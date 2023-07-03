using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LDChartControlPlus;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using DBTools.classes;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms.graficos
{
    public partial class frmGraficoPlot : Form
    {
        private enum PlotType
	    {
            PorHora         = 1,
            PorDia          = 2,
            PorMes          = 3,
            PorAno          = 4
	    }

        private bool		formLoad		= false;
        private PlotType	m_plotType;
        private string		m_objectFrom	= string.Empty;
 
        public frmGraficoPlot(object item, SqlObjectsClass so)
        {
            InitializeComponent();

            Columns columns = new Columns();

            try
            {
                if(item is Table)
                {
                    Table table = (Table)item; 

                    m_objectFrom = table.Name;  

                    columns = so.GetColumns(table); 
                }
                else if(item is DBTools.classes.ObjectsClass.View)
                {
                    DBTools.classes.ObjectsClass.View view = (DBTools.classes.ObjectsClass.View)item; 

                    m_objectFrom = view.Name;  

                    columns = so.GetColumns(view); 
                }

                for (int i = 0; i < columns.Count; i++)
                { 
                    ArrayList aDados = new ArrayList();  

                    bool isDateTime = false;
                    Color foreColor = Color.Blue;  

                    if(columns[i].DataType.SqlDataType == SqlDataType.DateTime)
                    {
                        foreColor   = Color.Maroon; 
                        isDateTime  = true;
                    }

                    aDados.Add(columns[i].Name);  
                    aDados.Add(isDateTime.ToString());

                    lvwCampos.Add(aDados, foreColor);  
                }

                int     indexMesAtual   = DateTime.Now.Month-1; 
                string  anoAtual        = DateTime.Now.ToString("yyyy"); 

                cboMes.SelectedIndex           = indexMesAtual;  
                cboAno.SelectedIndex           = cboAno.FindStringExact(anoAtual);  
                cboAno_TotalMes.SelectedIndex  = cboAno_TotalMes.FindStringExact(anoAtual);  
 
                cboTipoValue.SelectedIndex = 0; 

                formLoad = true;

                RadioButton_CheckedChanged(rdbTotalPorHora, null);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

#region FORM

        private void frmGraficoPlot_Load(object sender, EventArgs e)
        {

        }

#endregion

#region EVENTOS

        private void Select_btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string columnName = lvwCampos.GetSelectedItem(0);

                txtSelect.Text = columnName;  
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            string dateField    = "";
            string descField    = "";
            string where        = "";
            string query_temp   = "";
            string query        = "";
            Dictionary<int, int> dicYears = new Dictionary<int,int>();  
            
           try
            {
                chartPlot.MaxValueY     = 100;
                chartPlot.StepValueY    = 10;

                int mes = cboMes.SelectedIndex + 1;
                int ano = int.Parse(cboAno.Text);

                Funcoes.ActvButton(ref btnFill);

                int yearNow     = 2005;
                int yearCount   = DateTime.Now.Year - yearNow; 

                for (int i = 0; i <= yearCount; i++)
                {
                    dicYears.Add(yearNow, i);
                    yearNow++;
                }

                for (int i = 0; i < msChartLine.Series[0].Points.Count; i++)
                {
                    msChartLine.Series[0].Points[i].IsValueShownAsLabel	= false;
                    msChartLine.Series[0].Points[i].Label				= "";
                    msChartLine.Series[0].Points[i].IsEmpty				= true;
                }

                switch (m_plotType)
                {
                    case PlotType.PorHora:
                        {
                            string data = dtpTotalPorHora.Value.ToString("MM/dd/yyyy");

                            query_temp =    "SELECT datepart(hour, {0}) AS Hora, count({0}) AS Total" +
                                            " FROM {1} " +
                                            " WHERE {0} BETWEEN '" + data + " 00:00:00' AND '" + data + " 23:59:59' {2}" +
                                            " GROUP BY DATEPART(hour, {0})" +
                                            " ORDER BY Hora";

                            descField = "Hora";
                            break;
                        }
                    case PlotType.PorDia:
                        {
                            string dataDe = mes.ToString() + "/01/" + ano.ToString() + " 00:00:00";
                            string dataAte = mes.ToString() + "/" + DateTime.DaysInMonth(ano, mes).ToString() + "/" + ano.ToString() + " 23:59:59";

                            query_temp =    "SELECT datepart(day, {0}) as Dia, datepart(month, {0}) as Mes, " +
                                            " datepart(year, {0}) as Ano, count({0}) as Total " +
                                            " FROM {1} " +
                                            " WHERE {0} BETWEEN '" + dataDe + "' AND '" + dataAte + "' {2}" +
                                            " GROUP BY DATEPART(day, {0}), DATEPART(month, {0}), DATEPART(year, {0}) " +
                                            " ORDER BY Ano, Mes, Dia";

                            descField = "Dia";
                            break;
                        }
                    case PlotType.PorMes:
                        {
                            int anoTotalMes = int.Parse(cboAno_TotalMes.Text);

                            string dataDe   = "01/01/" + anoTotalMes.ToString() + " 00:00:00";
                            string dataAte  = "12/31/" + anoTotalMes.ToString() + " 23:59:59";

                            query_temp =    "SELECT datepart(month, {0}) as Mes, count({0}) as Total " +
                                            " FROM {1} " +
                                            " WHERE {0} BETWEEN '" + dataDe + "' AND '" + dataAte + "' {2}" +
                                            " GROUP BY DATEPART(month, {0}) " +
                                            " ORDER BY Mes";

                            descField = "Mes";
                            break;
                        }
                    case PlotType.PorAno:
                        {
                            string dataDe   = "01/01/2005 00:00:00";
                            string dataAte  = "12/31/" + DateTime.Now.Year.ToString() + " 23:59:59";

                            query_temp =    "SELECT datepart(year, {0}) as Ano, count({0}) as Total " +
                                            " FROM {1} " +
                                            " WHERE {0} BETWEEN '" + dataDe + "' AND '" + dataAte + "' {2}" +
                                            " GROUP BY DATEPART(year, {0}) " +
                                            " ORDER BY Ano";

                            descField = "Ano";
                            break;
                        }
                }

                dateField = "[" + txtSelect.Text + "]";

                for (int i = 0; i < lvwWhere.Items.Count; i++)
                {
                    where += " AND ";
                    where += " " + lvwWhere.GetItem(i, 0) + " ";
                }

                query = string.Format(query_temp, dateField, m_objectFrom, where);

                chartPlot.ClearItems(); 

                DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query);

                List<LDChartControlPlus.ItemsChartPlot> lstplotItemsChart   = new List<LDChartControlPlus.ItemsChartPlot>();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int field   = Convert.ToInt32(dt.Rows[i][descField]);
                    int total   = Convert.ToInt32(dt.Rows[i]["Total"]);
                    int indexY  = 0;

                    LDChartControlPlus.ItemsChartPlot itemsChart = new LDChartControlPlus.ItemsChartPlot();

                    itemsChart.ValueColor   = Color.SteelBlue;
                    
                    switch (m_plotType)
                    {
                        case PlotType.PorHora:
                            {
                                itemsChart.Number   = field+1;
                                indexY              = field; 
                                break;
                            }
                        case PlotType.PorDia:
                        case PlotType.PorMes:
                            {
                                itemsChart.Number   = field;
                                indexY              = field-1; 
                                break;
                            }
                        case PlotType.PorAno:
                            {
                                itemsChart.Number   = field - 2004;
                                indexY              = dicYears[field];
                                break;
                            }
                    }

                    itemsChart.Value        = total;

                    // MS Chart Control
                    if(total > 0)
                    {
                        msChartLine.Series[0].Points[indexY].IsEmpty    = false;
                        msChartLine.Series[0].Points[indexY].Label      = "#VAL{N0}";
                        msChartLine.Series[0].Points[indexY].YValues[0] = total;
                    }
                    else
                    {
                        msChartLine.Series[0].Points[indexY].IsEmpty    = true;
                        msChartLine.Series[0].Points[indexY].YValues[0] = total;
                    }

                    lstplotItemsChart.Add(itemsChart);
                }

                chartPlot.AddItems(lstplotItemsChart);

               tbcGrafico.SelectedIndex = 2;
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ActvButton(ref btnFill);
            }
        }
        private void Where_btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string columnName = lvwCampos.GetSelectedItem(0);

                ArrayList aDados = new ArrayList();

                aDados.Add(columnName + " " + cboTipoValue.Text + " " + txtValor.Text.Trim());
                
                lvwWhere.Add(aDados);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Where_btnRemoverUm_Click(object sender, EventArgs e)
        {
            try
            {
                lvwWhere.SelectedItems[0].Remove();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Where_btnRemoverTodos_Click(object sender, EventArgs e)
        {
            lvwWhere.Items.Clear();  
        }
        private void cboTipoValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipoValue.Text)
            {
                //case "=":
                //case ">": 
                //case "<":
                //case "<>":
                //case ">=":
                //case "<=":
                //case "LIKE":
                //case "IN":
                //case "NOT IN":
                //    {
                //        txtValor.ReadOnly = false; 
                //        break;
                //    }
                case "IS NULL":
                case "IS NOT NULL":
                    {
                        txtValor.Clear(); 
                        txtValor.ReadOnly = true; 
                        break;
                    }
                default:
                    {
                        txtValor.ReadOnly = false; 
                        break;
                    }
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(formLoad == false){return;}

            chartPlot.ClearItems();
            msChartLine.Series[0].Points.Clear(); 
            msChartLine.ChartAreas[0].AxisX.StripLines.Clear(); 

            dtpTotalPorHora.Visible         = false;
            pnlPorDia.Visible               = false;
            pnlTotalMes.Visible             = false;
            chartPlot.ShowLabelStepValueX   = false;

            RadioButton radioButton = sender as RadioButton;

            m_plotType = (PlotType)Convert.ToInt32(radioButton.Tag);

            int mes = cboMes.SelectedIndex + 1;
            int ano = int.Parse(cboAno.Text); 

            switch (m_plotType)
            {
                case PlotType.PorHora:
                    {
                        #region Por Hora

                        #region LDChartControl
                        chartPlot.MaxValueY             = 100;
                        chartPlot.StepValueY            = 10;
                        chartPlot.MinStepValueX         = 1;
                        chartPlot.PlotStepXType         = LDChartControlPlus.PlotStepXType.Hour;  
                        chartPlot.Title                 = "Total de ??? - Por Hora do dia " + dtpTotalPorHora.Text;  
                        chartPlot.ShowTitle             = true;
                        chartPlot.Visible               = true; 
                        dtpTotalPorHora.Visible         = true;
                        #endregion

                        #region MS Chart

                        msChartLine.Titles[0].Text = "Total de ??? - Por Hora do dia " + dtpTotalPorHora.Text; 

                        for (int i = 0; i <= 23; i++)
                        {
                            msChartLine.Series[0].Points.AddXY(i, 0);
                            msChartLine.Series[0].Points[i].Label       = string.Empty;
                            msChartLine.Series[0].Points[i].AxisLabel   = i.ToString();
                            msChartLine.Series[0].Points[i].IsEmpty     = true;
                        }

                        #endregion

                        #endregion
                        break;
                    }
                case PlotType.PorDia:
                    {
                        #region Por Dia

                        #region LDChartControl
                        chartPlot.MaxValueY             = 350;
                        chartPlot.StepValueY            = 50;
                        chartPlot.MinStepValueX         = 1;
                        chartPlot.MaxStepValueX         = DateTime.DaysInMonth(ano, mes);
                        chartPlot.Visible               = true;
                        chartPlot.PlotStepXType         = LDChartControlPlus.PlotStepXType.Day;
                        chartPlot.Title                 = "Total de ??? - Por dia do Mês " + cboMes.Text + " de " + cboAno.Text;
                        chartPlot.Visible               = true; 
                        pnlPorDia.Visible               = true;
                        #endregion

                        #region MS Chart

                        msChartLine.Titles[0].Text = "Total de ??? - Por dia do Mês " + cboMes.Text + " de " + cboAno.Text;

                        for (int i = 0; i < chartPlot.MaxStepValueX; i++)
                        {
                            int dia = i + 1;

                            StripLine stripLine = new StripLine();
                            string siglaDayOfWeek = string.Empty;  

                            msChartLine.Series[0].Points.AddXY(i, 0);
                            msChartLine.Series[0].Points[i].Label       = string.Empty;
                            msChartLine.Series[0].Points[i].AxisLabel   = dia.ToString();
                            msChartLine.Series[0].Points[i].IsEmpty     = true;

                            DateTime dtmDay = new DateTime(ano, mes, dia);

                            stripLine.Font              = new Font("Trebuchet MS",9.75f, FontStyle.Bold);   
                            stripLine.ForeColor         = Color.Blue;
                            stripLine.IntervalOffset    = dia;
                            stripLine.TextAlignment     = StringAlignment.Center;
                            stripLine.TextLineAlignment = StringAlignment.Near;
                            stripLine.TextOrientation   = TextOrientation.Horizontal;  

                            switch (dtmDay.DayOfWeek)
                            {
                                case DayOfWeek.Saturday:
                                    siglaDayOfWeek              = "S";
                                    stripLine.ForeColor         = Color.Maroon;
                                    stripLine.TextLineAlignment = StringAlignment.Far;
                                    break;
                                case DayOfWeek.Sunday:
                                    siglaDayOfWeek              = "D";
                                    stripLine.TextLineAlignment = StringAlignment.Far;
                                    break;
                                case DayOfWeek.Monday:
                                    siglaDayOfWeek = "S";
                                    break;
                                case DayOfWeek.Tuesday:
                                    siglaDayOfWeek = "T";
                                    break;
                                case DayOfWeek.Wednesday:
                                    siglaDayOfWeek = "Q";
                                    break;
                                case DayOfWeek.Thursday:
                                    siglaDayOfWeek = "Q";
                                    break;
                                case DayOfWeek.Friday:
                                    siglaDayOfWeek = "S";
                                    break;
                            }

                            stripLine.Text = siglaDayOfWeek; 

                            msChartLine.ChartAreas[0].AxisX.StripLines.Add(stripLine);    
                        }

                        #endregion

                        #endregion
                        break;
                    }
                case PlotType.PorMes:
                    {
                        #region Por Mês

                        chartPlot.MaxValueY             = 3000;
                        chartPlot.StepValueY            = 300;
                        chartPlot.MinStepValueX         = 1;
                        chartPlot.LabelStepValueX       = new string[]{"JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ"};  
                        chartPlot.PlotStepXType         = LDChartControlPlus.PlotStepXType.Month;   
                        chartPlot.Visible               = true;
                        pnlTotalMes.Visible             = true;
                        chartPlot.Title                 = "Total de ??? - Total por Mês de " + cboAno_TotalMes.Text; 
                        chartPlot.ShowTitle             = true;
 
                        #region MS Chart

                        string[] arrayMes = {"JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ"};  

                        msChartLine.Titles[0].Text = "Total de ??? - Total por Mês de " + cboAno_TotalMes.Text; 

                        for (int i = 0; i < arrayMes.Length; i++)
                        {
                            msChartLine.Series[0].Points.AddXY(i, 0);
                            msChartLine.Series[0].Points[i].Label       = string.Empty;
                            msChartLine.Series[0].Points[i].AxisLabel   = arrayMes[i];
                            msChartLine.Series[0].Points[i].IsEmpty     = true;
                        }

                        #endregion
                        #endregion
                        break;
                    }
                case PlotType.PorAno:
                    {
                        #region Por Ano

                        chartPlot.MaxValueY             = 100;
                        chartPlot.StepValueY            = 10;
                        chartPlot.MinStepValueX         = 2005;
                        
                        int			yearNow			= DateTime.Now.Year;
                        int			yearCount		= yearNow - 2004;
                        string[]	labelStepValueX	= new string[yearCount];

                        chartPlot.MaxStepValueX     = yearCount;

                        yearNow = 2005;

                        for (int i = 0; i < yearCount; i++)
                        {
                            labelStepValueX[i] = yearNow.ToString();
                            yearNow++;
                        }
                        
                        //chartPlot.LabelStepValueX       = new string[]{"2005", "2006", "2007", "2008", "2009"};  
                        chartPlot.LabelStepValueX       = labelStepValueX; 
                        chartPlot.ShowLabelStepValueX   = true;
                        chartPlot.PlotStepXType         = LDChartControlPlus.PlotStepXType.Number;   
                        chartPlot.Visible               = true;
                        chartPlot.Title                 = "Total de ??? - Total por Ano"; 
                        chartPlot.ShowTitle             = true;
 
                        #region MS Chart

                        msChartLine.Titles[0].Text = "Total de ??? - Total por Ano"; 

                        yearNow     = 2005;
                        yearCount   = DateTime.Now.Year - yearNow; 

                        for (int i = 0; i <= yearCount; i++)
                        {
                            msChartLine.Series[0].Points.AddXY(i, 0);
                            msChartLine.Series[0].Points[i].Label       = string.Empty;
                            msChartLine.Series[0].Points[i].AxisLabel   = yearNow.ToString();
                            msChartLine.Series[0].Points[i].IsEmpty     = true;

                            yearNow++;
                        }

                        #endregion
                        #endregion
                        break;
                    }
            }

            txtTituloMSChart.Text = msChartLine.Titles[0].Text; 
        }
        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged(rdbTotalPorDia, null);
        }
        private void cboAno_TotalMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged(rdbTotalMes, null);
        }
        private void dtpTotalPorHora_ValueChanged(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged(rdbTotalPorHora, null);
        }
        private void lvwCampos_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDate = bool.Parse(lvwCampos.GetSelectedItem(1));
  
                Select_btnInserirUm.Enabled = isDate;
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void msChartLine_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(msChartLine.Width, msChartLine.Height);     

                msChartLine.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));    
                
                Clipboard.SetImage(bmp);

                MessageBox.Show("Imagem salva no clipboard do Windows." +
                                "\n\nObs: para colar basta clicar Ctrl+V.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void txtTituloMSChart_TextChanged(object sender, EventArgs e)
        {
            msChartLine.Titles[0].Text = txtTituloMSChart.Text;    
        }
#endregion




    }
}
