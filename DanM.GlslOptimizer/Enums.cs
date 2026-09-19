namespace DanM.GlslOptimizer;

public enum GlslTarget : int
{
    OpenGL = 0,
    OpenGLES20 = 1,
    OpenGLES30 = 2,
    Metal = 3
}

public enum GlslShaderType : int
{
    Vertex = 0,
    Fragment = 1
}

[Flags]
public enum GlslOptimizeOptions : uint
{
    None = 0,
    SkipPreprocessor = 1 << 0,
    NotFullShader = 1 << 1
}
