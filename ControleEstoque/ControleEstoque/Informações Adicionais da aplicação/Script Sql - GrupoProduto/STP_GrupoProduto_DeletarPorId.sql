--sp_helptext STP_GrupoProduto_DeletarPorId


--Essa procedure seta como 0 o registro para representar que está deletado(false)
--Na mesma execução seta na tabela o horario da atualização 
--no select seguinte retorna o ultimo registro alterado com base na data e horario setado no update anterior
alter proc STP_GrupoProduto_DeletarPorId  
  
@Id int = 0  
  
as  
begin tran  
update tab_grupo_produto  set Deletado = 1, UpdateDtHr = GetDate()  where Id = @Id 
select top 1 * from tab_grupo_produto Order by updateDthr desc
commit