USE [Spinka]
GO

CREATE OR ALTER PROC [dbo].[P_GetDataForDayRepsGroup]
    @startDate Date,
    @endDate Date,
    @dayRepGroupId Int
AS
BEGIN
    DECLARE @Results TABLE(
	    PersonInGroupId INT NOT NULL,
	    FullName NVARCHAR (50) NOT NULL,
	    Day1 INT,
	    Day2 INT,
	    Day3 INT,
	    Day4 INT,
	    Day5 INT,
	    Day6 INT,
	    Day7 INT,
	    Day8 INT,
	    Day9 INT,
	    Day10 INT,
	    Day11 INT,
	    Day12 INT,
	    Day13 INT,
	    Day14 INT
	)

    DECLARE @Dates TABLE(
        ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
        Date DATE
    )
    DECLARE @TempDate DATE=@StartDate

    WHILE(@TempDate<=@EndDate)
        BEGIN
	        INSERT INTO @Dates(Date) VALUES(@TempDate)
	        SET @TempDate=DATEADD(DAY,1,@TempDate)
        END

    INSERT INTO @Results
    SELECT PersonInGroupId,FullName,
        [1] as Day1,
        [2] as Day2,
        [3] as Day3,
        [4] as Day4,
        [5] as Day5,
        [6] as Day6,
        [7] as Day7,
        [8] as Day8,
        [9] as Day9,
        [10] as Day10,
        [11] as Day11,
        [12] as Day12,
        [13] as Day13,
        [14] as Day14
    FROM
    (
	    SELECT pg.ID  as PersonInGroupId,
	        p.LastName +' '+ p.FirstName +IIF(p.OpNo is null,'',char(32) + Replace(STR(p.OpNo),' ','')) as FullName,
	        d.DayRepAcronymId,
	        dt.ID as DateID
	
	    FROM Persons p 
	    INNER JOIN DayRepGroupPersons pg on pg.PersonId=p.Id
	    CROSS JOIN @Dates dt 
	    LEFT JOIN DayReps d on d.DayRepGroupPersonId=pg.Id and convert(date,d.Day)=dt.Date and d.IsDeleted=0
	    Where pg.GroupForDayRepId=@DayRepGroupId and pg.IsDeleted=0 
    ) as d
    PIVOT
	(
	    MAX(DayRepAcronymId)
	    FOR DateID IN ([1],[2],[3],[4],[5],[6],
			[7], [8],[9],
			[10],[11],[12],
			[13],[14] )
	) as pvt
	ORDER BY pvt.FullName;

    SELECT * FROM @Results r
    ORDER BY
	    r.FullName

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