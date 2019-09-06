using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{

  
    [VisibleInReports(true)]
   
    [DomainComponent,  ImageName("BO_UnKnown")]
    [XafDefaultProperty("Application")]

    #region Rule required field 


    [RuleCriteria("PA1", DefaultContexts.Save, "(Application Is Not Null)","This process is not allowed", SkipNullOrEmptyValues = false)]

    // Family Member
    [RuleCriteria("Family Member in Line", DefaultContexts.Save, "(Application.ForFamilyMember = true And FamilyMember Is Not Null) Or (Application.ForFamilyMember = false And FamilyMember Is Null) ", "Family Member must be specified", SkipNullOrEmptyValues = false)]
    //Employee
    [RuleCriteria("Employee in Line", DefaultContexts.Save, "Employee Is Not Null ", "Employee must be specified", SkipNullOrEmptyValues = false)]
    // Position
    [RuleCriteria("Position in Line", DefaultContexts.Save, "(PositionVisibility =true And Position Is Not Null) Or (PositionVisibility =false And Position Is Null) ", "Position must be specified", SkipNullOrEmptyValues = false)]

    // Address
    [RuleCriteria("Address in Line", DefaultContexts.Save, "(AddressVisibility=false And Address Is Null ) Or (AddressVisibility=true And Address Is Not Null )", "Address must be specified", SkipNullOrEmptyValues = false)]
    // AddressOfResidence
    [RuleCriteria("Address Of Residence  in Line", DefaultContexts.Save, "(AddressOfResidenceVisibility=false And AddressOfResidence Is Null ) Or (AddressOfResidenceVisibility=true And AddressOfResidence Is Not Null )", "Address Of Residence must be specified", SkipNullOrEmptyValues = false)]

    //Passport

    [RuleCriteria("Passport in Line", DefaultContexts.Save, "Passport Is Not Null ", "Passport must be specified", SkipNullOrEmptyValues = false)]
    //PreviousPassport
    [RuleCriteria("Previous Passport  in Line", DefaultContexts.Save, "(PreviousPassportVisibility=false And PreviousPassport Is Null ) Or (PreviousPassportVisibility=true And PreviousPassport Is Not Null )", "Previous passport must be specified", SkipNullOrEmptyValues = false)]

    // Visa
    [RuleCriteria("Visa  in Line", DefaultContexts.Save, "(VisaVisibility=false And Visa Is Null ) Or (VisaVisibility=true And Visa Is Not Null )", "Wizasyny saýlamaly", SkipNullOrEmptyValues = false)]
    //WorkPermit

    [RuleCriteria("Work Permit  in Line", DefaultContexts.Save, "(WorkPermitVisibility=false And WorkPermit Is Null ) Or (WorkPermitVisibility=true And WorkPermit Is Not Null )", "Iş rugsatnamasyny saýlamaly", SkipNullOrEmptyValues = false)]

    //CheckPoint

    [RuleCriteria("CheckPoint  in Line", DefaultContexts.Save, "(RegistrationVisibility=false And CheckPoint Is Null ) Or (RegistrationVisibility=true And CheckPoint Is Not Null )", "Giren migrasiýa gözegçilik postunyň adyny saýlamaly", SkipNullOrEmptyValues = false)]
    
    // Employee Entry Date
    [RuleCriteria("Employee Entry Date  in Line", DefaultContexts.Save, "(AppliedPerson.IsEmployee = true And RegistrationVisibility= false And EmployeeEntryDate Is Null ) Or (AppliedPerson.IsEmployee = true And RegistrationVisibility= true And EmployeeEntryDate Is Not Null Or (AppliedPerson.IsEmployee = false) )", "Işgäriň gelen senesini saýlamaly", SkipNullOrEmptyValues = false)]
    // Family Member Entry Date
    [RuleCriteria("Family Member Entrye Date in Line", DefaultContexts.Save, "(AppliedPerson.IsFamilyMember = true And RegistrationVisibility= false And FamilyMemberEntryDate Is Null ) Or (AppliedPerson.IsFamilyMember = true And RegistrationVisibility= true And FamilyMemberEntryDate Is Not Null ) Or (AppliedPerson.IsFamilyMember = false) ", "Maşgala agzanyň gelen senesini saýlamaly", SkipNullOrEmptyValues = false)]


    // Visa Issued place
    [RuleCriteria("Visa Issued Place  in Line", DefaultContexts.Save, "(RegistrationVisibility=false And VisaIssuedPlace Is Null ) Or (RegistrationVisibility=true And VisaIssuedPlace Is Not Null )",
        "Wizanyň resmileşdirilen ýerini görkezmeli", SkipNullOrEmptyValues = false)]

    // Purpose Of Travel
    [RuleCriteria("Purpose Of Travel  in Line", DefaultContexts.Save, "(RegistrationVisibility=false And PurposeOfTrave Is Null ) Or (RegistrationVisibility=true And PurposeOfTrave Is Not Null )", 
        "Gelmeginiň(Gitmginiň) maksadyny görkezmeli", SkipNullOrEmptyValues = false)]

    [RuleCriteria("AddressOnBusinessTrip", DefaultContexts.Save, "(AddressOnBusinessTripVisibility=false And AddressOnBusinessTrip Is Null ) Or (AddressOnBusinessTripVisibility=true And AddressOnBusinessTrip Is Not Null )", "Iş saparynda boljak salgysy görkezilmeli", SkipNullOrEmptyValues = false)]

    #endregion

    #region Application Appearence

    [Appearance("OfficeP", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "PersonState='Office'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance(">>MinisteryP", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "PersonState='ToMinistery'", BackColor = "Turquoise", FontColor = "Black")]

    [Appearance("Ministery>>P", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "PersonState='FromMinistery' ", BackColor = "RoyalBlue", FontColor = "White")]


    [Appearance("OnProcessSPP", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = "PersonState='OnProcess'", BackColor = "Gold", FontColor = "Black")]


   // [Appearance("OnProcessSPWP", AppearanceItemType = "ViewItem", TargetItems = "PersonState", Context = "ListView",
   // Criteria = "PersonState='InvitationIssuedWorkPermitNot' Or PersonState='VisaExtendedWorkPermitNot' ", BackColor = "Gold", FontColor = "Black")]

  //  [Appearance("DiscWP", AppearanceItemType = "ViewItem", TargetItems = "PersonState", Context = "ListView",
   //Criteria = "PersonState='InvitationIssuedWorkPermitNot' Or PersonState='VisaExtendedWorkPermitNot' ", BackColor = "Orange", FontColor = "Black")]

    [Appearance("ProcessedPPerson", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "PersonState='Processed' And Application.ApplicationState !='Rejected' And Application.ApplicationState !='Cancelled'", BackColor = "MediumSeaGreen", FontColor = "White")]

    [Appearance("ProcessedApplication", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = "Application.ApplicationState ='Processed' And PersonState !='Rejected' And PersonState !='Cancelled'", BackColor = "MediumSeaGreen", FontColor = "White")]


    [Appearance("RejectedPerson", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = "PersonState='Rejected' And Application.ApplicationState !='Cancelled'", BackColor = "Red", FontColor = "White")]
    
    [Appearance("RejectedApp", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "Application.ApplicationState='Rejected' And PersonState !='Cancelled' ", BackColor = "Red", FontColor = "White")]



    [Appearance("CancelledPerson", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "PersonState='Cancelled' Or Application.ApplicationState='Cancelled'", BackColor = "LightGray", FontColor = "Gray")]

    #endregion
  


    public interface IPersonInApplication
    {


        
    

        #region Appearence
     
          [Appearance("FamilyMember", Visibility = ViewItemVisibility.Hide, Criteria = "Application.ForEmployee = true")]
          
        #endregion

        [ImmediatePostData, VisibleInListView(false)]
       
        [DataSourceCriteria("IsFamilyMember = true")]
        IPersonn FamilyMember { get; set; }

        [Browsable(false)]
        [ImmediatePostData]
        IPersonn EmployeeAsFM { get; }

        #region Appearence

        #endregion

        [ImmediatePostData,VisibleInListView(false)]
        [DataSourceCriteria("IsFamilyMember = false")]
        IPersonn Employee { get; set; }

        #region Appearence

        [ImmediatePostData]
        [Browsable(false)]
        bool PositionVisibility { get; }

        [Appearance("Position", Visibility = ViewItemVisibility.Hide, Criteria = "PositionVisibility = false")]
        
        #endregion

        IWorkHistory Position { get; set; }
        [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
        string PositionForReport { get; }

        #region Appearence
        [Browsable(false)]
        [ImmediatePostData]
        bool AddressOfResidenceVisibility { get;}
        [Appearance("AddressOfResidence", Visibility = ViewItemVisibility.Hide, Criteria = "AddressOfResidenceVisibility=false")]
       
        #endregion   
     
        [DataSourceProperty("PersonType.AddressOfResidences")]
        IAddressOfResidence AddressOfResidence { get; set; }
       
        [ImmediatePostData]
        [Browsable(false)]
        IPersonn PersonType { get; }

        [RuleRequiredField]
        [ImmediatePostData]

        

        [DataSourceProperty("PersonType.Passports")]


        IPassport Passport { get; set; }

        

        #region Appearence
        [Browsable(false),ImmediatePostData]
        bool PreviousPassportVisibility { get; }

         [Appearance("PreviousPassport", Visibility = ViewItemVisibility.Hide, Criteria = "PreviousPassportVisibility=false")]
        #endregion


        [DataSourceProperty("PersonType.Passports"),VisibleInListView(false)]

        IPassport PreviousPassport { get; set; }

        #region Appearence
        [ImmediatePostData]
        [Browsable(false)]
        bool VisaVisibility { get; }
        [Appearance("ExtendingWorkPermitLocationEAV", Visibility = ViewItemVisibility.Hide, Criteria = "VisaVisibility=false")]
       
        #endregion
        
        [ImmediatePostData]
        [DataSourceProperty("Passport.Visas")]
        IVisa Visa { get; set; }


        #region Appearence


        [ImmediatePostData]
        [Browsable(false)]

        bool AddressVisibility { get; }
        [Appearance("ExtendingWorkPermitLocationEAddress", Visibility = ViewItemVisibility.Hide, Criteria = "AddressVisibility=false")]
        
        #endregion
       
        IAddresses Address { get; set; }

        IApplication Application { get; set; }



        IApplication ApplicationForChangingInvitation { get; set; }
        [VisibleInListView(true)]
        IPersonn AppliedPerson { get; }
        [VisibleInListView(true),VisibleInDetailView(false)]
        SubType ApplicationType { get; }

        #region Appearence
        [Browsable(false),ImmediatePostData]
        bool  WorkPermitVisibility {get;}

        [Appearance("WorkPermit", Visibility = ViewItemVisibility.Hide, Criteria = "WorkPermitVisibility=false")]
        #endregion
        IWorkPermit WorkPermit { get; set; }

        IWorkPermit NewWorkPermit { get; }

        [VisibleInDetailView(false),VisibleInListView(false)]
         string BorderZoneCollectionForLine { get; }

        #region Appearence


     
        #endregion

        #region Invitation
     
       
        [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
        IApplicationResult Invitation { get; }
       [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        IApplicationResult RejectionLet { get; }
         [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
       IPersonInResult PersonInResult { get; }
   


        #endregion
      //  [VisibleInDetailView(false),Browsable(false)]
        IVisa NewVisa { get;}
        [Browsable(false)]
        bool Deletedd { get; set; }
        #region Registration

        #region Appearence
               [Browsable(false)]
              [ImmediatePostData]

              bool RegistrationVisibility { get; }
            [Appearance("EntryPoint", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationVisibility=false ")]
            
              #endregion

              CheckPoint CheckPoint { get; set; }


              #region Appearence
          [Appearance("EntryDate", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationVisibility=false")]
          [Appearance("EntryDate1", Visibility = ViewItemVisibility.Hide, Criteria = " Application.ForFamilyMember =true")]
          
              #endregion
              
      
            
              [DataSourceCriteria("TravelType='Entry'")]
              [DataSourceProperty("Employee.TravelInformations")]
              ITravelInformation EmployeeEntryDate { get; set;}


              #region Appearence
          [Appearance("EntryDateFM", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationVisibility=false")]
          [Appearance("EntryDateFM1", Visibility = ViewItemVisibility.Hide, Criteria = " Application.ForEmployee=true ")]
          
          #endregion
              

              [DataSourceCriteria("TravelType='Entry'")]
              [DataSourceProperty("FamilyMember.TravelInformations")]
              ITravelInformation FamilyMemberEntryDate { get; set; }

              #region Appearence
             [Appearance("VisaIssuedplace", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationVisibility=false ")]
             
              #endregion


              IVisaIssuedPlace VisaIssuedPlace { get; set; }

              #region Appearence
         [Appearance("Purposeoftravel", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationVisibility=false ")]
       
              #endregion

              PurposeOfTravel PurposeOfTrave { get; set; }


              #region Appearence

          [Browsable(false),ImmediatePostData]
         bool RegistrationNumberAndDateVisibility { get; }
         [Appearance("RegistrationNumber", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationNumberAndDateVisibility =false ")]
         [Appearance("PIA12", Enabled = false, Criteria = "Application Is Null")]
#endregion
         string RegistrationNumber { get; set; }


              #region Appearence
          [Appearance("RegistrationDate", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationNumberAndDateVisibility =false ")]
          [Appearance("PIA13", Enabled = false, Criteria = "Application Is Null")]
#endregion

         DateTime? RegistrationDate { get; set; }
              #endregion
                  [Appearance("CancelledCancelled", Enabled = false, Criteria = "Rejected Or IsComplete"), ImmediatePostData]
          bool Cancelled { get; set; }

           ApplicationStateEnum  PersonState { get; }

           [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
           string ContractStartDate { get; }
           [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
           string ContractEndDate { get; }
           [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
           Salary Salary { get; }
         #region Apprearence
            [Browsable(false),ImmediatePostData]
            bool AddressOnBusinessTripVisibility { get; }

            [Appearance("AddressOnBusinessTrip", Visibility = ViewItemVisibility.Hide, Criteria = "AddressOnBusinessTripVisibility=false")]
#endregion

             IAddressOnBusinessTrip AddressOnBusinessTrip { get; set; }
            [Appearance("RejectedRejected", Enabled = false, Criteria = "IsComplete Or Cancelled"),ImmediatePostData]
            bool Rejected { get; set; }
            [Appearance("IsCompleteIsComplete", Enabled = false, Criteria = "Rejected Or Cancelled"), ImmediatePostData]
            bool IsComplete { get; set; }
     
         //   IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
            string BirthDateAndPlaceForLetter { get; }
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
            string PassportNumberAndDateOfExpire { get; }
          [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string EducationForLetter { get; }
          [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string SpecialtyForLetter { get; }

    } // End IPersonInApplication

    [DomainLogic(typeof(IPersonInApplication))]
  
    public class PersonInApplicationLogic

    {
       

        public static Salary Get_Salary  (IPersonInApplication personInApp){

            try
            {
                if (personInApp.AppliedPerson.IsFamilyMember)
                {

                    return null;
                }

                else if (personInApp.AppliedPerson.IsEmployee && (personInApp.AppliedPerson as IEmployee).Salary !=null)
                {

                    return (personInApp.AppliedPerson as IEmployee).Salary;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
          
        
        }

        public static string Get_EducationForLetter(IPersonInApplication personInApplication)
        {
            if (personInApplication != null && personInApplication.AppliedPerson.LastEducation != null)
            {

                if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Orta")
                {
                    return "Orta";
                }

                else if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Ýokary")
                {

                    return personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel + "\n          " + personInApplication.AppliedPerson.LastEducation.EducationCountry.NameOfCountryL + "\n        " + personInApplication.AppliedPerson.LastEducation.EducationInstitution.TitleOfIEducationInstitution;


                }
                else if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Ýörite orta")
                {

                    return personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel + "\n          " + personInApplication.AppliedPerson.LastEducation.EducationCountry.NameOfCountryL + "\n        " + personInApplication.AppliedPerson.LastEducation.EducationInstitution.TitleOfIEducationInstitution;


                }
                else return "-";
            }
            else return null;

        }


        public static string Get_SpecialtyForLetter(IPersonInApplication personInApplication)

        {
            if (personInApplication != null && personInApplication.AppliedPerson.LastEducation != null)
            {
                if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Orta")
                {
                    return "-";
                }
                else
                    if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Ýokary")
                    {

                        return personInApplication.AppliedPerson.LastEducation.Spcialty.TitleOfSpeciality;


                    }
                    else if (personInApplication != null && personInApplication.AppliedPerson.IsEmployee && personInApplication.AppliedPerson.LastEducation.EducationLevel.TitleOfEducationLevel == "Ýörite orta")
                    {

                        return personInApplication.AppliedPerson.LastEducation.Spcialty.TitleOfSpeciality; ;


                    }
                    else return "-";
            }
            else return null;

        }

        public static string Get_BirthDateAndPlaceForLetter(IPersonInApplication personInApp)

        {
            if (personInApp != null)
            {
                return personInApp.AppliedPerson.BirthDate.ToString("dd.MM.yyyy") + "\n  " + personInApp.AppliedPerson.BirthPlace;
            }
            else return null;
        }


        public static string Get_PassportNumberAndDateOfExpire(IPersonInApplication personInApp)

        {
            if (personInApp != null)
            {
                return personInApp.Passport.PassportNumber + "\n  " + personInApp.Passport.PassportExpiringDate.ToString("dd.MM.yyyy");
                 
            }
            else return null;

        
        }

       public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory( IPersonInApplication personInApp, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, personInApp);

        }

     public static IPersonInResult Get_PersonInResult(IPersonInApplication personInApp)

        {

         return Helper.GetPersonInResult(personInApp.AppliedPerson, personInApp);
       
        }

     public static bool Get_AddressOnBusinessTripVisibility(IPersonInApplication personInApp)

        {

            if (personInApp.Application != null && personInApp.Application.ForEmployee && personInApp.Application.ApplicationTypeForEmployee.BusinessTripDestinationVisibility == true)
            {
                return true;

            }
            else return false;

        }
        
     public static string Get_ContractStartDate(IPersonInApplication personInApp)


        {

            if (personInApp.Application.ForEmployee && personInApp.ApplicationType == SubType.ApplicationForVisaExtention | personInApp.ApplicationType == SubType.ApplicationForInvitation)
            {
                return  personInApp.Application.ManualApplicationDate.ToString("dd.MM.yyyy");
            }

            else return null;
        
        
        
        }
     public static string Get_ContractEndDate(IPersonInApplication personInApp)
        {
            if (personInApp != null && personInApp.Application != null)
            {
                if (personInApp.Application.ForEmployee && personInApp.ApplicationType == SubType.ApplicationForVisaExtention | personInApp.ApplicationType == SubType.ApplicationForInvitation)
                {
                    int visaPeriod = personInApp.Application.VisaPeriod.CountMonth;
                    DateTime contractEndDate = personInApp.Application.ManualApplicationDate.AddMonths(personInApp.Application.VisaPeriod.CountMonth);

                    return contractEndDate.ToString("dd.MM.yyyy");

                }

                else return null;

            }

            else return null;

        }


    public static string Get_BirthDateForLetter(IPersonInApplication personInApp)


        {


            if (personInApp.Passport != null)
            {
                return personInApp.Passport.PassportNumber;

            }

            else return null;
        
        
        
        }

    public static IWorkPermit Get_NewWorkPermit(IPersonInApplication personInApp)


        {
            if (personInApp.Employee != null)
            {
                if (personInApp != null && personInApp.Employee.IsEmployee  && personInApp.Application != null && personInApp.Employee.WorkPermits.Count > 0 && personInApp.Application.ForEmployee)
                {
                    IWorkPermit workpermit = null;

                    foreach (var employeeInWP in personInApp.Employee.WorkPermits)
                    {

                        if (employeeInWP.ProcessNumber != null && employeeInWP.ProcessNumber.Application == personInApp.Application)
                        {
                            workpermit = employeeInWP;

                            break;

                        }
                    }


                    return workpermit;



                }
                else return null;
            }
            else return null;


        }

    public static IVisa Get_NewVisa (IPersonInApplication personInApp)

    {
            IVisa visa = null;
        if (personInApp != null)
        {
            foreach (var visaInPassport in personInApp.Passport.Visas)
            {
                if (visaInPassport.ProcessNumber == personInApp)
                {
                    visa = visaInPassport;

                    break;
                }

            }
            return visa;
        }
        else return null;
    
    
    }

    public static IPersonn Get_AppliedPerson(IPersonInApplication person)

        {

            if (person.Application!=null && person.Application.ForEmployee)
            {

                return person.Employee;

            }

            else if (person.Application != null && person.Application.ForFamilyMember)
            {

                return person.FamilyMember;

            }

            else return null;
        
        
        }

    public static string Get_PositionForReport(IPersonInApplication personInApp)

    {


        if (personInApp.Application != null && personInApp.Position!=null && personInApp.Application.ForEmployee)
        {

            return personInApp.Position.Position.Code + "" + personInApp.Position.Position.TitleOfPosition;
        
        }

        else if (personInApp.Application != null  && personInApp.Application.ForFamilyMember)

        {
        return personInApp.Position.Position.Code + "." + personInApp.Position.Position.TitleOfPosition +"-"+personInApp.Employee.FullName+"-ň "+personInApp.FamilyMember.FamilyMemberRelation.RelativeAsL;
        
        }

        else return null;
    
    
    }

    public static ApplicationStateEnum Get_PersonState(IPersonInApplication person)

    {
        if (person.Rejected) {

            return ApplicationStateEnum.Rejected;
        
        }
        if (person.Cancelled) {

            return ApplicationStateEnum.Cancelled;
        }
        if (person.IsComplete) {

            return ApplicationStateEnum.Processed;
        }

        if (person.AppliedPerson!=null && person.AppliedPerson.IsEmployee)
        {
            return Helper.GEt_PersonInAppStateEmp(person);

        }
        else if (person.AppliedPerson != null && person.AppliedPerson.IsFamilyMember)
        {
            return Helper.GEt_PersonInAppStateFM(person);

        }
        else return ApplicationStateEnum.None;



      
    }

    #region AfterChange

 
    public static void AfterChange_FamilyMember (IPersonInApplication personInApp, IObjectSpace os)

    {
        if ( personInApp.AppliedPerson!=null && personInApp.AppliedPerson.IsFamilyMember && personInApp != null && personInApp.Application != null && personInApp.Application.ApplicationTypeForFamilyMember !=null)
        {
            // Employee
            personInApp.Employee = personInApp.FamilyMember.Employee;
            // Last Passport
            personInApp.Passport = personInApp.AppliedPerson.LastPassport;

            if (personInApp.PreviousPassportVisibility == true)
            {
                personInApp.PreviousPassport = Helper.GetPreviousPassport(personInApp.AppliedPerson);
            }
            // Last Visa

            if (personInApp.VisaVisibility == true)
            {

                personInApp.Visa = personInApp.AppliedPerson.LastVisa;
            }

            // Last Address Fo Residence
            if (personInApp.AddressOfResidenceVisibility == true)
            {
                personInApp.AddressOfResidence = personInApp.AppliedPerson.LastAddressOfResidence;
            }

            // Last Family Entry
            if (personInApp.RegistrationVisibility== true)
            {
                personInApp.FamilyMemberEntryDate = Helper.GetLastEntry(personInApp.PersonType);
                personInApp.CheckPoint = personInApp.FamilyMemberEntryDate.CheckPoint;
                personInApp.PurposeOfTrave = personInApp.FamilyMemberEntryDate.PurposeOfTravel;

                var visaIssuedPlace = os.FindObject<IVisaIssuedPlace>(new BinaryOperator("IsDefault", true));

                if (visaIssuedPlace != null)
                {
                    personInApp.VisaIssuedPlace = os.FindObject<IVisaIssuedPlace>(new BinaryOperator("IsDefault", true));
                }
            }

            // Last Position

            personInApp.Position = Helper.GetLastPosition(personInApp.Employee);

        }

       
    }


   

    public static void AfterChange_Employee(IPersonInApplication personInApp, IObjectSpace os)
    {

        if (personInApp != null && personInApp.AppliedPerson!=null && personInApp.AppliedPerson.IsEmployee && personInApp.Application != null && personInApp.Application.ApplicationTypeForEmployee != null)
        {

            personInApp.Passport = personInApp.AppliedPerson.LastPassport;
            // Previous Pasport
            if (personInApp.PreviousPassportVisibility == true)
            {
                personInApp.PreviousPassport = Helper.GetPreviousPassport(personInApp.AppliedPerson);

            }

            // Last Visa

            if (personInApp.VisaVisibility == true)
            {
                personInApp.Visa = personInApp.AppliedPerson.LastVisa;
            }


            //Last Work Persmit

            if (personInApp.WorkPermitVisibility == true)
            {
                personInApp.WorkPermit = Helper.GetLastWorkPermit(personInApp.Employee);

            }


            //Last Entrye
            if (personInApp.RegistrationVisibility == true && personInApp.EmployeeEntryDate!=null)
            {
                personInApp.EmployeeEntryDate = Helper.GetLastEntry(personInApp.AppliedPerson);
                personInApp.CheckPoint = personInApp.EmployeeEntryDate.CheckPoint;
                personInApp.PurposeOfTrave = personInApp.EmployeeEntryDate.PurposeOfTravel;

                var visaIssuedPlace = os.FindObject<IVisaIssuedPlace>(new BinaryOperator("IsDefault", true));

                if (visaIssuedPlace != null)
                {
                    personInApp.VisaIssuedPlace = os.FindObject<IVisaIssuedPlace>(new BinaryOperator("IsDefault", true));
                }
            }


            // Last Address Of Residence

            if (personInApp.AddressOfResidenceVisibility == true)
            {
                personInApp.AddressOfResidence = Helper.GetLastAddress(personInApp.AppliedPerson);
            }

            // Last Position
            if (personInApp.Application.ApplicationTypeForEmployee.Position == true)
            {
                personInApp.Position = Helper.GetLastPosition(personInApp.Employee);
            }
        }
           
     
    }

  
    #endregion


    public static SubType Get_ApplicationType(IPersonInApplication personInApp)


    {

        return Helper.Get_ApplicationType(personInApp.Application);
     
    }

    public static bool Get_BorderZoneVisible(IPersonInApplication personInApp)


    {

        if (personInApp.Application != null && personInApp.Application.ChooseBorderZoneType == ChooseBorderZoneTypeEnum.BorderZoneForApplication && personInApp.Application.BorderZoneVisibility == true)
        {
            return true;
        }

        else return false;
    
    }

    public static void AfterConstruction(IPersonInApplication person, IObjectSpace obspace)
    {
      
            
            }
          
    public static bool Get_AddressOfResidenceVisibility(IPersonInApplication person)

    {

        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.AddressOfResidence == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.AddressOfResidence == true))
            {
                return true;
            }

            else




                return false;

        }

        else return false;



    }

    public static IPersonn Get_PersonType(IPersonInApplication person)


    {

        if (person.Application != null && person.Application.ForEmployee == true)
        {

            return person.Employee;

        }

        else return person.FamilyMember;
    
    
    }

    public static IPersonn Get_EmployeeAsFM(IPersonInApplication person)

    {


        if (person.Application != null && person.Application.ForFamilyMember == true)
        {

            return person.FamilyMember.Employee;

        }

        else return person.Employee;
    
    
    
    }

    public static bool Get_AddressVisibility(IPersonInApplication person)

    {


        if (person.Application!=null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.IsAddressVisible == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.IsAddressVisible == true))
            {
                return true;
            }

            else




                return false;

        }

        else return false;
 
    }

    public static bool Get_PositionVisibility(IPersonInApplication person)


    {


        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.Position == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.Position == true))
            {
                return true;
            }

            else




                return false;

        }

        else return false;
    }

    public static bool Get_BorderZoneVisibility(IPersonInApplication person)

    {

      return false;
    
    }

    public static bool Get_RegistrationVisibility(IPersonInApplication person)

    {

        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.RegistrationDataForPersonInApplication == true ) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.RegistrationDataForPersonInApplication == true))
            {
                return true;
            }

            else 
            {


                return false;
            }

          
        }

        else return false;
    
    }

    public static bool Get_VisaVisibility(IPersonInApplication person)

    {
        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.VisaVisibleForPersonInApplication == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.VisaVisibleForPersonInApplication == true))
            {
                return true;
            }

            else 
            


                return false;
            

          
        }

        else return false;
    
    }

    //WorkPermitVisibility

    public static bool Get_WorkPermitVisibility(IPersonInApplication person)
    {
        if (person.Application != null && person.Application.BaseApplicationType != null)
        {



            if (person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.WorkPermitForPersonInLineVisible == true )
            {


                return true;

            }

            else if (person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.WorkPermitForPersonInLineVisible == true &&  (person.Application.IsWizaWithWorkPermitVisibility && person.Application.IsWizaWithWorkPermit.WizaAndWorkPermitRequired == IsWPForWizaRequired.WizaAndWorkPermit))
            {


                return true;


            }
            else return false;




        }
        else return false;


            


    }

    public static bool Get_PreviousPassportVisibility(IPersonInApplication person)

    {

        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.PreviousPassportInAppLineVisible == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.PreviousPassportInAppLineVisible == true))
            {
                return true;
            }

            else



                return false;



        }

        else return false;
    
    }


    public static bool Get_RegistrationNumberAndDateVisibility(IPersonInApplication person)


    {


        if (person.Application != null && person.Application.BaseApplicationType != null)
        {

            if ((person.Application.ApplicationTypeForEmployee != null && person.Application.ApplicationTypeForEmployee.RegistrationNumberAndDateVisible == true) || (person.Application.ApplicationTypeForFamilyMember != null && person.Application.ApplicationTypeForFamilyMember.RegistrationNumberAndDateVisible == true))
            {
                return true;
            }

            
            else return false;
        }

        else return false;
    }

    public static bool GetFMVisibility(IPersonInApplication person)
    {

        if (person.Application.ForFamilyMember)
        {

            return true;

        }
        else
            return false;

    }

    public static IApplicationResult Get_Invitation(IPersonInApplication personInApp)



    {
        if (personInApp.Application != null && personInApp.Application.ForEmployee)
        {
            return Helper.Get_Invit(personInApp.Application, personInApp.Employee);
        }
        else if (personInApp.Application != null && personInApp.Application.ForFamilyMember)
        {
            return Helper.Get_Invit(personInApp.Application, personInApp.FamilyMember);
        }



        else return null;
    }

    public static IApplicationResult Get_RejectionLet(IPersonInApplication personInApp)
    {

        if (personInApp.Application != null && personInApp.Application.ForEmployee)
        {
            return Helper.Get_Rejection(personInApp.Application, personInApp.Employee);
        }
        else if (personInApp.Application != null && personInApp.Application.ForFamilyMember)
        {
            return Helper.Get_Rejection(personInApp.Application, personInApp.FamilyMember);
        }



        else return null;
    }
        
    public static string Get_BorderZoneCollectionForLine (IPersonInApplication personInApp)

{
    return Helper.GetBorderZoneCollectionForPersonInApplication(personInApp);
 


}


    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IPersonInApplication));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IPersonInApplication))]
    //public class IPersonInApplicationLogic {
    //    public static string Get_CalculatedProperty(IPersonInApplication instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IPersonInApplication instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IPersonInApplication instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IPersonInApplication instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
