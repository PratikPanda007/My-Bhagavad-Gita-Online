USE [BGVT]
GO
/****** Object:  StoredProcedure [dbo].[GetShlokaByChapterAndVerseNumber]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Kumar Panda
-- Create date: 01/01/2023
-- Description:	This SP will return Shlokas from Chapter and Verse numbers
-- =============================================
CREATE PROCEDURE [dbo].[GetShlokaByChapterAndVerseNumber]
	-- Add the parameters for the stored procedure here
	@ChId int,
	@VerseId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT S.ChapterId, C.ChapterName, S.ShlokaSubId, S.Shloka, S.Transliteration, ShlokaTrans, Notes, Purport FROM Shlokas S LEFT Join Chapters C ON C.ChapterId = S.ChapterId WHERE s.ChapterId = @ChId AND S.ShlokaSubId = @VerseId
END
GO
