<?php
defined('_JEXEC') or die('Acesso restrito!');
jimport('joomla.application.component.controller');
use Joomla\CMS\Factory as JFactory;
use Joomla\CMS\MVC\Controller\AdminController as JControllerAdmin;

class {PREFIX}Controller{TYPE} extends JControllerAdmin
{
    public function __construct($config = array())
    {
        parent::__construct($config);
    }

    public function GetEntity()
    {
        $entity = new {TYPE}Entity();
        $entity->acao = {PREFIX_UPPER}_ACAO_NOVO;

        $jinput = JFactory::getApplication()->input;

        $id = json_decode($jinput->getString('id', "0"));

        if($id > 0)
        {
            ${TYPE_LOWER}Business = new {TYPE}Business();
            $userClass = new UserClass();

            $entity = ${TYPE_LOWER}Business->BuscarRegistro($id, $userClass);
            $entity->acao = {PREFIX_UPPER}_ACAO_ATUALIZAR;
        }

        jexit(json_encode($entity));
    }
    public function GetFilterEntity()
    {
        $filterEntity = new {TYPE}FilterEntity();

        jexit(json_encode($filterEntity));
    }
    public function BuscarRegistros()
    {
        $userClass = new UserClass();
        ${TYPE_LOWER}Business = new {TYPE}Business();
        $jinput = JFactory::getApplication()->input;

        $filterEntity = json_decode($jinput->getString('filterEntity', ""));
        $filterEntity->UserClass = $userClass;

        $lista = ${TYPE_LOWER}Business->BuscarRegistros($filterEntity);

        jexit(json_encode($lista));
    }
    public function SaveEntity()
    {
        ${TYPE_LOWER}Business = new {TYPE}Business();
        $jinput = JFactory::getApplication()->input;
        $entity = json_decode($jinput->getString("entity", ""));

        $result = ${TYPE_LOWER}Business->Salvar($entity);

        jexit(json_encode($result));
    }

    public function DeleteEntity()
    {
        ${TYPE_LOWER}Business = new {TYPE}Business();
        $jinput = JFactory::getApplication()->input;
        $entity = json_decode($jinput->getString("entity", ""));

        $result = ${TYPE_LOWER}Business->Excluir($entity);

        jexit(json_encode($result));
    }
}

