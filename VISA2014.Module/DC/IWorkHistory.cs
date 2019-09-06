using System;
using System.Collections;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;


namespace VISA2014.Module.DC
{
    [DomainComponent, ImageName("BO_Position")]
    [XafDefaultProperty("Position")]
    public interface IWorkHistory
    {
       [RuleRequiredField]
        ICompany Company { get; set; }
        [RuleRequiredField]
        IDepartment Department { get; set; }
        [RuleRequiredField]
        IPosition Position { get; set; }
        [ImmediatePostData]
        bool hasPositionStartDate { get; set; }
        [Appearance("StartDateOnThisPosition", Visibility = ViewItemVisibility.Hide, Criteria = "hasPositionStartDate = false")]
        [RuleRequiredField]
        DateTime StartDateOnThisPosition { get; set; }

        // DateTime StartDateOnThisPosition { get; set; }
        [RuleRequiredField]
        IPersonn Employee { get; set; }
  

        // Import Data
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string ImpCompany { get; set; }
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string ImpDepartment { get; set; }
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string ImpPosition { get; set; }
        [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
        string ImpIDNumber { get; set; }


        IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }


    }
    [DomainLogic(typeof(IWorkHistory))]
    public class IWorkHistoryLogic
    {

        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IWorkHistory workhistory, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, workhistory);


        }



        public static void OnSaving(IWorkHistory wh, IObjectSpace obspace)
        {


            //Imp Company
            if (!String.IsNullOrEmpty(wh.ImpCompany))
            {
                ICompany company = obspace.FindObject<ICompany>(new BinaryOperator("TitleOfCompany", wh.ImpCompany));

                wh.Company = company;

            }

            // Imp Department
            if (!String.IsNullOrEmpty(wh.ImpDepartment))
            {


                IDepartment department = obspace.FindObject<IDepartment>(new BinaryOperator("TitleOfDepartment", wh.ImpDepartment));

                wh.Department = department;

            }

            // Imp Position

            if (!String.IsNullOrEmpty(wh.ImpPosition))
            {


                IPosition position = obspace.FindObject<IPosition>(new BinaryOperator("TitleOfPosition", wh.ImpPosition));

                wh.Position = position;


            }


            // Imp ID Number


            if (!String.IsNullOrEmpty(wh.ImpIDNumber))
            {


                IEmployee employee = obspace.FindObject<IEmployee>(new BinaryOperator("IDNumber", wh.ImpIDNumber));

                wh.Employee = employee;


            }



        }


        public static void AfterConstruction(IWorkHistory workhistory)
        {

            workhistory.StartDateOnThisPosition = DateTime.Now;


        }


    }


    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IWorkHistory));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IWorkHistory))]
    //public class IWorkHistoryLogic {
    //    public static string Get_CalculatedProperty(IWorkHistory instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IWorkHistory instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IWorkHistory instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IWorkHistory instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
