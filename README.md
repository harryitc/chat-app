<!-- Improved compatibility of back to top link: See: https://github.com/harryitc/chat-app/pull/73 -->

<a id="readme-top"></a>

<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Unlicense License][license-shield]][license-url]
<!-- [![Pulls][pulls-shield]][pulls-url] -->
<!-- [![LinkedIn][linkedin-shield]][linkedin-url] -->

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/harryitc/chat-app">
    <img src="/demo/Logo.jpg" alt="Logo" width="200" height="200">
  </a>

  <h3 align="center">Chat App</h3>

  <p align="center">
    Ứng dụng Chat App Realtime đơn giản
    <br />
    <a href="https://github.com/harryitc/chat-app/tree/master/demo">View Demo</a>
    &middot;
    <a href="https://github.com/harryitc/chat-app/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    &middot;
    <a href="https://github.com/harryitc/chat-app/issues/new?labels=enhancement&template=feature-request---.md">Request Feature</a>
  </p>
</div>

## Features

- **Gửi tin nhắn**: Người dùng có thể gửi tin nhắn văn bản và hình ảnh trong các nhóm chat.
- **Quản lý nhóm**: Người dùng có thể tạo nhóm, tham gia nhóm và quản lý các thành viên trong nhóm.
- **Quản lý bạn bè**: Người dùng có thể gửi lời mời kết bạn, chấp nhận hoặc từ chối lời mời kết bạn.
- **Báo cáo**: Hỗ trợ tạo báo cáo về các nhóm và thành viên trong nhóm.
- **Thông báo**: Nhận thông báo khi có tin nhắn mới hoặc khi có hoạt động trong nhóm.
- **Tìm kiếm**: Tìm kiếm tin nhắn và người dùng trong ứng dụng.
- **Bảo mật**: Hỗ trợ mã hóa tin nhắn và bảo mật thông tin người dùng.
- **Giao diện thân thiện**: Giao diện người dùng đơn giản và dễ sử dụng.
- Báo cáo thống kê tin nhắn sử dụng **Report Viewer**.

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<details>
  <summary>Demo Project</summary>
  <img src="/demo/Logo.jpg" alt="Logo" />
  <br>
  <img src="/demo/AvatarViewer.jpg" alt="AvatarViewer" />
  <br>
  <img src="/demo/ChatAppDemo.jpg" alt="ChatAppDemo" />
  <br>
  <img src="/demo/ChatAppMainForm.jpg" alt="ChatAppMainForm" />
  <br>
  <img src="/demo/CreateGroup.jpg" alt="CreateGroup" />
  <br>
  <img src="/demo/DemoWelcomeEmail.jpg" alt="DemoWelcomeEmail" />
  <br>
  <img src="/demo/JoinGroup.jpg" alt="JoinGroup" />
  <br>
  <img src="/demo/LoginForm.jpg" alt="LoginForm" />
  <br>
  <img src="/demo/NotificationFriendRequest.jpg" alt="NotificationFriendRequest" />
  <br>
  <img src="/demo/QrCode.jpg" alt="QrCode" />
  <br>
  <img src="/demo/SendAddFriendRequest.jpg" alt="SendAddFriendRequest" />
  <br>
  <img src="/demo/ServerNewUserLoginSuccess.jpg" alt="ServerNewUserLoginSuccess" />
  <br>
  <img src="/demo/ServerStart.jpg" alt="ServerStart" />
  <br>
  <img src="/demo/SigninForm.jpg" alt="SigninForm" />
</details>

<!-- ABOUT THE PROJECT -->

## About The Project
Ứng dụng **Chat Application** là một hệ thống nhắn tin thời gian thực được xây dựng bằng **C#** và **Entity Framework** theo phương pháp **Code First**. Ứng dụng này hỗ trợ người dùng giao tiếp thông qua giao diện thân thiện, đồng thời lưu trữ dữ liệu tin nhắn trong cơ sở dữ liệu. Ngoài ra, hệ thống sử dụng **Report Viewer** để tạo và hiển thị các báo cáo.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

- [![.NET][.NET]][.NET-url]
- [![C#][C#]][C#-url]
- [![SQLServer][SQLServer]][SQLServer-url]
- [![VisualStudio][VisualStudio]][VisualStudio-url]


<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Workflow

<div align="center">
    <img  src="/Workflow/ChatAppWorkflow.png" alt="workflow chat app">
</div>

<!-- GETTING STARTED -->

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites
This is an example of how to list things you need to use the software and how to install them.

- **Hệ điều hành**: Windows 10 trở lên.
- **IDE**: Viusal Studio 2022 trở lên.
- **Phiên bản .NET**: .NET Framework 4.7.0.
- **Cơ sở dữ liệu**: SQL Server 2022 (cao hơn hoặc thay đổi theo cấu hình của bạn).
- **Thư viện sử dụng**: 
  - Entity Framework (Code First)
  - Report Viewer
  - System.Data.SqlClient

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Clone the repo

   ```sh
   git clone https://github.com/harryitc/chat-app.git
   ```

2. Cấu hình cơ sở dữ liệu
- Tạo cơ sở dữ liệu mới trong SQL Server (Script có tên `ChatAppDB.sql`).
- Cập  nhật Connection String với máy của bạn ở `appsettings.development.json`: 
  - Vào thư mục `DAL` -> Tạo file cấu hình `.json` tên: `appsettings.development.json`
  - Cấu hình: Chọn `Properties` -> `Copy to Output Directory`: `Copy Always`
  - Copy toàn bộ cấu hình từ file `appsettings.json` qua file mới vừa tạo.
  - Chỉnh lại tên server theo máy bạn.
  - Ví dụ:
    ```json
    {
      "exclude": [
        "**/bin",
        "**/bower_components",
        "**/jspm_packages",
        "**/node_modules",
        "**/obj",
        "**/platforms"
      ],
      "ConnectionStrings": {
        "ChatApp": "data source=HARRYITC\\SQLEXPRESS;initial catalog=ChatApp;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework"
      }
    }
    ```
  - **Lưu ý! Phải bảo đảm cả 2 file `appsettings.*.json` đều có thuộc tính `Copy Always`**. 
3. Chạy chương trình
3.1. Build: `Ctrl + Shift + B`
3.2. Nhấn `Start Project` để chạy multiple project đã cấu hình sẵn (Theo mặc định, bạn cần start **server** trước, sau đó là **Client**).


### Project Structure
```bash
/ChatApp
├── DAL/               # Data Access Layer
├── BUS/               # Business Logic Layer
├── Client/            # Giao diện người dùng (Windows Forms + Report Viewer)
├──── appsettings.json # Mẫu cấu hình (không được chỉnh sửa)
├──── appsettings.development.json # Nơi cấu hình Connection String
├──── ...
├──── Program.cs # Khởi chạy chương trình
└── Server             # Broadcast dữ liệu đến các clients khác
├──── Program.cs # Khởi chạy chương trình
├──── ...
```

<!-- <p align="right">(<a href="#readme-top">back to top</a>)</p> -->

### NuGet Packages

| Package Name                                             | Version     |
| -------------------------------------------------------- | ----------- |
| EntityFramework                                          | 6.5.1       |
| Google.Apis                                              | 1.68.0      |
| Google.Apis.Auth                                         | 1.68.0      |
| Google.Apis.Core                                         | 1.68.0      |
| Google.Apis.Gmail.v1                                     | 1.68.0.3427 |
| Microsoft.Bcl.AsyncInterfaces                            | 9.0.0       |
| Microsoft.Extensions.Configuration                       | 9.0.0       |
| Microsoft.Extensions.Configuration.Abstractions          | 9.0.0       |
| Microsoft.Extensions.Configuration.FileExtensions        | 9.0.0       |
| Microsoft.Extensions.Configuration.Json                  | 9.0.0       |
| Microsoft.Extensions.FileProviders.Abstractions          | 9.0.0       |
| Microsoft.Extensions.FileProviders.Physical              | 9.0.0       |
| Microsoft.Extensions.FileSystemGlobbing                  | 9.0.0       |
| Microsoft.Extensions.Primitives                          | 9.0.0       |
| Newtonsoft.Json                                          | 13.0.3      |
| Otp.NET                                                  | 1.4.0       |
| QRCoder                                                  | 1.6.0       |
| System.Buffers                                           | 4.6.0       |
| System.CodeDom                                           | 7.0.0       |
| System.IO.Pipelines                                      | 9.0.0       |
| System.Management                                        | 7.0.2       |
| System.Memory                                            | 4.6.0       |
| System.Numerics.Vectors                                  | 4.6.0       |
| System.Runtime.CompilerServices.Unsafe                   | 6.1.0       |
| System.Text.Encodings.Web                                | 9.0.0       |
| System.Text.Json                                         | 9.0.0       |
| System.Threading.Tasks.Extensions                        | 4.6.0       |
| System.ValueTuple                                        | 4.5.0       |
| Microsoft.EntityFrameworkCore                            | 6.0.0       |
| Microsoft.EntityFrameworkCore.SqlServer                  | 6.0.0       |
| Microsoft.EntityFrameworkCore.Tools                      | 6.0.0       |
| Microsoft.Extensions.DependencyInjection                 | 6.0.0       |
| Microsoft.Extensions.Logging                             | 6.0.0       |
| BouncyCastle.Cryptography                                | 2.5.0       |
| Microsoft.ReportingServices.ReportViewerControl.Winforms | 150.1652.0  |
| Microsoft.SqlServer.Types                                | 14.0.314.76 |
| MimeKit                                                  | 4.9.0       |

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Top contributors

<a href="https://github.com/harryitc/chat-app/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=harryitc/chat-app" alt="contrib.rocks image" />
</a>

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTACT -->

## Contact
Bạn có thắc mắc điều gì? Liên hệ:
Phan Ngọc Cường - <cuongharryit@gmail.com>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/harryitc/chat-app.svg?style=for-the-badge
[contributors-url]: https://github.com/harryitc/chat-app/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/harryitc/chat-app?style=for-the-badge
[forks-url]: https://github.com/harryitc/chat-app/network/members
[stars-shield]: https://img.shields.io/github/stars/harryitc/chat-app?style=for-the-badge
[stars-url]: https://github.com/harryitc/chat-app/stargazers
[issues-shield]: https://img.shields.io/github/issues/harryitc/chat-app?style=for-the-badge
[issues-url]: https://github.com/harryitc/chat-app/issues
[pulls-shield]: https://img.shields.io/github/pulls/harryitc/chat-app?style=for-the-badge
[pulls-url]: https://github.com/harryitc/chat-app/pulls
[license-shield]: https://img.shields.io/github/license/harryitc/chat-app?style=for-the-badge
[license-url]: https://github.com/harryitc/chat-app/blob/master/LICENSE.txt
[product-screenshot]: demo/DemoChatApp.jpg

[.NET]: https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white
[.NET-url]: https://dotnet.microsoft.com/en-us/
[C#]: https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white
[C#-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[SQLServer]: https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white
[SQLServer-url]: https://www.microsoft.com/en-us/sql-server
[VisualStudio]: https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white
[VisualStudio-url]: https://visualstudio.microsoft.com/
