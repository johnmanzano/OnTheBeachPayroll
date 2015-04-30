CREATE TABLE [dbo].[Salaries] (
    [id]            INT    IDENTITY (1, 1) NOT NULL,
    [employee_id]   INT    NOT NULL,
    [currency_id]   INT    NOT NULL,
    [annual_amount] BIGINT NOT NULL,
    CONSTRAINT [FK_Salaries_Currencies] FOREIGN KEY ([currency_id]) REFERENCES [dbo].[Currencies] ([id]),
    CONSTRAINT [FK_Salaries_Employees] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([id])
);

