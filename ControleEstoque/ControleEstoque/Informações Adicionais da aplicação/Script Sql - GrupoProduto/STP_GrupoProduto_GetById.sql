Use Controle_estoque
go
alter procedure STP_GrupoProduto_GetById  
  
@Id int = 0  
  
as  
  
select * from tab_grupo_produto tab where tab.Id = @Id and Deletado = 0