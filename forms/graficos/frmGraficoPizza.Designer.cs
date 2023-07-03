namespace DBTools.forms.graficos
{
    partial class frmGraficoPizza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraficoPizza));
            this.tbcGrafico = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkPizzaMostrarTotal = new System.Windows.Forms.CheckBox();
            this.chkPizzaSiglaNome = new System.Windows.Forms.CheckBox();
            this.gpbWhere = new System.Windows.Forms.GroupBox();
            this.dtpValor = new System.Windows.Forms.DateTimePicker();
            this.cboTipoValue = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.Where_lblValor = new System.Windows.Forms.Label();
            this.Where_btnRemoverTodos = new System.Windows.Forms.Button();
            this.Where_btnRemoverUm = new System.Windows.Forms.Button();
            this.Where_btnInserirUm = new System.Windows.Forms.Button();
            this.lvwWhere = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhWhereColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.Select_btnInserirUm = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.gpbQuery = new System.Windows.Forms.GroupBox();
            this.lvwCampos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid5 = new System.Windows.Forms.PropertyGrid();
            this.piePizza = new LDChartControlPlus.Pie();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.msChartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTituloMSChart = new System.Windows.Forms.TextBox();
            this.tbcGrafico.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gpbWhere.SuspendLayout();
            this.gpbSelect.SuspendLayout();
            this.gpbQuery.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msChartPie)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcGrafico
            // 
            this.tbcGrafico.Controls.Add(this.tabPage3);
            this.tbcGrafico.Controls.Add(this.tabPage1);
            this.tbcGrafico.Controls.Add(this.tabPage2);
            this.tbcGrafico.Controls.Add(this.tabPage5);
            this.tbcGrafico.Controls.Add(this.tabPage4);
            this.tbcGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGrafico.ImageList = this.imageList1;
            this.tbcGrafico.Location = new System.Drawing.Point(0, 0);
            this.tbcGrafico.Name = "tbcGrafico";
            this.tbcGrafico.SelectedIndex = 0;
            this.tbcGrafico.Size = new System.Drawing.Size(741, 459);
            this.tbcGrafico.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkPizzaMostrarTotal);
            this.tabPage3.Controls.Add(this.chkPizzaSiglaNome);
            this.tabPage3.Controls.Add(this.gpbWhere);
            this.tabPage3.Controls.Add(this.gpbSelect);
            this.tabPage3.Controls.Add(this.btnFill);
            this.tabPage3.Controls.Add(this.gpbQuery);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(733, 432);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Query";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkPizzaMostrarTotal
            // 
            this.chkPizzaMostrarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPizzaMostrarTotal.AutoSize = true;
            this.chkPizzaMostrarTotal.Checked = true;
            this.chkPizzaMostrarTotal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPizzaMostrarTotal.ForeColor = System.Drawing.Color.Maroon;
            this.chkPizzaMostrarTotal.Location = new System.Drawing.Point(214, 405);
            this.chkPizzaMostrarTotal.Name = "chkPizzaMostrarTotal";
            this.chkPizzaMostrarTotal.Size = new System.Drawing.Size(84, 17);
            this.chkPizzaMostrarTotal.TabIndex = 23;
            this.chkPizzaMostrarTotal.Text = "Mostrar total";
            this.chkPizzaMostrarTotal.UseVisualStyleBackColor = true;
            // 
            // chkPizzaSiglaNome
            // 
            this.chkPizzaSiglaNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPizzaSiglaNome.AutoSize = true;
            this.chkPizzaSiglaNome.ForeColor = System.Drawing.Color.Maroon;
            this.chkPizzaSiglaNome.Location = new System.Drawing.Point(8, 405);
            this.chkPizzaSiglaNome.Name = "chkPizzaSiglaNome";
            this.chkPizzaSiglaNome.Size = new System.Drawing.Size(158, 17);
            this.chkPizzaSiglaNome.TabIndex = 22;
            this.chkPizzaSiglaNome.Text = "Abreviar o campo descrição";
            this.chkPizzaSiglaNome.UseVisualStyleBackColor = true;
            // 
            // gpbWhere
            // 
            this.gpbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWhere.Controls.Add(this.dtpValor);
            this.gpbWhere.Controls.Add(this.cboTipoValue);
            this.gpbWhere.Controls.Add(this.txtValor);
            this.gpbWhere.Controls.Add(this.Where_lblValor);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverTodos);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverUm);
            this.gpbWhere.Controls.Add(this.Where_btnInserirUm);
            this.gpbWhere.Controls.Add(this.lvwWhere);
            this.gpbWhere.Location = new System.Drawing.Point(307, 62);
            this.gpbWhere.Name = "gpbWhere";
            this.gpbWhere.Size = new System.Drawing.Size(418, 333);
            this.gpbWhere.TabIndex = 21;
            this.gpbWhere.TabStop = false;
            this.gpbWhere.Text = "WHERE";
            // 
            // dtpValor
            // 
            this.dtpValor.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpValor.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpValor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValor.Location = new System.Drawing.Point(209, 10);
            this.dtpValor.Name = "dtpValor";
            this.dtpValor.Size = new System.Drawing.Size(134, 20);
            this.dtpValor.TabIndex = 10;
            this.dtpValor.Visible = false;
            // 
            // cboTipoValue
            // 
            this.cboTipoValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValue.FormattingEnabled = true;
            this.cboTipoValue.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "<>",
            ">=",
            "<=",
            "LIKE",
            "IN",
            "NOT IN",
            "IS NULL",
            "IS NOT NULL"});
            this.cboTipoValue.Location = new System.Drawing.Point(106, 10);
            this.cboTipoValue.Name = "cboTipoValue";
            this.cboTipoValue.Size = new System.Drawing.Size(97, 21);
            this.cboTipoValue.TabIndex = 9;
            this.cboTipoValue.SelectedIndexChanged += new System.EventHandler(this.cboTipoValue_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(209, 10);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(203, 20);
            this.txtValor.TabIndex = 8;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Where_lblValor
            // 
            this.Where_lblValor.AutoSize = true;
            this.Where_lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_lblValor.ForeColor = System.Drawing.Color.Navy;
            this.Where_lblValor.Location = new System.Drawing.Point(60, 14);
            this.Where_lblValor.Name = "Where_lblValor";
            this.Where_lblValor.Size = new System.Drawing.Size(40, 13);
            this.Where_lblValor.TabIndex = 7;
            this.Where_lblValor.Text = "Valor:";
            // 
            // Where_btnRemoverTodos
            // 
            this.Where_btnRemoverTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Where_btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnRemoverTodos.ForeColor = System.Drawing.Color.Maroon;
            this.Where_btnRemoverTodos.Location = new System.Drawing.Point(6, 305);
            this.Where_btnRemoverTodos.Name = "Where_btnRemoverTodos";
            this.Where_btnRemoverTodos.Size = new System.Drawing.Size(48, 23);
            this.Where_btnRemoverTodos.TabIndex = 5;
            this.Where_btnRemoverTodos.Text = "<<";
            this.Where_btnRemoverTodos.UseVisualStyleBackColor = true;
            this.Where_btnRemoverTodos.Click += new System.EventHandler(this.Where_btnRemoverTodos_Click);
            // 
            // Where_btnRemoverUm
            // 
            this.Where_btnRemoverUm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Where_btnRemoverUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnRemoverUm.ForeColor = System.Drawing.Color.Maroon;
            this.Where_btnRemoverUm.Location = new System.Drawing.Point(6, 276);
            this.Where_btnRemoverUm.Name = "Where_btnRemoverUm";
            this.Where_btnRemoverUm.Size = new System.Drawing.Size(48, 23);
            this.Where_btnRemoverUm.TabIndex = 4;
            this.Where_btnRemoverUm.Text = "<";
            this.Where_btnRemoverUm.UseVisualStyleBackColor = true;
            this.Where_btnRemoverUm.Click += new System.EventHandler(this.Where_btnRemoverUm_Click);
            // 
            // Where_btnInserirUm
            // 
            this.Where_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.Where_btnInserirUm.Location = new System.Drawing.Point(6, 14);
            this.Where_btnInserirUm.Name = "Where_btnInserirUm";
            this.Where_btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.Where_btnInserirUm.TabIndex = 2;
            this.Where_btnInserirUm.Text = ">";
            this.Where_btnInserirUm.UseVisualStyleBackColor = true;
            this.Where_btnInserirUm.Click += new System.EventHandler(this.Where_btnInserirUm_Click);
            // 
            // lvwWhere
            // 
            this.lvwWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWhere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhWhereColumn});
            this.lvwWhere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lvwWhere.FullRowSelect = true;
            this.lvwWhere.HideSelection = false;
            this.lvwWhere.KeyUpDownActivateOnClick = false;
            this.lvwWhere.Location = new System.Drawing.Point(60, 37);
            this.lvwWhere.MultiSelect = false;
            this.lvwWhere.Name = "lvwWhere";
            this.lvwWhere.Size = new System.Drawing.Size(352, 290);
            this.lvwWhere.Sorter = false;
            this.lvwWhere.TabIndex = 1;
            this.lvwWhere.UseCompatibleStateImageBehavior = false;
            this.lvwWhere.View = System.Windows.Forms.View.Details;
            // 
            // clhWhereColumn
            // 
            this.clhWhereColumn.Text = "Column";
            this.clhWhereColumn.Width = 190;
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSelect.Controls.Add(this.txtSelect);
            this.gpbSelect.Controls.Add(this.Select_btnInserirUm);
            this.gpbSelect.Location = new System.Drawing.Point(307, 6);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(418, 50);
            this.gpbSelect.TabIndex = 20;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "SELECT";
            // 
            // txtSelect
            // 
            this.txtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelect.BackColor = System.Drawing.Color.Ivory;
            this.txtSelect.ForeColor = System.Drawing.Color.Blue;
            this.txtSelect.Location = new System.Drawing.Point(60, 21);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.ReadOnly = true;
            this.txtSelect.Size = new System.Drawing.Size(352, 20);
            this.txtSelect.TabIndex = 3;
            // 
            // Select_btnInserirUm
            // 
            this.Select_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.Select_btnInserirUm.Location = new System.Drawing.Point(6, 19);
            this.Select_btnInserirUm.Name = "Select_btnInserirUm";
            this.Select_btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.Select_btnInserirUm.TabIndex = 2;
            this.Select_btnInserirUm.Text = ">";
            this.Select_btnInserirUm.UseVisualStyleBackColor = true;
            this.Select_btnInserirUm.Click += new System.EventHandler(this.Select_btnInserirUm_Click);
            // 
            // btnFill
            // 
            this.btnFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFill.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnFill.Location = new System.Drawing.Point(650, 401);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 0;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // gpbQuery
            // 
            this.gpbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbQuery.Controls.Add(this.lvwCampos);
            this.gpbQuery.Location = new System.Drawing.Point(8, 6);
            this.gpbQuery.Name = "gpbQuery";
            this.gpbQuery.Size = new System.Drawing.Size(293, 389);
            this.gpbQuery.TabIndex = 19;
            this.gpbQuery.TabStop = false;
            this.gpbQuery.Text = "Columns";
            // 
            // lvwCampos
            // 
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.clhDataType});
            this.lvwCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCampos.ForeColor = System.Drawing.Color.Maroon;
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.HideSelection = false;
            this.lvwCampos.KeyUpDownActivateOnClick = true;
            this.lvwCampos.Location = new System.Drawing.Point(3, 16);
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(287, 370);
            this.lvwCampos.Sorter = true;
            this.lvwCampos.TabIndex = 0;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            this.lvwCampos.Click += new System.EventHandler(this.lvwCampos_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Columns";
            this.columnHeader1.Width = 260;
            // 
            // clhDataType
            // 
            this.clhDataType.Text = "DataType";
            this.clhDataType.Width = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertyGrid5);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Propriedade";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid5
            // 
            this.propertyGrid5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid5.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid5.Name = "propertyGrid5";
            this.propertyGrid5.SelectedObject = this.piePizza;
            this.propertyGrid5.Size = new System.Drawing.Size(727, 426);
            this.propertyGrid5.TabIndex = 15;
            this.propertyGrid5.TabStop = false;
            // 
            // piePizza
            // 
            this.piePizza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piePizza.LegendColor = System.Drawing.Color.Green;
            this.piePizza.LegendFont = new System.Drawing.Font("Tahoma", 10F);
            this.piePizza.LegendRoundBackColor = System.Drawing.Color.WhiteSmoke;
            this.piePizza.LegendRoundLineColor = System.Drawing.Color.Navy;
            this.piePizza.LineArcColor = System.Drawing.Color.Black;
            this.piePizza.Location = new System.Drawing.Point(3, 3);
            this.piePizza.Name = "piePizza";
            this.piePizza.RoundBackColor = System.Drawing.Color.AliceBlue;
            this.piePizza.RoundPenColor = System.Drawing.Color.SteelBlue;
            this.piePizza.RoundPenWidth = 3;
            this.piePizza.RoundRadius = 60F;
            this.piePizza.ShowBoundLine = true;
            this.piePizza.Size = new System.Drawing.Size(727, 426);
            this.piePizza.TabIndex = 1;
            this.piePizza.UseCustomColor = false;
            this.piePizza.ValueColor = System.Drawing.Color.Black;
            this.piePizza.ValueFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.piePizza);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gráfico";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.propertyGrid1);
            this.tabPage5.ImageIndex = 0;
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(733, 432);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Propriedade MS Chart";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.msChartPie;
            this.propertyGrid1.Size = new System.Drawing.Size(733, 432);
            this.propertyGrid1.TabIndex = 16;
            this.propertyGrid1.TabStop = false;
            // 
            // msChartPie
            // 
            this.msChartPie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.msChartPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.msChartPie.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.msChartPie.BorderSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.msChartPie.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.msChartPie.BorderSkin.BorderWidth = 2;
            this.msChartPie.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Inclination = 40;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.msChartPie.ChartAreas.Add(chartArea1);
            this.msChartPie.IsSoftShadows = false;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            legend1.IsDockedInsideChartArea = false;
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "Legend1";
            legend1.TextWrapThreshold = 100;
            this.msChartPie.Legends.Add(legend1);
            this.msChartPie.Location = new System.Drawing.Point(10, 33);
            this.msChartPie.Name = "msChartPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "MinimumRelativePieSize=20, PieDrawingStyle=Concave";
            series1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Label = "#PERCENT{P2}";
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.msChartPie.Series.Add(series1);
            this.msChartPie.Size = new System.Drawing.Size(714, 389);
            this.msChartPie.TabIndex = 0;
            this.msChartPie.Text = "chart1";
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(109)))));
            title1.Name = "TitleTop";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Titulo";
            this.msChartPie.Titles.Add(title1);
            this.msChartPie.DoubleClick += new System.EventHandler(this.msChartPie_DoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.txtTituloMSChart);
            this.tabPage4.Controls.Add(this.msChartPie);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(733, 432);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Gráfico MS Chart";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PropertiesC#.ico");
            this.imageList1.Images.SetKeyName(1, "ChartPie16x16.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Título:";
            // 
            // txtTituloMSChart
            // 
            this.txtTituloMSChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTituloMSChart.ForeColor = System.Drawing.Color.Blue;
            this.txtTituloMSChart.Location = new System.Drawing.Point(49, 7);
            this.txtTituloMSChart.Name = "txtTituloMSChart";
            this.txtTituloMSChart.Size = new System.Drawing.Size(674, 20);
            this.txtTituloMSChart.TabIndex = 4;
            this.txtTituloMSChart.TextChanged += new System.EventHandler(this.txtTituloMSChart_TextChanged);
            // 
            // frmGraficoPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 459);
            this.Controls.Add(this.tbcGrafico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGraficoPizza";
            this.Text = "Gráfico Pizza";
            this.Load += new System.EventHandler(this.frmGraficoPizza_Load);
            this.tbcGrafico.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gpbWhere.ResumeLayout(false);
            this.gpbWhere.PerformLayout();
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.gpbQuery.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msChartPie)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcGrafico;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private LDChartControlPlus.Pie piePizza;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PropertyGrid propertyGrid5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gpbQuery;
        private System.Windows.Forms.Button btnFill;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwCampos;
        internal System.Windows.Forms.GroupBox gpbSelect;
        private System.Windows.Forms.Button Select_btnInserirUm;
        internal System.Windows.Forms.GroupBox gpbWhere;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label Where_lblValor;
        private System.Windows.Forms.Button Where_btnRemoverTodos;
        private System.Windows.Forms.Button Where_btnRemoverUm;
        private System.Windows.Forms.Button Where_btnInserirUm;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwWhere;
        private System.Windows.Forms.ColumnHeader clhWhereColumn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox chkPizzaSiglaNome;
        private System.Windows.Forms.CheckBox chkPizzaMostrarTotal;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.ComboBox cboTipoValue;
        private System.Windows.Forms.ColumnHeader clhDataType;
        private System.Windows.Forms.DateTimePicker dtpValor;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart msChartPie;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloMSChart;
    }
}