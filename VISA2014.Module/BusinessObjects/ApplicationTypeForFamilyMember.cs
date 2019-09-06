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
    [DefaultProperty("TypeOfApplicationForFamilyMember")]
    public class ApplicationTypeForFamilyMember : ApplicationType
    {
        public ApplicationTypeForFamilyMember(Session session)
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

        private int typeOfApplicationForFamilyMemberID;
        private BaseApplicationType baseApplicationType;
        private SubType typeOfApplicationForFamilyMember;

         [VisibleInListView(true)]
        public SubType TypeOfApplicationForFamilyMember
        {
            get
            {
                return typeOfApplicationForFamilyMember;
            }
            set
            {
                SetPropertyValue("TypeOfApplicationForFamilyMember", ref typeOfApplicationForFamilyMember, value);
            }
        }


        public int TypeOfApplicationForFamilyMemberID
        {
            get
            {
                return typeOfApplicationForFamilyMemberID;
            }
            set
            {
                SetPropertyValue("TypeOfApplicationForFamilyMemberID", ref typeOfApplicationForFamilyMemberID, value);
            }
        }



         [VisibleInListView(true)]

        [Association("BaseApplicationType-ApplicationTypeForFamilyMembers")]
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

    }

}
