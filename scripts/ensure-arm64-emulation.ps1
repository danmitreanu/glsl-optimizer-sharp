# Registers QEMU arm64 emulation in the Docker VM if it isn't already.
# Needed on x64 hosts (e.g. Rancher Desktop on WSL) to build and run linux/arm64 containers.
# The registration is lost when the VM restarts, so the build scripts call this every time.

$status = docker run --privileged --rm tonistiigi/binfmt | ConvertFrom-Json
if ($status.supported -notcontains 'linux/arm64') {
	docker run --privileged --rm tonistiigi/binfmt --install arm64
	if ($LASTEXITCODE -ne 0) { throw 'Failed to register arm64 emulation' }
}
