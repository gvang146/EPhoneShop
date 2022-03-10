drop table if exists order_details;
drop table if exists orders;
drop table if exists carts;
drop table if exists product;
drop table if exists user_address;
drop table if exists users;

create table users
(
    Id           varchar(36)  not null primary key,
    LastName     varchar(100) not null,
    FirstName    varchar(100) not null,
    Email        varchar(100) not null unique,
    PasswordHash varchar(100) not null,
    PasswordSalt varchar(36)  not null
);

create table user_address
(
    Id      varchar(36) primary key,
    UserId  varchar(36),
    address varchar(256) not null,
    city    varchar(120) not null,
    state   varchar(2),
    zip     varchar(25),
    constraint fk_custaddr_custid
        foreign key (UserId)
            references users (Id)
);

create table product
(
    Id          varchar(36)  not null primary key,
    ProductName varchar(100) not null,
    ProductDesc varchar(2000),
    Brand       varchar(100),
    Color       varchar(100),
    Processors  varchar(100),
    Speed       varchar(100),
    Price       double       not null
);

create table carts
(
    Id        varchar(36) primary key,
    UserId    varchar(36) not null,
    ProductId varchar(36) not null,
    Quantity  int         not null,
    constraint fk_custcart_custid
        foreign key (UserId)
            references users (Id),
    constraint fk_custcart_prodid
        foreign key (ProductId)
            references product (id)
);

create table orders
(
    Id                 varchar(36) primary key,
    UserId             varchar(36) not null,
    ShippingAddressId  varchar(36) not null,
    BillingAddressId   varchar(36) not null,
    Status             varchar(25) not null,
    OrderDate          datetime    not null,
    PaymentDate        datetime    not null,
    ConfirmationNumber varchar(10),
    TotalCost          double      not null,
    constraint fk_order_custid
        foreign key (UserId)
            references users (Id),
    constraint fk_order_shipping_addr
        foreign key (ShippingAddressId)
            references user_address (Id),
    constraint fk_order_billing_addr
        foreign key (BillingAddressId)
            references user_address (Id)
);

create table order_details
(
    Id        varchar(36) primary key,
    OrderId   varchar(36) not null,
    ProductId varchar(36) not null,
    Status    varchar(25) not null,
    Price     double      not null,
    Quantity  int         not null,
    ShipDate  datetime
);


insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'YouNeedPhone', 'YouPhone', 'White', 'Level 10 Processor', '5G', 899.45);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'ByeBuyPhone', 'DamSun', 'Black', 'Level 4 Processor', '4G', 399.32);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'UniversGateTrill', 'SoldyerSystem', 'White', 'Ravi Processor', '5G', 999.37);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'CellStarullar', 'Notkia', 'White', 'Level 7 Processor', '4G', 799.99);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'Portfold', 'Enginerola', 'White', 'Level 3 Processor', '5G', 799.99);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'Thriftbook', 'Froogle', 'Silver', 'Level 1 Processor', '4G', 199.72);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'WorldGate', 'SoldyerSystem', 'Black', 'Level 7 Processor', '3G', 699.57);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'YouneedPro', 'YouPhone', 'Silver', 'Level Ravi Processor', '5G', 999.34);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'InterPhonement', 'Enginerola', 'Silver', 'Level 4 Processor', '5G', 599.67);
insert into product(Id, ProductName, Brand, Color, Processors, Speed, Price)
values (UUID(), 'StaticMatic', 'JankTech', 'White', 'Level 3 Processor', '3G', 299.23);

