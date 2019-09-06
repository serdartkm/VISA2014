using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;

namespace VISA2014.Module.DC
{
    [DomainComponent]
  
    public interface IApplicationForBorderZonePermit
    {
        [Browsable(false),ImmediatePostData]
        bool BorderZonePeriodVisibility { get; }
        [Appearance("BorderZonePeriod", Visibility = ViewItemVisibility.Hide, Criteria = "BorderZonePeriodVisibility = false")]
        IVisaPeriod BorderZonePeriod { get; set; }
        [Appearance("BorderZoneForVisaInApp", Visibility = ViewItemVisibility.Hide, Criteria = "BorderZonePeriodVisibility = false And ChooseBorderZoneType ='BorderZoneIsNotRequired'")]
        [Appearance("BorderZoneForVisaInApp2", Visibility = ViewItemVisibility.Hide, Criteria = "ChooseBorderZoneType ='BorderZoneIsNotRequired'")]
        [Appearance("BorderZoneForVisaInApp3", Visibility = ViewItemVisibility.Hide, Criteria = "BorderZoneVisibility=false")]
        [DataSourceCriteria("Daşoguz = false And Tagtabazar = false And Serhetabat = false And Etrek = false And Sarahs = false And Garabogaz = false And Ýolöten = false And Farap = false")]
        IBorderZoneForVisa BorderZoneForVisa { get; set; }
        [VisibleInListView(false),VisibleInDetailView(false),VisibleInLookupListView(false)]
        string BorderZoneCollectionForBZApp { get; }

        [ImmediatePostData, VisibleInListView(false), VisibleInDetailView(false)]
        string BorderZoneCollection { get; }
        [ImmediatePostData, VisibleInListView(false), VisibleInDetailView(false)]
        string BorderZoneCollectionForLine { get; }

    }

 



    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IApplicationForBorderZonePermit));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IApplicationForBorderZonePermit))]
    //public class IApplicationForBorderZonePermitLogic {
    //    public static string Get_CalculatedProperty(IApplicationForBorderZonePermit instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IApplicationForBorderZonePermit instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IApplicationForBorderZonePermit instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IApplicationForBorderZonePermit instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
