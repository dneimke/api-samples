# Cursor Rules — quick reference

When using Cursor:

- Use this repository's prompts under `ai/` as canonical templates.
- For quick fixes, prefer small focused prompts: "Refactor method X to reduce complexity to <= 10 statements."
- For code generation, include: desired file path, public contract (DTOs/interfaces), and one-line acceptance criteria.

Example rule

- "If asked to add telemetry to an endpoint, add ILogger call `_logger.LogInformation`(...)` at the start of the method."
