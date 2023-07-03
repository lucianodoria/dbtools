<?php
/**
 * @package     Joomla.Administrator
 * @subpackage  com_banners
 *
 * @copyright   Copyright (C) 2005 - 2013 Open Source Matters, Inc. All rights reserved.
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */

defined('_JEXEC') or die;

JLoader::register('{PREFIX}Helper', JPATH_COMPONENT . '/helpers/{PREFIX_LOWER}.php');

class {PREFIX}View{TYPE_EDIT} extends JViewLegacy
{
	protected $form;
	protected $item;
	protected $state;

	/**
	 * Display the view
	 */
	public function display($tpl = null)
	{
		// Initialiase variables.
		$this->form     = $this->get('Form');
		$this->item     = $this->get('Item');
		$this->state	= $this->get('State');

		// Check for errors.
		if (count($errors = $this->get('Errors')))
		{
			JError::raiseError(500, implode("\n", $errors));
			return false;
		}

		$this->addToolbar();
                
		JHtml::_('jquery.framework');
		parent::display($tpl);
	}

	/**
	 * Add the page title and toolbar.
	 *
	 * @since   1.6
	 */
	protected function addToolbar()
	{
            JFactory::getApplication()->input->set('hidemainmenu', true);

            $user		= JFactory::getUser();
            $userId		= $user->get('id');
            $isNew		= ($this->item->{PK} == 0);

            // Since we don't track these assets at the item level, use the category id.
            $canDo = JHelperContent::getActions(0, 0, '{COMPONENT}');

            JToolbarHelper::title($isNew ? JText::_('{TITLE_NEW}') : JText::_('{TITLE_EDIT}'), 'bookmark {TYPE_LOWER}');

            if ($canDo->get('core.edit'))
            {
                JToolbarHelper::apply('{TYPE_EDIT_LOWER}.apply');
                JToolbarHelper::save('{TYPE_EDIT_LOWER}.save');
            }

            JToolbarHelper::cancel('{TYPE_EDIT_LOWER}.cancel');
	}
}
