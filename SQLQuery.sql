
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
  id int  PRIMARY KEY NOT NULL,
  posted_by int NOT NULL,
  accepted_by int DEFAULT NULL,
  category varchar(30) NOT NULL,
  name varchar(30) NOT NULL,
  salary int NOT NULL,
  duration datetime NOT NULL,
  details text NOT NULL,
  negotiable int NOT NULL,
  preferred_skills varchar(30) NOT NULL
)

INSERT INTO job (id, posted_by, accepted_by, category, name, salary, duration, details, negotiable, preferred_skills) VALUES
(41, 25, 2, 'Graphics & Design', 'Illustration1', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(42, 2, 25, 'Graphics & Design', 'Illustration2', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(43, 1, 2, 'Graphics & Design', 'Illustration3', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(44, 1, NULL, 'Graphics & Design', 'Illustration4', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(45, 1, NULL, 'Graphics & Design', 'Illustration5', 3000, '2021-12-12 02:30:01', 'illustration is very nice', 1, 'Design'),
(46, 25, NULL, 'Writing & Translation', 'Translate1', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(47, 26, 2, 'Writing & Translation', 'Translate2', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(48, 2, 1, 'Writing & Translation', 'Translate3', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(49, 1, 2, 'Writing & Translation', 'Translate4', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(50, 1, 2, 'Writing & Translation', 'Translate5', 4000, '2021-12-12 02:30:01', 'translation is very nice', 1, 'Multilingual'),
(51, 25, 2, 'Digital Marketing', 'Marketing1', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(52, 2, 1, 'Digital Marketing', 'Marketing2', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(53, 1, 2, 'Digital Marketing', 'Marketing3', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(54, 1, 2, 'Digital Marketing', 'Marketing4', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(55, 1, 2, 'Digital Marketing', 'Marketing5', 3000, '2021-12-12 02:30:01', 'marketing is very nice', 1, 'Business'),
(56, 26, 2, 'Video & Animation', 'Animation1', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(57, 2, 1, 'Video & Animation', 'Animation2', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(58, 1, 2, 'Video & Animation', 'Animation3', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(59, 1, 2, 'Video & Animation', 'Animation4', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(60, 1, 2, 'Video & Animation', 'Animation5', 5000, '2021-12-12 02:30:01', 'animation is very nice', 1, 'Animation'),
(61, 25, 2, 'Music & Audio', 'Music1', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(62, 2, 26, 'Music & Audio', 'Music2', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(63, 2, 2, 'Music & Audio', 'Music3', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(64, 1, 2, 'Music & Audio', 'Music4', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(65, 1, 2, 'Music & Audio', 'Music5', 6000, '2021-12-12 02:30:01', 'audio is very nice', 1, 'Music'),
(66, 1, 2, 'Programming & Tech', 'Programming1', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(67, 1, 2, 'Programming & Tech', 'Programming2', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(68, 1, 2, 'Programming & Tech', 'Programming3', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(69, 1, 2, 'Programming & Tech', 'Programming4', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(70, 2, 2, 'Programming & Tech', 'Programming5', 7000, '2021-12-12 02:30:01', 'programming is very nice', 1, 'Tech'),
(71, 1, 2, 'Business', 'Business1', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(72, 1, 2, 'Business', 'Business2', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(73, 1, 2, 'Business', 'Business3', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(74, 1, 2, 'Business', 'Business4', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(75, 1, 2, 'Business', 'Business5', 8000, '2021-12-12 02:30:01', 'business is very nice', 1, 'Business'),
(76, 1, 2, 'Lifestyle', 'Health1', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(77, 1, 2, 'Lifestyle', 'Health2', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(78, 2, 1, 'Lifestyle', 'Health3', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(79, 1, 2, 'Lifestyle', 'Health4', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic'),
(80, 1, 2, 'Lifestyle', 'Health5', 2000, '2021-12-12 02:30:01', 'prevention is better than cure', 1, 'Medic');


SELECT * FROM users
SELECT * FROM freelancer
SELECT * FROM hirer
SELECT * FROM job
SELECT * FROM users where mail = 'a@gmail.com';
INSERT INTO freelancer(id) values(100) 