BOSH Deployment Manifest Parser
===

What is this project?
---
This is a PowerShell module to parse [BOSH](https://bosh.io/docs/) deployment manifest and output useful info.
A set of cmdlet are available:
`Get-InstanceGroup`

Project state
---
Really alpha, barely work


How to install?
---

`dotnet clean && dotnet build`

`cd TASPowerShell/packaged`

`Import-Module -Name ./TASPowerShell/`

`Get-Module -Name TASPowerShell`
Should show 
```shell
ModuleType Version    PreRelease Name                 ExportedCommands
---------- -------    ---------- ----                 ----------------
Binary     0.1                   TASPowerShell        Get-InstanceGroup
```

How to use?
---
`Get-InstanceGroup -BoshManifestPath ./sample-instance-group.yaml`
```shell
Get-InstanceGroup -BoshManifestPath ./TASPowerShell/sample-instance-group.yaml

InstanceGroupName NumberOfInstances
----------------- -----------------
database                          3
diegocell                         9
gorouter                          9

```


![Demo](https://github.com/hinyinlam/TASUtilities/blob/main/demo.gif)


Limitation
---
This PowerShell command is tested in MacOS `Powershell 7.3.4`

ie PowerShell core - `pwsh`
