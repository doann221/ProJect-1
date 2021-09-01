create database CatSale;

use CatSale;

create table Customer(
customer_id int auto_increment primary key,
customer_name varchar(100) not null,
customer_address varchar(200),
customer_Email varchar(200)
);
create table Users(
 user_id  int auto_increment primary key,
 user_name varchar(200),
 user_password varchar(200),
 user_Telephone varchar(11),
 user_email varchar(200)
 );
 
 create table Cat(
cat_id int auto_increment primary key,
constraint fk_Cat_BreedSpecies foreign key(breedSpecies_id) references BreedSpecies(breedSpecies_id),
cat_name varchar(200),
cat_price decimal,
cat_quantity int,
cat_age int,
cat_color varchar(20),
cat_weight int,
cat_longevely int
 );
 
 create table Invoice(
 invoice_no int auto_increment primary key,
 invoice_date datetime default now() not null,
 constraint fk_Invoice_users foreign key(user_id) references Users(user_id),
 constraint fk_Invoice_cat foreign key(cat_id) references Cat(cat_id),
 constraint fk_Invoice_Customer foreign key(customer_id) references Customer(customer_id),
 invoice_form varchar(200)
 );

 create table BreedSpecies(
 breedSpecies_id int auto_increment primary key,
 breedSpecies_name varchar(200),
 breedSpecies_breed varchar(200),
 breedSpecies_species varchar(200)
 );

 
 create table InvoiceDetail(
 invoice_no int,
 cat_id int,
 unit_price decimal,
 quantity int,
 constraint pk_Invoicedetail primary key(invoice_no, cat_id),
 constraint fk_InvoiceDetail_Invoice foreign key (invoice_no) references Invoice(invoice_no),
 constraint fk_InvoiceDetail_Cat foreign key (cat_id) references Cat(cat_id)
 );
 
 insert into Customer( customer_name, customer_address, customer_email) values
 ( 'Nguyen Van A', 'Ha Noi', 'a123@gmail.com'),
 ( 'Nguyen Thi B', 'Vinh Phuc', 'b234@gmail.com'),
 ( 'Tran Phuong C', 'Ha nam' , 'c345@gmail.com');
 select* from Customer;
 
 insert into Users( user_name, user_password, user_Telephone, user_email) values
 ( 'NguyenA', '12345asfds' , '12331232112' , 'a12314@gmail.com'),
 ( 'TranB', '12491230awe', '15623157891', 'asdf@gmail,com'),
 ( 'LeC', '23123adf', '15324896217', 'rwe@gmail.com');
 select *from Users;
 
 insert into Cat(cat_id, cat_name, cat_price, cat_quantity, cat_age, cat_color, cat_weight, cat_longevely) values
 ( 'meo mun', 2000000 , 100, 1 , 'black' , 2, 7),
 ( 'Tom' , 3000000, 50, 2, 'Darkblue', 3, 7),
 ( 'doraemon', 4000000, 20 , 3, 'white , blue', 5, 10);
 select * from Cat;

 insert into Invoice(invoice_no, invoice_form) values
 (1,'FASL' ),
 (2,'1ASA'),
 (3,'1ADF');
 select * from Invoice;
 
 insert into BreedSpecies(breedSpecies_name , breedSpecies_breed, breedSpecies_species) values
 ('ads', 'male' , 'tai dai'),
 ('adsf', 'female', 'chân dài tai ngắn'),
 ('daff', 'male' , 'tai dài lông dài');
 select * from BreedSpecies;
 insert into InvoiceDetail( invoice_no, cat_id,  unit_price, quantity) values
 (1,2,3.3,4), (2,4,1243,5), (3,5, 312,6);
 select * from InvoiceDetail;
 