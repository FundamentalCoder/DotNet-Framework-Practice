# DotNet-Framework-Practice

Dieses Repository enthält Lern- und Übungsprojekte zu .NET. Die Themen umfassen einfache Berechnungen, Konfiguration, Generics und unterschiedliche .NET-Zielplattformen.

## Projektübersicht

- `src/A.Projects.Calculator/` – Calculator-Bibliothek mit Addition, Subtraktion, Multiplikation und Division.
- `src/A.Projects.Calculator.Konsole/` – Konsolenanwendung für .NET Framework 4.8.
- `src/A.Projects.Calculator.NET8/` – Konsolenanwendung für .NET 8.
- `src/A.Projects.Calculator.Forms/` – Windows-Forms-Oberfläche für den Calculator.
- `src/B.Project.Konfiguration/` – Übungen zur Konfiguration mit `appSettings.json`.
- `src/B.Project.Konfiguration.Aufgabe/` und `src/B.Project.Konfiguration.SettingsUmgebungen/` – weitere Konfigurations- und Umgebungsübungen.
- `src/C.Project.Generic/` – Übungsprojekt zu Generics.
- `src/D.Project.Aufgabe/` – Notification-Service mit generischen Nachrichten.
- `src/D.Project.HostConfigGenerics/` – neu angelegtes Konsolenprojekt für .NET 10, das in die Lösung aufgenommen wurde.

## Aktueller Stand: HostConfigGenerics

Das Projekt `D.Project.HostConfigGenerics` zielt auf .NET 10 und aktiviert Nullable Reference Types sowie implizite Usings. Der Einstiegspunkt liegt in `src/D.Project.HostConfigGenerics/Program.cs` und gibt derzeit „Hello, World!“ aus. Host-, Konfigurations- und Generic-Funktionen sind in diesem Projekt noch nicht implementiert.

## Lösung öffnen und Projekt ausführen

Die Lösung `DotNet-Framework-Practice.slnx` kann in Visual Studio geöffnet werden. Das .NET-10-Projekt lässt sich über die .NET CLI erstellen und starten:

```powershell
dotnet build src/D.Project.HostConfigGenerics/D.Project.HostConfigGenerics.csproj
dotnet run --project src/D.Project.HostConfigGenerics/D.Project.HostConfigGenerics.csproj
```

Das Repository enthält Projekte für .NET Framework 4.8, .NET Standard 2.0, .NET 8 und .NET 10. Für .NET Framework kann zum Erstellen gegebenenfalls Visual Studio oder MSBuild erforderlich sein.

## Zweck

Das Repository dient zum Lernen und Ausprobieren von .NET-Funktionen und Projektstrukturen. Die Projekte können unabhängig voneinander unterschiedliche Konzepte demonstrieren.
