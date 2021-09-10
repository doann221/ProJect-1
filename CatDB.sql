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



    insert into Staffs( user_name, user_pass, role) values
    ( 'doann221', '44a86e166293f65a7a692150234cdef0', 1);
    
select * from Staffs;
