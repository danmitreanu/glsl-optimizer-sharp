using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DanM.GlslOptimizer;

internal static partial class Native
{
    private const string Lib = "glslopt_dll";

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_initialize_(int target);

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_cleanup_(IntPtr ctx);

    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_optimize_(IntPtr ctx, int shaderType, string source, uint options);

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_shader_delete_(IntPtr shader);

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int glslopt_get_status_(IntPtr shader);

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_get_output_(IntPtr shader);

    [LibraryImport(Lib)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr glslopt_get_log_(IntPtr shader);
}
