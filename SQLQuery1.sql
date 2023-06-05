create database GitPsProjec
go

use GitPsProjec
go

create table Repositorios
(
	ID int primary key identity(1,1),
	Diretorio Varchar (255),
	Data_atualização date default GETDATE()
);
go


insert into Repositorios values ('abc', '2023/05/06')
insert into Repositorios(Diretorio) values ('oi')

select * from Repositorios;

update Repositorios
set Data_atualização = '2020-02-02'
where ID = 2



drop table Repositorios