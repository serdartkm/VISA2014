using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace VISA2014.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(true, GroupName = "Configuration")]
    [DefaultProperty("TitleOfCheckPoint")]
    public class CheckPoint : BaseObject
    {
        public CheckPoint(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here or place it only when the IsLoading property is false:
            // if (!IsLoading){
            //    It is now OK to place your initialization code here.
            // }
            // or as an alternative, move your initialization code into the AfterConstruction method.
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        //// Fields...

        private string titleOfCheckPointR;
        private string titleOfCheckPointL;
        private CheckPointEn titleOfCheckPoint;

        public CheckPointEn TitleOfCheckPoint
        {
            get
            {
                return titleOfCheckPoint;
            }
            set
            {
                SetPropertyValue("TitleOfCheckPoint", ref titleOfCheckPoint, value);
            }
        }


        public string TitleOfCheckPointL
        {
            get
            {
                return titleOfCheckPointL;
            }
            set
            {
                SetPropertyValue("TitleOfCheckPointL", ref titleOfCheckPointL, value);
            }
        }


        public string TitleOfCheckPointR
        {
            get
            {
                return titleOfCheckPointR;
            }
            set
            {
                SetPropertyValue("TitleOfCheckPointR", ref titleOfCheckPointR, value);
            }
        }
    }


    public enum CheckPointEn 

    { 
    
    AşgabatŞäherHowaMenzilindäkiMGP,
    HowdanMGP,
    DaşoguzMGP,
    KöneürgençMGP,
    FarapMGP,
    YmamnazarMGP,
    TallymerjenMGP,
    SerhetabatMGP,
    ArtykMGP,
    SarahsMGP,
    EtrekMGP,
    GarabogazMGP,
    TürkmenbaşyDeňizMenzilindäkiMGP,
    TürkmenbaşyHowaMenzilindäkiMGP
    
    
    }

}
