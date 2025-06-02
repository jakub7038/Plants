# 🌿 Plants — Zarządzanie Roślinami 🌻

## 📖 Opis aplikacji
Plants to aplikacja desktopowa (Windows Forms), służąca do zarządzania kolekcją roślin, ich gatunkami oraz logami pielęgnacji. Funkcje obejmują:
- Zarządzanie gatunkami (nazwa, region, optymalna temperatura, wilgotność)
- Dodawanie roślin i przypisywanie ich do gatunków
- Rejestrowanie czynności pielęgnacyjnych (podlewanie, nawożenie, przycinanie itp.) wraz z datą, temperaturą, wilgotnością, stanem zdrowia, zdjęciem i komentarzem
- Wyświetlanie historii logów pielęgnacji oraz obliczanie „dni od ostatniego podlewania/nawożenia”
- Import danych przykładowych (Seeder) i czyszczenie bazy (Cleaner)

## 💻 Technologia
- **Język**: C#  
- **GUI**: Windows Forms (.NET 9.0)  
- **ORM**: Entity Framework Core (Npgsql)  
- **Baza danych**: PostgreSQL  

## 🧩 Struktura projektu
```
Plants/
│   appsettings.json
│   Plants.csproj
│   Program.cs
│
├───Data/
│   │   AppDbContext.cs
│   └───Helpers/
│       │   DBContextHelper.cs
│       │   DatabaseSeeder.cs
│       │   DatabaseCleaner.cs
│       │   FileHelper.cs
│       │   RegexHelper.cs
│       └───images/
│               1.jpg
│               2.jpg
│               3.jpg
│               4.jpg
│               5.jpg
│               6.jpg
│
├───Forms/
│   │   PlantManagerForm.cs
│   │   PlantManagerForm.Designer.cs
│   ├───AddSpeciesControl/
│   │       AddSpeciesControl.cs
│   │       AddSpeciesControl.Designer.cs
│   ├───AddPlantForm/
│   │       AddPlantForm.cs
│   │       AddPlantForm.Designer.cs
│   ├───AddCareLogForm/
│   │       AddCareLogForm.cs
│   │       AddCareLogForm.Designer.cs
│   ├───PlantDetailsControl/
│   │       PlantDetailsControl.cs
│   │       PlantDetailsControl.Designer.cs
│   └───CareLogListControl/
│           CareLogListControl.cs
│           CareLogListControl.Designer.cs
│
├───Migrations/
│       20250515210235_init_fixes.cs
│       20250515210235_init_fixes.Designer.cs
│       AppDbContextModelSnapshot.cs
│
├───Models/
│       Species.cs
│       Plant.cs
│       CareLog.cs
│
└───Services/
    │   SpeciesService.cs
    │   PlantService.cs
    │   CareLogService.cs
```

## 🗄️ Model bazy danych

### Tabela: Species
| Kolumna           | Typ      | Opis                                   |
|-------------------|----------|----------------------------------------|
| SpeciesId (PK)    | int      | Klucz główny                           |
| Name              | string   | Nazwa gatunku (max 100, wymagane)      |
| Region            | string   | Położenie naturalne (max 100, wymagane)|
| IdealTemperature  | string   | Optymalna temperatura (max 50, wymagane)|
| IdealHumidity     | string   | Optymalna wilgotność (max 50, wymagane)|

### Tabela: Plant
| Kolumna           | Typ      | Opis                                   |
|-------------------|----------|----------------------------------------|
| PlantId (PK)      | int      | Klucz główny                           |
| Name              | string   | Nazwa rośliny (max 100, wymagane)      |
| SpeciesId (FK)    | int      | Odniesienie do gatunku                 |

Dodatkowo właściwości obliczane w modelu:
- `LastWateringDate`, `LastFertilizationDate`
- `DaysSinceLastWatering`, `DaysSinceLastFertilization`
- Słownik „Dni od ostatniej akcji” dla każdej akcji pielęgnacyjnej

### Tabela: CareLog
| Kolumna                 | Typ           | Opis                                                  |
|-------------------------|---------------|-------------------------------------------------------|
| CareLogId (PK)          | int           | Klucz główny                                          |
| Action                  | enum          | Typ akcji (Podlewanie, Nawożenie, Przycinanie, itp.)  |
| CareDate                | DateTime      | Data wykonania (UTC)                                  |
| TemperatureAtCare       | int           | Temperatura podczas pielęgnacji (–50 … 100 °C)         |
| HumidityAtCare          | int           | Wilgotność podczas pielęgnacji (0 … 100 %)            |
| GrowthMeasurementCm     | int           | Pomiar wzrostu (0 … 500 cm)                           |
| HealthStatus            | enum          | Stan zdrowia (Doskonała, Dobra, Średnia, Słaba)       |
| ObservedProblems        | string        | Opis problemów (max 300, opcjonalne)                  |
| Comment                 | string        | Komentarz (opcjonalne)                                |
| Photo                   | byte[]        | Zdjęcie (opcjonalne, max 1 MB)                        |
| PlantId (FK)            | int           | Odniesienie do rośliny                                 |

## ⚙️ Konfiguracja i uruchomienie

1. **Wymagania**  
   - .NET 9.0  
   - PostgreSQL 14+  
   - Visual Studio 2022+ (lub nowszy)

2. **Ustawienia bazy danych**  
   W pliku `appsettings.json` podaj połączenie do PostgreSQL:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=plants_db;Username=postgres;Password=TwojeHasło"
     }
   }
   ```

3. **Inicjalizacja bazy danych**  
   - Aby wstawić przykładowe dane, w wierszu poleceń uruchom:  
     ```
     Plants.exe --seed
     ```
   - Aby wyczyścić wszystkie tabele, użyj:  
     ```
     Plants.exe --clean
     ```
   Po zakończeniu program wyświetli komunikat o powodzeniu i zakończy działanie.

4. **Uruchomienie aplikacji**  
   - W Visual Studio otwórz projekt `Plants` i ustaw go jako startowy (WinForms App).  
   - Uruchom bez argumentów → otworzy się główne okno `PlantManagerForm`.  
   - Z poziomu aplikacji można:  
     - Dodawać nowe gatunki (`Add Species`)  
     - Dodawać rośliny (`Add Plant`)  
     - Dla wybranej rośliny rejestrować logi pielęgnacji (`Add Care Log`)  
     - Przeglądać szczegóły rośliny i historię logów

---

## 📄 Pliki kluczowe

- **`Program.cs`**  
  - Parsuje argumenty `--seed` i `--clean`  
  - Inicjalizuje `AppDbContext` przez `DBContextHelper`  

- **`AppDbContext.cs`**  
  - Definiuje tabele `DbSet<Species>`, `DbSet<Plant>`, `DbSet<CareLog>`  
  - Łączy się do PostgreSQL przez `UseNpgsql(...)`

- **`DBContextHelper.cs`**  
  - Metoda `Create()` tworzy `AppDbContext` z konfiguracją z `appsettings.json`  

- **`DatabaseSeeder.cs`**  
  - Metoda `Seed(AppDbContext context)` dodaje przykładowe `Species`, `Plant` i `CareLog`  

- **`DatabaseCleaner.cs`**  
  - Metoda `Clean(AppDbContext context)` usuwa wszystkie rekordy w tabelach w odpowiedniej kolejności  

- **`RegexHelper.cs`**  
  - Metody walidujące nazwy i regiony (tylko litery, spacje, myślniki, apostrofy)  

- **`FileHelper.cs`**  
  - Metody do konwersji zdjęć na `byte[]` i zapisania z bazy do pliku tymczasowego  

- **`SpeciesService.cs`**, **`PlantService.cs`**, **`CareLogService.cs`**  
  - CRUD i operacje walidacji (np. sprawdzanie duplikatów)  

- **Formularze (Windows Forms)**  
  - `PlantManagerForm` – główne okno z listą roślin i panelem szczegółów  
  - `AddSpeciesControl` – dodawanie gatunku (walidacja regex + unikalność)  
  - `AddPlantForm` – dodawanie rośliny (walidacja regex + unikalność + wybór gatunku)  
  - `AddCareLogForm` – rejestracja logu pielęgnacji (zakresy numeryczne, data ≤ dziś, rozmiar zdjęcia ≤ 1 MB)  
  - `PlantDetailsControl` – wyświetlanie danych rośliny oraz historii logów  
  - `CareLogListControl` – wyświetlanie listy logów z przyciskiem do podglądu zdjęcia  

---
## The End?
