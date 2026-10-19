# Copilot Instructions for "Immunities Reset (Continued)" Mod

## Mod Overview and Purpose

The "Immunities Reset (Continued)" mod for RimWorld serves an essential function for players who frequently add or remove mods that interact with pawns' health attributes. Specifically, this mod addresses issues related to hediffs (health definitions) that track immunities. When a mod that introduced such hediffs is removed, it can leave behind erroneous immunity records in the save game. These remnants can cause cascading errors, affecting various game systems such as needs management and other health systems.

This mod provides a mechanism to "nuke" or remove these erroneous records, allowing players to continue their game sessions without lingering errors related to removed mods. Additionally, it includes mod options for resetting health records related to immunities, thus maintaining a clean and stable gameplay experience.

## Key Features and Systems

- **Immunity Record Reset:** Offers a user-triggered method to reset all erroneous immunity records in the game, effectively cleaning up after mod changes.
  
- **Compatibility:** Designed to be compatible with any mod that is removed, which previously included hediffs with potential for immunities. Ensures that this mod does not adversely impact ongoing games when such mods are uninstalled.

- **User-Friendly Options:** Provides mod options for players to customize the reset behavior, offering flexibility in managing immunity data.

## Coding Patterns and Conventions

The mod is developed following C# coding conventions typical in RimWorld modding, focusing on clean, maintainable, and efficient code structure.

- **Folder Structure:** Source files are organized within a dedicated `ImmuCorrect` folder.
- **Naming Conventions:** Classes and methods use PascalCase, while method parameters and local variables use camelCase.
- **Type Definitions:** Emphasizes clarity in type definitions, particularly for configuration and data handling classes such as `Controller`, `ImmuCorrection`, and `Settings`.

## XML Integration

While this mod does not currently utilize any XML files, SQL integration in RimWorld generally involves defining new game assets or modifying existing ones. For potential future expansions of this mod:
   
- XML files should be placed in a `Defs` folder within the mod directory.
- Naming should be consistent with game entities being modified or introduced.
- Utilize sequence tags (`<Defs>`, `<ThingDef>`, etc.) appropriately to integrate custom definitions or modify existing assets seamlessly.

## Harmony Patching

The mod uses Harmony, a popular library for patching methods at runtime in C# applications. Within the `HarmonySetup.cs` file:

- **Harmony Patch:** The patching is initialized by creating a `Harmony` instance with a unique identifier, typically the mod's package ID (`Mlie.ImmunitiesReset`).
  
- **Patch Execution:** Hooks into vanilla methods to remove or correct immunity records as necessary without permanently altering base game code.

- **NonPublicField Access:** Non-public fields are accessed responsibly using Harmony's reflection capabilities, ensuring compliance with RimWorld's modding standards.

## Suggestions for Copilot

- **Code Completion:** Suggest auto-completion for creating Harmony patches, including prefix and postfix methods.
  
- **Error Handling:** Provide error checking snippets for scenarios where removed mods may not have been completely cleaned up.
  
- **Settings Management:** Offer templates for implementing custom settings menus and saving/loading user preferences.

- **Integration Checks:** Recommend code blocks for detecting if other mods, especially those adding hediffs with immunities, are present.

- **Logging Utilities:** Enhance debug best practices by suggesting logging utilities for better error reporting, facilitating easier troubleshooting.

- **Expansion Capabilities:** Encourage ideas for extending the mod's functionality through XML definitions when integrating additional in-game features.

By adhering to these guidelines, contributors and Copilot can assist in maintaining and expanding the "Immunities Reset (Continued)" mod effectively. This ensures a robust and error-free experience for RimWorld players.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

