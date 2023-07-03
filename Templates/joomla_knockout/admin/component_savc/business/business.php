<?php
defined('_JEXEC') or die('Acesso restrito!');
class {TYPE}Business extends BaseBusiness
{
    var $_db = null;
    
    function __construct() 
    {
        $this->_db = JFactory::getDbo();
    }
    
    function Salvar($entity)
    {
        $result = new ResultClass();
		
        try 
        {
			if($this->ValidaDuplicidade($entity) == false)
            {
                $result->Erro = true; 
                $result->Message = "Já existe o registro \"$entity->{SEARCH_TEXT}\"!";
                
                return $result;
            }
			
            $this->_db->transactionStart();
                        
            $this->SalvarEntity($entity, $this->_db); 

            $this->_db->transactionCommit();

            $result->Erro = false; 
            $result->Message = "Registro salvo com sucesso!"; 
        }
        catch (Exception $e) 
        {
            $this->_db->transactionRollback();

            $result->Erro = true;
            $result->Message = $e->getMessage();
        }
        
        return $result;
    }
    
	function SalvarEntity($entity, &$db)
    {
		$userClass = new UserClass();
		{DATE_CREATE_UPDATE}{USER_CREATE_UPDATE}
	
		$row = JTable::getInstance('{TYPE_LOWER}', 'HotelTable');
		$row->setDBO($db);
		
		$row->id_hot =$userClass->CodigoHotel;
		{CONVERTDATEROW_PREPARETABLE}
		{SAVE_FIELDS}
		if($entity->acao == HOTEL_ACAO_NOVO)
		{
			$row->{PK} = (int)$row->{PK};
		}
		else
		{
			$row->{PK} = (int)$entity->{PK};
		}

		$row->store(true);
		
		return $row->{PK};
    }
	
    function Excluir($entity)
    {
        $result = new ResultClass();
        
        try 
        {
            $this->_db->transactionStart();
                       
            $this->ExcluirEntity($entity, $this->_db);

            $this->_db->transactionCommit();
            
            $result->Erro = false; 
            $result->Message = "Registro excluído com sucesso!"; 
        }
        catch (Exception $e) 
        {
            $this->_db->transactionRollback();

            $result->Erro = true;
            $result->Message = $e->getMessage();
        }

        return $result;
    }
	
	function ExcluirEntity($entity, &$db)
    {
		${PK} = $entity->{PK};
            
		$queryDelete = $db->getQuery(true);
		$queryDelete->delete('#__{TABLE_NAME}')->where("{PK}=${PK}");

		$db->setQuery($queryDelete);
		$db->query();
    }
    
    function BuscarRegistro($id)
    {
        $entity = new {TYPE}Entity();
        $filtro = new {TYPE}FilterEntity();
        $filtro->{PK} = $id;
            
        $row = $this->BuscarRegistros($filtro);
          
        $entity->setRow($row[0]);
        
        return $entity;
    }
    
    function BuscarRegistros($filtro)
    {
		$userClass = new UserClass();
        $query = $this->_db->getQuery(true);
        $filtrouPeloID = false;
        
        $query->select({SELECT_FIELDS})
            ->from('#__{TABLE_NAME} AS {TABLE_SIGLA}');       
		{QUERY_JOINS}
        if($filtro->{PK} > 0)
        {
            $query->where("{TABLE_SIGLA}.{PK}=$filtro->{PK}");
            $filtrouPeloID = true;
        }
		
		$query->where("{TABLE_SIGLA}.id_cli=".$userClass->CodigoHotel);
{FILTER_FIELDS}
        $query->order('{TABLE_SIGLA}.{ORDER_BY_DEFAULT} ASC'); 
        
        $this->_db->setQuery($query);
        
        return $this->_db->loadObjectList();
    }
	
	function ValidaDuplicidade($entity)
    {
        $validado = true;
        
        $filtro = new {TYPE}FilterEntity();
        $filtro->{SEARCH_TEXT}_exato = $entity->{SEARCH_TEXT};
        
        $rows = $this->BuscarRegistros($filtro);
        
        if(count($rows) > 0 )
        {
            if($entity->acao == HOTEL_ACAO_NOVO)
            {
                $validado = false;
            }
            else
            {
                if($rows[0]->{PK} != $entity->{PK})
                {
                    $validado = false;
                }
            }
        }
        
        return $validado;
    }
}

