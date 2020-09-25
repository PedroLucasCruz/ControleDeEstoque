Use Controle_estoque
go
alter procedure STP_GrupoProduto_Salvar  

@Nome varchar(70),  
@Ativo bit,  
@Deletado bit = 0
 
as   
  
insert into tab_grupo_produto values(@Nome, @Ativo, @Deletado, GETDATE())  
 
select top 1  * from tab_grupo_produto  
where Id = @@IDENTITY  
and Deletado = 0  

