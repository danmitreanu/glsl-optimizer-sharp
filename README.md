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

### Targets

`GlslTarget` selects the output dialect: `OpenGL`, `OpenGLES20`, `OpenGLES30` or `Metal`.

### Options

`GlslOptimizeOptions` is a flags enum: `SkipPreprocessor` to leave `#` directives alone,
`NotFullShader` to optimize a fragment of a shader rather than a complete one.

## Supported platforms

| RID           | Native library         |
| ------------- | ---------------------- |
| `win-x64`     | `glslopt_dll.dll`      |
| `linux-x64`   | `libglslopt_dll.so`    |
| `linux-arm64` | `libglslopt_dll.so`    |
| `osx-x64`     | `libglslopt_dll.dylib` |
| `osx-arm64`   | `libglslopt_dll.dylib` |

There is currently no `win-arm64` binary.

## License

MIT. The bundled native binaries are built from glsl-optimizer, which is also MIT
licensed (Brian Paul; Unity Technologies) — see [LICENSE](LICENSE).
