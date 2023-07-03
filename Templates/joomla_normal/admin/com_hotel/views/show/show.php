<?php
defined('_JEXEC') or die;

class {PREFIX}View{TYPE} extends JViewLegacy
{
	protected $items;
	protected $pagination;
	protected $state;

	public function display($tpl = null)
	{
            $this->items        = $this->get('Items');
            $this->pagination	= $this->get('Pagination');
            $this->state        = $this->get('State');

            // Check for errors.
            if (count($errors = $this->get('Errors')))
            {
                    JError::raiseError(500, implode("\n", $errors));

                    return false;
            }

            {PREFIX_LOWER}Helper::addSubmenu('{TYPE_LOWER}');

            $this->addToolbar();

            // Include the component HTML helpers.
            JHtml::addIncludePath(JPATH_COMPONENT . '/helpers/html');

            $this->sidebar = JHtmlSidebar::render();

            parent::display($tpl);
	}

	/**
	 * Add the page title and toolbar.
	 *
	 * @return  void
	 *
	 * @since   1.6
	 */
	protected function addToolbar()
	{
            require_once JPATH_COMPONENT . '/helpers/{PREFIX_LOWER}.php';

            $canDo = JHelperContent::getActions($this->state->get('filter.category_id'), 0, '{COMPONENT}');

            JToolbarHelper::title(JText::_('{TITLE_SHOW}'), '{IMAGE_TITLE}');

            if($canDo->get('core.create'))
            {
                JToolbarHelper::addNew('{TYPE_EDIT_LOWER}.add');
            }

            if ($canDo->get('core.edit'))
            {
                JToolbarHelper::editList('{TYPE_EDIT_LOWER}.edit');
            }

			{TOOLBAR_PUBLISH}
			
            if ($canDo->get('core.delete'))
            {
                JToolbarHelper::deleteList('', '{TYPE_LOWER}.delete');
                JToolbarHelper::divider();
            }
            
            if($canDo->get('core.admin'))
            {
                JToolbarHelper::preferences('{COMPONENT}');
            }
	}
}
