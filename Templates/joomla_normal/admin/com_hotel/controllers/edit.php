<?php

defined('_JEXEC') or die('Acesso restrito!');
jimport('joomla.application.component.controller');

class {PREFIX}Controller{TYPE_EDIT} extends JControllerForm 
{
    protected $text_prefix = '{TEXT_PREFIX_EDIT}';
	protected $view_list = "{TYPE_LOWER}";
}

?>
