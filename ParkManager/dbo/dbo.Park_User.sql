CREATE TABLE [dbo].[Park_User] (
    [ID]              BIGINT         NOT NULL IDENTITY,
    [User_Carname]    NVARCHAR (500) NOT NULL,
    [User_Name]       NVARCHAR (500) NOT NULL,
    [User_Password]   NVARCHAR (500) NOT NULL,
    [User_Createtime] DATETIME       NOT NULL,
    CONSTRAINT [PK_Park_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

