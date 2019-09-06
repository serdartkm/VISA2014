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
    [DefaultProperty("TravelPurpose")]
    public class PurposeOfTravel : BaseObject
    {
        public PurposeOfTravel(Session session)
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

        private string purposeOfTravelR;
        private string purposeOfTravelL;
        private TravelPurposeEn travelPurpose;

        public TravelPurposeEn TravelPurpose
        {
            get
            {
                return travelPurpose;
            }
            set
            {
                SetPropertyValue("TravelPurpose", ref travelPurpose, value);
            }
        }



        public string PurposeOfTravelL
        {
            get
            {
                return purposeOfTravelL;
            }
            set
            {
                SetPropertyValue("PurposeOfTravelL", ref purposeOfTravelL, value);
            }
        }


        public string PurposeOfTravelR
        {
            get
            {
                return purposeOfTravelR;
            }
            set
            {
                SetPropertyValue("PurposeOfTravelR", ref purposeOfTravelR, value);
            }
        }



    }

    




    public enum TravelPurposeEn

    { 
    
    Work,
    Visit,
    Vacation,
    FamilyMember,
    Quit,
    BusinessTrip

    
    
    }

}
