# QLShopQuanAo
Mô tả: Hệ thống quản lý shop quần áo là hệ thống dùng để quản lý các nhu cầu cần thiết trong việc quản lý shop quần áo của cửa hàng.
Cài đặt và sử dụng:
    Cài Đătk:
        Visual Studio 2020: Đây là ứng dụng để mở chương trình chạy.
        Microsoft SQL Server Manageement Studio(SSMS): Là cơ sở dữ liệu để lưu toàn bộ thông tin trong quá trình sử dụng.
    Sử dụng:
    B1: Chuẩn bị cơ sở dữ liệu.
        Trong phần file code: Sẽ có file cớ sở dữ "ShopQuanAo.bacpac". Hãy tải về. Và tiến hành cài đặt vào MSSM.
            B1: Mở MSSM
            B2: Bấm chuột phải vào Databases -> Import Data-tier Application.
            B3: Chọn vào file "ShopQuanAo.bacpac" mà bạn vừa dowload. 
            B4: Chọn tên cho Database của bạn và bấm "Next" cho đến khi cài đặt xong.
    B2: Chạy chương trình:
        - Tiến hành mở file có đuôi là QLShopQuanAo.sln .
        - Mở file DAL -> DBConnect.cs 
        - Chọn Tools -> Connect to Database -> Ghi tên server của bạn vào( Nơi có cơ sở dữ liệu bạn tạo)
        - Chọn Advanced Bạn sẽ thấy chuỗi String kết nối của bạn. Copy chuối String đó và thay thế vào string strconec = @" Đây" ;
    B3: Bấm "Start" Để chạy chương trình:
        Đối với Admin: Tk là '000' mk là '123'
        Đối với Cửa hàng trưởng TK là '111' mk là '123'
        Đối với nhân viên TK là '112' mk là '123'