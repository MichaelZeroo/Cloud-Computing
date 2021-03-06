USE [CatBabysitting]
GO
/****** Object:  Table [dbo].[Cat]    Script Date: 29/08/2018 12:22:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat](
	[CatId] [int] IDENTITY(10000,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[NameOfCat] [nvarchar](50) NULL,
	[Condition] [nvarchar](50) NULL,
	[Weight] [float] NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_Cat] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 29/08/2018 12:22:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [int] IDENTITY(10371,1) NOT NULL,
	[FirstNames] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Password] [nvarchar](256) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](80) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cat] ON 

INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10000, 10372, N'Alicia', N'VO', 3, 4)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10001, 10372, N'Tiddles', N'CO', 2, 2)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10002, 10372, N'Mikey', N'AD', 4.3, 3)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10003, 10372, N'Pearl', N'FI', 3.8, 4)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10004, 10372, N'Donald1', N'DT', 2, 2)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10005, 10372, N'Donald2', N'BT', 0.2, 2)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10006, 10373, N'TomJerry', N'BT', 4, 8)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10007, 10373, N'cat01', N'AD', 0.1, 1)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10008, 10373, N'TomJerry2', N'AM', 4.7, 39)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10009, 10373, N'Jayson', N'VO', 10, 10)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10010, 10373, N'bart', NULL, 15, 5)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10011, 10373, N'Donald3', N'BT', 2, 2)
INSERT [dbo].[Cat] ([CatId], [MemberId], [NameOfCat], [Condition], [Weight], [Age]) VALUES (10012, 10372, N'Jupiter', N'AM', 2.7, 11)
SET IDENTITY_INSERT [dbo].[Cat] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([MemberId], [FirstNames], [LastName], [Password], [Phone], [Email]) VALUES (10372, N'John', N'Testing', N'TDrsrDztEo4IzKzlvtYj8kwkrnCjbqHI5mcYXs6+JlmtJJ22nZOXbvN7eLegiRy6Jo/L4Gsxb7Ump8BPyAIYrQ==', N'222-222222', N'jt@example.com')
INSERT [dbo].[Member] ([MemberId], [FirstNames], [LastName], [Password], [Phone], [Email]) VALUES (10373, N'John', N'Testing', N'TDrsrDztEo4IzKzlvtYj8kwkrnCjbqHI5mcYXs6+JlmtJJ22nZOXbvN7eLegiRy6Jo/L4Gsxb7Ump8BPyAIYrQ==', N'222-222222', N'jt2@example.com')
INSERT [dbo].[Member] ([MemberId], [FirstNames], [LastName], [Password], [Phone], [Email]) VALUES (10374, N'John', N'Testing', N'wwwww', N'8888', N'aa@bbb.ccc')
INSERT [dbo].[Member] ([MemberId], [FirstNames], [LastName], [Password], [Phone], [Email]) VALUES (10375, N'Harold', N'Testing', N'uuuuu', N'12345', N'hhh@aa.bbb')
SET IDENTITY_INSERT [dbo].[Member] OFF
ALTER TABLE [dbo].[Cat]  WITH CHECK ADD  CONSTRAINT [FK_Cat_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Cat] CHECK CONSTRAINT [FK_Cat_Member]
GO
