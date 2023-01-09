BEGIN TRANSACTION;

INSERT INTO tblKeywordType (pkKeywordType, KeywordTypeDescription)
VALUES (1, 'Ability Words'), (2, 'Keyword Abilities'), (3, 'Keyword Actions');

COMMIT;