<p align="center"><img src="Termnana/Images/termnana.png" alt="Termnana"></p>
<div align="center" style="margin-top: 0;">
   <h1>Termnana</h1>
   <p>Your command-line 🍌 banana buddy, designed to boost productivity and make your terminal experience a-peel-ing! 🍌</p>
</div>
<em><h5 align="center">(Programming Language - C#)</h5></em>
<p align="center">
<a href="#"><img alt="Termnana forks" src="https://img.shields.io/github/forks/RussianCatt/Termnana?style=for-the-badge"></a>
<a href="#"><img alt="Repo stars" src="https://img.shields.io/github/stars/RussianCatt/Termnana?style=for-the-badge&color=yellow"></a>
<a href="#"><img alt="Termnana License" src="https://img.shields.io/github/license/RussianCatt/Termnana?color=cyan&style=for-the-badge"></a>
<a href="https://github.com/RussianCatt/Termnana/issues"><img alt="issues" src="https://img.shields.io/github/issues/RussianCatt/Termnana?color=purple&style=for-the-badge"></a>
<p align="center"><img src="https://views.whatilearened.today/views/github/RussianCatt/Termnana.svg" width="80px" height="28px" alt="View"></p>


<p align="center"><img src="Termnana/Images/Screenshot.png" width="570" alt="Termnana Screenshot"></p>

## 📄 Description

**Termnana** is your command-line 🍌 banana buddy, designed to enhance productivity through a set of rich, extensible features. From advanced command management to seamless theme switching, Termnana ensures your terminal experience is always a-peel-ing. 🍌

## ✨ Features

### Configuration Manager

**Purpose:**
Manages the application configuration settings, such as saving and loading settings from a JSON file. Because who doesn't love their settings well managed, right?

**Key Functions:**
- `LoadConfiguration()`: Loads settings from a JSON file. 🗄️
- `SaveConfiguration()`: Saves settings to a JSON file. 💾
- `GetSetting(key)`: Retrieves a setting by key. 🔑
- `SetSetting(key, value)`: Sets and saves a setting. 🛠️

**Example Usage:**
```csharp
ConfigurationManager.SetSetting("theme", "dark");
string theme = ConfigurationManager.GetSetting("theme");
```
Keep your settings ripe and ready!

### Logger

**Purpose:**
Logs information, warnings, and errors to a log file, with timestamps for each log entry. It's like a diary for your code's deepest secrets. 📜

**Key Functions:**
- `LogInfo(message)`: Logs an informational message. ℹ️
- `LogWarning(message)`: Logs a warning message. ⚠️
- `LogError(message)`: Logs an error message. ❌

**Example Usage:**
```csharp
Logger.LogInfo("Application started");
Logger.LogError("An unexpected error occurred");
```
Logging: because even code needs to vent sometimes.

### NanaManager

**Purpose:**
Manages the loading and listing of "Nanas", which are plugins that extend the functionality of the application. Yes, we're serious about the bananas. 🍌

**Key Functions:**
- `LoadNanas()`: Loads Nanas from DLL files in the specified directory. 📂
- `ListNanas()`: Lists all loaded Nanas. 📋

**Example Usage:**
```csharp
NanaManager.LoadNanas();
NanaManager.ListNanas();
```
Get ready to unleash the power of the Nanas!

### Command Aliases

**Purpose:**
Allows users to define and manage aliases for commands to simplify command input. Because who wants to type long commands? Ain't nobody got time for that! ⏳

**Key Functions:**
- `LoadAliases()`: Loads command aliases from the configuration. 📥
- `SaveAliases()`: Saves command aliases to the configuration. 📤
- `AddAlias(alias, command)`: Adds a new alias. ➕
- `RemoveAlias(alias)`: Removes an existing alias. ➖
- `ResolveAlias(alias)`: Resolves an alias to its corresponding command. 🔍

**Example Usage:**
```csharp
CommandAliases.AddAlias("ls", "list");
string command = CommandAliases.ResolveAlias("ls"); // returns "list"
```
Alias away your typing troubles!

### Autocomplete Helper

**Purpose:**
Provides autocomplete functionality for command input, helping users by suggesting and completing commands. Never type a full command again! ✨

**Key Functions:**
- `ReadLineWithAutocomplete(prompt, availableCommands)`: Reads user input with autocomplete support. 💡

**Example Usage:**
```csharp
List<string> commands = new List<string> { "list", "help", "exit" };
string input = AutocompleteHelper.ReadLineWithAutocomplete("[Termnana] > ", commands);
```
Autocomplete: the life-saver for the lazy typer.

### Main Program

**Purpose:**
The entry point of the application that initializes components and handles the main command loop. This is where the magic happens! ✨

**Key Functions:**
- `Main()`: Initializes the configuration manager, command aliases, and Nana manager, then enters the command loop. 🔄
- Command handling for built-in commands like `exit`, `clear`, `list`, and `help`. 💻

**Example Usage:**
Running the program and entering commands:
```
[Termnana] > help
Available commands:
 - list
 - help
 - exit
```
The main event: where all your commands come to life!

### Nana Interface

**Purpose:**
Defines the interface that all Nanas (plugins) must implement, ensuring a standard structure and behavior. Consistency is key! 🔑

**Key Functions:**
- `CommandName`: The name of the command the Nana handles. 📛
- `Description`: A description of what the Nana does. 📄
- `Author`: The author of the Nana. ✍️
- `Version`: The version of the Nana. 🕰️
- `Dependencies`: A list of dependencies required by the Nana. 🧩
- `Execute(args)`: Executes the Nana's functionality. 🚀

**Example Usage:**
```csharp
public class ExampleNana : INana
{
    public string CommandName => "example";
    public string Description => "An example Nana";
    public string Author => "Author Name";
    public Version Version => new Version(1, 0);
    public List<string> Dependencies => new List<string>();

    public void Execute(string[] args)
    {
        Console.WriteLine("Executing example Nana");
    }
}
```
Become a Nana connoisseur and let your plugins shine!

## 🛠️ Libraries Used

- **System.Text.Json**: For JSON serialization and deserialization. JSON: it's like a banana for your data! 🍌
- **System.Composition**: For Managed Extensibility Framework (MEF), used for dependency injection and plugin management. 🛠️
- **Spectre.Console**: For enhanced console output, including colors and interactive elements like prompts and progress bars. Make your console a colorful fruit salad! 🌈

## 🚀 Example Workflow

1. **Starting the Application**:
   - The user starts Termnana and is greeted with the terminal prompt `[Termnana] >`. Hello, world! 👋

2. **Using Autocomplete**:
   - The user starts typing a command. For example, typing `li` and pressing `Tab` will autocomplete to `list` if it matches available commands. 🎉

3. **Executing a Command**:
   - The user types `list` and presses `Enter`. The application lists all loaded Nanas. 📝

4. **Adding an Alias**:
   - The user adds an alias: `CommandAliases.AddAlias("ls", "list")`.
   - Now, typing `ls` will resolve to `list` and execute the list command. 🪄

5. **Exiting the Application**:
   - The user types `exit` and confirms to close the application. Bye-bye! 👋

Termnana enhances the terminal experience with these features, making it more interactive, user-friendly, and productive. 🍌

## 🔧 Installation

1. **Download the latest release** from the [Releases](https://github.com/RussianCatt/Termnana/releases) tab.
2. **Extract the contents** to your desired directory. 📂
3. **Run the executable** to start the application. 🎬

**Building from source:**

Clone the repository and build it using your preferred C# IDE (e.g., Visual Studio).

```shell
git clone https://github.com/RussianCatt/Termnana.git
cd Termnana
# Open and build the project in Visual Studio or use dotnet CLI
```

Don't forget to install the [.NET 8 runtime](https://dotnet.microsoft.com/download/dotnet/8.0) if you haven't already!

## 🛠️ License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. 📜

## 🌟 Acknowledgements

Special

 thanks to all contributors and open-source libraries that made this project possible. 🙏

---

<p align="center">
Made with ❤️ by  <a href="https://github.com/RussianCatt/">RussianCat</a> with the help of <a href="https://github.com/stxfi/">stxfi</a>
</p>
