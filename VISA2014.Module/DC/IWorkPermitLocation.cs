﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using VISA2014.Module.BusinessObjects;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace VISA2014.Module.DC
{
    [DomainComponent]
    [XafDefaultProperty("WorkPermitLocationCollection")]


    #region Appearence

    [Appearance("AşgabatŞäheri", AppearanceItemType = "ViewItem", TargetItems = "AşgabatŞäheri", Context = "DetailView",
Criteria = "AşgabatŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("TejenŞäheri", AppearanceItemType = "ViewItem", TargetItems = "TejenŞäheri", Context = "DetailView",
Criteria = "TejenŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("BalkanabatŞäheri", AppearanceItemType = "ViewItem", TargetItems = "BalkanabatŞäheri", Context = "DetailView",
Criteria = "BalkanabatŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("DaşoguzŞäheri", AppearanceItemType = "ViewItem", TargetItems = "DaşoguzŞäheri", Context = "DetailView",
Criteria = "DaşoguzŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]

    [Appearance("MaryŞäheri", AppearanceItemType = "ViewItem", TargetItems = "MaryŞäheri", Context = "DetailView",
Criteria = "MaryŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]


    [Appearance("TürkmenabatŞäheri", AppearanceItemType = "ViewItem", TargetItems = "TürkmenabatŞäheri", Context = "DetailView",
Criteria = "TürkmenabatŞäheri = true", BackColor = "SpringGreen", FontColor = "Black")]

    #endregion
    public interface IWorkPermitLocation
    {
        [ImmediatePostData]
        bool AşgabatŞäheri { get; set; }
        [ImmediatePostData]
        bool TejenŞäheri { get; set; }
        [ImmediatePostData]
        bool BalkanabatŞäheri { get; set; }
        [ImmediatePostData]
        bool DaşoguzŞäheri { get; set; }
        [ImmediatePostData]
        bool TürkmenabatŞäheri { get; set; }
        [ImmediatePostData]
        bool MaryŞäheri { get; set; }


         [ImmediatePostData]
bool BaharlyEtraby { get; set; }
         [ImmediatePostData]
bool GökdepeEtraby { get; set; }
         [ImmediatePostData]
bool RuhabatEtraby { get; set; }
         [ImmediatePostData]
bool AkbugdaýEtraby { get; set; }
         [ImmediatePostData]
bool ÄnewŞäheri { get; set; }
         [ImmediatePostData]
bool KakaEtraby { get; set; }
         [ImmediatePostData]
bool TejenEtraby { get; set; }


         [ImmediatePostData]
bool AltynAsyrEtraby { get; set; }
         [ImmediatePostData]
bool BabadaýhanEtraby { get; set; }
         [ImmediatePostData]
bool SarahsEtraby { get; set; }
         [ImmediatePostData]
bool AbadanŞäheri { get; set; }
         [ImmediatePostData]
bool EsengulyEtraby { get; set; }
         [ImmediatePostData]
bool BereketEtraby { get; set; }
         [ImmediatePostData]
bool BereketŞäheri { get; set; }
         [ImmediatePostData]
bool SerdarEtraby { get; set; }
         [ImmediatePostData]
bool MagtymgulyEtraby { get; set; }
         [ImmediatePostData]
bool EtrekEtraby { get; set; }
         [ImmediatePostData]
bool TürkmenbaşyEtraby { get; set; }

         [ImmediatePostData]

bool TürkmenbaşyŞäheri { get; set; }
         [ImmediatePostData]
bool GumdagŞäheri { get; set; }
         [ImmediatePostData]
bool HazarŞäheri { get; set; }
         [ImmediatePostData]
bool GarabogazŞäheri { get; set; }
         [ImmediatePostData]
bool SerdarŞäheri { get; set; }
         [ImmediatePostData]
bool GurbansoltanEjeAdEtraby { get; set; }
         [ImmediatePostData]
bool SaparmyratTürkmenbaşyAdEetraby { get; set; }
         [ImmediatePostData]
bool SANyýazowAdEtraby { get; set; }
         [ImmediatePostData]
bool GöroglyEtraby { get; set; }
         [ImmediatePostData]
bool BoldumsazEtraby { get; set; }
         [ImmediatePostData]
bool KöneürgençEtraby { get; set; }
         [ImmediatePostData]
bool AkdepeEtraby { get; set; }
         [ImmediatePostData]
bool GubadagEtraby { get; set; }
         [ImmediatePostData]
bool RuhubelentEtraby { get; set; }

         [ImmediatePostData]

bool KöneürgençŞäheri { get; set; }
         [ImmediatePostData]
bool BaýramalyŞäheri { get; set; }
         [ImmediatePostData]
bool WekilbazarEtraby { get; set; }
         [ImmediatePostData]
bool ÝolötenEtraby { get; set; }
         [ImmediatePostData]
bool ÝolötenŞäheri { get; set; }
         [ImmediatePostData]
bool GaragumEtraby { get; set; }
         [ImmediatePostData]
bool SerhetabatŞäheri { get; set; }
         [ImmediatePostData]
bool SerhetabatEtraby { get; set; }
         [ImmediatePostData]
bool MaryEtraby { get; set; }
         [ImmediatePostData]
bool MurgapEtraby { get; set; }
         [ImmediatePostData]
bool OguzhanEtraby { get; set; }
         [ImmediatePostData]
bool ŞatlykŞäheri { get; set; }
         [ImmediatePostData]
bool SakarçägeEtraby { get; set; }
         [ImmediatePostData]
bool TagtabazarEtraby { get; set; }
         [ImmediatePostData]
bool TürkmengalaEtraby { get; set; }
         [ImmediatePostData]
bool AltynSähraEtraby { get; set; }
         [ImmediatePostData]


bool BaýramalyEtraby { get; set; }
         [ImmediatePostData]
bool BirataEtraby { get; set; }
         [ImmediatePostData]
bool GazojakŞäheri { get; set; }
         [ImmediatePostData]
bool GaraşsyzlykEtraby { get; set; }
         [ImmediatePostData]
bool GalkynyşEtraby { get; set; }
         [ImmediatePostData]
bool GarabekewülEtraby { get; set; }
         [ImmediatePostData]
bool AtamyratEtraby { get; set; }
         [ImmediatePostData]
bool AtamyratŞäheri { get; set; }
         [ImmediatePostData]
bool SakarEtraby { get; set; }
         [ImmediatePostData]
bool SaýatEtraby { get; set; }
         [ImmediatePostData]
bool HalaçEtraby { get; set; }
         [ImmediatePostData]
bool FarapEtraby { get; set; }
         [ImmediatePostData]
bool HojambazEtraby { get; set; }
         [ImmediatePostData]
bool SerdarabatEtraby { get; set; }
         [ImmediatePostData]
bool KöýtendagEtraby { get; set; }
         [ImmediatePostData]
bool BeýikSaparmyratTürkmenbaşyAdEtraby { get; set; }
          [ImmediatePostData]
bool DöwletliEtraby { get; set; }
         [ImmediatePostData]
bool SeýdiŞäheri { get; set; }
         [ImmediatePostData]
bool MagdanlyŞäheri { get; set; }
        [VisibleInDetailView(false)]
        string WorkPermitLocationCollection { get;  }



        //AşgabatŞäheri TejenŞäheri BalkanabatŞäheri DaşoguzŞäheri TürkmenabatŞäheri MaryŞäheri

    }
[DomainLogic(typeof(IWorkPermitLocation))]
    public class WorkPermitLocationLogic


{


    public static string Get_WorkPermitLocationCollection(IWorkPermitLocation wpLocations)
    {


        return Helper.Get_WPL_Сollection(wpLocations);


    
    }


   
}

    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IWorkPermitLocations));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IWorkPermitLocations))]
    //public class IWorkPermitLocationsLogic {
    //    public static string Get_CalculatedProperty(IWorkPermitLocations instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IWorkPermitLocations instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IWorkPermitLocations instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IWorkPermitLocations instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
