/// <reference path="../../../adminlte/plugins/jQuery/jquery.min.js" />
/// <reference path="../../libs/knockout/knockout-3.5.1.js" />
/// <reference path="../../DoriaTILibrary.js" />
/// <reference path="../BaseIndexViewModel.js" />
DoriaTI.{PREFIX}.MvcApplication.ViewModels.{TYPE} = DoriaTI.{PREFIX}.MvcApplication.ViewModels.{TYPE} || {};
DoriaTI.{PREFIX}.MvcApplication.ViewModels.{TYPE}.IndexViewModel = function () {

    var self = this;

    //define herança passando array de parametros do construtor do base
    DoriaTI.{PREFIX}.MvcApplication.ViewModels.BaseIndexViewModel.apply(self, [
        '{TYPE_LOWER}', //view
        'GetEntity' //task
    ]);

    $.ExtendViewModelBase(self);//aplica herança

    self.FiltroAvancado = ko.observable(true);
    self.ModelEdicao = ko.observable(undefined);
    self.ModelEdicaoTemp = null;

    self.gridViewModel = new ko.grid.viewModel({
        data: self.items,
        columns: [
            {FIELDS_COLUMNS}
            {
                headerText: "Ações", rowText:
                {
                    columnButtons: [
                        { iconCssClass: "fa fa-edit color-success", textCssClass: 'color-success', text: 'Editar', title: 'Clique  para Editar este registro.', showButtom: function () { return $.PermissaoEditar; }, buttonClick: function (item) { self.Editar(item); } },
                        { iconCssClass: "fa fa-trash-o color-danger", textCssClass: 'color-danger', text: 'Excluir', title: 'Clique para Excluir este registro.', showButtom: function () { return $.PermissaoExcluir; }, buttonClick: function (item) { self.Excluir(item); } }
                    ],
                }, rowType: 'text', HeaderCssClass: 'text-align-center', CssClass: 'col-md-2'
            }
        ],
        pageSize: 10
    });


    self.Editar = function (data) {
        self.Id(data.{PK});
        self.AbrirModal();
    };

    self.Excluir = function (data) {

        $.confirmDelete(function () {
            var options = {
                view: '{TYPE_LOWER}',
                task: 'DeleteEntity',
                entity: JSON.stringify(ko.toJS(data))
            };

            $.Ajax{PREFIX} (options, function (response) {

                response = $.toJSON(response);

                if (response != null) {
                    $.ExibirMensagensOperacao(response);

                    var resultado = ko.utils.arrayFirst(self.items(), function (item) {
                        return item.{PK} === data.{PK};
                    });

                    self.items.remove(resultado);
                    self.items.destroy(resultado);
                }

            }, true);
        });
    };

    self.Novo = function () {
        self.Id(0);
        self.AbrirModal();
    };

    self.AbrirModal = function () {
        var options = {
            view: '{TYPE_LOWER}',
            task: 'GetEntity',
            id: self.Id()
        };

        $.Ajax{PREFIX} (options, function (response) {

            response = $.toJSON(response);

            if (response != null) {

                self.ModelEdicao(ko.viewmodel.fromModel(response));

                $('#modalAdicionar').modal($.ModalDefaultOptions);
            }

        }, true);
    };

    self.Salvar = function () {

        var isValid = $($('#form1')).validate().form();

        if (!isValid)
            return;

        var options = {
            view: '{TYPE_LOWER}',
            task: 'SaveEntity',
            entity: JSON.stringify(ko.toJS(self.ModelEdicao))
        };

        $.Ajax{PREFIX} (options, function (response) {

            response = $.toJSON(response);

            if (response != null) {
                $.ExibirMensagensOperacao(response);

                $('#modalAdicionar').modal('hide');
                self.Filtro().{SEARCH_TEXT} (self.ModelEdicao().{SEARCH_TEXT} ());
                self.items.removeAll();
            }

        }, true);
    };

    // adicionar foco
    $('#modalAdicionar').on('shown.bs.modal', function () {
        $('#{FIELD_FOCO}').focus()
    });

    //Busca o filter do servidor
    self.GetFilterFromServer(function () {
        self.BuscarRegistros();
    });

    self.SearchReset = function () {
        self.Filtro().{SEARCH_TEXT} (null);
    };
};
