-- CREATE TABLE profiles (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY(id)
-- )

-- CREATE TABLE keeps (
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   image VARCHAR(255) NOT NULL,
--   keepCount INT NOT NULL,
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   keeps INT,
--   creator VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE

 



-- )

-- CREATE TABLE vaults (
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT NOT NULL,
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE

-- )

-- CREATE TABLE vaultkeeps (
--   id INT NOT NULL AUTO_INCREMENT,
--   vaultId INT NOT NULL,
--   keepId INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
  
--   PRIMARY KEY(id),

--   FOREIGN KEY (vaultId)
--   REFERENCES vaults(id)
--   ON DELETE CASCADE,

--   FOREIGN KEY(keepId)
--   REFERENCES keeps(id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (creatorId)
--   REFERENCES profiles (id)
--   ON DELETE CASCADE



-- )

-- ALTER TABLE keeps
--   DROP COLUMN keepCount

-- ALTER TABLE keeps
--   DROP COLUMN title

-- ALTER TABLE keeps
-- ADD name VARCHAR(255);

-- ALTER TABLE keeps
--   DROP COLUMN image

-- ALTER TABLE keeps
-- ADD img VARCHAR(255);

--  ALTER TABLE keeps
--   DROP COLUMN creator

--  ALTER TABLE keeps
-- ADD views INT 