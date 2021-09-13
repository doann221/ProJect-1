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
cat_age varchar(50),
cat_color varchar(100),
cat_weight int,
cat_longevety varchar(20),
cat_quantity int,
cat_price decimal
);
-- drop table Staffs;
insert into Staffs( user_name, user_pass, role) values
( 'doann221', '7d669799ea755df1aa4dd7b92e443013', 1);
-- pass: Catsale 123
select * from Staffs;


insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Anh lông dài', '3 tháng', 'trắng', '3', '14 năm', '20', '4000000'),
('Mèo Xiêm Thái', '4 tháng', 'xám hải cẩu' , 5 , '15 năm', 20 , 6000000),
('Mèo Ba Tư Truyền Thống', '4 tháng ', 'trắng', 7, '10-17 năm', 20, 10000000),
 ('Mèo Tai Cụp Scottish Fold' , '13 tháng', 'lông  ngắn xám', 5, '15 năm', 30 , 12000000);

insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Ba Tư lông ngắn','15 tháng', 'tam thể', 4, '20 năm', 25, 20000000),
('Mèo Ba tư Himalaya', '16 tháng', 'nâu đốm', 3, '20 năm', 20, 15000000),
('Mèo Chichilla', '17 tháng',  'silver' , 5, '20 năm' , 15, 10000000),
('Giống Mèo Abyssinian', '7 tháng', 'nâu vàng', 5, '9-15 năm', 10, 25000000);   
select * from Cat;


 
