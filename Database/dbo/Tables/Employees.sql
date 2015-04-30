CREATE TABLE [dbo].[Employees] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [name]    VARCHAR (255) NOT NULL,
    [role_id] INT           NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Employees_Roles] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Roles] ([id])
);

GO

CREATE NONCLUSTERED INDEX [IX_Employees] ON [dbo].[Employees]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
