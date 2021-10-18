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
cat_weight varchar(10),
cat_longevety varchar(20),
cat_quantity int,
cat_price decimal (20)
);

create table Customers(
customer_id int auto_increment primary key not null,
customer_name varchar(50),
customer_phone varchar(11),
customer_address varchar(50)
);

create table Invoice(
invoice_id int auto_increment primary key not null,
invoice_date datetime default now(),
customer_id int,
staff_id int,
constraint fk_customer_name foreign key(customer_id) references Customers(customer_id),
constraint fk_staff_name foreign key(staff_id) references Staffs(staff_id)
);
create table InvoiceDetails(
invoice_id int not null,
cat_id int not null,
unit_price decimal(20,2) not null,
quantity int not null,
constraint pk_InvoiceDetails primary key(invoice_id, cat_id),
constraint fk_InvoiceDetails_Ivoice foreign key(invoice_id) references Invoice(invoice_id),
constraint fk_InvoiceDetails_Cat foreign key(cat_id) references Cat(cat_id)
);
 -- drop table Cat;
insert into Staffs( user_name, user_pass) values
( 'doann221', '7d669799ea755df1aa4dd7b92e443013');
-- pass: Catsale123
insert into Staffs( user_name, user_pass) values
( 'anphuong123456', 'd9fbdbecb9ebdf50896ab4dfbe161bd4');
-- pass: Cat1234v
select * from Staffs;


insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
(' British Longhair Cat', '3 month', 'white', '3 kg', '14 year', '7', '4000000'),
(' Siamese Cat', '4 month', 'gray seal' , '5 kg' , '15 year', '6', 6000000),
(' Persian Cat Traditional', '4 month ', 'white', '7 kg', '10-17 year', '5', 10000000),
(' Fold-Eared Cat Scottish Fold' , '13 month', 'gray short hair', '5 kg', '15 year', '11', 12000000),
(' Shorthair Persian Cat', '15 month', 'trinity', '4 kg', '20 year', '3', 20000000),
(' Persian Cat Himalaya', '16 month', 'spotted brown', '3 kg', '20 year', '5', 15000000),
(' Chichilla', '17 month', 'silver' , '5 kg', '20 year' , '7', 10000000),
(' Abyssinian', '7 month', 'golden brown', '5 kg', '9-15 year', '6', 25000000), 
(' Aegan', '5 month' , 'black and white', '4 kg' , '9-12 year', '7', 11500000),
(' Bali', '6 month' , 'socola', '4 kg', '>15 year', '6', 15000000),
(' Birman', '8 month', 'white point socola', '5 kg' , '>15 year', '5', 21000000),
(' Bombay', '9 month', 'black', '4 kg', '12 - 16 year', '10', 10000000),
(' British Shorthair Cat', '8 month', 'blue', '5 kg', '12 -17 year', '5', 12000000),
(' Burmilla', '8 month', 'carammel', '5 kg' , '10-15 year', '3', 10000000),
(' Chartreux', '7 month', 'silver gray', '4.5 kg', '12-15 year', '4', 12000000);
insert into Cat(cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price) values
(' Cymric', '13 month', 'trinity', '3 kg', '16 year', '10', '10000000'),
(' Devon Rex', '14 month', 'blue', '3 kg', '10 year', '8', '8000000'),
(' Egyptian Mau Cat', '13 month', 'green silver', '4 kg', '12 year', '5', '14000000'),
(' Shorthair Exotic Cat', '15 month', 'silver', '4 kg', '20 year', '8', '20000000'),
(' Havana Brown', '17 month', 'pink gray', '5 kg', '18 year', '4', '18000000'),
(' Himalayan', '18 month', 'sky blue', '8 kg', '19 year', '8', '10000000'),
(' Bobtail Japanese Cat', '10 month', 'blue', '4 kg', '15 year', '10', '12000000'),
(' Java', '15 month', 'white', '5 kg', '12 year', '6', '18000000'),
(' Korat', '12 month', 'blue gray', '5 kg', '10 year', '7', '14000000'),
(' Bobtail Kurilian Cat', '14 month', 'white brown', '6 kg', '14 year', '9', '15000000'),
(' Laperm', '14 month', 'turtle hair', '5 kg', '16 year', '4', '22000000'),
(' Li Hua', '14 month', 'striped black', '7 kg', '15 year', '5', '17000000'),
(' Pixi Bob', '13 month', 'spot', '10 kg', '14 year', '7', '15000000'),
(' Ragamuffin', '15 month', 'white smoke', '10 kg', '13 year', '6', '20000000'),
(' Ragdoll', '14 month', 'blue', '10 kg ', '20 year', '8', '25000000');
select * from Cat;

insert into Customers(customer_name, customer_phone, customer_address) values
('Đoàn','01234567890', 'Hà Nội'),
('Phương','12312311', 'Thanh Hóa'),
('Thắng', '4112312', 'Hưng Yên'),
('Nhung', '34312312','Việt Trì');
select * from customers;

select cat_id, cat_name, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity, cat_price
                        from Cat where cat_id=1;
select cat_id, cat_name, cat_price, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity from Cat;
select cat_id, cat_name, cat_price, cat_age, cat_color, cat_weight, cat_longevety, cat_quantity from Cat
                                where cat_name like concat('%',@catName,'%');
delimiter $$
create trigger tg_before_insert before insert
	on Cat for each row
    begin
		if new.cat_quantity < 0 then
            signal sqlstate '45001' set message_text = 'tg_before_insert: amount must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create trigger tg_CheckQuantity
	before update on Cat
	for each row
	begin
		if new.cat_quantity < 0 then
            signal sqlstate '45001' set message_text = 'tg_CheckQuantity quantity must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create procedure sp_createCustomer(IN customerName varchar(100), IN customerAddress varchar(200),In customerPhone varchar(11), OUT customerId int)
begin
	insert into Customers(customer_name, customer_address) values (customerName, customerAddress); 
    select max(customer_id) into customerId from Customers;
end $$
delimiter ;

select customer_id from Customers order by customer_id desc limit 1;
SELECT 
    cat_price
FROM
    Cat
WHERE
    cat_id = 1;
