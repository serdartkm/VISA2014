using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace VISA2014.Module.DC
{

   
       
       [DomainComponent]

    public interface IPluralForeignCitizen

    {
           // TKM single 
           string DYR_ДП_tkm {get;set;}
           string DYR_ВП_tkm {get;set;}
           string DYR_РП_tkm { get; set; }

           // TKM plural 
           string DYR_ДП_PL_tkm {get;set;}
           string DYR_ВП_PL_tkm {get;set;}
           string DYR_РП_РL_tkm { get; set; }
           // RUS single
           string DYR_ДП_rus {get;set;}
           string DYR_ВП_rus {get;set;}
           string DYR_РП_rus { get; set; }
           // RUS plural
           string DYR_ДП_PL_rus {get;set;}
           string DYR_ВП_PL_rus {get;set;}
           string DYR_РП_PL_rus { get; set; }
 

    }

      
       [DomainComponent]

    public interface IPluralFamilyMember

    {
           // TKM single
           string FM_ДП_tkm {get;set;}
           string FM_ВП_tkm {get;set;}

           // TKM plural
           string FM_ДП_PL_tkm {get;set;}
           string FM_ВП_PL_tkm {get;set;}

           // RUS single
           string FM_ДП_rus {get;set;}
           string FM_ВП_rus {get;set;}

           // RUS plural
           string FM_ДП_PL_rus {get;set;}
           string FM_ВП_PL_rus {get;set;}


    }


       [DomainComponent]
       public interface IPluralWiza
       {
           // TKM single       
           string Wiza_ВП_tkm { get; set; }

           // TKM plural
           string Wiza_ВП_PL_tkm { get; set; }

           // RUS single
           string Wiza_ВП_rus { get; set; }

           // RUS plural
           string Wiza_ВП_PL_rus { get; set; }

           string Wiza_РП_tkm { get; set; }
           string Wiza_РП_PL_tkm { get; set; }
           string Wiza_РП_rus { get; set; }
           string Wiza_РП_PL_rus { get; set; }
       }




       [DomainComponent]
       public interface IPluralWizaAndWorkPermit
       {
           // TKM single

           string WizaAndWorkPermit_ВП_tkm { get; set; }

           // TKM plural

           string WizaAndWorkPermit_ВП_PL_tkm { get; set; }

           // RUS single

           string WizaAndWorkPermit_ВП_rus { get; set; }

           // RUS plural

           string WizaAndWorkPermit_ВП_PL_rus { get; set; }


       }

       [DomainComponent]
       public interface IPluralInvitation
       {
           // TKM single

           string Invitation_ВП_tkm { get; set; }

           // TKM plural

           string Invitation_ВП_PL_tkm { get; set; }

           // RUS single

           string Invitation_ВП_rus { get; set; }

           // RUS plural

           string Invitation_ВП_PL_rus { get; set; }


       }


       [DomainComponent]
       public interface IPluralInvitationAndWorkPermit
       {
           // TKM single

           string InvitationAndWorkPermit_ВП_tkm { get; set; }

           // TKM plural

           string InvitationAndWorkPermit_ВП_PL_tkm { get; set; }

           // RUS single

           string InvitationAndWorkPermit_ВП_PL_rus { get; set; }

           // RUS plural

           string InvitationAndWorkPermit_ВП_rus { get; set; } 


       }



       [DomainComponent]

       public interface IPluralBorderZone
       {
           // TKM single

           string BorderZone_ВП_tkm { get; set; }

           // TKM plural

           string BorderZone_ВП_PL_tkm { get; set; }

           // RUS single

           string BorderZone_ВП_PL_rus { get; set; }

           // RUS plural

           string BorderZone_ВП_rus { get; set; }


       }


       [DomainComponent]

       public interface IPluralRugsat
       {
           // TKM single
           /// <summary>
           /// rugsat berilmegini
           /// </summary>
           string RugsatBermek_bir_tkm { get; set; }
           string RugsatBermek_bir_rus { get; set; }
           // TKM plural
           /// <summary>
           /// rugsat berilmegine ýardam etmegiňizi
           /// </summary>
           string RugsatBermek_iki_tkm { get; set; }
           string RugsatBermek_iki_rus { get; set; }
       


       }


   

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IPlurals));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IPlurals))]
    //public class IPluralsLogic {
    //    public static string Get_CalculatedProperty(IPlurals instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IPlurals instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IPlurals instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IPlurals instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
