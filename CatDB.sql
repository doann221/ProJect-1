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
insert into Staffs( user_name, user_pass, role) values
( 'anphuong123456', 'd9fbdbecb9ebdf50896ab4dfbe161bd4', 1);
-- pass: Cat1234v
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
insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Cymric', '13 tháng', 'tam thể', '3', '16 năm', '10', '10000000'),
('Mèo Devon Rex', '14 tháng', 'xanh lam', '3', '10 năm', '8', '8000000'),
('Mèo Mau Ai Cập', '13 tháng', 'bạc xanh', '4', '12 năm', '5', '14000000'),
('Mèo Exotic lông ngắn', '15 tháng', 'bạc', '4', '20 năm', '8', '20000000'),
('Mèo Havana Brown', '17 tháng', 'xám hồng', '5', '18 năm', '4', '18000000'),
('Mèo Himalayan', '18 tháng', 'xanh da trời', '8', '19 năm', '8', '10000000'),
('Mèo Nhật đuôi cộc', '10 tháng', 'xanh lam', '4', '15 năm', '10', '12000000'),
('Mèo Java', '15 tháng', 'trắng', '5', '12 năm', '6', '18000000'),
('Mèo Korat', '12 tháng', 'xám xanh', '5', '10 năm', '7', '14000000'),
('Mèo Kurilian đuôi cộc', '14 tháng', 'nâu trắng', '6', '14 năm', '9', '15000000'),
('Mèo Laperm', '14 tháng', 'lông rùa', '5', '16 năm', '4', '22000000'),
('Mèo Li Hua', '14 tháng', 'đen vằn', '7', '15 năm', '5', '17000000'),
('Mèo Pixi Bob', '13 tháng', 'đốm', '10', '14 năm', '7', '15000000'),
('Mèo Ragamuffin', '15 tháng', 'khói trắng', '10', '13 năm', '6', '20000000'),
('Mèo Ragdoll', '14 tháng', 'xanh lam', '10', '20 năm', '8', '25000000');
select * from Cat;



 
