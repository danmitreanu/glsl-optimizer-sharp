#!/bin/bash

cd /source

cmake -G "Unix Makefiles" -B/build -DCMAKE_BUILD_TYPE=Release -DCMAKE_C_FLAGS=-fno-strict-aliasing -DCMAKE_CXX_FLAGS=-fno-strict-aliasing
cd /build
cmake --build . --target glslopt_dll -- -j 8

mkdir -p /output/linux-x64
cp libglslopt_dll.so /output/linux-x64/

objdump -f /output/linux-x64/libglslopt_dll.so

