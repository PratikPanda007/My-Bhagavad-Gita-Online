USE [BGVT]
GO
/****** Object:  StoredProcedure [dbo].[GetShlokasByChapterNum]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Kumar Panda
-- Create date: 12/29/2022
-- Description:	This SP will return Shlokas from Chapter numbers
-- =============================================
CREATE PROCEDURE [dbo].[GetShlokasByChapterNum] 
	-- Add the parameters for the stored procedure here
	@ChId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ChapterId, ChapterName FROM Chapters WHERE ChapterId = @ChId
	SELECT * FROM Shlokas WHERE ChapterId = @ChId ORDER BY ShlokaSubId ASC
END
GO
