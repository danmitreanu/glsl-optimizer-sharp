using Microsoft.Win32.SafeHandles;

namespace DanM.GlslOptimizer;

public class GlslOptimizerContext : SafeHandleZeroOrMinusOneIsInvalid
{
    public GlslOptimizerContext(GlslTarget target) : base(ownsHandle: true)
    {
        int targeti = (int)target;
        handle = Native.glslopt_initialize_(targeti);
    }

    public OptimizedShader Optimize(GlslShaderType shaderType, string source, GlslOptimizeOptions options = GlslOptimizeOptions.None)
    {
        int shaderTypei = (int)shaderType;
        uint optionsi = (uint)options;
        IntPtr shaderHandle = Native.glslopt_optimize_(handle, shaderTypei, source, optionsi);
        return new OptimizedShader(shaderHandle);
    }

    protected override bool ReleaseHandle()
    {
        Native.glslopt_cleanup_(handle);
        return true;
    }
}
