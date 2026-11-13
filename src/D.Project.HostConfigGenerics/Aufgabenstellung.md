# Praxisübung für Junior Developer – .NET Host, dynamische Konfiguration, Extension Methods und Generics

**C# / .NET 9 · Console Application · 4 Hauptmodule + 1 Bonusmodul · Schwierigkeitsgrad: Junior bis Intermediate**

## 1. Ausgangssituation

Ein Logistikunternehmen möchte die Temperaturen seiner Lagerbereiche überwachen. Einige Bereiche enthalten temperaturempfindliche Waren und müssen deshalb regelmässig kontrolliert werden.

Die Anwendung soll verschiedene Sensoren verwalten, Messwerte verarbeiten und Warnungen ausgeben, sobald definierte Grenzwerte überschritten werden.

Die Anforderungen werden schrittweise erweitert:

- Die Anwendung verwendet einen Generic Host mit Dependency Injection.
- Die Grenzwerte und Einstellungen werden in einer `appsettings.json` verwaltet.
- Änderungen an der Konfiguration werden während der Laufzeit erkannt, ohne die Anwendung neu zu starten.
- Wiederverwendbare Funktionalitäten werden in einer separaten Class Library mit Extension Methods bereitgestellt.
- Unterschiedliche Messwerte werden mit generischen Klassen und Methoden mit Constraints verarbeitet.

Ziel ist nicht nur eine funktionierende Anwendung. Der Junior soll die jeweiligen Konzepte verstehen, selbstständig implementieren und seine technischen Entscheidungen begründen können.

## 2. Gesamtübersicht

### Warehouse Monitoring

Temperaturüberwachung der Lagerbereiche.

| Modul | Thema | Inhalt |
|---|---|---|
| Modul 1 | Generic Host | Host, Services, DI |
| Modul 2 | Live-Konfiguration | JSON, `IOptionsMonitor<T>` |
| Modul 3 | Extension Library | Erweiterungen, NuGet |
| Modul 4 | Generics | Constraints, Interfaces |
| Modul 5 – Bonus | Integration | Alle Komponenten zu einer Anwendung verbinden |

Alle vier Hauptmodule können eigenständig bearbeitet werden.

## Modul 1 – Generic Host und Dependency Injection

### Grundlagen und Ziel

Der Junior soll verstehen, wie eine .NET-Anwendung aufgebaut wird und wie sich Services über den Dependency-Injection-Container verwalten lassen.

### Aufgabe 1.1 – Projekt erstellen

Erstelle eine neue .NET-Konsolenanwendung mit dem Namen:

`Warehouse.Monitoring.Console`

Die Anwendung muss mit `Host.CreateDefaultBuilder(args)` gestartet werden.

Anforderungen:

1. Erstelle den Host mithilfe von `Host.CreateDefaultBuilder(args)`.
2. Registriere die benötigten Services im DI-Container.
3. Starte die Anwendung über den Host.
4. Verwende `ILogger<T>` für die Ausgabe.
5. Die Anwendung soll bis zum manuellen Beenden weiterlaufen.

### Aufgabe 1.2 – Services erstellen

Implementiere die folgenden Komponenten:

| Komponente | Verantwortung |
|---|---|
| `ISensorReader` | Messwert eines Sensors lesen |
| `SensorReader` | Simulierte Temperatur erzeugen |
| `ITemperatureMonitor` | Temperatur prüfen |
| `TemperatureMonitor` | Messwert auswerten und protokollieren |
| `MonitoringWorker` | Regelmässige Messungen auslösen |

Der `MonitoringWorker` soll von `BackgroundService` erben und alle fünf Sekunden eine Messung anfordern.

Der `SensorReader` darf zunächst Zufallswerte zwischen −10 °C und +30 °C erzeugen.

### Erwartete Konsolenausgabe

```text
info: MonitoringWorker
	  Warehouse Monitoring started.

info: SensorReader
	  Reading sensor: Freezer-01

info: TemperatureMonitor
	  Temperature: -5.3 °C

info: TemperatureMonitor
	  Temperature: -4.8 °C
```

### Fragen zur Vertiefung

- Was ist der Unterschied zwischen `IHost` und `BackgroundService`?
- Weshalb wird ein Service registriert, statt direkt eine Instanz zu erzeugen?
- Welche Auswirkungen haben `AddSingleton`, `AddScoped` und `AddTransient`?
- Was passiert, wenn ein `BackgroundService` einen Scoped Service benötigt?
- Wie lässt sich die Anwendung über `CancellationToken` kontrolliert beenden?

**Abnahme:** Die Anwendung verwendet `Host.CreateDefaultBuilder`, die Services werden über Constructor Injection bereitgestellt und die Messungen erfolgen automatisch.

## Modul 2 – Dynamische Konfiguration mit appsettings.json

### Aufbau und Ziel

Die Anwendung soll Einstellungen aus einer JSON-Datei laden und Änderungen daran zur Laufzeit erkennen.

**Wichtig:** Ein Neustart der Anwendung ist bei einer Konfigurationsänderung nicht erlaubt.

### Aufgabe 2.1 – Konfiguration erstellen

Erstelle die Datei `appsettings.json`:

```json
{
  "Monitoring": {
	"SensorName": "Freezer-01",
	"IntervalSeconds": 5,
	"MinTemperature": -10,
	"MaxTemperature": 5,
	"Enabled": true
  }
}
```

Erstelle die Klasse `MonitoringOptions` und binde den Abschnitt `Monitoring` an diese Klasse. Die Klasse soll alle Eigenschaften aus der JSON-Datei enthalten und korrekt typisiert sein.

### Aufgabe 2.2 – Konfiguration verwenden

Erweitere den `TemperatureMonitor` und den `MonitoringWorker` so, dass sie ihre Einstellungen aus `MonitoringOptions` beziehen.

Nutze dafür `IOptionsMonitor<MonitoringOptions>`.

Erwartetes Verhalten:

- `Enabled = false`: Es dürfen keine weiteren Messungen durchgeführt werden.
- `IntervalSeconds`: Bestimmt das Intervall zwischen den Messungen.
- `MinTemperature`: Unterer zulässiger Temperaturwert.
- `MaxTemperature`: Oberer zulässiger Temperaturwert.
- `SensorName`: Bezeichnung des überwachten Sensors.

Die Grenzwerte gelten inklusive. Ein Wert genau auf der Grenze ist zulässig.

### Aufgabe 2.3 – Änderungen erkennen

Während die Anwendung läuft, soll der Junior die `appsettings.json` manuell bearbeiten. Bei jeder relevanten Änderung soll die Anwendung eine entsprechende Nachricht ausgeben.

**Beispiel 1 – Maximaltemperatur verändern**

Vorher:

```json
"MaxTemperature": 5
```

Nachher:

```json
"MaxTemperature": 8
```

Erwartete Ausgabe:

```text
Configuration changed:
MaxTemperature: 5 -> 8
```

**Beispiel 2 – Monitoring deaktivieren**

```json
"Enabled": false
```

Erwartete Ausgabe:

```text
Configuration changed:
Enabled: True -> False

Monitoring paused.
```

**Beispiel 3 – Messintervall verändern**

```json
"IntervalSeconds": 2
```

Erwartetes Verhalten: Die Überwachung arbeitet künftig mit einem Intervall von zwei statt fünf Sekunden. Das Intervall muss tatsächlich angepasst werden. Eine reine Logausgabe reicht nicht.

### Aufgabe 2.4 – Fehlerhafte Konfiguration behandeln

Die Anwendung soll ungültige Konfigurationen erkennen.

| Eigenschaft | Regel |
|---|---|
| `SensorName` | Darf nicht leer sein |
| `IntervalSeconds` | Zwischen 1 und 60 |
| `MinTemperature` | Muss kleiner als `MaxTemperature` sein |
| `Enabled` | Muss ein gültiger Boolean sein |

Überlege, wie Änderungen an der Konfiguration validiert werden können und wie sich verhindern lässt, dass ungültige Werte in der Überwachung verwendet werden.

### Technische Vorgaben

- `IOptionsMonitor<T>` verwenden.
- Konfigurationsänderungen über `OnChange` erkennen.
- Den alten und den neuen Wert der veränderten Einstellungen ausgeben.
- Keine dauerhafte Polling-Schleife bauen, die ständig die JSON-Datei einliest.
- Event-Registrierungen korrekt freigeben.
- Fehlerhafte Änderungen dürfen nicht zu einem unkontrollierten Absturz führen.

**Zusatzfrage:** Wie unterscheiden sich `IOptions<T>`, `IOptionsSnapshot<T>` und `IOptionsMonitor<T>`?

> **Hinweis für den Betreuer:** Das Laufzeitverhalten bei ungültigen Konfigurationen ist ein anspruchsvoller Teil. Der Junior soll erkennen, dass Reload, Validierung und die Beibehaltung einer letzten gültigen Konfiguration getrennte Probleme sind. Für die Abnahme kann zunächst der erfolgreiche Reload gültiger Werte im Mittelpunkt stehen.

## Modul 3 – Extension Methods in einer separaten Class Library

### Fortgeschrittene Grundlagen und Ziel

Der Junior soll lernen, wie sich bestehende Typen durch Extension Methods erweitern lassen und wie wiederverwendbare Funktionalitäten in einer eigenen Bibliothek gekapselt werden.

### Aufgabe 3.1 – Class Library erstellen

Erstelle ein zusätzliches Projekt:

`Warehouse.Monitoring.Extensions`

Die Bibliothek darf keine Abhängigkeit zum Console-Projekt besitzen.

### Aufgabe 3.2 – ServiceCollection erweitern

Erstelle eine Extension Method, mit der sämtliche Monitoring-Services zentral registriert werden können.

Gewünschte Verwendung in `Program.cs`:

```csharp
services.AddWarehouseMonitoring();
```

Die Extension Method soll folgende Services registrieren:

- `ISensorReader` mit `SensorReader`
- `ITemperatureMonitor` mit `TemperatureMonitor`
- `MonitoringWorker` als Hosted Service

Die Methode soll `IServiceCollection` zurückgeben, damit weitere Registrierungen verkettet werden können.

**Herausforderung:** Wie muss die Projektstruktur aussehen, damit die Extension Library die Services kennt, ohne vom Console-Projekt abhängig zu sein?

### Aufgabe 3.3 – Fluent Extension Methods erstellen

Erweitere den `ITemperatureMonitor` durch mindestens zwei sinnvolle Extension Methods:

```csharp
monitor.CheckAndLog(temperature);
monitor.IsWithinRange(temperature);
```

Die Methoden müssen vorhandene Funktionalität sinnvoll ergänzen. Die Extension Methods dürfen nicht einfach nur die gleichnamigen Methoden des Services ohne zusätzlichen Nutzen aufrufen.

Anforderungen:

- Die Extension Methods müssen in der Class Library liegen.
- Die Bibliothek soll von einem zweiten Konsolenprojekt wiederverwendet werden können.
- Es soll keine doppelte Implementierung der eigentlichen Temperaturprüfung entstehen.

### Aufgabe 3.4 – Verteilung als NuGet-Paket (Bonus)

Erstelle aus der Library ein lokales NuGet-Paket. Das Paket soll über einen lokalen Package Feed in einem zweiten Projekt installiert werden können.

### Fragen zur Vertiefung

- Was ist eine Extension Method?
- Kann eine Extension Method auf private Felder zugreifen?
- Was geschieht, wenn eine Instanzmethode und eine Extension Method dieselbe Signatur besitzen?
- Wann ist eine Extension Method sinnvoll, und wann sollte besser eine normale Service-Methode verwendet werden?
- Welche Rolle spielen Namespaces bei Extension Methods?

## Modul 4 – Generische Klassen und Methoden mit Constraints

### Anspruch und Ziel

Der Junior soll nicht nur einfache generische Klassen erstellen, sondern auch lernen, wie sich Typparameter durch Constraints einschränken lassen. Dabei sollen mehrere Constraints kombiniert und generische Methoden mit eigenen Typparametern erstellt werden.

Die Aufgaben steigen bewusst im Schwierigkeitsgrad.

### Aufgabe 4.1 – Generische Messwerte

Erstelle zunächst eine Basisklasse:

```csharp
public abstract class SensorData
{
	public Guid SensorId { get; init; }
	public DateTime Timestamp { get; init; }
}
```

Implementiere anschliessend eine generische Klasse:

```csharp
public class Measurement<T> where T : SensorData
{
	// Implementierung durch Junior
}
```

Die Klasse soll einen Datensatz vom Typ `T` speichern und folgende Eigenschaften anbieten:

| Eigenschaft | Beschreibung |
|---|---|
| `Id` | Eindeutige Messungs-ID |
| `Data` | Generischer Sensorwert |
| `RecordedAt` | Erfassungszeitpunkt |

Erstelle zwei konkrete Sensortypen, die von `SensorData` erben:

- `TemperatureData` mit einer Temperatur als `double`.
- `HumidityData` mit einer Luftfeuchtigkeit als `double`.

Versuche anschliessend, `Measurement<string>` zu erzeugen.

**Frage:** Warum verhindert der Compiler dies?

### Aufgabe 4.2 – Mehrere Constraints kombinieren

Definiere ein Interface:

```csharp
public interface IValidatable
{
	bool IsValid();
}
```

Erstelle eine generische Klasse, die nur bestimmte Datentypen akzeptiert:

```csharp
public class DataProcessor<T>
	where T : SensorData, IValidatable, new()
{
	// Implementierung durch Junior
}
```

Anforderungen:

- `T` muss von `SensorData` erben.
- `T` muss `IValidatable` implementieren.
- `T` muss einen öffentlichen parameterlosen Konstruktor besitzen.
- Die Klasse soll eine Methode `CreateDefault()` bereitstellen, die eine neue Instanz von `T` erzeugt.
- Eine Methode `Process(T data)` soll ungültige Daten ablehnen.

Erweitere `TemperatureData` und `HumidityData`, damit sie diese Anforderungen erfüllen.

### Aufgabe 4.3 – Generische Methode mit mehreren Typparametern

Jetzt wird die Aufgabe bewusst komplexer.

Erstelle eine Klasse `SensorDataConverter`, die unterschiedliche Sensorwerte in andere Datentypen umwandeln kann.

Definiere folgendes Interface:

```csharp
public interface IDataConverter<TSource, TTarget>
{
	TTarget Convert(TSource source);
}
```

Implementiere anschliessend eine generische Methode mit dieser Signatur:

```csharp
public TTarget Convert<TSource, TTarget, TConverter>(TSource source)
	where TSource : SensorData, IValidatable
	where TTarget : SensorData, new()
	where TConverter : IDataConverter<TSource, TTarget>, new()
{
	// Implementierung durch Junior
}
```

Anforderungen:

1. Prüfe zuerst, ob die Quelldaten gültig sind.
2. Erzeuge eine Instanz von `TConverter`.
3. Konvertiere die Quelldaten.
4. Gib das Ergebnis als `TTarget` zurück.

Erstelle einen konkreten Converter, der eine Temperatur in Celsius in Fahrenheit umwandelt.

Verwende dazu beispielsweise zwei unterschiedliche Datentypen:

- `CelsiusTemperatureData`
- `FahrenheitTemperatureData`

Erwartete Verwendung:

```csharp
var fahrenheit = converter.Convert<
	CelsiusTemperatureData,
	FahrenheitTemperatureData,
	CelsiusToFahrenheitConverter>(celsius);
```

### Aufgabe 4.4 – Generische Repository-Klasse

Implementiere ein In-Memory-Repository mit mehreren Constraints:

```csharp
public class Repository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>
	where TKey : notnull
{
	// Implementierung durch Junior
}
```

Dazu gehört das Interface:

```csharp
public interface IEntity<TKey>
{
	TKey Id { get; }
}
```

Anforderungen:

- `Add(TEntity entity)` fügt ein Element hinzu.
- `GetById(TKey id)` liefert ein Element anhand seiner ID.
- `GetAll()` liefert alle Elemente.
- `Remove(TKey id)` entfernt ein Element.
- Das Repository muss mindestens mit `int` und `Guid` als Schlüsseltyp funktionieren.

### Aufgabe 4.5 – Method Constraints und Typsicherheit

Erweitere das Repository um eine generische Methode:

```csharp
public IReadOnlyList<TResult> Select<TResult>(Func<TEntity, TResult> selector)
	where TResult : notnull
{
	// Implementierung durch Junior
}
```

Der Junior soll anschliessend folgende Fragen beantworten:

- Warum benötigt diese Methode einen eigenen Typparameter `TResult`?
- Welche Bedeutung hat `where TResult : notnull`?
- Welche Constraints werden vom Compiler überprüft?
- Können Constraints garantieren, dass fachlich gültige Daten verarbeitet werden?
- Weshalb kann eine zu komplexe generische Signatur problematisch sein?

**Abnahme:** Der Junior muss jeden einzelnen Constraint erklären und mindestens ein Beispiel zeigen, das wegen einer Constraint-Verletzung nicht kompiliert.

## Modul 5 – Integration aller Komponenten (Bonus)

Erweitere die Anwendung so, dass die Sensorwerte nicht nur erzeugt und kontrolliert, sondern auch in einem generischen Repository gespeichert werden.

Das Ergebnis soll folgendermassen funktionieren:

| Komponente | Aufgabe |
|---|---|
| Generic Host | Initialisierung und Dependency Injection |
| `MonitoringWorker` | Führt periodische Messungen aus |
| `SensorReader` | Erzeugt Temperatur- oder Feuchtigkeitswerte |
| `TemperatureMonitor` | Prüft und protokolliert |
| Repository | Speichert Messwerte |
| `appsettings.json` / `IOptionsMonitor<T>` | Ermöglicht Änderungen an Konfiguration und Grenzwerten zur Laufzeit |

Die Anwendung muss Änderungen der Einstellungen während der Laufzeit berücksichtigen, Messwerte typisiert verarbeiten und die Extension Library zur Registrierung verwenden.

## Modularität und unabhängige Bearbeitung

Da der Junior nicht an einer Aufgabe scheitern und dadurch alle weiteren Aufgaben blockieren soll, würde ich jedes Modul mit einer eigenen Starterlösung bereitstellen.

| Modul | Bereitgestellte Grundlage |
|---|---|
| 1 | Leeres Konsolenprojekt |
| 2 | Funktionierender Host inklusive aller Services |
| 3 | Vorgegebene Monitoring-Interfaces und Serviceimplementierungen |
| 4 | Eigenständiges Class-Library-Projekt mit den Basis-Interfaces |
| 5 | Zusammengeführte Grundlösung aus den Modulen 1–4 |

Damit kann er beispielsweise Modul 4 bearbeiten, auch wenn er das Thema Dependency Injection noch nicht vollständig verstanden hat.

## Bewertung

### Abnahmecheckliste

**0 von 16 erfüllt**

#### Host und Services

- [ ] Generic Host korrekt erstellt
- [ ] Services korrekt registriert und injiziert
- [ ] `BackgroundService` und `CancellationToken` verstanden

#### Konfiguration

- [ ] Typisierte Konfiguration korrekt gebunden
- [ ] Änderungen während der Laufzeit erkannt
- [ ] Alte und neue Werte korrekt protokolliert
- [ ] Veränderte Einstellungen beeinflussen die Anwendung

#### Extension Methods

- [ ] Class Library sauber erstellt
- [ ] `IServiceCollection`-Extension funktioniert
- [ ] Weitere sinnvolle Extension Methods implementiert
- [ ] Bibliothek ohne Console-Abhängigkeit wiederverwendbar

#### Generics

- [ ] Generische Klasse mit Constraint implementiert
- [ ] Mehrere Constraints kombiniert
- [ ] Generische Methode mit mehreren Typparametern umgesetzt
- [ ] Repository mit `TEntity` und `TKey` implementiert
- [ ] Constraint-Verletzung nachvollziehbar demonstriert

## Zeitaufwand

| Modul | Geschätzte Dauer |
|---|---|
| Generic Host | 1–2 Stunden |
| Dynamische Konfiguration | 2–3 Stunden |
| Extension Methods und Library | 2–3 Stunden |
| Generics und Constraints | 3–4 Stunden |
| Integration (Bonus) | 1–2 Stunden |
| **Gesamt** | **9–14 Stunden** |

## Didaktische Hinweise

Ich würde bei dieser Übung drei Aspekte besonders beachten:

1. **Konfiguration ist mehr als das Einlesen von JSON.** Der Junior soll demonstrieren, dass er versteht, wie `IOptionsMonitor<T>` Änderungen verarbeitet, wie die Anwendung darauf reagiert und weshalb ungültige Konfigurationen problematisch sein können.
2. **Extension Methods sind kein Ersatz für gutes Service-Design.** Die Library soll sinnvoll wiederverwendbar sein. Besonders wichtig ist, dass der Junior erkennt, weshalb die Abhängigkeiten von der Extension Library zu den Services und nicht umgekehrt verlaufen.
3. **Generics sollen bewusst anspruchsvoll sein, aber nicht unnötig kompliziert bleiben.** In Modul 4 sind einige Signaturen absichtlich komplex. Der Junior soll sie lesen, implementieren und anschliessend beurteilen, ob eine einfachere API möglich wäre. Besonders die Converter-Signatur eignet sich dafür: `TConverter` ist bereits für die Erzeugung durch `new()` eingeschränkt, weshalb sich daraus auch eine Diskussion über Dependency Injection und testbare Konverter ergibt.

Als abschliessende Aufgabe würde ich den Junior die Anwendung in einem kurzen Code Review vorstellen lassen. Dabei muss er erklären können, was seine Lösung macht, warum er sie so umgesetzt hat und welche Teile er bei einer produktiven Anwendung anders gestalten würde.

## Mögliche nächste Schritte

- Eine konkrete Übung zur Extension Method in der Library erstellen.
- Konkrete Anforderungen zum Überwachen von `appsettings.json`-Änderungen formulieren.
- Eine generische Klasse mit anspruchsvollen Constraints skizzieren.
