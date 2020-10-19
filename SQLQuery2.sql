-- TPH (Table Per Hierarchy)
create table TPH_Customers (
	Id int primary key identity,
	Discriminator char(2) not null,
	Name nvarchar(50) not null,
	BusinessName nvarchar(50),
	BusinessAddress nvarchar(50),
	FooBarName nvarchar(50),
	FooBarAddress nvarchar(50),
);

-- TPT (Table Per Type) (EF Core 5.0)
create table TPT_Customers (
	Id int primary key identity,
	Name nvarchar(50) not null,
);
create table TPT_BCustomers (
	Id int primary key,
	BusinessName nvarchar(50) not null,
	BusinessAddress nvarchar(50) not null,
);
create table TPT_FCustomers (
	Id int primary key,
	FooBarName nvarchar(50) not null,
	FooBarAddress nvarchar(50) not null,
);

-- TPC (Table Per Concrete Type) (not EF Core ATM)
create table TPC_BCustomers (
	Id int primary key identity(1,10), --sequence
	Name nvarchar(50) not null,
	BusinessName nvarchar(50) not null,
	BusinessAddress nvarchar(50) not null,
);
create table TPC_FCustomers (
	Id int primary key identity(2,10), --sequence
	Name nvarchar(50) not null,
	FooBarName nvarchar(50) not null,
	FooBarAddress nvarchar(50) not null,
);