using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{
    [DomainComponent]
    [XafDefaultProperty("TravelDate")]
    public interface ITravelInformation
    {
        TravelTypeEnum TravelType { get; set; }
        DateTime TravelDate { get; set; }
        CheckPoint CheckPoint { get; set; }
        PurposeOfTravel PurposeOfTravel { get; set; }
        IPersonn Person { get; set; }


        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
        string TravelDateForReport { get; }
    }

    [DomainLogic(typeof(ITravelInformation))]
    public class TravelinForClass

    {

        public static string Get_TravelDateForReport(ITravelInformation tinfo)

        {

            return tinfo.TravelDate.ToString("dd.MM.yyyy");
        
        
        }



        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(ITravelInformation travelInfor, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, travelInfor);

        }
    
    
    }





       public enum TravelTypeEnum
    { 
    
    Entry,
    Exit
    
    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(ITravelInfor));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(ITravelInfor))]
    //public class ITravelInforLogic {
    //    public static string Get_CalculatedProperty(ITravelInfor instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(ITravelInfor instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(ITravelInfor instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(ITravelInfor instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
