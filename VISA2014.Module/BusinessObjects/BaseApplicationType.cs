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
    [DefaultProperty("TypeOfBaseApplication")]
    public class BaseApplicationType : BaseObject
    {
        public BaseApplicationType(Session session)
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

        private bool isLongProcessApp;
        private AppType typeOfBaseApplication;

        public AppType TypeOfBaseApplication
        {
            get
            {
                return typeOfBaseApplication;
            }
            set
            {
                SetPropertyValue("TypeOfBaseApplication", ref typeOfBaseApplication, value);


               
            }
        }


        public bool IsLongProcessApp
        {
            get
            {
                return isLongProcessApp;
            }
            set
            {
                SetPropertyValue("IsLongProcessApp", ref isLongProcessApp, value);
            }
        }


        [Association("BaseApplicationType-ApplicationTypeForFamilyMembers")]
        public XPCollection<ApplicationTypeForFamilyMember> ApplicationTypeForFamilyMembers
        {
            get
            {
                return GetCollection<ApplicationTypeForFamilyMember>("ApplicationTypeForFamilyMembers");
            }
        }


        [Association("BaseApplicationType-ApplicationTypeForEmployees")]
        public XPCollection<ApplicationTypeForEmployee> ApplicationTypeForEmployees
        {
            get
            {
                return GetCollection<ApplicationTypeForEmployee>("ApplicationTypeForEmployees");
            }
        }
    }

}
