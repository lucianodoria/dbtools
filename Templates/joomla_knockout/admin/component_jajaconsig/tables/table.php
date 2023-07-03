<?php
defined('_JEXEC') or die('Acesso restrito!');
use Joomla\CMS\Table\Table as JTable;

class {PREFIX}Table{TYPE_EDIT} extends JTable
{
{VARS}
    /**
     * @param JDatabaseDriver $db Classe que representa o Banco de Dados.
     */
    function __construct(&$db)
    {
        parent::__construct('#__{TABLE_NAME}', '{PK}', $db);
    }
}

?>