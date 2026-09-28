#!/bin/bash

cd /source

cmake -G "Unix Makefiles" -B/build -DCMAKE_BUILD_TYPE=Release
cd /build
cmake --build . --target glslopt_dll -- -j 8

mkdir -p /output/linux-x64
cp libglslopt_dll.so /output/linux-x64/

objdump -f /output/linux-arm64/libglslopt_dll.so

