& "$PSScriptRoot/ensure-arm64-emulation.ps1"

foreach ($arch in 'amd64', 'arm64') {
	docker buildx build `
		--platform "linux/$arch" `
		-t "glslopt-builder:$arch" -f "$PSScriptRoot/build-env.Dockerfile" `
		--load `
		$PSScriptRoot
}
