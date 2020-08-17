powershell .\build\psake.ps1 ".\build\default.ps1" -properties @{configuration='Release';skipTests=$true}
pause