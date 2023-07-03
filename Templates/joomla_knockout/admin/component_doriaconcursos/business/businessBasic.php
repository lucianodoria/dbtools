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
        $this->ExisteCodigoUnidade = false;

        parent::__construct("{TABLE_POSFIXO_SIGLA}");
    }
    /**
	 * Summary of SalvarEntityBuilder
     * @param {TYPE}Entity $entity
	 * @param {PREFIX}Table{TYPE_EDIT} $row
	 */
    function SalvarEntityBuilder($entity, &$row)
    {
		$userClass = JFactoryDoriaTI::getAuthenticatedUser();
        $dateNow = utils_DateNowToSQL();

        {CONVERTDATEROW_PREPARETABLE}
        $row->id_und = $entity->id_und > 0 ? $entity->id_und : $userClass->CodigoUnidade;
		{SAVE_FIELDS}
    }
    /**
     * M�todo para Buscar o Registro
     * @param int $id
     * @param UserClass $userClass
     * @return {TYPE}Entity
     */
    function BuscarRegistro($id, $userClass = NULL)
    {
        return parent::BuscarRegistro($id, $userClass);
    }
    /**
     * M�todo para Buscar os Registros
     * @param {TYPE}FilterEntity $filtro
     * @return array
     */
    function BuscarRegistros($filtro)
    {
        $query = $this->_db->getQuery(true);

        $query->select({SELECT_FIELDS})
            ->from('#__{TABLE_NAME} AS {TABLE_POSFIXO_SIGLA}');
		{QUERY_JOINS}

        $query->where("{TABLE_POSFIXO_SIGLA}.id_und=".$filtro->UserClass->CodigoUnidade);

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