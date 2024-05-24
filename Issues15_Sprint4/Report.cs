using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanTraiCay
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        string strcon = @"Data Source=LAPTOP-9SBLPHER;Initial Catalog=Quanlybantraicay3;Integrated Security=True";
        SqlConnection SqlCon = null;

       

        private void Report_Load(object sender, EventArgs e)
        {
            if (SqlCon == null)
            {
                SqlCon = new SqlConnection(strcon);
            }
            string sql = "select * from tblChitietHDBan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, SqlCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HoaDon");

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanTraiCay.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["HoaDon"];

            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
