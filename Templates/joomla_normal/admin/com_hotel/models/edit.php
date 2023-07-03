<?php

defined('_JEXEC') or die;

class {PREFIX}Model{TYPE_EDIT} extends JModelAdmin
{
	protected $text_prefix = '{TEXT_PREFIX_EDIT}';
	public $typeAlias = '{COMPONENT}.{TYPE_EDIT_LOWER}';

	protected function canDelete($record)
	{
            $user = JFactory::getUser();
            
            if (!empty($record->{PK}))
            {
                return $user->authorise('core.delete', '{COMPONENT}.{TYPE_EDIT_LOWER}.' . (int)$record->{PK});
            }
            else
            {
                return parent::canDelete($record);
            }
	}

	protected function canEditState($record)
	{
		$user = JFactory::getUser();

		// Check against the category.
		if (!empty($record->{PK}))
		{
			return $user->authorise('core.edit.state', '{COMPONENT}.{TYPE_EDIT_LOWER}.' . (int) $record->{PK});
		}
		// Default to component settings if category not known.
		else
		{
			return parent::canEditState($record);
		}
	}

	public function getTable($type = '{TYPE_EDIT}', $prefix = '{PREFIX}Table', $config = array())
	{
		return JTable::getInstance($type, $prefix, $config);
	}

	public function getForm($data = array(), $loadData = true)
	{
		// Get the form.
		$form = $this->loadForm('{COMPONENT}.{TYPE_EDIT_LOWER}', '{TYPE_EDIT_LOWER}', array('control' => 'jform', 'load_data' => $loadData));
		
                if (empty($form))
		{
			return false;
		}

		return $form;
	}

	protected function loadFormData()
	{
		// Check the session for previously entered form data.
		$app  = JFactory::getApplication();
		$data = $app->getUserState('{COMPONENT}.edit.{TYPE_EDIT_LOWER}.data', array());

		if (empty($data))
		{
			$data = $this->getItem();
		}

		$this->preprocessData('{COMPONENT}.{TYPE_EDIT_LOWER}', $data);

		return $data;
	}

	public function stick(&$pks, $value = 1)
	{
		$user = JFactory::getUser();
		$table = $this->getTable();
		$pks = (array) $pks;

		// Access checks.
		foreach ($pks as $i => $pk)
		{
			if ($table->load($pk))
			{
				if (!$this->canEditState($table))
				{
					// Prune items that you can't change.
					unset($pks[$i]);
					JError::raiseWarning(403, JText::_('JLIB_APPLICATION_ERROR_EDITSTATE_NOT_PERMITTED'));
				}
			}
		}

		// Attempt to change the state of the records.
		if (!$table->stick($pks, $value, $user->get('id')))
		{
			$this->setError($table->getError());
			return false;
		}

		return true;
	}

	protected function getReorderConditions($table)
	{
		$condition = array();
		$condition[] = '{PK} = '. (int) $table->{PK};
		$condition[] = 'state >= 0';
		return $condition;
	}

	protected function prepareTable($table)
	{
		{CREATE_UPDATE_ROWS}
		{CONVERTDATEROW_PREPARETABLE}
	}

	public function save($data)
	{
		$app = JFactory::getApplication();

		// Alter the name for save as copy
		if ($app->input->get('task') == 'save2copy')
		{
			list($name, $alias) = $this->generateNewTitle($data['{PK}'], $data['alias'], $data['name']);
			$data['name']	= $name;
			$data['alias']	= $alias;
			$data['state']	= 0;
		}

		if (parent::save($data))
		{
                    return true;
		}

		return false;
	}   
}
