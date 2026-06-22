#!/usr/bin/env bash
cd "$(dirname "$0")"

git add .
dotnet test && git commit -m "It works!" || git reset --hard
