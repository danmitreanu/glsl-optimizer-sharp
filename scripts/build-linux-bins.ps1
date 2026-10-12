& "$PSScriptRoot/ensure-arm64-emulation.ps1"

$root = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
$output = Join-Path $root 'bin'

docker run --rm -it --platform linux/arm64 -v "${root}:/source" -v "${output}:/output" glslopt-builder:arm64 /bin/bash /source/scripts/build-in-docker-arm64.sh

docker run --rm -it --platform linux/amd64 -v "${root}:/source" -v "${output}:/output" glslopt-builder:amd64 /bin/bash /source/scripts/build-in-docker-amd64.sh
