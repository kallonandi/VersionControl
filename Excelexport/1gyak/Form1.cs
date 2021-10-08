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

        public Form1()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.DataSource = Flats;



        }
        private void LoadData()
        {
            Flats = context.Flat.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'realEstateDataSet.Flat' table. You can move, or remove it, as needed.
            this.flatTableAdapter.Fill(this.realEstateDataSet.Flat);

        }
    }
}
