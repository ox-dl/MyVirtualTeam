# MyVirtualTeam for Windows

<p align="center">
  <img src="./docs/img/App_Logo.png" alt="MyVirtualTeam Logo" width="300">
</p>

<p align="center"><em>Manage your local virtual lab easily with Hyper-V</em></p>

## Introduction
MyVirtualTeam is a desktop tool that allows you to emulate multiple local Windows machines managed via Hyper-V.  
It is ideal for testing, automation, or locally distributed workflows.

**Documentation:**  
You can access the full documentation on [GitHub Pages](https://ox-dl.github.io/MyVirtualTeam/).

## Requirements
- **Windows 10/11 Pro (or higher)** — required to enable and use **Hyper-V**.  
- **.NET Desktop Runtime 8.0 or later** — required to run the application.  
  You can download it from the official [.NET website](https://dotnet.microsoft.com/en-us/download/dotnet).  

> **Note:** The application is currently designed as a framework-dependent build.  
> This means users must have the .NET Desktop Runtime installed on their system.

## Download
You can download and install the latest version of MyVirtualTeam from the [latest release](../../releases/latest) section of this repository.  
Simply download the installer package and follow the setup instructions.

## How to Use

Before using MyVirtualTeam, make sure your system meets the [Requirements](#requirements).

1. Download the latest release from the [latest release](../../releases/latest) section.  
2. Run `MyVirtualTeam.exe`.  
3. Follow the setup wizard to configure the application if necessary.  

4. **Create a new project**:  
   - Define the number of virtual machines you want to emulate.  
   - Configure parameters for each VM (CPU, RAM, network, etc.).  
   - Install and launch the virtual machines.  

5. **Create your custom tasks** for these virtual machines:  
   - Automate workflows, testing, or any local distributed processes.  
   - Save and manage tasks directly from the application interface.

6. **Monitor and control** your virtual machines from the MyVirtualTeam interface.

## ⚠️ Warning – License Responsibility

This project **does not include, distribute, or install any proprietary operating system** (such as Microsoft Windows).  
It only provides automation tools for creating and managing virtual machines through Hyper-V.

**Important:**  
If you use this software to create or run virtual machines containing **Microsoft Windows** (or any other proprietary software),  
you must have a **valid license** for each instance of the operating system used.  
Owning a Windows 10/11 Pro license on your host machine **does not automatically authorize** running Windows inside one or more virtual machines.

The author of this project **assumes no responsibility** for any misuse or violation of third-party software licenses.

## License
This project is licensed under the **GPL-3.0** license. See the [LICENSE](./LICENSE) file for details.
