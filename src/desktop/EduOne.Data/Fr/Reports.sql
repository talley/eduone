 CREATE OR ALTER PROCEDURE proc_rpt_get_all_users
 as
 SELECT
 au.Utilisateur,'[MASQUÉE]' as Password,
 case au.Statut
 WHEN 1 THEN 'Actif'
 WHEN 0 THEN 'InActif'
 END AS Statut ,
 au.Nom,au.Prenom as Prénom,
 dbo.func_get_french_date(0, au.DateNaissance) as DateNaissance,
 au.Email,
 au.AjouterAu,
 au.AjouterPar,
 au.ModifierAu,
 ISNULL(au.ModifierPar,'N/A') as ModifierPar
 FROM ApplicationUsers as au
 INNER JOIN ApplicationRoles as ro ON au.RoleId = ro.Id
 ORDER BY au.AjouterAu DESC




 SELECT FORMAT(CAST('2025-02-04 00:00:00.0000000' AS DATETIME2), 'dd/MM/yyyy', 'fr-FR') AS FrenchDate;

 CREATE OR ALTER FUNCTION func_get_french_date
 (
 @as_today bit=0,
 @date datetime2
 )
 returns nvarchar(200)
 as
 begin
  declare @result nvarchar(200)
  if @as_today=0
  begin
     set @result=(SELECT FORMAT(CAST(@date AS DATETIME2), 'dd/MM/yyyy', 'fr-FR'))
  end

  if @as_today=1
  begin
     set @date=NULL;
     set @result=(SELECT FORMAT(CAST(getdate() AS DATETIME2), 'dd/MM/yyyy', 'fr-FR'))
  end
  return @result;
 end


 select dbo.func_get_french_date(1,NULL)


 CREATE OR ALTER Procedure proc_rpt_get_department_heads
 as
 SELECT dh.Nom,dh.Prénom,dbo.func_get_french_date(0,dh.DateNaissance) as DateNaissance,dh.TelePhone as Téléphone,
 dh.Email,dh.Fax,
 case dh.Statut
 WHEN 1 THEN 'Actif'
 WHEN 0 THEN 'InActif'
 END AS Statut ,dh.Notes,
 dh.AjouterAu,dh.AjouterPar,dh.ModifierAu,dh.ModifierPar
 FROM DepartmentHeads as dh

 CREATE OR ALTER FUNCTION func_get_department_head_name
 (
 @department_head_id int,
 @department_id int
 )
 returns nvarchar(200)
 as
 begin
   declare @result nvarchar(200)
   set @result=(
   SELECT dh.Nom+' '+dh.Prénom FROM Departments as  d
   INNER JOIN DepartmentHeads as dh ON d.ID_Chef_Département = dh.Id
   WHERE d.ID_Chef_Département=@department_head_id AND d.Id=@department_id
   )
   return ISNULL(@result,'Aucun(e)')
 end

 /*
  CREATE OR ALTER FUNCTION func_get_french_date
 (
 @as_today bit=0,
 @date datetime2
 )
 */

 CREATE OR ALTER Proc proc_rpt_departments
 as
 SELECT d.Id, d.Nom_Département,dbo.func_get_department_head_name(d.ID_Chef_Département,d.Id) as [Chef de département],ISNULL(d.Description,'N/A') as Description,
 dbo.func_get_french_date(0,d.AjouterAu) as AjouterAu,d.AjouterPar,dbo.func_get_french_date(0,d.ModifierAu) as ModifierAu,d.ModifierAu
 FROM Departments as d

 CREATE OR ALTER PROC proc_rpt_staffs
 as
 SELECT s.Nom,s.Prénom,s.LieuNaissance,s.Genre,s.Email,s.Date_Embauche,
 s.Role,s.Notes,
 case s.Status
 WHEN 1 THEN 'Actif'
 WHEN 0 THEN 'InActif'
 END AS Statut ,
 dbo.func_get_french_date(0,s.AjouterAu) as AjouterAu,
 s.AjouterPar,
 dbo.func_get_french_date(0,s.ModifierAu) as ModifierAu,s.ModifierAu
 FROM Staffs as s
