# API Samples

Quick start

1. Open the repository in VS Code. Use the devcontainer (`.devcontainer/devcontainer.json`) for a consistent environment with recommended extensions.
2. From the workspace root run the API:

```powershell
cd src/Api
dotnet run
```

3. Open `http://localhost:5000/swagger` (or the port shown in the console) to exercise the endpoints.

AI guidance

- Lightweight Copilot and Cursor guidance lives in `ai/`.
- While the repo doesn't call any LLMs yet, the `GET /ai/instructions` endpoint will return the contents of `ai/copilot-instructions.md` when available in the runtime path.

Files created

- `src/Api/Program.cs` — Minimal API with `/health`, `/api/echo`, `/ai/instructions`.
- `ai/copilot-instructions.md`, `ai/cursor-rules.md` — AI hints for Copilot/Cursor.
- `.devcontainer/devcontainer.json` — Devcontainer recommending Copilot and Cursor extensions.
- `.vscode/extensions.json` — VS Code recommended extensions.
