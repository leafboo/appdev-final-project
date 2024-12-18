using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _046_caranguian_pattaguan_F2
{

    public partial class frmPirateGroups : Form
    {
        string query;
        string connectionString = ("server=localhost; database=dbpirates; pwd=1234; uid=root; port=3306");
        MySqlConnection conn;
        DataTable dt = new DataTable();

        public frmPirateGroups()
        {
            InitializeComponent();
        }

        private void cboCRUD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPirateGroupId.Enabled = false;
            txtPirateGroupName.Enabled = false;
            txtShipName.Enabled = false;

            if (cboCRUD.SelectedIndex == 0) // Create
            {
                txtPirateGroupName.Enabled = true;
                txtShipName.Enabled = true;
            }
            else if (cboCRUD.SelectedIndex == 1) // Read
            {
                txtPirateGroupId.Enabled = true;
            }
            else if (cboCRUD.SelectedIndex == 2) // Update
            {
                txtPirateGroupId.Enabled= true;
                txtPirateGroupName.Enabled = true;
                txtShipName.Enabled = true;
            }
        }

        private void frmPirateGroups_Load(object sender, EventArgs e)
        {
            selectAll();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            

            if (cboCRUD.SelectedIndex == 0) // Create
            {
                create();
                selectAll();
            }
            else if (cboCRUD.SelectedIndex == 1) // Read
            {
                read();
                clearAllInputFields();
            }
            else if (cboCRUD.SelectedIndex == 2) // Update
            {
                update();
                selectAll();
            }
        }

        void selectAll()
        {
            dt.Clear();
            dtgPirateGroups.DataSource = null;

            query = "SELECT * FROM pirategroup";

            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();
            dtgPirateGroups.DataSource = dt;

            clearAllInputFields();
            
        }

        void clearAllInputFields()
        {
            txtPirateGroupId.Clear();
            txtPirateGroupName.Clear();
            txtShipName.Clear();
            cboCRUD.SelectedIndex = -1;
        }

        void create()
        {
            query = ($"INSERT INTO pirategroup(prgname, shipname) VALUES('{txtPirateGroupName.Text}', '{txtShipName.Text}')");
            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        void read()
        {
            dt.Clear();
            dtgPirateGroups.DataSource = null;

            query = ($"SELECT prgname, shipname FROM pirategroup WHERE prgid={txtPirateGroupId.Text}");
            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();

            dtgPirateGroups.DataSource= dt;
        }

        void update()
        {
            query = ($@"UPDATE pirategroup SET prgname='{txtPirateGroupName.Text}', 
                        shipname='{txtShipName.Text}' WHERE prgid={txtPirateGroupId.Text}");
            conn = new MySqlConnection(connectionString);

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            selectAll();
        }
    }
}
