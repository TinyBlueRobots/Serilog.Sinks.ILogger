NUGETVERSION=1.0.3
dotnet pack Serilog.Sinks.ILogger -c Release /p:PackageVersion=$NUGETVERSION
dotnet nuget push Serilog.Sinks.ILogger/bin/Release/Serilog.Sinks.ILogger.$NUGETVERSION.nupkg -k $NUGETKEY -s nuget.org
