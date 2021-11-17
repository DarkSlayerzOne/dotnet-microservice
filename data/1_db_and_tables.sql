CREATE DATABASE Chuck;
GO
USE Chuck;
GO


CREATE TABLE ChuckNorrisJokes(
    ID uniqueidentifier NOT NULL PRIMARY KEY,
    Joke nvarchar(300) NOT NULL,
    FunnyLevel int default 1,
    CreatedDate datetime
);
GO