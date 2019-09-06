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
  
    public class ApplicationType : BaseObject
    {
        public ApplicationType(Session session)
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

        private bool bellikVisibility;
        private bool goşmaçaIşlemägeRugsatÝeriVisibility;
        private bool businessTripDestinationVisibility;
        private bool applicationResultVisibility;
        private bool isBorderZoneInLetterRequired;
        private bool borderZonePeriodVisibility;
        private bool workPermitForPersonInLineVisible;
        private bool previousPassportInAppLineVisible;
        private bool prefferedVisaCategoryVisibility;
        private bool processNumberVisible;

        private bool departmentForRegistrationVisible;
        private bool isLongProcessApplication;
        private bool isAddressedToChiefOfOrganization;
        private bool isAddressedToOrganization;
        private bool tDMGAdy;
        private bool tDMGBaşlygyňAdy;

        private bool registrationNumberAndDateVisible;
        private bool visaVisibleForPersonInApplication;
        private bool registrationDataForPersonInApplication;
        private bool borderZoneForPersonInApplication;
        private bool signingPeronVisible;
        private bool position;
        private bool addressOfResidence;
        private bool invitation;
        private bool invitationToBeChanged;
        private bool isAddressVisible;
        private bool isVisaPeriodVisible;
        private bool isVisaCategoryVisible;
        private bool isBorderZoneRequired;
        private bool isAplicableToMinistery;
        private bool hasUrgency;



        [VisibleInListView(false)]
        public bool HasUrgency
        {
            get
            {
                return hasUrgency;
            }
            set
            {
                SetPropertyValue("HasUrgency", ref hasUrgency, value);
            }
        }


        public bool ApplicationResultVisibility
        {
            get
            {
                return applicationResultVisibility;
            }
            set
            {
                SetPropertyValue("ApplicationResultVisibility", ref applicationResultVisibility, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsAplicableToMinistery
        {
            get
            {
                return isAplicableToMinistery;
            }
            set
            {
                SetPropertyValue("IsAplicableToMinistery", ref isAplicableToMinistery, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsBorderZoneRequired
        {
            get
            {
                return isBorderZoneRequired;
            }
            set
            {
                SetPropertyValue("IsBorderZoneRequired", ref isBorderZoneRequired, value);
            }
        }



        public bool IsBorderZoneInLetterRequired
        {
            get
            {
                return isBorderZoneInLetterRequired;
            }
            set
            {
                SetPropertyValue("IsBorderZoneInLetterRequired", ref isBorderZoneInLetterRequired, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsVisaCategoryVisible
        {
            get
            {
                return isVisaCategoryVisible;
            }
            set
            {
                SetPropertyValue("IsVisaCategoryVisible", ref isVisaCategoryVisible, value);
            }
        }


        [VisibleInListView(false)]
        public bool IsVisaPeriodVisible
        {
            get
            {
                return isVisaPeriodVisible;
            }
            set
            {
                SetPropertyValue("IsVisaPeriodVisible", ref isVisaPeriodVisible, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsAddressVisible
        {
            get
            {
                return isAddressVisible;
            }
            set
            {
                SetPropertyValue("IsAddressVisible", ref isAddressVisible, value);
            }
        }

        [VisibleInListView(false)]
        public bool InvitationToBeChanged
        {
            get
            {
                return invitationToBeChanged;
            }
            set
            {
                SetPropertyValue("InvitationToBeChanged", ref invitationToBeChanged, value);
            }
        }


        [VisibleInListView(false)]
        public bool Invitation
        {
            get
            {
                return invitation;
            }
            set
            {
                SetPropertyValue("Invitation", ref invitation, value);
            }
        }

        [VisibleInListView(false)]
        public bool AddressOfResidence
        {
            get
            {
                return addressOfResidence;
            }
            set
            {
                SetPropertyValue("AddressOfResidence", ref addressOfResidence, value);
            }
        }


        [VisibleInListView(false)]
        public bool Position
        {
            get
            {
                return position;
            }
            set
            {
                SetPropertyValue("Position", ref position, value);
            }
        }


        [VisibleInListView(false)]
        public bool SigningPeronVisible
        {
            get
            {
                return signingPeronVisible;
            }
            set
            {
                SetPropertyValue("SigningPeronVisible", ref signingPeronVisible, value);
            }
        }


        [VisibleInListView(false)]
        public bool BorderZoneForPersonInApplication
        {
            get
            {
                return borderZoneForPersonInApplication;
            }
            set
            {
                SetPropertyValue("BorderZoneForPersonInApplication", ref borderZoneForPersonInApplication, value);
            }
        }

        [VisibleInListView(false)]

        public bool RegistrationDataForPersonInApplication
        {
            get
            {
                return registrationDataForPersonInApplication;
            }
            set
            {
                SetPropertyValue("RegistrationDataForPersonInApplication", ref registrationDataForPersonInApplication, value);
            }
        }



        [VisibleInListView(false)]
        public bool VisaVisibleForPersonInApplication
        {
            get
            {
                return visaVisibleForPersonInApplication;
            }
            set
            {
                SetPropertyValue("VisaVisibleForPersonInApplication", ref visaVisibleForPersonInApplication, value);
            }
        }


        [VisibleInListView(false)]
        public bool RegistrationNumberAndDateVisible
        {
            get
            {
                return registrationNumberAndDateVisible;
            }
            set
            {
                SetPropertyValue("RegistrationNumberAndDateVisible", ref registrationNumberAndDateVisible, value);
            }
        }



        public bool IsAddressedToOrganization
        {
            get
            {
                return isAddressedToOrganization;
            }
            set
            {
                SetPropertyValue("IsAddressedToOrganization", ref isAddressedToOrganization, value);
            }
        }


        public bool IsAddressedToChiefOfOrganization
        {
            get
            {
                return isAddressedToChiefOfOrganization;
            }
            set
            {
                SetPropertyValue("IsAddressedToChiefOfOrganization", ref isAddressedToChiefOfOrganization, value);
            }
        }


        public bool IsLongProcessApplication
        {
            get
            {
                return isLongProcessApplication;
            }
            set
            {
                SetPropertyValue("IsLongProcessApplication", ref isLongProcessApplication, value);
            }
        }


        public bool DepartmentForRegistrationVisible
        {
            get
            {
                return departmentForRegistrationVisible;
            }
            set
            {
                SetPropertyValue("DepartmentForRegistrationVisible", ref departmentForRegistrationVisible, value);
            }
        }

        [VisibleInListView(false)]
        public bool TDMGBaşlygyňAdy
        {
            get
            {
                return tDMGBaşlygyňAdy;
            }
            set
            {
                SetPropertyValue("TDMGBaşlygyňAdy", ref tDMGBaşlygyňAdy, value);
            }
        }

        [VisibleInListView(false)]
        public bool TDMGAdy
        {
            get
            {
                return tDMGAdy;
            }
            set
            {
                SetPropertyValue("TDMGAdy", ref tDMGAdy, value);
            }
        }





        public bool PrefferedVisaCategoryVisibility
        {
            get
            {
                return prefferedVisaCategoryVisibility;
            }
            set
            {
                SetPropertyValue("PrefferedVisaCategoryVisibility", ref prefferedVisaCategoryVisibility, value);
            }
        }


        public bool PreviousPassportInAppLineVisible
        {
            get
            {
                return previousPassportInAppLineVisible;
            }
            set
            {
                SetPropertyValue("PreviousPassportInAppLineVisible", ref previousPassportInAppLineVisible, value);
            }
        }


        public bool WorkPermitForPersonInLineVisible
        {
            get
            {
                return workPermitForPersonInLineVisible;
            }
            set
            {
                SetPropertyValue("WorkPermitForPersonInLineVisible", ref workPermitForPersonInLineVisible, value);
            }
        }

        public bool ProcessNumberVisible
        {
            get
            {
                return processNumberVisible;
            }
            set
            {
                SetPropertyValue("ProcessNumberVisible", ref processNumberVisible, value);
            }
        }


        public bool BorderZonePeriodVisibility
        {
            get
            {
                return borderZonePeriodVisibility;
            }
            set
            {
                SetPropertyValue("BorderZonePeriodVisibility", ref borderZonePeriodVisibility, value);
            }
        }



        public bool BusinessTripDestinationVisibility
        {
            get
            {
                return businessTripDestinationVisibility;
            }
            set
            {
                SetPropertyValue("BusinessTripDestinationVisibility", ref businessTripDestinationVisibility, value);
            }
        }




        public bool GoşmaçaIşlemägeRugsatÝeriVisibility
        {
            get
            {
                return goşmaçaIşlemägeRugsatÝeriVisibility;
            }
            set
            {
                SetPropertyValue("GoşmaçaIşlemägeRugsatÝeriVisibility", ref goşmaçaIşlemägeRugsatÝeriVisibility, value);
            }
        }




        public bool BellikVisibility
        {
            get
            {
                return bellikVisibility;
            }
            set
            {
                SetPropertyValue("BellikVisibility", ref bellikVisibility, value);
            }
        }
    }

}
