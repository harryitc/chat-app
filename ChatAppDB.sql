USE master
Go

IF EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME = 'ChatApp')
	DROP DATABASE ChatApp
GO

CREATE DATABASE ChatApp;
GO

USE ChatApp;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(MAX) NOT NULL,
	SecretKey NVARCHAR(MAX) NOT NULL,
    ProfilePicture NVARCHAR(MAX),
    Status NVARCHAR(50), -- CHECK (Status IN ('online', 'offline', 'busy')),
    CreatedAt DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE Groups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(200) NOT NULL,
    GroupDescription NVARCHAR(MAX),
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    GroupImage NVARCHAR(MAX),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
)
GO

CREATE TABLE GroupMembers (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    UserID INT NOT NULL,
    Role NVARCHAR(50), -- CHECK (Role IN ('admin', 'member')) NOT NULL,
    JoinedAt DATETIME DEFAULT GETDATE(),
    LastSeen DATETIME,
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
GO

CREATE TABLE GroupMessages (
    MessageID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    SenderID INT NOT NULL,
    Content NVARCHAR(MAX),
    MessageType NVARCHAR(50), -- CHECK (MessageType IN ('text', 'image', 'file', 'video')) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (SenderID) REFERENCES Users(UserID)
)
GO

CREATE TABLE Attachments (
    AttachmentID INT IDENTITY(1,1) PRIMARY KEY,
    MessageID INT NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    FileType NVARCHAR(50), -- CHECK (FileType IN ('image', 'video', 'document')) NOT NULL,
    FOREIGN KEY (MessageID) REFERENCES GroupMessages(MessageID)
)
GO

CREATE TABLE GroupNotifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    UserID INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    IsRead BIT DEFAULT 0,
    Timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
GO

CREATE TABLE ReadReceipts (
    ReceiptID INT IDENTITY(1,1) PRIMARY KEY,
    MessageID INT NOT NULL,
    UserID INT NOT NULL,
    ReadAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MessageID) REFERENCES GroupMessages(MessageID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
GO

CREATE TABLE Friendships (
    FriendshipID INT IDENTITY(1,1) PRIMARY KEY, -- M  ??nh danh quan h?
    RequesterID INT NOT NULL,                   -- Ng??i g?i y u c?u (Foreign Key t?i Users)
    AddressID INT NOT NULL,                   -- Ng??i nh?n y u c?u (Foreign Key t?i Users)
    Status NVARCHAR(50), -- CHECK (Status IN ('pending', 'accepted', 'blocked')) DEFAULT 'pending', -- Tr?ng th i
    CreatedAt DATETIME DEFAULT GETDATE(),       -- Th?i gian g?i y u c?u
    FOREIGN KEY (RequesterID) REFERENCES Users(UserID),
    FOREIGN KEY (AddressID) REFERENCES Users(UserID),
    CONSTRAINT UC_Friendship UNIQUE (RequesterID, AddressID) -- ??m b?o kh ng tr ng y u c?u
)
GO

/* Old Data, can't use anymore
INSERT INTO Users (Username, Email, Password, ProfilePicture, Status)
VALUES 
('admin', 
'admin@example.com', 
'123', 
'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 
'offline')

INSERT INTO Users (Username, Email, Password, ProfilePicture, Status)
VALUES 
('john_doe', 'john.doe@example.com', 'pass123', 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'offline'),
('jane_smith', 'jane.smith@example.com', 'pass123', 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'offline'),
('alice_wong', 'alice.wong@example.com', 'pass123', 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'busy'),
('bob_brown', 'bob.brown@example.com', 'pass123', 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'offline'),
('charlie_adams', 'charlie.adams@example.com', 'pass123', 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'offline');

INSERT INTO Groups (GroupName, GroupDescription, CreatedBy, GroupImage)
VALUES 
('Tech Talk', 'Group for discussing technology', 1, 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
('Movie Fans', 'Discuss your favorite movies here', 2, 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
('Book Club', 'Monthly book discussions', 3, 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');

INSERT INTO GroupMembers (GroupID, UserID, Role, LastSeen)
VALUES 
(1, 1, 'admin', GETDATE()),
(1, 2, 'member', GETDATE()),
(2, 2, 'admin', GETDATE()),
(2, 3, 'member', GETDATE()),
(3, 3, 'admin', GETDATE()),
(3, 4, 'member', GETDATE());

INSERT INTO GroupMessages (GroupID, SenderID, Content, MessageType)
VALUES 
(1, 1, 'Welcome to Tech Talk!', 'text'),
(1, 2, 'Thank you! Looking forward to discussions.', 'text'),
(2, 2, 'Has anyone watched the latest movie?', 'text'),
(3, 3, 'This months book is "The Great Gatsby."', 'text');

INSERT INTO Attachments (MessageID, FilePath, FileType)
VALUES 
(1, 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'image'),
(3, 'https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'document');

INSERT INTO GroupNotifications (GroupID, UserID, Content)
VALUES 
(1, 2, 'John added a new member to Tech Talk'),
(2, 3, 'Jane sent a message in Movie Fans'),
(3, 4, 'Alice started a new discussion in Book Club');

INSERT INTO ReadReceipts (MessageID, UserID, ReadAt)
VALUES 
(1, 2, GETDATE()),
(2, 1, GETDATE()),
(3, 4, GETDATE());

INSERT INTO Friendships (RequesterID, AddressID, Status)
VALUES 
(1, 2, 'accepted'),
(1, 3, 'pending'),
(2, 3, 'accepted'),
(3, 4, 'blocked'),
(4, 5, 'accepted');
*/