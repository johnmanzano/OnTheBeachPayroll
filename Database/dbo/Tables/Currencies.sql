CREATE TABLE [dbo].[Currencies] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [unit]              VARCHAR (255)   NOT NULL,
    [conversion_factor] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([id] ASC)
);

