USE [Spinka]
GO

CREATE OR ALTER PROC [dbo].[P_DayRepNumbersForGroupInnerDashBoardProcedure]
@day Date,
@DayRepGroupId Int
AS
BEGIN
    DECLARE @Results TABLE(
	    DayRepValueName NVARCHAR (50) NULL,
	    DayRepValueFull NVARCHAR (150) NULL,
	    DayRepValueLocation NVARCHAR (50) NULL,
	    DayRepValueDescription NVARCHAR (50) NULL,
	    MilitaryRankPl NVARCHAR (50) NULL,
	    PersonName NVARCHAR (50) NULL,
	    PersonOpNo INT null
    )

    INSERT INTO @Results

    Select da.Description,
        CONCAT(da.Description,IIF((len(dr.Description)=0),'',', '+dr.Description),IIF((len(dr.Location)=0),'',', '+dr.Location)) as fulla,
        dr.Location,  
        dr.Description,
        mr.AcrRankPl,
        p.LastName,
        p.OpNo
    from DayRepGroupPersons dgp 
		left join DayReps dr on dgp.Id= dr.DayRepGroupPersonId
		left join Persons p on p.id =dgp.PersonId
		left join DayRepAcronyms da on da.id=dr.DayRepAcronymId
		left join MilitaryRanks mr on mr.id=p.MilitaryRankId
    where dgp.GroupForDayRepId=@DayRepGroupId and dgp.IsDeleted=0 and datediff(day, dr.Day ,@Day)=0


    SELECT * FROM @Results r
    ORDER BY
        r.DayRepValueFull,
	    r.PersonName

    IF @@ERROR<>0 GOTO ERROR_PROC

    --------------------------------------------------------------------------
    -- exit point of the store proc
    RETURN(0)

    ERROR_PROC:
	    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
	    DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
	    DECLARE @ErrorState INT = ERROR_STATE()
	    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
END