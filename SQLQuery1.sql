create table List
(
	ListId int primary key identity (1,1)not null, 
	Name varchar(100) not null,
	CreatedDate datetime not null,

);
create table Card
(
	CardId int primary key identity (1,1)not null,
	ListId int not null foreign key references Lists (ListId),
	Name varchar(50) not null,
	CreatedDate datetime not null,
	Text varchar(100) not null,

);