<?php
defined('_JEXEC') or die;

class {PREFIX}Model{TYPE} extends JModelList
{
	public function __construct($config = array())
	{
		if (empty($config['filter_fields']))
		{
			$config['filter_fields'] = array(
                                {FILTER_FIELDS});
		}

		parent::__construct($config);
	}

	protected function populateState($ordering = null, $direction = null)
	{
		// Load the filter state.
		$search = $this->getUserStateFromRequest($this->context . '.filter.search', 'filter_search');
		$this->setState('filter.search', $search);

		$state = $this->getUserStateFromRequest($this->context . '.filter.state', 'filter_state', '', 'string');
		$this->setState('filter.state', $state);

		// List state information.
		parent::populateState('a.{ORDER_BY_DEFAULT}', 'asc');
	}

	protected function getListQuery()
	{
		$db = $this->getDbo();
		$query = $db->getQuery(true);

		// Select the required fields from the table.
		$query->select(
			$this->getState(
				'list.select',
				{LIST_QUERY})
		);
		$query->from('#__{TABLE_NAME} AS a');

		{QUERY_JOINS}
		// Filter by published state.
		$state = $this->getState('filter.state');
		
		{MODEL_SHOW_PUBLISHED}

		// Filter by search in subject or banner.
		$search = $this->getState('filter.search');

		if (!empty($search))
		{
			$search = $db->quote('%' . $db->escape($search, true) . '%', false);
			$query->where('a.{SEARCH_TEXT} LIKE ' . $search);
		}

                // Add the list ordering clause.
		$orderCol   = $this->state->get('list.ordering', '{ORDER_BY_DEFAULT}');
		$orderDirn  = $this->state->get('list.direction', 'ASC');
                
		$query->order($db->escape($orderCol . ' ' . $orderDirn));

		return $query;
	}

	public function getTable($type = '{TYPE_EDIT}', $prefix = '{PREFIX}Table', $config = array())
	{
		return JTable::getInstance($type, $prefix, $config);
	}
}
