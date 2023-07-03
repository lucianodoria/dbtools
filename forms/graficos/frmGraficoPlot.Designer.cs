namespace DBTools.forms.graficos
{
    partial class frmGraficoPlot
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(9D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(11D, 90D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraficoPlot));
            this.tbcGrafico = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            this.dtpTotalPorHora = new System.Windows.Forms.DateTimePicker();
            this.pnlTotalMes = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAno_TotalMes = new System.Windows.Forms.ComboBox();
            this.pnlPorDia = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAno = new System.Windows.Forms.ComboBox();
            this.rdbTotalAno = new System.Windows.Forms.RadioButton();
            this.rdbTotalMes = new System.Windows.Forms.RadioButton();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.Select_btnInserirUm = new System.Windows.Forms.Button();
            this.rdbTotalPorHora = new System.Windows.Forms.RadioButton();
            this.rdbTotalPorDia = new System.Windows.Forms.RadioButton();
            this.gpbWhere = new System.Windows.Forms.GroupBox();
            this.cboTipoValue = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.Where_lblValor = new System.Windows.Forms.Label();
            this.Where_btnRemoverTodos = new System.Windows.Forms.Button();
            this.Where_btnRemoverUm = new System.Windows.Forms.Button();
            this.Where_btnInserirUm = new System.Windows.Forms.Button();
            this.lvwWhere = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhWhereColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFill = new System.Windows.Forms.Button();
            this.gpbQuery = new System.Windows.Forms.GroupBox();
            this.lvwCampos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhColumnIsDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid5 = new System.Windows.Forms.PropertyGrid();
            this.chartPlot = new LDChartControlPlus.ChartPlot();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.msChartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtTituloMSChart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcGrafico.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gpbSelect.SuspendLayout();
            this.pnlTotalMes.SuspendLayout();
            this.pnlPorDia.SuspendLayout();
            this.gpbWhere.SuspendLayout();
            this.gpbQuery.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msChartLine)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcGrafico
            // 
            this.tbcGrafico.Controls.Add(this.tabPage3);
            this.tbcGrafico.Controls.Add(this.tabPage1);
            this.tbcGrafico.Controls.Add(this.tabPage2);
            this.tbcGrafico.Controls.Add(this.tabPage4);
            this.tbcGrafico.Controls.Add(this.tabPage5);
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
            this.tabPage3.Controls.Add(this.gpbSelect);
            this.tabPage3.Controls.Add(this.gpbWhere);
            this.tabPage3.Controls.Add(this.btnFill);
            this.tabPage3.Controls.Add(this.gpbQuery);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(733, 432);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Query";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSelect.Controls.Add(this.dtpTotalPorHora);
            this.gpbSelect.Controls.Add(this.pnlTotalMes);
            this.gpbSelect.Controls.Add(this.pnlPorDia);
            this.gpbSelect.Controls.Add(this.rdbTotalAno);
            this.gpbSelect.Controls.Add(this.rdbTotalMes);
            this.gpbSelect.Controls.Add(this.txtSelect);
            this.gpbSelect.Controls.Add(this.Select_btnInserirUm);
            this.gpbSelect.Controls.Add(this.rdbTotalPorHora);
            this.gpbSelect.Controls.Add(this.rdbTotalPorDia);
            this.gpbSelect.Location = new System.Drawing.Point(307, 6);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(418, 153);
            this.gpbSelect.TabIndex = 23;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "SELECT";
            // 
            // dtpTotalPorHora
            // 
            this.dtpTotalPorHora.CustomFormat = "dd/MM/yyyy";
            this.dtpTotalPorHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTotalPorHora.Location = new System.Drawing.Point(102, 46);
            this.dtpTotalPorHora.Name = "dtpTotalPorHora";
            this.dtpTotalPorHora.Size = new System.Drawing.Size(87, 20);
            this.dtpTotalPorHora.TabIndex = 214;
            this.dtpTotalPorHora.ValueChanged += new System.EventHandler(this.dtpTotalPorHora_ValueChanged);
            // 
            // pnlTotalMes
            // 
            this.pnlTotalMes.Controls.Add(this.label8);
            this.pnlTotalMes.Controls.Add(this.cboAno_TotalMes);
            this.pnlTotalMes.Location = new System.Drawing.Point(102, 103);
            this.pnlTotalMes.Name = "pnlTotalMes";
            this.pnlTotalMes.Size = new System.Drawing.Size(113, 21);
            this.pnlTotalMes.TabIndex = 213;
            this.pnlTotalMes.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 194;
            this.label8.Text = "Ano:";
            // 
            // cboAno_TotalMes
            // 
            this.cboAno_TotalMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAno_TotalMes.ForeColor = System.Drawing.Color.Blue;
            this.cboAno_TotalMes.FormattingEnabled = true;
            this.cboAno_TotalMes.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboAno_TotalMes.Location = new System.Drawing.Point(39, 0);
            this.cboAno_TotalMes.Name = "cboAno_TotalMes";
            this.cboAno_TotalMes.Size = new System.Drawing.Size(71, 21);
            this.cboAno_TotalMes.TabIndex = 192;
            this.cboAno_TotalMes.SelectedIndexChanged += new System.EventHandler(this.cboAno_TotalMes_SelectedIndexChanged);
            // 
            // pnlPorDia
            // 
            this.pnlPorDia.Controls.Add(this.label2);
            this.pnlPorDia.Controls.Add(this.label3);
            this.pnlPorDia.Controls.Add(this.cboMes);
            this.pnlPorDia.Controls.Add(this.cboAno);
            this.pnlPorDia.Location = new System.Drawing.Point(102, 73);
            this.pnlPorDia.Name = "pnlPorDia";
            this.pnlPorDia.Size = new System.Drawing.Size(281, 21);
            this.pnlPorDia.TabIndex = 212;
            this.pnlPorDia.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Mês:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(173, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 194;
            this.label3.Text = "Ano:";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.ForeColor = System.Drawing.Color.Blue;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cboMes.Location = new System.Drawing.Point(39, 0);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(128, 21);
            this.cboMes.TabIndex = 191;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // cboAno
            // 
            this.cboAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAno.ForeColor = System.Drawing.Color.Blue;
            this.cboAno.FormattingEnabled = true;
            this.cboAno.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboAno.Location = new System.Drawing.Point(209, 0);
            this.cboAno.Name = "cboAno";
            this.cboAno.Size = new System.Drawing.Size(71, 21);
            this.cboAno.TabIndex = 192;
            this.cboAno.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // rdbTotalAno
            // 
            this.rdbTotalAno.AutoSize = true;
            this.rdbTotalAno.BackColor = System.Drawing.Color.Transparent;
            this.rdbTotalAno.ForeColor = System.Drawing.Color.Maroon;
            this.rdbTotalAno.Location = new System.Drawing.Point(6, 132);
            this.rdbTotalAno.Name = "rdbTotalAno";
            this.rdbTotalAno.Size = new System.Drawing.Size(89, 17);
            this.rdbTotalAno.TabIndex = 211;
            this.rdbTotalAno.Tag = "4";
            this.rdbTotalAno.Text = "Total por Ano";
            this.rdbTotalAno.UseVisualStyleBackColor = false;
            this.rdbTotalAno.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbTotalMes
            // 
            this.rdbTotalMes.AutoSize = true;
            this.rdbTotalMes.BackColor = System.Drawing.Color.Transparent;
            this.rdbTotalMes.ForeColor = System.Drawing.Color.Maroon;
            this.rdbTotalMes.Location = new System.Drawing.Point(6, 104);
            this.rdbTotalMes.Name = "rdbTotalMes";
            this.rdbTotalMes.Size = new System.Drawing.Size(90, 17);
            this.rdbTotalMes.TabIndex = 210;
            this.rdbTotalMes.Tag = "3";
            this.rdbTotalMes.Text = "Total por Mês";
            this.rdbTotalMes.UseVisualStyleBackColor = false;
            this.rdbTotalMes.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
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
            this.Select_btnInserirUm.Enabled = false;
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
            // rdbTotalPorHora
            // 
            this.rdbTotalPorHora.AutoSize = true;
            this.rdbTotalPorHora.BackColor = System.Drawing.Color.Transparent;
            this.rdbTotalPorHora.Checked = true;
            this.rdbTotalPorHora.ForeColor = System.Drawing.Color.Maroon;
            this.rdbTotalPorHora.Location = new System.Drawing.Point(6, 48);
            this.rdbTotalPorHora.Name = "rdbTotalPorHora";
            this.rdbTotalPorHora.Size = new System.Drawing.Size(94, 17);
            this.rdbTotalPorHora.TabIndex = 209;
            this.rdbTotalPorHora.TabStop = true;
            this.rdbTotalPorHora.Tag = "1";
            this.rdbTotalPorHora.Text = "Total Por Hora";
            this.rdbTotalPorHora.UseVisualStyleBackColor = false;
            this.rdbTotalPorHora.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbTotalPorDia
            // 
            this.rdbTotalPorDia.AutoSize = true;
            this.rdbTotalPorDia.BackColor = System.Drawing.Color.Transparent;
            this.rdbTotalPorDia.ForeColor = System.Drawing.Color.Maroon;
            this.rdbTotalPorDia.Location = new System.Drawing.Point(6, 76);
            this.rdbTotalPorDia.Name = "rdbTotalPorDia";
            this.rdbTotalPorDia.Size = new System.Drawing.Size(87, 17);
            this.rdbTotalPorDia.TabIndex = 208;
            this.rdbTotalPorDia.Tag = "2";
            this.rdbTotalPorDia.Text = "Total Por Dia";
            this.rdbTotalPorDia.UseVisualStyleBackColor = false;
            this.rdbTotalPorDia.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // gpbWhere
            // 
            this.gpbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWhere.Controls.Add(this.cboTipoValue);
            this.gpbWhere.Controls.Add(this.txtValor);
            this.gpbWhere.Controls.Add(this.Where_lblValor);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverTodos);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverUm);
            this.gpbWhere.Controls.Add(this.Where_btnInserirUm);
            this.gpbWhere.Controls.Add(this.lvwWhere);
            this.gpbWhere.Location = new System.Drawing.Point(307, 165);
            this.gpbWhere.Name = "gpbWhere";
            this.gpbWhere.Size = new System.Drawing.Size(418, 230);
            this.gpbWhere.TabIndex = 21;
            this.gpbWhere.TabStop = false;
            this.gpbWhere.Text = "WHERE";
            // 
            // cboTipoValue
            // 
            this.cboTipoValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValue.ForeColor = System.Drawing.Color.Blue;
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
            this.cboTipoValue.Location = new System.Drawing.Point(106, 11);
            this.cboTipoValue.Name = "cboTipoValue";
            this.cboTipoValue.Size = new System.Drawing.Size(97, 21);
            this.cboTipoValue.TabIndex = 10;
            this.cboTipoValue.SelectedIndexChanged += new System.EventHandler(this.cboTipoValue_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.ForeColor = System.Drawing.Color.Blue;
            this.txtValor.Location = new System.Drawing.Point(209, 11);
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
            this.Where_btnRemoverTodos.Location = new System.Drawing.Point(6, 202);
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
            this.Where_btnRemoverUm.Location = new System.Drawing.Point(6, 173);
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
            this.Where_btnInserirUm.Location = new System.Drawing.Point(6, 19);
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
            this.lvwWhere.Size = new System.Drawing.Size(352, 187);
            this.lvwWhere.Sorter = false;
            this.lvwWhere.TabIndex = 1;
            this.lvwWhere.UseCompatibleStateImageBehavior = false;
            this.lvwWhere.View = System.Windows.Forms.View.Details;
            // 
            // clhWhereColumn
            // 
            this.clhWhereColumn.Text = "Column";
            this.clhWhereColumn.Width = 320;
            // 
            // btnFill
            // 
            this.btnFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFill.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.gpbQuery.Size = new System.Drawing.Size(293, 418);
            this.gpbQuery.TabIndex = 19;
            this.gpbQuery.TabStop = false;
            this.gpbQuery.Text = "Columns";
            // 
            // lvwCampos
            // 
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhColumnName,
            this.clhColumnIsDate});
            this.lvwCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCampos.ForeColor = System.Drawing.Color.Maroon;
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.HideSelection = false;
            this.lvwCampos.KeyUpDownActivateOnClick = true;
            this.lvwCampos.Location = new System.Drawing.Point(3, 16);
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(287, 399);
            this.lvwCampos.Sorter = true;
            this.lvwCampos.TabIndex = 0;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            this.lvwCampos.Click += new System.EventHandler(this.lvwCampos_Click);
            // 
            // clhColumnName
            // 
            this.clhColumnName.Text = "Columns";
            this.clhColumnName.Width = 260;
            // 
            // clhColumnIsDate
            // 
            this.clhColumnIsDate.Text = "É Data";
            this.clhColumnIsDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhColumnIsDate.Width = 0;
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
            this.propertyGrid5.SelectedObject = this.chartPlot;
            this.propertyGrid5.Size = new System.Drawing.Size(727, 426);
            this.propertyGrid5.TabIndex = 15;
            this.propertyGrid5.TabStop = false;
            // 
            // chartPlot
            // 
            this.chartPlot.BackColor = System.Drawing.Color.White;
            this.chartPlot.BarLabelColor = System.Drawing.Color.Navy;
            this.chartPlot.BarLabelFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chartPlot.BGColor1 = System.Drawing.Color.White;
            this.chartPlot.BGColor2 = System.Drawing.Color.White;
            this.chartPlot.BGImage = null;
            this.chartPlot.BGImageTransparentValue = 128;
            this.chartPlot.BGLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.chartPlot.ChartStyle = LDChartControlPlus.ChartStyle.StyleNormal;
            this.chartPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPlot.EndDateStepValueX = new System.DateTime(2008, 8, 24, 23, 59, 59, 0);
            this.chartPlot.GridBGColor = System.Drawing.Color.GhostWhite;
            this.chartPlot.GridColor = System.Drawing.Color.DarkGray;
            this.chartPlot.GridDashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.chartPlot.GridLineColor = System.Drawing.Color.Black;
            this.chartPlot.LabelStepValueX = new string[] {
        "JAN",
        "FEV",
        "MAR",
        "ABR",
        "MAI",
        "JUN",
        "JUL",
        "AGO",
        "SET",
        "OUT",
        "NOV",
        "DEZ"};
            this.chartPlot.LegendX = "Legenda X";
            this.chartPlot.LegendXColor = System.Drawing.Color.SteelBlue;
            this.chartPlot.LegendXFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chartPlot.LegendY = "Legenda Y";
            this.chartPlot.LegendYColor = System.Drawing.Color.Black;
            this.chartPlot.LegendYFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chartPlot.Location = new System.Drawing.Point(3, 3);
            this.chartPlot.MaxCountCharLineLabelX = 20;
            this.chartPlot.MaxStepValueX = 12;
            this.chartPlot.MaxValueY = 100;
            this.chartPlot.MinStepValueX = 1;
            this.chartPlot.Month = 1;
            this.chartPlot.Name = "chartPlot";
            this.chartPlot.PlotStepXType = LDChartControlPlus.PlotStepXType.Number;
            this.chartPlot.RotateLabelStepValueX = 0;
            this.chartPlot.ShowGridX = true;
            this.chartPlot.ShowGridY = true;
            this.chartPlot.ShowHighlightValue = true;
            this.chartPlot.ShowLabelStepValueX = true;
            this.chartPlot.ShowLegendX = false;
            this.chartPlot.ShowLegendY = false;
            this.chartPlot.ShowTitle = false;
            this.chartPlot.ShowTotalValue = false;
            this.chartPlot.Size = new System.Drawing.Size(727, 426);
            this.chartPlot.StartDateStepValueX = new System.DateTime(2008, 7, 25, 0, 0, 0, 0);
            this.chartPlot.StepColorValueX = System.Drawing.Color.SteelBlue;
            this.chartPlot.StepColorValueY = System.Drawing.Color.Maroon;
            this.chartPlot.StepValueX = 1;
            this.chartPlot.StepValueXFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chartPlot.StepValueY = 10;
            this.chartPlot.TabIndex = 1;
            this.chartPlot.Title = "Título";
            this.chartPlot.TitleColor = System.Drawing.Color.SteelBlue;
            this.chartPlot.TitleFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPlot.Year = 2008;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartPlot);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gráfico";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.propertyGrid1);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(733, 432);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Propriedade MS Chart";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.msChartLine;
            this.propertyGrid1.Size = new System.Drawing.Size(727, 426);
            this.propertyGrid1.TabIndex = 16;
            this.propertyGrid1.TabStop = false;
            // 
            // msChartLine
            // 
            this.msChartLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.msChartLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.msChartLine.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.msChartLine.BorderSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.msChartLine.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.msChartLine.BorderSkin.BorderWidth = 2;
            this.msChartLine.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.SteelBlue;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Maroon;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackColor = System.Drawing.Color.GhostWhite;
            chartArea1.Name = "ChartArea1";
            this.msChartLine.ChartAreas.Add(chartArea1);
            this.msChartLine.IsSoftShadows = false;
            this.msChartLine.Location = new System.Drawing.Point(9, 36);
            this.msChartLine.Name = "msChartLine";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.CustomProperties = "MinimumRelativePieSize=20, PieDrawingStyle=Concave, EmptyPointValue=Zero, LabelSt" +
                "yle=Top";
            series1.EmptyPointStyle.IsValueShownAsLabel = true;
            series1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsXValueIndexed = true;
            series1.Label = "#VAL{N0}";
            series1.LabelBackColor = System.Drawing.Color.Ivory;
            series1.LabelBorderColor = System.Drawing.Color.SteelBlue;
            series1.LabelForeColor = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.LegendText = "#LEGENDTEXT";
            series1.MarkerBorderColor = System.Drawing.Color.Blue;
            series1.MarkerColor = System.Drawing.Color.SteelBlue;
            series1.MarkerSize = 6;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            dataPoint1.AxisLabel = "JAN";
            dataPoint1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            dataPoint1.IsValueShownAsLabel = false;
            dataPoint1.IsVisibleInLegend = true;
            dataPoint1.Label = "#VAL{N0}";
            dataPoint1.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint1.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint1.LegendText = "";
            dataPoint2.AxisLabel = "FEV";
            dataPoint2.IsValueShownAsLabel = false;
            dataPoint2.Label = "#VAL{N0}";
            dataPoint2.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint2.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint2.LegendText = "";
            dataPoint3.AxisLabel = "MAR";
            dataPoint3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.None;
            dataPoint3.IsValueShownAsLabel = false;
            dataPoint3.IsVisibleInLegend = true;
            dataPoint3.Label = "#VAL{N0}";
            dataPoint3.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint3.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint3.LegendText = "";
            dataPoint4.AxisLabel = "ABR";
            dataPoint4.IsValueShownAsLabel = false;
            dataPoint4.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint4.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint4.LegendText = "";
            dataPoint5.AxisLabel = "MAI";
            dataPoint5.IsValueShownAsLabel = false;
            dataPoint5.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint5.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint5.LegendText = "";
            dataPoint6.AxisLabel = "JUN";
            dataPoint6.IsValueShownAsLabel = false;
            dataPoint6.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint6.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint6.LegendText = "";
            dataPoint7.AxisLabel = "JUL";
            dataPoint7.IsValueShownAsLabel = false;
            dataPoint7.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint7.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint7.LegendText = "";
            dataPoint8.AxisLabel = "AGO";
            dataPoint8.IsValueShownAsLabel = false;
            dataPoint8.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint8.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint8.LegendText = "";
            dataPoint9.AxisLabel = "SET";
            dataPoint9.IsValueShownAsLabel = false;
            dataPoint9.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint9.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint9.LegendText = "";
            dataPoint10.AxisLabel = "OUT";
            dataPoint10.IsValueShownAsLabel = false;
            dataPoint10.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint10.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint10.LegendText = "";
            dataPoint11.AxisLabel = "NOV";
            dataPoint11.IsValueShownAsLabel = false;
            dataPoint11.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint11.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint11.LegendText = "";
            dataPoint12.AxisLabel = "DEZ";
            dataPoint12.IsValueShownAsLabel = false;
            dataPoint12.LabelBackColor = System.Drawing.Color.Ivory;
            dataPoint12.LabelBorderColor = System.Drawing.Color.SteelBlue;
            dataPoint12.LegendText = "";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            series1.Points.Add(dataPoint9);
            series1.Points.Add(dataPoint10);
            series1.Points.Add(dataPoint11);
            series1.Points.Add(dataPoint12);
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.msChartLine.Series.Add(series1);
            this.msChartLine.Size = new System.Drawing.Size(714, 387);
            this.msChartLine.TabIndex = 1;
            this.msChartLine.Text = "chart1";
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(109)))));
            title1.Name = "TitleTop";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Titulo";
            this.msChartLine.Titles.Add(title1);
            this.msChartLine.DoubleClick += new System.EventHandler(this.msChartLine_DoubleClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.txtTituloMSChart);
            this.tabPage5.Controls.Add(this.msChartLine);
            this.tabPage5.ImageIndex = 1;
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(733, 432);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gráfico MS Chart";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PropertiesC#.ico");
            this.imageList1.Images.SetKeyName(1, "grafico_plot.ico");
            // 
            // txtTituloMSChart
            // 
            this.txtTituloMSChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTituloMSChart.ForeColor = System.Drawing.Color.Blue;
            this.txtTituloMSChart.Location = new System.Drawing.Point(49, 10);
            this.txtTituloMSChart.Name = "txtTituloMSChart";
            this.txtTituloMSChart.Size = new System.Drawing.Size(674, 20);
            this.txtTituloMSChart.TabIndex = 2;
            this.txtTituloMSChart.TextChanged += new System.EventHandler(this.txtTituloMSChart_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Título:";
            // 
            // frmGraficoPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 459);
            this.Controls.Add(this.tbcGrafico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGraficoPlot";
            this.Text = "Gráfico Plot";
            this.Load += new System.EventHandler(this.frmGraficoPlot_Load);
            this.tbcGrafico.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.pnlTotalMes.ResumeLayout(false);
            this.pnlTotalMes.PerformLayout();
            this.pnlPorDia.ResumeLayout(false);
            this.pnlPorDia.PerformLayout();
            this.gpbWhere.ResumeLayout(false);
            this.gpbWhere.PerformLayout();
            this.gpbQuery.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msChartLine)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcGrafico;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PropertyGrid propertyGrid5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gpbQuery;
        private System.Windows.Forms.Button btnFill;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwCampos;
        internal System.Windows.Forms.GroupBox gpbWhere;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label Where_lblValor;
        private System.Windows.Forms.Button Where_btnRemoverTodos;
        private System.Windows.Forms.Button Where_btnRemoverUm;
        private System.Windows.Forms.Button Where_btnInserirUm;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwWhere;
        private System.Windows.Forms.ColumnHeader clhWhereColumn;
        private System.Windows.Forms.ColumnHeader clhColumnName;
        private LDChartControlPlus.ChartPlot chartPlot;
        internal System.Windows.Forms.GroupBox gpbSelect;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.Button Select_btnInserirUm;
        private System.Windows.Forms.ComboBox cboTipoValue;
        private System.Windows.Forms.RadioButton rdbTotalAno;
        private System.Windows.Forms.RadioButton rdbTotalMes;
        private System.Windows.Forms.RadioButton rdbTotalPorHora;
        private System.Windows.Forms.RadioButton rdbTotalPorDia;
        private System.Windows.Forms.Panel pnlTotalMes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAno_TotalMes;
        private System.Windows.Forms.Panel pnlPorDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAno;
        private System.Windows.Forms.DateTimePicker dtpTotalPorHora;
        private System.Windows.Forms.ColumnHeader clhColumnIsDate;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataVisualization.Charting.Chart msChartLine;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloMSChart;
    }
}