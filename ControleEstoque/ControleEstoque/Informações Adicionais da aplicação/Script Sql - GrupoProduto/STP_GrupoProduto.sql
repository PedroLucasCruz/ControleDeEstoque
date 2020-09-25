use controle_estoque

go



alter proc STP_GrupoProduto_Todos

as 
select * from tab_grupo_produto tab where tab.Deletado = 0 






