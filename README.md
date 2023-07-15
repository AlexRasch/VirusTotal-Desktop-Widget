# VirusTotal Desktop Widget

VirusTotal Desktop Widget is a simple Windows desktop widget that integrates with the VirusTotal API to perform file scans and displays basic system information such as RAM and CPU usage. It is developed using C# and Windows Forms, utilizing PInvoke for some functions. Please note that due to these dependencies, the widget may not be compatible with Linux or macOS.

![GitHub all releases](https://img.shields.io/github/downloads/AlexRasch/VirusTotal-Desktop-Widget/total) ![GitHub Repo stars](https://img.shields.io/github/stars/AlexRasch/VirusTotal-Desktop-Widget)


![VirusTotal-Desktop-Widget](https://github.com/AlexRasch/VirusTotal-Desktop-Widget/assets/46262688/8a152623-e950-47ab-bfa8-9b18dc2a90b1)

Disclaimer: This application/widget is not a substitute for a antivirus software. It only provides an additional layer of security by scanning files with multiple antivirus engines. You should always use a reputable antivirus software on your system and keep it updated.

## Features
- Autostart support
- Customizable settings (Work in Progress)
- Display RAM and CPU usage information
- Light-weight application that does not use any third-party libraries
- Perform file scans using the VirusTotal API
- Secure API Key Storage with DPAPI encryption (no plaintext storage)
- User-friendly and minimalistic desktop widget
- "Send To" integration for easy file submission to VirusTotal

## Requirements
- Windows 10 or Windows 11
- .NET 6.0 runtime
- VirusTotal API key (optimal)

## Credit
This project utilizes the following resources from the community:
- [Theme by aeonhack](https://github.com/aeonhack) - The theme used for the user interface.

## Usage
1. Clone the repository or download the source code.
2. Build the project using Visual Studio or the .NET CLI.
3. Obtain a VirusTotal API key from the [VirusTotal website](https://www.virustotal.com).
4. Launch the VirusTotal desktop widget application.
5. Enter your VirusTotal API key in the settings.
6. Customize the widget appearance and behavior according to your preferences (Work in Progress).
7. Enjoy the widget on your Windows desktop!

## Configuration
The VT Desktop Widget uses a configuration file (`config.json`) to store user settings. It is located in the application data folder (`%APPDATA%\VT-Desktop-Widget`).

**Secure API Key Storage with DPAPI Encryption**
Rest assured, your VirusTotal API key is securely protected within VirusTotal Desktop Widget. The project utilizes encryption techniques provided by the DPAPI (Data Protection API) to safeguard your API key. This ensures that your API key is not stored in plain text and remains confidential.

If you have any technical concerns or would like to review the code yourself, you can examine the implementation in the source code. If you discover any areas for improvement or have suggestions to enhance the security of VirusTotal Desktop Widget, we welcome your contributions.


## Contributing
Contributions are welcome! If you would like to contribute to VirusTotal desktop widget, please follow these steps:

1. Fork the repository by clicking the "Fork" button on the top right corner of this page.
2. Clone your forked repository to your local machine.
3. Make the necessary changes and improvements to the code.
4. Test your changes to ensure they work correctly.
5. Commit your changes and push them to your forked repository.
6. Open a pull request from your forked repository to the original repository.

Please provide a clear and detailed description of the changes you made in your pull request. It will help in reviewing and merging your code faster.
Before submitting a pull request, make sure to run the tests and verify that they pass successfully. If you're adding new features, consider adding relevant tests as well.
By contributing to this project, you agree to license your contributions under the [MIT License](LICENSE).
Thank you for your contribution! Together, we can make VirusTotal desktop widget even better.
