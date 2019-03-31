create database CarHolding;
go
use CarHolding;
go
create table BodyType
(
	Id int primary key identity(1,1),
	BodyType varchar(45) not null
);
go
create table DriveType
(
	Id int primary key identity(1,1),
	DriveType varchar(45)
);
go
create table TransmissionType
(
	Id int primary key identity(1,1),
	TransmissionType varchar(45)
);
go
create table Car
(
	Id int primary key identity(1,1),
	Title varchar(45) not null,
	Volume float not null,
	Color varchar(45) not null,
	[Year] int not null,
	Price int not null,
	ImagePath varchar(45) not null,
	TransmissionTypeId int not null,
	DriveTypeId int not null,
	BodyTypeId int not null,

	constraint FK_CarTransmissionType foreign key (TransmissionTypeId) references TransmissionType(Id),
	constraint FK_CarDriveType foreign key (DriveTypeId) references DriveType(Id),
	constraint FK_CarBodyType foreign key (BodyTypeId) references BodyType(Id)
);
go
create table ProgramConfig
(
	Id int primary key identity(1,1),
	LightTheme bit not null,
	[Language] varchar(20) not null
);
go
insert into TransmissionType(TransmissionType)
values	('Automatic'), 
		('Manual')
go
insert into BodyType(BodyType)
values	('Sedan'), 
		('Wagon'),
		('Coupe'),
		('Hatchback'),
		('Pickup'),
		('Van'),
		('Crossover'),
		('Sport')
go
insert into DriveType(DriveType)
values	('FrontWheel'),
		('BackWheel'),
		('Full')
go
insert into Car(Title, Volume, Color, [Year], Price, ImagePath, TransmissionTypeId, DriveTypeId, BodyTypeId)
values	('Honda Accord', 2.4, 'Black', 2011, 24000, '..\Image\hondaAccord.jpg', 2, 1, 1),
		('Honda HR-V', 3.2, 'DarkRed', 2018, 34000, '..\Image\hondaHRV.jpg', 1, 3, 7),
		('Honda Civic', 2.0, 'Green', 2017, 27000, '..\Image\hondaCivic.jpg', 2, 1, 3)
go
insert into ProgramConfig(LightTheme, [Language])
values	(1, 'ENG')