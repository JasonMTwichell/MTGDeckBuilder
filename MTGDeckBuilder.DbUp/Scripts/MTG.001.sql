BEGIN TRANSACTION;
-- COLOR AND COLOR IDENTITY WILL USE THE SAME SEARCH PARAMS SO THE PK NEED TO BE MATCHED 
INSERT INTO tblColor (pkColor, Color)
VALUES (1, 'W'), (2, 'U'), (3, 'R'), (4, 'B'), (5, 'G');

INSERT INTO tblColorIdentity (pkColorIdentity, ColorIdentity)
VALUES (1, 'W'), (2, 'U'), (3, 'R'), (4, 'B'), (5, 'G');

COMMIT;