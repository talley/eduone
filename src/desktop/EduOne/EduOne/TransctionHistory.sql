CREATE OR ALTER TRIGGER trg_Audit_SemesterEnrollmentFees
ON SemesterEnrollmentFees
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Handle DELETE
    --INSERT INTO TransactionSecurity (ActionType, EmployeeID, Name, Position, Salary)
    --SELECT 'DELETE', EmployeeID, Name, Position, Salary
    --FROM deleted
    --WHERE NOT EXISTS (
    --    SELECT 1 FROM inserted WHERE inserted.EmployeeID = deleted.EmployeeID
    --);

    -- Handle INSERT
    INSERT INTO dbo.TransactionSecurity
           (GID
           ,EleveId
           ,SemestreId
           ,Statut
           ,MontantDu
           ,MontantReçu
           ,Balance
           ,Notes
           ,AjouterAu
           ,AjouterPar
           ,ModifierAu
           ,ModifierPar
           ,Type_Action
           ,Utilisateur_Action
           ,Date_Action)

    SELECT i.GID,
	        i.EleveId
           ,i.SemestreId
           ,i.Statut
           ,i.MontantDu
           ,i.MontantReçu
           ,i.Balance
           ,i.Notes
           ,i.AjouterAu
           ,i.AjouterPar
           ,i.ModifierAu
           ,i.ModifierPar
           ,'INSÉRER'
           ,SYSTEM_USER
           ,GETDATE()
    FROM inserted as i
    WHERE NOT EXISTS (
        SELECT 1 FROM deleted WHERE deleted.GID = i.GID
    );

    -- Handle UPDATE
     INSERT INTO dbo.TransactionSecurity
           (GID
           ,EleveId
           ,SemestreId
           ,Statut
           ,MontantDu
           ,MontantReçu
           ,Balance
           ,Notes
           ,AjouterAu
           ,AjouterPar
           ,ModifierAu
           ,ModifierPar
           ,Type_Action
           ,Utilisateur_Action
           ,Date_Action)
    SELECT i.GID,
	        i.EleveId
           ,i.SemestreId
           ,i.Statut
           ,i.MontantDu
           ,i.MontantReçu
           ,i.Balance
           ,i.Notes
           ,i.AjouterAu
           ,i.AjouterPar
           ,i.ModifierAu
           , i.ModifierPar
           ,'MIS À JOUR'
           ,SYSTEM_USER
           ,GETDATE()
    FROM inserted as i
    INNER JOIN deleted d ON i.GID = d.GID
    
END;