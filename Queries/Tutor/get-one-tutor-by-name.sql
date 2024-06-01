SELECT
  Name, 
  Address, 
  City,
  Id
FROM
  Persons
WHERE
  Name = @Name
