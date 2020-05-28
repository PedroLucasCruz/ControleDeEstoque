create database controle_estoque
go
begin tran
Use [controle_estoque]
go
create table Usuario(
id int identity(1,1) not null,
Login nvarchar (50),  
Senha nvarchar (10)

PRIMARY KEY CLUSTERED
(
[ID] ASC
)
WITH (PAD_INDEX = OFF,
STATISTICS_NORECOMPUTE = OFF,
IGNORE_DUP_KEY = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [AK_Usuario] UNIQUE NONCLUSTERED 
(
[ID] ASC
)
WITH
(
PAD_INDEX = OFF,
STATISTICS_NORECOMPUTE = OFF,
IGNORE_DUP_KEY = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY]
) ON [PRIMARY]
GO

--drop table Usuario

--select * from Usuario

--insert into Usuario (Login, Senha) values ('Davi','123') 

--select * from Usuario where login = 'Davi' and Senha = '123'