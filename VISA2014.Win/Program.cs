using System;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Collections.Generic;
using System.ComponentModel;

using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;

using DevExpress.Persistent.Validation;
using VISA2014.Module.BusinessObjects;
using LogicNP.CryptoLicensing;
using LisenceKey;
using FoxLearn.License;
using Microsoft.Win32;

namespace VISA2014.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if EASYTEST
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif

            Application.EnableVisualStyles();
           
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            VISA2014WindowsFormsApplication winApplication = new VISA2014WindowsFormsApplication();
            winApplication.SetFormattingCulture("tk-TM");
            
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif

            


//if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            //{
              //  winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                RegistryKey keyValues = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\sqlConnection", true);
                // string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run\sqlConnection";
                if (keyValues != null && keyValues.ValueCount > 0)
                {




                    try
                    {
                        string ip = keyValues.GetValue("ip").ToString();  //returns the text found in 'someValue'
                        string userName = keyValues.GetValue("userName").ToString();
                        string password = keyValues.GetValue("password").ToString();
                        string databaseName = keyValues.GetValue("databaseName").ToString();
                        string connectionString = "Data Source=" + ip + ";Initial Catalog=" + databaseName + ";User ID=" + userName + ";Password=" + password;
                        // MessageBox.Show(connectionString);
                        winApplication.ConnectionString = connectionString;
                        //Data Source=.\SQLEXPRESS;Initial Catalog=VISA2014;User ID=sa;Password=897200
                        keyValues.Close();
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message, "SQL error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else {

                    frmSQLConnection frmCon = new frmSQLConnection();
                    frmCon.ShowDialog();

                }
            
          //  }
            try
            {

                
                KeyManager km = new KeyManager(ComputerInfo.GetComputerId());
                LicenseInfo lic = new LicenseInfo();
           
                int value = km.LoadSuretyFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Key.lic", ref lic);
                string productKey = lic.ProductKey;
                if (km.ValidKey(ref productKey))
                {

                
                        frmAbout fm = new frmAbout();
                        fm.ShowDialog();

                        winApplication.Setup();
                        winApplication.Start();
                    
                  
                }

                else {
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                }
          
                   
                    
                

           
            }
            catch (Exception e)
            {
                winApplication.HandleException(e);
            }
        }

        /*
        private static CryptoLicense CreateLicense()
        {
            CryptoLicense ret = new CryptoLicense();

            //Uses the validation key of the "samples.netlicproj" license project file from the "Samples" directory
            // Get the validation key using Ctrl+K in the Generator UI.
            ret.ValidationKey = "BgIAAACkAABSU0ExgAEAAAEAAQB3G0c+AT9OnhMwwnpOLzVU4MSGG+2PRJ6Vrul76ddHxjrfMI2vaKLMP7sqE49teqE=";

            
            // *** IMPORTANT: Set the LicenseServiceURL property below to the URL of your license service
            // See video tutorial at http://www.ssware.com/cryptolicensing/demo/license_service_net.htm to learn 
            // how to create the license service
            ret.LicenseServiceURL = ""; // your license service URL here!

            return ret;
        }

       */
    }
}
