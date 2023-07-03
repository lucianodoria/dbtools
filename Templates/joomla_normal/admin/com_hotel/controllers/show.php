<?php

defined('_JEXEC') or die('Acesso restrito!');
jimport('joomla.application.component.controller');

class {PREFIX}Controller{TYPE} extends JControllerAdmin
{
    protected $text_prefix = '{TEXT_PREFIX}';
    
    public function __construct($config = array())
    {
            parent::__construct($config);

            $this->registerTask('sticky_unpublish', 'sticky_publish');
    }
    
    public function getModel($name = '{TYPE_EDIT}', $prefix = '{PREFIX}Model', $config = array('ignore_request' => true))
    {
            $model = parent::getModel($name, $prefix, $config);
            return $model;
    }
}

?>
