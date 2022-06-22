CREATE TABLE [dbo].[RefreshToken] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [AccountId]       INT NOT NULL,
    [Token]           TEXT NULL,
    [Expires]         TEXT NOT NULL,
    [Created]         TEXT NOT NULL,
    [CreatedByIp]     TEXT NULL,
    [Revoked]         TEXT NULL,
    [RevokedByIp]     TEXT NULL,
    [ReplacedByToken] TEXT NULL,
    [ReasonRevoked]   TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

