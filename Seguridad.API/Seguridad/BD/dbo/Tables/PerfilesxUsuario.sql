CREATE TABLE [dbo].[PerfilesxUsuario] (
    [IdUsuario] UNIQUEIDENTIFIER NOT NULL,
    [IdPerfil]  INT              NOT NULL,
    CONSTRAINT [FK_PerfilesxUsuario_Perfiles] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfiles] ([Id]),
    CONSTRAINT [FK_PerfilesxUsuario_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

