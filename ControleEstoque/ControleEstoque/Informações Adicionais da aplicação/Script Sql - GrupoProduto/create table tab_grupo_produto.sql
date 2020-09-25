create table tab_grupo_produto
(
Id int identity(1,1) not null,
Nome nvarchar(100),
Ativo bit not null,
Deletado bit, 
UpdateDtHr dateTime,
CONSTRAINT PK_tab_grupo_produto_TransactionID PRIMARY KEY CLUSTERED (Id)
)



