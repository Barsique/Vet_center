CREATE TABLE [dbo].[Животные] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Код_хозяина]  INT            NULL,
    [Кличка]           NVARCHAR (MAX) NULL,
    [Порода] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Животные_ToTable] FOREIGN KEY ([Код_хозяина]) REFERENCES [dbo].[Родители] ([Id])
);

