using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace VISA2014.Module.DC
{

     

   [DomainComponent, ImageName("BO_Unknown")]
   [XafDefaultProperty("NameOfCountry")]
    public interface ICountries
    {
        [RuleRequiredField]
        CountryEnum CountryEnum {get; set;}
        [RuleRequiredField]
        string NameOfCountry { get; set; }
        [RuleRequiredField]
        string NameOfCountryL { get; set; }

        string mgCode { get; set; }
    }
   
    [DomainComponent,  ImageName("BO_Unknown")]
    [XafDefaultProperty("NameOfRegion")]
    public interface IRegion
    {
        
         [RuleRequiredField]
         RegionEnum NameOfRegion { get; set; }
         [RuleRequiredField]
         string NameOfRegionL { get; set; }
         string mgCode { get; set; }
         [Aggregated]
         IList<IŞäherEtrap> Cities { get; }

    }
  
    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("ŞäherEtrapL")]
    
    public interface IŞäherEtrap
    {

         [RuleRequiredField]
         CityTypeEnum CityType { get; set; }
         [RuleRequiredField]
         string ŞäherEtrapL { get; set; }
         string mgCode { get; set; }
         IRegion Region { get; set; }
        
    }



    [DomainComponent, ImageName("BO_Unknown")]
    [XafDefaultProperty("CopyOfDocument")]
    
    public interface ICopy 
    {
          [RuleRequiredField]
        FileData CopyOfDocument { get; set; }
   
    }



    public enum RegionEnum


    { 
    
    AşgabatŞäheri,
    AhalWelaýaty,
    BalkanWelaýaty,
    DaşoguzWelaýaty,
    LebapWelaýaty,
    MaryWelaýaty
    
    }

    public enum CountryEnum

    {


        #region countries
        TUR,//1
        RUS,//2
        TKM,//3
        GBR,//4
        DEU,//5
        CHN,//6
        USA,//7
        UKR,//8
        TJK,//9
        AFG,//10
        ASM,//11
        AGO,//12
        AIA,//13
        ATG,//14
        ARG,//15
        ARM,//16
        ABW,//17
        AUS,//18
        AUT,//19
        AZE,//20
        BHS,//21
        BHR,//22
        BGD,//23
        BRB,//24
        BLR,//25
        BEL,//26
        BLZ,//27
        BEN,//28
        BMU,//29
        BTN,//30
        BOL,//31
        BIH,//32
        BWA,//33
        BVT,//34
        BRA,//35
        IOT,//36
        BRN,//37
        BGR,//38
        BFA,//39
        BDI,//40
        KHM,//41
        CMR,//42
        CAN,//43
        CPV,//44
        CYM,//45
        CAF,//46
        TCD,//47
        CHL,//48
        CXR,//49
        CCK,//50
        COL,//51
        COM,//52
        COG,//53
        COD,//54
        COK,//55
        CRI,//56
        CIV,//57
        HRV,//58
        CUB,//59
        CYP,//60
        CZE,//61
        DNK,//62
        DJI,//63
        DMA,//64
        DOM,//65
        TMP,//66
        ECU,//67
        EGY,//68
        SLV,//69
        GNQ,//70
        ERI,//71
        EST,//72
        ETH,//73
        FLK,//74
        FRO,//75
        FJI,//76
        FIN,//77
        FRA,//78
        FXX,//79
        GUF,//80
        PYF,//81
        ATF,//82
        GAB,//83
        GMB,//84
        GEO,//85
        GIB,//86
        GRC,//87
        GRL,//88
        GRD,//89
        GLP,//90
        GUM,//91
        GTM,//92
        GIN,//93
        GNB,//94
        GUY,//95
        HTI,//96
        HMD,//97
        VAT,//98
        HND,//99
        HKG,//100
        HUN,//101
        ISL,//102
        IND,//103
        IRN,//104
        IRQ,//105
        IRL,//106
        ISR,//107
        ITA,//108
        JAM,//109
        JPN,//110
        JOR,//111
        KAZ,//112
        KEN,//113
        KIR,//114
        PRK,//115
        KOR,//116
        KWT,//117
        KGZ,//118
        LAO,//119
        LVA,//120
        LBN,//121
        LSO,//122
        LBR,//123
        LBY,//124
        LIE,//125
        LTU,//126
        LUX,//127
        MAC,//128
        MKD,//129
        MDG,//130
        MWI,//131
        MYS,//132
        MDV,//133
        MLI,//134
        MLT,//135
        MHL,//136
        MTQ,//137
        MRT,//138
        MUS,//139
        MYT,//140
        MEX,//141
        FSM,//142
        MDA,//143
        MCO,//144
        MNG,//145
        MSR,//146
        MAR,//147
        MOZ,//148
        MMR,//149
        NAM,//150
        NRU,//151
        NPL,//152
        NLD,//153
        ANT,//154
        NCL,//155
        NZL,//156
        NIC,//157
        NER,//158
        NGA,//159
        NIU,//160
        NFK,//161
        MNP,//162
        NOR,//163
        OMN,//164
        PAK,//165
        PLW,//166
        PAN,//167
        PNG,//168
        PRY,//169
        PER,//170
        PHL,//171
        PCN,//172
        POL,//173
        PRT,//174
        PRI,//175
        QAT,//176
        REU,//177
        ROM,//178
        RWA,//179
        KNA,//180
        LCA,//181
        VCT,//182
        WSM,//183
        SMR,//184
        STP,//185
        SAU,//186
        SEN,//187
        SYC,//188
        SLE,//190
        SGP,//191
        SVK,//192
        SVN,//193
        SLB,//194
        SOM,//195
        ZAF,//196
        SGS,//197
        ESP,//198
        LKA,//199
        SHN,//200
        SPM,//201
        SDN,//202
        SUR,//203
        SJM,//204
        SWZ,//205
        SWE,//206
        CHE,//207
        SYR,//208
        TWN,//209
        TZA,//210
        THA,//211
        TGO,//212
        TKL,//213
        TON,//214
        TTO,//215
        TUN,//216
        TCA,//217
        TUV,//218
        UGA,//219
        ARE,//220
        UMI,//221
        URY,//222
        UZB,//223
        VUT,//224
        VEN,//225
        VNM,//226
        VGB,//227
        VIR,//228
        WLF,//229
        ESH,//230
        YEM,//231
        ZMB,//232
        ZWE,//233
        ROU //234
        #endregion

    
    
    }

    public enum CityTypeEnum

    { 
    
    Etrap,
    Şäher,
    Şäherçe

    
    }




    // To use a Domain Component in an XAF application, the Component should be registered.
    // Override the ModuleBase.Setup method in the application's module and invoke the ITypesInfo.RegisterEntity method in it:
    //
    // public override void Setup(XafApplication application) {
    //     XafTypesInfo.Instance.RegisterEntity("MyComponent", typeof(IDictionary));
    //     base.Setup(application);
    // }

    //[DomainLogic(typeof(IDictionary))]
    //public class IDictionaryLogic {
    //    public static string Get_CalculatedProperty(IDictionary instance) {
    //        // A "Get_" method is executed when getting a target property value. The target property should be readonly.
    //        // Use this method to implement calculated properties.
    //        return "";
    //    }
    //    public static void AfterChange_PersistentProperty(IDictionary instance) {
    //        // An "AfterChange_" method is executed after a target property is changed. The target property should not be readonly. 
    //        // Use this method to refresh dependant property values.
    //    }
    //    public static void AfterConstruction(IDictionary instance) {
    //        // The "AfterConstruction" method is executed only once, after an object is created. 
    //        // Use this method to initialize new objects with default property values.
    //    }
    //    public static int SumMethod(IDictionary instance, int val1, int val2) {
    //        // You can also define custom methods.
    //        return val1 + val2;
    //    }
    //}
}
