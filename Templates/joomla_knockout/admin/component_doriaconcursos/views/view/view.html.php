<?php
defined('_JEXEC') or die;

class {PREFIX}View{TYPE} extends JViewLegacyDoriaTI
{
	public function display($tpl = null)
	{
        // Check for errors.
        $errors = $this->get('Errors');

        if ($errors !== null && count($errors))
		{
			throw new Exception(implode("\n", $errors), 500);
		}

        parent::display($tpl);
	}
}

