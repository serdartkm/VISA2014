
using System;
using DevExpress.Persistent.AuditTrail;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using VISA2014.Module.BusinessObjects;
using DevExpress.Persistent.Validation;
using System.Linq;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using Spire.Pdf;
using System.IO;

namespace VISA2014.Module.DC
{


    public enum PersonType { 
    
        Employee,
        FamilyMember
    }

    public enum ApplicationForEnum

    { 
    
        Employee,
        FamilyMember
    
    }

    public enum PreferedVisaCategoryEnum

    { 
    
        OnceToMulty,
        MultyToOnce,
        OnceToTwice,
        OnceToThree,   
        MultyToTwice,
        MultyToThree,
        ThreeToMulty,
        ThreeToOnce,
        ThreeToTwo,
        TwoToOnce,
        TwoToThree,
        TwoToMulty


    
    }

    public enum SubType{
        
        ApplicationForInvitation=0,
        ApplicationForChangingInvitation=1,
        //Registration
        ApplicationForRegistrationUpOnArrival = 2,
        ApplicationForRegistrationExtention = 3,
        ApplicationForRegisteringToANewLocation = 4,
        ApplicationForChagingInformation = 5,
        ApplicationForStrikeOffRegister = 6,
        //Visa
        ApplicationForVisaExtention = 7,
        ApplicationForChangingVisaCategory = 8,
        //Passport
        ApplicationForChangingPassport = 9,
        ApplicationForSevicePasport = 10,
        // BorderZone
        ApplicationForBorderZonePermision = 11,
        ApplicationForCancellingVisaAndWorkpermit = 12,
        ApplicationForGoBusinessTrip = 13,
        ApplicationForCameFromBusinessTrip = 14,
        //WorkPermit
        ApplicationForExtendingWorkPermitLocation = 15,
        None=16,
        RugsatnamaMöhletineGöräÇakylyk =20,
        VisaExtentionAccordingToWorkPermit=37,
        ApplicationForCancellingVisa = 21,
        ApplicationForCancellingWorkPermit =22,
        ApplicationForCancellingWorkPermitAndInvitation=33,
        ApplicationForExitVisa =55
        
    }




    public enum AppWithOrWithoutWP

    { 
    
        Wiza,
        WizaAndWorkPermit

    
    }

    public enum AppType
    {
        Invitation,
        Registration,
        Visa,
        BorderZone,
        WorkPermit,
        BuzinessTrip,
        Others,
        Cancelling

    }


    public enum AppUrgency

    { 
    Adaty,
    Gyssagtly,
    ÖränGyssagly
    
    }

    public enum ChooseBorderZoneTypeEnum
    { 
    BorderZoneIsNotRequired,
   // BorderZoneForIndividual,
    BorderZoneForApplication
    
    
    }

    public enum ApplicationStateEnum

    { 
    Office,
    ToMinistery,
    FromMinistery,
    OnProcess,
    Processed,
    Rejected,
    VisaExtended,
    CategoryChanged,
    Transfered,
    Cancelled,
    VisaExtendedWorkPermitNot,
    InvitationIssuedWorkPermitNot,
    Expiring,
    Expired,
    Valid,
    Extended,
    Previous,
   
    None


    
    }

    public enum StrikeOffTypeEnum

    { 
    
    LeavingTheCountry,
    ChangingRegistrationLocation
    
    }

    public enum ChangeInfoEnum

    { 
    
    Address,
    Passport,
    VisaCategory

    
    }

    [NavigationItem(true, GroupName = "Configuration")]
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("id")]
    public interface IPlural : IPluralForeignCitizen, IPluralFamilyMember , IPluralWiza,IPluralWizaAndWorkPermit, IPluralInvitation,IPluralInvitationAndWorkPermit, IPluralBorderZone,IPluralRugsat

    {
        
        [VisibleInListView(false)]
        string Plural1 { get; set; }
        [VisibleInListView(false)]
        string Single1 { get; set; }
     

        [VisibleInListView(false)]
        string Plural2 { get; set; }
        [VisibleInListView(false)]
        string Single2 { get; set; }
       

        [VisibleInListView(false)]
        string Plural3 { get; set; }
        [VisibleInListView(false)]
        string Single3 { get; set; }
        [VisibleInListView(false)]
        int id { get; set; }



    
    }



    [DomainLogic(typeof(IPlural))]
    public class PluralLogic

    {

        public void AfterConstruction(IPlural plural)

        {

            plural.id = 1;
    
    
        }

       
    
    
    }


    [DomainComponent]
    [XafDefaultProperty("ApplicationNumber")]
    public interface IRegistration

    {
       


        [VisibleInListView(false)]
        [Appearance("ManualAutoApplicationDate", Enabled= false, Criteria = "!Manual")]
        DateTime ManualApplicationDate { get; set; }

        [VisibleInListView(false)]
        [Appearance("ManualAutoApplicationNumber", Enabled=false, Criteria = "!Manual")]
        string ManualApplicationNumber { get; set; }

        [Browsable(false)]
        bool Manual { get;}
   //    [Appearance("RegistrationNumber", Visibility = ViewItemVisibility.Hide, Criteria = "Manual")]
        [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
        string RegistrationNumber { get; }
      // [Appearance("RegistrationDate", Visibility = ViewItemVisibility.Hide, Criteria = "Manual")]
        string RegistrationDate { get; }

     
    }
    [DomainLogic(typeof(IRegistration))]
    public class RegistrationLogic
    {

     


        public static string Get_RegistrationNumber(IRegistration reg)

        {


            if (reg.ManualApplicationNumber != null && !reg.Manual)
            {
                return   reg.ManualApplicationNumber.ToString();

            }
            else if (reg.ManualApplicationNumber != null && reg.Manual)

            {

                return reg.ManualApplicationNumber.ToString();
            }


            else return null;
           
        
        }

        public static string Get_RegistrationDate(IRegistration reg)

        {

            if (reg.ManualApplicationDate != null)
            {

                return reg.ManualApplicationDate.ToString("dd.MM.yyyy");
            }
            else return null;

           
        
        
        }
        
        

    }

    [DomainComponent]

    [XafDefaultProperty("ApplicationUrgency")]
    public interface IUrgency
    {
        
        AppUrgency ApplicationUrgency { get; set; }
        
        string ApplicationUrgencyH { get; set; }

        int Priority { get; set; }
            [Browsable(false)]
        string mgCode { get; set; }

        [VisibleInListView(false),VisibleInLookupListView(false)]

        string ApplicationUrgencyL { get; set; }
    }


    [DomainComponent]
    

    [XafDefaultProperty("PeriodOfVisa")]
    public interface IVisaPeriod
    {
        [RuleRequiredField]
        string PeriodOfVisa { get; set; }
        [RuleRequiredField]
        [VisibleInListView(false)]
        string PeriodOfVisaL { get; set; }
        Int16 PeriodInNumber { get; set; }
            [Browsable(false)]
        string mgCode { get; set; }

        int CountMonth { get; set; }
    }

    #region Application Appearence

    [Appearance("Office", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "ApplicationState='Office'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance(">>Ministery", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "ApplicationState='ToMinistery'", BackColor = "Turquoise", FontColor="Black")]

    [Appearance("Ministery>>", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "ApplicationState='FromMinistery' ", BackColor = "RoyalBlue", FontColor = "White")]


    [Appearance("OnProcessSP", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = " ApplicationState='OnProcess'", BackColor = "Gold",FontColor="Black")]


    [Appearance("Processed", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "ApplicationState='Processed'", BackColor = "MediumSeaGreen", FontColor = "White")]
 
    // Urgency Appearence 


    [Appearance("Urgent", AppearanceItemType = "ViewItem", TargetItems = "Urgency", Context = "DetailView",
    Criteria = "Urgency.ApplicationUrgency ='Gyssagtly'", BackColor = "Orange", FontColor = "Black")]

    [Appearance("TopUrgent", AppearanceItemType = "ViewItem", TargetItems = "Urgency", Context = "DetailView",
   Criteria = "Urgency.ApplicationUrgency ='ÖränGyssagly'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("Cancelled", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "ApplicationState='Cancelled'", BackColor = "WhiteSmoke", FontColor = "Black")]

    [Appearance("RejectedAppState", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = "ApplicationState='Rejected'", BackColor = "Red", FontColor = "White")]

    #endregion
    
    [VisibleInReports]

    #region Rule required field
    [RuleCriteria("12", DefaultContexts.Save, "BaseApplicationType Is Not Null",
"Işiň görnüşini saýlamaly", SkipNullOrEmptyValues = false)]
   

    [RuleCriteria("1", DefaultContexts.Save, "(AppliedMinisteryVisibility=true And Contract Is Not Null) Or (AppliedMinisteryVisibility=false And Contract Is Null)",
   "Şertnamany saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("2", DefaultContexts.Save, "(AppliedMinisteryVisibility=true And AppliedMinistery Is Not Null) Or (AppliedMinisteryVisibility=false And AppliedMinistery Is Null)",
  "Ýüz tutulan edarany saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("3", DefaultContexts.Save, "(UrgencyVisibility=true And Urgency Is Not Null) Or (UrgencyVisibility=false And Urgency Is Null) Or (UrgencyVisibility=false And Urgency Is Not Null) ",
"Gyssaglylygy saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("4", DefaultContexts.Save, "(VisaPeriodVisibility=true And VisaPeriod Is Not Null) Or (VisaPeriodVisibility=false And VisaPeriod Is Null)",
"Wiza möhletini saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("5", DefaultContexts.Save, "(VisaCategoryVisibility=true And VisaCategory Is Not Null) Or (VisaCategoryVisibility=false And VisaCategory Is Null)",
"Wiza kategoriýasyny saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("6", DefaultContexts.Save, "(IsInvitationWithWorkPermitVisibility=true And IsInvitationWithWorkPermit Is Not Null) Or (IsInvitationWithWorkPermitVisibility=false And IsInvitationWithWorkPermit Is Null)",
"Çakylygyň iş rugsatnamaly ýa-da iş rugsatnamasyz görnüşini saýlamaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("7", DefaultContexts.Save, "(IsWizaWithWorkPermitVisibility=true And IsWizaWithWorkPermit Is Not Null) Or (IsWizaWithWorkPermitVisibility=false And IsWizaWithWorkPermit Is Null)",
"Wizanyň iş rugsatnamaly ýa-da iş rugsatnamasyz görnüşini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("8", DefaultContexts.Save, "(ForFamilyMember =true And ApplicationTypeForFamilyMember Is Not Null) Or (ForFamilyMember =false And ApplicationTypeForFamilyMember Is Null)",
"Maşgala agza üçin ýüztutmanyň görnüşi boş bolmaly däl", SkipNullOrEmptyValues = false)]
    [RuleCriteria("9", DefaultContexts.Save, "((ForFamilyMember =true And BaseApplicationType Is Not Null) Or (ForFamilyMember =false And BaseApplicationType Is Null)) Or ((ForEmployee =true And BaseApplicationType Is Not Null) Or (ForEmployee =false And BaseApplicationType Is Null))",
"Işiň görnüşini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("10", DefaultContexts.Save, "(ForEmployee =true And  ApplicationTypeForEmployee  Is Not Null) Or (ForEmployee =false And ApplicationTypeForEmployee Is Null)",
"Işgär üçin ýüztutmanyň görnüşini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("11", DefaultContexts.Save, "(ForEmployee =true Or ForFamilyMember =true)",
"Işgäri ýa-da maşgala agzany saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("13", DefaultContexts.Save, "(BorderZonePeriodVisibility = false And BorderZonePeriod Is Null ) Or (BorderZonePeriodVisibility = true And BorderZonePeriod Is Not Null ) ",
"Serhet ýaka rugsat möhletini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("14", DefaultContexts.Save, "(BorderZoneVisibility=true And ChooseBorderZoneType ='BorderZoneIsNotRequired' And  IsNullOrEmpty(BorderZoneForVisa)) Or (BorderZoneVisibility=true And ChooseBorderZoneType ='BorderZoneForApplication' And Not  IsNullOrEmpty(BorderZoneForVisa)) Or (BorderZoneVisibility=false And  IsNullOrEmpty(BorderZoneForVisa)) ",
"Serhet ýakany saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("15", DefaultContexts.Save, " (InvitationToBeChangedVisibility=false And InvitationToBeChanged Is Null) Or (InvitationToBeChangedVisibility = true And InvitationToBeChanged Is Not Null) ",
"Çalyşylmaly çakylygy saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("16", DefaultContexts.Save, " (DepartmentForRegistrationVisibility=false And DepartmentForRegistration Is Null) Or (DepartmentForRegistrationVisibility = true And DepartmentForRegistration Is Not Null) ",
"Ýüz tutulýan edarany saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("17", DefaultContexts.Save, "(RegistrationLocationVisibility=false And NewRegistrationLocation Is Null) Or (RegistrationLocationVisibility = true And NewRegistrationLocation Is Not Null) ",
"Täze hasaba goýuljak ýeri saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("18", DefaultContexts.Save, " (RegistrationLocationVisibility=false And PreviousRegistrationLocation Is Null) Or (RegistrationLocationVisibility = true And PreviousRegistrationLocation Is Not Null) ",
"Öňki hasaba duran ýerini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("19", DefaultContexts.Save, " (PrefferedVisaCategoryVisibility=false And PrefferedVisaCategory Is Null) Or (PrefferedVisaCategoryVisibility = true And PrefferedVisaCategory Is Not Null) ",
  "Islenilýän wiza kategoriýasyny saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("20", DefaultContexts.Save, " (BusinessTripDestinationVisibility=false And BusinessTripDestination Is Null) Or (BusinessTripDestinationVisibility = true And BusinessTripDestination Is Not Null) ",
"Iş saparyna barýan ýerini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("21", DefaultContexts.Save, "(BusinessTripDestinationVisibility=false And DateOfDeparture Is Not Null) Or (BusinessTripDestinationVisibility=false And DateOfDeparture Is Null) Or (BusinessTripDestinationVisibility = true And DateOfDeparture Is Not Null) ",
"Iş saparyna ugrajak senesini saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("22", DefaultContexts.Save, " (BusinessTripDestinationVisibility=false And DurationOfStay = 0) Or (BusinessTripDestinationVisibility = true And DurationOfStay >0) ",
"Iş saparynda boljak gün sanyny  ýazmaly", SkipNullOrEmptyValues = false)]

    #endregion
   
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("ApplicationAndASNumber")]
    public interface IApplication : IRegistration, IApplicationForBorderZonePermit
   {
        [ImmediatePostData,VisibleInListView(false),VisibleInLookupListView(false)]
        bool AutoRegistration { get; set; }
        int Counter { get; set; }
        bool CreatePDF_SK { get; set; }
       [Appearance("RejectedApp", Enabled = false, Criteria = "IsComplete Or Cancelled"), ImmediatePostData]
        bool Rejected { get; set; }
        FileData SahsyKagyz { get; set; }
        [Appearance("IsCompleteApp", Enabled = false, Criteria = "Rejected Or Cancelled"), ImmediatePostData]
        bool IsComplete { get; set; }

        [VisibleInDetailView(false),VisibleInListView(true)]
        SubType SubType { get; }
        [VisibleInDetailView(false), VisibleInListView(true)]
        ApplicationForEnum ApplicationFor { get; }

        [Browsable(false)]

        AppConf AppConf { get; set; }
         
        [ImmediatePostData,VisibleInListView(false)]
     
         [Appearance("ForEmployee", Visibility = ViewItemVisibility.Hide, Criteria = "ForFamilyMember")]
         bool ForEmployee { get; set; }
      
         [ImmediatePostData, VisibleInListView(false)]

     
         [Appearance("ForFamilyMember", Visibility = ViewItemVisibility.Hide, Criteria = "ForEmployee")]
         bool ForFamilyMember { get; set; }

         [ImmediatePostData,VisibleInListView(false)]
         [Appearance("BaseApplicationType", Visibility = ViewItemVisibility.Hide, Criteria = "ForEmployee=false And ForFamilyMember=false")]
         BaseApplicationType BaseApplicationType { get; set; }
         

         #region Appearence
          [ImmediatePostData]
          [Browsable (false)]
           bool IsInvitationWithWorkPermitVisibility { get;}
          [Appearance("IsInvitationWithWorkPermit1", Visibility = ViewItemVisibility.Hide, Criteria = "IsInvitationWithWorkPermitVisibility =false")]
         #endregion
          [ImmediatePostData,VisibleInListView(false)]
          IsInvitationWithWorkPermit IsInvitationWithWorkPermit { get; set; }

         #region Appearence

          [ImmediatePostData]
          [Browsable(false)]
         bool IsWizaWithWorkPermitVisibility { get; }

        [Appearance("IsWizaWithWorkPermit", Visibility = ViewItemVisibility.Hide, Criteria = "IsWizaWithWorkPermitVisibility  =false")]
#endregion

         IsWizaWithWorkPermit IsWizaWithWorkPermit { get; set; }

      

         [DataSourceProperty("BaseApplicationType.ApplicationTypeForEmployees")]

         [ImmediatePostData, VisibleInListView(false)]
         #region          Appearence
        [Appearance("AppTypeEmp", Visibility = ViewItemVisibility.Hide, Criteria = " ForEmployee=false")]
        [Appearance("AppTypeEmp1", Visibility = ViewItemVisibility.Hide, Criteria = "BaseApplicationType Is Null")]
         #endregion

         ApplicationTypeForEmployee ApplicationTypeForEmployee { get; set; }
    
         [DataSourceProperty("BaseApplicationType.ApplicationTypeForFamilyMembers")]
         [ImmediatePostData , VisibleInListView(false)]
         #region          Appearence
         [Appearance("AppTypeFM", Visibility = ViewItemVisibility.Hide, Criteria = "ForFamilyMember =false")]
         [Appearance("AppTypeFM1", Visibility = ViewItemVisibility.Hide, Criteria = "BaseApplicationType Is Null")]
         #endregion
         ApplicationTypeForFamilyMember ApplicationTypeForFamilyMember { get; set; }

         #region Registration



         #region Appearence
         [Browsable(false)]
         [ImmediatePostData]
         bool StrikeOffTypeVisibility { get; }
         [Appearance("StrikeOffType", Visibility = ViewItemVisibility.Hide, Criteria = "StrikeOffTypeVisibility=false")]
         #endregion
         [ImmediatePostData]
          StrikeOffTypeEnum StrikeOffType { get; set; }
         #region Appearence
       
        
        [Browsable(false),ImmediatePostData]
        bool RegistrationLocationVisibility { get; }
        [Appearance("NewRegistrationLocation", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationLocationVisibility=false")]
#endregion
          [VisibleInListView(false)]
         IŞäherEtrap NewRegistrationLocation { get; set; }

         [Appearance("PreviousRegistrationLocation", Visibility = ViewItemVisibility.Hide, Criteria = "RegistrationLocationVisibility=false")]
         [VisibleInListView(false)]
         IŞäherEtrap PreviousRegistrationLocation { get; set; }


       

        [VisibleInDetailView(false),VisibleInListView(false)]
         string NewRegistrationLocationInLetter { get; }

        string PreviousRegistrationLocationInLetter { get;}


        [Browsable(false),ImmediatePostData]
        bool ChangeInformationVisibility { get; }
         [Appearance("ChangeInformation", Visibility = ViewItemVisibility.Hide, Criteria = "ChangeInformationVisibility=false")]
        ChangeInfoEnum ChangeInformation { get; set; }


#endregion
       
        
        // BUSINESS TRIP


        
            #region Appearence
         [Browsable(false)]

         bool BusinessTripDestinationVisibility { get; }
         [Appearance("BusinessTripDestination", Visibility = ViewItemVisibility.Hide, Criteria = "BusinessTripDestinationVisibility=false")]
         #endregion
           [ImmediatePostData]
           IŞäherEtrap BusinessTripDestination { get; set; }
           [VisibleInDetailView(false), VisibleInListView(false)]
           string BusinessTripDestinationInLetter { get; }

           [Appearance("DateOfDeparture", Visibility = ViewItemVisibility.Hide, Criteria = "BusinessTripDestinationVisibility=false")]
           DateTime DateOfDeparture { get; set; }
           [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
           string DateOfDepartureInLetter { get; }
          
           [ImmediatePostData]
           [Appearance("DurationOfStay", Visibility = ViewItemVisibility.Hide, Criteria = "BusinessTripDestinationVisibility=false")]
           int DurationOfStay { get; set; }
           [Appearance("EndOfBusinessTrip", Visibility = ViewItemVisibility.Hide, Criteria = "BusinessTripDestinationVisibility=false")]
           string EndOfBusinessTrip { get;}

        

        // END BUSINESS TRIP

        #region          Appearence

        [ImmediatePostData]
        [Browsable(false)]
         bool UrgencyVisibility {get;}
         [Appearance("Urgency", Visibility = ViewItemVisibility.Hide, Criteria = "UrgencyVisibility =false")]

         #endregion
            
        [ImmediatePostData]
      
        IUrgency Urgency { get; set; }

         #region Appearence
         [ImmediatePostData]
         [Browsable(false)]

         bool DepartmentForRegistrationVisibility { get; }
         [Appearance("DepartmentForRegistration", Visibility = ViewItemVisibility.Hide, Criteria = "DepartmentForRegistrationVisibility =false")]
#endregion

         DepartmentForRegistration DepartmentForRegistration { get; set; }

       

          #region           Appearence

         [ImmediatePostData]
         [Browsable(false)]

         bool AppliedMinisteryVisibility { get; }

        [Appearance("AppliedMinistery", Visibility = ViewItemVisibility.Hide, Criteria = "AppliedMinisteryVisibility =false")]

         #endregion
         [ImmediatePostData]
         IAppliedMinistery AppliedMinistery {get;set;}
         
      

         #region Appearence
       

         [Appearance("InvitationContract", Visibility = ViewItemVisibility.Hide, Criteria = "AppliedMinisteryVisibility =false")]
#endregion
        [ImmediatePostData]
        [DataSourceProperty("AppliedMinistery.Contracts")]
      
        IContract Contract { get; set; }



         #region Apprearence


          [Appearance("PersonInApplication1", Visibility = ViewItemVisibility.Hide, Criteria = "ForEmployee And ApplicationTypeForEmployee Is Null")]
          [Appearance("PersonInApplication2", Visibility = ViewItemVisibility.Hide, Criteria = "ForFamilyMember And ApplicationTypeForFamilyMember Is Null")]
          [Appearance("PersonInApplication3", Visibility = ViewItemVisibility.Hide, Criteria = "!ForFamilyMember And !ForEmployee")]
#endregion

         [DevExpress.Xpo.Aggregated]
        
               [BackReferenceProperty("Application")]
        IList<IPersonInApplication> PersonInApplication { get; }

      
         
           [ImmediatePostData]
           DateTime ProcessDate { get; set; }
         

           #region Appearence
          [Browsable(false),ImmediatePostData]
           bool processNumberVisibility { get; }
          [Appearance("ProcessNumber", Visibility = ViewItemVisibility.Hide, Criteria = "processNumberVisibility=false")]
           #endregion

           string ProcessNumber { get; set; }

       
        
           #region Appearence



        [Appearance("DateForwardedToMonistery", Visibility = ViewItemVisibility.Hide, Criteria = "AppliedMinisteryVisibility =false")]
 
#endregion
            [ImmediatePostData]
            DateTime DateForwardedToMonistery { get; set; }
     
           #region Appearence 

          [Appearance("MinisteriesDocumentDate", Visibility = ViewItemVisibility.Hide, Criteria = "AppliedMinisteryVisibility =false")]

        
 
#endregion
          [ImmediatePostData]
           DateTime MinisteriesDocumentDate { get; set; }
      
          #region Appearence

       [Appearance("MinisteriesDocumentNumber", Visibility = ViewItemVisibility.Hide, Criteria = "AppliedMinisteryVisibility =false")]

        #endregion
          [ImmediatePostData]
          string MinisteriesDocumentNumber { get; set; }

        // BorderZones
     
          #region          Appearence
       
         [ImmediatePostData]
         [Browsable(false)]

         bool BorderZoneVisibility { get; }
         [Appearance("ChooseBorderZone", Visibility = ViewItemVisibility.Hide, Criteria = "BorderZoneVisibility=false")]
          #endregion
         [ImmediatePostData, VisibleInListView(false)]
         ChooseBorderZoneTypeEnum ChooseBorderZoneType { get; set; }
       



        // Application For Invitation
     
         #region          Appearence
         [ImmediatePostData]
         [Browsable(false)]
         bool VisaPeriodVisibility { get;}

         [Appearance("VisaPeriod", Visibility = ViewItemVisibility.Hide, Criteria = "VisaPeriodVisibility =false")]

        #endregion
        
        
   
         [ImmediatePostData]
        IVisaPeriod VisaPeriod { get; set; }
       
         
         #region          Appearence
         [ImmediatePostData]
         [Browsable(false)]
         bool VisaCategoryVisibility { get; }

         [Appearance("VisaCategory", Visibility = ViewItemVisibility.Hide, Criteria = "VisaCategoryVisibility =false")]

        
        
         

        #endregion
       

        [ImmediatePostData]
        IVisaCategory VisaCategory { get; set;}
         [RuleRequiredField]

         #region Signing Person

        [ImmediatePostData]
        [Browsable(false)]
         bool SigningPersonVisibility { get; }
         [Appearance("SigningPerson", Visibility = ViewItemVisibility.Hide, Criteria = "SigningPersonVisibility =false")]
#endregion

         [RuleRequiredField]
        ICompany SigningPerson { get; set; }
        [DevExpress.Xpo.Aggregated]

        #region Appearence
        [ImmediatePostData]
        [Browsable(false)]
         bool ApplicationResultVisibility { get; }
       [Appearance("Invitations2", Visibility = ViewItemVisibility.Hide, Criteria = "ApplicationResultVisibility =false")]
       [Appearance("Invitations3", Visibility = ViewItemVisibility.Hide, Criteria = "ProcessDate Is Null")]
       #endregion

        [ImmediatePostData,DevExpress.Xpo.Aggregated]
        [BackReferenceProperty("Application")]
        IList<IApplicationResult> ApplicationResult { get; }


      

        #region Appearence
        [ImmediatePostData]
        [Browsable (false)]
        bool InvitationToBeChangedVisibility { get;  }


        [Appearance("InvitationToBeChanged1", Visibility = ViewItemVisibility.Hide, Criteria = "InvitationToBeChangedVisibility =false")]
        #endregion
        [ImmediatePostData,VisibleInListView(false),VisibleInLookupListView(false)]
        IApplicationResult InvitationToBeChanged { get; set; }

         
        #region Appearence

        [ImmediatePostData,Browsable(false)]
        bool PrefferedVisaCategoryVisibility { get; }
        [Appearance("PrefferedVisaCategory", Visibility = ViewItemVisibility.Hide, Criteria = "PrefferedVisaCategoryVisibility =false")]
        #endregion

        PrefferedVisaCategory PrefferedVisaCategory { get; set; }

        #region Appearence

        [ImmediatePostData, Browsable(false)]
        bool GoşmaçaIşlemägeRugsatÝeriVisibility { get; }

         [Appearance("GoşmaçaIşlemägeRugsatÝeriVisibility", Visibility = ViewItemVisibility.Hide, Criteria = "GoşmaçaIşlemägeRugsatÝeriVisibility =false")]
        #endregion


        GoşmaçaIşlemägeRugsatÝeri GoşmaçaIşlemägeRugsatÝeri { get; set; }



        #region Apprearence


        [Appearance("NumberOfPerson1", Visibility = ViewItemVisibility.Hide, Criteria = "ForEmployee And ApplicationTypeForEmployee Is Null")]
        [Appearance("NumberOfPerson2", Visibility = ViewItemVisibility.Hide, Criteria = "ForFamilyMember And ApplicationTypeForFamilyMember Is Null")]
        [Appearance("NumberOfPerson3", Visibility = ViewItemVisibility.Hide, Criteria = "!ForFamilyMember And !ForEmployee")]
        #endregion

        [ImmediatePostData, VisibleInDetailView(false), VisibleInListView(false)]
        string NumberOfPerson { get; }

        [ImmediatePostData,VisibleInDetailView(false),VisibleInListView(false)]
        IPlural Plural { get; set; }

        #region Plural



         [VisibleInListView(false), VisibleInDetailView(false)]
        [ImmediatePostData]
        string PluralForeignCitizen_ВП { get; }
        [ImmediatePostData]
         [VisibleInListView(false), VisibleInDetailView(false)]
         string PluralForeignCitizen_ДП { get; }

        [ImmediatePostData]
        [VisibleInListView(false), VisibleInDetailView(false)]
        string PluralForeignCitizen_РП { get; }

        [VisibleInListView(false), VisibleInDetailView(false)]
        string IPluralFamilyMember_ВП { get; }

        [VisibleInListView(false), VisibleInDetailView(false)]
        string IPluralFamilyMember_ДП { get; }

         [VisibleInListView(false), VisibleInDetailView(false)]
        string PluralWiza_ВП { get; }
         [VisibleInListView(false), VisibleInDetailView(false)]
         string PluralWiza_РП { get; }


        [VisibleInListView(false), VisibleInDetailView(false)]
        string PluralWizaAndWorkPermit_ВП { get; }

         [VisibleInListView(false), VisibleInDetailView(false)]
        string PluralInvitation_ВП { get; }

         [VisibleInListView(false), VisibleInDetailView(false)]
        string PluralInvitationAndWorkPermit_ВП { get; }

         [VisibleInListView(false), VisibleInDetailView(false)]
         string PluralBorderZone_ВП { get; }

        #endregion
        [ImmediatePostData, VisibleInListView(false)]
        string RelationShipInLetterFM { get; }
        [ImmediatePostData,VisibleInListView(false)]
        string RelationShipInLetterEmp { get; }

        ApplicationStateEnum ApplicationState { get; }
        [VisibleInListView(false),VisibleInLookupListView(false)]
        string ApplicationAndASNumber { get; }
     
        IList<IWorkPermit> WorkPermit { get; }
       
        [Browsable(false)]
        int CurrentYear { get; set; }


        string NumberOfPages { get; set; }


        #region Appearence

        [ImmediatePostData, Browsable(false)]
        bool BellikVisibility { get; }

        [Appearance("BellikVisibility", Visibility = ViewItemVisibility.Hide, Criteria = "BellikVisibility =false")]
        #endregion

        Bellik Bellik { get; set; }



        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }

         [VisibleInListView(false), VisibleInLookupListView(false),VisibleInDetailView(false)]
        string PersonNumberInLetter { get; }
         [Appearance("CancelledApp", Enabled = false, Criteria = "IsComplete Or Rejected"), ImmediatePostData]
         bool Cancelled { get; set; }
    }
    [DomainLogic(typeof(IApplication))]
   public class ApplicationLogic
   
   {

        public static void AfterChange_IsComplete(IApplication application) {


            if (application.IsComplete)
            {
                foreach (var item in application.PersonInApplication)
                {
                    if (!item.Cancelled && !item.Rejected) {
                        item.IsComplete = true;
                    }

                }
            }
          
        }

        public static void AfterChange_Rejected(IApplication application) {

            if (application.Rejected)
            {
                foreach (var item in application.PersonInApplication)
                {
                    item.Rejected = true;
                    item.IsComplete = false;
                    item.Cancelled = false;
                    
                }

           
            }
            else {
                foreach (var item in application.PersonInApplication)
                {
                    item.Rejected = false;
                }
            
            }
           
        
        }
        public static void AfterChange_Cancelled(IApplication application) {

            if (application.Cancelled)
            {

                foreach (var item in application.PersonInApplication)
                {
                    item.Cancelled = true;
                    item.IsComplete = false;
                    item.Rejected = false;
                }

              
            }
            else {

                foreach (var item in application.PersonInApplication)
                {
                    item.Cancelled = false;
                    
                }
            }
          
        }
        public static string Get_PersonNumberInLetter(IApplication application)


        {

            int countPerson = 0;

            if (application.PersonInApplication.Count > 0)
            {

                countPerson = application.PersonInApplication.Count;

                switch (application.PersonInApplication.Count)
                {
                    case 1:

                        return "bir";

                    case 2:

                        return "iki";
                    case 3:

                        return "üç";
                    case 4:

                        return "dört";
                    case 5:

                        return "bäş";
                    case 6:

                        return "alty";
                    case 7:

                        return "ýedi";
                    case 8:

                        return "sekiz";
                    case 9:

                        return "dokuz";
                    case 10:

                        return "on";
                    case 11:

                        return "on bir";
                    case 12:

                        return "on iki";
                    case 13:

                        return "on üç";
                    case 14:

                        return "on dört";
                    case 15:

                        return "on bäş";
                    case 16:

                        return "on alty";
                    case 17:

                        return "on ýedi";
                    case 18:

                        return "on sekiz";
                    case 19:

                        return "on dokuz";
                    case 20:

                        return "ýigrimi";
                    case 21:

                        return "ýigrimi bir";
                    case 22:

                        return "ýigrimi iki";
                    case 23:

                        return "ýigrimi üç";
                    case 24:

                        return "ýigrimi dört";
                    case 25:

                        return "ýigrimi bäş";
                    case 26:

                        return "ýigrimi alty";
                    case 27:

                        return "ýigrimi ýedi";
                    case 28:

                        return "ýigirimi sekiz";
                    case 29:

                        return "ýigirimi dokuz";
                    case 30:

                        return "otuz";
                    case 31:

                        return "otuz bir";
                    case 32:

                        return "otuz iki";
                    case 33:

                        return "otuz üç";
                    case 34:

                        return "otuz dört";
                    case 35:

                        return "otuz bäş";
                    case 36:

                        return "otuz alty";
                    case 37:

                        return "otuz ýedi";
                    case 38:

                        return "otuz sekiz";
                    case 39:

                        return "otuz dokuz";
                    case 40:

                        return "kyrk";
                    case 41:

                        return "kyrk bir";
                    case 42:

                        return "kyrk iki";
                    case 43:

                        return "kyrk üç";
                    case 44:

                        return "kyrk dört";
                    case 45:

                        return "kyrk bäş";
                    case 46:

                        return "kyrk alty";
                    case 47:

                        return "kyrk ýedi";
                    case 48:

                        return "kyrk sekiz";
                    case 49:

                        return "kyrk dokuz";
                    case 50:

                        return "elli";

                    default: return null;
                }



            }
            else return null;
            
        
        
        
        }


        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IApplication application, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, application);

        }

        public static string Get_DateOfDepartureInLetter(IApplication application)

        {

            if (application.BusinessTripDestinationVisibility == true && application.DateOfDeparture != null && application.DurationOfStay >0)
            {

                return application.DateOfDeparture.ToString("dd.MM.yyyy");

            }
            else return null;
        }


        public static string Get_EndOfBusinessTrip(IApplication application)

        {

            if (application.BusinessTripDestinationVisibility == true && application.DateOfDeparture != null && application.DurationOfStay > 0)
            {
            
                return application.DateOfDeparture.AddDays(application.DurationOfStay - 1).ToString("dd.MM.yyyy");

            }
            else return "";
        
        }


        public static void AfterChange_BaseApplicationType(IApplication app)

        {

            app.ApplicationTypeForEmployee = null;
            app.ApplicationTypeForFamilyMember = null;
            app.BorderZonePeriod = null;
            app.BorderZoneForVisa = null;        
            app.NewRegistrationLocation=null;
            app.PreviousRegistrationLocation =null;     
            app.DepartmentForRegistration=null;
            app.Urgency=null;
            app.AppliedMinistery=null;
            app.Contract=null;
            app.VisaPeriod=null;
            app.VisaCategory=null;
            app.InvitationToBeChanged=null;
            app.PrefferedVisaCategory = null;
            app.DurationOfStay = 0;
           
            app.BusinessTripDestination = null;
        
        }

        public static void AfterChange_CreatePDF_SK(IApplication app, IObjectSpace os) {

            if (app.CreatePDF_SK) {
                string fileName = "SahsyKagyz_" + DateTime.Now.Ticks;
                PdfDocument doc = new PdfDocument();
                List<string> files = new List<string>();
                for (int i = 0; i < app.PersonInApplication.Count; i++)
                {

                    //create folder for application

                    List<string> directories = new List<string>();
                    
                    string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
               
                    directories.Add(strPath + "\\" + fileName);
                    HelperFillForm.Fill(app.PersonInApplication[i]).SaveToFile(strPath + "\\" + fileName + "\\" + app.PersonInApplication[i].PersonType.FullName + ".pdf");
                   // files.Add(strPath +"\\docs\\" + app.PersonInApplication[i].PersonType.FullName + ".pdf");

                }

                for (int i = 0; i < app.PersonInApplication.Count; i++)
                {


                    //   CreateMergedPDF.MergePDF(@"d:\visanew.pdf", "D:\\docs\\");



                }
            
            
            }

           

        
        }

        public static bool Get_BusinessTripDestinationVisibility(IApplication application)

        {

            if (application.ForEmployee && application.ApplicationTypeForEmployee!=null && application.ApplicationTypeForEmployee.BusinessTripDestinationVisibility == true)
            {
                return true;

            }

            else return false;
        
        }
   
 public static void AfterConstruction (IApplication application, IObjectSpace obspace)
 {

     application.NumberOfPages = "1";
   
          application.AutoRegistration = true;

     var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
     if (appConf != null)
     {

         application.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

     }
         
         application.ManualApplicationDate = DateTime.Today; 


 

       var sPerson = obspace.FindObject<ICompany>(new BinaryOperator("CompanyId", 1));

       if (sPerson != null)
       { 
       application.SigningPerson = obspace.FindObject<ICompany>(new BinaryOperator("CompanyId",1));
       }

       var plural = obspace.FindObject<IPlural>(new BinaryOperator("id", 1));
       if (plural != null)

       {

           application.Plural = obspace.FindObject<IPlural>(new BinaryOperator("id", 1));
       
       }



       if (application.AutoRegistration)
       {
           application.CurrentYear = DateTime.Today.Year;
           int day = DateTime.Now.Day;
           int month = DateTime.Now.Month;
           bool newyear= false;
           if (day == 1 && month == 1) {
               newyear = true;
           }
           if (!newyear) {
               IList<IApplication> apps = obspace.GetObjects<IApplication>();

               IApplication app = (from num in apps where num.CurrentYear == DateTime.Now.Year select num).OrderByDescending(t => t.ManualApplicationDate).OrderByDescending(r => r.Counter).First();



               if (app.Counter == 0)
               {
                   application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (application.AppConf.StartNumber + 1).ToString();
                   application.Counter = application.AppConf.StartNumber + 1;

               }

               else if (app.Counter > 0 && app.Counter > app.AppConf.StartNumber)
               {



                   application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (app.Counter + 1).ToString();
                   application.Counter = app.Counter + 1;
               }
               else if (app.Counter < app.AppConf.StartNumber)
               {

                   application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (application.AppConf.StartNumber + 1).ToString();
                   application.Counter = application.AppConf.StartNumber + 1;

               }
           
           
           
           }
           
       
           else if (newyear) {
               IList<IApplication> apps = obspace.GetObjects<IApplication>();

               IList<IApplication> newapps = (from num in apps where num.CurrentYear == DateTime.Now.Year select num).OrderByDescending(t => t.ManualApplicationDate).OrderByDescending(r => r.Counter).ToList() ;
               if (newapps.Count == 0) {

                   application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (1).ToString();
                   application.Counter = 1;
               }
               else if (newapps.Count>0)
               {
                   int newval = 1+ application.Counter;
                   int newvalue = application.Counter+1;
                   application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (newvalue).ToString();
                   application.Counter = newvalue;
               }
               
              
           
           }
         

           }


  
      

      
       

       
   }

 public static void AfterChange_AutoRegistration(IApplication application, IObjectSpace obspace)



 {
     /*
   
     if (application.AutoRegistration )
     {
         application.CurrentYear = DateTime.Today.Year;
         if (obspace.GetObjectsCount(typeof(IApplication), null) == 0 && application.AppConf != null && application.AppConf.StartDate.Year == DateTime.Today.Year)
         {
           

             
             application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (obspace.GetObjectsCount(typeof(IApplication), null) + application.AppConf.TotalPreviousRegisteredDoc).ToString();


         }


         else if (obspace.GetObjectsCount(typeof(IApplication), null) > 0 && application.AppConf != null && application.AppConf.StartDate.Year == DateTime.Today.Year)
         {

             application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + (obspace.GetObjectsCount(typeof(IApplication), new BinaryOperator("CurrentYear", DateTime.Today.Year)) + application.AppConf.TotalPreviousRegisteredDoc).ToString();
         }

         else if (obspace.GetObjectsCount(typeof(IApplication), null) > 0 && application.AppConf != null && application.AppConf.StartDate.Year != DateTime.Today.Year)
         {

             application.ManualApplicationNumber = application.ManualApplicationDate.Month.ToString() + "/-" + obspace.GetObjectsCount(typeof(IApplication), new BinaryOperator("CurrentYear", DateTime.Today.Year)).ToString();
         }




     }
   
         */
     /*
     else
     {
         application.ManualApplicationNumber = null;
         application.CurrentYear = 0;
     }
    */
 }

 public static void AfterChange_Application(IApplication application)
   {
    
   application.ApplicationTypeForEmployee =null;
   application.ApplicationTypeForFamilyMember =null;
   
   
   
  
   }

 public static string Get_ApplicationAndASNumber(IApplication application)

 {

     return application.RegistrationNumber + ";" + application.ProcessNumber;
 
 
 }

 public static void AfterChange_ForEmployee(IApplication app)
 {





     app.BaseApplicationType = null;

     



 }


 public static void AfterChange_ForFamilyMember(IApplication app)
 {


     app.BaseApplicationType = null;


 }



 public static bool Get_Manual(IApplication application)
   {

       if (application.AutoRegistration)
       {
           return false;

       }

       else return true;


   }

 public static void AfterChange_ApplicationTypeForEmployee(IApplication application, IObjectSpace obspace)


 {
     application.Urgency = null;
     application.NewRegistrationLocation = null;
     application.PreviousRegistrationLocation = null;
     application.VisaPeriod = null;
     application.DepartmentForRegistration = null;
     application.VisaCategory = null;
     application.InvitationToBeChanged = null;
     application.PrefferedVisaCategory = null;
     application.BorderZonePeriod = null;
     application.BorderZoneForVisa = null;
    
     application.DurationOfStay = 0;
     application.BusinessTripDestination = null;

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForBorderZonePermision)
         {

             application.ChooseBorderZoneType = ChooseBorderZoneTypeEnum.BorderZoneForApplication;

         }

         if (application.ApplicationTypeForEmployee != null)
         {
             application.Urgency = Helper.Get_Urgency(application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee, obspace);


         }




    
   

     } 

 public static void AfterChange_ApplicationTypeForFamilyMember(IApplication application, IObjectSpace obspace)
 {
    

       
        


       
              application.Urgency = null;
              application.NewRegistrationLocation = null;
              application.PreviousRegistrationLocation = null;
              application.VisaPeriod = null;
              application.DepartmentForRegistration = null;
              application.VisaCategory = null;
              application.InvitationToBeChanged = null;
              application.PrefferedVisaCategory = null;
              application.BorderZonePeriod = null;
              application.BorderZoneForVisa = null;

              if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMember == SubType.ApplicationForBorderZonePermision)
              {

                  application.ChooseBorderZoneType = ChooseBorderZoneTypeEnum.BorderZoneForApplication;

              }

              if (application.ApplicationTypeForFamilyMember != null)
              {
                  application.Urgency = Helper.Get_Urgency(application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMember, obspace);


              }
     
 }

 public static ApplicationStateEnum Get_ApplicationState(IApplication application)


 { 
 // Long Process

     if (application.Rejected)
     {
         return ApplicationStateEnum.Rejected;
     }

     else
         if (application.IsComplete) {
             return ApplicationStateEnum.Processed;         
         }
         else
     if (application.Cancelled)
     {

         return ApplicationStateEnum.Cancelled;

     }

     if (application.CurrentYear < 2019 && !application.Cancelled && !application.Rejected && !application.IsComplete) {

         return ApplicationStateEnum.Processed;
     
     }

     else
     {
         return Helper.Get_ApplicationState(application);
     }

     
 }

 public static bool Get_IsInvitationWithWorkPermitVisibility(IApplication application)


 {
     if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForInvitation)

     {

         return true;
     
     }
     else


     return false;
 
 }
 //StrikeOffTypeVisibility
 public static bool Get_StrikeOffTypeVisibility(IApplication application)
 {

     if (application.ForEmployee && application.ApplicationTypeForEmployee !=null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployeeID == 7)
     {
         return true;

     }

     else if (application.ForFamilyMember && application.ApplicationTypeForFamilyMember!=null && application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMemberID == 7)
     {
         return true;

     }
     else return false;


 }

 public static bool Get_IsWizaWithWorkPermitVisibility(IApplication application)


 {

     if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForVisaExtention)
     {
         return true;

     }

     else return false;
 
 
 
 
 }

 public static bool Get_UrgencyVisibility(IApplication application)



 {

     if (application.BaseApplicationType != null)
         
     {

         if ( (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.HasUrgency == true) ||(application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.HasUrgency == true))


         {
             return true;
         }

         else
 
             
             
             
             return false;
     
     
     }
        
   

     else return false;
 
 
 }

 public static bool Get_AppliedMinisteryVisibility(IApplication application)
 {

     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.IsAplicableToMinistery == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.IsAplicableToMinistery == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 }

 public static bool Get_BorderZoneVisibility(IApplication application)


 {

     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.IsBorderZoneRequired == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.IsBorderZoneRequired == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 
 }

 public static bool Get_VisaPeriodVisibility(IApplication application)


 {

     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.IsVisaPeriodVisible == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.IsVisaPeriodVisible == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 
 }

 public static bool Get_VisaCategoryVisibility(IApplication application)

 {


     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.IsVisaCategoryVisible == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.IsVisaCategoryVisible == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 
 
 
 }

 public static bool Get_InvitationToBeChangedVisibility(IApplication application)

 {

     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.InvitationToBeChanged == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.InvitationToBeChanged == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 
 
 }

 public static bool Get_ApplicationResultVisibility(IApplication application)


 {

     if (application.ForEmployee && application.ApplicationTypeForEmployee!=null && application.ApplicationTypeForEmployee.ApplicationResultVisibility == true)
     {

         return true;

     }
     else if (application.ForFamilyMember && application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.ApplicationResultVisibility == true)
     {

         return true;

     }

     else return false;
   
 
 }

 public static bool Get_SigningPersonVisibility(IApplication application)

 {

     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.SigningPeronVisible == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.SigningPeronVisible == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 }

 public static bool Get_DepartmentForRegistrationVisibility(IApplication application)

 {
     if (application.BaseApplicationType != null)
     {

         if ((application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.DepartmentForRegistrationVisible == true) || (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.DepartmentForRegistrationVisible == true))
         {
             return true;
         }

         else




             return false;

     }

     else return false;
 
 }

 public static bool Get_RegistrationLocationVisibility(IApplication application)


 {

     if (application.ForEmployee)
     {
         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployeeID == 5)
         {

             return true;
         }

         else if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployeeID == 7 && application.StrikeOffType == StrikeOffTypeEnum.ChangingRegistrationLocation)
         {

             return true;
         }

         else return false;
     }
     

     if (application.ForFamilyMember)
     {
         if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMemberID == 5)
         {

             return true;
         }

         else if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMemberID == 7 && application.StrikeOffType == StrikeOffTypeEnum.ChangingRegistrationLocation)
         {
             return true;

         }

         else return false;
     }

     else return false;

        




     
 
 
 }

 public static bool Get_ChangeInformationVisibility(IApplication application)

 {
     if (application.ForEmployee)
     {

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.TypeOfApplicationForEmployeeID == 6)
         {
             return true;
         }
         else return false;
     }
   
         if (application.ForFamilyMember)
         {

             if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMemberID == 6)
             {
                 return true;
             }
             else return false;
         }

         else return false;

 
 }

 public static bool Get_processNumberVisibility(IApplication application)

 {

     if (application.ForEmployee)
     {

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.ProcessNumberVisible==true)
         {
             return true;
         }
         else return false;
     }

     if (application.ForFamilyMember)
     {

         if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.ProcessNumberVisible==true)
         {
             return true;
         }
         else return false;
     }

     else return false;

 
 
 }

 public static bool Get_BorderZonePeriodVisibility(IApplication application)
 {

     if (application.ForEmployee)
     {

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.BorderZonePeriodVisibility == true)
         {
             return true;
         }
         else return false;
     }

     if (application.ForFamilyMember)
     {

         if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.BorderZonePeriodVisibility == true)
         {
             return true;
         }
         else return false;
     }

     else return false;



 }

 public static bool Get_GoşmaçaIşlemägeRugsatÝeriVisibility(IApplication application)
 {

    

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.GoşmaçaIşlemägeRugsatÝeriVisibility == true)
         {
             return true;
         }
         else return false;
   

   



 }




 public static bool Get_BellikVisibility(IApplication application)
 {

    

       



         if (application.ForEmployee)
         {

             if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.BellikVisibility == true)
             {
                 return true;
             }
             else return false;
         }

         if (application.ForFamilyMember)
         {

             if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.BellikVisibility == true)
             {
                 return true;
             }
             else return false;
         }

         else return false;


 }

 public static SubType Get_SubType (IApplication app)

 {

     return Helper.Get_ApplicationType(app);
 
 }

 
 public static bool Get_PrefferedVisaCategoryVisibility(IApplication application)


 {

     if (application.ForEmployee)
     {

         if (application.ApplicationTypeForEmployee != null && application.ApplicationTypeForEmployee.PrefferedVisaCategoryVisibility)
         {
             return true;
         }
         else return false;
     }

     if (application.ForFamilyMember)
     {

         if (application.ApplicationTypeForFamilyMember != null && application.ApplicationTypeForFamilyMember.PrefferedVisaCategoryVisibility)
         {
             return true;
         }
         else return false;
     }

     else return false;
 
 
 }

 public static ApplicationForEnum Get_ApplicationFor(IApplication application)

 {

     if (application.ForEmployee)
     {
         return ApplicationForEnum.Employee;

     }
     else return ApplicationForEnum.FamilyMember;
 
 
 }
 


        #region Plurals

 
 public static string Get_PluralForeignCitizen_ВП(IApplication application)

 {



     if (application.PersonInApplication.Count > 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

         return application.Plural.DYR_ВП_PL_tkm;
         
     else
         if (application.PersonInApplication.Count ==1  && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

             return application.Plural.DYR_ВП_tkm;
         else
             if (application.PersonInApplication.Count >1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                 return application.Plural.DYR_ВП_PL_rus;
             else
                 if (application.PersonInApplication.Count ==1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                     return application.Plural.DYR_ВП_rus;
                 else return null;
 
 }

 public static string Get_PluralForeignCitizen_РП(IApplication application)
 {



     if (application.PersonInApplication.Count > 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

         return application.Plural.DYR_РП_РL_tkm;

     else
         if (application.PersonInApplication.Count == 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

             return application.Plural.DYR_РП_tkm;
         else
             if (application.PersonInApplication.Count > 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                 return application.Plural.DYR_РП_PL_rus;
             else
                 if (application.PersonInApplication.Count == 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                     return application.Plural.DYR_РП_rus;
                 else return null;

 }

 public static string Get_PluralForeignCitizen_ДП(IApplication application)
 {



     if (application.PersonInApplication.Count >1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

         return application.Plural.DYR_ДП_PL_tkm;

     else
         if (application.PersonInApplication.Count == 1  && ((application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)))

             return application.Plural.DYR_ДП_tkm;
         else
             if (application.PersonInApplication.Count > 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                 return application.Plural.DYR_ДП_PL_rus;
             else
                 if (application.PersonInApplication.Count == 1 && ((application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)))

                     return application.Plural.DYR_ДП_rus;
                 else return null;

 }

 public static string Get_IPluralFamilyMember_ВП(IApplication application)

 {


     if  (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)

         return application.Plural.FM_ВП_PL_tkm;

    
         
         else
             if (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)

                 return application.Plural.FM_ВП_PL_rus;
             
               
                 else return null;
 
 
 }

 public static string Get_IPluralFamilyMember_ДП(IApplication application)
 {


     if  (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen)

         return application.Plural.FM_ДП_tkm;


         else
             if (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian)

                 return application.Plural.FM_ДП_PL_rus;
       
                 else return null;


 }
  
 public static string Get_PluralWiza_ВП (IApplication application)

 {

     if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

         return application.Plural.Wiza_ВП_PL_tkm;

     else
         if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

             return application.Plural.Wiza_ВП_tkm;
         else
             if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                 return application.Plural.Wiza_ВП_PL_rus;
             else
                 if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                     return application.Plural.Wiza_ВП_rus;

                 else return null;
 
 }


 public static string Get_PluralWiza_РП(IApplication application)
 {

     if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

         return application.Plural.Wiza_РП_PL_tkm;

     else
         if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

             return application.Plural.Wiza_РП_tkm;
         else
             if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                 return application.Plural.Wiza_РП_PL_rus;
             else
                 if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                     return application.Plural.Wiza_РП_rus;

                 else return null;

 }
 

 public static string Get_PluralWizaAndWorkPermit_ВП(IApplication application)

 {
     if (application.IsWizaWithWorkPermit != null)
     {
         IsWPForWizaRequired wizaOrWorkPermit = application.IsWizaWithWorkPermit.WizaAndWorkPermitRequired;

         switch (wizaOrWorkPermit)
         {

             case IsWPForWizaRequired.WizaAndWorkPermit:




                 if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                     return application.Plural.WizaAndWorkPermit_ВП_PL_tkm;

                 else
                     if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                         return application.Plural.WizaAndWorkPermit_ВП_tkm;
                     else
                         if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                             return application.Plural.WizaAndWorkPermit_ВП_PL_rus;
                         else
                             if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                                 return application.Plural.WizaAndWorkPermit_ВП_rus;
                             else return null;

             case IsWPForWizaRequired.OnlyWiza:

                 if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                     return application.Plural.Wiza_ВП_PL_tkm;

                 else
                     if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                         return application.Plural.Wiza_ВП_tkm;
                     else
                         if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                             return application.Plural.Wiza_ВП_PL_rus;
                         else
                             if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                                 return application.Plural.Wiza_ВП_rus;

                             else return null;

             default:
                 return null;


         }
     }

     else return null;

 }

 public static string Get_PluralInvitation_ВП(IApplication application)


 {

    

         if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

             return application.Plural.Invitation_ВП_PL_tkm;

         else
             if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

                 return application.Plural.Invitation_ВП_tkm;
             else
                 if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                     return application.Plural.Invitation_ВП_PL_rus;
                 else
                     if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) || (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                         return application.Plural.Invitation_ВП_rus;

                     else return null;
   

   
 
 
 }

 public static string Get_PluralInvitationAndWorkPermit_ВП(IApplication application)

 {


     if (application.IsInvitationWithWorkPermit != null)
     {
         WPForInvitationRequired wizaOrWorkPermit = application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired;

         switch (wizaOrWorkPermit)
         {

             case WPForInvitationRequired.InvitationAndWorkPermit:


                 if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                     return application.Plural.InvitationAndWorkPermit_ВП_PL_tkm;

                 else
                     if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                         return application.Plural.InvitationAndWorkPermit_ВП_tkm;
                     else
                         if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                             return application.Plural.InvitationAndWorkPermit_ВП_PL_rus;
                         else
                             if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                                 return application.Plural.InvitationAndWorkPermit_ВП_rus;
                             else return null;

             case WPForInvitationRequired.OnlyInvitation:

                 if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                     return application.Plural.Invitation_ВП_tkm;

                 else
                     if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen))

                         return application.Plural.Invitation_ВП_tkm;
                     else
                         if (application.PersonInApplication.Count > 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                             return application.Plural.Invitation_ВП_PL_rus;
                         else
                             if (application.PersonInApplication.Count == 1 && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian))

                                 return application.Plural.Invitation_ВП_rus;

                             else return null;

             default:
                 return null;


         }
     }

     else return null;
 
 }
 
public static string Get_PluralBorderZone_ВП (IApplication application)


{


    if (Helper.CountBorderZones(application) && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) | (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

         return application.Plural.BorderZone_ВП_PL_tkm;

     else
        if (!Helper.CountBorderZones(application) && (application.ApplicationTypeForEmployee != null && application.AppConf.InTurkmen) | (application.ApplicationTypeForFamilyMember != null && application.AppConf.InTurkmen))

             return application.Plural.BorderZone_ВП_tkm;
         else
            if (Helper.CountBorderZones(application) && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) | (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                 return application.Plural.BorderZone_ВП_PL_rus;
             else
                if (!Helper.CountBorderZones(application) && (application.ApplicationTypeForEmployee != null && application.AppConf.InRussian) | (application.ApplicationTypeForFamilyMember != null && application.AppConf.InRussian))

                     return application.Plural.BorderZone_ВП_rus;

                 else return null;

}

 #endregion

 public static bool Set_Visible (IApplication application)

   {

       if (application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForInvitation)

       {

           return  true;
       
       }
       else
       return false;
   
   }

 public static string Get_RelationShipInLetterFM(IApplication application)

 {


     return null;// Helper.GetRelationFM(application);
 
 
 
 }

 public static string Get_RelationShipInLetterEmp(IApplication application)

 {

     return  Helper.GetRelationEmp(application);
 
 }

 public static string Get_NumberOfPerson(IApplication application)

 {

     return application.PersonInApplication.Count().ToString();
 
 }

 public static string Get_BorderZoneCollection(IApplication application)

 {

     string bzCollection =Helper.Get_BZ_collection(application.BorderZoneForVisa);
     if ( application.ChooseBorderZoneType== ChooseBorderZoneTypeEnum.BorderZoneForApplication)
     { 
      if (application.AppConf.InTurkmen && application.ForFamilyMember)
     {
         return ", şeýle hem " + Helper.Get_BZ_collection(application.BorderZoneForVisa) + " " + application.PluralBorderZone_ВП + " " + application.Plural.RugsatBermek_bir_tkm;

     }
    
     

      else  if (application.AppConf.InTurkmen && application.ForEmployee)
     {
         return ", şeýle hem " + Helper.Get_BZ_collection(application.BorderZoneForVisa) +" "+ application.PluralBorderZone_ВП +" "+ application.Plural.RugsatBermek_iki_tkm;

     }


      else return null;

     }
  else return null;

     //Tkm

    

    


 
 }

 public static string Get_BorderZoneCollectionForBZApp(IApplication application)
 {

     string bzCollection = Helper.Get_BZ_collection(application.BorderZoneForVisa);
     if (application.ChooseBorderZoneType == ChooseBorderZoneTypeEnum.BorderZoneForApplication)
     {
         if (application.AppConf.InTurkmen && application.ForFamilyMember)
         {
             return  Helper.Get_BZ_collection(application.BorderZoneForVisa) + "" + application.PluralBorderZone_ВП + " " + application.Plural.RugsatBermek_bir_tkm;

         }



         else if (application.AppConf.InTurkmen && application.ForEmployee)
         {
             return Helper.Get_BZ_collection(application.BorderZoneForVisa) + "" + application.PluralBorderZone_ВП + " " + application.Plural.RugsatBermek_iki_tkm;

         }


         else return null;

     }
     else return null;

     //Tkm







 }

 public static string Get_BorderZoneCollectionForLine(IApplication application)
 {

     string bzCollection = Helper.Get_BZ_collection(application.BorderZoneForVisa);
     if (application.ChooseBorderZoneType == ChooseBorderZoneTypeEnum.BorderZoneForApplication)
     {
         if (application.AppConf.InTurkmen)
         {
             return Helper.Get_BZ_collection(application.BorderZoneForVisa) ;

         }

         else return null;

     }
     else return null;

     //Tkm







 }

 public static bool Get_BorderZoneVisible(IApplication application)

 {

     if (application.ChooseBorderZoneType == ChooseBorderZoneTypeEnum.BorderZoneForApplication && application.BorderZoneVisibility ==true)
     {
         return true;
     }

     else return false;
 
 
 }

 public static string Get_NewRegistrationLocationInLetter(IApplication application)


 {

     if (application.NewRegistrationLocation != null)
     {
         var city = application.NewRegistrationLocation.CityType;

         var region = application.NewRegistrationLocation.Region.NameOfRegion;

         if (region == RegionEnum.AşgabatŞäheri)
         {
             return application.NewRegistrationLocation.Region.NameOfRegionL + "ne";
         }

         else
         {


             switch (city)
             {
                 case CityTypeEnum.Etrap:
                     return application.NewRegistrationLocation.Region.NameOfRegionL + "nyň " + application.NewRegistrationLocation.ŞäherEtrapL + "na";
                 case CityTypeEnum.Şäher:
                     return application.NewRegistrationLocation.Region.NameOfRegionL + "nyň " + application.NewRegistrationLocation.ŞäherEtrapL + "ne";
                 case CityTypeEnum.Şäherçe:
                     return application.NewRegistrationLocation.Region.NameOfRegionL + "nyň " + application.NewRegistrationLocation.ŞäherEtrapL + "ne";
                 default: return null;

             }

         }
     }
     else return null;
 
 }

 public static string Get_BusinessTripDestinationInLetter(IApplication application)
 {

     if (application.BusinessTripDestination != null)
     {
         var city = application.BusinessTripDestination.CityType;

         var region = application.BusinessTripDestination.Region.NameOfRegion;

         if (region == RegionEnum.AşgabatŞäheri)
         {
             return application.BusinessTripDestination.Region.NameOfRegionL + "ne";
         }

         else
         {


             switch (city)
             {
                 case CityTypeEnum.Etrap:
                     return application.BusinessTripDestination.Region.NameOfRegionL + "nyň " + application.BusinessTripDestination.ŞäherEtrapL + "na";
                 case CityTypeEnum.Şäher:
                     return application.BusinessTripDestination.Region.NameOfRegionL + "nyň " + application.BusinessTripDestination.ŞäherEtrapL + "ne";
                 case CityTypeEnum.Şäherçe:
                     return application.BusinessTripDestination.Region.NameOfRegionL + "nyň " + application.BusinessTripDestination.ŞäherEtrapL + "ne";
                 default: return null;

             }

         }
     }
     else return null;

 }


 public static string Get_PreviousRegistrationLocationInLetter(IApplication application)
 {

     if (application.PreviousRegistrationLocation != null)
     {
         var city = application.PreviousRegistrationLocation.CityType;
      
         var region = application.PreviousRegistrationLocation.Region.NameOfRegion;

         if (region == RegionEnum.AşgabatŞäheri)
         {
             return application.PreviousRegistrationLocation.Region.NameOfRegionL + "nden";
         }

         else
         {


             switch (city)
             {
                 case CityTypeEnum.Etrap:
                     return application.PreviousRegistrationLocation.Region.NameOfRegionL + "nyň " + application.PreviousRegistrationLocation.ŞäherEtrapL + "ndan";
                 case CityTypeEnum.Şäher:
                     return application.PreviousRegistrationLocation.Region.NameOfRegionL + "nyň " + application.PreviousRegistrationLocation.ŞäherEtrapL + "nden";
                 case CityTypeEnum.Şäherçe:
                     return application.PreviousRegistrationLocation.Region.NameOfRegionL + "nyň " + application.PreviousRegistrationLocation.ŞäherEtrapL + "nden";
                 default: return null;

             }

         }
     }
     else return null;

 }

    } //End Application Logic





     
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfMinistery")]
    public interface IAppliedMinistery 
    {
        [RuleRequiredField]
        string TitleOfMinistery { get; set; }
        [RuleRequiredField]
        string TitleOfMinisteryL { get; set; }
        [RuleRequiredField]
        string MinistersPosition { get; set; }
        [RuleRequiredField]
        string MinistersFullName { get; set; }
       
        string formOfAddress { get; set; }
        [DevExpress.Xpo.Aggregated]
        IList<  IContract> Contracts { get;}

        int LastContractNumberWithEmployee { get; set; }
    }

     
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("NumberOfContract")]
    public interface IContract {

        string NumberOfContract { get; set; }
        [FieldSize(FieldSizeAttribute.Unlimited)]
        string ContentOfContract { get; set; }
        IAppliedMinistery AppliedMinistery { get; set; }
    
    
    }


    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("NumberOfEmployee")]

    public interface IApplicationSigningPerson
    {
        [RuleRequiredField]
        ICompany Company { get; set; }
        [RuleRequiredField]
        [VisibleInListView(false),VisibleInDetailView(false),VisibleInLookupListView(false)]
        IPersonn Employee { get; set; }
        [RuleRequiredField]
       [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        IWorkHistory Position { get; set; }

    }

    [DomainLogic(typeof(IApplicationSigningPerson))]
    public class ApplicationSigningPersonLogic
    {

       public  static void AfterChange_Company(IApplicationSigningPerson asp)  


       {
            asp.Employee = asp.Company.DocSigningPerson;
         //   asp.Position = Helper.GetLastPosition(asp.Employee);
        }
    
    
    }





    [DomainComponent]
 
    public interface IVisibility

    {

        bool ControlIsVisible { get; set; }
    
    
    
    }

   [DomainComponent]

    public interface IMessage
    {

        [Browsable(false)]
        bool ApplicationLicenced { get; }

      //  [Appearance("LMessage", Visibility = ViewItemVisibility.Hide, Criteria = "ApplicationLicenced =true")]
        [VisibleInListView(false)]
        [Appearance("MessageFontColor", AppearanceItemType = "ViewItem", TargetItems = "Message", Context = "ListView, DetailView", BackColor = "White", FontColor = "Red")]
        string Message { get; }




    }



 
  
  




    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IApplication));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IApplication))]
    //public class IApplicationLogic {
    //    public static string Get_CalculatedProperty(IApplication instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IApplication instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IApplication instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IApplication instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
