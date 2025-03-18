CREATE TABLE CompanyApprovedComputers
(
 CId int identity(1,1) not null,
 CompanyId int not null,
 MachineName nvarchar(max) not null,
 IP  nvarchar(max)  null,
 Approved bit not null default 0,
 Status bit not null default 0,
 Notes  nvarchar(max)  null,
 AddedOn datetime2  not null default getdate(),
AddedBy nvarchar(80) not null default system_user,
UpdatedOn datetime2 null,
UpdatedBy nvarchar(80)  null,
Primary Key(CId)

)