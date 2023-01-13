USE [BGVT]
GO
/****** Object:  StoredProcedure [dbo].[GetChDetails]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Kumar Panda
-- Create date: 12/29/2022
-- Description:	This SP will return Chapters table
-- =============================================
CREATE PROCEDURE [dbo].[GetChDetails]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[Chapters]
END
GO
