#!env bash 

env pwsh -Command Publish-Module -Name packaged/VMware.TanzuApplicationService.Utility -NuGetApiKey "$NUGET_API_KEY"
