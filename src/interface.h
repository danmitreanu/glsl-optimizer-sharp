#ifndef GLSLOPT_DLL_INTERFACE
#define GLSLOPT_DLL_INTERFACE

// CMake defines <target>_EXPORTS automatically when building a SHARED library,
// so glslopt_dll_EXPORTS is set while compiling the DLL itself and unset for
// consumers that include this header.
#if defined(glslopt_dll_EXPORTS)
	#define GLSLOPT_BUILDING_DLL
#endif

#if defined(_WIN32) || defined(__CYGWIN__)
	#ifdef GLSLOPT_BUILDING_DLL
		#define DLL_EXPORT __declspec(dllexport)
	#else
		#define DLL_EXPORT __declspec(dllimport)
	#endif
#elif defined(__GNUC__) || defined(__clang__)
	#define DLL_EXPORT __attribute__((visibility("default")))
#else
	#define DLL_EXPORT
#endif

#ifdef __cplusplus
	#define GLSLOPT_EXTERN_C_BEGIN extern "C" {
	#define GLSLOPT_EXTERN_C_END }
#else
	#define GLSLOPT_EXTERN_C_BEGIN
	#define GLSLOPT_EXTERN_C_END
#endif

GLSLOPT_EXTERN_C_BEGIN

// Example:
// DLL_EXPORT int glslopt_example(int value);

DLL_EXPORT void* glslopt_initialize_(int target);
DLL_EXPORT void glslopt_cleanup_(void* ctx);
DLL_EXPORT void* glslopt_optimize_(void* ctx, int shaderType, const char* shaderSource, unsigned int options);
DLL_EXPORT void glslopt_shader_delete_(void* shader);
DLL_EXPORT int glslopt_get_status_(void* shader);
DLL_EXPORT const char* glslopt_get_output_(void* shader);
DLL_EXPORT const char* glslopt_get_log_(void* shader);

GLSLOPT_EXTERN_C_END

#endif
