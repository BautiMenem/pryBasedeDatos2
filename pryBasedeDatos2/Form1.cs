using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pryBasedeDatos2
{
    public partial class frmMain : Form
    {

        OleDbConnection ConnBase = null;
        OleDbCommand CmdBase = null;
        OleDbDataReader LectorBD = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            ConnBase = new OleDbConnection();
            ConnBase.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\VERDULEROS.mdb";
            ConnBase.Open();

            MessageBox.Show("Conectado a BD");
            btnConectar.BackColor = Color.Green;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            CmdBase = new OleDbCommand();
            CmdBase.Connection = ConnBase;
            CmdBase.CommandType = CommandType.TableDirect;
            CmdBase.CommandText = "Productos";
        
            LectorBD = CmdBase.ExecuteReader();

            while (LectorBD.Read())
            {
                dtvDatos.Rows.Add(LectorBD[0],LectorBD[1], LectorBD[2], LectorBD[3]);
               
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }

}
