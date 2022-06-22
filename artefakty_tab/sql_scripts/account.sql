CREATE TABLE [dbo].[Account] (
    [Id] INT NOT NULL,
    [Title] TEXT NULL, 
    [FirstName] TEXT NULL, 
    [Email] TEXT NULL, 
    [PasswordHash] TEXT NULL, 
    [AcceptTerms] INT NOT NULL, 
    [Role] INT NOT NULL, 
    [VerificationToken] TEXT NULL, 
    [Verified] TEXT NULL, 
    [ResetToken] TEXT NULL, 
    [ResetTokenExpires] TEXT NULL, 
    [PasswordReset] TEXT NULL, 
    [Created] TEXT NOT NULL, 
    [Updated] TEXT NULL, 
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);

