
using DanM.GlslOptimizer;

string source = File.ReadAllText("testshader.txt");
string optimized = GlslShader.OptimizeOpenGLVertex(source);
Console.WriteLine(optimized);
