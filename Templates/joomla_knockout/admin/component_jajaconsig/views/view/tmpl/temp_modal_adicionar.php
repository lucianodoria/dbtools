<?php
defined('_JEXEC') or die;
?>
<div class="modal fade" id="modalAdicionar" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">
                    <span data-bind="text: $root.LabelModalAcao($root.ModelEdicao().acao)"></span> {TITLE}
                </h4>
            </div>
            <div class="modal-body" data-bind="with: $root.ModelEdicao">
                <form id="form1">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Geral</h3>
                        </div>
                        <div class="box-body">
                               {FIELDS}
                        </div>
                    </div>
                    <span class="label-obrigatorio"></span>
                    <small style="color: red;">Preenchimento obrigatório</small>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                <button type="button" class="btn btn-primary" data-bind="click: $root.Salvar"><span class="fa fa-floppy-o"></span> Salvar</button>
            </div>
        </div>
    </div>
</div>