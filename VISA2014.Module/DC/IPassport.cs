using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DomainComponents.Common;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Linq;
using VISA2014.Module.BusinessObjects;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ServiceModel.Channels;
using DevExpress.Persistent.AuditTrail;
using DevExpress.ExpressApp.Xpo;
using System.Drawing;
using DevExpress.Xpo.Metadata;
namespace VISA2014.Module.DC
{

    public enum PassportStateEnum

    { 
    Previous,
    Expiring,
    Expired,
    Valid,
    None
    
    }

    #region Passport State

     [Appearance("Previous", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
         Criteria = "PassportState='Previous'", BackColor = "LightGray", FontColor = "Gray")]


     [Appearance("PassportExpiring", AppearanceItemType = "ViewItem", TargetItems = "PassportNumber,PassportState", Context = "ListView",
       Criteria = "PassportState ='Expiring'", BackColor = "Crimson", FontColor = "White")]

     [Appearance("PassportExpired", AppearanceItemType = "ViewItem", TargetItems = "PassportNumber, PassportState", Context = "ListView",
     Criteria = "PassportState ='Expired'", BackColor = "Crimson", FontColor = "White")]

    #endregion


    #region Licence Appearence


  //  [Appearance("NotLicences", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView,DetailView",
     //   Criteria = "ApplicationLicenced= false ", Enabled = false)]

        #endregion

     [RuleCombinationOfPropertiesIsUnique("PassportNumber", DefaultContexts.Save, "PassportNumber,Citizenship", MessageTemplateCombinationOfPropertiesMustBeUnique = "Bu pasport öò ýazylan.")]
    [DomainComponent, ImageName("BO_UnKnown")]
    [XafDefaultProperty("PassportNumber")]
    public interface IPassport : IRemainingDays, IMessage
    {    [RuleRequiredField]
        string PassportNumber { get; set; }
          [RuleRequiredField]
        IPassportType PassportType { get; set; }
        [Appearance("VisaIsNotRequired ", Visibility = ViewItemVisibility.Hide, Criteria = "PassportType.TypeOfPassport='Service' Or PassportType.TypeOfPassport='Diplomatic' ")]
       [ImmediatePostData]
        bool VisaIsNotRequired { get; set; }
          [RuleRequiredField]
        ICountries Citizenship { get; set; }
          [RuleRequiredField]
        DateTime PassportIssuedDate { get; set; }
        [VisibleInDetailView(false),VisibleInListView(true),VisibleInLookupListView(true)]
        string PassportIssuedDateForLetter { get; }
          [RuleRequiredField]
        string PassportIssuedPlace { get; set; }
          [RuleRequiredField]
        string PersonalNumber { get; set; }
          [RuleRequiredField]
        DateTime PassportExpiringDate { get; set; }

        [VisibleInDetailView(false), VisibleInListView(true), VisibleInLookupListView(true)]
        string PassportExpireingDateForLetter { get; }
        [RuleRequiredField]
        ICountries PassportIssuedCountry { get; set; }
        IPersonn Person { get; set; }
         
        [Appearance("PassportVisaVisibility", Visibility = ViewItemVisibility.Hide, Criteria = "VisaIsNotRequired =true")]
        [DevExpress.Xpo.Aggregated]
         [ImmediatePostData]
        IList<IVisa> Visas { get; }
         [DevExpress.Xpo.Aggregated]
        IList<ICopy> PassportCopy { get;  } 
        IVisa LastVisa { get; }

        [Browsable(false)]
        AppConf AppConf { get; set; }

        PassportStateEnum PassportState { get; }
        IPersonInApplication PersonInApplication { get; }



          IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
           [DevExpress.Xpo.Aggregated]
          IList<IPassportCopy> IDCopy { get; }

    }

    [DomainLogic(typeof(IPassport))]
    public class PassportLogic
   
    {

        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IPassport passport, IObjectSpace os)

        

        {

        

            return  DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session,passport);
        
        }
        


        public static void OnSaving(IPassport passport, IObjectSpace obspace)
        {
            /*
            //Passport Type
            if (!String.IsNullOrEmpty(passport.ImpPassportType))
            {
                IPassportType passportType = obspace.FindObject<IPassportType>(new BinaryOperator("TypeOfPassportL", passport.ImpPassportType));

                passport.PassportType = passportType;
            }

            // Passport Issued Country

            if (!String.IsNullOrEmpty(passport.ImpPassportIssuedCountry))
            {


                ICountries passportIssuedCountry = obspace.FindObject<ICountries>(new BinaryOperator("NameOfCountry", passport.ImpPassportIssuedCountry));

                passport.PassportIssuedCountry = passportIssuedCountry;

            }

            //Citizenship
            if (!String.IsNullOrEmpty(passport.ImpCitizenship))
            {


                ICountries citizenship = obspace.FindObject<ICountries>(new BinaryOperator("NameOfCountry", passport.ImpCitizenship));

                passport.Citizenship = citizenship;


            }


            // Person
            if (!String.IsNullOrEmpty(passport.ImpPersonID))
            {


                IPersonn personID = obspace.FindObject<IPersonn>(new BinaryOperator("IDNumber", passport.ImpPersonID));

                passport.Person = personID;


            }

           
            */

        }

        public static PassportStateEnum Get_PassportState(IPassport passport)
        {
            PassportStateEnum ps = PassportStateEnum.None;
            if (passport.Person!=null && passport.Person.Passports.Count > 0)
            {

                foreach (var passp in passport.Person.Passports)
                {

                    if (passport == passp.Person.LastPassport && passport.RemainingDays > passport.AppConf.PassportExpireDay)
                    {

                        ps = PassportStateEnum.Valid;
                        break;
                    }

                    if (passport == passp.Person.LastPassport && passport.RemainingDays ==0)
                    {

                        ps = PassportStateEnum.Expired;
                        break;
                    }
                    else if (passport== passp.Person.LastPassport && passport.RemainingDays <= passport.AppConf.PassportExpireDay)
                    {
                        ps = PassportStateEnum.Expiring;
                        break;
                    }
                    else if (passport != passp.Person.LastPassport)
                    {
                        ps = PassportStateEnum.Previous;
                        break;
                    }
                    else ps = PassportStateEnum.None;


                }


                return ps;
            }

            else return PassportStateEnum.None;

        }


        public static void AfterConstruction(IPassport passport, IObjectSpace obspace)


        {

            var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
            if (appConf != null)
            {

                passport.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

            }
        
        }

        public static string Get_PassportIssuedDateForLetter(IPassport passport)



        {

            if (passport.PassportIssuedDate != null)
            {

                return passport.PassportIssuedDate.ToString("dd.MM.yyyy ý.");


            }


            else return null;
        
        
        
        }

        public static string Get_PassportExpireingDateForLetter(IPassport passport)

        {

            if (passport.PassportExpiringDate != null)
            {

                return passport.PassportExpiringDate.ToString("dd.MM.yyyy ý.");


            }


            else return null;
        

        
        }

        public int Get_RemainingDays(IPassport passport)
        {

            {
                return Helper.GetRemainingDaysBeforeExpire(passport.PassportExpiringDate);
            }

        }


        public static IVisa Get_LastVisa(IPassport passport)


        {

            if (passport.Visas.Count == 1)
            {
                return passport.Visas.First();
            }


            else if (passport.Visas.Count > 1)
            {
               
                    return passport.Visas.OrderByDescending(t => t.VisaStartDate).First();
                
             
                
            }
            else return null;
        
        }


        public static bool Get_ApplicationLicenced(IPassport passport)
        {

            return true;


        }

        public static string Get_Message(IPassport passport)
        {

            if (passport.AppConf != null)
            {
                return passport.AppConf.Messge;
            }
            else return null;
        }

        public static IPersonInApplication Get_PersonInApplication(IPassport passport)
        {

            if (passport.Person.IsEmployee)
            {
                IPersonInApplication temp = null;
                foreach (var empInApp in passport.Person.EmployeeInApplications)
                {

                    if (empInApp.ApplicationType == SubType.ApplicationForChangingPassport && empInApp.PreviousPassport == passport)
                    {


                        return temp = empInApp;

                    }




                }

                return temp;
            }

            else if (passport.Person.IsFamilyMember)
            {


                IPersonInApplication temp = null;
                foreach (var empInApp in passport.Person.FamilyMemberInApplications)
                {

                    if (empInApp.ApplicationType == SubType.ApplicationForChangingPassport && empInApp.PreviousPassport == passport)
                    {


                        return temp = empInApp;

                    }




                }

                return temp;

            }
            else return null;


        
        
        }
    }



     
    [DomainComponent, ImageName("BO_UnKnown")]
    [XafDefaultProperty("TypeOfPassport")]
     public interface IPassportType
    {
        PassportTypeEnum TypeOfPassport { get; set; }
        string TypeOfPassportL { get; set; }
            [Browsable(false)]
        string mgCode { get; set; }
     
    }



     [DomainComponent, ImageName("BO_UnKnown")]
     [XafDefaultProperty("PlaceOfIssue")]
    public interface IPassportIssuedPlace
    {
        string PlaceOfIssue { get; set; }
    }

    public enum PassportTypeEnum 


{
    Ordinary,
    Service,
    Diplomatic


}

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IPassport));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IPassport))]
    //public class IPassportLogic {
    //    public static string Get_CalculatedProperty(IPassport instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IPassport instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IPassport instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IPassport instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
