SELECT 
  Id, 
  Name 
FROM 
  DapperDB.PetTypes pt
WHERE
  Name = @Name