﻿

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
	[tongTien] int NOT NULL,
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
INSERT INTO [tblnhanVien] ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu]) VALUES ('nv1','Nam','05/12/1999',133,'cv1')
INSERT INTO [tblnhanVien] ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu]) VALUES ('nv2','Tuan','24/1/1999',133,'cv1')
INSERT INTO [tblnhanVien] ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu]) VALUES ('nv3','Hung','5/3/1999',133,'cv1')
INSERT INTO [tblnhanVien] ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu]) VALUES ('nv4','Quang','15/7/1999',133,'cv1')
INSERT INTO [tblnhanVien] ([manhanVien], [tenNhanVien], [birth], [luongCoBan], [machucVu]) VALUES ('nv5','Dung','25/2/1999',133,'cv1')
INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia], [donVi], [trongKho], [HSD]) VALUES ('nl1','Thit',12,'ky',5,'12/12/2019')
INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia], [donVi], [trongKho], [HSD]) VALUES ('nl2','Ca',13,'ky',6,'12/12/2019')
INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia], [donVi], [trongKho], [HSD]) VALUES ('nl3','Trung',14,'qua',13,'12/12/2019')
INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia], [donVi], [trongKho], [HSD]) VALUES ('nl4','Sua',15,'lit',2,'12/12/2019')
INSERT INTO [tblNguyenLieu] ([maNguyenLieu], [tenNguyenLieu], [dongia], [donVi], [trongKho], [HSD]) VALUES ('nl5','Rau',10,'bo',4,'12/12/2019')
INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia]) VALUES ('ma1', 'Banh gato', 100)
INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia]) VALUES ('ma2', 'Ca chien', 80)
INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia]) VALUES ('ma3', 'Trung chien', 50)
INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia]) VALUES ('ma4', 'Banh bong lan', 60)
INSERT INTO [tblMonAn] ([maMonAn], [tenMonAn], [dongia]) VALUES ('ma5', 'Canh', 70)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl3','ma1',3)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl4','ma1',1)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl2','ma2',1)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl5','ma2',1)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl3','ma3',3)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl3','ma4',3)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl4','ma4',1)
INSERT INTO [tblDSNguyenLieu] ([maNguyenLieu], [maMonAn], [soLuong]) VALUES ('nl5','ma5',1)
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (1,'12/1/2019')
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (2,'12/1/2019')
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (3,'12/1/2019')
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (2,'13/1/2019')
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (1,'13/1/2019')
INSERT INTO [tbldsBandadat] ([soban], [ngayDat]) VALUES (4,'12/1/2019')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd1',1,123,'12/12/2019','nv1')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd2',2,100,'12/12/2019','nv1')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd3',3,124,'12/12/2019','nv1')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd4',2,73,'13/12/2019','nv1')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd5',1,103,'13/12/2019','nv1')
INSERT INTO [tblhoaDon] ([mahoaDon], [soban], [tongTien], [ngayThanhToan], [mathuNgan]) VALUES ('hd6',4,203,'12/12/2019','nv1')
----TESTING----

