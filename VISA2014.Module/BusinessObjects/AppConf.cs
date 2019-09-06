using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace VISA2014.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(true, GroupName = "Configuration")]
    public class AppConf : BaseObject
    {
        public AppConf(Session session)
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
            // Place here your initialization code.
        }


        //// Fields...

     
        private string fileLocation;
        private string agreement;
        private int workPermitExpireDate;
        private int addressExpireDay;
        private int passportExpireDay;
        private int visaExpireDay;
        private int totalPreviousRegisteredDoc;
        private DateTime startDate;
        private int startNumber;
        private int iD;
        private bool useCompanyLogo;
        private bool inRussian;
        private bool inTurkmen;

        public bool InTurkmen
        {
            get
            {
                return inTurkmen;
            }
            set
            {
                SetPropertyValue("InTurkmen", ref inTurkmen, value);
            }
        }

        public int StartNumber
        {
            get
            {
                return startNumber;
            }
            set
            {
                SetPropertyValue("StartNumber", ref startNumber, value);
            }
        }
        public bool InRussian
        {
            get
            {
                return inRussian;
            }
            set
            {
                SetPropertyValue("InRussian", ref inRussian, value);
            }
        }



        public bool UseCompanyLogo
        {
            get
            {
                return useCompanyLogo;
            }
            set
            {
                SetPropertyValue("UseCompanyLogo", ref useCompanyLogo, value);
            }
        }


        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                SetPropertyValue("ID", ref iD, value);
            }
        }



        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                SetPropertyValue("StartDate", ref startDate, value);
            }
        }



        public int VisaExpireDay
        {
            get
            {
                return visaExpireDay;
            }
            set
            {
                SetPropertyValue("VisaExpireDay", ref visaExpireDay, value);
            }
        }




        public int PassportExpireDay
        {
            get
            {
                return passportExpireDay;
            }
            set
            {
                SetPropertyValue("PassportExpireDay", ref passportExpireDay, value);
            }
        }


        public int WorkPermitExpireDate
        {
            get
            {
                return workPermitExpireDate;
            }
            set
            {
                SetPropertyValue("WorkPermitExpireDate", ref workPermitExpireDate, value);
            }
        }




        public int AddressExpireDay
        {
            get
            {
                return addressExpireDay;
            }
            set
            {
                SetPropertyValue("AddressExpireDay", ref addressExpireDay, value);
            }
        }





        public int TotalPreviousRegisteredDoc
        {
            get
            {
                return totalPreviousRegisteredDoc;
            }
            set
            {
                SetPropertyValue("TotalPreviousRegisteredDoc", ref totalPreviousRegisteredDoc, value);
            }
        }

        [Browsable (false)]
        public string Agreement
        {
            get
            {
                return agreement;
            }
            set
            {
                SetPropertyValue("Agreement", ref agreement, value);
            }
        }


        public string Messge
        {
            get
            {

                if (Agreement != "NgAAALu5wD+u3c0BuzklOEH1zQE02jdcMX01vjrUg6Rr2OXueb6B/Ta0tNBqjgLhwTDhornYXmlQ6R8a4+Nhx2j9WvE=")
                {
                    return "This product is not licenced . To purchase this product  contact the product owner. Phone: 864010359 - Turkmenistan";
                }
                else return null;
               
            }
           
        }



        public string FileLocation
        {
            get
            {
                return fileLocation;
            }
            set
            {
                SetPropertyValue("FileLocation", ref fileLocation, value);
            }
        }

    }

}
