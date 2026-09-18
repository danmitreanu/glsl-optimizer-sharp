cmake_minimum_required(VERSION 3.50)
project(glsl-optimizer)

set(CMAKE_BUILD_TYPE Release CACHE STRING "" FORCE)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

file(GLOB glcpp-library_sources glsl-optimizer/src/glsl/glcpp/*.c glsl-optimizer/src/util/*.c)
add_library(glcpp-library STATIC ${glcpp-library_sources})
target_include_directories(glcpp-library PUBLIC glsl-optimizer/include)
target_include_directories(glcpp-library PUBLIC glsl-optimizer/src/mesa)
target_include_directories(glcpp-library PUBLIC glsl-optimizer/src)

file(GLOB mesa_sources glsl-optimizer/src/mesa/program/*.c glsl-optimizer/src/mesa/main/*.c)
add_library(mesa STATIC ${mesa_sources})
target_include_directories(mesa PUBLIC glsl-optimizer/include)
target_include_directories(mesa PUBLIC glsl-optimizer/src/mesa)
target_include_directories(mesa PUBLIC glsl-optimizer/src)

file(GLOB glsl_sources glsl-optimizer/src/glsl/*.cpp glsl-optimizer/src/glsl/*.c)
file(GLOB glsl_sources_remove glsl-optimizer/src/glsl/main.cpp glsl-optimizer/src/glsl/builtin_stubs.cpp)
list(REMOVE_ITEM glsl_sources ${glsl_sources_remove})
add_library(glsl_optimizer STATIC ${glsl_sources})
target_link_libraries(glsl_optimizer glcpp-library mesa)
target_include_directories(glsl_optimizer PUBLIC glsl-optimizer/src/glsl)

# DLL below
add_library(glslopt_dll SHARED src/interface.cpp src/interface.h)
target_link_libraries(glslopt_dll PRIVATE glsl_optimizer)
