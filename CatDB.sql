drop database if exists CatDB;

create database CatDB;

use CatDB;


create table Staffs(
	staff_id int auto_increment primary key,
    user_name varchar(100) not null unique,
    user_pass varchar(200) not null,
    telephone varchar(20),
    email varchar(100) unique,
    role int not null default 1
);

create user if not exists 'vtca'@'localhost' identified by 'vtcacademy';
grant all on CatDB.* to 'vtca'@'localhost';
create table Cat(
cat_id int auto_increment primary key not null,
cat_name varchar(200) not null unique,
cat_age int,
cat_color varchar(100),
cat_weight int,
cat_longevety int,
cat_quantity int,
cat_price decimal
);
drop table Cat;
insert into Staffs( user_name, user_pass, role) values
( 'doann221', '44a86e166293f65a7a692150234cdef0', 1);
select * from Staffs;

insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Anh lông dài', '3', 'trắng', '3', '14', '20', '4000000');
select * from Cat;
