USE Chuck;
GO


CREATE PROC sp_read_chuck_jokes_randomly
AS
BEGIN

    SET NOCOUNT ON;
    SELECT TOP 1 * FROM ChuckNorrisJokes ORDER BY NEWID()

END
GO

CREATE PROC sp_read_chuck_jokes_by_joke_level
@JokeLevel int
AS
BEGIN

    SET NOCOUNT ON;
    SELECT * FROM ChuckNorrisJokes WHERE JokeLevel=@JokeLevel

END
GO