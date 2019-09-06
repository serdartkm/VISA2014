using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.Drawing;
using DevExpress.Xpo.Metadata;

namespace VISA2014.Module.DC
{
    [DomainComponent]
    public interface FamilyProofDocument
    {
        //string PersistentProperty { get; set; }
        //string CalculatedProperty { get; }
        //int SumMethod(int val1, int val2);


        [Delayed(true)]
        [Size(-1)]
        [ValueConverter(typeof(ImageValueConverter))]
        Image CopyOfDocument { get; set; }



    }

    [DomainLogic(typeof(FamilyProofDocument))]
    public class FamilyProofDocumentLogic

    {
    
    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(FamilyProofDocument));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(FamilyProofDocument))]
    //public class FamilyProofDocumentLogic {
    //    public static string Get_CalculatedProperty(FamilyProofDocument instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(FamilyProofDocument instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(FamilyProofDocument instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(FamilyProofDocument instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
