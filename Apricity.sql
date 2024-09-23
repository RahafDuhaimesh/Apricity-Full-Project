CREATE DATABASE Apricity;
GO

USE Apricity;
GO

-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100) NULL,
	LastName NVARCHAR(100),
    Email NVARCHAR(100) NULL,
    Password NVARCHAR(255) NULL,
	PasswordHash varbinary(MAX),
	PasswordSalt varbinary(MAX),
	PhoneNumber varchar(30),
	Role int
);

-- Doctors Table
CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY IDENTITY,
    DoctorName NVARCHAR(100) NULL,
    Specialization NVARCHAR(100) NULL,
    Email NVARCHAR(100) NULL,
    Phone NVARCHAR(50) NULL,
	University NVARCHAR(50),
	Bio NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);

-- Appointments Table (linking Users and Doctors)
CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    DoctorID INT NULL FOREIGN KEY REFERENCES Doctors(DoctorID) ON DELETE SET NULL,
    AppointmentDate DATETIME NULL,
    Status NVARCHAR(50) NULL,
	Comment NVARCHAR(MAX),
	Feedback NVARCHAR(MAX),
	MeetingLink NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY,
    TeacherName NVARCHAR(100) NULL,
    Email NVARCHAR(100) NULL,
    Phone NVARCHAR(50) NULL,
    Specialization NVARCHAR(100) NULL,
);

CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NULL,
    Description NVARCHAR(MAX) NULL,
    EventDate DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NULL,
    MinChildAge INT NULL,
    MaxChildAge INT NULL,
    Capacity INT NULL,
    Price FLOAT NULL,  
    TeacherID INT NULL FOREIGN KEY REFERENCES Teachers(TeacherID) ON DELETE SET NULL
);

CREATE TABLE EventAppointments (
    AppointmentID INT PRIMARY KEY IDENTITY,
    EventID INT NULL FOREIGN KEY REFERENCES Events(EventID) ON DELETE CASCADE,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    AppointmentDate DATETIME NULL,
    Status NVARCHAR(50) NULL,  -- E.g., 'Confirmed', 'Cancelled'
   ChildName NVARCHAR(50),
   ChildAge int,
   Comment NVARCHAR(MAX),
);

-- Contact Table
CREATE TABLE Contacts (
    ContactID INT PRIMARY KEY IDENTITY,
Email NVARCHAR(50),
Message NVARCHAR(MAX) NULL,
Subject NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);

-- Articles Table
CREATE TABLE Articles (
    ArticleID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NULL,
    Content NVARCHAR(MAX) NULL,
    AuthorID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);

-- Community Posts Table
CREATE TABLE CommunityPosts (
    PostID INT PRIMARY KEY IDENTITY,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    Content NVARCHAR(MAX) NULL,
	Image VARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);

-- Community Comments Table (linking Users and CommunityPosts)
CREATE TABLE CommunityComments (
    CommentID INT PRIMARY KEY IDENTITY,
    PostID INT NULL FOREIGN KEY REFERENCES CommunityPosts(PostID) ON DELETE CASCADE,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    Comment NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);

-- Community Likes Table (linking Users and CommunityPosts)
CREATE TABLE CommunityLikes (
    LikeID INT PRIMARY KEY IDENTITY,
    PostID INT NULL FOREIGN KEY REFERENCES CommunityPosts(PostID) ON DELETE CASCADE,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);
CREATE TABLE ArticleComments (
    CommentID INT PRIMARY KEY IDENTITY,
    ArticleID INT NULL FOREIGN KEY REFERENCES Articles(ArticleID) ON DELETE CASCADE,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    CommentText NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);
CREATE TABLE CommentReplies (
    ReplyID INT PRIMARY KEY IDENTITY,
    CommentID INT NULL FOREIGN KEY REFERENCES ArticleComments(CommentID) ON DELETE CASCADE,
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE SET NULL,
    ReplyText NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NULL
);
