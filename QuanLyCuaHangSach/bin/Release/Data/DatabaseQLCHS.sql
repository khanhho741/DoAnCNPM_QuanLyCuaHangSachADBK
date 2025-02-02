USE [QLBSTEST1]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaSach] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietNhapSach]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhapSach](
	[MaSach] [nchar](10) NOT NULL,
	[MaPhieuNhap] [int] NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[SoLuongNhap] [int] NOT NULL,
	[GiaNhap] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ChiTietNhapSach_1] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaPhieuNhap] ASC,
	[NgayNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1000) NOT NULL,
	[SoTienThanhToan] [decimal](18, 0) NOT NULL,
	[SoLuongSachDaMua] [int] NOT NULL,
	[MaTheDocGia] [nchar](10) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[NgayLapHoaDon] [datetime] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1000) NOT NULL,
	[HoTenKhachHang] [nvarchar](250) NOT NULL,
	[SDT_KhachHang] [nchar](10) NOT NULL,
	[DiaChiKhachHang] [nvarchar](250) NULL,
	[GioiTinh] [int] NOT NULL,
	[NgaySinh] [datetime] NULL,
	[LoaiKhachHang] [int] NOT NULL,
	[Email] [nchar](100) NOT NULL,
 CONSTRAINT [PK_KhachHang_1] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoSach]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoSach](
	[MaKhoSach] [nchar](10) NOT NULL,
	[TenKhoSach] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KhoSach] PRIMARY KEY CLUSTERED 
(
	[MaKhoSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKhachHang]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhachHang](
	[LoaiKhachHang] [int] NOT NULL,
	[TenLoaiKhachHang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiDocGia] PRIMARY KEY CLUSTERED 
(
	[LoaiKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [nchar](10) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nchar](100) NOT NULL,
	[LoaiNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[SDTNhanVien] [nchar](10) NOT NULL,
	[DiaChiNhanVien] [nvarchar](150) NOT NULL,
	[HinhAnhNhanVien] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaNhaXuatBan] [nchar](10) NOT NULL,
	[TenNhaXuatBan] [nvarchar](250) NOT NULL,
	[SDTNhaXuatBan] [nchar](10) NOT NULL,
	[DiaChiNhaXuatBan] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNhaXuatBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[NgayLapPhieu] [datetime] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaKhoSach] [nchar](10) NOT NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](10) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[GiaBan] [decimal](18, 0) NOT NULL,
	[MaTacGia] [nchar](10) NOT NULL,
	[MaNhaXuatBan] [nchar](10) NOT NULL,
	[MaTheLoaiSach] [nchar](10) NOT NULL,
	[NDTomTat] [nvarchar](2500) NULL,
	[HinhAnh] [nvarchar](150) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SachTrongKho]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SachTrongKho](
	[MaSach] [nchar](10) NOT NULL,
	[MaKhoSach] [nchar](10) NOT NULL,
	[SoLuongTon] [int] NOT NULL,
 CONSTRAINT [PK_SachTrongKho] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaKhoSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [nchar](10) NOT NULL,
	[TenTacGia] [nvarchar](250) NOT NULL,
	[SDTTacGia] [nchar](10) NOT NULL,
	[DiaChiTacGia] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoan] [nchar](100) NOT NULL,
	[MatKhau] [nchar](100) NOT NULL,
	[Email] [nchar](100) NOT NULL,
	[HovaTen] [nvarchar](100) NOT NULL,
	[VoHieuHoa] [bit] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheDocGia]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheDocGia](
	[MaTheDocGia] [nchar](10) NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[NgayLapThe] [datetime] NOT NULL,
	[SoDiemTichLuy] [int] NOT NULL,
 CONSTRAINT [PK_TheDocGia] PRIMARY KEY CLUSTERED 
(
	[MaTheDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoaiSach]    Script Date: 1/12/2024 5:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoaiSach](
	[MaTheLoaiSach] [nchar](10) NOT NULL,
	[TenTheLoai] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoaiSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (10001, N'MS01      ', 5)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (14001, N'MS05      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (15001, N'MS04      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (16001, N'MS03      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (32001, N'MS02      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (33001, N'MS01      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (34001, N'MS01      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (35001, N'MS01      ', 8)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (36001, N'MS04      ', 49)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (37001, N'MS04      ', 331)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong]) VALUES (39001, N'MS03      ', 1)
GO
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS01      ', 0, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 4, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS01      ', 11, CAST(N'2023-09-10T00:00:00.000' AS DateTime), 20, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS01      ', 14, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 2, CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS01      ', 15, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 2, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS01      ', 16, CAST(N'2023-10-31T22:27:14.000' AS DateTime), 44, CAST(643440 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS02      ', 0, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 4, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS02      ', 13, CAST(N'2023-09-28T00:00:00.000' AS DateTime), 30, CAST(13500 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS02      ', 16, CAST(N'2023-10-31T22:27:14.000' AS DateTime), 40, CAST(643434 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS03      ', 0, CAST(N'2023-10-05T15:04:43.000' AS DateTime), 4, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS03      ', 0, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 4, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS03      ', 11, CAST(N'2023-09-10T00:00:00.000' AS DateTime), 35, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS03      ', 14, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 2, CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS03      ', 18, CAST(N'2023-10-31T22:28:56.000' AS DateTime), 10, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS04      ', 0, CAST(N'2023-10-31T15:04:43.000' AS DateTime), 4, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS04      ', 12, CAST(N'2023-09-23T00:00:00.000' AS DateTime), 40, CAST(32000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS04      ', 17, CAST(N'2023-10-31T22:28:56.000' AS DateTime), 400, CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS05      ', 13, CAST(N'2023-09-28T00:00:00.000' AS DateTime), 30, CAST(17000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietNhapSach] ([MaSach], [MaPhieuNhap], [NgayNhap], [SoLuongNhap], [GiaNhap]) VALUES (N'MS05      ', 17, CAST(N'2023-10-31T22:28:56.000' AS DateTime), 1200, CAST(360000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (10001, CAST(115000 AS Decimal(18, 0)), 5, N'DG004     ', 33, CAST(N'2023-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (14001, CAST(20000 AS Decimal(18, 0)), 1, N'DG001     ', 32, CAST(N'2023-10-08T00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (15001, CAST(70000 AS Decimal(18, 0)), 2, N'DG003     ', 33, CAST(N'2023-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (16001, CAST(100000 AS Decimal(18, 0)), 2, N'DG005     ', 32, CAST(N'2023-10-20T00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (32001, CAST(30000 AS Decimal(18, 0)), 2, N'DG001     ', 29, CAST(N'2023-11-01T02:33:02.840' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (33001, CAST(46000 AS Decimal(18, 0)), 2, N'DG001     ', 29, CAST(N'2023-11-01T02:37:40.087' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (34001, CAST(46000 AS Decimal(18, 0)), 2, N'DG001     ', 29, CAST(N'2023-11-01T11:10:06.190' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (35001, CAST(184000 AS Decimal(18, 0)), 8, N'qwqw      ', 29, CAST(N'2023-11-01T11:20:38.767' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (36001, CAST(1715000 AS Decimal(18, 0)), 49, N'qwqw      ', 29, CAST(N'2023-11-01T11:25:42.920' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (37001, CAST(11585000 AS Decimal(18, 0)), 331, N'sdfsd     ', 29, CAST(N'2023-11-01T13:00:13.550' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [SoTienThanhToan], [SoLuongSachDaMua], [MaTheDocGia], [MaNhanVien], [NgayLapHoaDon]) VALUES (39001, CAST(50000 AS Decimal(18, 0)), 1, N'DG001     ', 29, CAST(N'2024-01-04T17:26:12.133' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (4001, N'Nguyễn Văn An', N'0994951611', N'123 Nguyễn Du', 1, CAST(N'1989-10-20T00:00:00.000' AS DateTime), 1, N'vanan@gmail.com                                                                                     ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (6001, N'Huỳnh Thị Diễm My', N'0942325661', N'25 Từ Văn Tư', 0, CAST(N'1998-02-24T00:00:00.000' AS DateTime), 0, N'diemmy@gmail.com                                                                                    ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (8001, N'Nguyễn Toàn Thắng', N'0869121616', N'36 Nguyễn Kiệm', 1, CAST(N'1996-05-17T00:00:00.000' AS DateTime), 2, N'toanthang@gmail.com                                                                                 ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (9001, N'Lê Thị Tú Oanh', N'0659448991', N'18/06 Lê Tú', 0, CAST(N'2005-05-19T00:00:00.000' AS DateTime), 1, N'thituoanh@gmail.com                                                                                 ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (10001, N'Nguyễn Quốc Duy', N'0346896566', N'656 Nguyễn Duy Từ', 1, CAST(N'2000-05-06T00:00:00.000' AS DateTime), 2, N'quocduy@gmail.com                                                                                   ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (11001, N'ed', N'aw        ', N'qw', 1, CAST(N'2023-10-29T12:40:23.997' AS DateTime), 2, N'qwq                                                                                                 ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (12001, N'baongu', N'dfs       ', N'dsf', 0, CAST(N'2023-10-30T12:40:23.000' AS DateTime), 0, N'dfs                                                                                                 ')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTenKhachHang], [SDT_KhachHang], [DiaChiKhachHang], [GioiTinh], [NgaySinh], [LoaiKhachHang], [Email]) VALUES (13001, N'jfghuj', N'dfsdfh    ', N'ddf', 1, CAST(N'2023-10-11T12:40:23.000' AS DateTime), 2, N'dsfdsf                                                                                              ')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
INSERT [dbo].[KhoSach] ([MaKhoSach], [TenKhoSach]) VALUES (N'KHO01     ', N'Kho 1')
INSERT [dbo].[KhoSach] ([MaKhoSach], [TenKhoSach]) VALUES (N'KHO02     ', N'Kho 2')
INSERT [dbo].[KhoSach] ([MaKhoSach], [TenKhoSach]) VALUES (N'KHO03     ', N'Kho 3')
GO
INSERT [dbo].[LoaiKhachHang] ([LoaiKhachHang], [TenLoaiKhachHang]) VALUES (0, N'Khách mới')
INSERT [dbo].[LoaiKhachHang] ([LoaiKhachHang], [TenLoaiKhachHang]) VALUES (1, N'Khách quen')
INSERT [dbo].[LoaiKhachHang] ([LoaiKhachHang], [TenLoaiKhachHang]) VALUES (2, N'Khách VIP')
GO
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'GD        ', N'Giám Đốc')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'NV        ', N'Nhân Viên')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'QLNV      ', N'Quản Lý Nhân Viên')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'QLTC      ', N'Kế Toán')
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [TaiKhoan], [LoaiNhanVien], [TenNhanVien], [SDTNhanVien], [DiaChiNhanVien], [HinhAnhNhanVien]) VALUES (29, N'GDNTS                                                                                               ', N'GD        ', N'Nguyễn Thành Sơn', N'0599851911', N'72 Tên Lửa', NULL)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TaiKhoan], [LoaiNhanVien], [TenNhanVien], [SDTNhanVien], [DiaChiNhanVien], [HinhAnhNhanVien]) VALUES (31, N'QLNV                                                                                                ', N'QLNV      ', N'Nguyễn Gia Bảo', N'0651656365', N'692 Trần Hưng Đạo', N'638400091925755574-360_F_224869519_aRaeLneqALfPNBzg0xxMZXghtvBXkfIA.jpg')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TaiKhoan], [LoaiNhanVien], [TenNhanVien], [SDTNhanVien], [DiaChiNhanVien], [HinhAnhNhanVien]) VALUES (32, N'NV                                                                                                  ', N'NV        ', N'Hồ Chí Khanh', N'0984516515', N'60 Đồng Nai', NULL)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TaiKhoan], [LoaiNhanVien], [TenNhanVien], [SDTNhanVien], [DiaChiNhanVien], [HinhAnhNhanVien]) VALUES (33, N'QLTC                                                                                                ', N'QLTC      ', N'Nguyễn Hoàng Thiên Ân', N'0594651682', N'25 Nguyễn Liên', NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB01     ', N'Nhà xuất bản Trẻ', N'0489616535', N'61B Lý Chính Thắng, phường Võ Thị Sáu, Quận 3')
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB02     ', N'Nhà xuất bản Kim Đồng', N'0301568412', N'248 Cống Quỳnh, P. Phạm Ngũ Lão, Q.1')
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB03     ', N'Nhà xuất bản Hội Nhà văn', N'0316556120', N'65 Nguyễn Du, Quận Hai Bà Trưng')
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB04     ', N'Nhà xuất bản Lao Động', N'0121214653', N'175 Giảng Võ, Đống Đa')
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB05     ', N'Nhà xuất bản Nhã Namnn', N'0654846311', N'59 Đỗ Quang, Cầu Giấy')
INSERT [dbo].[NhaXuatBan] ([MaNhaXuatBan], [TenNhaXuatBan], [SDTNhaXuatBan], [DiaChiNhaXuatBan]) VALUES (N'NXB06     ', N'Nhà xuất bản khanh', N'0654846311', N'59 Đỗ Quang, Cầu Giấy')
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (0, CAST(N'2023-10-31T15:37:17.000' AS DateTime), 29, N'KHO03     ', CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (11, CAST(N'2023-09-10T00:00:00.000' AS DateTime), 31, N'KHO03     ', CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (12, CAST(N'2023-09-23T00:00:00.000' AS DateTime), 31, N'KHO02     ', CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (13, CAST(N'2023-09-28T00:00:00.000' AS DateTime), 33, N'KHO03     ', CAST(41000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (14, CAST(N'2023-10-31T19:52:13.103' AS DateTime), 29, N'KHO01     ', CAST(61000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (15, CAST(N'2023-10-31T19:52:13.103' AS DateTime), 29, N'KHO01     ', CAST(41000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (16, CAST(N'2023-10-31T21:46:03.973' AS DateTime), 29, N'KHO01     ', CAST(54048720 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (17, CAST(N'2023-10-31T21:46:03.973' AS DateTime), 29, N'KHO01     ', CAST(552000000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLapPhieu], [MaNhanVien], [MaKhoSach], [TongTien]) VALUES (18, CAST(N'2023-10-31T15:37:17.000' AS DateTime), 29, N'KHO01     ', CAST(300000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MaTacGia], [MaNhaXuatBan], [MaTheLoaiSach], [NDTomTat], [HinhAnh]) VALUES (N'MS01      ', N'Những Bức Di Thư Cổ Thành', CAST(23000 AS Decimal(18, 0)), N'TG02      ', N'NXB03     ', N'02        ', NULL, N'638404825479342648-sach-clean-code-ma-sach-va-con-duong-tro-thanh-lap-trinh-vien-gioi.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MaTacGia], [MaNhaXuatBan], [MaTheLoaiSach], [NDTomTat], [HinhAnh]) VALUES (N'MS02      ', N'Bảy Viên Ngọc Rồng', CAST(15000 AS Decimal(18, 0)), N'TG03      ', N'NXB02     ', N'05        ', NULL, N'638404825536059644-i.doanhnhansaigon.vn-2018-08-25-_mot-lit-nuoc-mat-2277-1535167004.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MaTacGia], [MaNhaXuatBan], [MaTheLoaiSach], [NDTomTat], [HinhAnh]) VALUES (N'MS03      ', N'Theo Dấu Chân Bác Hồ', CAST(50000 AS Decimal(18, 0)), N'TG04      ', N'NXB04     ', N'04        ', NULL, N'638404825603908106-sao-chung-ta-lai-ngu.png')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MaTacGia], [MaNhaXuatBan], [MaTheLoaiSach], [NDTomTat], [HinhAnh]) VALUES (N'MS04      ', N'Chùm Nho Thịnh Nộ', CAST(35000 AS Decimal(18, 0)), N'TG02      ', N'NXB01     ', N'01        ', NULL, N'638404330781115192-dac-nhan-tam_600x865.png')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MaTacGia], [MaNhaXuatBan], [MaTheLoaiSach], [NDTomTat], [HinhAnh]) VALUES (N'MS05      ', N'Sự Tích Chú Cuội', CAST(20000 AS Decimal(18, 0)), N'TG05      ', N'NXB05     ', N'03        ', NULL, N'638404825661302941-nxbtre_full_29292017_042903 (1).jpg')
GO
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS01      ', N'KHO01     ', 95)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS01      ', N'KHO02     ', 4)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS02      ', N'KHO01     ', 38)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS02      ', N'KHO02     ', 4)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS02      ', N'KHO03     ', 30)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS03      ', N'KHO01     ', 12)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS03      ', N'KHO02     ', 33)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS04      ', N'KHO01     ', 20)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS04      ', N'KHO02     ', 4)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS04      ', N'KHO03     ', 45)
INSERT [dbo].[SachTrongKho] ([MaSach], [MaKhoSach], [SoLuongTon]) VALUES (N'MS05      ', N'KHO01     ', 1255)
GO
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG01      ', N'Lê Xuân Hiếu ', N'0981462365', N'336 Lê Văn Hoàn')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG02      ', N'Nguyễn Văn Luân', N'0931315464', N'54 Trần Hưng Đạo')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG03      ', N'Trần Thoại ', N'0943561561', N'15 Hùng Vương')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG036     ', N'Trần Thoại344', N'0943561561', N'15 Hùng Vương')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG04      ', N'Tấn Hưng', N'0315158455', N'19/03 Hàm Tử')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [SDTTacGia], [DiaChiTacGia]) VALUES (N'TG05      ', N'Lê Quốc Oai', N'0164364133', N'01/12 Lê Tú')
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [Email], [HovaTen], [VoHieuHoa]) VALUES (N'GDNTS                                                                                               ', N'FCB9AD2921B2C253624EAA7D65FD79A1                                                                    ', N'thanhsonnguyen3001@gmail.com                                                                        ', N'0', 0)
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [Email], [HovaTen], [VoHieuHoa]) VALUES (N'NV                                                                                                  ', N'81DC9BDB52D04DC20036DBD8313ED055                                                                    ', N'khanhho741@gmail.com                                                                                ', N'Ho Chi Khanh', 0)
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [Email], [HovaTen], [VoHieuHoa]) VALUES (N'NVA                                                                                                 ', N'23533333                                                                                            ', N'khanhchii741@gmail.com                                                                              ', N'Nguyen Van A', 0)
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [Email], [HovaTen], [VoHieuHoa]) VALUES (N'QLNV                                                                                                ', N'7A8C2BC10628BC9F87C25D2402A91C3C                                                                    ', N'nguyengiabao@gmail.com                                                                              ', N'0', 0)
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [Email], [HovaTen], [VoHieuHoa]) VALUES (N'QLTC                                                                                                ', N'nguyenhoangt                                                                                        ', N'thienan@gmail.com                                                                                   ', N'asdasd0', NULL)
GO
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'DG001     ', 4001, CAST(N'2023-09-01T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'DG002     ', 6001, CAST(N'2023-10-20T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'DG003     ', 8001, CAST(N'2023-05-05T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'DG004     ', 9001, CAST(N'2023-08-05T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'DG005     ', 10001, CAST(N'2023-04-06T00:00:00.000' AS DateTime), 85)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'dsfsfd    ', 12001, CAST(N'2023-11-01T11:23:15.857' AS DateTime), 0)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'qwqw      ', 11001, CAST(N'2023-11-01T01:30:38.137' AS DateTime), 57)
INSERT [dbo].[TheDocGia] ([MaTheDocGia], [MaKhachHang], [NgayLapThe], [SoDiemTichLuy]) VALUES (N'sdfsd     ', 13001, CAST(N'2023-11-01T11:23:59.607' AS DateTime), 331)
GO
INSERT [dbo].[TheLoaiSach] ([MaTheLoaiSach], [TenTheLoai]) VALUES (N'01        ', N'Tiểu Thuyết')
INSERT [dbo].[TheLoaiSach] ([MaTheLoaiSach], [TenTheLoai]) VALUES (N'02        ', N'Truyện Ngắn')
INSERT [dbo].[TheLoaiSach] ([MaTheLoaiSach], [TenTheLoai]) VALUES (N'03        ', N'Truyện Cổ Tích')
INSERT [dbo].[TheLoaiSach] ([MaTheLoaiSach], [TenTheLoai]) VALUES (N'04        ', N'Lịch Sử')
INSERT [dbo].[TheLoaiSach] ([MaTheLoaiSach], [TenTheLoai]) VALUES (N'05        ', N'Truyện Tranh')
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sach]
GO
ALTER TABLE [dbo].[ChiTietNhapSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhapSach_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietNhapSach] CHECK CONSTRAINT [FK_ChiTietNhapSach_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietNhapSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhapSach_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietNhapSach] CHECK CONSTRAINT [FK_ChiTietNhapSach_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_TheDocGia] FOREIGN KEY([MaTheDocGia])
REFERENCES [dbo].[TheDocGia] ([MaTheDocGia])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_TheDocGia]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_LoaiKhachHang] FOREIGN KEY([LoaiKhachHang])
REFERENCES [dbo].[LoaiKhachHang] ([LoaiKhachHang])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_LoaiKhachHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNhanVien] FOREIGN KEY([LoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TaiKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_KhoSach] FOREIGN KEY([MaKhoSach])
REFERENCES [dbo].[KhoSach] ([MaKhoSach])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_KhoSach]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MaNhaXuatBan])
REFERENCES [dbo].[NhaXuatBan] ([MaNhaXuatBan])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoaiSach] FOREIGN KEY([MaTheLoaiSach])
REFERENCES [dbo].[TheLoaiSach] ([MaTheLoaiSach])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoaiSach]
GO
ALTER TABLE [dbo].[SachTrongKho]  WITH CHECK ADD  CONSTRAINT [FK_SachTrongKho_KhoSach] FOREIGN KEY([MaKhoSach])
REFERENCES [dbo].[KhoSach] ([MaKhoSach])
GO
ALTER TABLE [dbo].[SachTrongKho] CHECK CONSTRAINT [FK_SachTrongKho_KhoSach]
GO
ALTER TABLE [dbo].[SachTrongKho]  WITH CHECK ADD  CONSTRAINT [FK_SachTrongKho_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[SachTrongKho] CHECK CONSTRAINT [FK_SachTrongKho_Sach]
GO
ALTER TABLE [dbo].[TheDocGia]  WITH CHECK ADD  CONSTRAINT [FK_TheDocGia_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[TheDocGia] CHECK CONSTRAINT [FK_TheDocGia_KhachHang]
GO
