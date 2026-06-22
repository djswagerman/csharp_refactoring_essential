@echo off
git add .
dotnet test && (
  for /f "tokens=* delims=" %%i in ('git diff --cached ^| pi -p "Generate a concise, imperative commit message for this staged diff (one line, no quotes). Output only the message, nothing else."') do set COMMIT_MSG=%%i
  git commit -m "%COMMIT_MSG%"
) || git reset --hard
