using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Linq;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using VISA2014.Module.BusinessObjects;
namespace VISA2014.Module.DC
{
      [DomainComponent, ImageName("BO_Unknown")]
      [XafDefaultProperty("Number")]

    #region RuleRequiredFiel


      [RuleCriteria("ResultNumber", DefaultContexts.Save, "Number Is Not Null", "Number should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("IssuedDate", DefaultContexts.Save, "IssuedDate Is Not Null", "Issued date should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("DateOfExpire", DefaultContexts.Save, "(DateOfExpire Is Not Null And Result ='Invitation') Or (DateOfExpire Is Null And Result ='Rejection') ", "Date of expire should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("VisaCategory", DefaultContexts.Save, "(VisaCategory Is Not Null And  Result ='Invitation') Or (VisaCategory Is Null And  Result ='Rejection') ", "Visa category should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("VisaPeriod", DefaultContexts.Save, "(VisaPeriod Is Not Null And  Result ='Invitation') Or (VisaPeriod Is Null And  Result ='Rejection')", "Visa period should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("VisaStartDate", DefaultContexts.Save, "(VisaStartDate Is Not Null And  Result ='Invitation' And VisaStartAndEnDateDefined = true ) Or (VisaStartDate Is Null And  Result ='Invitation' And VisaStartAndEnDateDefined = false ) Or (VisaStartDate Is Null And  Result ='Rejection' )", "Visa start date should not be empty", SkipNullOrEmptyValues = false)]
      [RuleCriteria("VisaEndDate", DefaultContexts.Save, "(VisaEndDate Is Not Null And  Result ='Invitation' And VisaStartAndEnDateDefined = true) Or (VisaEndDate Is Null And  Result ='Invitation' And VisaStartAndEnDateDefined = false) Or (VisaEndDate Is Null And  Result ='Rejection')", "Visa end date should not be empty", SkipNullOrEmptyValues = false)]

    #endregion

    public interface IApplicationResult
    {
           IApplication Application { get; set; }
          [ImmediatePostData]
          
         // [Appearance("VisaExtResult", Enabled = false, Criteria = "Application.SubType='ApplicationForVisaExtention'")]
        //  [Appearance("VisaExtResult2", Enabled = false, Criteria = "Application.SubType='ApplicationForChangingInvitation'")]
           ApplicationResultEnum Result { get; set; }
         
           string Number { get; set; }
           string ASBelgisi { get; set; }
          
           DateTime IssuedDate { get; set; }

           string IssuedDateShort { get; }
           
           [Appearance("DateOfExpire", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           DateTime DateOfExpire { get; set; }

           
           [Appearance("VisaCategory", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           IVisaCategory VisaCategory { get; set; }

           


           [Appearance("VisaPeriod", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           IVisaPeriod VisaPeriod { get; set; }

           [Appearance("VisaStartAndAenDateDefined", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           [VisibleInListView(false),VisibleInLookupListView(false)]
           [ImmediatePostData]
           bool VisaStartAndEnDateDefined { get; set; }

           [Appearance("VisaStartDate", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           [Appearance("VisaStartDate1", Visibility = ViewItemVisibility.Hide, Criteria = "VisaStartAndEnDateDefined =false")]
           DateTime? VisaStartDate { get; set; }

           
           [Appearance("VisaEndDate", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           [Appearance("VisaEndDate1", Visibility = ViewItemVisibility.Hide, Criteria = "VisaStartAndEnDateDefined =false")]
           DateTime? VisaEndDate { get; set; }
           [Aggregated]
           IList<ICopy> CopyOfResult { get;}
           [DevExpress.Xpo.Aggregated]
           
           IList<IPersonInResult> PersonInResultLetter { get; }
           [Appearance("InvitationRemaningDays", Visibility = ViewItemVisibility.Hide, Criteria = "Result='Rejection'")]
           int InvitationRemaningDays { get; }

           [DevExpress.Xpo.Aggregated]
           IList<IPassportCopy> NetijeGocurme { get; }

    }
      [DomainLogic(typeof(IApplicationResult))]
      public class ApplicationResultLogic
      {

          public static  int Get_InvitationRemaningDays(IApplicationResult appResult)

          {
             
                return Helper.GetRemainingDaysBeforeExpire(appResult.DateOfExpire);
              
              
          
          
          }


          public static void AfterChange_Result(IApplicationResult appResult)

          {



              appResult.Number = null;
              appResult.VisaCategory = null;
              appResult.VisaEndDate = null;
              appResult.VisaStartDate = null;
              appResult.VisaPeriod = null;

           
          
          }

          public static string Get_IssuedDateShort(IApplicationResult appResult)

          {
              return appResult.IssuedDate.ToString("dd.MM.yyyy");
          }

          public static void AfterConstruction(IApplicationResult appResult)


          {
              if (appResult.Application != null)
              {
                  if (appResult.Application.SubType == SubType.ApplicationForChangingInvitation || appResult.Application.SubType == SubType.ApplicationForInvitation)
                  {
                      appResult.Result = ApplicationResultEnum.Invitation;


                  }
                  else appResult.Result = ApplicationResultEnum.Rejection;
              }
            
          
          }
      
      }

      public enum ApplicationResultEnum
      { 
      
          Invitation,
          Rejection
      
      
      }
    





    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(Invitation));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(Invitation))]
    //public class InvitationLogic {
    //    public static string Get_CalculatedProperty(Invitation instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(Invitation instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(Invitation instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(Invitation instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
