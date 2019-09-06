using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace VISA2014.Module.DC
{

    #region Appearence for Fill

      [Appearance("FullName", AppearanceItemType = "ViewItem", TargetItems = "FullName", Context = "ListView, DetailView",
      Criteria = "FullName='Fill FullName' Or IsNullOrEmpty(FullName) ", BackColor = "Gold", FontColor = "Black")]


      [Appearance("PassportDetails", AppearanceItemType = "ViewItem", TargetItems = "PassportDetails", Context = "ListView, DetailView",
      Criteria = "PassportDetails='Fill Passport Detail(Number,IssuedPlace & date)' Or IsNullOrEmpty(PassportDetails) ", BackColor = "Gold", FontColor = "Black")]


      [Appearance("PhoneNumbers", AppearanceItemType = "ViewItem", TargetItems = "PhoneNumbers", Context = "ListView, DetailView",
      Criteria = "PhoneNumbers='Fill office,home,mobile number' Or IsNullOrEmpty(PhoneNumbers) ", BackColor = "Gold", FontColor = "Black")]


    #endregion
    
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("FullName")]
    public interface ICompanyRepresentative
    {
        [RuleRequiredField]
        string FullName { get; set; }
       [RuleRequiredField]
        string PassportDetails { get; set; }
       [RuleRequiredField]
        string PhoneNumbers { get; set; }
        ICompany Company { get; set; }


    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(ICompanyRepresentative));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(ICompanyRepresentative))]
    //public class ICompanyRepresentativeLogic {
    //    public static string Get_CalculatedProperty(ICompanyRepresentative instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(ICompanyRepresentative instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(ICompanyRepresentative instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(ICompanyRepresentative instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
