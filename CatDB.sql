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
-- drop table Cat;
insert into Staffs( user_name, user_pass, role) values
( 'doann221', '7d669799ea755df1aa4dd7b92e443013', 1);
-- pass: Catsale 123
select * from Staffs;


insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Anh lông dài', '3 tháng', 'trắng', '3', '14 năm', 7, '4000000'),
('Mèo Xiêm Thái', '4 tháng', 'xám hải cẩu' , 5 , '15 năm', 6 , 6000000),
('Mèo Ba Tư Truyền Thống', '4 tháng ', 'trắng', 7, '10-17 năm', 5, 10000000),
 ('Mèo Tai Cụp Scottish Fold' , '13 tháng', 'lông  ngắn xám', 5, '15 năm', 11 , 12000000),
('Mèo Ba Tư lông ngắn','15 tháng', 'tam thể', 4, '20 năm',3,20000000),
('Mèo Ba tư Himalaya', '16 tháng', 'nâu đốm', 3, '20 năm', 5, 15000000),
('Mèo Chichilla', '17 tháng',  'silver' , 5, '20 năm' , 7, 10000000),
('Mèo Abyssinian', '7 tháng', 'nâu vàng', 5, '9-15 năm', 6, 25000000), 
('Mèo Aegan', '5 tháng' , 'đen-trắng', 4 , '9-12 năm', 7, 11500000),
('Mèo Bali', '6  tháng' , 'socola', 4, '>15 năm', 6, 15000000),
(' Mèo Birman', '8 tháng', 'trắng điểm socola', 5 , '>15 năm', 5 , 21000000),
(' Mèo Bombay', '9 tháng', 'đen', 4, '12 - 16 năm', 10, 10000000),
('Mèo Anh lông ngắn', '8 tháng', 'xanh lam', 5, '12 -17 năm', 5 , 12000000),
(' Mèo Burmilla', ' 8 tháng', 'carammel', 5 , '10-15 năm', 3, 10000000),
('Mèo Chartreux', '7 tháng', 'xám bạc', 4.5, '12-15 năm', 4, 12000000);

select * from Cat;



 
