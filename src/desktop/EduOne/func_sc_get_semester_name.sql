CREATE OR ALTER Procedure proc_get_enrollments
as
SELECT e.InscriptionID as Id, dbo.func_sc_get_semester_name(e.SemestreID) as Semestre,
dbo.func_sc_get_studentName(e.EleveId) as Eleve,
dbo.func_sc_get_courseName(e.CoursId) as Cours,e.Grade,e.Notes,
e.AjouterAu,e.AjouterPar,e.ModifierAu,e.ModifierPar
FROM Enrollments as e


CREATE OR ALTER function func_sc_get_semester_name
(
@semester_id int
)
returns nvarchar(100)
as
begin
 declare @semester_name nvarchar(100)
	select @semester_name = Semestre from Semesters where id = @semester_id
	return @semester_name
end