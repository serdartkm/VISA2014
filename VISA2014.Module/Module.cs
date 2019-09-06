using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using VISA2014.Module.DC;



namespace VISA2014.Module
{
    public sealed partial class VISA2014Module : ModuleBase
    {
        public VISA2014Module()
        {
            InitializeComponent();
            this.RequiredModuleTypes.Add(typeof(DatabaseUserSettings.DatabaseUserSettingsModule));
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Conf

            // Company
            XafTypesInfo.Instance.RegisterEntity("Company", typeof(ICompany));
            XafTypesInfo.Instance.RegisterEntity("CompanyRepresentative", typeof(ICompanyRepresentative));
            // Person
            XafTypesInfo.Instance.RegisterEntity("Person", typeof(IPersonn));
            XafTypesInfo.Instance.RegisterEntity("Employee", typeof(IEmployee));
            XafTypesInfo.Instance.RegisterEntity("FamilyMember", typeof(IFamilyMember));
            XafTypesInfo.Instance.RegisterEntity("PersonInApplication", typeof(IPersonInApplication));
            XafTypesInfo.Instance.RegisterEntity("MaritalStatus", typeof(IMaritalStatus));
            XafTypesInfo.Instance.RegisterEntity("Gender", typeof(IGender));
            //Passport
            XafTypesInfo.Instance.RegisterEntity("Passport", typeof(IPassport));
            XafTypesInfo.Instance.RegisterEntity("PassportType", typeof(IPassportType));
            XafTypesInfo.Instance.RegisterEntity("PassportIssuedPlace", typeof(IPassportIssuedPlace));
           

            // Employee
        
            XafTypesInfo.Instance.RegisterEntity("Position", typeof(IPosition));
            XafTypesInfo.Instance.RegisterEntity("WorkHistoryOfEmployee", typeof(IWorkHistory));
          
            XafTypesInfo.Instance.RegisterEntity("Relation", typeof(IRelation));
            XafTypesInfo.Instance.RegisterEntity("Department", typeof(IDepartment));



            // Education
            XafTypesInfo.Instance.RegisterEntity("Education", typeof(IEducation));
            XafTypesInfo.Instance.RegisterEntity("EducationLevel", typeof(IEducationLevel));
            XafTypesInfo.Instance.RegisterEntity("EducationInstitution", typeof(IEducationInstitution));
            XafTypesInfo.Instance.RegisterEntity("Speciality", typeof(ISpeciality));
           
            //Address
            XafTypesInfo.Instance.RegisterEntity("Address", typeof(IAddresses));
            XafTypesInfo.Instance.RegisterEntity("AddressOfResidence", typeof(IAddressOfResidence));
            XafTypesInfo.Instance.RegisterEntity("AddressOnBusinessTrip", typeof(IAddressOnBusinessTrip));
            XafTypesInfo.Instance.RegisterEntity("DocumentOfAddress", typeof(IDocumentOfAddress));
            XafTypesInfo.Instance.RegisterEntity("Copy", typeof(ICopy));
          

            // Dictionary

            XafTypesInfo.Instance.RegisterEntity("Region", typeof(IRegion));
            XafTypesInfo.Instance.RegisterEntity("ŞäherEtrap", typeof(IŞäherEtrap));
            XafTypesInfo.Instance.RegisterEntity("Country", typeof(ICountries));
            //Visa

            XafTypesInfo.Instance.RegisterEntity("Visa", typeof(IVisa));
            XafTypesInfo.Instance.RegisterEntity("VisaType", typeof(IVisaType));
            XafTypesInfo.Instance.RegisterEntity("VisaCategory", typeof(IVisaCategory));
            XafTypesInfo.Instance.RegisterEntity("VisaIssuedPlace", typeof(IVisaIssuedPlace));        
            XafTypesInfo.Instance.RegisterSharedPart(typeof(IVisaType));

            // ResistrationCard  
            XafTypesInfo.Instance.RegisterEntity("TravelInformation", typeof(ITravelInformation)); 
            // Application
            XafTypesInfo.Instance.RegisterEntity("Application", typeof(IApplication));
            XafTypesInfo.Instance.RegisterEntity("AppliedMinistery", typeof(IAppliedMinistery));
            XafTypesInfo.Instance.RegisterEntity("Contract", typeof(IContract));
        
            XafTypesInfo.Instance.RegisterSharedPart( typeof(IRegistration));
            XafTypesInfo.Instance.RegisterEntity("Visibility", typeof(IVisibility));
            XafTypesInfo.Instance.RegisterEntity("Plural", typeof(IPlural));
            XafTypesInfo.Instance.RegisterEntity("IPluralFamilyMember", typeof(IPluralFamilyMember));

            XafTypesInfo.Instance.RegisterEntity("LongProcessApplication", typeof(ILongProcessApplication));
            XafTypesInfo.Instance.RegisterEntity("SimpleProcessApplication", typeof(ISimpleProcessApplication));
            XafTypesInfo.Instance.RegisterEntity("Urgency", typeof(IUrgency));
            XafTypesInfo.Instance.RegisterEntity("VisaPeriod", typeof(IVisaPeriod));
          
            // BorderZone
            XafTypesInfo.Instance.RegisterSharedPart( typeof(IBorderZone));
            XafTypesInfo.Instance.RegisterSharedPart(typeof(IRemainingDays));
            XafTypesInfo.Instance.RegisterSharedPart(typeof(IMessage));
            //WorkPermit
            XafTypesInfo.Instance.RegisterEntity("WorkPermitLetter", typeof(IWorkPermitLetter));
            XafTypesInfo.Instance.RegisterEntity("WorkPermit", typeof(IWorkPermit));
            XafTypesInfo.Instance.RegisterEntity("WorkPermitLocation", typeof(IWorkPermitLocation));
           
      
            //Invitation

            XafTypesInfo.Instance.RegisterEntity("ApplicationResult", typeof(IApplicationResult));
          
       
            XafTypesInfo.Instance.RegisterEntity("PersonInInvitation", typeof(IPersonInResult));
            XafTypesInfo.Instance.RegisterEntity("BorderZoneForVisa", typeof(IBorderZoneForVisa));
     
         //HR

            XafTypesInfo.Instance.RegisterEntity("PassportCopy", typeof(IPassportCopy));
            XafTypesInfo.Instance.RegisterEntity("FamilyProofDocument", typeof(FamilyProofDocument));


            // Gatnaw 

      

        }
    }
}
