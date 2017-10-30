Install-PackageProvider NuGet -Force
Import-PackageProvider NuGet -Force
Set-PSRepository -Name PSGallery -InstallationPolicy Trusted

Install-Module -Name xWebAdministration

$env:PSModulePath = [System.Environment]::GetEnvironmentVariable("PSModulePath","Machine")