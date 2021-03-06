USE [DETAI_QLNHANSU]
GO
/****** Object:  StoredProcedure [dbo].[spAddNhanVien]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spAddNhanVien]
	@MaNV char(5),
	@HoTen nvarchar(50),
	@NgaySinh datetime,
	@DiaChi nvarchar(50),
	@GioiTinh nchar(3),	
	@MaPB char(5) = null,
	@MaCV char(5) = null,
	@MaCM char(5) = null,
	@BacLuong int = null
as
begin
	INSERT INTO NHANVIEN
	Values(@MaNV, @HoTen, @NgaySinh, @DiaChi, @GioiTinh, @MaPB, @MaCV, @MaCM, @BacLuong)
end

GO
/****** Object:  StoredProcedure [dbo].[spAddPhongBan]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spAddPhongBan]
@MaPB char(5),
@TenPB nvarchar(50),
@DiaChi nvarchar(50) = null
as
begin
	INSERT INTO PHONGBAN
	Values(@MaPB, @TenPB, @DiaChi)
end

GO
/****** Object:  StoredProcedure [dbo].[spDeleteNhanVien]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[spDeleteNhanVien]
 @MaNV char(5)
 as
 begin
	Delete from NHANVIEN
	Where MaNV = @MaNV
 end


GO
/****** Object:  StoredProcedure [dbo].[spDeletePhongBan]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeletePhongBan] 
@MaPB char(5)
as
begin
	Delete from PHONGBAN	
	Where MaPB = @MaPB
end

GO
/****** Object:  StoredProcedure [dbo].[spGetBacLuong]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get bậc lương
CREATE PROC [dbo].[spGetBacLuong]
AS
BEGIN
Select BacLuong
from LUONG
END
GO
/****** Object:  StoredProcedure [dbo].[spGetChucVu]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get chức vụ
CREATE PROC [dbo].[spGetChucVu]
AS
BEGIN
Select MaCV, TenCV
from CHUCVU
END
GO
/****** Object:  StoredProcedure [dbo].[spGetChuyenMon]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get chuyên môn
CREATE PROC [dbo].[spGetChuyenMon]
AS
BEGIN
Select MaCM, TenCM
from CHUYENMON
END

GO
/****** Object:  StoredProcedure [dbo].[spGetNhanVien]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetNhanVien]
as
begin
	Select * from NHANVIEN
end
GO
/****** Object:  StoredProcedure [dbo].[spGetNhanVienByMa]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetNhanVienByMa]
@Ma char(5)
as
begin
Select *
 from NHANVIEN where MaNV = @Ma
 end

GO
/****** Object:  StoredProcedure [dbo].[spGetPhongBan]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetPhongBan]
AS
BEGIN
Select MaPB, TenPB,DiaChi
from PHONGBAN
END
GO
/****** Object:  StoredProcedure [dbo].[spGetTenChucVuByMa]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 -- Get chức vụ ban by Mã
CREATE PROC [dbo].[spGetTenChucVuByMa]
@Ma char(5)
as
begin
Select TenCV
 from CHUCVU where MaCV = @Ma
 end


GO
/****** Object:  StoredProcedure [dbo].[spGetTenChuyenMonByMa]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetTenChuyenMonByMa]
@Ma char(5)
as
begin
Select TenCM
 from CHUYENMON where MaCM = @Ma
 end

GO
/****** Object:  StoredProcedure [dbo].[spGetTenPhongByID]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetTenPhongByID]
@MaPB char(5)
as
begin
Select TenPB
 from PHONGBAN where MaPB = @MaPB
 end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateNhanVien]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[spUpdateNhanVien]
	@MaNV char(5),
	@HoTen nvarchar(50),
	@NgaySinh datetime,
	@DiaChi nvarchar(50),
	@GioiTinh nchar(3),	
	@MaPB char(5) = null,
	@MaCV char(5) = null,
	@MaCM char(5) = null,
	@BacLuong int = null
as
begin
	Update NHANVIEN
	Set HoTen = @HoTen,
	 NgaySinh = @NgaySinh,
	 DiaChi = @DiaChi, 
	 GioiTinh = @GioiTinh, 
	 MaPB = @MaPB, 
	 MaCV = @MaCV, 
	 MaCM = @MaCM, 
	 BacLuong = @BacLuong
	 Where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[spUpdatePhongBan]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdatePhongBan]
@MaPB char(5),
@TenPB nvarchar(50),
@DiaChi nvarchar(50) = null
as
begin
	UPDATE PHONGBAN
	Set TenPB = @TenPB, DiaChi = @DiaChi
	Where MaPB = @MaPB

end

GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MaCV] [char](5) NOT NULL,
	[TenCV] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHUYENMON]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHUYENMON](
	[MaCM] [char](5) NOT NULL,
	[TenCM] [nvarchar](50) NULL,
	[TrinhDo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOPDONG]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOPDONG](
	[MaHD] [char](5) NOT NULL,
	[MaNV] [char](5) NOT NULL,
	[LoaiHD] [nvarchar](20) NULL,
	[NgayBD] [datetime] NULL,
	[NgayKT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LUONG]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUONG](
	[BacLuong] [int] NOT NULL,
	[LuongCB] [int] NULL,
	[HSLuong] [float] NULL,
	[HSPC] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[BacLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [char](5) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GioiTinh] [nchar](3) NULL,
	[MaPB] [char](5) NULL,
	[MaCV] [char](5) NULL,
	[MaCM] [char](5) NULL,
	[BacLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MaPB] [char](5) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK__PHONGBAN__2725E7E4902B704F] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 07/11/2016 2:53:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Quyen] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV01 ', N'Tổng Giám Đốc')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV02 ', N'Phó Giám Đốc')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV03 ', N'Nhân Viên')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV04 ', N'Trưởng Phòng')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV05 ', N'Phó Phòng')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (N'CV06 ', N'Bảo Vệ')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM01 ', N'Quản Trị Kinh Doanh', N'Đại học')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM02 ', N'Công nghệ thông tin', N'Đại học')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM03 ', N'Quản trị nhân lực ', N'Đại học')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM04 ', N'Tài chính kế toán', N'Đại học')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM05 ', N'Quan hệ công chúng', N'Đại học')
INSERT [dbo].[CHUYENMON] ([MaCM], [TenCM], [TrinhDo]) VALUES (N'CM06 ', N'An ninh', N'Trung cấp')
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD01 ', N'NV01 ', N'Dài hạn', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD02 ', N'NV02 ', N'Dài hạn', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD03 ', N'NV03 ', N'Ngắn hạn', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD04 ', N'NV04 ', N'Ngắn hạn', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD05 ', N'NV05 ', N'Ngắn thời', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[HOPDONG] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD06 ', N'NV06 ', N'Tạm thời', CAST(0x0000A6AF00000000 AS DateTime), CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[LUONG] ([BacLuong], [LuongCB], [HSLuong], [HSPC]) VALUES (1, 1150, 2.34, 0.4)
INSERT [dbo].[LUONG] ([BacLuong], [LuongCB], [HSLuong], [HSPC]) VALUES (2, 1150, 3.5, 0.6)
INSERT [dbo].[LUONG] ([BacLuong], [LuongCB], [HSLuong], [HSPC]) VALUES (3, 1150, 4.18, 0.8)
INSERT [dbo].[LUONG] ([BacLuong], [LuongCB], [HSLuong], [HSPC]) VALUES (4, 1150, 6.42, 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV007', N'Nguyễn Thị Định', CAST(0x00007B3600000000 AS DateTime), N'HN', N'Nam', N'PB01 ', N'CV01 ', N'CM01 ', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'nv009', N'Nguyễn Văn Ni', CAST(0x00008A2900000000 AS DateTime), N'Sài Gòn', N'Nữ ', N'PB02 ', N'CV02 ', N'CM01 ', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV01 ', N'Nguyễn Văn A', CAST(0x00007B3600000000 AS DateTime), N'Hồ Chí Minh', N'Nam', N'PB01 ', N'CV01 ', N'CM03 ', 4)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV02 ', N'Nguyễn Lan Anh', CAST(0x0000836F00000000 AS DateTime), N'Cần Thơ', N'Nữ ', N'PB02 ', N'CV02 ', N'CM03 ', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV027', N'Thạch Mu Ni', CAST(0x0000A6B600000000 AS DateTime), N'Sài gòn', N'Nam', N'PB01 ', N'CV01 ', N'CM01 ', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV03 ', N'Nguyễn Thị Cúc', CAST(0x0000732600000000 AS DateTime), N'Hồ Chí Minh', N'Nữ ', N'PB05 ', N'CV04 ', N'CM05 ', 2)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV04 ', N'Đoàn Nguyên Đức', CAST(0x000086FC00000000 AS DateTime), N'Hà Nội', N'Nam', N'PB03 ', N'CV06 ', N'CM06 ', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV05 ', N'Phạm Nhựt Vượng', CAST(0x00007B5400000000 AS DateTime), N'Hồ Chí Minh', N'Nam', N'PB06 ', N'CV03 ', N'CM04 ', 2)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV06 ', N'Phạm Văn Chính', CAST(0x00007B5400000000 AS DateTime), N'Hồ Chí Minh', N'Nam', N'PB04 ', N'CV05 ', N'CM02 ', 2)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV16 ', N'Nguyễn Văn Xxx', CAST(0x0000A6B500000000 AS DateTime), N'Cà Mau', N'Nam', N'PB01 ', N'CV01 ', N'CM01 ', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV654', N'Nguyễn Thị B', CAST(0x00007B3600000000 AS DateTime), N'sài gòn', N'Nam', N'PB01 ', N'CV01 ', N'CM01 ', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [NgaySinh], [DiaChi], [GioiTinh], [MaPB], [MaCV], [MaCM], [BacLuong]) VALUES (N'NV692', N'Muni', CAST(0x00007BE800000000 AS DateTime), N'HCM', N'Nam', N'PB01 ', N'CV01 ', N'CM02 ', 4)
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB01 ', N'Hành Chính', N'Tầng 3')
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB02 ', N'Kinh Doanh ', N'Tầng 2')
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB03 ', N'Giám Sát ', N'Tầng 1')
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB04 ', N'Công nghệ', N'Tầng 3')
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB05 ', N'Nhân Sự ', N'Tầng 2')
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [DiaChi]) VALUES (N'PB06 ', N'Kế Hoạch ', N'Tầng 4')
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([ID], [TaiKhoan], [MatKhau], [Quyen], [Email]) VALUES (1, N'admin', N'123', N'ADMIN', N'admin@tonii.xyz')
SET IDENTITY_INSERT [dbo].[USERS] OFF
