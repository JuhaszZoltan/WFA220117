using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA220117
{
    public partial class FrmUtas : Form
    {
        public FrmUtas()
        {
            InitializeComponent();
            Icon = Properties.Resources.utas;
        }

        private void FrmUtas_Load(object sender, EventArgs e)
        {
            string kDatum = Program.MaiDatum.ToString("yyyy-MM-01");
            string vDatum = Program.MaiDatum.AddMonths(2).ToString("yyyy-MM-01");

            using (var conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();

                var r = new SqlCommand(
                    "SELECT t_kod FROM tura " +
                    $"WHERE kezdet >= '{kDatum}' AND kezdet < '{vDatum}';",
                    conn).ExecuteReader();

                while (r.Read())
                {
                    cbJelentkezes.Items.Add(r[0]);
                }
            }
        }
    }
}
