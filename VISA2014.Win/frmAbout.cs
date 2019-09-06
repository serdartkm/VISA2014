using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoxLearn.License;

namespace LisenceKey
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        const int ProductCode = 1;
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lbProductID.Text = ComputerInfo.GetComputerId();
            KeyManager km = new KeyManager(lbProductID.Text);
            LicenseInfo lic = new LicenseInfo();
            

            km.LoadSuretyFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Key.lic", ref lic);
            string productKey = lic.ProductKey;
            if (km.ValidKey(ref productKey)) {

                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv)) {
                    lbProductName.Text = "VISA";
                    lbProductKey.Text = productKey;
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lbLicenseType.Text = string.Format("{0} days", (kv.Expiration - DateTime.Now.Date).Days);

                    }
                    else
                    {
                        lbLicenseType.Text = "Full";
                    }
                }
            }
        }

        private void frmAbout_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {

                Form1 frm = new Form1();
                frm.Show();

            }
        }

      
    }
}
