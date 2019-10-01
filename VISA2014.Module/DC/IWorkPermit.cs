using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using VISA2014.Module.BusinessObjects;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.ComponentModel;
using DevExpress.ExpressApp.Editors;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System.Linq;

namespace VISA2014.Module.DC
{


    public enum WorkPermitStateEnum
    {
        VALID,
        EXPIRED,
        CANCELLED,
        Cancelled,
      //  NONE_0,
      //  NONE_5,
      //  NONE_4,
     //   NONE_2,
      //  NONE_1,
      //  NONE_3,
        UNKNOWN,
        VE_OFFICE,
        VC_OFFICE,
        TO_MINISTERY,
        FROM_MINISTERY,
       // ON_PROCESS,
        VE_ONPROCESS,
        VC_ONPROCESS,
        VE_REJECTED,
        AP_ONPROCESS,
        AP_COMPLETE,
        AP_OFFICE,
       // VisaExtendedWorkPermitNot,
        Extended,
        NO_WORKPERMIT

    }




    [DomainComponent, ImageName("BO_UnKnown")]
    [VisibleInReports]

   
    #region  Work Permit State Appearence


    [Appearance("CANCELLED", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='CANCELLED'", BackColor = "LightGray", FontColor = "Gray")]
   
    [Appearance("VALID", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
     Criteria = "WorkPermitState ='VALID'", BackColor = "LightGreen", FontColor = "Black")]
    
    [Appearance("EXPIRED", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
   Criteria = "WorkPermitState ='EXPIRED'", BackColor = "Brown", FontColor = "White")]


    [Appearance("VE_OFFICE", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
    Criteria = "WorkPermitState ='VE_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]
    [Appearance("VC_OFFICE", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
 Criteria = "WorkPermitState ='VC_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("TO_MINISTERY", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='TO_MINISTERY'", BackColor = "Turquoise", FontColor = "Black")]

    [Appearance("FROM_MINISTERY", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='FROM_MINISTERY'", BackColor = "RoyalBlue", FontColor = "Black")]

    [Appearance("VE_ONPROCESS", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]


    [Appearance("VC_ONPROCESS", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VC_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("VE_REJECTED", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='VE_REJECTED'", BackColor = "Red", FontColor = "White")]

    [Appearance("AP_ONPROCESS", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_ONPROCESS'", BackColor = "Gold", FontColor = "Black")]

    [Appearance("AP_COMPLETE", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_COMPLETE'", BackColor = "MediumSeaGreen", FontColor = "White")]

    [Appearance("AP_OFFICE", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='AP_OFFICE'", BackColor = "NavajoWhite", FontColor = "Black")]

    [Appearance("Extended", AppearanceItemType = "ViewItem", TargetItems = "WorkPermitState", Context = "ListView",
Criteria = "WorkPermitState ='Extended'", BackColor = "MediumSeaGreen", FontColor = "White")]
    #endregion


    // WorkPermit AS Number And Application Process Number Does not match
    
    [Appearance("ASNummber mismatch", AppearanceItemType = "ViewItem", TargetItems = "ProcessNumber", Context = "DetailView",
    Criteria = "Not IsNullOrEmpty(ASNumber) And WorkPermitLetter.Date Is Not Null And  ASNumber != ProcessNumber.Application.ProcessNumber And Employee Is Not Null And ProcessNumber Is Not Null", BackColor = "Crimson", FontColor = "White")]
    

   [RuleCriteria("WorPermitExpireDate", DefaultContexts.Save, "ExpiringDateOfWorkPermit > StartDateOfWorkPermit ",
"ExpiringDateOfWorkPermit can be only greater  than StartDateOfWorkPermit", SkipNullOrEmptyValues = false)]

   [XafDefaultProperty("AppruvalNumber")]
    public interface IWorkPermit : IRemainingDays
    {
       [RuleRequiredField,ImmediatePostData]
       [DataSourceCriteria("IsEmployee")]
       IPersonn Employee { get; set; }
     
        [RuleRequiredField]
       [DataSourceProperty("Person.Passports")]
       IPassport Passport { get; set; }
      
        [RuleRequiredField]
       [DataSourceProperty("Person.WorkHistories")]
       IWorkHistory Position { get; set; }
     
        [RuleRequiredField]
       DateTime StartDateOfWorkPermit { get; set; }
     
        [RuleRequiredField,ImmediatePostData]
       DateTime ExpiringDateOfWorkPermit { get; set; }
     //  [RuleRequiredField]
     
        [DataSourceCriteria("AşgabatŞäheri =false And TejenŞäheri = false And  BalkanabatŞäheri = false And  DaşoguzŞäheri = false And  TürkmenabatŞäheri = false And  MaryŞäheri =false")]
       IWorkPermitLocation WorkPermitLocation { get; set; }
      
        IWorkPermitLetter WorkPermitLetter { get; set; }
       IşlemägeRugsatEdilenYer IşlemägeRugsatEdilenYer { get; set; }

      
       #region Appearenc


        [Appearance("ASNumberDisabled", Enabled = false)]
       #endregion 
       
       IPersonInApplication ProcessNumber { get; set; }
        [VisibleInListView(false)]
      
       IPersonInApplication PersonInApplication { get;  }
          [RuleRequiredField]
        string ASNumber { get; set; }

       [RuleRequiredField]
       string AppruvalNumber { get; set; }
       [VisibleInListView(false),VisibleInDetailView(false),VisibleInLookupListView(false)]
       string ASNumberForLine { get; }

       WorkPermitStateEnum WorkPermitState { get; }

       [Browsable (false)]
       AppConf AppConf {get;set;}

          [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
      [BackReferenceProperty("WorkPermit")]
       IList<IPersonInApplication> PersonInApplications { get; }

         IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> ChangeHistory { get; }
    }


    [DomainLogic(typeof(IWorkPermit))]
    public class WorkPermitLogic
    {
        public static IList<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> Get_ChangeHistory(IWorkPermit workpermit, IObjectSpace os)
        {



            return DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(((XPObjectSpace)os).Session, workpermit);

        }

        /*
        public static void OnSaving(IWorkPermit wp, IObjectSpace obspace)
        {

            // Imp wp letter




            IWorkPermitLetter wpLetter = obspace.FindObject<IWorkPermitLetter>(new BinaryOperator("Number", wp.ImpLetter));
            if (wpLetter == null)
            {

                wpLetter = obspace.CreateObject<IWorkPermitLetter>();
                wpLetter.Date = wp.ImpWpIssuedDate;


            }


            if (wpLetter != null)
            {
                wp.WorkPermitLetter = wpLetter;
            }

            // Imp Passport
            if (!String.IsNullOrEmpty(wp.ImpPassport))
            {


                IPassport pasport = obspace.FindObject<IPassport>(new BinaryOperator("PassportNumber", wp.ImpPassport));

                wp.Passport = pasport;

            }

            // Imp Position

            if (!String.IsNullOrEmpty(wp.ImpPosition))
            {


                IWorkHistory position = obspace.FindObject<IWorkHistory>(new BinaryOperator("Position", wp.ImpPosition));

                wp.Position = position;


            }


            // Imp ID Number


            if (!String.IsNullOrEmpty(wp.ImpIDNumber))
            {


                IEmployee employee = obspace.FindObject<IEmployee>(new BinaryOperator("IDNumber", wp.ImpIDNumber));

                wp.Employee = employee;


            }

           




        }
        */
    
        public static IPersonInApplication Get_AppForWorkPermitCancelling(IWorkPermit workPermit)
        {

            if (workPermit.Employee != null && workPermit.Employee.EmployeeInApplications.Count > 0)
            {
                IPersonInApplication temp = null;
                foreach (var empInApp in workPermit.Employee.EmployeeInApplications)
                {

                    if (empInApp.Application.ForEmployee && empInApp.Application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForCancellingVisaAndWorkpermit && empInApp.WorkPermit == workPermit)
                    {

                        temp = empInApp;

                    }


                }

                return temp;

            }
            else return null;



        }


        public int Get_RemainingDays(IWorkPermit wp)
        {

            {
                return Helper.GetRemainingDaysBeforeExpire(wp.ExpiringDateOfWorkPermit);
            }

        }

        public static void AfterChange_Employee(IWorkPermit wp)
        {

            wp.Passport = Helper.GetLastPassport(wp.Employee);
            wp.Position = Helper.GetLastPosition(wp.Employee);

            if (wp.WorkPermitLetter != null && wp.WorkPermitLetter.Date != null)
            {
                wp.ProcessNumber = Helper.Get_ApplicationFoWorkPermit(wp.Employee, wp.WorkPermitLetter.Date);

            }
        }

        public static string Get_ASNumberForLine(IWorkPermit wp)
        {


            return wp.ASNumber;



        }

        public static void AfterConstruction(IWorkPermit workPermit, IObjectSpace obspace)
        {

            var appConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));
            if (appConf != null)
            {

                workPermit.AppConf = obspace.FindObject<AppConf>(new BinaryOperator("ID", 1));

            }


        }

        public static IPersonInApplication Get_PersonInApplication(IWorkPermit workpermit)
        {

            if (workpermit.Employee != null && workpermit.Employee.EmployeeInApplications.Count > 0)
            {
                IPersonInApplication appForWP = null;

                foreach (var personInApp in workpermit.Employee.EmployeeInApplications)
                {


                    SubType st = personInApp.ApplicationType;

                    switch (st)
                    {
                        case SubType.ApplicationForVisaExtention:

                            if (personInApp.WorkPermit == workpermit)
                            {
                                appForWP = personInApp;
                            }
                            break;

                        case SubType.ApplicationForCancellingVisaAndWorkpermit:

                            if (personInApp.WorkPermit == workpermit)
                            {
                                appForWP = personInApp;
                            }
                            break;
                    }



                }
                return appForWP;






            }
            else return null;


        }


        public static WorkPermitStateEnum Get_WorkPermitState(IWorkPermit workPermit, IObjectSpace os)
        {

            try
            {
                if (workPermit.PersonInApplications.Count==0 && workPermit.RemainingDays <= 0)
                {

                    return WorkPermitStateEnum.EXPIRED;
                }

                if (workPermit.Employee.LastWorkPermit != workPermit && workPermit.RemainingDays >= 1) {

                    return WorkPermitStateEnum.Extended;
                }

                if (workPermit.PersonInApplications.Count==0 && workPermit.RemainingDays >=1)
                {
                    return WorkPermitStateEnum.VALID;
                }
             
            

          

                if (workPermit.PersonInApplications != null && workPermit.PersonInApplications.Count == 1 ) {
                    
                    IPersonInApplication personInApp = workPermit.PersonInApplications.First();


                    return WorkPermitStateHelper.GetWorkPermitState(personInApp, workPermit, WorkPermitStateEnum.UNKNOWN);

             
                    
                
                }
              
                if (workPermit.PersonInApplications != null && workPermit.PersonInApplications.Count >= 2)
                {
                    IList<IPersonInApplication> personInApps = workPermit.PersonInApplications.Where(c=> !c.Cancelled ).Where(g=> !g.Application.Cancelled).Where(t=> t.Application.SubType == SubType.ApplicationForCancellingVisaAndWorkpermit
                        || t.Application.SubType == SubType.ApplicationForCancellingWorkPermit
                        || t.Application.SubType == SubType.ApplicationForCancellingWorkPermitAndInvitation
                        || t.Application.SubType == SubType.ApplicationForExtendingWorkPermitLocation
                        || t.Application.SubType == SubType.ApplicationForVisaExtention
                      
                        ).OrderBy(b=> b.Cancelled ).OrderByDescending(t => t.Application.ManualApplicationDate).ToList(); 
                   
                    if (personInApps.Count > 0) {
                        IPersonInApplication pInApp = personInApps.First();

                        return WorkPermitStateHelper.GetWorkPermitState(pInApp, workPermit, WorkPermitStateEnum.UNKNOWN);
                    
                    }

                    if ( workPermit.RemainingDays <= 0)
                    {

                        return WorkPermitStateEnum.EXPIRED;
                    }

                    if ( workPermit.RemainingDays >= 1)
                    {
                        return WorkPermitStateEnum.VALID;
                    }
                  //  return WorkPermitStateEnum.NONE_0;
                }

                return WorkPermitStateEnum.UNKNOWN;
           

            }
            catch (Exception)
            {

                return WorkPermitStateEnum.UNKNOWN;
            }


 
            
        }
    }


    [NavigationItem(true, GroupName = "Configuration")]
    [DomainComponent, ImageName("BO_UnKnown")]
    [XafDefaultProperty("NameOfLocation")]
   public interface ILocationPermittedToWork
   {
       [RuleRequiredField]
       string NameOfLocation { get; set; }
   
   }
    [VisibleInReports(true)]
    [DomainComponent, ImageName("BO_UnKnown")]
    [XafDefaultProperty("Number")]
    public interface IWorkPermitLetter
    {
        [RuleRequiredField]
        string Number { get; set; }
        [RuleRequiredField]
        DateTime Date { get; set; }
      
        [RuleRequiredField]
        [Aggregated]

        [Appearance("WorkPermits", Visibility = ViewItemVisibility.Hide, Criteria = "IsNullOrEmpty(Number) Or Date Is Null")]
        IList<IWorkPermit> WorkPermits { get; }
        [DevExpress.Xpo.Aggregated]
        IList<ICopy> WorkPermitCopy { get; }
      //  [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        ICompany Company { get; set; }
        [VisibleInListView(false),VisibleInDetailView(false),VisibleInLookupListView(false)]
        string MaglumatSene { get; }
        [Browsable(false)]
        int CountWP { get; }

        [DevExpress.Xpo.Aggregated]
        IList<IPassportCopy> IşRugsatnamaGocurme { get; }

    }
    [DomainLogic(typeof(IWorkPermitLetter))]
    public class WorkPermitLetterLogic {

        public static int Get_CountWP(IWorkPermitLetter wpl)

        {
            if (wpl.WorkPermits.Count > 0)
            {
                return Helper.CountForeignEmpInWP(wpl);
            }
            else return 0;
        
        }

        public static void AfterConstruction(IWorkPermitLetter wpLetter, IObjectSpace obspace)
        {

            var company = obspace.FindObject<ICompany>(new BinaryOperator("CompanyId", 1));
            if (company != null)
            {

                wpLetter.Company = obspace.FindObject<ICompany>(new BinaryOperator("CompanyId", 1));

            }

        }


        public static string Get_MaglumatSene(IWorkPermitLetter wpLetter)

        {
            return DateTime.Now.ToString("dd.MM.yyyy");
        
        
        }

    
    
    }



}
