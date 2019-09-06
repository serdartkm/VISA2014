 using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System.Drawing;
using System.ComponentModel;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using System.Linq;
using VISA2014.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;



namespace VISA2014.Module.DC
{


    public enum PersonStateEnum


    { 
    
    Registered,
    StrikedOff,
    Invited,
    Uncertain   
    
    
    
    }


    public enum RegistrationStateEnum

    { 
    
    REGISTERED,
    STRIKED_OFF,
    HC_OFFICE,
    HA_OFFICE,
    HC_ONPROCESS,
    HA_ONPROCESS,
    ONPROCESS,
    NONE,
    NOT_REGISTERED,
    HAS_NO_VISA,
    NEED_STRIKE_OFF,
    NEED_REGISTRATION,
    OUTSIDE_C,
    CLOSED,
    FINE,
    EXITVISA,
    CANCELLED,
    REG_NOT_REQUIRED,
    DO_NOT_REQUIRE
  
    }

    public enum VisaState { 
    
    VISA_CANCELLED,
    VISA_EXPIRED,
    VISA_VALID,
    VISA_NO,
    VISA_NONE,
    VISA_EXT_REJECTED,
    VISA_EXT_ONPROCESS,
    VISA_EXT_OFFICE,
    VISA_EXTENDED,
    VISA_EXT_FROM_MINISTERY,
    VISA_EXT_TO_MINISTERY,
    VISA_CAN_OFFICE,
   // VISA_NONE_1,
  //  VISA_NONE_0,
   // VISA_NONE_2,
   // VISA_NONE_3,
  //  VISA_NONE_4
    }

    public enum InvitationStateEnum
    {

Valid,
Expired,
Used,
Rejected,
Changed,
None,
INV_OFFICE,
INV_ONPROCESS,
INV_REJECTED,
INV_FROM_MIN,
INV_TO_MIN,
INV_VALID,
INV_EXPIRED,
INV_USED,
INV_NO,

   }



    

   [VisibleInReports]
   [DomainComponent,  ImageName("BO_Person")]
   [XafDefaultProperty("FullName")]




    


    #region  State Appearence

    #region VisaState


    [Appearance("LastVisaExpiring", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
      Criteria = "VisaState='Expiring'", BackColor = "Crimson", FontColor = "White")]

    [Appearance("LastVisaExpiringState", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
    Criteria = "VisaState='Expiring'", BackColor = "Crimson", FontColor = "White")]

    [Appearance("LastVisaExpired", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
     Criteria = "VisaState='VISA_EXPIRED'", BackColor = "Crimson", FontColor = "White")]

    //  [Appearance("LastVisaExpiredVisaState", AppearanceItemType = "ViewItem", TargetItems = "LastVisa.VisaState", Context = "ListView",
    //  Criteria = "LastVisa.VisaState='Expired'", BackColor = "Crimson", FontColor = "White")]


    [Appearance("VisaOffice", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
    Criteria = "VisaState= 'VISA_EXT_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("VisaToMinistery", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
     Criteria = "VisaState= 'VISA_EXT_TO_MINISTERY'", BackColor = "Turquoise", FontColor = "Black")]

    [Appearance("VisaFromMinistery", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
     Criteria = "VisaState= 'VISA_EXT_FROM_MINISTERY'", BackColor = "RoyalBlue", FontColor = "White")]

    [Appearance("VisaOnProcess", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
    Criteria = "VisaState= 'VISA_EXT_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("VisaRejected", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
        Criteria = "VisaState= 'VISA_EXT_REJECTED'", BackColor = "Red", FontColor = "White")]
    [Appearance("VisaIsValid", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
    Criteria = "VisaState= 'VISA_VALID'", BackColor = "LightGreen", FontColor = "Black")]

    [Appearance("VisaCanOffice", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
    Criteria = "VisaState= 'VISA_CAN_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("VISA_NO", AppearanceItemType = "ViewItem", TargetItems = "VisaState", Context = "ListView",
 Criteria = "VisaState= 'VISA_NO'", BackColor = "NavajoWhite", FontColor = "Black")]
    #endregion
 

    // Invitation State 
    #region Invitation State
    [Appearance("InvitatValid", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
    Criteria = "InvitatState= 'INV_VALID'", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("InvitationNo", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
     Criteria = "InvitatState= 'INV_NO'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("InvitationExpired", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
     Criteria = "InvitatState= 'INV_EXPIRED'", BackColor = "Salmon", FontColor = "Black")]

    [Appearance("InvitationUsed", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
     Criteria = "InvitatState= 'INV_USED'", BackColor = "YellowGreen", FontColor = "Black")]

    // Office

    [Appearance("InvitationOffice", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
    Criteria = "InvitatState= 'INV_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    
    //To ministery
    [Appearance("InvitationToMinistery", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
     Criteria = "InvitatState = 'INV_TO_MIN'", BackColor = "Turquoise", FontColor = "Black")]

   
    // From ministery
    [Appearance("InvitationFromMinistery", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
    Criteria = "InvitatState = 'INV_FROM_MIN'", BackColor = "RoyalBlue", FontColor = "White")]


    // On process
    [Appearance("InvitationOnProcess", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
     Criteria = "InvitatState = 'INV_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

   /*
    * 
    // Invitation issued work permit not
     [Appearance("InvitationIssuedWPNot", AppearanceItemType = "ViewItem", TargetItems = "LastInvitation.PersonState", Context = "ListView",
     Criteria = "LastInvitation.PersonState = 'InvitationIssuedWorkPermitNot'", BackColor = "Orange", FontColor = "Black")]
    */
    // Processed
    [Appearance("InvitationRejected", AppearanceItemType = "ViewItem", TargetItems = "InvitatState", Context = "ListView",
       Criteria = "InvitatState = 'INV_REJECTED'", BackColor = "Crimson", FontColor = "White")]
    // Rejected




    
    #endregion

    #region  Work Permit State Appearence


    [Appearance("CANCELLED_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='CANCELLED'", BackColor = "LightGray", FontColor = "Gray")]

    [Appearance("VALID_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
     Criteria = "WorkPermitState ='VALID'", BackColor = "LightGreen", FontColor = "Black")]

    [Appearance("EXPIRED_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
   Criteria = "WorkPermitState ='EXPIRED'", BackColor = "Brown", FontColor = "White")]


    [Appearance("VE_OFFICE_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='VE_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]
    [Appearance("VC_OFFICE_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
 Criteria = "WorkPermitState ='VC_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("TO_MINISTERY_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='TO_MINISTERY'", BackColor = "Turquoise", FontColor = "Black")]

    [Appearance("FROM_MINISTERY_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='FROM_MINISTERY'", BackColor = "RoyalBlue", FontColor = "Black")]

    [Appearance("VE_ONPROCESS_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]


    [Appearance("VC_ONPROCESS_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VC_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("VE_REJECTED_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_REJECTED'", BackColor = "Red", FontColor = "White")]

    [Appearance("AP_ONPROCESS_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("AP_COMPLETE_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_COMPLETE'", BackColor = "MediumSeaGreen", FontColor = "White")]

    [Appearance("AP_OFFICE_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]
            
    [Appearance("Extended_WP_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='Extended'", BackColor = "MediumSeaGreen", FontColor = "White")]
    #endregion
 
    // Passport State

    #region Passport State



    [Appearance("LastPassportPassportExpiring", AppearanceItemType = "ViewItem", TargetItems = "LastPassport.PassportState", Context = "ListView",
      Criteria = "LastPassport.PassportState ='Expiring'", BackColor = "Crimson", FontColor = "White")]

    [Appearance("LastPassportPassportExpired", AppearanceItemType = "ViewItem", TargetItems = "LastPassport.PassportState", Context = "ListView",
    Criteria = "LastPassport.PassportState ='Expired'", BackColor = "Crimson", FontColor = "White")]
    #endregion

    // Registration State

    #region Registration State

    // Registration

    [Appearance("RegistrationOffice", AppearanceItemType = "ViewItem", TargetItems = "RegistrationState, LastRegistration.Application", Context = "ListView",
    Criteria = "RegistrationState= 'HA_OFFICE' Or RegistrationState= 'HC_OFFICE' ", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("RegistrationOnProcess", AppearanceItemType = "ViewItem", TargetItems = "RegistrationState, LastRegistration.Application ", Context = "ListView",
    Criteria = "RegistrationState= 'HA_ONPROCESS' Or RegistrationState= 'HC_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    // Strike Off
     

    [Appearance("StrikeOffOffice", AppearanceItemType = "ViewItem", TargetItems = " LastStrikeOff.Application, RegistrationState", Context = "ListView",
   Criteria = "RegistrationState= 'HAS_NO_VISA' ", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("StrikeOffOnProcess", AppearanceItemType = "ViewItem", TargetItems = " LastStrikeOff.Application, RegistrationState ", Context = "ListView",
    Criteria = "RegistrationState= 'HC_ONPROCESS' Or RegistrationState= 'HA_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("Registered", AppearanceItemType = "ViewItem", TargetItems = "LastRegistration.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'REGISTERED'", BackColor = "LightGreen", FontColor = "Black")]

    [Appearance("StrikedOff", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'STRIKED_OFF'", BackColor = "PaleVioletRed", FontColor = "Black")]

    [Appearance("NotStrikedOff", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'STRIKED_OFF'", BackColor = "PaleVioletRed", FontColor = "Black")]
    [Appearance("NotRegistered", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
     Criteria = "RegistrationState= 'NOT_REGISTERED'", BackColor = "Red", FontColor = "Black")]

    [Appearance("NeedRegistration", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'NEED_REGISTRATION'", BackColor = "Yellow", FontColor = "Black")]
    [Appearance("NeedStrikeOff", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'NEED_STRIKE_OFF'", BackColor = "Yellow", FontColor = "Black")]

    [Appearance("OUTSIDE_C", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'OUTSIDE_C'", BackColor = "BLUE", FontColor = "White")]

    
    [Appearance("EXITVISA", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'EXITVISA'", BackColor = "Coral", FontColor = "White")]

    [Appearance("DO_NOT_REQUIRE", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'DO_NOT_REQUIRE'", BackColor = "Coral", FontColor = "White")]

    [Appearance("CANCELLED", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'CANCELLED'", BackColor = "BurlyWood", FontColor = "White")]

    [Appearance("CLOSED", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
    Criteria = "RegistrationState= 'CLOSED'", BackColor = "Brown", FontColor = "White")]

    [Appearance("REG_NOT_REQUIRED", AppearanceItemType = "ViewItem", TargetItems = "LastStrikeOff.Application , RegistrationState", Context = "ListView",
Criteria = "RegistrationState= 'REG_NOT_REQUIRED'", BackColor = "BlueViolet", FontColor = "White")]
    #endregion


    #region WorkPermitState
    [Appearance("CANCELLED_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='CANCELLED'", BackColor = "LightGray", FontColor = "Gray")]

    [Appearance("VALID_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
     Criteria = "WorkPermitState ='VALID'", BackColor = "LightGreen", FontColor = "Black")]

    [Appearance("EXPIRED_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
   Criteria = "WorkPermitState ='EXPIRED'", BackColor = "Brown", FontColor = "White")]


    [Appearance("VE_OFFICE_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='VE_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]
    [Appearance("VC_OFFICE_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
 Criteria = "WorkPermitState ='VC_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("TO_MINISTERY_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='TO_MINISTERY'", BackColor = "Turquoise", FontColor = "Black")]

    [Appearance("FROM_MINISTERY_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='FROM_MINISTERY'", BackColor = "RoyalBlue", FontColor = "Black")]

    [Appearance("VE_ONPROCESS_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]


    [Appearance("VC_ONPROCESS_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VC_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("VE_REJECTED_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_REJECTED'", BackColor = "Red", FontColor = "White")]

    [Appearance("AP_ONPROCESS_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("AP_COMPLETE_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_COMPLETE'", BackColor = "MediumSeaGreen", FontColor = "White")]

    [Appearance("AP_OFFICE_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]


    [Appearance("NO_WORKPERMIT_P", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='NO_WORKPERMIT'", BackColor = "NavajoWhite", FontColor = "Black")]


    #endregion
  
    #region Address State

    [Appearance("LastAddressExpiring", AppearanceItemType = "ViewItem", TargetItems = " LastAddressOfResidence.AddressState", Context = "ListView",
    Criteria = "LastAddressOfResidence.AddressState ='Expiring'", BackColor = "Crimson", FontColor = "White")]

    [Appearance("LastAddressExpired", AppearanceItemType = "ViewItem", TargetItems = " LastAddressOfResidence.AddressState", Context = "ListView",
    Criteria = "LastAddressOfResidence.AddressState ='Expired'", BackColor = "Crimson", FontColor = "White")]


    #endregion


    #region Gender Apprearence


    //[Appearance("GenderMale", AppearanceItemType = "ViewItem", TargetItems = "FirstName, LastName, MiddleName, FullName", Context = "ListView",
     // Criteria = "Gender.TypeOfGender ='Erkek'", BackColor = "DarkKhaki", FontColor = "Black")]
   
   // [Appearance("GenderFemale", AppearanceItemType = "ViewItem", TargetItems = "FirstName, LastName, MiddleName, FullName", Context = "ListView",
   //  Criteria = "Gender.TypeOfGender  ='Aýal'", BackColor = "Mistyrose", FontColor = "Black")]


    #endregion

 

   

    [RuleCombinationOfPropertiesIsUnique("FullName", DefaultContexts.Save, "FullName", MessageTemplateCombinationOfPropertiesMustBeUnique = "Bu raýat öň ýazylan.")]

    #endregion
   

    public interface IPersonn :IMessage
    {
    
         #region Person Data
        [VisibleInDetailView(false), VisibleInListView(false)]
        int CountPerson { get; set; }
        [RuleRequiredField]
        string FirstName { get; set; }
        [RuleRequiredField]
        string LastName { get; set; }
        string MiddleName { get; set; }
        string FullName { get; }
        [RuleRequiredField, ImmediatePostData]
        
        DateTime BirthDate { get; set; }
        [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
        string BirthdateForLetter { get; }
      
     
       // [Appearance("ForeignAddressCountryVisible", Visibility = ViewItemVisibility.Hide, Criteria = "LocalEmployee = true")]
        ICountries ForeignAddressCountry { get; set; }
        [RuleRequiredField]
        string BirthPlace { get; set; }
     
      //  [Appearance("ForeignAddressVisible", Visibility = ViewItemVisibility.Hide, Criteria = "LocalEmployee = true")]
        string ForeignAddress { get; set; }

        [RuleRequiredField, ImmediatePostData]


        IGender Gender { get; set; }


        #region Appearence
        [Appearance("MaritalStatus", Visibility = ViewItemVisibility.Hide, Criteria = "Gender Is Null")]
        #endregion

        [RuleRequiredField]
        [DataSourceProperty("Gender.MaritalStatuses")]
        IMaritalStatus MaritalStatus { get; set; }

        [Delayed(true)]
        [Size(-1)]
        [ValueConverter(typeof(ImageValueConverter))]
        Image Photo { get; set; }

        [RuleRequiredField]
        ICountries BirthCountry { get; set; }
       
        #endregion

         #region Employee Data
         [Appearance("IsEmployee", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
         [ImmediatePostData]
         [VisibleInDetailView(false), VisibleInListView(false)]
         bool IsEmployee { get; set; }

          [Appearance("IsEmployeeContract", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
        //  [Appearance("IsEmployeeContract1", Visibility = ViewItemVisibility.Hide, Criteria = "LocalEmployee = true")]
        [ImmediatePostData]
          IContract Contract { get; set; }
          //[Appearance("IsEmployeeWage", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
        //  string Wage { get; set; }

        [Appearance("ContractNumber", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
          string ContractNumber { get; set; }
      //  [Appearance("IDNumber", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
          string IDNumber { get; set; }
        #endregion

         #region Family Member Data
         [Appearance("IsFamilyMember", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee")]
         [ImmediatePostData]
         [VisibleInDetailView(false), VisibleInListView(false)]
         bool IsFamilyMember { get; set; }

        [Appearance("Employee", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee Or (!IsFamilyMember And !IsEmployee)")]
         [DataSourceCriteria("IsEmployee")]
         IPersonn Employee { get; set; }

         [Appearance("Relation", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee")]
         [ImmediatePostData]
         [DataSourceProperty("Gender.Relations")]
         [Appearance("FamilyMemberRelation", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee Or (!IsFamilyMember And !IsEmployee)")]
         IRelation FamilyMemberRelation { get; set; }
    
         RelationEnum EmployeeRelation { get; }
       // [Appearance("Salary", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
      //   Salary Salary { get; set; }

         [DevExpress.Xpo.Aggregated]
         IList<FamilyProofDocument> FamilyProofDocCopy { get; } 
         
       

#endregion

         #region Last Data

        
         IPassport LastPassport { get; }

         IAddressOfResidence LastAddressOfResidence { get; }


    
         IVisa LastVisa { get; }

    
         IPersonInApplication LastRegistration { get; }

         IPersonInApplication LastRegistrationUpOnArrival { get; }
    
         IPersonInApplication LastStrikeOff { get; }

          IPersonInApplication LastAppForVisaExtention { get; }

         [Appearance("LastWorkPermit", Visibility = ViewItemVisibility.Hide, Criteria = "!IsEmployee")]
     
         IWorkPermit LastWorkPermit { get; }

         [Appearance("LastPosition", Visibility = ViewItemVisibility.Hide, Criteria = "!IsEmployee")]
         IWorkHistory LastPosition { get; }

         IPersonInResult LastInvitation { get; }

         bool ActivePerson { get; set; }
      
         ITravelInformation LastTravelInfo { get; }

       
         IEducation LastEducation { get; }

       #endregion
      
         #region List Data
      
       [DevExpress.Xpo.Aggregated]
       [Appearance("IWorkHistory", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
       IList<IWorkHistory> WorkHistories { get; }
       [DevExpress.Xpo.Aggregated]
 
       IList<IEducation> Educations { get; }
       [Appearance("WorkPermitsVisible", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
      
       IList<IWorkPermit> WorkPermits { get; }

        [Appearance("NoRegistrationRequired", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee")]
       bool NoRegistrationRequired { get; set; }

       [DevExpress.Xpo.Aggregated]
       [Appearance("FamilyMembers", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember Or (!IsFamilyMember And !IsEmployee)")]
       IList<IPersonn> FamilyMembers { get; }
       [Appearance("FamilyMemberInApplications", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee Or (!IsFamilyMember And !IsEmployee)")]
       [BackReferenceProperty("FamilyMember"), DevExpress.Xpo.Aggregated]
       IList<IPersonInApplication> FamilyMemberInApplications { get; }
       [Appearance("EmployeeInApplications", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember Or (!IsFamilyMember And !IsEmployee) ")]
       [BackReferenceProperty("Employee"), DevExpress.Xpo.Aggregated]
       IList<IPersonInApplication> EmployeeInApplications { get; }
       [DevExpress.Xpo.Aggregated]
       //[Browsable(false)]
       [BackReferenceProperty("FamilyMember")]
       [Appearance("FamilyMember'InResult", Visibility = ViewItemVisibility.Hide, Criteria = "IsEmployee")]
       IList<IPersonInResult> FamilyMemberInResult { get; }
       [DevExpress.Xpo.Aggregated]
       [BackReferenceProperty("Employee")]
      // [Browsable(false)]
       [Appearance("EmployeeInResult", Visibility = ViewItemVisibility.Hide, Criteria = "IsFamilyMember")]
       IList<IPersonInResult> EmployeeInResult { get; }


       [ImmediatePostData]
       [DevExpress.Xpo.Aggregated]
      
       IList<ITravelInformation> TravelInformations { get; }

       
       [DevExpress.Xpo.Aggregated]
       IList<IAddressOfResidence> AddressOfResidences { get; }
       [DevExpress.Xpo.Aggregated]
       [ImmediatePostData]
       [RuleRequiredField]
       IList<IPassport> Passports { get; }

       #endregion
        
   
       // PersonStateEnum PersonState { get; }
  
           RegistrationStateEnum RegistrationState { get; }
     
          InvitationStateEnum InvitatState { get; }

       [Browsable(false)]
       AppConf AppConf { get; set; }

        #region Local Employee

   


        #endregion



       bool IsOutSideOfCountry { get;set; }


        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
        IList<ICopy> SpidKepilnama { get; }
      
 
        Proje Proje { get; set; }

       

        FileData AnketaCV { get; set; }

        VisaState VisaState { get; }
        IPersonInApplication LastApplicationForCancellingVisa { get; }

        IPersonInApplication LastAppForChangingVisaCategory { get; }
        WorkPermitStateEnum WorkPermitState { get; }

        IPersonInApplication LastApplicationForInvit { get; }

    }
   [DomainLogic(typeof(IPersonn))]
   public class PersonLogic
   {

       public static WorkPermitStateEnum Get_WorkPermitState(IPersonn person)
       {

           if (person.IsEmployee && person.LastWorkPermit != null)
           {

               return person.LastWorkPermit.WorkPermitState;
           }
           else {

               return WorkPermitStateEnum.NO_WORKPERMIT;
           }

           /*
           #region temp
           if (person.IsEmployee && person.WorkPermits.Count==0)
           {

               return WorkPermitStateEnum.NO_WORKPERMIT;
           }
           if (person.IsEmployee && person.WorkPermits.Count == 1)
           {

               return person.WorkPermits.First().WorkPermitState;
           }
           if (person.IsEmployee && person.WorkPermits.Count > 1)
           {
               return person.WorkPermits.OrderByDescending(t => t.ExpiringDateOfWorkPermit).First().WorkPermitState;
           }


           else return WorkPermitStateEnum.UNKNOWN;





           #endregion



           */
       }

       public static IPersonInApplication Get_LastAppForChangingVisaCategory(IPersonn person) {

           if (person.IsEmployee)
           {
               try
               {
                   return  person.EmployeeInApplications.Where(t=> !t.Cancelled).Where(s=> s.Application.SubType== SubType.ApplicationForChangingVisaCategory).OrderByDescending(d=>d.Application.ManualApplicationDate).First();

               }
               catch (Exception)
               {

                   return null;
               }

           }
           else if (person.IsFamilyMember)
           {
               try
               {
                   person.FamilyMemberInApplications.Where(t => !t.Cancelled).Where(s => s.Application.SubType == SubType.ApplicationForChangingVisaCategory).OrderByDescending(d => d.Application.ManualApplicationDate).First();

               }
               catch (Exception)
               {
                   return null;

               }

               return null;
           }
           else return null;

       }

       public static IPersonInApplication Get_LastApplicationForCancellingVisa(IPersonn person) {


           if (person.IsEmployee)
           {
               try
               {
                   return person.EmployeeInApplications.Where(t=> !t.Cancelled).Where(e=>e.AppliedPerson.IsEmployee).Where(n=> n.ApplicationType == SubType.ApplicationForCancellingVisa | n.ApplicationType == SubType.ApplicationForCancellingVisaAndWorkpermit).OrderByDescending(t => t.Application.ManualApplicationDate).First();

               }
               catch (Exception)
               {

                   return null;
               }
           
           }
           else if (person.IsFamilyMember)
           {
               try
               {
                   return person.EmployeeInApplications.Where(t => !t.Cancelled).Where(e => e.AppliedPerson.IsFamilyMember).Where(n => n.ApplicationType == SubType.ApplicationForCancellingVisa).OrderByDescending(t => t.Application.ManualApplicationDate).First();

               }
               catch (Exception)
               {  return null;

               }

             
           }
           else return null;
       
       }

       public static VisaState Get_VisaState(IPersonn person) {

           

           try

           {
               if (person.LastVisa == null) {

                   return VisaState.VISA_NO;
                  }
               
                return person.LastVisa.VisaState;
                   /*
               if (person.LastApplicationForCancellingVisa != null && person.LastVisa.VisaNumber == person.LastApplicationForCancellingVisa.Visa.VisaNumber && person.LastApplicationForCancellingVisa.Application.ApplicationState == ApplicationStateEnum.Processed)
               {

                   return VisaState.VISA_CANCELLED;
               }
               
               else if (person.LastVisa.RemainingDays <= 0) {

                   return VisaState.VISA_EXPIRED;
               
               }
               else if (person.LastVisa.RemainingDays >0)
               {

                   return VisaState.VISA_VALID;

               }
               else
               {
                   return VisaState.VISA_NONE;
               }*/
           }
           catch (Exception)
           {

               return VisaState.VISA_NONE;
           }
       
       }
       

       public static IEducation Get_LastEducation(IPersonn person)


       {

           if (person != null && person.Educations.Count > 0)
           {
               return person.Educations.First();
           }
           else return null;
       
       }


       public static IPersonInApplication Get_LastAppForVisaExtention(IPersonn person)

       {

           List<IPersonInApplication> appForVisaExten = new List<IPersonInApplication>(); ;
           if (person != null && person.IsEmployee && person.EmployeeInApplications!=null && person.EmployeeInApplications.Count > 0)
           {

               foreach (var item in person.EmployeeInApplications)
               {
                   if (item.ApplicationType == SubType.ApplicationForVisaExtention)
                   {

                       appForVisaExten.Add(item);

                   }
               }

               if (appForVisaExten.Count == 1)
               {

                   return appForVisaExten.First();

               }
               else if (appForVisaExten.Count > 1)
               {
                   return appForVisaExten.OrderByDescending(t => t.RegistrationDate).First(); ;

               }
               else return null;
           }
           else return null;
       
       }


       public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IPersonn person, IObjectSpace os)
       {



           return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, person);

       }

       public static IPersonInApplication Get_LastApplicationForInvit(IPersonn person) {


           if (person.IsEmployee)
           {
               try
               {

                   IList<IPersonInApplication> lastAppsForInvitationEmp = person.EmployeeInApplications
             .Where(t => t.PersonState != ApplicationStateEnum.Cancelled && t.Application.ApplicationState != ApplicationStateEnum.Cancelled)
     
             
             .Where(s => s.Application.SubType == SubType.ApplicationForInvitation).ToList();

                   return lastAppsForInvitationEmp.OrderByDescending(m=> m.RegistrationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }



           }
           else if (person.IsFamilyMember) {
               try
               {

                   IList<IPersonInApplication> lastAppsForInvitationEmp = person.FamilyMemberInApplications
             .Where(t => t.PersonState != ApplicationStateEnum.Cancelled && t.Application.ApplicationState != ApplicationStateEnum.Cancelled)
             

             .Where(s => s.Application.SubType == SubType.ApplicationForInvitation).ToList();

                   return lastAppsForInvitationEmp.OrderByDescending(m => m.RegistrationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }
           
           }

           return null;

       }

       public static InvitationStateEnum Get_InvitatState(IPersonn person)
       {

         

           if (person.IsEmployee)
           {

               IList<IPersonInApplication> lastAppsForInvitationEmp = person.EmployeeInApplications
               .Where(t => t.PersonState != ApplicationStateEnum.Cancelled && t.Application.ApplicationState != ApplicationStateEnum.Cancelled)
               .Where(p => p.PersonState != ApplicationStateEnum.Processed && p.Application.ApplicationState != ApplicationStateEnum.Processed)
               .Where(s => s.Application.SubType == SubType.ApplicationForInvitation).ToList();
               if (lastAppsForInvitationEmp.Count == 1)
               {
                   IPersonInApplication personInApp = lastAppsForInvitationEmp.First();
                   if (personInApp.PersonState == ApplicationStateEnum.Office)
                   {

                       return InvitationStateEnum.INV_OFFICE;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.OnProcess)
                   {

                       return InvitationStateEnum.INV_ONPROCESS;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.ToMinistery)
                   {

                       return InvitationStateEnum.INV_TO_MIN;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.FromMinistery)
                   {

                       return InvitationStateEnum.INV_FROM_MIN;
                   }
               }
               if (person.LastInvitation != null && person.LastInvitation.Invitation.Result == ApplicationResultEnum.Rejection) {

                   return InvitationStateEnum.INV_REJECTED;
               }

               if (person.LastInvitation != null && person.LastInvitation.Invitation.Result == ApplicationResultEnum.Invitation)
               {
                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_VALID) {

                       return InvitationStateEnum.INV_VALID;
                   }
                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_EXPIRED)
                   {

                       return InvitationStateEnum.INV_EXPIRED;
                   }

                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_USED)
                   {

                       return InvitationStateEnum.INV_USED;
                   }
               }

               if (person.LastInvitation == null)
               {
                   return InvitationStateEnum.INV_NO;

               }
           }
           if (person.IsFamilyMember) {

               IList<IPersonInApplication> lastAppsForInvitationFM = person.FamilyMemberInApplications
                        .Where(t => t.PersonState != ApplicationStateEnum.Cancelled && t.Application.ApplicationState != ApplicationStateEnum.Cancelled)
                        .Where(p => p.PersonState != ApplicationStateEnum.Processed && p.Application.ApplicationState != ApplicationStateEnum.Processed)
                        .Where(s => s.Application.SubType == SubType.ApplicationForInvitation).ToList();
               if (lastAppsForInvitationFM.Count == 1)
               {
                   IPersonInApplication personInApp = lastAppsForInvitationFM.First();
                   if (personInApp.PersonState == ApplicationStateEnum.Office)
                   {

                       return InvitationStateEnum.INV_OFFICE;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.OnProcess)
                   {

                       return InvitationStateEnum.INV_ONPROCESS;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.ToMinistery)
                   {

                       return InvitationStateEnum.INV_TO_MIN;
                   }
                   if (personInApp.PersonState == ApplicationStateEnum.FromMinistery)
                   {

                       return InvitationStateEnum.INV_FROM_MIN;
                   }
               }
               if (person.LastInvitation != null && person.LastInvitation.Invitation.Result == ApplicationResultEnum.Rejection)
               {

                   return InvitationStateEnum.INV_REJECTED;
               }

               if (person.LastInvitation != null && person.LastInvitation.Invitation.Result == ApplicationResultEnum.Invitation)
               {
                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_VALID)
                   {

                       return InvitationStateEnum.INV_VALID;
                   }
                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_EXPIRED)
                   {

                       return InvitationStateEnum.INV_EXPIRED;
                   }

                   if (person.LastInvitation.InvitationState == InvitStateEnum.INV_USED)
                   {

                       return InvitationStateEnum.INV_USED;
                   }
               }

               if (person.LastInvitation == null)
               {
                   return InvitationStateEnum.INV_NO;

               }

           
           }

           return InvitationStateEnum.None;

           /*
           if (person.LastInvitation != null && person.LastInvitation.PersonInResult != null)
           {


               if (person.LastInvitation.NewVisa != null)
               {

                   return InvitationStateEnum.Used;

               }
               else if (person.LastInvitation.NewVisa == null && person.LastInvitation.Invitation.InvitationRemaningDays == 0)
               {
                   return InvitationStateEnum.Expired;


               }
               else if (person.LastInvitation.NewVisa == null && person.LastInvitation.Invitation.InvitationRemaningDays > 0)
               {

                   return InvitationStateEnum.Valid;

               }

               else if (person.LastInvitation.NewVisa == null && person.LastInvitation.ApplicationForChangingInvitation != null)
               {

                   return InvitationStateEnum.Changed;

               }
               else return InvitationStateEnum.None;

           }
           else return InvitationStateEnum.None;

           */
       }


       public static RegistrationStateEnum Get_RegistrationState(IPersonn person,IObjectSpace os)
       {


           try

           {
               if (person.NoRegistrationRequired) { 
               
                   return RegistrationStateEnum.REG_NOT_REQUIRED;
               }

         
               //YATYRLAN
               //first time entry

               if (person.LastVisa != null && person.LastRegistration == null && person.VisaState == VisaState.VISA_CANCELLED)
               {

                   return RegistrationStateEnum.CANCELLED;

               }
               //YATYRLAN
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber!= person.LastVisa.VisaNumber && person.VisaState == VisaState.VISA_CANCELLED)
               {

                   return RegistrationStateEnum.CANCELLED;

               }

               //HASAPDAN CYKARMALY
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber  && person.LastStrikeOff==null &&  person.VisaState == VisaState.VISA_CANCELLED)
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;

               }

               //HASAPDAN CYKARMALY
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber && person.VisaState == VisaState.VISA_CANCELLED)
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;

               }
              //HASAPDAN CYKARMALY
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber && person.LastVisa.RemainingDays<=0)
                   
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;

               }
               //HASAPDAN CYKARMALY
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber &&  person.LastRegistration.Application.ManualApplicationDate >= person.LastStrikeOff.Application.ManualApplicationDate && person.LastVisa.RemainingDays <= 0)
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;

               }
               //HASAPDAN CYKARMALY
               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastStrikeOff == null &&  person.LastVisa.RemainingDays <= 0)
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;

               }

             
               //CK CYKYS VISA
               if (person.LastVisa != null && (person.LastVisa.VisaType.TypeOfVisa == "ÇK" | person.LastVisa.VisaType.TypeOfVisa == "EX") && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber && person.LastVisa.RemainingDays > 0)
               {
                   return RegistrationStateEnum.EXITVISA;
               }

               //CYKYS VISA
               if (person.LastVisa != null && (person.LastVisa.VisaType.TypeOfVisa == "ÇK" | person.LastVisa.VisaType.TypeOfVisa == "EX") && person.LastStrikeOff == null && person.LastVisa.RemainingDays > 0)
               {
                   return RegistrationStateEnum.EXITVISA;
               }
          
               //CK VISA HASAPDAN CYKARMALY
               if (person.LastVisa != null && (person.LastVisa.VisaType.TypeOfVisa == "ÇK" | person.LastVisa.VisaType.TypeOfVisa == "EX") && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber && person.LastVisa.RemainingDays <= 0)
               {
                   return RegistrationStateEnum.NEED_STRIKE_OFF;
               }
               
               //CK VISA HASAPDAN CYKARMALY
               if (person.LastVisa != null && (person.LastVisa.VisaType.TypeOfVisa == "ÇK" | person.LastVisa.VisaType.TypeOfVisa == "EX") && person.LastStrikeOff == null && person.LastVisa.RemainingDays <= 0)
               {
                   return RegistrationStateEnum.NEED_STRIKE_OFF;
               }
               
               //HASAPDAN CYKARLAN
               if (person.LastVisa != null && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber && person.LastStrikeOff.Application.ApplicationState == ApplicationStateEnum.Processed  && person.LastRegistration== null)
               {

                   return RegistrationStateEnum .STRIKED_OFF;

               }
                //HASAPDAN CYKARLAN
               if (person.LastVisa != null && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber && person.LastStrikeOff.Application.ApplicationState == ApplicationStateEnum.Processed  && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber!= person.LastVisa.VisaNumber)
               {

                   return RegistrationStateEnum .STRIKED_OFF;

               }

                  //HASAPDAN CYKARLAN
               if (person.LastVisa != null && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber && person.LastStrikeOff.Application.ApplicationState == ApplicationStateEnum.Processed  && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber== person.LastVisa.VisaNumber && person.LastRegistration.Application.ManualApplicationDate< person.LastStrikeOff.Application.ManualApplicationDate)
               {

                   return RegistrationStateEnum .STRIKED_OFF;

               }
               //HASAPDAN CYKARYLYAR OFISDE 
               if (person.LastVisa != null && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber && person.LastStrikeOff.Application.ApplicationState == ApplicationStateEnum.Office)
               {

                   return RegistrationStateEnum.HC_OFFICE;

               }

               //HASAPDAN CYKARYLYAR ONPROCESS 
               if (person.LastVisa != null && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber && person.LastStrikeOff.Application.ApplicationState == ApplicationStateEnum.OnProcess)
               {

                   return RegistrationStateEnum.HC_ONPROCESS;

               }

               //Y_CLOSED
               if (person.LastVisa != null && person.LastRegistration == null && person.IsOutSideOfCountry && person.LastVisa.RemainingDays <= 0)
               {
                   return RegistrationStateEnum.CLOSED;
               }
               //Y_CLOSED
               if (person.LastVisa != null && person.LastRegistration != null && person.LastVisa.VisaNumber != person.LastRegistration.Visa.VisaNumber && person.IsOutSideOfCountry && person.LastVisa.RemainingDays <= 0)
               {
                   return RegistrationStateEnum.CLOSED;
               }
                   //HASAPDAN CYKARYMALY STRIKEOFF IS NULL
               if (person.LastVisa != null && person.LastVisa.RemainingDays <= 0 && person.LastStrikeOff == null) {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;
               }
               //HASAPDAN CYKARYMALY STRIKEOFF IS NOT  NULL
               if (person.LastVisa != null && person.LastVisa.RemainingDays <= 0 && person.LastStrikeOff != null && person.LastVisa.VisaNumber !=person.LastStrikeOff.Visa.VisaNumber)
               {

                   return RegistrationStateEnum.NEED_STRIKE_OFF;
               }

             

               //Y_DASYNDA
               if (person.LastVisa != null && person.LastRegistration==null &&  person.IsOutSideOfCountry && person.LastVisa.RemainingDays>0)
               {
                   return RegistrationStateEnum.OUTSIDE_C;
               }
               //Y_DASYNDA
               if (person.LastVisa != null && person.LastRegistration != null && person.LastVisa.VisaNumber != person.LastRegistration.Visa.VisaNumber && person.IsOutSideOfCountry && person.LastVisa.RemainingDays > 0)
               {
                   return RegistrationStateEnum.OUTSIDE_C;
               }
                   //HASABA ALYNMALY Registration is null

               if (person.LastVisa != null && person.LastVisa.HasabaAlynmayar && person.LastVisa.RemainingDays > 0) {

                   return RegistrationStateEnum.DO_NOT_REQUIRE;
               }
               if (person.LastVisa != null && person.LastRegistration == null) {
                   return RegistrationStateEnum.NEED_REGISTRATION;
               }
               //HASABA ALYNMALY Registration is not null

               if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber!= person.LastVisa.VisaNumber)
               {
                   return RegistrationStateEnum.NEED_REGISTRATION;
               }

               //HASABA ALYNAN

               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Processed && person.LastStrikeOff == null)
               {

                   return RegistrationStateEnum.REGISTERED;

               }

                       //HASABA ALYNAN

               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Processed && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber)
               {

                   return RegistrationStateEnum.REGISTERED;

               }


                           //HASABA ALYNAN

               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Processed && person.LastStrikeOff != null && person.LastVisa.VisaNumber == person.LastStrikeOff.Visa.VisaNumber  && person.LastStrikeOff.Application.ManualApplicationDate<= person.LastRegistration.Application.ManualApplicationDate)
               {

                   return RegistrationStateEnum.REGISTERED;

               }
               //HASABA ALYNYAR HA_ONPROCESS  LastStrikeOff is Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.OnProcess && person.LastStrikeOff == null)
               {

                   return RegistrationStateEnum.HA_ONPROCESS;

               }
               //HASABA ALYNYAR HA_ONPROCESS  LastStrikeOff is Not Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.OnProcess && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber)
               {

                   return RegistrationStateEnum.HA_ONPROCESS;

               }
               //HASABA ALYNYAR OFISDE LastStrikeOff is  Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Office && person.LastStrikeOff == null)
               {
                  
                   return RegistrationStateEnum.HA_OFFICE;

               }

                   //HASABA ALYNYAR OFISDE LastStrikeOff is Not Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Office && person.LastStrikeOff != null && person.LastStrikeOff.Visa.VisaNumber != person.LastVisa.VisaNumber)
               {

                   return RegistrationStateEnum.HA_OFFICE;

               }
               //HASABA ALYNAN REGISTERED LastStrikeOff is Not Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Processed && person.LastStrikeOff != null && person.LastVisa.VisaNumber != person.LastStrikeOff.Visa.VisaNumber)
               {

                   return RegistrationStateEnum.REGISTERED;

               }

                    //HASABA ALYNAN REGISTERED LastStrikeOff is  Null
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber == person.LastVisa.VisaNumber && person.LastRegistration.Application.ApplicationState == ApplicationStateEnum.Processed && person.LastStrikeOff == null)
               {

                   return RegistrationStateEnum.REGISTERED;

               }
               //HASABA ALYNMADYK LastRegistration IS NULL

               else if (person.LastVisa != null && person.LastRegistration == null)
               {
                   return RegistrationStateEnum.NOT_REGISTERED;
               }
               //HASABA ALYNMADYK LastRegistration IS NOT NULL
               else if (person.LastVisa != null && person.LastRegistration != null && person.LastRegistration.Visa.VisaNumber != person.LastVisa.VisaNumber)
               {
                   return RegistrationStateEnum.NOT_REGISTERED;

               }
               else if (person.LastVisa == null)
               {
                   return RegistrationStateEnum.HAS_NO_VISA;
               }

               else return RegistrationStateEnum.NONE;
           }
           catch (Exception)
           {

               return RegistrationStateEnum.NONE;
           }



       }
     
    
      
       public static PersonStateEnum Get_PersonState(IPersonn person)

       {

           if (person.LastInvitation != null)
           {

               return PersonStateEnum.Invited;

           }
           else if (person.LastRegistration != null && person.LastStrikeOff == null)
           {

               return PersonStateEnum.Registered;

           }

           else if (person.LastRegistration != null && person.LastStrikeOff != null | person.LastRegistration == null && person.LastStrikeOff != null)
           {

               return PersonStateEnum.StrikedOff;

           }

           else if (person.LastRegistration == null && person.LastStrikeOff == null && person.LastInvitation == null)
           {

               return PersonStateEnum.Uncertain;

           }

           else return PersonStateEnum.Uncertain;


           return PersonStateEnum.Uncertain;


       }

       
   
       public static string Get_BirthdateForLetter(IPersonn person)


       {

           if (person.BirthDate != null)
           {
               return person.BirthDate.ToString("dd.MM.yyyy.ý");


           }


           else return null;
       
       
       
       }




       public static string Get_FullName(IPersonn person)
       { return string.Format("{0} {1}", person.FirstName, person.LastName); }


       public static void AfterConstruction(IPersonn person, IObjectSpace obspace)

       {

           person.CountPerson = obspace.GetObjectsCount(typeof(IPersonn), null);

           var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
           if (appConf != null)
           {

               person.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

           }
        

         
         
       }

    
       #region Get Last Data


       public static IWorkPermit Get_LastWorkPermit(IPersonn person)
       {
           #region temp
           if (person.IsEmployee && person.WorkPermits!=null && person.WorkPermits.Count !=0)
           {
             

                   return person.WorkPermits.OrderByDescending(t => t.ExpiringDateOfWorkPermit).First();
               
             

              
                   
               }
               
                  else return null;

           #endregion

          
       
       
       }
      
       public static IPassport Get_LastPassport(IPersonn person)
       {
          

           if (person.Passports.Count > 0)
           {

               return person.Passports.OrderByDescending(t => t.PassportExpiringDate).First();
           }
           else return null;
       }

       public static IAddressOfResidence Get_LastAddressOfResidence ( IPersonn person)

   {
       if (person.AddressOfResidences.Count == 1)
       {
           return person.AddressOfResidences.First();
       }


       else if (person.AddressOfResidences.Count > 1 )
       {

           return person.AddressOfResidences.OrderByDescending(t => t.StartDateOfResidence).First();
       }
       else return null;
   
   
   }

       public static IVisa Get_LastVisa(IPersonn person)

       {
          

           try
           {
               return person.Passports.Where(t => t.LastVisa != null).OrderByDescending(t => t.PassportIssuedDate).First().LastVisa;
               
           }
           catch (Exception)
           {
               
              return null;
           }
          
       }

       public static IPersonInApplication Get_LastRegistrationUpOnArrival(IPersonn person)
       {

           if (person.IsEmployee)
           {
               try
               {
                   return (from num in person.EmployeeInApplications where ((num.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival) && num.AppliedPerson.IsEmployee) select num).OrderByDescending(t => t.Application.ManualApplicationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }
               //IApplication lastApplication = (from num in apps where num.ApplicationDate.Year == DateTime.Now.Year select num).Max();


               // return Helper.GetLastRegistrationEmp(person);
           }
           else if (person.IsFamilyMember)
           {
               try
               {
                   return (from num in person.FamilyMemberInApplications where (num.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival) && num.AppliedPerson.IsFamilyMember select num).OrderByDescending(t => t.Application.ManualApplicationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }

               // return Helper.GetLastRegistrationFM(person);
           }
           else return null;
       
       }
       public static IPersonInApplication Get_LastRegistration(IPersonn person)
       {

           if (person.IsEmployee )
           {
               try
               {
                   return person.EmployeeInApplications.Where(t => !t.Cancelled).Where(a => !a.Application.Cancelled).Where(b => b.AppliedPerson.IsEmployee).Where(c => c.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival
                               | c.ApplicationType == SubType.ApplicationForRegisteringToANewLocation
                               | c.ApplicationType == SubType.ApplicationForRegistrationExtention
                               | c.ApplicationType == SubType.ApplicationForChangingPassport | c.ApplicationType == SubType.ApplicationForChagingInformation).OrderByDescending(t => t.Application.ManualApplicationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }
               //IApplication lastApplication = (from num in apps where num.ApplicationDate.Year == DateTime.Now.Year select num).Max();
             

              // return Helper.GetLastRegistrationEmp(person);
           }
           else if (person.IsFamilyMember)
           {
               try
               {

                   return person.FamilyMemberInApplications.Where(t => !t.Cancelled).Where(a => !a.Application.Cancelled).Where(b => b.AppliedPerson.IsFamilyMember).Where(c => c.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival
                            | c.ApplicationType == SubType.ApplicationForRegisteringToANewLocation
                            | c.ApplicationType == SubType.ApplicationForRegistrationExtention
                            | c.ApplicationType == SubType.ApplicationForChangingPassport 
                            |c.ApplicationType == SubType.ApplicationForChagingInformation 
                            ).OrderByDescending(t => t.Application.ManualApplicationDate).First();
                   /*
                   return (from num in person.FamilyMemberInApplications where (num.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival
                               | num.ApplicationType == SubType.ApplicationForRegisteringToANewLocation
                               | num.ApplicationType == SubType.ApplicationForRegistrationExtention 
                               | num.ApplicationType == SubType.ApplicationForChangingPassport) && num.AppliedPerson.IsFamilyMember
                           select num).OrderByDescending(t => t.Application.ManualApplicationDate).First();   */
               }
               catch (Exception)
               {

                   return null;
               }
              
              // return Helper.GetLastRegistrationFM(person);
           }
           else return null;
         
                 
                 
                 

       }

       public static IPersonInApplication Get_LastStrikeOff(IPersonn person)
       {

           if (person.IsEmployee)
           {
               try
               {
                   return (from num in person.EmployeeInApplications where (num.ApplicationType == SubType.ApplicationForStrikeOffRegister && num.AppliedPerson.IsEmployee) select num).OrderByDescending(t => t.Application.ManualApplicationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }
               //IApplication lastApplication = (from num in apps where num.ApplicationDate.Year == DateTime.Now.Year select num).Max();


               // return Helper.GetLastRegistrationEmp(person);
           }
           else if (person.IsFamilyMember)
           {
               try
               {
                   return (from num in person.FamilyMemberInApplications where (num.ApplicationType == SubType.ApplicationForStrikeOffRegister && num.AppliedPerson.IsFamilyMember) select num).OrderByDescending(t => t.Application.ManualApplicationDate).First();
               }
               catch (Exception)
               {

                   return null;
               }

               // return Helper.GetLastRegistrationFM(person);
           }
           else return null;
         
                 
                 

        




       }

       public static IPersonInResult Get_LastInvitation(IPersonn person)
       {

           if (person.IsEmployee)
           {

               IList<IPersonInResult> personInResults = person.EmployeeInResult.OrderByDescending(t => t.Invitation.IssuedDate).ToList();
               if (personInResults.Count > 0)
               {
                   IPersonInResult peronInRes = personInResults.First();
                   return peronInRes;

               }
               else return null;
             //  return  Helper.GetLastInvitationEmp(person);


           }
           else if (person.IsFamilyMember)
           {

               IList<IPersonInResult> personInResults = person.FamilyMemberInResult.OrderByDescending(t => t.Invitation.IssuedDate).ToList();
               if (personInResults.Count > 0)
               {
                   IPersonInResult peronInRes = personInResults.First();
                   return peronInRes;

               }
               return null;
              // return //Helper.GetLastInvitationFM(person);


           }
           else return null;



       }
      

       public static IWorkHistory Get_LastPosition(IPersonn person)

       {

           if (person.WorkHistories.Count == 1)
           {
               return person.WorkHistories.First();
           }


           else if (person.WorkHistories.Count > 1)
           {

               return person.WorkHistories.OrderByDescending(t => t.StartDateOnThisPosition).First();
           }
           else return null;
       
       }

       public static ITravelInformation Get_LastTravelInfo(IPersonn person)



       {


           if (person.TravelInformations.Count == 1)
           {
               return person.TravelInformations.First();
           }


           else if (person.TravelInformations.Count > 1)
           {

               return person.TravelInformations.OrderByDescending(t => t.TravelDate).First();
           }
           else return null;
       

       
       }

       #endregion

       public static RelationEnum Get_EmployeeRelation(IPersonn fm)
       {
           if (fm.Employee != null && fm.FamilyMemberRelation != null)
           {
               RelationEnum relation = fm.FamilyMemberRelation.RelativeAs;

               switch (relation)
               {
                   case RelationEnum.Aýaly:
                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Erkek)
                           return RelationEnum.Adamsy;

                       else return RelationEnum.None;

                   case RelationEnum.Ogly:
                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.Ejesi;

                       }

                       else return RelationEnum.Kakasy;

                   case RelationEnum.Gyzy:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.Ejesi;

                       }
                       else return RelationEnum.Kakasy;
                   case RelationEnum.Ejesi:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.Gyzy;

                       }
                       else return RelationEnum.Ogly;
                   case RelationEnum.Kakasy:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.Gyzy;

                       }
                       else return RelationEnum.Ogly;
                   case RelationEnum.Agtygy:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.Enesi;

                       }
                       else return RelationEnum.Atasy;
                   case RelationEnum.AýalDogany:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.AýalDogany;

                       }
                       else return RelationEnum.ErkekDogany;
                   case RelationEnum.ErkekDogany:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Aýal)
                       {

                           return RelationEnum.AýalDogany;

                       }
                       else return RelationEnum.ErkekDogany;
                   case RelationEnum.Adamsy:

                       if (fm.Employee.Gender.TypeOfGender == GenderEnum.Erkek)
                       {
                           return RelationEnum.Aýaly;
                       }
                       else return RelationEnum.None;

                   case RelationEnum.Atasy:



                       return RelationEnum.Agtygy;



                   case RelationEnum.Enesi:

                       return RelationEnum.Agtygy;
                   default: return RelationEnum.None;


               }






           }
           else return RelationEnum.None;
       }

       public static void AfterChange_Gender(IPersonn person, IObjectSpace os)

       {

           if (person.BirthDate != null && (DateTime.Now.Year - person.BirthDate.Year) <= 14)
           {

               person.MaritalStatus = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Çaga));

           }
           else person.MaritalStatus = null;

          

          

       
       }

       public static void AfterChange_BirthDate(IPersonn person, IObjectSpace os)
       {


           if (person.BirthDate != null && (DateTime.Now.Year - person.BirthDate.Year) <= 14)
           {

               person.MaritalStatus = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Çaga));

           }
           else person.MaritalStatus = null;

        

       }

       public static void AfterChange_BirthCountry(IPersonn person, IObjectSpace os)

       {

           
           if (person.BirthDate != null && (DateTime.Now.Year - person.BirthDate.Year) >= 16 && person.IsFamilyMember && person.BirthCountry !=null && person.Educations.Count ==0)
           {
               var educ = os.CreateObject<IEducation>();
               educ.EducationInstitution = os.FindObject<IEducationInstitution>(new BinaryOperator("TitleOfIEducationInstitution", "Orta mekdep"));
               educ.EducationCountry = person.BirthCountry;
               educ.EducationLevel = os.FindObject<IEducationLevel>(new BinaryOperator("TitleOfEducationLevel", "Orta"));
               educ.Spcialty = os.FindObject<ISpeciality>(new BinaryOperator("TitleOfSpeciality", "Orta bilim"));
               educ.EducationStartDate = new DateTime(person.BirthDate.Year + 7, 09, 01);
               educ.EducationEndDate = new DateTime(person.BirthDate.Year + 17, 05, 25);
               person.Educations.Add(educ);
           }
       
       }

       public static void AfterChange_MaritalStatus(IPersonn person, IObjectSpace os) {

           if (person != null && person.MaritalStatus != null) {

               switch (person.MaritalStatus.Status)
               {
                   case MaritalStatus.Öýlenen:
                       person.MaritalStatus.mgCode = "2";
                       break;
                   case MaritalStatus.Sallah:
                       person.MaritalStatus.mgCode = "1";
                       break;
                   case MaritalStatus.DurmuşaÇykan:
                       person.MaritalStatus.mgCode = "2";
                       break;
                   case MaritalStatus.DurmuşaÇykmadyk:
                       person.MaritalStatus.mgCode = "1";
                       break;
                   case MaritalStatus.Aýrylşan:
                       person.MaritalStatus.mgCode = "3";
                       break;
                   case MaritalStatus.Çaga:
                       person.MaritalStatus.mgCode = "";
                       break;
                   default:
                       break;
               }
           }
       
       }

       public static bool Get_ApplicationLicenced(IPersonn person)
       {

           if (person.AppConf != null && person.AppConf.Agreement == "NgAAALu5wD+u3c0BuzklOEH1zQE02jdcMX01vjrUg6Rr2OXueb6B/Ta0tNBqjgLhwTDhornYXmlQ6R8a4+Nhx2j9WvE=")
           {

               return true;
           }

           else return false;


       }

       public static string Get_Message(IPersonn person)
       {

           if (person.AppConf != null)
           {
               return "";//person.AppConf.Messge;
           }
           else return null;
       }

       
   }

    
     [DomainComponent, ImageName("BO_Person")]
     [XafDefaultProperty("Status")]
   public interface IMaritalStatus
   {
        [RuleRequiredField]
        MaritalStatus Status {get;set;}
        [RuleRequiredField, VisibleInListView(false), VisibleInLookupListView(false)]
        string StatusL { get; set; }
        IGender Gender { get; set; }
         [Browsable(false)]
        string mgCode { get; set; }

   }

   
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TypeOfGender")]
     public interface IGender
     {
          [RuleRequiredField]
         GenderEnum  TypeOfGender {get;set;}
         [RuleRequiredField, VisibleInListView(false),VisibleInLookupListView(false)]
         string TypeOfGenderL { get; set; }
            [Browsable(false)]
         string mgCode { get; set; }
         [DevExpress.Xpo.Aggregated]
         [BackReferenceProperty("Gender")]
         IList<IRelation> Relations { get; }
         IList<IMaritalStatus> MaritalStatuses { get; }
     }


    [DomainComponent, ImageName("BO_Position")]
    [XafDefaultProperty("TitleOfPosition")]
   
    public interface IPosition
    {
        [RuleRequiredField]
        string TitleOfPosition { get; set; }

        string Code { get; set; }
       
    }

    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfDepartment")]

    public interface IDepartment
    {

        [RuleRequiredField]
        string TitleOfDepartment { get; set; }
       

    }





    
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("EducationLevel")]
    public interface IEducation
    {
        [RuleRequiredField]
        IPersonn Person { get; set; }
        [RuleRequiredField]
        IEducationInstitution EducationInstitution { get; set; }
        [RuleRequiredField]
        ICountries EducationCountry { get; set; }
        [RuleRequiredField]
        ISpeciality Spcialty { get; set; }
        [RuleRequiredField]
        IEducationLevel EducationLevel { get; set; }
        [ImmediatePostData]
        bool HasEducationPeriod { get; set; }

        [Appearance("HasEducationPeriod", Visibility = ViewItemVisibility.Hide, Criteria = "HasEducationPeriod = false")]
        DateTime EducationStartDate { get; set; }
        [Appearance("HasEducationPeriod1", Visibility = ViewItemVisibility.Hide, Criteria = "HasEducationPeriod = false")]
        DateTime EducationEndDate { get; set; }
        [DevExpress.Xpo.Aggregated]
        IList<IPassportCopy> Diplomgocurme { get; }

        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }

        [Delayed(true)]
        [Size(-1)]
        [ValueConverter(typeof(ImageValueConverter))]
       IList< Image> GöçürmeNusga { get; }

    }
    [DomainLogic(typeof(IEducation))]
    public class EducationLogic {


        public static void AfterContruction(IEducation education, IObjectSpace os)


        {


        
        }

        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IEducation education, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, education);

        }

    
    
    }


    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfIEducationInstitution")]
    public interface IEducationInstitution
    {
        [RuleRequiredField]
        string TitleOfIEducationInstitution { get; set; }


    }

    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfSpeciality")]
    public interface ISpeciality
    {
        [RuleRequiredField]
        string TitleOfSpeciality { get; set; }

    }

   
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfEducationLevel")]
    public interface IEducationLevel
    {
        [RuleRequiredField]
        string TitleOfEducationLevel { get; set; }
            [Browsable(false)]
        string mgCode { get; set; }

    }


     
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("RelativeAs")]
    public interface IRelation
    {
        [RuleRequiredField]
        RelationEnum RelativeAs { get; set; }
        [RuleRequiredField]
        string RelativeAsL { get; set; }
        string EndingLI { get;set; }
        string EndingLV { get;set; }
        [RuleRequiredField] 
        IGender Gender { get; set; }
      

    }
    [DomainLogic(typeof(IRelation))]
    public class RelationLogic { 
    
  
    
    
    }


    public enum GenderEnum

    { 
    Erkek,
    Aýal
    
    }

    public enum MaritalStatus

    { 
    
    Öýlenen,
    Sallah,
    DurmuşaÇykan,
    DurmuşaÇykmadyk,
    Aýrylşan,
    Çaga

    
    
    }

    public enum RelationEnum

    { 
        Aýaly,
        Ogly,
        Gyzy,
        Ejesi,
        Kakasy,
        Agtygy,
        AýalDogany,
        ErkekDogany,     
        Adamsy,    
        Atasy,
        Enesi,
        None
        

    
    }


    




}
