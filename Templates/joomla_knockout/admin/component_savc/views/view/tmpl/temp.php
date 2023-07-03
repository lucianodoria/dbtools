<?php
defined('_JEXEC') or die;
use Joomla\CMS\HTML\HTMLHelper as JHtml;
use Joomla\CMS\Uri\Uri as JUri;

JHtml::addIncludePath(JPATH_COMPONENT . '/helpers/html');

$page_header = "{TITLE}";
$page_header_icon_class = "fa fa-list-alt";
$searchFieldName = "{TITLE}";
$searchField = '$root.Filtro().{SEARCH_TEXT}';
$view_outros = false;
?>
<div class="wrapper">
    <?php include_once({PREFIX_UPPER}_PATH_SHARED_HEADER);?>
    <?php include_once({PREFIX_UPPER}_PATH_SHARED_SIDEBAR);?>

    <div class="content-wrapper">
        <?php include_once({PREFIX_UPPER}_PATH_SHARED_PAGE_HEADER);?>
        <section class="content">
            <?php if (!$this->PermissaoAcesso): ?>
            <?php include_once({PREFIX_UPPER}_PATH_SHARED_NOT_PERMISSION);?>
            <?php else:?>
            <?php include_once({PREFIX_UPPER}_PATH_SHARED_SEARCH_CONTROL);?>
            <!--O filtro -->
            <div class="containerFiltros">
                <form action="#" data-bind="with: $root.Filtro">
                    <div class="box">
                        <?php include_once(GRUPOJOVEM_PATH_SHARED_SEARCH_CONTROL_HEADER);?>
                        <div class="box-body">
                            <div class="form-group">
                                <label for="nome_txa">Nome:</label>
                                <?php echo JHtmlPlus::TextBoxControl('{SEARCH_TEXT}',100, null, '{SEARCH_TEXT}', true, '')?>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="data_cadastro_inicial">Data de cadastro inicial:</label>
                                        <?php echo JHtmlPlus::DatepickerControl('data_cadastro_inicial');?>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="data_cadastro_final">Data de cadastro final:</label>
                                        <?php echo JHtmlPlus::DatepickerControl('data_cadastro_final');?>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="filtro_id_rev">Status:</label>
                                        <?php echo JHtmlPlus::SelectStatusAtivo('ativo','filtro_ativo', '-- Todos --', 'FiltroStatusAtivo')?>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <?php include_once({PREFIX_UPPER}_PATH_SHARED_SEARCH_CONTROL_BUTTONS);?>
                    </div>
                </form>
            </div>
            <!--O grid -->
            <div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="box">
                        <div class="box-body">
                            <div class="table-responsive" data-bind="grid: $root.gridViewModel, visible: $root.items().length > 0"></div>
                        </div>
                    </div>
                </div>
            </div>
            <?php include_once({PREFIX_UPPER}_PATH_SHARED_NENHUM_RESULTADO_ENCONTRADO);?>
            <?php endif;?>
        </section>
    </div>
    <?php include_once({PREFIX_UPPER}_PATH_SHARED_FOOTER);?>
</div>
<?php if ($this->PermissaoCriar || $this->PermissaoEditar): ?>
<!-- Modal -->
<?php include_once('modal_adicionar.php');?>
<?php endif;?>
<?php if ($this->PermissaoAcesso): ?>
<script type="text/javascript">
    $.ApplyBindingsContentContainer(new DoriaTI.{PREFIX}.MvcApplication.ViewModels.{TYPE}.IndexViewModel());
</script>
<?php
    JHTML::script(JUri::root().'administrator/components/{COMPONENT}/assets/js/ViewModels/{TYPE}/IndexViewModel.js?v='.{PREFIX_UPPER}_VERSAO_FILES);
?>
<?php endif;?>