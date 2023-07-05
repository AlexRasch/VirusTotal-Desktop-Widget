# VT Desktop Widget

VT Desktop Widget is a simple Windows desktop widget that integrates with the VirusTotal API to perform file scans and displays basic system information such as RAM and CPU usage. It is developed using C# and Windows Forms, utilizing PInvoke for some functions. Please note that due to these dependencies, the widget may not be compatible with Linux or macOS.

  ![GitHub all releases](https://img.shields.io/github/downloads/AlexRasch/VT-Desktop-Widget/total) ![GitHub Repo stars](https://img.shields.io/github/stars/AlexRasch/VT-Desktop-Widget)



![VT-Desktop-Widget](https://github.com/AlexRasch/VT-Desktop-Widget/assets/46262688/bfa0b2b4-4405-404d-81d7-4980bc0c26c2)


## Features

- Autostart support
- Perform file scans using the VirusTotal API
- Display RAM and CPU usage information
- User-friendly and minimalistic desktop widget
- Customizable settings (Work in Progress)
- Secure API Key Storage with DPAPI encryption (no plaintext storage)


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

The VT Desktop Widget uses a configuration file (`config.json`) to store user settings. It is located in the application data folder (`%APPDATA%\VT-Desktop-Widget`).

**Secure API Key Storage with DPAPI Encryption**

Rest assured, your VirusTotal API key is securely protected within VT Desktop Widget. The project utilizes encryption techniques provided by the DPAPI (Data Protection API) to safeguard your API key. This ensures that your API key is not stored in plain text and remains confidential.

If you have any technical concerns or would like to review the code yourself, you can examine the implementation in the source code. If you discover any areas for improvement or have suggestions to enhance the security of VT Desktop Widget, we welcome your contributions.


## Contributing

Contributions are welcome! If you would like to contribute to VT-Desktop-Widget, please follow these steps:

1. Fork the repository by clicking the "Fork" button on the top right corner of this page.
2. Clone your forked repository to your local machine.
3. Make the necessary changes and improvements to the code.
4. Test your changes to ensure they work correctly.
5. Commit your changes and push them to your forked repository.
6. Open a pull request from your forked repository to the original repository.

Please provide a clear and detailed description of the changes you made in your pull request. It will help in reviewing and merging your code faster.
Before submitting a pull request, make sure to run the tests and verify that they pass successfully. If you're adding new features, consider adding relevant tests as well.
By contributing to this project, you agree to license your contributions under the [MIT License](LICENSE).
Thank you for your contribution! Together, we can make VT-Desktop-Widget even better.
