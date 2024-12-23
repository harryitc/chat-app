USE master
IF EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME = 'ChatApp')
	DROP DATABASE ChatApp
GO

-- T?o c? s? d? li?u
CREATE DATABASE ChatApp;
GO

USE ChatApp;
GO

-- B?ng Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    ProfilePicture NVARCHAR(500),
    Status NVARCHAR(50), -- CHECK (Status IN ('online', 'offline', 'busy')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

go

-- B?ng Groups
CREATE TABLE Groups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(200) NOT NULL,
    GroupDescription NVARCHAR(MAX),
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    GroupImage NVARCHAR(500),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);
go

-- B?ng GroupMembers
CREATE TABLE GroupMembers (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    UserID INT NOT NULL,
    Role NVARCHAR(50), -- CHECK (Role IN ('admin', 'member')) NOT NULL,
    JoinedAt DATETIME DEFAULT GETDATE(),
    LastSeen DATETIME,
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

go

-- B?ng GroupMessages
CREATE TABLE GroupMessages (
    MessageID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    SenderID INT NOT NULL,
    Content NVARCHAR(MAX),
    MessageType NVARCHAR(50), -- CHECK (MessageType IN ('text', 'image', 'file', 'video')) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (SenderID) REFERENCES Users(UserID)
);

-- B?ng Attachments
CREATE TABLE Attachments (
    AttachmentID INT IDENTITY(1,1) PRIMARY KEY,
    MessageID INT NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    FileType NVARCHAR(50), -- CHECK (FileType IN ('image', 'video', 'document')) NOT NULL,
    FOREIGN KEY (MessageID) REFERENCES GroupMessages(MessageID)
);

go

-- B?ng GroupNotifications
CREATE TABLE GroupNotifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    UserID INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    IsRead BIT DEFAULT 0,
    Timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

go

-- B?ng ReadReceipts
CREATE TABLE ReadReceipts (
    ReceiptID INT IDENTITY(1,1) PRIMARY KEY,
    MessageID INT NOT NULL,
    UserID INT NOT NULL,
    ReadAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MessageID) REFERENCES GroupMessages(MessageID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

go

-- B?ng Friendships (Quan h? b?n b )
CREATE TABLE Friendships (
    FriendshipID INT IDENTITY(1,1) PRIMARY KEY, -- M  ??nh danh quan h?
    RequesterID INT NOT NULL,                   -- Ng??i g?i y u c?u (Foreign Key t?i Users)
    AddressID INT NOT NULL,                   -- Ng??i nh?n y u c?u (Foreign Key t?i Users)
    Status NVARCHAR(50), -- CHECK (Status IN ('pending', 'accepted', 'blocked')) DEFAULT 'pending', -- Tr?ng th i
    CreatedAt DATETIME DEFAULT GETDATE(),       -- Th?i gian g?i y u c?u
    FOREIGN KEY (RequesterID) REFERENCES Users(UserID),
    FOREIGN KEY (AddressID) REFERENCES Users(UserID),
    CONSTRAINT UC_Friendship UNIQUE (RequesterID, AddressID) -- ??m b?o kh ng tr ng y u c?u
);
go

-- Th m ng??i d ng v o b?ng Users
INSERT INTO Users (Username, Email, Password, ProfilePicture, Status)
VALUES 
('admin', 
'admin@example.com', 
'123', 
'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 
'online')

SELECT * FROM Friendships 
go

Select * from Users
go

INSERT INTO Users (Username, Email, Password, ProfilePicture, Status)
VALUES 
	('duc', 'duc@example.com', '123', '', 'online'),
	('an', 'an@example.com', '123', '', 'online'),
	('cuong', 'cuong@example.com', '123', '', 'online'),
	('trung', 'trung@example.com', '123', '', 'online')
go
