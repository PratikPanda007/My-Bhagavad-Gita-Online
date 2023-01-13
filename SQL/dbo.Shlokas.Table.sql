USE [BGVT]
GO
/****** Object:  Table [dbo].[Shlokas]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shlokas](
	[ShlokaId] [int] IDENTITY(1,1) NOT NULL,
	[ChapterId] [int] NULL,
	[ShlokaSubId] [int] NULL,
	[Shloka] [nvarchar](max) NOT NULL,
	[Transliteration] [nvarchar](max) NULL,
	[ShlokaTrans] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[Purport] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShlokaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Shlokas]  WITH CHECK ADD FOREIGN KEY([ChapterId])
REFERENCES [dbo].[Chapters] ([ChapterId])
GO
