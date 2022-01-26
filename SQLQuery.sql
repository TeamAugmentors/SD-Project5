
CREATE TABLE users (
  id int identity(1, 1) primary key,
  user_name varchar(30) NOT NULL,
  mail varchar(30) NOT NULL,
  password varchar(30) NOT NULL,
  name varchar(30) NOT NULL,
  phone_no varchar(11) NULL,
  billing_info varchar(11) NULL,
  picture varchar(200) NULL,
  ban int NOT NULL DEFAULT 0
)

CREATE TABLE freelancer (
  id int NOT NULL,
  earned varchar(30) NOT NULL DEFAULT '0',
  completed int NOT NULL DEFAULT 0,
  rating varchar(10) NOT NULL DEFAULT 0
)
CREATE TABLE hirer (
  id int NOT NULL,
  spent varchar(30) NOT NULL DEFAULT '0',
  hired int NOT NULL DEFAULT 0,
  rating varchar NOT NULL DEFAULT 0
)

CREATE TABLE job (
  id int NOT NULL,
  posted_by int NOT NULL,
  accepted_by int DEFAULT NULL,
  category varchar NOT NULL,
  name varchar(30) NOT NULL,
  salary int NOT NULL,
  duration datetime NOT NULL,
  details text NOT NULL,
  negotiable int NOT NULL,
  preferred_skills varchar(30) NOT NULL
)

SELECT * FROM users
SELECT * FROM freelancer
SELECT * FROM hirer
SELECT * FROM users where mail = 'a@gmail.com';
INSERT INTO freelancer(id) values(100) 