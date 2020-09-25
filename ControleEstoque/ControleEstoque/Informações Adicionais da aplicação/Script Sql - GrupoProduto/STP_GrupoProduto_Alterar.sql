Use Controle_estoque
go
Use controle_estoque
go
alter procedure STP_GrupoProduto_Alterar

@Id int,
@Nome varchar(255),
@Ativo bit

as 
update tab_grupo_produto set Nome = @Nome, Ativo = @Ativo, UpdateDtHr = GETDATE()  where Id = @Id

Select top 1 * from tab_grupo_produto order by UpdateDtHr desc


