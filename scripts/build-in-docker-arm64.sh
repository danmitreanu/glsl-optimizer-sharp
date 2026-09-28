#!/bin/bash

cd /source

cmake -G "Unix Makefiles" -B/build -DCMAKE_BUILD_TYPE=Release -DCMAKE_C_FLAGS=-fno-strict-aliasing -DCMAKE_CXX_FLAGS=-fno-strict-aliasing
cd /build
cmake --build . --target glslopt_dll

mkdir -p /output/linux-arm64
cp libglslopt_dll.so /output/linux-arm64/

objdump -f /output/linux-arm64/libglslopt_dll.so

