using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using VISA2014.Module.DC;

namespace VISA2014.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(true, GroupName = "Configuration")]
    [DefaultProperty("PreferedVisaCategoryEnum")]
    public class PrefferedVisaCategory : BaseObject
    {
        public PrefferedVisaCategory(Session session)
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

        private string preferredVisaCategoryR;
        private string preferredVisaCategoryL;
        private PreferedVisaCategoryEnum preferedVisaCategoryEnum;

        public PreferedVisaCategoryEnum PreferedVisaCategoryEnum
        {
            get
            {
                return preferedVisaCategoryEnum;
            }
            set
            {
                SetPropertyValue("PreferedVisaCategoryEnum", ref preferedVisaCategoryEnum, value);
            }
        }



        public string PreferredVisaCategoryL
        {
            get
            {
                return preferredVisaCategoryL;
            }
            set
            {
                SetPropertyValue("PreferredVisaCategoryL", ref preferredVisaCategoryL, value);
            }
        }


        public string PreferredVisaCategoryR
        {
            get
            {
                return preferredVisaCategoryR;
            }
            set
            {
                SetPropertyValue("PreferredVisaCategoryR", ref preferredVisaCategoryR, value);
            }
        }

    }

}
