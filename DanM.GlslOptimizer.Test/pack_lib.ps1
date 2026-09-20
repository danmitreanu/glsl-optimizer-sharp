$rootPath = Split-Path $PSScriptRoot -Parent

Push-Location $rootPath
try
{
    dotnet pack DanM.GlslOptimizer -c Release
}
finally
{
    Pop-Location
}
