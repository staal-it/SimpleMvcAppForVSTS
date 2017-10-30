Param(
  [Parameter(Mandatory=$true)]
  [string]$connectionString
)

.\migrate.exe SimpleMVCApp.Data.dll /connectionString="$($connectionString)" /connectionProviderName="System.Data.SqlClient"