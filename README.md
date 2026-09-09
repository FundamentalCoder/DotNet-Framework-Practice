A.Projects — Übungsprojekt: Einfacher Calculator
===============================================

Kurzbeschreibung
-----------------
Dieses Repository enthält ein kleines Übungsprojekt mit einer wiederverwendbaren Calculator-Bibliothek und zwei Konsolenanwendungen (eine für .NET Framework 4.8, eine für .NET 8). Ziel war es, grundlegende arithmetische Operationen zu implementieren und die Bibliothek aus unterschiedlichen Projekttypen zu verwenden.

Projektstruktur
---------------
- src/A.Projects.Calculator/
  - Bibliothek (Target z. B. .NET Standard 2.0)
  - Enthält A.Projects.Calculator.Calculator mit den Kernmethoden (Add, Subtract, Multiply, Divide).
- src/A.Projects.Calculator.Konsole/
  - Konsolenanwendung (zielt auf .NET Framework 4.8)
  - Nutzt die Calculator-Bibliothek und liest zwei Zahlen von der Konsole ein.
- src/A.Projects.Calculator.NET8/
  - Konsolenanwendung (zielt auf .NET 8)
  - Ähnliche Funktionalität wie die .NET Framework-Version, demonstriert Zielplattform .NET 8.
- src/A.Projects.Calculator.Forms/
  - Windows Forms-Anwendung (zielt auf .NET Framework)
  - Einfache GUI mit Tasten und einem Textfeld, nutzt die Calculator-Bibliothek für Operationen.

Was implementiert wurde
-----------------------
- Klasse: A.Projects.Calculator.Calculator
  - public int Add(int a, int b)
  - public int Subtract(int a, int b)
  - public int Multiply(int a, int b)
  - public double Divide(int a, int b) — wirft DivideByZeroException, wenn b == 0
- Zwei Konsolenprogramme, die die Bibliothek verwenden und die Ergebnisse der Operationen ausgeben.
- Einfache Fehlerbehandlung beim Divisionsversuch durch Abfangen der DivideByZeroException in den Konsolenprogrammen.
 - Eine Windows Forms-Anwendung (Form1) mit einfacher Tastatur-Eingabe (textBox1) und Button-Handlern, die die Calculator-Klasse verwenden.

Beispiel (Konsole)
------------------
Eingaben:
- erste Zahl: 10
- zweite Zahl: 2

Ausgabe:
- Addition: 12
- Subtraction: 8
- Multiplication: 20
- Division: 5

Bei Division durch 0 wird die Meldung "Cannot divide by zero." ausgegeben (oder die entsprechende deutsche Meldung, falls geändert).

Build & Ausführung
------------------
Empfohlen: Visual Studio 2022/2026 öffnen und die Lösung (A.Projects.slnx) laden.

Mit dotnet CLI (für .NET 8-Projekt):
- Build: dotnet build src\\A.Projects.Calculator.NET8\\A.Projects.Calculator.Konsole.NET8.csproj
- Run:   dotnet run --project src\\A.Projects.Calculator.NET8\\A.Projects.Calculator.Konsole.NET8.csproj

Die .NET Framework-Konsole muss ggf. über Visual Studio gestartet werden (oder msbuild für .NET Framework verwenden).

Erweiterungsmöglichkeiten
------------------------
- Unit-Tests hinzufügen (z. B. xUnit oder NUnit) für die Calculator-Methoden.
- Überladungen oder Generics hinzufügen, um auch double-Argumente direkt zu unterstützen.
- CLI-Argumente (z. B. --a 5 --b 3 --op add) für nicht-interaktive Nutzung.
- Logging und robustere Fehlerbehandlung einbauen.

Hinweise
--------
- Dieses Projekt ist als Lern-/Übungsprojekt gedacht.
- Keine Lizenzangaben im Repo; bei Bedarf eine passende LICENSE-Datei hinzufügen.

Kontakt
-------
Bei Fragen zum Projektinhalt in diesem Repository bitte im entsprechenden Issue/Commit nachfragen.
