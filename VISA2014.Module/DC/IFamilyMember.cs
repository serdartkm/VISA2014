using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace VISA2014.Module.DC
{
    [DomainComponent]
    [VisibleInReports]
    [RuleCriteria("ForiegnAddress1", DefaultContexts.Save, "Not IsNullOrEmpty(ForeignAddress)", "Daºary ýurtdaky salgysyny ýazmaly", SkipNullOrEmptyValues = false)]
    [RuleCriteria("ForiegnAddressÇountry1", DefaultContexts.Save, "Not IsNullOrEmpty(ForeignAddressCountry)", "Daºary ýurtdaky salgysyny ýazmaly", SkipNullOrEmptyValues = false)]
    public interface IFamilyMember: IPersonn
    {
   

      

    }
    [DomainLogic(typeof(IFamilyMember))]
    public class FamilyMemberLogic {

        public static void AfterConstruction(IFamilyMember fm)

        {

            fm.IsFamilyMember = true;
        
        }
    
    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IFamilyMember));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IFamilyMember))]
    //public class IFamilyMemberLogic {
    //    public static string Get_CalculatedProperty(IFamilyMember instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IFamilyMember instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IFamilyMember instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IFamilyMember instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
