USE bloggr;


CREATE TABLE blogs (
    id int NOT NULL AUTO_INCREMENT,
    creatorId VARCHAR(255) NOT NULL,
    title VARCHAR(255) NOT NULL,
    body VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);