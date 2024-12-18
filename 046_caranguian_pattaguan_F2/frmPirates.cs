using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _046_caranguian_pattaguan_F2
{
    public partial class frmPirates : Form
    {
        string connectionString = "server=localhost; database=dbpirates; pwd=1234; uid=root; port=3306";
        string query;
        MySqlConnection conn;
        DataTable dt = new DataTable();
        string state;

        public frmPirates()
        {
            InitializeComponent();
        }

        private void pirateGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPirateGroups pirateGroups = new frmPirateGroups();
            pirateGroups.ShowDialog();
        }

        private void frmPirates_Load(object sender, EventArgs e)
        {
            selectAll();

            disable();


            //populate combobox
            query = "SELECT prgname FROM pirategroup";
            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboGroup.Items.Add(dr["prgname"].ToString());
                cboPrtGrp.Items.Add(dr["prgname"].ToString());
            }

            dr.Close();
            conn.Close();
        }

        void disable()
        {
            txtCrewId.Enabled = false;
            txtAlias.Enabled = false;
            txtAge.Enabled = false;
            txtBounty.Enabled = false;
            txtName.Enabled = false;
            cboPrtGrp.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text) || string.IsNullOrEmpty(cboGroup.Text))
            {
                MessageBox.Show("All input fields are required!");
            }
            else
            {
                dt = new DataTable();

                query = "SELECT piratename, givenname, prgname, bounty, age FROM crew c JOIN pirategroup p ON c.prgid = p.prgid WHERE piratename = '" + txtSearch.Text + "' OR givenname = '" + txtSearch.Text + "'";
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
                dtgRecord.DataSource = dt;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            state = "update";

            txtAlias.Text = dtgRecord.SelectedCells[0].Value.ToString();
            txtName.Text = dtgRecord.SelectedCells[1].Value.ToString();
            cboPrtGrp.Text = dtgRecord.SelectedCells[2].Value.ToString();
            txtBounty.Text = dtgRecord.SelectedCells[3].Value.ToString();
            txtAge.Text = dtgRecord.CurrentRow.Cells["age"].Value.ToString();


            txtCrewId.Enabled = true;
            txtAlias.Enabled = true;
            txtAge.Enabled = true;
            txtBounty.Enabled = true;
            txtName.Enabled = true;
            cboPrtGrp.Enabled = true;
            btnSave.Enabled = true;
            btnNewRec.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            if (state == "create") // for creating new record
            {
                if (string.IsNullOrEmpty(txtAlias.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(txtBounty.Text) || string.IsNullOrEmpty(cboPrtGrp.Text))
                {
                    MessageBox.Show("All input fields are required!");
                }
                else
                {
                    query = "INSERT INTO crew (piratename, givenname, age, bounty,prgid) VALUES('" + txtAlias.Text + "', '" + txtName.Text + "', '" + txtAge.Text + "', '" + txtBounty.Text + "', '" + cboPrtGrp.SelectedIndex + "')";
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    selectAll();

                    btnNewRec.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            else if (state == "update") // for updating record
            {
                // This gets the id of the updated pirate goup name 
                query = "select prgid from pirategroup where prgname = '" + cboPrtGrp.SelectedItem.ToString() + "'";
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand mdc = new MySqlCommand(query, conn);
                int result = (int)mdc.ExecuteScalar();
                conn.Close();

                
                query = "update crew set piratename = '" + txtAlias.Text + "', givenname = '" + txtName.Text + "', age = '" + txtAge.Text + "', prgid = '" + result.ToString() + "',bounty = '" + txtBounty.Text + "' where crewid = '" + txtCrewId.Text + "'";
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                selectAll();
                btnNewRec.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgRecord.SelectedRows.Count > 0)
            {
                query = ($"DELETE FROM crew WHERE piratename='{dtgRecord.SelectedCells[0].Value.ToString()}'");
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand( query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                selectAll();
            }
            else
            {
                MessageBox.Show("Please select a row to delete!!");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveText.Title = "Save as File";
            saveText.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveText.DefaultExt = "txt";
            saveText.Filter = "(*.*)|*.*|Text File(*.txt)|*.txt";
            saveText.FilterIndex = 2;

            if (saveText.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = File.CreateText(saveText.FileName))
                {
                    for (int i = 0; i < dtgRecord.Rows.Count - 1; i++)
                    {
                       
                        writer.WriteLine(dtgRecord.Rows[i].Cells["ALIAS"].Value.ToString());

                        writer.WriteLine(dtgRecord.Rows[i].Cells["NAME"].Value.ToString());

                        writer.WriteLine(dtgRecord.Rows[i].Cells["PIRATEGROUP"].Value.ToString());

                        writer.WriteLine(dtgRecord.Rows[i].Cells["BOUNTY"].Value.ToString() + "\n");

                    }
                }

            }
        }

        private void btnNewRec_Click(object sender, EventArgs e)
        {
            state = "create";

            txtCrewId.Enabled = false;
            txtAlias.Enabled = true;
            txtAge.Enabled = true;
            txtBounty.Enabled = true;
            txtName.Enabled = true;
            cboPrtGrp.Enabled = true;
            btnSave.Enabled = true;
            btnNewRec.Enabled = false;

        }

        void selectAll()
        {
            dt.Clear();
            dtgRecord.DataSource = null;

            query = "select piratename as ALIAS, givenname as NAME, prgname as PIRATEGROUP, bounty as BOUNTY, age from crew c join pirategroup p on c.prgid = p.prgid";

            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();
            dtgRecord.DataSource = dt;

            dtgRecord.Columns["age"].Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            state = "default";

            txtCrewId.Clear();
            txtAlias.Clear();
            txtName.Clear();
            txtAge.Clear();
            cboPrtGrp.SelectedIndex = -1;
            txtBounty.Clear();

            txtCrewId.Enabled = false;
            txtAlias.Enabled = false;
            txtName.Enabled = false;
            txtAge.Enabled = false;
            cboGroup.Enabled = false;
            txtBounty.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}
