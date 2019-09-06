using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;

namespace VISA2014.Module.DC
{
    class UpdateHelperClasses
    {
        private static void UpdateUrgency(IObjectSpace os) {

            var urgencyAdaty = os.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgencyH","Adaty tertipde !"));

            if (urgencyAdaty != null && urgencyAdaty.mgCode == null)
            {
                urgencyAdaty.mgCode = "1";
               
            }
            var urgencyGyssagly = os.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgencyH", "Gyssagly tertipde!"));

            if (urgencyGyssagly != null && urgencyGyssagly.mgCode == null)
            {
                urgencyGyssagly.mgCode = "2";

            }


            var urgencyOranGyssagly = os.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgencyH", "Örän gyssagly!"));

            if (urgencyOranGyssagly != null && urgencyOranGyssagly.mgCode == null)
            {
                urgencyOranGyssagly.mgCode = "3";

            }

        }//enf of updateUrgency
        private static void UpdateGender(IObjectSpace os)
        {
            var genderMale = os.FindObject<IGender>(new BinaryOperator("TypeOfGender", 0));

            if (genderMale != null && genderMale.mgCode == null)
            {
                genderMale.mgCode = "1";

            }

            var genderfMale = os.FindObject<IGender>(new BinaryOperator("TypeOfGender", 1));

            if (genderfMale != null && genderfMale.mgCode == null)
            {
                genderfMale.mgCode = "2";

            }
        
        }// endof 
        private static void UpdatePassportType(IObjectSpace os) {

            var MP = os.FindObject<IPassportType>(new BinaryOperator("TypeOfPassport", 0));

            if (MP != null && MP.mgCode == null)
            {
                MP.mgCode = "MP";

            }


            var GL = os.FindObject<IPassportType>(new BinaryOperator("TypeOfPassport", 1));

            if (GL != null && GL.mgCode == null)
            {
                GL.mgCode = "PG";

            }

            var PD = os.FindObject<IPassportType>(new BinaryOperator("TypeOfPassport", 2));

            if (PD != null && PD.mgCode == null)
            {
                PD.mgCode = "PD";

            }


        }
        private static void UpdateMaritalStatus(IObjectSpace os)
        {

            var sallah = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", 1));

            if (sallah != null && sallah.mgCode == null)
            {
                sallah.mgCode = "1";

            }


            var oylenen = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", 0));

            if (oylenen != null)
            {
                oylenen.mgCode = "2";

            }
            var durmusacykan = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", 2));

            if (durmusacykan != null && durmusacykan.mgCode == null)
            {
                durmusacykan.mgCode = "2";

            }

            var ayrylsan = os.FindObject<IMaritalStatus>(new BinaryOperator("Status", 4));

            if (ayrylsan != null && ayrylsan.mgCode == null)
            {
                ayrylsan.mgCode = "3";

            }

           

        }
        private static void UpdateEducationLevel(IObjectSpace os)
        {

            var yokary = os.FindObject<IEducationLevel>(new BinaryOperator("TitleOfEducationLevel", "Ýokary"));

            if (yokary != null && yokary.mgCode == null)
            {
                yokary.mgCode = "2";

            }

            var yoriteorta = os.FindObject<IEducationLevel>(new BinaryOperator("TitleOfEducationLevel", "Ýörite Orta"));

            if (yoriteorta != null && yoriteorta.mgCode == null)
            {
                yoriteorta.mgCode = "1";

            }

            var orta = os.FindObject<IEducationLevel>(new BinaryOperator("TitleOfEducationLevel", "Orta"));

            if (orta != null && orta.mgCode == null)
            {
                orta.mgCode = "5";

            }

        }
        private static void UpdateVisaType(IObjectSpace os)
        {

            var BS = os.FindObject<IVisaType>(new BinaryOperator("TypeOfVisa", "BS"));

            if (BS != null && BS.mgCode == null)
            {
                BS.mgCode = "14";

            }

            var WP = os.FindObject<IVisaType>(new BinaryOperator("TypeOfVisa", "WP"));

            if (WP != null && WP.mgCode == null)
            {
                WP.mgCode = "11";

            }

          
        
        }
        private static void UpdateVisaCategory(IObjectSpace os)
        {

            var birGezeklik = os.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", 1));

            if (birGezeklik != null && birGezeklik.mgCode == null)
            {
                birGezeklik.mgCode = "1";

            }

            var ikiGezeklik = os.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", 2));

            if (ikiGezeklik != null && ikiGezeklik.mgCode == null)
            {
                ikiGezeklik.mgCode = "2";

            }

            var kopgezeklik = os.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", 0));

            if (kopgezeklik != null && kopgezeklik.mgCode == null)
            {
                kopgezeklik.mgCode = "4";

            }
        
        }
        private static void UpdateRegion(IObjectSpace os)
        {
            var AS = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 0));

            if (AS != null && AS.mgCode == null)
            {
                AS.mgCode = "AS";

            }

            var AH = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 1));

            if (AH != null && AH.mgCode == null)
            {
                AH.mgCode = "AH";

            }

            var MR = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 5));

            if (MR != null && MR.mgCode == null)
            {
                MR.mgCode = "MR";

            }

            var LB = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 4));

            if (LB != null && LB.mgCode == null)
            {
                LB.mgCode = "LB";

            }

            var DZ = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 3));

            if (DZ != null && DZ.mgCode == null)
            {
                DZ.mgCode = "DZ";

            }

            var BN = os.FindObject<IRegion>(new BinaryOperator("NameOfRegion", 2));

            if (BN != null && BN.mgCode == null)
            {
                BN.mgCode = "BN";

            }
        
        }
        private static void UpdateOneCity(IObjectSpace os,string cityName, string cityCode) {

            var city = os.FindObject<IŞäherEtrap>(new BinaryOperator("ŞäherEtrapL", cityName));

            if (city != null && city.mgCode == null)
            {
                city.mgCode = cityCode;

            }
        }
        private static void UpdateCities(IObjectSpace os)
        {

            UpdateOneCity(os, "Akbugdaý etraby", "AH48");
            UpdateOneCity(os, "Altyn asyr etraby", "AH71");

            UpdateOneCity(os, "Babadaýhan etraby", "AH65");

            UpdateOneCity(os, "Baharly etraby", "AH64");

            UpdateOneCity(os, "Gökdepe etraby", "AH47");


            UpdateOneCity(os, "Kaka etraby", "AH41");

            UpdateOneCity(os, "Ruhabat etraby", "AH30");

            UpdateOneCity(os, "Sarahs etraby", "AH27");

            UpdateOneCity(os, "Tejen şäheri", "AH7");

            UpdateOneCity(os, "Tejen etraby", "AH20");

            UpdateOneCity(os, "Aşgabat şäheri", "AS69");

            UpdateOneCity(os, "Çandybil etraby", "AS57");

            UpdateOneCity(os, "Balkanabat şäheri", "BN63");
            UpdateOneCity(os, "Bereket etraby", "BN61");

            UpdateOneCity(os, "Esenguly etraby", "BN55");

            UpdateOneCity(os, "Etrek etraby", "BN54");

            UpdateOneCity(os, "Garabogaz şäheri", "BN10");

            UpdateOneCity(os, "Magtymguly etraby", "BN49");

            UpdateOneCity(os, "Gumdag şäheri", "BN9");

            UpdateOneCity(os, "Serdar şäheri", "BN25");

            UpdateOneCity(os, "Türkmenbaşy etraby", "BN15");

            UpdateOneCity(os, "Türkmenbaşy şäheri", "BN5");

            UpdateOneCity(os, "Akdepe etraby", "DZ72");

            UpdateOneCity(os, "Boldumsaz etraby", "DZ59");

            UpdateOneCity(os, "Daşoguz şäheri", "DZ56");

            UpdateOneCity(os, "Görogly etraby", "DZ46");

            UpdateOneCity(os, "Gubadag etraby", "DZ45");

            UpdateOneCity(os, "Gurbansoltan-eje ad. etraby", "DZ12");

            UpdateOneCity(os, "Köneürgenç etraby", "DZ40");

            UpdateOneCity(os, "S.A.Nyýazow ad. etraby", "DZ34");

            UpdateOneCity(os, "Ruhubelent etraby", "DZ74");

            UpdateOneCity(os, "Saparmyrat Türkmenbaşy ad. etraby", "DZ8");

            UpdateOneCity(os, "Atamyrat etraby", "LB68");

            UpdateOneCity(os, "Atamyrat şäheri", "LB67");

            UpdateOneCity(os, "Birata etraby", "LB60");

            UpdateOneCity(os, "Döwletli etraby", "LB75");

            UpdateOneCity(os, "Farap etraby", "LB53");

            UpdateOneCity(os, "Galkynyş etraby", "LB52");

            UpdateOneCity(os, "Garabekewül etraby", "LB51");

            UpdateOneCity(os, "Garaşsyzlyk etraby", "LB58");

            UpdateOneCity(os, "Türkmenistanyň Gahrymany Gurbansoltan eje etraby", "LB17");

            UpdateOneCity(os, "Halaç etraby", "LB44");

            UpdateOneCity(os, "Hojambaz etraby", "LB42");

            UpdateOneCity(os, "Köýtendag etraby", "LB38");

            UpdateOneCity(os, "Magdanly şäheri", "LB37");

            UpdateOneCity(os, "Sakar etraby", "LB29");

            UpdateOneCity(os, "Saýat etraby", "LB26");

            UpdateOneCity(os, "Serdarabat etraby", "LB24");

            UpdateOneCity(os, "Seýdi şäheri", "LB22");

            UpdateOneCity(os, "Türkmenabat şäheri", "LB18");

            UpdateOneCity(os, "Beýik Saparmyrat Türkmenbaşy ad. etraby", "LB32");

            UpdateOneCity(os, "Altyn sähra etraby", "MR77");

            UpdateOneCity(os, "Baýramaly etraby", "MR4");

            UpdateOneCity(os, "Baýramaly şäheri", "MR62");

            UpdateOneCity(os, "Garagum etraby", "MR50");

            UpdateOneCity(os, "Mary etraby", "MR36");

            UpdateOneCity(os, "Mary şäheri", "MR19");

            UpdateOneCity(os, "Murgap etraby", "MR35");

            UpdateOneCity(os, "Oguzhan etraby", "MR31");

            UpdateOneCity(os, "Sakarçäge etraby", "MR28");

            UpdateOneCity(os, "Şatlyk şäheri", "MR3");

            UpdateOneCity(os, "Serhetabat etraby", "MR23");

            UpdateOneCity(os, "Serhetabat şäheri", "MR2");

            UpdateOneCity(os, "Tagtabazar etraby", "MR21");

            UpdateOneCity(os, "Türkmengala etraby", "MR14");

            UpdateOneCity(os, "Wekilbazar etraby", "MR13");
            UpdateOneCity(os, "Ýolöten şäheri", "MR11");




        }
        private static void UpdateOneCountry(IObjectSpace os, string Name, string code) {

            var countries = os.GetObjects<ICountries>(new BinaryOperator("NameOfCountry", Name));

            if (countries != null)
            {
                foreach (var item in countries)
                {
                    item.mgCode = Name;
                }

            }
        
        }
        private static void UpdateCountries(IObjectSpace os) {

            UpdateOneCountry(os, "TUR", "TUR-TURKIYE RESP.");
            UpdateOneCountry(os, "ABW", "ABW-ARUBA");
            UpdateOneCountry(os, "AFG", "AFG-OWGANYSTAN");
            UpdateOneCountry(os, "AGO", "AGO-ANGOLA");

            UpdateOneCountry(os, "AIA", "AIA-ANGUILLA");
            UpdateOneCountry(os, "ALA", "ALA-ALAND ISLANDS");
            UpdateOneCountry(os, "ALB", "ALB-ALBANIYA");
            UpdateOneCountry(os, "AND", "AND-ANDORRA");

            UpdateOneCountry(os, "ANT", "ANT-ANTIL ADALARY");

            UpdateOneCountry(os, "ARE", "ARE-BIRLESEN ARAB EMIR");

            UpdateOneCountry(os, "ARG", "ARG-ARGENTINA");

            UpdateOneCountry(os, "ARM", "ARM-ERMENISTAN");

            UpdateOneCountry(os, "ASM", "ASM-AMERIKAN SAMOA");


            UpdateOneCountry(os, "ATA", "ATA-ANTARKTIKA");

            UpdateOneCountry(os, "ATF", "ATF-FRANSUZ GUNBATAR YERI");


            UpdateOneCountry(os, "ATG", "ATG-ANTIGUA WE BARBUDA");

            UpdateOneCountry(os, "AUS", "AUS-AWSRTRALIYA");

            UpdateOneCountry(os, "AUT", "AUT-AWSTRIYA");

            UpdateOneCountry(os, "AZE", "AZE-AZERBEYJAN");

            UpdateOneCountry(os, "BDI", "BDI-BURUNDI");

            UpdateOneCountry(os, "BEL", "BEL-BELGIYA");

            UpdateOneCountry(os, "BEN", "BEN-BENIN");

            UpdateOneCountry(os, "BFA", "BFA-BURKINA-FASO");

            UpdateOneCountry(os, "BGD", "BGD-BANGLADES");

            UpdateOneCountry(os, "BGR", "BGR-BOLGARIYA");

            UpdateOneCountry(os, "BHR", "BHR-BAHREYN");

            UpdateOneCountry(os, "BHS", "BHS-BAGAM ADALARY");

            UpdateOneCountry(os, "BIH", "BIH-BOSNIYA WE GERSEGOWINA");

            UpdateOneCountry(os, "BLR", "BLR-BELARUS");

            UpdateOneCountry(os, "BLZ", "BLZ-BELIZ");

            UpdateOneCountry(os, "BMU", "BMU- BERMUD ADALARY");

            UpdateOneCountry(os, "BOL", "BOL-BOLIVIYA");

            UpdateOneCountry(os, "BRA", "BRA-BRAZILIYA");

            UpdateOneCountry(os, "BRB", "BRB-BARBADOS");

            UpdateOneCountry(os, "BRN", "BRN-BRUNEY DRASSALAM");

            UpdateOneCountry(os, "BTN", "BTN-BUTAN");

            UpdateOneCountry(os, "BVT", "BVT-BOWE");

            UpdateOneCountry(os, "BWA", "BWA-BOTSVANA");

            UpdateOneCountry(os, "CAF", "CAF-MERKEZI AFRIKA RESPUB");

            UpdateOneCountry(os, "CAN", "CAN-KANADA");

            UpdateOneCountry(os, "CCK", "CCK-KOKOS ADALARY (AWSTRALIYA)");

            UpdateOneCountry(os, "CHE", "CHE-SWEYSARIYA");

            UpdateOneCountry(os, "CHL", "CHL-CHILI");

            UpdateOneCountry(os, "CHN", "CHN-HYTAY");

            UpdateOneCountry(os, "CIV", "CIV-KOT-DIWUAR");

            UpdateOneCountry(os, "CMR", "CMR-KAMERUN");

            UpdateOneCountry(os, "COD", "COD-KONGO");

            UpdateOneCountry(os, "COK", "COK-KUK ADALARY");

            UpdateOneCountry(os, "COL", "COL-KOLUMBIYA");

            UpdateOneCountry(os, "COM", "COM-KOMOR ADALARY");

            UpdateOneCountry(os, "CPV", "CPV-KABO-WERDE");

            UpdateOneCountry(os, "CRI", "CRI-KOSTA-RIKA");

            UpdateOneCountry(os, "CUB", "CUB-KUBA");

            UpdateOneCountry(os, "CXR", "CXR-ROJDESTWO ADASY");

            UpdateOneCountry(os, "CYM", "CYM-KAYMAN ADALARY (BRITANIYA)");
            UpdateOneCountry(os, "CYP", "CYP-KIPR");

            UpdateOneCountry(os, "CZE", "CZE-CHEHIYA");

            UpdateOneCountry(os, "DEU", "DEU-GERMANIYA");

            UpdateOneCountry(os, "DJI", "DJI-JIBUTI");

            UpdateOneCountry(os, "DMA", "DMA-DOMINIKA");

            UpdateOneCountry(os, "DNK", "DNK-DANIYA");

            UpdateOneCountry(os, "DOM", "DOM-DOMINIKAN RESPUBLIK");

            UpdateOneCountry(os, "ECU", "ECU-EKWADOR");


            UpdateOneCountry(os, "EGY", "EGY-MUSUR");

            UpdateOneCountry(os, "ERI", "ERI-ERITREYA");

            UpdateOneCountry(os, "ESH", "ESH - SAHARA GUNBATAR");

            UpdateOneCountry(os, "ESP", "ESP-ISPANIYA");

            UpdateOneCountry(os, "EST", "EST-ESTONIYA");

            UpdateOneCountry(os, "ETH", "ETH-EFIOPIYA");

            UpdateOneCountry(os, "FIN", "FIN-FINLYANDIYA");

            UpdateOneCountry(os, "FJI", "FJI-FIJI");

            UpdateOneCountry(os, "FLK", "FLK-FOLKLEND ADALARY");

            UpdateOneCountry(os, "FRA", "FRA-FRANSIYA");

            UpdateOneCountry(os, "FRO", "FRO-FARER ADALARY");

            UpdateOneCountry(os, "FSM", "FSM-MIKRONEZIYA");

            UpdateOneCountry(os, "GAB", "GAB-GABON");

            UpdateOneCountry(os, "GBR", "GBR-WELIKOBRITANIYA");

            UpdateOneCountry(os, "GEO", "GEO-GRUZIYA");

            UpdateOneCountry(os, "GGY", "GGY-GUERNSEY");

            UpdateOneCountry(os, "GHA", "GHA-GANA");

            UpdateOneCountry(os, "GIB", "GIB-GIBRALTAR");

            UpdateOneCountry(os, "GIN", "GIN-GWINEYA");

            UpdateOneCountry(os, "GLP", "GLP-GWADELUPA");
            UpdateOneCountry(os, "GMB", "GMB-GAMBIYA");

            UpdateOneCountry(os, "GNB", "GNB-GWINEYA BISAU");

            UpdateOneCountry(os, "GNQ", "GNQ-EKWATORIAL GWINEA");

            UpdateOneCountry(os, "GRC", "GRC-GRESIYA");

            UpdateOneCountry(os, "GRD", "GRD-GRENADA");

            UpdateOneCountry(os, "GRL", "GRL-GRENLANDIYA");

            UpdateOneCountry(os, "GTM", "GTM-GWATEMALA");

            UpdateOneCountry(os, "GUF", "GUF-GWIANA");

            UpdateOneCountry(os, "GUM", "GUM-GUAM");

            UpdateOneCountry(os, "GUY", "GUY-GAYANA");

            UpdateOneCountry(os, "HKG", "HKG-GONKONG");

            UpdateOneCountry(os, "HMD", "HMD-HERD WE MAKDONALD");

            UpdateOneCountry(os, "HND", "HND-GONDURAS");

            UpdateOneCountry(os, "HRV", "HRV-HORWATIYA");

            UpdateOneCountry(os, "HTI", "HTI-GAITI");

            UpdateOneCountry(os, "HUN", "HUN-WENGRIYA");

            UpdateOneCountry(os, "IDN", "IDN-INDONEZIYA");

            UpdateOneCountry(os, "IMM", "IMM-ISLE OF MAN");

            UpdateOneCountry(os, "IND", "IND-HINDISTAN");

            UpdateOneCountry(os, "IOT", "IOT-HINDI OKEAN BRITAN YERI");

            UpdateOneCountry(os, "IRL", "IRL-IRLANDIYA");

            UpdateOneCountry(os, "IRN", "IRN-EYRAN");

            UpdateOneCountry(os, "IRQ", "IRQ-IRAK");

            UpdateOneCountry(os, "ISL", "ISL-ISLANDIYA");

            UpdateOneCountry(os, "ISR", "ISR-IZRAIL");

            UpdateOneCountry(os, "ITA", "ITA-ITALIYA");

            UpdateOneCountry(os, "JAM", "JAM-YAMAYKA");

            UpdateOneCountry(os, "JEY", "JEY-JERSEY");

            UpdateOneCountry(os, "JOR", "JOR-IORDANIYA");

            UpdateOneCountry(os, "JPN", "JPN-YAPONIYA");


            UpdateOneCountry(os, "KAZ", "KAZ-GAZAGYSTAN");

            UpdateOneCountry(os, "KEN", "KEN-KENIYA");

            UpdateOneCountry(os, "KGZ", "KGZ-GYRGYZSTAN");

            UpdateOneCountry(os, "KHM", "KHM-KAMBODJA");

            UpdateOneCountry(os, "KIR", "KIR-KIRIBATI");

            UpdateOneCountry(os, "KNA", "KNA-SENT KITS WE NEWS");

            UpdateOneCountry(os, "KOR", "KOR-KOREYA RESPUBLIKA");

            UpdateOneCountry(os, "KWT", "KWT-KUWEYT");

            UpdateOneCountry(os, "LAO", "LAO-LAOS");

            UpdateOneCountry(os, "LBN", "LBN-LIVAN");

            UpdateOneCountry(os, "LBR", "LBR-LIBERIYA");

            UpdateOneCountry(os, "LBY", "LBY-LIWIYA");

            UpdateOneCountry(os, "LCA", "LCA-SENT LUSIYA");

            UpdateOneCountry(os, "LIE", "LIE-LIHTENSTEIN");

            UpdateOneCountry(os, "LKA", "LKA-SRI LANKA");

            UpdateOneCountry(os, "LSO", "LSO-LESOTO");

            UpdateOneCountry(os, "LTU", "LTU-LITWA");

            UpdateOneCountry(os, "LUX", "LUX-LUKSEMBURG");

            UpdateOneCountry(os, "LVA", "LVA-LATWIYA");

            UpdateOneCountry(os, "MAC", "MAC-MAKAO");

            UpdateOneCountry(os, "MAR", "MAR-MAROKKO");

            UpdateOneCountry(os, "MCO", "MCO-MONAKO");

            UpdateOneCountry(os, "MDA", "MDA-MOLDOWA");

            UpdateOneCountry(os, "MDG", "MDG-MADAKASKAR");

            UpdateOneCountry(os, "MDV", "MDV-MALDIWY");

            UpdateOneCountry(os, "MEX", "MEX-MEKSIKA");

            UpdateOneCountry(os, "MHL", "MHL-MARSHAL ADALARY");

            UpdateOneCountry(os, "MKD", "MKD-MAKEDONIYA");

            UpdateOneCountry(os, "MLI", "MLI-MALI");


            UpdateOneCountry(os, "MLT", "MLT-MALTA");

            UpdateOneCountry(os, "MMR", "MMR-MYANMA");

            UpdateOneCountry(os, "MNE", "MNE-MONTENEGRO");

            UpdateOneCountry(os, "MNG", "MNG-MONGOLIYA");

            UpdateOneCountry(os, "MNP", "MNP-DEMIRGAZYK MARIAN ADA");

            UpdateOneCountry(os, "MOZ", "MOZ-MOZAMBIK");

            UpdateOneCountry(os, "MRT", "MRT-MAWRITANIYA");

            UpdateOneCountry(os, "MSR", "MSR-MONTSERRAT");

            UpdateOneCountry(os, "MTQ", "MTQ-MARTINIKA");

            UpdateOneCountry(os, "MUS", "MUS-MAWRIKIY");

            UpdateOneCountry(os, "MWI", "MWI-MALAWI");

            UpdateOneCountry(os, "MYS", "MYS-MALAYZIYA");

            UpdateOneCountry(os, "MYT", "MYT-MAYOTTA");

            UpdateOneCountry(os, "NAM", "NAM-NAMIBIYA");

            UpdateOneCountry(os, "NCL", "NCL-TAZE KALEDONIYA");

            UpdateOneCountry(os, "NER", "NER-NIGER");

            UpdateOneCountry(os, "NFK", "NFK-NORFOLK");

            UpdateOneCountry(os, "NGA", "NGA-NIGERIYA");

            UpdateOneCountry(os, "NIC", "NIC-NIKARAGUA");

            UpdateOneCountry(os, "NIU", "NIU-NIUE");

            UpdateOneCountry(os, "NLD", "NLD-NIDERLANDY");

            UpdateOneCountry(os, "NOR", "NOR-NORWEGIYA");

            UpdateOneCountry(os, "NPL", "NPL-NEPAL");

            UpdateOneCountry(os, "NRU", "NRU-NAURU");

            UpdateOneCountry(os, "NZL", "NZL-TAZE ZELANDIYA");

            UpdateOneCountry(os, "OMN", "OMN-OMAN");

            UpdateOneCountry(os, "OTH", "OTH-OTHERS(BEYLEKILER)");

            UpdateOneCountry(os, "PAK", "PAK-PAKISTAN");

            UpdateOneCountry(os, "PAN", "PAN-PANAMA");

            UpdateOneCountry(os, "PCN", "PCN-PITKERN ADALARY (GB)");

            UpdateOneCountry(os, "PER", "PER-PERU");

            UpdateOneCountry(os, "PHL", "PHL-FILIPPINY");

            UpdateOneCountry(os, "PLW", "PLW-PALAU");

            UpdateOneCountry(os, "PNG", "PNG-PAPUA TAZE GWINEA");

            UpdateOneCountry(os, "POL", "POL-POLSA");

            UpdateOneCountry(os, "PRI", "PRI-PUERTO RIKO");

            UpdateOneCountry(os, "PRK", "PRK- KOREYA (KNDR)");

            UpdateOneCountry(os, "PRT", "PRT-PORTUGALIYA");

            UpdateOneCountry(os, "PRY", "PRY-PARAGWAY");

            UpdateOneCountry(os, "PSE", "PSE-PALESTINA");

            UpdateOneCountry(os, "PYF", "PYF-FRANSUZ POLINEZIYA");

            UpdateOneCountry(os, "QAT", "QAT-KATAR");

            UpdateOneCountry(os, "REU", "REU-REYUNYON");

            UpdateOneCountry(os, "RKS", "RKS-KOSOWA RESPUBLIKASY");

            UpdateOneCountry(os, "ROU", "ROU-RUMINIYA");

            UpdateOneCountry(os, "RUS", "RUS-RUSSIYA FEDERASIYASY");

            UpdateOneCountry(os, "RWA", "RWA-RUANDA");

            UpdateOneCountry(os, "SAU", "SAU-SAUD ARABYSTAN");

            UpdateOneCountry(os, "SDN", "SDN-SUDAN");

            UpdateOneCountry(os, "SEN", "SEN-SENEGAL");

            UpdateOneCountry(os, "SGP", "SGP-SINGAPUR");

            UpdateOneCountry(os, "SGS", "SGS-GUNORTA GEORGIYA WE SANDWICH");

            UpdateOneCountry(os, "SHN", "SHN-YELENA ADASY");

            UpdateOneCountry(os, "SJM", "SJM-SPITSBERGEN ADALARY");

            UpdateOneCountry(os, "SLB", "SLB-SOLOMON ADALARY");

            UpdateOneCountry(os, "SLE", "SLE-SIERRA LEONE");

            UpdateOneCountry(os, "SLV", "SLV-SALWADOR");

            UpdateOneCountry(os, "SMR", "SMR-SAN MARINO");

            UpdateOneCountry(os, "SOM", "SOM-SOMALI");

            UpdateOneCountry(os, "SPM", "SPM-SEN PIER WE MIKELON");

            UpdateOneCountry(os, "SRB", "SRB-SERBIA");

            UpdateOneCountry(os, "SSD", "SSD-GUNORTA SUDAN");

            UpdateOneCountry(os, "STP", "STP-SAN TOME WE PRINSIPI");

            UpdateOneCountry(os, "SUR", "SUR-SURINAM");

            UpdateOneCountry(os, "SVK", "SVK-SLOWAKIYA");

            UpdateOneCountry(os, "SVN", "SVN-SLOWENIYA");

            UpdateOneCountry(os, "SWE", "SWE-SWESIYA");

            UpdateOneCountry(os, "SWZ", "SWZ-SWAZILEND");

            UpdateOneCountry(os, "SYC", "SYC-SEYSHEL ADALARY");

            UpdateOneCountry(os, "SYR", "SYR-SIRIYA");

            UpdateOneCountry(os, "TCA", "TCA-TERKS WE KAYKOS ADALARY");

            UpdateOneCountry(os, "TCD", "TCD-CHAD");

            UpdateOneCountry(os, "TGO", "TGO-TOGO");

            UpdateOneCountry(os, "THA", "THA-TAYLAND");

            UpdateOneCountry(os, "TJK", "TJK-TAJIKISTAN");

            UpdateOneCountry(os, "TKL", "TKL-TOKELAU ADALARY");

            UpdateOneCountry(os, "TKM", "TKM-TURKMENISTAN");

            UpdateOneCountry(os, "TLS", "TLS-TIMOR-LESTE");

            UpdateOneCountry(os, "TON", "TON-TONGA");

            UpdateOneCountry(os, "TTO", "TTO-TRINIDAD WE TOBAGO");

            UpdateOneCountry(os, "TUN", "TUN-TUNIS");

            UpdateOneCountry(os, "TUR", "TUR-TURKIYE RESP.");

            UpdateOneCountry(os, "TUV", "TUV-TUWALU");

            UpdateOneCountry(os, "TWN", "TWN-TAYWAN");

            UpdateOneCountry(os, "TZA", "TZA-TANZANIYA");

            UpdateOneCountry(os, "UGA", "UGA-UGANDA");

            UpdateOneCountry(os, "UKR", "UKR-UKRAINA");

            UpdateOneCountry(os, "UMI", "UMI-YUWAS OKEAN ADALARY");

            UpdateOneCountry(os, "UN", "UN-BIRLESEN MILLET GURAMA");

            UpdateOneCountry(os, "URY", "URY-URUGVAY");

            UpdateOneCountry(os, "USA", "USA-AMERICANYN BIRL.STATL");

            UpdateOneCountry(os, "UTO", "UTO-UTOPIYA");

            UpdateOneCountry(os, "UZB", "UZB-OZBEKISTAN");

            UpdateOneCountry(os, "VAT", "VAT-WATIKAN");

            UpdateOneCountry(os, "VCT", "VCT-SENT WINSENT GRENADINY");

            UpdateOneCountry(os, "VEN", "VEN-WENESUELA");

            UpdateOneCountry(os, "VGB", "VGB-VIRGIN ADA (BRITAN)");

            UpdateOneCountry(os, "VIR", "VIR-VIRGIN ADA (USA)");

            UpdateOneCountry(os, "VNM", "VNM-WETNAM");

            UpdateOneCountry(os, "VUT", "VUT-WANUATU");

            UpdateOneCountry(os, "WLF", "WLF-WOLLIS FUTUNA ADASY");

            UpdateOneCountry(os, "WSM", "WSM-GUNBATAR SAMOA");



            UpdateOneCountry(os, "YEM", "YEM-YEMEN");

            UpdateOneCountry(os, "YUG", "YUG-YUGOSLAWIYA");

            UpdateOneCountry(os, "ZAF", "ZAF-GUNORTA AFRIKA");

            UpdateOneCountry(os, "ZAR", "ZAR-ZAIR");

            UpdateOneCountry(os, "ZIM", "ZIM-ZIMBABWE");

            UpdateOneCountry(os, "ZMB", "ZMB-ZAMBIYA");
         

        }
        private static void UpdateOneVisaPeriod(IObjectSpace os, string periodInString,Int16 PeriodInNumber,string mgCode)
        {

            var visaPeriod = os.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", periodInString));

            if (visaPeriod != null)
            {
                visaPeriod.PeriodInNumber = PeriodInNumber;
                visaPeriod.mgCode = mgCode;
            }
        }
        private static void updateVisaPeriods(IObjectSpace os)
        { 
                 UpdateOneVisaPeriod(os,"20 gün",20,"15");
                 UpdateOneVisaPeriod(os, "6 aý", 6, "16");
                 UpdateOneVisaPeriod(os, "3 aý", 3, "16");

                 UpdateOneVisaPeriod(os, "2 aý", 2, "16");

                 UpdateOneVisaPeriod(os, "10 gün", 10, "15");

                 UpdateOneVisaPeriod(os, "1 ýyl", 1, "17");
                 UpdateOneVisaPeriod(os, "12 aý", 12, "16");

                 UpdateOneVisaPeriod(os, "7 gün", 7, "15");

                 UpdateOneVisaPeriod(os, "4 aý", 4, "16");

                 UpdateOneVisaPeriod(os, "1 aý", 1, "16");

                 UpdateOneVisaPeriod(os, "15 gün", 15, "15");
            

        }
        public static void  UpdateMgCode(IObjectSpace os) {
            UpdateCountries(os);
            updateVisaPeriods(os);
            UpdateUrgency(os);
            UpdateGender(os);
            UpdatePassportType(os);
            UpdateMaritalStatus(os);
            UpdateEducationLevel(os);
            UpdateVisaType(os);
            UpdateVisaCategory(os);
            UpdateRegion(os);
            UpdateCities(os);



        }
        public static string ReplaceLetters(string word){
           return word.Replace('Ğ', 'G')
               .Replace('Ü', 'U')
               .Replace('ü', 'u')
               .Replace('Ö', 'O')
               .Replace('ö', 'o')
               .Replace('Ň', 'N')
               .Replace('ň', 'n')
               .Replace("Ş", "S")
               .Replace("ş", "s")
               .Replace("Ç", "C")
               .Replace("ç", "c")
               .Replace('Ğ', 'G')
               .Replace('ğ', 'g')
               .Replace('Ý', 'Y')
               .Replace('ý', 'y')
               .Replace('Ä', 'A')
               .Replace('ä', 'a')
               .Replace('Ž', 'Z')
               .Replace('ž', 'z')
               .Replace('İ', 'I')
               .Replace('ı', 'i')
               .Replace('"', ' ')
               .Replace('„', ' ').ToUpper();
        
       }

    }
}


