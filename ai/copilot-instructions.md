# Repository Copilot Instructions — short & opinionated

Purpose

- Help write idiomatic Minimal API endpoints, small helper methods, and README content.
- Prefer .NET 8 minimal APIs, immutable `record` DTOs, and explicit, well-named parameters.

Style Guidelines

- Keep endpoints small and single-responsibility.
- Use `async` for I/O operations.
- Favor explicit DTOs (use `record` for request/response).
- Add XML comments for public types.
- Return `Results.Ok(...)` / `Results.NotFound()` etc. in APIs.

Example prompt to use with Copilot

- "Create a minimal API endpoint to POST `/api/summarize` that accepts `SummarizeRequest` and returns `SummarizeResponse`. Use a service interface `ISummaryService` and register it in DI."

Where to look

- `src/Api/Program.cs` — API entry
- `ai/patterns.md` — (future) common prompt templates
