#!/bin/bash

echo "BEGIN --------------package-cmdlet.sh-----------------------"
mkdir -p packaged/TASPowerShell
cp -rf ./bin/Debug/net7.0/* ./packaged/TASPowerShell
cp TASPowerShell.psd1 ./packaged/TASPowerShell/
echo "END   --------------package-cmdlet.sh-----------------------"
