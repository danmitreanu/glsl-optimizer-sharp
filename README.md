# DanM.GlslOptimizer

.NET bindings for [glsl-optimizer](https://github.com/aras-p/glsl-optimizer), the GLSL
optimizing compiler originally from Mesa and maintained by Unity. Native binaries for
Windows, Linux and macOS ship inside the package, so there is nothing to build or install
separately.

## Install

```
dotnet add package DanM.GlslOptimizer
```

## Usage

```csharp
using DanM.GlslOptimizer;

using var ctx = new GlslOptimizerContext(GlslTarget.OpenGL);
using var shader = ctx.Optimize(
    GlslShaderType.Fragment,
    "void main() { float x = 1.0 + 2.0; gl_FragColor = vec4(x, 0.0, 0.0, 1.0); }");

if (shader.Status)
    Console.WriteLine(shader.Output);
else
    Console.WriteLine(shader.Log);
```

Output:

```glsl
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1.yzw = vec3(0.0, 0.0, 1.0);
  tmpvar_1.x = 3.0;
  gl_FragColor = tmpvar_1;
}
```

`GlslOptimizerContext` and `OptimizedShader` both own native handles, so dispose them
(`using`) rather than leaving them to the finalizer.

## How it works

[`aras-p/glsl-optimizer`](https://github.com/aras-p/glsl-optimizer) was taken and its `CMakeLists.txt` stripped to only build the static library. `glsl_optimizer` is linked to `glslopt_dll`, the dynamic library shipped with this project. The .NET library P/Invokes into that.

The dynamic library's code is in `src/`. The stripped `CMakeLists.txt` is in the root of the repo.

## Supported platforms

| RID           | Native library         |
| ------------- | ---------------------- |
| `win-x64`     | `glslopt_dll.dll`      |
| `linux-x64`   | `libglslopt_dll.so`    |
| `linux-arm64` | `libglslopt_dll.so`    |
| `osx-x64`     | `libglslopt_dll.dylib` |
| `osx-arm64`   | `libglslopt_dll.dylib` |

There is currently no `win-arm64` binary.

## AI disclosure

AI (Opus 5) was used write the NuGet publishing pipeline (GitHub Actions and some .csproj editing), parts of this README, and the `interface.h` DLL_EXPORT define.

## License

MIT. The bundled native binaries are built from glsl-optimizer, which is also MIT
licensed (Brian Paul; Unity Technologies) — see [LICENSE](LICENSE).
