using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class frmLog : Form
    {
        List<String> log;
        public frmLog(List<String> log)
        {
            this.log = log;
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Log", "Log");
            dataGridView1.Columns["Log"].DataPropertyName = "Value";
            dataGridView1.DataSource = log.Select(x => new { Value = x }).ToList();
        }
    }
}
