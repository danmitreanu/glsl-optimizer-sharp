# Changelog

## 1.0.0

Initial release

## 1.1.0

Added convenience C# wrappers in `GlslShader.cs`.

## 1.1.1

Fixed an issue where some shaders would hang spontaneously on linux-arm64 (in Docker) (added `-fno-strict-aliasing` for linux-arm64 binary build).

This is probably due to `glsl-shader`'s vector/list code.

## 1.1.2

Fixed an issue where some shaders would hang spontaneously on linux-amd64 (in Docker) (added `-fno-strict-aliasing` for linux-amd64 binary build).

This is probably due to `glsl-shader`'s vector/list code.

