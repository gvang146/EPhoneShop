Use phone;

Create table products (
serialNum int not null primary key, modelNum varchar(100), name varchar(100), 
color varchar(100), processor varchar(100), price int, brand varchar(100), speed varchar(100));

Insert into products values ('1001', 'V101', 'thunderbolt', 'silver', 'level 5', '1299', 'singsung', '5g');
Insert into products values ('1002', 'V102', 'thunderbolt', 'gold', 'level 4', '999', 'singsung', '4g');
Insert into products values ('2201', 'M1', 'greatEscape', 'gold', 'level 5', '1499', 'uphone', '5g');
Insert into products values ('2202', 'M2', 'explorer', 'silver', 'level 4', '1199', 'uphone', '5g');
Insert into products values ('333', 'kick4', 'glider', 'blue', 'level 3', '499', 'foogle', '5g');
Insert into products values ('334', 'kick5', 'paperPlane', 'red', 'level 3', '399', 'foogle', '5g');



