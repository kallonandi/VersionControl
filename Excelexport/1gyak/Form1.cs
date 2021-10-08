using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Excel= Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace _1gyak
{
    public partial class Form1 : Form

    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.DataSource = Flats;
            CreateExcel();


        }
        public void LoadData()
        {
            Flats = context.Flat.ToList();
        }

        public void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                CreateTable();




                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (System.Exception ex)
            {
                string hiba = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(hiba, "error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
           
        }

        private void CreateTable()
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'realEstateDataSet.Flat' table. You can move, or remove it, as needed.
            this.flatTableAdapter.Fill(this.realEstateDataSet.Flat);

        }
    }
}
