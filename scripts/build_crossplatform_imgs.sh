#!/bin/bash

for ARCH in amd64 arm64; do
	docker buildx build \
		--platform "linux/$ARCH" \
		-t "glslopt-builder:$ARCH" -f "./build-env.Dockerfile" \
		--load \
		.
done

