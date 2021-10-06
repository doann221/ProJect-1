drop database if exists CatDB;

create database CatDB;

use CatDB;

create table Staffs(
	staff_id int auto_increment primary key,
    user_name varchar(100) not null unique,
    user_pass varchar(200) not null,
    telephone varchar(20),
    email varchar(100) unique
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

create table Customers(
customer_id int auto_increment primary key not null,
customer_name varchar(50),
customer_phone varchar(11),
customer_address varchar(20)
);

create table Invoice(
invoice_no int auto_increment primary key not null,
invoice_date datetime default now(),
customer_id int,
staff_id int,
constraint fk_customer_name foreign key(customer_id) references Customers(customer_id),
constraint fk_staff_name foreign key(staff_id) references Staffs(staff_id)
);
-- drop table Cat;
insert into Staffs( user_name, user_pass) values
( 'doann221', '7d669799ea755df1aa4dd7b92e443013');
-- pass: Catsale 123
insert into Staffs( user_name, user_pass) values
( 'anphuong123456', 'd9fbdbecb9ebdf50896ab4dfbe161bd4');
-- pass: Cat1234v
select * from Staffs;


insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Anh lông dài', '3 month', 'trắng', '3', '14 year', 7, '4000000'),
('Mèo Xiêm Thái', '4 month', 'xám hải cẩu' , 5 , '15 year', 6 , 6000000),
('Mèo Ba Tư Truyền Thống', '4 month ', 'trắng', 7, '10-17 year', 5, 10000000),
 ('Mèo Tai Cụp Scottish Fold' , '13 month', 'lông  ngắn xám', 5, '15 year', 11 , 12000000),
('Mèo Ba Tư lông ngắn','15 month', 'tam thể', 4, '20 year',3,20000000),
('Mèo Ba tư Himalaya', '16 month', 'nâu đốm', 3, '20 year', 5, 15000000),
('Mèo Chichilla', '17 month',  'silver' , 5, '20 year' , 7, 10000000),
('Mèo Abyssinian', '7 month', 'nâu vàng', 5, '9-15 year', 6, 25000000), 
('Mèo Aegan', '5 month' , 'đen-trắng', 4 , '9-12 year', 7, 11500000),
('Mèo Bali', '6  month' , 'socola', 4, '>15 year', 6, 15000000),
(' Mèo Birman', '8 month', 'trắng điểm socola', 5 , '>15 year', 5 , 21000000),
(' Mèo Bombay', '9 month', 'đen', 4, '12 - 16 year', 10, 10000000),
('Mèo Anh lông ngắn', '8 month', 'xanh lam', 5, '12 -17 year', 5 , 12000000),
(' Mèo Burmilla', ' 8 month', 'carammel', 5 , '10-15 year', 3, 10000000),
('Mèo Chartreux', '7 month', 'xám bạc', 4.5, '12-15 year', 4, 12000000);
insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
('Mèo Cymric', '13 month', 'tam thể', '3', '16 year', '10', '10000000'),
('Mèo Devon Rex', '14 month', 'xanh lam', '3', '10 year', '8', '8000000'),
('Mèo Mau Ai Cập', '13 month', 'bạc xanh', '4', '12 year', '5', '14000000'),
('Mèo Exotic lông ngắn', '15 month', 'bạc', '4', '20 year', '8', '20000000'),
('Mèo Havana Brown', '17 month', 'xám hồng', '5', '18 year', '4', '18000000'),
('Mèo Himalayan', '18 month', 'xanh da trời', '8', '19 year', '8', '10000000'),
('Mèo Nhật đuôi cộc', '10 month', 'xanh lam', '4', '15 year', '10', '12000000'),
('Mèo Java', '15 month', 'trắng', '5', '12 year', '6', '18000000'),
('Mèo Korat', '12 month', 'xám xanh', '5', '10 year', '7', '14000000'),
('Mèo Kurilian đuôi cộc', '14 month', 'nâu trắng', '6', '14 year', '9', '15000000'),
('Mèo Laperm', '14 month', 'lông rùa', '5', '16 year', '4', '22000000'),
('Mèo Li Hua', '14 month', 'đen vằn', '7', '15 year', '5', '17000000'),
('Mèo Pixi Bob', '13 month', 'đốm', '10', '14 year', '7', '15000000'),
('Mèo Ragamuffin', '15 month', 'khói trắng', '10', '13 year', '6', '20000000'),
('Mèo Ragdoll', '14 month', 'xanh lam', '10', '20 year', '8', '25000000');
select * from Cat;



 
