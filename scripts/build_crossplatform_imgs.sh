#!/bin/bash

bash "$(dirname "$0")/ensure-arm64-emulation.sh" || exit 1

for ARCH in amd64 arm64; do
	docker buildx build \
		--platform "linux/$ARCH" \
		-t "glslopt-builder:$ARCH" -f "./build-env.Dockerfile" \
		--load \
		.
done

