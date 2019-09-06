using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VISA2014.Win
{
    public partial class frmSQLConnection : Form
    {
        public frmSQLConnection()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            //create a new key 
            key.CreateSubKey("sqlConnection");
           


           RegistryKey keyValues = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\sqlConnection", true);

            //adding/editing a value 
           keyValues.SetValue("ip", txtIp.Text); //sets 'someData' in 'someValue' 
           keyValues.SetValue("userName", txtUserName.Text);
           keyValues.SetValue("password", txtPassword.Text);
           keyValues.SetValue("databaseName", txtDatabaseName.Text);
           key.Close();

           keyValues.Close();
           this.Close();
        }

        private void frmSQLConnection_Load(object sender, EventArgs e)
        {
        RegistryKey keyValues = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\sqlConnection", true);
           // string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run\sqlConnection";
            if (keyValues!=null && keyValues.ValueCount>0)
            {

                //getting the value
               // if (keyValues.GetValue("ip") != null) {
                    txtIp.Text = keyValues.GetValue("ip").ToString();  //returns the text found in 'someValue'
                    txtUserName.Text = keyValues.GetValue("userName").ToString();
                    txtPassword.Text = keyValues.GetValue("password").ToString();
                    txtDatabaseName.Text = keyValues.GetValue("databaseName").ToString();
                
             //   }
            

                keyValues.Close();
            }


            


        }
    }
}

