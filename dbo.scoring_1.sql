CREATE TABLE [dbo].[scoring] (
    [Id]     INT        NOT NULL,
    [name]   NCHAR (20) NULL,
    [score]  NCHAR (10) NULL,
    [status] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

