#!/bin/bash

echo "BEGIN --------------package-cmdlet.sh-----------------------"
export PUBLISH_FOLDER="./packaged/VMware.TanzuApplicationService.Utility"
mkdir -p $PUBLISH_FOLDER
cp -rf ./bin/Debug/net7.0/* $PUBLISH_FOLDER/
cp VMware.TanzuApplicationService.Utility.psd1 $PUBLISH_FOLDER/
echo "END   --------------package-cmdlet.sh-----------------------"
