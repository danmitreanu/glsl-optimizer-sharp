#include "interface.h"

#include <glsl/glsl_optimizer.h>

/*glslopt_ctx**/void* glslopt_initialize_(int target)
{
	glslopt_target target_ = static_cast<glslopt_target>(target);
	return glslopt_initialize(target_);
}

/*glslopt_shader*/void* glslopt_optimize_(void* ctx, int shaderType, const char* shaderSource, unsigned int options)
{
	auto* ctx_ = reinterpret_cast<glslopt_ctx*>(ctx);
	glslopt_shader_type shaderType_ = static_cast<glslopt_shader_type>(shaderType);
	return glslopt_optimize(ctx_, shaderType_, shaderSource, options);
}

void glslopt_cleanup_(void* ctx)
{
	auto* ctx_ = reinterpret_cast<glslopt_ctx*>(ctx);
	glslopt_cleanup(ctx_);
}

void glslopt_shader_delete_(void* shader)
{
	auto* shader_ = reinterpret_cast<glslopt_shader*>(shader);
	glslopt_shader_delete(shader_);
}

int glslopt_get_status_(void* shader)
{
	auto* shader_ = reinterpret_cast<glslopt_shader*>(shader);
	return glslopt_get_status(shader_) ? 1 : 0;
}

const char* glslopt_get_output_(void* shader)
{
	auto* shader_ = reinterpret_cast<glslopt_shader*>(shader);
	return glslopt_get_output(shader_);
}

const char* glslopt_get_log_(void* shader)
{
	auto* shader_ = reinterpret_cast<glslopt_shader*>(shader);
	return glslopt_get_log(shader_);
}

