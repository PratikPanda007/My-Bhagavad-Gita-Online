USE [BGVT]
GO
/****** Object:  StoredProcedure [dbo].[DD_Chapters]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Kumar Panda
-- Create date: 12/28/2022
-- Description:	This SP will return Chapter Name and Chapter Number
-- =============================================
CREATE PROCEDURE [dbo].[DD_Chapters] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ChapterId, ChapterName FROM [dbo].[Chapters] ORDER BY ChapterId ASC
END
GO
