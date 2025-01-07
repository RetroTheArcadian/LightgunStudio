rmdir /s /q Release
mkdir Release
dotnet publish LightgunStudio\LightgunStudio.csproj -c Release /p:PublishProfile=LightgunStudio\Properties\PublishProfiles\FolderProfile.pubxml
dotnet publish LightgunStudio.Console\LightgunStudio.Console.csproj -c Release /p:PublishProfile=LightgunStudio.Console\Properties\PublishProfiles\FolderProfile.pubxml
del LightgunStudio.zip
powershell Compress-Archive ./Release/* LightgunStudio.zip
rmdir /s /q Release
echo Build done...
pause