using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public enum AddressStateEnum

    { 
    
    Valid,
    Expiring,
    Expired,
    Previous,
    None
    
    }

   
    [DomainComponent, ImageName("BO_Address")]
    [XafDefaultProperty("FullAdress")]


    public interface IAddresses 
    {
       //  [RuleRequiredField]
     //   [VisibleInDetailView(false),VisibleInListView(false)]
         [ImmediatePostData]
         IRegion Region { get; set; }
      //   [RuleRequiredField]
        // [DataSourceProperty("Region.Cities")]
        //   [VisibleInDetailView(false), VisibleInListView(false)]
         [ImmediatePostData]
         IŞäherEtrap ŞäherEtrap { get; set; }
         [RuleRequiredField]
         string AddressLine { get; set; }  
         [RuleRequiredField]
         IDocumentOfAddress DocumentOfAddress { get; set; }
         [RuleRequiredField]
         DateTime ExpiringDateOfAddressDocument { get; set; }

         string FullAdress { get; }
      
         
    }

    [DomainLogic(typeof(IAddresses))]
    public class AddressLogic {


        public static string Get_FullAdress(IAddresses address)


        {
            if (address.AddressLine != null)
            {
                return address.AddressLine;
            }
            else return null;
        }

    
    }


    #region Appearence

     [Appearance("PreviousAddress", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
         Criteria = "AddressState='Previous'", BackColor = "LightGray", FontColor = "Gray")]


    [Appearance("AddressExpiring", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
      Criteria = "AddressState ='Expiring'", BackColor = "Crimson", FontColor = "White")]

    [Appearance("AddressExpired", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
     Criteria = "AddressState ='Expired'", BackColor = "Crimson", FontColor = "White")]

    #endregion


    [DomainComponent, ImageName("BO_Address")]
    [XafDefaultProperty("Address")]
    public interface IAddressOfResidence : IRemainingDays
    {
         [RuleRequiredField,ImmediatePostData]
         IAddresses Address { get; set; }
         [ImmediatePostData]
         bool ShowAddressStartDate { get; set; }
         
         [RuleRequiredField]
         [Appearance("StartDateOnThisPosition", Visibility = ViewItemVisibility.Hide, Criteria = "ShowAddressStartDate = false")]
         DateTime StartDateOfResidence { get; set; }
        
        
         IPersonn Person { get; set; }

         AddressStateEnum AddressState { get; }
        [Browsable(false)]
         AppConf AppConf { get; set; }

        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }

    }
[DomainLogic (typeof(IAddressOfResidence))]
    public class AddressOfResidenceLogic {


    public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IAddressOfResidence addressOfResidence, IObjectSpace os)
    {



        return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, addressOfResidence);


    }

    public static AddressStateEnum Get_AddressState(IAddressOfResidence addressOfResidence)

    {
        if (addressOfResidence.AppConf != null && addressOfResidence.Address !=null)
        {
            if (addressOfResidence.Person.LastAddressOfResidence != null && addressOfResidence.Person.LastAddressOfResidence != addressOfResidence)
            {
                return AddressStateEnum.Previous;

            }
            else if (addressOfResidence.Person.LastAddressOfResidence != null && addressOfResidence.Person.LastAddressOfResidence == addressOfResidence && addressOfResidence.RemainingDays >= addressOfResidence.AppConf.AddressExpireDay)
            {
                return AddressStateEnum.Valid;

            }

            else if (addressOfResidence.Person.LastAddressOfResidence != null && addressOfResidence.Person.LastAddressOfResidence == addressOfResidence && addressOfResidence.RemainingDays < addressOfResidence.AppConf.AddressExpireDay && addressOfResidence.Address.ExpiringDateOfAddressDocument > DateTime.Today)
            {
                return AddressStateEnum.Expiring;
            }

            else if (addressOfResidence.Person.LastAddressOfResidence != null && addressOfResidence.Person.LastAddressOfResidence == addressOfResidence && addressOfResidence.RemainingDays == 0)
            {
                return AddressStateEnum.Expired;
            }
            else return AddressStateEnum.None;
        }
        else return AddressStateEnum.None;
    }


    public int Get_RemainingDays(IAddressOfResidence address)
    {

        {
            if (address.Address != null)
            {
                return Helper.GetRemainingDaysBeforeExpire(address.Address.ExpiringDateOfAddressDocument);
            }

            else return 0;
        }



    }


    public static void AfterConstruction(IAddressOfResidence addressOfResidence, IObjectSpace obspace)
    {
        var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
        if (appConf != null)
        {

            addressOfResidence.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

        }

        addressOfResidence.StartDateOfResidence = DateTime.Now;

    }

}



    [DomainComponent, ImageName("BO_Address")]
    [XafDefaultProperty("AddressOnTrip")]
    public interface IAddressOnBusinessTrip 
    {
        [RuleRequiredField]
        IAddresses AddressOnTrip { get; set; } 
        
    }


    [DomainComponent, ImageName("BO_Address")]
    [XafDefaultProperty("TypeOfDocument")]
    public interface IDocumentOfAddress
    {
         [RuleRequiredField]

        string TypeOfDocument { get; set; }
    }

   



    





    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IAddress));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IAddress))]
    //public class IAddressLogic {
    //    public static string Get_CalculatedProperty(IAddress instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IAddress instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IAddress instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IAddress instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
