#!env bash 

env pwsh -Command Publish-Module -Name VMware.TanzuApplicationService.Utility -NuGetApiKey "$NUGET_API_KEY"
