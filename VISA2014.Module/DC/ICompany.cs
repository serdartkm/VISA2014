using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{

    #region Appearence For Fill
    [Appearance("TitleOfCompany", AppearanceItemType = "ViewItem", TargetItems = "TitleOfCompany", Context = "ListView, DetailView",
      Criteria = "TitleOfCompany='Fill Company name' Or IsNullOrEmpty(TitleOfCompany) ", BackColor = "Gold", FontColor = "Black")]

    [Appearance("AddressOfCompany", AppearanceItemType = "ViewItem", TargetItems = "AddressOfCompany", Context = "ListView, DetailView",
  Criteria = "AddressOfCompany='Fill Full Address Of Company' Or IsNullOrEmpty(AddressOfCompany) ", BackColor = "Gold", FontColor = "Black")]



    [Appearance("PhoneOfNumber", AppearanceItemType = "ViewItem", TargetItems = "PhoneOfNumber", Context = "ListView, DetailView",
  Criteria = "PhoneOfNumber='Fill Office Number' Or IsNullOrEmpty(PhoneOfNumber) ", BackColor = "Gold", FontColor = "Black")]

    [Appearance("TaxRegistrationNumber", AppearanceItemType = "ViewItem", TargetItems = "TaxRegistrationNumber", Context = "ListView, DetailView",
  Criteria = "TaxRegistrationNumber='FillTax Registration Number' Or IsNullOrEmpty(TaxRegistrationNumber) ", BackColor = "Gold", FontColor = "Black")]

    [Appearance("NumberOfLocalEmployee", AppearanceItemType = "ViewItem", TargetItems = "NumberOfLocalEmployee", Context = "ListView, DetailView",
 Criteria = "NumberOfLocalEmployee=0 Or IsNullOrEmpty(NumberOfLocalEmployee) ", BackColor = "Gold", FontColor = "Black")]

    #endregion

   
    [DomainComponent,  ImageName("BO_Unknown")]
    [XafDefaultProperty("TitleOfCompany")]
    [VisibleInReports(true)]
    public interface ICompany
    {



        #region Company


        [RuleRequiredField]
        string TitleOfCompany { get; set; }
        [RuleRequiredField]
        string AddressOfCompany { get; set; }
        [RuleRequiredField]
        string PhoneOfNumber { get; set; }
        [RuleRequiredField,Browsable(false)]
        int CompanyId { get; set;}
        int SC { get; set; }
        [RuleRequiredField]
        string TaxRegistrationNumber { get; set; }
        [Delayed(true)]
        [Size(-1)]
        [ValueConverter(typeof(ImageValueConverter))]
        [RuleRequiredField]
        Image logo { get; set; }
        [RuleRequiredField]
        int NumberOfLocalEmployee { get; set; }
        [Browsable(false)]
        IList<IWorkPermitLetter> WorkPermitLetter { get; }
        int NumberOfForeignEmployees { get; }

        double LocalEmployeePercentage { get; }

        double ForeignEmployeePercentage { get; }

        int ContractStartPeriod { get; set; }

        int ContractEndPeriod { get;set; }

       // IList<IPersonn> Person { get; }


        #endregion


        #region Signing person
         [DataSourceCriteria("IsEmployee")]
        IPersonn DocSigningPerson { get; set; }
        #endregion


        #region Representative
        [RuleRequiredField]
        ICompanyRepresentative CurrentReprezentative { get; set; }
        [Browsable(false)]
        [DevExpress.Xpo.Aggregated]
        IList<ICompanyRepresentative> CompanyRepresentative { get; }

        #endregion



        string Email { get; set; }


  
  }
    [DomainLogic(typeof(ICompany))]
    public class CompanyLogic {


        public static int Get_NumberOfForeignEmployees(ICompany company)

        {
            if (company.WorkPermitLetter.Count > 0)
            {

                return Helper.CountForeignEmpInWPLetter(company);




            }

            else return 0;
        
        
        
        }


        public static double Get_LocalEmployeePercentage(ICompany company)
        {


            if (company.NumberOfForeignEmployees > 0 && company.NumberOfLocalEmployee > 0)
            
            {
                return 100 * company.NumberOfLocalEmployee / (company.NumberOfLocalEmployee + company.NumberOfForeignEmployees);
            
            }
            else return 0;
        }


        public static double Get_ForeignEmployeePercentage(ICompany company)
        {

            if (company.NumberOfForeignEmployees > 0 && company.NumberOfLocalEmployee > 0)
            {
                return 100 * company.NumberOfForeignEmployees / (company.NumberOfLocalEmployee + company.NumberOfForeignEmployees);
            }
            else return 0;
        }

    
    }

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(ICompany));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(ICompany))]
    //public class ICompanyLogic {
    //    public static string Get_CalculatedProperty(ICompany instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(ICompany instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(ICompany instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(ICompany instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
