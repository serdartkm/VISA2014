using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace VISA2014.Module.DC
{
    [DomainComponent]
    public interface IPassportCopy
    {
        [Delayed(true)]
        [Size(-1)]
        [ValueConverter(typeof(ImageValueConverter))]
        Image Gцзьrme { get; set; }
      
          [VisibleInDetailView(false), VisibleInListView(false)]
          IEducation Education { get; set; }
           [VisibleInDetailView(false), VisibleInListView(false)]
          IPassport Passport { get; set; }

   
    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IPassportCopy));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IPassportCopy))]
    //public class IPassportCopyLogic {
    //    public static string Get_CalculatedProperty(IPassportCopy instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IPassportCopy instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IPassportCopy instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IPassportCopy instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
