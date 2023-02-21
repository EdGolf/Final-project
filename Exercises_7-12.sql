## Create schema `Exercises_7-12`;
## drop schema `Exercises_7-12`;
use `Exercises_7-12`;

## Создание таблицы
create table cat (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday DATE
);


create table dog (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday DATE
);


create table hamster (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday DATE
);



create table horse (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	liftWeight INT,
    Name VARCHAR(45),
    Command VARCHAR(45),
	Birthday DATE
);


create table camel (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	liftWeight INT,
    Name VARCHAR(45),
    Command VARCHAR(45),
	Birthday DATE
);


create table donkey (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	liftWeight INT,
    Name VARCHAR(45),
    Command VARCHAR(45),
	Birthday DATE
);

## Создание таблицы выше
create table pet (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday DATE
);


create table packAnimal (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    liftWeight INT,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday DATE
);

## Создание общей таблицы
create table humanFriend(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Command VARCHAR(45),
    Birthday Date
    );
    
## Заполнения данными в таблицу
    
    insert into cat (Name, Command, Birthday) values
    ('cat1', 'Спать', '2022'),
    ('cat2', 'Спать', '2019'),
	('cat3', 'Спать', '2021'),
    ('cat4', 'Спать', '2020');
    
    select * from cat;

    insert into dog (Name, Command, Birthday) values
    ('dog1', 'Лежать', '2022'),
    ('dog2', 'Лежать', '2015'),
	('dog3', 'Лежать', '2021'),
    ('dog4', 'Лежать', '2023');
	
    select * from dog;
 
	insert into hamster (Name, Command, Birthday) values
    ('hamster1', 'Бежать', '2022'),
    ('hamster2', 'Бежать', '2016'),
	('hamster3', 'Бежать', '2021'),
    ('hamster4', 'Бежать', '2023');
	
    select * from hamster;
     
	insert into camel (camelName, camelCommand, camelLiftWeight, camelBirthday) values
    ('camel1', 'Поднять', 100, '2023'),
    ('camel2', 'Поднять', 100, '2018'),
	('camel3', 'Поднять', 100, '2022'),
    ('camel4', 'Поднять', 150, '2021');
	
    select * from camel;
     
	insert into horse (Name, Command, liftWeight, Birthday) values
    ('horse1', 'Галоп', 150, '2022'),
    ('horse2', 'Галоп', 150, '2019'),
	('horse3', 'Галоп', 200, '2021'),
    ('horse4', 'Галоп', 200, '2023');
	
    select * from horse;    
     
	insert into donkey (Name, Command, liftWeight, Birthday) values
    ('donkey1', 'Жевать', 150, '2021'),
    ('donkey2', 'Жевать', 100, '2019'),
	('donkey3', 'Жевать', 120, '2023'),
    ('donkey4', 'Жевать', 100, '2020');
	
    select * from donkey;  	
 
 ## Удаление таблицы верблюдов
 delete from camel where id > 0;
 select * from camel;
 
## Объединение таблицы лошадей и ослов в одну таблицу.
create table packAnimalNew (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY)
select  Name, 
        Command, 
        Birthday
from horse union 
select  Name, 
        Command, 
        Birthday
from donkey;

select * from packAnimalNew;

## Создание таблицы, в которой все животные в возрасте от 1 до 3 лет.
INSERT into pet (Name, Command, Birthday)
select  Name, 
        Command, 
        Birthday
from cat union 
select  Name, 
        Command, 
        Birthday
from dog union
select  Name, 
        Command, 
        Birthday
from hamster;
select * from pet;

INSERT into humanFriend (Name, Command, Birthday)
select  Name, 
        Command, 
        Birthday
from pet union 
select  Name, 
        Command, 
        Birthday
from packAnimalNew;
select * from humanFriend;

create table youngAnimals (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY)
select Name, 
        Command, 
        Birthday,
        Round((year(current_date()) - year(Birthday)) + (month(current_date() - month(Birthday)))/10, 2) as age
from humanFriend
where Round((year(current_date()) - year(Birthday)) + (month(current_date() - month(Birthday)))/10, 2) > 1 
	and Round((year(current_date()) - year(Birthday)) + (month(current_date() - month(Birthday)))/10, 2) < 3;
select * from youngAnimals;

## Объединить все таблицы в одну, при этом сохраняя поля, указывающие на прошлую принадлежность к старым таблицам.

create table newhumanFriend (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY)
select  Name, 
        Command,
        Birthday,
        'cat' as oldTable
from cat union 
select  Name, 
        Command, 
        Birthday,
        'dog' as oldTable
from dog union
select  Name, 
        Command, 
        Birthday,
        'hamster' as oldTable
from hamster union 
select  Name, 
        Command, 
        Birthday,
        'horse' as oldTable
from horse union 
select  Name, 
        Command, 
        Birthday,
        'donkey' as oldTable
from donkey;

select * from newhumanFriend;