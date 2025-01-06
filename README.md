# Chat App with Entity Framework

# Hướng dẫn sử dụng
1. Git clone 
2. Vào thư mục `DAL` -> Tạo file cấu hình `.json` tên: `appsettings.development.json`
    - Cấu hình: Chọn `Properties` -> `Copy to Output Directory`: `Copy if newer`
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
            "ChatApp": "data source=HARRYITC/SQLEXPRESS;initial catalog=ChatApp;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework"
        }
    }
    ```
3. Build (`Ctrl + Shift + B`) and Run with task `Start Project` (Có thể thủ công tùy bạn)