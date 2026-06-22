#!/bin/bash
cd "$(dirname "$0")"

echo "Running LegacyCode.Console for multiple orderIds..."

dotnet run --project ./LegacyCode.Console.csproj -- 1001
echo ----------------------------------------

dotnet run --project ./LegacyCode.Console.csproj -- 1002
echo ----------------------------------------

dotnet run --project ./LegacyCode.Console.csproj -- 1003
echo ----------------------------------------

dotnet run --project ./LegacyCode.Console.csproj -- 1004
echo ----------------------------------------


echo "Done."
