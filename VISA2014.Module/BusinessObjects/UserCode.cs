using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using LogicNP.CryptoLicensing;

namespace VISA2014.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class UserCode : BaseObject
    {
        public UserCode(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here or place it only when the IsLoading property is false:
            // if (!IsLoading){
            //    It is now OK to place your initialization code here.
            // }
            // or as an alternative, move your initialization code into the AfterConstruction method.
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            CryptoLicense license = new CryptoLicense();
            // Place here your initialization code.

            Code = license.GetLocalMachineCodeAsString();
        }


        //// Fields...

        private string code;
     
        


        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                SetPropertyValue("Code", ref code, value);
            }
        }




      
  


    }

}
