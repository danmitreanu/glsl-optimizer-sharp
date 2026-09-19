using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace DanM.GlslOptimizer;

public class OptimizedShader : SafeHandleZeroOrMinusOneIsInvalid
{
    public bool Status => GetStatus() != 0;
    public string Output => GetOutput();
    public string? Log => GetLog();

    internal OptimizedShader(IntPtr shader) : base(ownsHandle: true)
    {
        handle = shader;
    }

    private int GetStatus()
    {
        return Native.glslopt_get_status_(handle);
    }

    private string GetOutput()
    {
        IntPtr outputPtr = Native.glslopt_get_output_(handle);
        return Marshal.PtrToStringUTF8(outputPtr) ?? string.Empty;
    }

    private string? GetLog()
    {
        IntPtr logPtr = Native.glslopt_get_log_(handle);
        return Marshal.PtrToStringUTF8(logPtr);
    }

    protected override bool ReleaseHandle()
    {
        Native.glslopt_shader_delete_(handle);
        return true;
    }
}
