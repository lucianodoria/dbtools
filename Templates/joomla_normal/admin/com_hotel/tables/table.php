<?php
defined('_JEXEC') or die('Acesso restrito!');

class {PREFIX}Table{TYPE_EDIT} extends JTable
{
{VARS}
    function __construct(&$db) 
    {
        parent::__construct('#__{TABLE_NAME}', '{PK}', $db);
    }
}

?>
