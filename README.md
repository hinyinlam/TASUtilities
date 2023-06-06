Tanzu Application Service Utility
===

What is this project?
---
This is a PowerShell module to help [TAS](https://tanzu.vmware.com/application-service) administration and parse [BOSH](https://bosh.io/docs/) deployment manifest and output useful info.
Only the following single cmdlet is available:

- `Get-InstanceGroup` 

Project state
---
Really alpha, barely work, not for production.

How to install?
---
`install-Module -Name VMware.TanzuApplicationService.Utility`

How to use?
---
BOSH Manifest Parser
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

How To compile?
---

`dotnet clean && dotnet build`


`cd VMware.TanzuApplicationService.Utility/packaged`


`Import-Module -Name ./VMware.TanzuApplicationService.Utility`


`Get-Module -Name VMware.TanzuApplicationService.Utility`


Should show


```shell
ModuleType Version    PreRelease Name                                ExportedCommands
---------- -------    ---------- ----                                ----------------
Binary     0.1                   VMware.TanzuApplicationService.Uti… Get-InstanceGroup
```

Limitation
---
This PowerShell command is tested in MacOS `Powershell 7.3.4`

ie PowerShell core - `pwsh`
