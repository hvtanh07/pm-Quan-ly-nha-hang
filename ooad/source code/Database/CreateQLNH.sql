

USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLNH')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLNH') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLDL]
END
GO

/* Collation = SQL_Latin1_General_CP1_CI_AS */
CREATE DATABASE [QLNH]
GO
USE [QLNH]
GO
CREATE TABLE [dbo].[tblnhanVien]
(	
	[manhanVien] nvarchar(10) NOT NULL PRIMARY KEY,
	[tenNhanVien] nvarchar(10) NOT NULL,
	[birth]	datetime2(7) NOT NULL,
	[luongCoBan] int NOT NULL,
	[gioLam] int NOT NULL,
	[chucVu] nvarchar(10) NOT NULL,
)
CREATE TABLE [dbo].[tblNguyenLieu]
(	
	[maLNguyenLieu] nvarchar(10) NOT NULL PRIMARY KEY,
	[tenNguyenLieu]	nvarchar(50) NOT NULL,	
	[dongia] int NOT NULL,
	[donVi] nvarchar(10) NOT NULL,
	[trongKho] int NOT NULL,
	[HSD]	datetime2(7) NOT NULL
)
CREATE TABLE [dbo].[tblMonAn]
(
	[maMonAn] nvarchar(10) NOT NULL PRIMARY KEY,
	[dongia] int NOT NULL,
)	
CREATE TABLE [dbo].[tblDSNguyenLieu]
(	
	[maLNguyenLieu] nvarchar(10) NOT NULL,
	[maMonAn] nvarchar(10) NOT NULL,
	[soLuong] int NOT NULL,
	FOREIGN KEY (maLNguyenLieu) REFERENCES tblNguyenLieu(maLNguyenLieu),
	FOREIGN KEY (maMonAn) REFERENCES tblMonAn(maMonAn)
)
CREATE TABLE [dbo].[tblMenu]
(	
	[maMenu] nvarchar(10) NOT NULL PRIMARY KEY,
	[tongTien] int NOT NULL
)
CREATE TABLE [dbo].[tblDSMonAn]
(	
	[maMonAn] nvarchar(10) NOT NULL,
	[maMenu] nvarchar(10) NOT NULL,		
	[soLuong] int NOT NULL,
	[gia]		int NOT NULL,
	FOREIGN KEY (maMonAn) REFERENCES tblMonAn(maMonAn),
	FOREIGN KEY (maMenu) REFERENCES tblMenu(maMenu)
)
CREATE TABLE [dbo].[tblkhachHang]
(		
	[tenKhachHang] nvarchar(50) NOT NULL PRIMARY KEY,
	[sdtKhachHang]	nvarchar(11) 
)
CREATE TABLE [dbo].[tblhoaDon]
(	
	[mahoaDon] nvarchar(10) NOT NULL,
	[tenKhachHang] nvarchar(50) NOT NULL,
	[soban] int NOT NULL,
	[tongTien] int NOT NULL,	
	[ngayThanhToan]	datetime2(7) NOT NULL,
	[maThuNgan] nvarchar(10) NOT NULL,
	FOREIGN KEY (tenKhachHang) REFERENCES tblkhachHang(tenKhachHang),
	FOREIGN KEY (maThuNgan) REFERENCES tblnhanVien(manhanVien)
)
CREATE TABLE [dbo].[tblBan] --its a table of a.....table :)
(	
	[soban] int NOT NULL PRIMARY KEY,
	[booked] BIT NOT NULL,
	[ngayDat]	datetime2(7) NOT NULL,
	[tenKhachHang] nvarchar(50) NOT NULL,
	[maThuNgan] nvarchar(10) NOT NULL,
	[soGheToiDa] int NOT NULL,
	FOREIGN KEY (tenKhachHang) REFERENCES tblkhachHang(tenKhachHang)
)
CREATE TABLE [dbo].[tblPhieubaocaoDoanhThu]
(
	[maPhieu] nvarchar(10) NOT NULL PRIMARY KEY,	
	[tongDoanhThu]	int NOT NULL,	
	[ngayLapPhieu]	 datetime2(7) NOT NULL,	
)
CREATE TABLE [dbo].[tblChitietPhieubaocaoDT]
(
	[maPhieu] nvarchar(10) NOT NULL,	
	[maMenu] nvarchar(10) NOT NULL,
	FOREIGN KEY (maPhieu) REFERENCES tblPhieubaocaoDoanhThu(maPhieu),
	FOREIGN KEY (maMenu) REFERENCES tblMenu(maMenu),	
)

CREATE TABLE [dbo].[tblQuiDinh]
(
	[getkey] int NOT NULL primary key,
	[maxloaidl]    int NOT NULL,	
	[soluongmathang]	int NOT NULL,
	[soluongdvt]	int NOT NULL,	
	[maxdl]	int NOT NULL,--max so dl trong 1 quan
)	

--drop table tblnhanVien
--drop table tblNguyenLieu
--drop table tblMonAn
--drop table tblDSNguyenLieu
--drop table tblMenu
--drop table tblDSMonAn
--drop table tblkhachHang
--drop table tblhoaDon
--drop table tblBan
--drop table tblPhieubaocaoDoanhThu
--drop table tblChitietPhieubaocaoDT
--drop table tblQuiDinh


--dữ liệu có trước--
SET DATEFORMAT dmy;  

----TESTING----

