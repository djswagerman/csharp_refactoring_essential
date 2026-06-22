#!/usr/bin/env bash
cd "$(dirname "$0")"

git add .
if dotnet test; then
  COMMIT_MSG=$(git diff --cached | pi -p "Generate a concise, imperative commit message for this staged diff (one line, no quotes). Output only the message, nothing else.")
  git commit -m "$COMMIT_MSG"
else
  git reset --hard
fi
