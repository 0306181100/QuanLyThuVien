create database QLTV

use QLTV
--1
create table tbSach
(
	MaSach varchar(10) primary key,
	TenSach nvarchar(50),
	MaTheLoai varchar(10),
	GiaThue int,
	SoLuong int,
	--số lượng =0 =>trạng thái =0
	TrangThai bit,
	-- mượn đc =1,không mượn đc =0
	DaXoa bit
)

--2
create table tbTheloai
(
	MaTheLoai varchar(10) primary key,
	TheLoai nvarchar(30),
	DaXoa bit
)

--3
create table tbNhaCungCap
(
	MaNCC varchar(10) primary key,
	TenNCC nvarchar(30),
	DiaChi nvarchar(50),
	Email nvarchar(50),
	DaXoa bit
)
--4
create table tbHoaDonNhap(
	MaHD varchar(10) primary key,
	MaNCC varchar(10),
	NgayLap datetime,
	DaXoa bit
)
--5
create table tbChiTietHoaDonNhap
(
	MaHD varchar(10),
	MaSach varchar(10),
	TenSach nvarchar(30),
	primary key(MaHD,MaSach),
	SoLuong int,
	DonGia int,
	DaThem bit,
	DaXoa bit
)
--6
create table tbTheDocGia
(
	MaTheDocGia varchar(10) primary key,
	HoTen nvarchar(50),
	Gioitinh nvarchar(4),
	NgaySinh datetime,
	CMND varchar(10),
	Ngaylap datetime,
	NgayHetHan datetime,
	--Ngày hết hạn = ngày lập +30
	SDT varchar(12),
	--khi gần đến hạn thì nhắc nhân viên gọi nhắc nhở,
	--có thể null nhưng khi mượn phải cập nhật SDT
	DiaChi nvarchar(50),
	GhiChu nvarchar(50),
	--nếu vi phạm sẽ ghi vào đây
	DaXoa bit
)
--7
create table tbNhanVien
(
	MaNV varchar(10) primary key,
	TaiKhoan varchar(20),
	HoTen nvarchar(50),
	NgaySinh datetime,
	DiaChi nvarchar(30),
	Gioitinh nvarchar(4),
	SDT varchar(12),
	Quyen bit,--1 có quyen quan ly nhan vien, 0 thì ngược lại.
	DaXoa bit 
	--Xóa tk thì xóa NV
)
--8
create table tbTaiKhoan
(
	TaiKhoan varchar(20) primary key,
	MatKhau varchar(20),--=SDT sau khi mã hóa
	DaXoa bit
)
--9
create table tbPhieuMuon
(
	MaPhieuMuon varchar(10) primary key,
	MaDocGia varchar(10),
	foreign key (MaDocGia) references tbTheDocGia(MaTheDocGia),
	MaNV varchar(10),
	NgayLap datetime,
	DaXoa bit
)
--10
create table tbChiTietPhieuMuon(
	MaTheDocGia varchar(10),
	STT int,
	Primary key (MaTheDocGia,STT),
	-- constraint check_SoLuong_CT check (count(MaPhieuMuon)<=3),
	-- trước khi mượn kiểm tra số lần mượn chưa trả phải < 3
	MaSach varchar(10),
	NgayMuon datetime,
	HanMuon int,
	-- if (NgayTra == null) HanMuon = 7-(ngay hien tai - NgayMuon)
	-- <= 2 ngày thông báo cho nhân viên;
	-- <= 0 Ghi chú vào bảng tbDocGia và đóng tiền phạt; 
	NgayTra nvarchar(30),
	GhiChu nvarchar(50),
	DaXoa bit
	--tbPhieuMuon.DaXoa=tbChiTietPhieuMuon.DaXoa;
)

alter table tbSach
add foreign key (Matheloai) references tbTheloai(Matheloai)
alter table tbHoaDonNhap
add foreign key (MaNCC) references tbNhaCungCap(MaNCC)
alter table tbChiTietHoaDonNhap
add foreign key (MaHD) references tbHoaDonNhap(MaHD)
alter table tbNhanVien
add foreign key (TaiKhoan) references tbTaiKhoan(TaiKhoan)
alter table tbPhieuMuon
add foreign key (MaNV) references tbNhanVien(MaNV)
alter table tbChiTietPhieuMuon
add foreign key (MaTheDocGia) references tbTheDocGia(MaTheDocGia)
alter table tbChiTietPhieuMuon
add foreign key (MaSach) references tbSach(MaSach)

--1
insert into tbTheloai
values('sdl',N'Sách địa lí',0),
('sls',N'Sách lịch sử',0),
('stt',N'Sách tiểu thuyết',0),
('sgk',N'Sách giáo khoa',0),
('sct',N'Sách chính trị',0),
('tt',N'Truyện tranh',0)
--select * from tbTheLoai
--delete from tbTheLoai

--2
insert into tbNhaCungCap
values('1',N'Kim Đồng',N'Hà Nội','kimdong@gmail.com',0),
('2',N'Nhã Nam',N'Hà Nội','nhanam@gmail.com',0),
('3',N'Đông Tị',N'Hà Nội','dongti@gmail.com',0),
('4',N'Minh Long',N'Hà Nội','minlong@gmail.com',0)
select * from tbNhaCungCap
--delete from tbNhaCungCap

--3
insert into tbTaiKhoan
values('nguyenhoanglong','123456',0),
('lequanghai','123456',0),
('hogiabao','123456',0)
--select * from tbTaiKhoan
--delete from tbTaiKhoan

--4
insert into tbTheDocGia
values('1',N'Nguyễn Văn A',N'Nam','1/1/2000','0123456789','1/1/2020','1/1/2021','0123456789',N'TP Hồ Chí Minh',null,0),
('2',N'Nguyễn Thị B',N'Nữ','1/1/2000','0123456789','1/2/2020','1/2/2021','0123456789',N'TP Hồ Chí Minh',null,0),
('3',N'Nguyễn Văn C','Nam','1/1/2000','0123456789','1/2/2020','1/2/2021','0123456789',N'Hà Nội',null,0),
('4',N'Nguyễn Thị D',N'Nữ','1/1/2000','0123456789','1/1/2020','1/1/2021','0123456789',N'Hà Nội',null,0)
--select * from tbTheDocGia
--delete from tbTheDocGia

--5
insert into tbSach
values('1',N'Tuổi trẻ đáng giá bao hhiêu','stt',57000,5,1,0),
('2',N'Tôn tử binh pháp','sls',61000,6,1,0),
('3',N'Ngữ văn 12','sgk',20000,7,1,0),
('4',N'Đắc nhân tâm','stt',81000,8,1,0)
--select * from tbSach
--delete from tbSach

--6
insert into tbNhanVien
values('1','nguyenhoanglong',N'Nguyễn Hoàng Long','2/2/2000',N'HCM','Nam','1234567890',0,0),
('2','lequanghai',N'Lê Quang Hải','3/3/2000',N'Hà Nội','Nam','1234567890',0,0),
('3','hogiabao',N'Hồ Gia Bảo','4/4/2000',N'HCM',N'Nữ','1234567890',1,0)
select * from tbNhanVien
--delete from tbNhanVien

--7
insert into tbPhieuMuon
values('1','1','1','4/4/2020',0),
('2','1','1','4/4/2020',0),
('3','2','1','5/5/2020',0),
('4','2','1','5/4/2020',1),
('5','3','1','6/4/2020',0),
('6','3','1','3/4/2020',1)
select * from tbPhieuMuon
--delete from tbPhieuMuon

--8
insert into tbHoaDonNhap
values('HD1','1','2/2/2020',0),
('HD2','2','2/2/2020',1),
('HD3','3','3/2/2020',0),
('HD4','4','5/2/2020',1),
('HD5','2','7/2/2020',0),
('HD6','1','10/2/2020',0)
select * from tbHoaDonNhap
--delete from tbHoaDonNhap

--9
insert into tbChiTietHoaDonNhap
values('HD1','1',N'Bí kíp Yasuo',2,57000*2,0,0),
('HD2','1',N'Những điều răn của Huấn rose',2,61000*2,0,0)
select * from tbChiTietHoaDonNhap
--delete from tbChiTietHoaDonNhap

--10
insert into tbChiTietPhieuMuon
values('1','1','1','4/4/2020',7,'4/11/2020',null,0),
('2','1','3','4/5/2020',7,'4/12/2020',null,0),
('3','2','1','4/5/2020',7,'4/12/2020',null,0),
('4','2','3','4/9/2020',7,'4/16/2020',null,0)
select * from tbChiTietPhieuMuon
--delete from tbChiTietPhieuMuon
