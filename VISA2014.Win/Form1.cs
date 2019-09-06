using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VISA2014.Win;

namespace LisenceKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (frmGenerate frm = new frmGenerate())
            {
                frm.ShowDialog();
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            using (frmRegistration frm = new frmRegistration())
            {
                frm.ShowDialog();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSQLConnection_Click(object sender, EventArgs e)
        {
            using (frmSQLConnection frm = new frmSQLConnection())
            {
                frm.ShowDialog();
            }
        }
    }
}
