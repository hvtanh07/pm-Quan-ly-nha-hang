

USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLNH')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLNH') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLNH]
END
GO

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
	[machucVu] nvarchar(10) NOT NULL
)
CREATE TABLE [dbo].[tblphucVu]
(	
	[maphucVu] nvarchar(10) NOT NULL PRIMARY KEY,
	[soBanDaPhucVu] int NOT NULL,
	[thuongTheoBan]	int NOT NULL,
)
CREATE TABLE [dbo].[tblquanLy]
(	
	[maquanLy] nvarchar(10) NOT NULL PRIMARY KEY,
	[kpi] int NOT NULL,
	[luongDatkpi]	int NOT NULL
)
CREATE TABLE [dbo].[tblthuNgan]
(	
	[mathuNgan] nvarchar(10) NOT NULL PRIMARY KEY,
	[gioLam] int NOT NULL,
	[thuongGioLam] int NOT NULL
)
CREATE TABLE [dbo].[tblNguyenLieu]
(	
	[maNguyenLieu] nvarchar(10) NOT NULL PRIMARY KEY,
	[tenNguyenLieu]	nvarchar(50) NOT NULL,	
	[dongia] int NOT NULL,
	[donVi] nvarchar(10) NOT NULL,
	[trongKho] int NOT NULL,
	[HSD]	datetime2(7) NOT NULL
)
CREATE TABLE [dbo].[tblMonAn]
(
	[maMonAn] nvarchar(10) NOT NULL PRIMARY KEY,
	[tenMonAn]	nvarchar(50) NOT NULL,	
	[dongia] int NOT NULL,
)	
CREATE TABLE [dbo].[tblDSNguyenLieu]
(	
	[maNguyenLieu] nvarchar(10) NOT NULL,
	[maMonAn] nvarchar(10) NOT NULL,
	[soLuong] int NOT NULL,
	FOREIGN KEY (maNguyenLieu) REFERENCES tblNguyenLieu(maNguyenLieu),
	FOREIGN KEY (maMonAn) REFERENCES tblMonAn(maMonAn)
)
CREATE TABLE [dbo].[tblBan] --its a table of a.....table :)
(	
	[soban] int NOT NULL PRIMARY KEY,
)
CREATE TABLE [dbo].[tbldsBandadat] 
(	
	[soban] int NOT NULL,
	[ngayDat]	datetime2(7) NOT NULL,
	FOREIGN KEY (soban) REFERENCES tblBan(soban)
)
CREATE TABLE [dbo].[tblhoaDon]
(	
	[mahoaDon] nvarchar(10) NOT NULL PRIMARY KEY,
	[soban] int NOT NULL,
	[tongTien] int NOT NULL,	
	[ngayThanhToan]	datetime2(7) NOT NULL,
	[mathuNgan] nvarchar(10) NOT NULL,
	--FOREIGN KEY (mathuNgan) REFERENCES tblthuNgan(mathuNgan),
	FOREIGN KEY (soban) REFERENCES tblBan(soban)
)
CREATE TABLE [dbo].[tblDSMonAn]
(	
	[maMonAn] nvarchar(10) NOT NULL,
	[mahoaDon] nvarchar(10) NOT NULL,		
	[soLuong] int NOT NULL,
	FOREIGN KEY (maMonAn) REFERENCES tblMonAn(maMonAn),
	FOREIGN KEY (mahoaDon) REFERENCES tblhoaDon(mahoaDon)	
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
	[mahoaDon] nvarchar(10) NOT NULL,
	FOREIGN KEY (maPhieu) REFERENCES tblPhieubaocaoDoanhThu(maPhieu),
	FOREIGN KEY (mahoaDon) REFERENCES tblhoaDon(mahoaDon)
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
INSERT INTO tblBan ([soban]) VALUES (1)
INSERT INTO tblBan ([soban]) VALUES (2)
INSERT INTO tblBan ([soban]) VALUES (3)
INSERT INTO tblBan ([soban]) VALUES (4)
----TESTING----

