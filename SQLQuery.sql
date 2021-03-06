
CREATE TABLE users (
  id int identity(1, 1) primary key,
  user_name varchar(30) NOT NULL,
  mail varchar(30) NOT NULL,
  password varchar(30) NULL,
  name varchar(30) NOT NULL,
  phone_no varchar(11) NULL,
  billing_info varchar(11) NULL,
  picture varchar(500) NULL,
  ban int NOT NULL DEFAULT 0,
  token varchar(2000) NULL,
  verified int DEFAULT 0 NOT NULL,
  verifylink varchar(35) NULL,
)


CREATE TABLE freelancer (
  id int NOT NULL,
  earned varchar(30) NOT NULL DEFAULT '0',
  completed int NOT NULL DEFAULT 0,
  rating varchar(10) NOT NULL DEFAULT 0,
)


CREATE TABLE hirer (
  id int NOT NULL,
  spent varchar(30) NOT NULL DEFAULT '0',
  hired int NOT NULL DEFAULT 0,
  rating varchar(10) NOT NULL DEFAULT 0,
)
Insert into freelancer (id, earned, completed, rating) values (19,'5000', 3, '3.7') 

CREATE TABLE job (
  id int PRIMARY KEY identity(1, 1) NOT NULL,
  posted_by int NOT NULL,
  hired_id int DEFAULT NULL,
  category varchar(30) NOT NULL,
  name varchar(30) NOT NULL,
  salary int NOT NULL,
  revisions int NOT NULL,
  duration datetime NOT NULL,
  details text NULL,
  negotiable int NOT NULL,
  preferred_skills varchar(30) NOT NULL
)

CREATE TABLE applications (
job_id int NOT NULL, 
applied_id int NOT NULL,
)


CREATE TABLE activeorder (
  serial int IDENTITY(1, 1) PRIMARY KEY,
  user_id int NOT NULL,
  job_id int NOT NULL
)

CREATE TABLE jobfiles (
serial int IDENTITY(1, 1) PRIMARY KEY,
job_id int NOT NULL,
sample_files varchar(255) NOT NULL
)



CREATE TABLE jobimages (
serial int IDENTITY(1, 1) PRIMARY KEY,
job_id int NOT NULL,
sample_images varchar(255) NOT NULL
)

Select Top 1 * from jobimages ORDER BY serial DESC

INSERT INTO job (posted_by, hired_id, category, name, salary,revisions, duration, details, negotiable, preferred_skills) VALUES
(2, NULL, 'Graphics & Design', 'Illustration2', 3000, 3, '2022-02-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(3, NULL, 'Programming', 'C++', 3000, 4, '2022-02-20 02:30:01', 'Programming is very nice', 1, 'Design'),
(2, NULL, 'Game Development', 'Unity', 3000, 3,'2022-01-31 02:30:01', 'Unity is very nice', 1, 'Design')
(1, NULL, 'Graphics & Design', 'Illustration4', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(1, NULL, 'Graphics & Design', 'Illustration5', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(25, NULL, 'Writing & Translation', 'Translate1', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(26, 2, 'Writing & Translation', 'Translate2', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(2, 1, 'Writing & Translation', 'Translate3', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(1, 2, 'Writing & Translation', 'Translate4', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(1, 2, 'Writing & Translation', 'Translate5', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(25, 2, 'Digital Marketing', 'Marketing1', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(2, 1, 'Digital Marketing', 'Marketing2', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(1, 2, 'Digital Marketing', 'Marketing3', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(1, 2, 'Digital Marketing', 'Marketing4', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(1, 2, 'Digital Marketing', 'Marketing5', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(26, 2, 'Video & Animation', 'Animation1', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(2, 1, 'Video & Animation', 'Animation2', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(1, 2, 'Video & Animation', 'Animation3', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(1, 2, 'Video & Animation', 'Animation4', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(1, 2, 'Video & Animation', 'Animation5', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(25, 2, 'Music & Audio', 'Music1', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(2, 26, 'Music & Audio', 'Music2', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(2, 2, 'Music & Audio', 'Music3', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(1, 2, 'Music & Audio', 'Music4', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(1, 2, 'Music & Audio', 'Music5', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(1, 2, 'Programming & Tech', 'Programming1', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(1, 2, 'Programming & Tech', 'Programming2', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(1, 2, 'Programming & Tech', 'Programming3', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(1, 2, 'Programming & Tech', 'Programming4', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(2, 2, 'Programming & Tech', 'Programming5', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(1, 2, 'Business', 'Business1', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(1, 2, 'Business', 'Business2', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(1, 2, 'Business', 'Business3', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(1, 2, 'Business', 'Business4', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(1, 2, 'Business', 'Business5', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(1, 2, 'Lifestyle', 'Health1', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(1, 2, 'Lifestyle', 'Health2', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(2, 1, 'Lifestyle', 'Health3', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(1, 2, 'Lifestyle', 'Health4', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(1, 2, 'Lifestyle', 'Health5', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic');

INSERT INTO users VALUES ('Tanim', 'tanim@gmail.com', '123456', 'Tanim Tanim', '12345', '12345', NULL, 0, NULL)
INSERT INTO users VALUES ('Sanjid', 'sanjid@gmail.com', '123456', 'Sanjis Islam', '12555', '12555', NULL, 0, NULL)
INSERT INTO users VALUES ('Atiq', 'atik@mail.com', '123456', 'Atiq Atiq', '12345', '12345', NULL, 0, NULL)

INSERT INTO applications VALUES (1, 2)
INSERT INTO applications VALUES (1, 3)
INSERT INTO applications VALUES (2, 3)
INSERT INTO freelancer VALUES (1, 1000, 5, 5),(2, 2000, 4, 4.5),
(3, 20000, 10, 4.0)

insert into hirer values (1, 10000, 4, 5), (2, 30000, 4, 4.5), (3, 20000, 9, 4.3)

Select * from activeorder
Select * from applications
SELECT * FROM freelancer
SELECT * FROM users
SELECT * FROM hirer
SELECT * FROM job
SELECT * FROM jobfiles
SELECT * FROM jobimages

--DELETE table
delete from users
delete from hirer
delete from freelancer
delete from job
delete from jobfiles
delete from jobimages
delete from activeorder
delete from applications

--Drop tables
drop table users
drop table hirer
drop table freelancer
drop table job
drop table jobfiles
drop table jobimages
SELECT * FROM job 

