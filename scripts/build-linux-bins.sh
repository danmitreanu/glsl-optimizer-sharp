#!/bin/bash

docker run --rm -it --platform linux/arm64 -v ../:/source -v ../bin/:/output glslopt-builder:arm64 /bin/bash /source/scripts/build-in-docker-arm64.sh

docker run --rm -it --platform linux/amd64 -v ../:/source -v ../bin/:/output glslopt-builder:amd64 /bin/bash /source/scripts/build-in-docker-amd64.sh

