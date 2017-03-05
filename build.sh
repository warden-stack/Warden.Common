#!/bin/bash
dotnet restore --source "https://api.nuget.org/v3/index.json" --source "https://www.myget.org/F/warden%build-env%/api/v3/index.json" --no-cache
dotnet pack -o .