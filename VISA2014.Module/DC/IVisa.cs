using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using VISA2014.Module.BusinessObjects;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Xpo;
using System.Drawing;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo;
using System.Linq;


namespace VISA2014.Module.DC
{

    public enum VisaStateEnum


    { 
    Expiring,
    Expired,
    OnExtention,
    None
   
    
    
    }

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

    #endregion

    #region State Appearece

      

    // Visa AS Number And Application Process Number Does not match

        [Appearance("ASNummber mismatch", AppearanceItemType = "ViewItem", TargetItems = "ProcessNumber", Context = "DetailView",
        Criteria = "Not IsNullOrEmpty(ASNumber) And VisaIssuedDate Is Not Null And  ASNumber != ProcessNumber.Application.ProcessNumber And ProcessNumber Is Not Null", BackColor = "Crimson", FontColor = "White")]

    #endregion

    #region Licence Appearence


      // [Appearance("NotLicences", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView,DetailView",
       //  Criteria = "ApplicationLicenced= false ", Enabled = false)]

    #endregion



    [RuleCriteria("BorderZoneForVisaRule1", DefaultContexts.Save, "(HasBorderZonePermit = true And BorderZone Is Not Null) Or (HasBorderZonePermit =false And BorderZone Is Null) Or  (HasBorderZonePermit =false And BorderZone Is Not Null)",
   "Border Zone must be specified", SkipNullOrEmptyValues = false)]

    [RuleCombinationOfPropertiesIsUnique("VisaNumber", DefaultContexts.Save, "VisaNumber", MessageTemplateCombinationOfPropertiesMustBeUnique = "Bu belgili visa öň ýazylan.")]

       [RuleCriteria("VisaEndDate1", DefaultContexts.Save, "VisaEndDate > VisaStartDate ",
"VisaEndDate can be only greater  than IssuedDate And Visa Start Date", SkipNullOrEmptyValues = false)]

 [DomainComponent, ImageName("BO_UnKnown")]
 [XafDefaultProperty("VisaNumber")]

    public interface  IVisa :IRemainingDays, IMessage
    {

            [RuleRequiredField]
         string VisaNumber { get; set; }
            [RuleRequiredField]
         IVisaType VisaType { get; set; }
            [RuleRequiredField]
         IVisaCategory VisaCategory { get; set;}
            [ImmediatePostData]
            [RuleRequiredField]
         DateTime VisaIssuedDate { get; set; }
            [RuleRequiredField]
         IVisaIssuedPlace VisaIssuedPlace { get; set; }
            [RuleRequiredField]
         DateTime VisaStartDate { get; set; }
        [RuleRequiredField]
         DateTime VisaEndDate { get; set; }
            [RuleRequiredField]
         IPassport Passport { get; set; }
         [ImmediatePostData, VisibleInListView(false),VisibleInLookupListView(false)]
         bool HasBorderZonePermit {get;set;}
         #region Appearence



        [Appearance("PersonInApp", Enabled = false)]

#endregion
         IPersonInApplication ProcessNumber { get; set; }
         [RuleRequiredField]
         string ASNumber { get; set; }
         [DataSourceCriteria("Daşoguz = false And Tagtabazar = false And Serhetabat = false And Etrek = false And Sarahs = false And Garabogaz = false And Ýolöten = false And Farap = false")]
         [ImmediatePostData]
         [Appearance("BorderZoneForVisaVisibility", Visibility = ViewItemVisibility.Hide, Criteria = "HasBorderZonePermit =false")]
         IBorderZoneForVisa BorderZone { get; set; }
          [Browsable(false)]
          AppConf AppConf { get; set; }
          VisaState VisaState { get; }
        //   [Browsable(false)]
           IPersonInApplication PersonInApplication { get; }
             [BackReferenceProperty("Visa")]
             IList<IPersonInApplication> PersonInApplications { get; }
            [DevExpress.Xpo.Aggregated]
             IList<ICopy> VisaCopy { get; }
           
             IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
             [Delayed(true)]
             [Size(-1)]
             [ValueConverter(typeof(ImageValueConverter))]
             Image GöçürmeNusga { get; set; }
             bool HasabaAlynmayar { get; set; }
    }

     [DomainLogic(typeof(IVisa))]
     public class VisaLogic

 {


         public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IVisa visa, IObjectSpace os)
         {



             return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, visa);

         }


         public static void OnSaving(IVisa visa, IObjectSpace obspace)
         {

             //Visa Type
          

             // VisaIssuedPlace

          

           



         }


        public static void AfterConstruction(IVisa visa, IObjectSpace obspace)

         {
             var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
             if (appConf != null)
             {

                 visa.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

             }



         }

        public static bool Get_ApplicationLicenced(IVisa visa)


        {

        
             return true;
        
        
        }

        public static IPersonInApplication Get_PersonInApplication(IVisa visa)



        {

            if (visa.Passport != null && visa.Passport.Person != null && visa.Passport.Person.IsEmployee && visa.Passport.Person.EmployeeInApplications.Count>0)
            {
                IPersonInApplication appForVisa = null;

                foreach (var personInApp in visa.Passport.Person.EmployeeInApplications)
                {
                    SubType st=personInApp.ApplicationType;
                    

                    switch (st)
                    {
                        case  SubType.ApplicationForVisaExtention:

                            if (personInApp.Visa == visa)
                            {
                             appForVisa = personInApp;
                            }
                            break;

                        case SubType.ApplicationForChangingPassport:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;

                        case SubType.ApplicationForChangingVisaCategory:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;
                        case SubType.ApplicationForCancellingVisaAndWorkpermit:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;
                    }

                }

                return appForVisa;

            }


            else if (visa.Passport != null && visa.Passport.Person != null && visa.Passport.Person.IsFamilyMember  && visa.Passport.Person.FamilyMemberInApplications.Count>0)
            {
                IPersonInApplication appForVisa = null;

                foreach (var personInApp in visa.Passport.Person.FamilyMemberInApplications)
                {
                    SubType st = personInApp.ApplicationType;


                    switch (st)
                    {
                        case SubType.ApplicationForVisaExtention:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;

                        case SubType.ApplicationForChangingPassport:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;

                        case SubType.ApplicationForChangingVisaCategory:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;
                        case SubType.ApplicationForCancellingVisaAndWorkpermit:

                            if (personInApp.Visa == visa)
                            {
                                appForVisa = personInApp;
                            }
                            break;
                    }
                }

                return appForVisa;

            }

            else return null;
        
        
        }


        public static VisaState Get_VisaState(IVisa visa)

        {
            
            try
            {
                 if (visa.PersonInApplications.Count==0 && visa.RemainingDays <= 0)
                {

                    return VisaState.VISA_EXPIRED;
                }

                if (visa.PersonInApplications.Count==0 && visa.RemainingDays >=1)
                {
                    return VisaState.VISA_VALID;
                }
                
                if (visa.PersonInApplications != null && visa.PersonInApplications.Count == 1) { 

                  IPersonInApplication personInApp = visa.PersonInApplications.First();
                  if (
                      personInApp.Application.SubType == SubType.ApplicationForCancellingVisa
                      | personInApp.Application.SubType == SubType.ApplicationForCancellingVisaAndWorkpermit
                 
                      | personInApp.Application.SubType == SubType.ApplicationForVisaExtention) {
                          return VisaStateHelper.GetVisaState(personInApp, visa, VisaState.VISA_NONE);
                  }
                   
                  if ( visa.RemainingDays <= 0)
                  {

                      return VisaState.VISA_EXPIRED;
                  }

                  if ( visa.RemainingDays >= 1)
                  {
                      return VisaState.VISA_VALID;
                  }
                
                    return VisaState.VISA_NONE;
                }

                if (visa.PersonInApplications.Count > 1) {
                    
                   // IPersonInApplication personInApp = visa.PersonInApplications.OrderByDescending(t => t.Application.ManualApplicationDate).First();
                    IList<IPersonInApplication> personInApp = visa.PersonInApplications.Where(c=>!c.Cancelled && !c.Application.Cancelled).Where(t => t.Application.SubType == SubType.ApplicationForVisaExtention
                  | t.Application.SubType == SubType.ApplicationForCancellingVisa
                  | t.Application.SubType == SubType.ApplicationForCancellingVisaAndWorkpermit
                  | t.Application.SubType == SubType.VisaExtentionAccordingToWorkPermit
                  ).OrderByDescending(t => t.Application.ManualApplicationDate).ToList();

                    if (personInApp.Count >0) {

                        IPersonInApplication pInApp = personInApp.First();
                        return VisaStateHelper.GetVisaState(pInApp, visa, VisaState.VISA_NONE);
                    }

                    if (visa.RemainingDays <= 0)
                    {

                        return VisaState.VISA_EXPIRED;
                    }

                    if (visa.RemainingDays >= 1)
                    {
                        return VisaState.VISA_VALID;
                    }
                  
                }
                
                if (visa.RemainingDays <= 0)
                {

                    return VisaState.VISA_EXPIRED;
                }

                if (visa.RemainingDays >= 1)
                {
                    return VisaState.VISA_VALID;
                }
                
                
                return VisaState.VISA_NONE;
             
            }
            catch (Exception)
            {

                return VisaState.VISA_NONE;
            }
            
          
        }
 
       
        public int Get_RemainingDays(IVisa visa)
        {

            
                return Helper.GetRemainingDaysBeforeExpire(visa.VisaEndDate);
            

        }


        public static void AfterChange_VisaIssuedDate(IVisa visa)


        {

            if (visa.VisaIssuedDate != null && visa.Passport !=null)

            {

                visa.ProcessNumber = Helper.Get_PersonInAppForVisa(visa.Passport.Person, visa);
            
            }

        }


        public static string Get_Message(IVisa visa)

        {

            return "";
        
        }
       
 }

     
   [DomainComponent,  ImageName("BO_UnKnown")]
   [XafDefaultProperty("TypeOfVisa")]
    public interface IVisaType
    {
        string TypeOfVisa { get; set; }
        string TypeOfVisaL { get; set; }
           [Browsable(false)]
        string mgCode { get; set; }
    }




      
     [DomainComponent, ImageName("BO_UnKnown")]
     [XafDefaultProperty("FullDiscription")]
    public interface IVisaIssuedPlace
    {

          [RuleRequiredField]
          VisaIssuedPlacesEnum IssuedPlaceOfVisa { get; set; }
         [RuleRequiredField]
         [VisibleInListView(false),VisibleInLookupListView(false)]
         string IssuedPlaceOfVisaL { get; set; }
         bool IsDefault { get; set; }
         string FullDiscription { get; }
    }


     [DomainLogic(typeof(IVisaIssuedPlace))]
     public class VisaIssuedPlaceLogic
     {

         public static string Get_FullDiscription(IVisaIssuedPlace vip)
         { return vip.IssuedPlaceOfVisaL; }

     }


    
    [DomainComponent,  ImageName("BO_UnKnown")]
    [XafDefaultProperty("CategoryOfVisa")]
    public interface IVisaCategory
    {
        [RuleRequiredField]
        VisaCategoryEnum CategoryOfVisa { get; set; }
     
        [RuleRequiredField, VisibleInListView(false),VisibleInLookupListView(false)]
        string CategoryOfVisaL { get; set; }
            [Browsable(false)]
        string mgCode { get; set; }
    }


    public enum VisaIssuedPlacesEnum

    { 
    
        Türkmenistanda,
        DaşaryÝurtda

    
    }
     
    public enum VisaCategoryEnum

    { 
        KöpGezeklik,
        BirGezeklik,
        IkiGezeklik,
        ÜçGezeklik

    
    }

   

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IVisa));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IVisa))]
    //public class IVisaLogic {
    //    public static string Get_CalculatedProperty(IVisa instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IVisa instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IVisa instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IVisa instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
