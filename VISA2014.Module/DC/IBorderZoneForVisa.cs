using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{
    [DomainComponent]
  
    [XafDefaultProperty("BorderZoneCollectionForVisa")]
    [Appearance("Ýolöten", AppearanceItemType = "ViewItem", TargetItems = "Ýolöten", Context = "DetailView",
  Criteria = "Ýolöten = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Daşoguz", AppearanceItemType = "ViewItem", TargetItems = "Daşoguz", Context = "DetailView",
   Criteria = "Daşoguz = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Tagtabazar", AppearanceItemType = "ViewItem", TargetItems = "Tagtabazar", Context = "DetailView",
   Criteria = "Tagtabazar = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Serhetabat", AppearanceItemType = "ViewItem", TargetItems = "Serhetabat", Context = "DetailView",
   Criteria = "Serhetabat = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Farap", AppearanceItemType = "ViewItem", TargetItems = "Farap", Context = "DetailView",
   Criteria = "Farap = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Garabogaz", AppearanceItemType = "ViewItem", TargetItems = "Garabogaz", Context = "DetailView",
   Criteria = "Garabogaz = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Sarahs", AppearanceItemType = "ViewItem", TargetItems = "Sarahs", Context = "DetailView",
   Criteria = "Sarahs = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("Etrek", AppearanceItemType = "ViewItem", TargetItems = "Etrek", Context = "DetailView",
   Criteria = "Etrek = true", BackColor = "SpringGreen", FontColor = "Black")]
    public interface IBorderZoneForVisa
    {
          
        [ImmediatePostData, VisibleInListView(false)]
        bool Daşoguz { get; set; }

        [ImmediatePostData, VisibleInListView(false)]
        bool Tagtabazar { get; set; }

        [ImmediatePostData, VisibleInListView(false)]
        bool Serhetabat { get; set; }
        [ImmediatePostData, VisibleInListView(false)]
        bool Ýolöten { get; set; }
        [ImmediatePostData, VisibleInListView(false)]
        bool Farap { get; set; }
        [ImmediatePostData, VisibleInListView(false)]
        bool Garabogaz { get; set; }
        [ImmediatePostData, VisibleInListView(false)]
        bool Sarahs { get; set; }
        [ImmediatePostData, VisibleInListView(false)]
        bool Etrek { get; set; }
        [ImmediatePostData, VisibleInListView(false),VisibleInDetailView(false)]
        string BorderZoneCollectionForVisa { get; }
        
        [Browsable(false)]
        AppConf AppConfig {get;set;}

       // string BorderZoneCollectionForLine { get; }
    }

    [DomainLogic(typeof (IBorderZoneForVisa))]
    public class BorderZoneForVisaLogic { 
    
    

        public static void AfterConstruction (IBorderZoneForVisa bzForVisa, IObjectSpace obspace)

        {
        
          var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
       if (appConf != null)
       {

           bzForVisa.AppConfig = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

       }
        
        
        }


        public static string Get_BorderZoneCollectionForVisa(IBorderZoneForVisa bzForVisa)
        {


            return Helper.Get_BZ_collection(bzForVisa);



        }


    
    
    }



    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IBorderZoneForVisa));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IBorderZoneForVisa))]
    //public class IBorderZoneForVisaLogic {
    //    public static string Get_CalculatedProperty(IBorderZoneForVisa instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IBorderZoneForVisa instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IBorderZoneForVisa instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IBorderZoneForVisa instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
