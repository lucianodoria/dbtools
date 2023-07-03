<?php
defined('_JEXEC') or die;

JHtml::addIncludePath(JPATH_COMPONENT . '/helpers/html');
JHtml::_('behavior.formvalidation');
JHtml::_('formbehavior.chosen', 'select');

$PATH_ADMIN_CSS = 'administrator/components/{COMPONENT}/assets/css/';

/* -------- CSS -------- */
JHTML::stylesheet($PATH_ADMIN_CSS . 'css_{COMPONENT}_edit.css');

$app = JFactory::getApplication();
$pathImage = JURI::root() . "/administrator/components/{COMPONENT}/assets/images/fieldsets/"
?>
<script type="text/javascript">
	Joomla.submitbutton = function(task)
	{
		if (task == '{TYPE_EDIT_LOWER}.cancel' || document.formvalidator.isValid(document.id('{TYPE_EDIT_LOWER}-form'))) {
			Joomla.submitform(task, document.getElementById('{TYPE_EDIT_LOWER}-form'));
		}
	}
</script>

<form action="<?php echo JRoute::_('index.php?option={COMPONENT}&layout=edit&{PK}='.(int)$this->item->{PK}); ?>" method="post" name="adminForm" id="{TYPE_EDIT_LOWER}-form" class="form-validate form-horizontal">
	<fieldset class="fieldsetGroup">
		<legend><img src="<?php echo $pathImage; ?>icon-24-form.png" alt="dados"></span> Dados do {TYPE_EDIT}</legend>
		<div class="control-group">
		{FIELDS}
		</div>  
	</fieldset>  
    <input type="hidden" name="task" value=""/>
    <?php echo JHTML::_('form.token');?>
</form>
