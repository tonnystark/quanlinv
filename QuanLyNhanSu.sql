
USE DETAI_QLNHANSU
GO

SET DATEFORMAT DMY

DROP TABLE NHANVIEN

CREATE TABLE CHUCVU
(
	MaCV char(5) not null,
	TenCV nvarchar(20)
	PRIMARY KEY(MaCV)
)
CREATE TABLE PHONGBAN
(
	MaPB char(5) not null,
	TenPB nvarchar(50),
	DiaChi nvarchar(10) 
	PRIMARY KEY(MaPB)
)

CREATE TABLE CHUYENMON
(
	MaCM char(5) not null,
	TenCM nvarchar(50),
	TrinhDo nvarchar(50) 
	PRIMARY KEY(MaCM)
)
CREATE TABLE LUONG
(
	BacLuong int not null,
	LuongCB int,
	HSLuong float,
	HSPC float,
	PRIMARY KEY(BacLuong)
)

DROP TABLE NHANVIEN

CREATE TABLE NHANVIEN
(
	MaNV char(5) not null,
	HoTen nvarchar(50),
	NgaySinh datetime,
	DiaChi nvarchar(50),
	GioiTinh nchar(3),	
	MaPB char(5),
	MaCV char(5),
	MaCM char(5),
	BacLuong int ,
	PRIMARY KEY(MaNV)
)



CREATE TABLE HOPDONG
(
	MaHD char(5) not null,
	MaNV char(5) not null,	
	LoaiHD nvarchar(20),
	NgayBD datetime,
	NgayKT datetime

	PRIMARY KEY(MaHD)
)

ALTER TABLE HOPDONG ADD MoTa nvarchar(50)

CREATE TABLE USERS
(
	ID int identity primary key,
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	Quyen varchar(20),
	Email varchar(50)
)


----------Chức vụ
INSERT INTO CHUCVU
VALUES('CV01',N'Tổng Giám Đốc'),
('CV02',N'Phó Giám Đốc'),
('CV03',N'Nhân Viên'),
('CV04',N'Trưởng Phòng'),
('CV05',N'Phó Phòng'),
('CV06',N'Bảo Vệ')

----------Phòng Ban
INSERT INTO PHONGBAN
VALUES('PB01',N'Hành Chính',N'Tầng 3'),
('PB02',N'Kinh Doanh',N'Tầng 2'),
('PB03',N'Giám Sát',N'Tầng 1'),
('PB04',N'Công nghệ',N'Tầng 3'),
('PB05',N'Nhân Sự',N'Tầng 4'),
('PB06',N'Kế hoạch',N'Tầng 4')

---------Trình độ học vấn
INSERT INTO CHUYENMON
VALUES('CM01', N'Quản Trị Kinh Doanh', N'Đại học'),
('CM02', N'Công nghệ thông tin', N'Đại học'),
('CM03', N'Quản trị nhân lực ', N'Đại học'),
('CM04', N'Tài chính kế toán', N'Đại học'),
('CM05', N'Quan hệ công chúng', N'Đại học'),
('CM06', N'An ninh', N'Trung cấp')

INSERT INTO CHUYENMON VALUES ('CM06', N'An ninh', N'Trung cấp')

---------Lương
INSERT INTO LUONG
VALUES(1,1150,2.34,0.4),
(2,1150,3.5,0.6),
(3,1150,4.18,0.8),
(4,1150,6.42,1)
---------Nhân viên
SET DATEFORMAT DMY

INSERT INTO NHANVIEN
VALUES('NV01',N'Nguyễn Văn A','12/5/1986',N'Hồ Chí Minh',N'Nam','PB01','CV01','CM03',4),
('NV02',N'Nguyễn Lan Anh','15/2/1992',N'Cần Thơ',N'Nữ','PB02','CV02','CM03',3),
('NV03',N'Nguyễn Thị Cúc','16/9/1980',N'Hồ Chí Minh',N'Nữ','PB05','CV04','CM05',2),
('NV04',N'Đoàn Nguyên Đức','12/8/1994',N'Hà Nội',N'Nam','PB03','CV06','CM06',1),
('NV05',N'Phạm Nhựt Vượng','11/6/1986',N'Hồ Chí Minh',N'Nam','PB06','CV03','CM04',2),
('NV06',N'Phạm Văn Chính','11/6/1986',N'Hồ Chí Minh',N'Nam','PB04','CV05','CM02',2)

--------- Hợp đồng

INSERT INTO HOPDONG
VALUES('HD01','NV01' ,N'Dài hạn','30/10/2016',''),
('HD02', 'NV02', N'Dài hạn','30/10/2016',''),
('HD03', 'NV03',N'Ngắn hạn','30/10/2016',''),
('HD04','NV04' ,N'Ngắn hạn','30/10/2016',''),
('HD05', 'NV05',N'Ngắn thời','30/10/2016',''),
('HD06', 'NV06',N'Tạm thời','30/10/2016','')


--------------------
INSERT INTO USERS
Values('admin', '123', 'ADMIN', 'admin@tonii.xyz'),
('muni', '123', 'USER', 'muni@tonii.xyz')

Select * from NHANVIEN
Select * from PHONGBAN
Select * from HOPDONG
Select * from USERS



-------------Store Proc
-- GetNhanVien
CREATE PROC GetNhanVien
as
begin
	Select * from NHANVIEN
end



-- Add NhanVien
CREATE PROC spAddNhanVien
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

spAddNhanVien 'nv009', 'TEST', '05/11/1996', 'HCM', 'NAM', 'CV09'






-- Get chức vụ
CREATE PROC spGetChucVu
AS
BEGIN
Select MaCV, TenCV
from CHUCVU
END

-- Get bậc lương
CREATE PROC spGetBacLuong
AS
BEGIN
Select BacLuong
from LUONG
END

-- Get Tên Phòng ban by Mã
CREATE PROC spGetTenPhongByID 
@MaPB char(5)
as
begin
Select TenPB
 from PHONGBAN where MaPB = @MaPB
 end


-- Get nhân viên ban by Mã
CREATE PROC spGetNhanVienByMa
@Ma char(5)
as
begin
Select *
 from NHANVIEN where MaNV = @Ma
 end

-- Get nhân viên ban by Mã
CREATE PROC spGetNhanVienByMa
@Ma char(5)
as
begin
Select *
 from NHANVIEN where MaNV = @Ma
 end


-- Get chuyên môn by Mã
CREATE PROC spGetTenChuyenMonByMa
@Ma char(5)
as
begin
Select TenCM
 from CHUYENMON where MaCM = @Ma
 end

 -- Get chức vụ ban by Mã
CREATE PROC spGetTenChucVuByMa
@Ma char(5)
as
begin
Select TenCV
 from CHUCVU where MaCV = @Ma
 end




 -----Delete NhanVien
 CREATE PROC spDeleteNhanVien 
 @MaNV char(5)
 as
 begin
	Delete from NHANVIEN
	Where MaNV = @MaNV
 end

 -- Update NhânViên
 CREATE PROC spUpdateNhanVien
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


spUpdateNhanVien 'nv009', 'muni', '1996-11-05', 'HCM', 'Nam', 'CV09', 'CV01', 'CM00', 1


-- Get phòng ban
ALTER PROC spGetPhongBan
AS
BEGIN
Select MaPB, TenPB,DiaChi
from PHONGBAN
END

-- Add phong Ban
CREATE PROC spAddPhongBan 'PB008', 'Test', 'Test'
@MaPB char(5),
@TenPB nvarchar(50),
@DiaChi nvarchar(50) = null
as
begin
	INSERT INTO PHONGBAN
	Values(@MaPB, @TenPB, @DiaChi)
end


-- Update phong Ban
ALTER PROC spUpdatePhongBan 
@MaPB char(5),
@TenPB nvarchar(50),
@DiaChi nvarchar(50) = null
as
begin
	UPDATE PHONGBAN
	Set TenPB = @TenPB, DiaChi = @DiaChi
	Where MaPB = @MaPB
end

-- Delete phòng ban
CREATE PROC spDeletePhongBan 'PB008'
@MaPB char(5)
as
begin
	Delete from PHONGBAN	
	Where MaPB = @MaPB
end


---chuyên môn
-- Get chuyên môn
CREATE PROC spGetChuyenMon
AS
BEGIN
Select MaCM, TenCM, TrinhDo
from CHUYENMON
END

-- Add Chuyên môn
ALTER PROC spAddChuyenMon --'CM007', 'TEST', 'TEST'
@MaCM char(5),
@TenCM nvarchar(50),
@TrinhDo nvarchar(50) = null
as
begin
	INSERT INTO CHUYENMON
	Values(@MaCM, @TenCM, @TrinhDo)
end


-- Update Chuyên môn
ALTER PROC spUpdateChuyenMon  --'CM007', 'TEST', 'đh'
@MaCM char(5),
@TenCM nvarchar(50),
@TrinhDo nvarchar(50) = null
as
begin
	UPDATE CHUYENMON
	Set TenCM = @TenCM, TrinhDo = @TrinhDo
	Where MaCM = @MaCM
end

-- Delete chuyên môn
CREATE PROC spDeleteChuyenMon --'cm007'
@MaCM char(5)
as
begin
	Delete from CHUYENMON	
	Where MaCM = @MaCM
end


--GET HỢP ĐỒNG

CREATE PROC spGetHopDong
as
begin
	Select * from HOPDONG
end

-- Tạo hợp đồng
ALTER PROC spAddHopDong --'HD008', 'NV02', N'Ngắn hạn', '01/01/2016'
@MaHD char(5),
@MaNV char(5),
@LoaiHD nvarchar(20),
@NgayBD datetime = null,
@NgayKT datetime = null,
@MoTa nvarchar(50) = null
as
begin
INSERT INTO HOPDONG 
Values(@MaHD, @MaNV, @LoaiHD, @NgayBD, @NgayKT, @MoTa)
end

-- Update Hợp đồng
CREATE PROC spUpdateHopDong --'HD007', 'NV02', N'Ngắn hạn', '01/01/2016', null,N'test hợp đồng'
@MaHD char(5),
@MaNV char(5),
@LoaiHD nvarchar(20),
@NgayBD datetime = null,
@NgayKT datetime = null,
@MoTa nvarchar(50) = null
as
begin
UPDATE HOPDONG 
SET MaNV = @MaNV, LoaiHD = @LoaiHD, NgayBD = @NgayBD, NgayKT = @NgayKT, MoTa = @MoTa
Where MaHD = @MaHD
end

-- Delete hợp đồng
CREATE PROC spDeleteHopDong -- 'HD008'
@MaHD char(5)
as
begin
	Delete from HOPDONG
	Where MaHD = @MaHD
end

--Get all manv
CREATE PROC spGetAllMaNV
as
begin
Select ManV
from NHANVIEN
end


Select * from PHONGBAN
Select * from CHUYENMON
Select * from NHANVIEN
Select * from CHUCVU
Select * from LUONG
Select * from HopDong
