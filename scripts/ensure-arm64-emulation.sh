#!/bin/bash
# Registers QEMU arm64 emulation in the Docker host kernel if linux/arm64 isn't already supported.
# Needed on x64 Linux hosts to build and run linux/arm64 containers. No-op on arm64 hosts.
# The registration is lost on reboot, so the build scripts call this every time.

if ! docker run --privileged --rm tonistiigi/binfmt | grep -q '"linux/arm64"'; then
	docker run --privileged --rm tonistiigi/binfmt --install arm64 || { echo 'Failed to register arm64 emulation' >&2; exit 1; }
fi
