namespace DanM.GlslOptimizer;

public class GlslOptimizerException(string msg) : Exception(msg);

public static class GlslShader
{
    public static string Optimize(GlslTarget target, GlslShaderType type, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
    {
        using GlslOptimizerContext ctx = new(target);
        using var shader = ctx.Optimize(type, source, options);
        if (!shader.Status)
        {
            throw new GlslOptimizerException(shader.Log ?? "Failed to optimize shader");
        }

        return shader.Output;
    }

    public static string OptimizeOpenGL(GlslShaderType type, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => Optimize(GlslTarget.OpenGL, type, source, options);

    public static string OptimizeOpenGLVertex(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGL(GlslShaderType.Vertex, source, options);

    public static string OptimizeOpenGLFragment(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGL(GlslShaderType.Fragment, source, options);

    public static string OptimizeOpenGLES20(GlslShaderType type, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => Optimize(GlslTarget.OpenGLES20, type, source, options);

    public static string OptimizeOpenGLES20Vertex(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGLES20(GlslShaderType.Vertex, source, options);

    public static string OptimizeOpenGLES20Fragment(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGLES20(GlslShaderType.Fragment, source, options);

    public static string OptimizeOpenGLES30(GlslShaderType type, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => Optimize(GlslTarget.OpenGLES30, type, source, options);

    public static string OptimizeOpenGLES30Vertex(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGLES30(GlslShaderType.Vertex, source, options);

    public static string OptimizeOpenGLES30Fragment(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeOpenGLES30(GlslShaderType.Fragment, source, options);

    public static string OptimizeMetal(GlslShaderType type, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => Optimize(GlslTarget.Metal, type, source, options);

    public static string OptimizeMetalVertex(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeMetal(GlslShaderType.Vertex, source, options);

    public static string OptimizeMetalFragment(string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
        => OptimizeMetal(GlslShaderType.Fragment, source, options);
}
