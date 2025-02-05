CREATE DATABASE EduOne_Fr;

USE EduOne_Fr;
GO

CREATE TABLE ApplicationRoles
(
Id uniqueidentifier not null default NEWID(),
NomRole nvarchar(50) not null unique,
[Description] nvarchar(200) not null,
AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

INSERT INTO ApplicationRoles(NomRole,Description,AjouterAu,AjouterPar)
VALUES('Administrateur','Administrateur',GETDATE(),SYSTEM_USER)


INSERT INTO ApplicationRoles(NomRole,Description,AjouterAu,AjouterPar)
VALUES('Utilisateur','Utilisateur',GETDATE(),SYSTEM_USER

SELECT * FROM ApplicationRoles

CREATE TABLE ApplicationForms
(
Id uniqueidentifier not null default NEWID(),
Form nvarchar(800) not null unique,
[Description] nvarchar(200) not null,
AjouterAu datetime2  not null default getdate(),
AjouterPar nvarchar(80) not null default system_user,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

CREATE TABLE ApplicationFormsSecurity
(
Id uniqueidentifier not null default NEWID(),
RoleId  uniqueidentifier not null references ApplicationRoles(Id),
FormId  uniqueidentifier not null references ApplicationForms(Id),
AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)


CREATE TABLE ApplicationUsers
(
Id uniqueidentifier not null default NEWID(),
RoleId uniqueidentifier not null references ApplicationRoles(Id),
Utilisateur nvarchar(50) not null,
[Password] varbinary(max) not null,
Statut bit not null default 0,
Nom nvarchar(100) not null unique,
Prenom nvarchar(200) not null,
DateNaissance datetime2 not null,
Age smallint not null,
Email nvarchar(200) not null unique,
AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

--====FUNCTIONS=================

CREATE OR ALTER FUNCTION func_encrypt_password
(
@password nvarchar(200)
)
returns varbinary(max)
as
begin
  declare @result varbinary(max);
  SET @result=ENCRYPTBYPASSPHRASE(@password, 'You decide here,must be a secret');
  return @result;
end

CREATE OR ALTER FUNCTION func_decrypt_password
(
@password  nvarchar(200),
@EncryptedValue varbinary(max)
)
returns nvarchar(max)
as
begin
  declare @result nvarchar(max);
  SET @result = CONVERT(NVARCHAR(MAX), DECRYPTBYPASSPHRASE(@password, @EncryptedValue));
  return @result;
end




CREATE OR ALTER FUNCTION func_get_roleId
(
@role  nvarchar(200)
)
returns uniqueidentifier
as
begin
  declare @result uniqueidentifier;
  SET @result =(SELECT Id FROM ApplicationRoles WHERE NomRole=@role);
  return @result;
end

CREATE OR ALTER FUNCTION func_validate_password
(
    @email nvarchar(200),
    @password nvarchar(100)
)
RETURNS bit
AS
BEGIN
    DECLARE @result bit = 0;
    DECLARE @encrypted_password varbinary(max);

    -- Retrieve the encrypted password from the database
    SELECT @encrypted_password = au.[Password]
    FROM ApplicationUsers AS au
    WHERE au.Email = @email;

    -- Check if the email exists
    IF @encrypted_password IS NOT NULL
    BEGIN
        -- Decrypt the stored password
        DECLARE @decrypted_value nvarchar(max);
        SET @decrypted_value = dbo.func_decrypt_password('Iam123@#$', @encrypted_password);

        -- Compare decrypted password with user input
        IF @decrypted_value = @password
            SET @result = 1;
    END

    RETURN @result;
END;

/* 01/31/2025 */

CREATE TABLE Students
(
 GlobalId uniqueidentifier not null default newid(),
 Id int identity(1,1) not null,
 Nom nvarchar(100) not null,
 Prénom nvarchar(100) not null,
 Surnom nvarchar(100) not null,
 LieuNaissance datetime2 not null,
 DateNaissance datetime2 not null,
 Genre nvarchar(40) not null,
 Email nvarchar(200)  null,
 TelePhone nvarchar(25) not null,
 Fax nvarchar(25)  null,
 Addresse nvarchar(200) not null,
 Addresse2 nvarchar(200)  null,
 Ville nvarchar(100) not null,
 État nvarchar(100) not null,
 Pays nvarchar(100) not null,
 Date_Inscription datetime null,

 AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)
CREATE TABLE StaffRoles
(
 Id int identity(1,1) not null,
 Role nvarchar(100) not null,
 AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

 INSERT INTO StaffRoles(Role,AjouterAu,AjouterPar) VALUES('Professeur',GETDATE(),SYSTEM_USER)
  INSERT INTO StaffRoles(Role,AjouterAu,AjouterPar) VALUES('Professeure',GETDATE(),SYSTEM_USER);
    INSERT INTO StaffRoles(Role,AjouterAu,AjouterPar) VALUES('Administrateur',GETDATE(),SYSTEM_USER)
        INSERT INTO StaffRoles(Role,AjouterAu,AjouterPar) VALUES('Administratrice',GETDATE(),SYSTEM_USER)
SELECT Role FROM StaffRoles;

CREATE TABLE Staffs
(
 Id int identity(1,1) not null,
  Nom nvarchar(100) not null,
 Prénom nvarchar(100) not null,
 Surnom nvarchar(100) not null,
 LieuNaissance datetime2 not null,
 DateNaissance datetime2 not null,
 Genre nvarchar(40) not null,
 Email nvarchar(200)  null,
 TelePhone nvarchar(25) not null,
 Fax nvarchar(25)  null,
 Date_Embauche datetime2 null,
 Role nvarchar(100) not null, -- e.g., Teacher, Administrator
 AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

CREATE TABLE Departments
(
 Id int identity(1,1) not null,
 Nom_Département nvarchar(200)  null,
 ID_Chef_Département int  null,
 AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)

CREATE TABLE Courses
(
 Cours_Id int identity(1,1) not null,
 Nom_Cours nvarchar(400) not null,
 Description nvarchar(max) not null,
 ID_Department int not null references Departments(Id),
 AjouterAu datetime2  not null,
AjouterPar nvarchar(80) not null,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Cours_Id)
)

CREATE TABLE DepartmentHeads
(
 Id int identity(1,1) not null,
 Nom nvarchar(200) not null,
 Prénom nvarchar(200) not null,
 TelePhone  nvarchar(25) not null,
 Fax  nvarchar(25) null,
 Email  nvarchar(200) not null,
AjouterAu datetime2  not null default getdate(),
AjouterPar nvarchar(80) not null default system_user,
ModifierAu datetime2 null,
ModifierPar nvarchar(80)  null,
Primary Key(Id)
)
