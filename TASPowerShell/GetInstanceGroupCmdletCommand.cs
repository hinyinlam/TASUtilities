using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using DeploymentManifestParser;

namespace VMware.PowerShell.TAS.Utility
{
    [Cmdlet(VerbsCommon.Get, "InstanceGroup")]
    [OutputType(typeof(InstanceGroupRecord))]
    public class GetInstanceGroupCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string BoshManifestPath { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            if (!Path.IsPathFullyQualified(BoshManifestPath))
            {
                BoshManifestPath = Path.GetFullPath(SessionState.Path.CurrentLocation.Path +
                                                    Path.DirectorySeparatorChar +
                                                    BoshManifestPath);
            }

            if (!File.Exists(BoshManifestPath))
            {
                throw new FileNotFoundException(
                    $"File not found: {BoshManifestPath}");
            }

            var boshManifest = BoshManifestDeserialization.GetDeserializedBoshManifest(BoshManifestPath);
            foreach (var ig in boshManifest.InstanceGroups)
            {
                var igRecord = new InstanceGroupRecord
                {
                    InstanceGroupName = ig.Name,
                    NumberOfInstances = ig.instances,
                };
                WriteObject(igRecord);
            }
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }

    public class InstanceGroupRecord
    {
        public string InstanceGroupName;
        public int NumberOfInstances;
    }
}