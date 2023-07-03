# VT-Desktop-Widget

![VT-Desktop-Widget Screenshot](https://github.com/AlexRasch/VT-Desktop-Widget/assets/46262688/3d4b4bf7-1168-4218-b099-3d6ca0d88b57)

VT-Desktop-Widget is a simple Windows desktop widget that integrates with the VirusTotal API to perform file scans and displays basic system information such as RAM and CPU usage. It is developed using C# and Windows Forms, utilizing PInvoke for some functions. Please note that due to these dependencies, the widget may not be compatible with Linux or macOS.

## Features

- Perform file scans using the VirusTotal API
- Display RAM and CPU usage information
- User-friendly and minimalistic desktop widget
- Customizable settings (Work in Progress)

## Requirements

- Windows 10 or Windows 11
- .NET 6.0 runtime

## Usage

1. Clone the repository or download the source code.
2. Build the project using Visual Studio or the .NET CLI.
3. Obtain a VirusTotal API key from the [VirusTotal website](https://www.virustotal.com).
4. Launch the VT-Desktop-Widget application.
5. Enter your VirusTotal API key in the settings.
6. Customize the widget appearance and behavior according to your preferences (Work in Progress).
7. Enjoy the widget on your Windows desktop!

## Configuration

The VT-Desktop-Widget uses a configuration file (`config.json`) to store user settings. It is located in the application data folder (`%APPDATA%\VT-Desktop-Widget`).

## Contributing

Contributions are welcome! If you would like to contribute to VT-Desktop-Widget, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and push the branch to your fork.
4. Submit a pull request detailing your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [VirusTotal](https://www.virustotal.com) - VirusTotal API for file scanning functionality.

## Disclaimer

VT-Desktop-Widget is provided as-is without any warranty. Use it at your own risk.
