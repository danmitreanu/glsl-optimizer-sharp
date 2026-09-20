
using DanM.GlslOptimizer;

string optimized = GlslShader.OptimizeOpenGLFragment("void main() { float x = 1.0 + 2.0; gl_FragColor = vec4(x, 0.0, 0.0, 1.0); }");
Console.WriteLine(optimized);
