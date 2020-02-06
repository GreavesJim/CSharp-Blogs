USE bloggr;

-- SELECT * FROM teams

-- CREATE TABLE blogs (
--     id int NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );
CREATE TABLE teams (
    id int NOT NULL AUTO_INCREMENT,
    creatorId VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);
CREATE TABLE players (
    id int NOT NULL AUTO_INCREMENT,
    creatorId VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    number int NOT NULL,
    teamId int, 
    PRIMARY KEY (id),

    FOREIGN KEY (teamId)
    REFERENCES teams(id)
);


