use master
go
create database PhonesManagement
go
use PhonesManagement
go


CREATE TABLE tbl_Users (
    userId NVARCHAR(20)  NOT NULL,
    password nvarchar(50)NOT NULL,
    fullName NVARCHAR(50) NOT NULL,
    role  NVARCHAR(50) NOT NULL,
	phone  NVARCHAR(50) NOT NULL,
	address  NVARCHAR(50) NOT NULL,
	 CONSTRAINT [PK_tbl_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
	
INSERT INTO tbl_Users (userId, password, fullName, role,phone,address)
VALUES 
('nhan','1', 'Nhan dep trai', 'AD','091234678','tp hcm'),
('hau','1', 'Hau Huynh', 'US','091234678','tp quang ngai'),
('tuan', '1', 'Tuan Pham', 'US','0977123456','tp vung tau'),
('phat', '1', 'Phat Nguyen','US','0977123456','tp tay ninh');
GO

CREATE TABLE [dbo].[tbl_Mobile](

	[mobileId] [nvarchar](10) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [float] NULL,
	[discount] [float] NULL,
	[mobileName] [nvarchar](20) NOT NULL,
	[yearOfProduction] [int] NULL,
	[quantity] [int] NULL,
	[notSale] [bit] NULL,
	[images] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Mobile] PRIMARY KEY CLUSTERED 
(
	[mobileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Samsung examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M002', N'64GB storage and 4GB RAM', 399.989, 10, N'Galaxy A52', 2021, 45, 0, N'a52.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M003', N'32GB storage and 3GB RAM', 199.99, 20, N'Galaxy M12', 2021, 78, 0, N'm12.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M004', N'256GB storage and 8GB RAM', 999.98, 30, N'Galaxy Note 20', 2020, 15, 0, N'Note20.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M005', N'128GB storage and 6GB RAM', 499.95, 40, N'Galaxy A72', 2021, 32, 0, N'a72.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M007', N'512GB storage and 12GB RAM', 1299.9, 50, N'Galaxy S21 Ultra', 2021, 10, 0, N's21.jpg');

-- iPhone examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M013', N'512GB storage and 6GB RAM', 1499.9, 10, N'iPhone 13 Pro Max', 2021, 30, 0, N'iphone13promax.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M018', N'256GB storage and 4GB RAM', 999.9, 12, N'iPhone 12', 2020, 40, 0, N'iphone12.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M023', N'128GB storage and 4GB RAM', 699.9, 8, N'iPhone SE (2020)', 2020, 50, 0, N'iphonese2020.jpg');

-- Redmi examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M014', N'128GB storage and 4GB RAM', 299.9, 15, N'Redmi Note 10', 2021, 50, 0, N'redminote10.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M019', N'64GB storage and 6GB RAM', 199.9, 10, N'Redmi Note 9', 2020, 60, 0, N'redminote9.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M024', N'256GB storage and 8GB RAM', 349.9, 15, N'Redmi K40', 2021, 45, 0, N'redmik40.jpg');

-- Xiaomi examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M015', N'256GB storage and 8GB RAM', 499.9, 20, N'Xiaomi Mi 11', 2021, 40, 0, N'mi11.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M020', N'128GB storage and 6GB RAM', 549.9, 22, N'Xiaomi Mi 10', 2020, 30, 0, N'mi10.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M025', N'128GB storage and 6GB RAM', 399.9, 17, N'Xiaomi Poco X3', 2021, 35, 0, N'pocox3.jpg');

-- Vivo examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M016', N'256GB storage and 12GB RAM', 699.9, 25, N'Vivo X60 Pro', 2021, 20, 0, N'vivox60pro.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M021', N'64GB storage and 4GB RAM', 249.9, 18, N'Vivo Y20', 2020, 70, 0, N'vivoy20.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M026', N'512GB storage and 12GB RAM', 899.9, 20, N'Vivo X50 Pro+', 2020, 20, 0, N'vivox50proplus.jpg');

-- Oppo examples
INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M017', N'128GB storage and 8GB RAM', 399.9, 18, N'Oppo Reno 6', 2021, 35, 0, N'opporeno6.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M022', N'256GB storage and 12GB RAM', 799.9, 20, N'Oppo Find X3 Pro', 2021, 25, 0, N'oppofindx3pro.jpg');

INSERT [dbo].[tbl_Mobile] ([mobileId], [description], [price], [discount], [mobileName], [yearOfProduction], [quantity], [notSale], [images]) 
VALUES (N'M027', N'128GB storage and 6GB RAM', 349.9, 12, N'Oppo A94', 2021, 30, 0, N'oppoa94.jpg');

GO
CREATE TABLE [dbo].[tbl_Invoice](
[invId] [nvarchar] (50) not null,
[userID] [nvarchar] (50)not null,
[total] [float]NULL,
[dateBuy] [datetime] NULL,
[phone] [nvarchar] (50)NULL,
[address] [nvarchar](50) NULL,
CONSTRAINT [PK tbl_Invoice] PRIMARY KEY CLUSTERED
(
[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[tbl_Cart](
	
	[userId] [nvarchar](20) NOT NULL,
	[mobileId] [nvarchar](10) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [float] NULL,
	[discount] [float] NULL,
	[mobileName] [nvarchar](20) NOT NULL,
	[yearOfProduction] [int] NULL,
	[quantity] [int] NULL,
	
	[images] [nvarchar](max) NULL,
 CONSTRAINT [PK tbl_Cart] PRIMARY KEY CLUSTERED
    (
        [userId] ASC,
        [mobileId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[tbl_InvDetails](
[invId] [nvarchar] (50) not null,
[userID] [nvarchar] (50)not null,
[mobileId] [nvarchar](10) NOT NULL,
[mobileName] [nvarchar](20) NOT NULL,
[quantity] [int] NULL,
[total] [float]NULL,
CONSTRAINT [PK tbl_InvDetails] PRIMARY KEY CLUSTERED
(
[invId]	ASC,
[userID] ASC,
[mobileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[tbl_Wishlist](
[userId] [nvarchar](20) NOT NULL,
	[mobileId] [nvarchar](10) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [float] NULL,
	[discount] [float] NULL,
	[mobileName] [nvarchar](20) NOT NULL,
	[yearOfProduction] [int] NULL,
	[quantity] [int] NULL,
	
	[images] [nvarchar](max) NULL,
 CONSTRAINT [PK tbl_Wishlist] PRIMARY KEY CLUSTERED
    (
        [userId] ASC,
        [mobileId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]







