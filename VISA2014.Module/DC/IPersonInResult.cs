using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{


    public enum InvitStateEnum
    {
        INV_EXPIRED,
        INV_VALID,
        INV_CANCELLED,
        INV_CAN_OFFICE,
        INV_CAN_ONPROCESS,
        INV_CHANGED,
        INV_CHANGE_OFFICE,
        INV_CHANGE_ONPROCESS,
        INV_NONE,
        INV_USED,
        INV_REJECTED

    }

    #region Rule required field

    // Invitation State 
    #region Invitation State
    [Appearance("InvitatValid", AppearanceItemType = "ViewItem", TargetItems = "InvitationState", Context = "ListView",
    Criteria = "InvitationState= 'INV_VALID'", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("InvitationExpired", AppearanceItemType = "ViewItem", TargetItems = "InvitationState", Context = "ListView",
     Criteria = "InvitationState= 'INV_EXPIRED'", BackColor = "Salmon", FontColor = "Black")]

    [Appearance("InvitationUsed", AppearanceItemType = "ViewItem", TargetItems = "InvitationState", Context = "ListView",
     Criteria = "InvitationState= 'INV_USED'", BackColor = "YellowGreen", FontColor = "Black")]

    // InvitationRejected
    [Appearance("InvitationRejected", AppearanceItemType = "ViewItem", TargetItems = "InvitationState", Context = "ListView",
       Criteria = "InvitationState = 'INV_REJECTED'", BackColor = "Crimson", FontColor = "White")]
    #endregion

    [RuleCriteria("Family Member In Result", DefaultContexts.Save, "(FamilyMemberVisibility =false And FamilyMember Is Null) Or (FamilyMemberVisibility =true And FamilyMember Is Not Null) ",
"Maºgala agzany saýlamaly", SkipNullOrEmptyValues = false)]

    [RuleCriteria("Employee In Result", DefaultContexts.Save, "(FamilyMemberVisibility =false And Employee Is Not Null) Or (FamilyMemberVisibility =true And Employee Is Null) ",
"Iºgäri saýlamaly", SkipNullOrEmptyValues = false)]


   // [RuleCriteria("PersonIsValid", DefaultContexts.Save, "PersonIsValid =true","Bu raýat çakylyk üçin ýüztutmada ýok", SkipNullOrEmptyValues = false)]


    [RuleCombinationOfPropertiesIsUnique("UniqueCivil", DefaultContexts.Save, "AppliedCivil, Invitation ", MessageTemplateCombinationOfPropertiesMustBeUnique = "Bu raýat çakylyga goºulan.")]

    #endregion

    [VisibleInReports]
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("Person")]
    public interface IPersonInResult
    {

        #region Appearence


        [Appearance("EmployeeVisibilityInResult", Visibility = ViewItemVisibility.Hide, Criteria = "FamilyMemberVisibility=true")]

        #endregion

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [DataSourceCriteria("IsFamilyMember = false")]
        [ImmediatePostData]

        IPersonn Employee { get; set; }

        #region Appearence

        [Browsable(false), ImmediatePostData]
        bool FamilyMemberVisibility { get; }
        [Appearance("FamilyMember1", Visibility = ViewItemVisibility.Hide, Criteria = "FamilyMemberVisibility=false")]

        #endregion

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [DataSourceCriteria("IsFamilyMember = true")]
        [ImmediatePostData]
        IPersonn FamilyMember { get; set; }
        [RuleRequiredField]
        [DataSourceProperty("PersonType.Passports")]
        IPassport Passport { get; set; }
        IApplicationResult Invitation { get; set; }

        [Appearance("ExpectedDateOfArrival", Visibility = ViewItemVisibility.Hide, Criteria = "Invitation.Result='Rejection'")]
        DateTime ExpectedDateOfArrival { get; set; }
        [VisibleInDetailView(false)]
        IPersonn AppliedCivil { get; }

        [Browsable(false)]

        IPersonn PersonType { get; }
        [Browsable(false)]
        bool PersonIsValid { get; }
        IVisa IssuedVisa { get; }
        InvitStateEnum InvitationState { get; }
    }
    [DomainLogic(typeof(IPersonInResult))]
    public class PersonInInvitationLogic
    {

        public static  IVisa Get_IssuedVisa(IPersonInResult person){
        IVisa issuedVisa =null;
        foreach (var p in person.AppliedCivil.Passports)
	    {
		    foreach (var v in p.Visas)
	        {
		        if(v.ASNumber == person.Invitation.ASBelgisi){
                    
                     issuedVisa=v;
                    break;
                }
	        }
    	}
            return issuedVisa;
        }

        public static InvitStateEnum Get_InvitationState(IPersonInResult personInResult)
        {

            if (personInResult.Invitation.Result == ApplicationResultEnum.Rejection)
            {

                return InvitStateEnum.INV_REJECTED;
            }
         
          
             
       
               
                foreach (var item in personInResult.AppliedCivil.LastPassport.Visas)
                {
                    if (item.ASNumber == personInResult.Invitation.ASBelgisi) {
                       
                        return InvitStateEnum.INV_USED;

                    }
                }
              

               // return InvitStateEnum.INV_USED;
        
            if (personInResult.Invitation.InvitationRemaningDays <= 0)
            {

                return InvitStateEnum.INV_EXPIRED;
            }
            if (personInResult.Invitation.InvitationRemaningDays >= 1)
            {

                return InvitStateEnum.INV_VALID;
            }
            return InvitStateEnum.INV_NONE;

        }

        public static bool Get_PersonIsValid(IPersonInResult personIResult)
        {


            return Helper.GetPersonIsValid(personIResult.PersonType, personIResult);

        }

        public static IPersonn Get_PersonType(IPersonInResult personInResult)
        {
            if (personInResult.Invitation.Application.ForEmployee)
            {
                return personInResult.Employee;

            }
            else return personInResult.FamilyMember;


        }

        public static bool Get_FamilyMemberVisibility(IPersonInResult personInResult)
        {


            if (personInResult.Invitation.Application.ForEmployee)
            {

                return false;
            }

            else return true;


        }

        public static void AfterChange_Employee(IPersonInResult personInInvit)
        {

            personInInvit.Passport = Helper.GetLastPassport(personInInvit.AppliedCivil);

        }

        public static void AfterChange_FamilyMember(IPersonInResult personInInvit)
        {

            personInInvit.Passport = Helper.GetLastPassport(personInInvit.AppliedCivil);

        }

        public static IPersonn Get_AppliedCivil(IPersonInResult person)
        {

            if (person.Invitation.Application != null && person.Invitation.Application.ForEmployee)
            {

                return person.Employee;

            }

            else if (person.Invitation.Application != null && person.Invitation.Application.ForFamilyMember)
            {

                return person.FamilyMember;

            }

            else return null;


        }



    }



    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IPersonInInvitation));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IPersonInInvitation))]
    //public class IPersonInInvitationLogic {
    //    public static string Get_CalculatedProperty(IPersonInInvitation instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IPersonInInvitation instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IPersonInInvitation instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IPersonInInvitation instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
