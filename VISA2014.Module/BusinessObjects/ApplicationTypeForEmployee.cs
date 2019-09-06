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
    [DefaultProperty("TypeOfApplicationForEmployee")]
    public class ApplicationTypeForEmployee : ApplicationType
    {
        public ApplicationTypeForEmployee(Session session)
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

       
        private int typeOfApplicationForEmployeeID;
        private BaseApplicationType baseApplicationType;
        private SubType typeOfApplicationForEmployee;

        [VisibleInListView(true)]
        public SubType TypeOfApplicationForEmployee
        {
            get
            {
                return typeOfApplicationForEmployee;
            }
            set
            {
                SetPropertyValue("TypeOfApplicationForEmployee", ref typeOfApplicationForEmployee, value);
            }
        }



        [Association("BaseApplicationType-ApplicationTypeForEmployees")]
        [VisibleInListView(true)]
        public BaseApplicationType BaseApplicationType
        {
            get
            {
                return baseApplicationType;
            }
            set
            {
                SetPropertyValue("BaseApplicationType", ref baseApplicationType, value);
            }
        }



        public int TypeOfApplicationForEmployeeID
        {
            get
            {
                return typeOfApplicationForEmployeeID;
            }
            set
            {
                SetPropertyValue("TypeOfApplicationForEmployeeID", ref typeOfApplicationForEmployeeID, value);
            }
        }



       
    }

}
