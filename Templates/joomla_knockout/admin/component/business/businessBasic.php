<?php
defined('_JEXEC') or die('Acesso restrito!');
use Joomla\CMS\Factory as JFactory;

class {TYPE}Business extends BaseBusiness
{
    function __construct()
    {
        $this->field_nome_exato = "{SEARCH_TEXT}";
        $this->table_name = "#__{TABLE_NAME}";
        $this->type = "{TYPE_LOWER}";
        $this->ClassNameEntity = "{TYPE}Entity";
        $this->ClassNameFilterEntity = "{TYPE}FilterEntity";

        parent::__construct("{TABLE_POSFIXO_SIGLA}");
    }
    /**
	 * Summary of SalvarEntityBuilder
     * @param {TYPE}Entity $entity
	 * @param {PREFIX}Table{TYPE_EDIT} $row
	 */
    function SalvarEntityBuilder($entity, &$row)
    {
		$userClass = new UserClass();
        $date = JFactory::getDate();
        $dateNow = $date->toSql();

        {CONVERTDATEROW_PREPARETABLE}
        $row->id_cli = $entity->id_cli > 0 ? $entity->id_cli : $userClass->CodigoCliente;
		{SAVE_FIELDS}
    }
    /**
     * Método para Buscar o Registro
     * @param int $id
     * @param UserClass $userClass
     * @return {TYPE}Entity
     */
    function BuscarRegistro($id, $userClass = NULL)
    {
        return parent::BuscarRegistro($id, $userClass);
    }
    /**
     * Método para Buscar os Registros
     * @param {TYPE}FilterEntity $filtro
     * @return array
     */
    function BuscarRegistros($filtro)
    {
        $query = $this->_db->getQuery(true);

        $query->select({SELECT_FIELDS})
            ->from('#__{TABLE_NAME} AS {TABLE_POSFIXO_SIGLA}');
		{QUERY_JOINS}

        $query->where("{TABLE_POSFIXO_SIGLA}.id_cli=".$userClass->CodigoCliente);

        if($filtro->{PK} > 0)
        {
            $query->where("{TABLE_POSFIXO_SIGLA}.{PK}=$filtro->{PK}");
        }
        else
        {
        {FILTER_FIELDS}

            $query = $this->GetQueryWhere($query, $filtro);
		}

        $query->order('{TABLE_POSFIXO_SIGLA}.{ORDER_BY_DEFAULT} ASC');

        $this->_db->setQuery($query);

        return $this->_db->loadObjectList();
    }
}