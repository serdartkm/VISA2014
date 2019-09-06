using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using VISA2014.Module.DC;

namespace VISA2014.Module.BusinessObjects
{
    public class Helper
    {
        public static IPassport GetLastPassport(IPersonn person)
        {


            if (person != null && person.LastPassport != null)
            {
                return person.LastPassport;

            }
            else return null;



        }

        public static IWorkHistory GetLastPosition(IPersonn person)
        {

            if (person != null && person.LastPosition != null)
            {
                return person.LastPosition;

            }

            else return null;

        }

        public static IWorkPermit GetLastWorkPermit(IPersonn person)
        {


            if (person != null && person.LastWorkPermit != null)
            {

                return person.LastWorkPermit;
            }

            else return null;

        }

        public static IPassport GetPreviousPassport(IPersonn person)
        {
            if (person != null && person.Passports != null)
            {
                IPassport newPass = person.Passports.OrderByDescending(t => t.PassportExpiringDate).First();
                IPassport prevPass = null;
                foreach (var passport in person.Passports)
                {
                    var temp = passport;

                    if (temp.PassportExpiringDate >= passport.PassportExpiringDate && passport.PassportExpiringDate != newPass.PassportExpiringDate)
                    {

                        prevPass = temp;

                    }
                }

                return prevPass;
            }


            else
                return null;



        }


        public static ITravelInformation GetLastEntry(IPersonn person)
        {

            if (person.LastTravelInfo != null)
            {
                return person.LastTravelInfo;

            }

            else return null;

        }

        public static IVisa GetLastVisa(IPassport passport)
        {
            if (passport.LastVisa != null)
            {
                return passport.LastVisa;
            }

            else return null;
        }

        public static IAddressOfResidence GetLastAddress(IPersonn person)
        {

            if (person != null)
            {
                if (person.AddressOfResidences.Count == 1)
                {

                    return person.AddressOfResidences.First();

                }

                if (person.AddressOfResidences.Count > 1)
                {

                    return person.AddressOfResidences.OrderByDescending(t => t.StartDateOfResidence).First();

                }

                else

                    return null;

            }


            else
                return null;


        }



        public static string GetRelationEmp(IApplication app)
        {

            string singleRelationShipInLetter = null;
            // string doubleRelationShipInLetter = null;
            string temp = null;
            int len = 0;
            if (app.PersonInApplication.Count > 0 && app.ForFamilyMember)
            {
                singleRelationShipInLetter = app.PersonInApplication.First().FamilyMember.EmployeeRelation.ToString() + Helper.Get_EmployeeRelationEnding(app.PersonInApplication.First().FamilyMember.EmployeeRelation) + ", ";
                foreach (var item in app.PersonInApplication)
                {
                    temp = item.FamilyMember.EmployeeRelation.ToString() + Helper.Get_EmployeeRelationEnding(item.AppliedPerson.EmployeeRelation);

                    if (!singleRelationShipInLetter.Contains(item.FamilyMember.EmployeeRelation.ToString()))
                        singleRelationShipInLetter += temp.ToLower() + ", ";

                    len = temp.Length;




                }

                return singleRelationShipInLetter.Remove(singleRelationShipInLetter.Length - 2).ToLower();


            }
            else return null;



        }




        public static string Get_EmployeeRelationEnding(RelationEnum empRelation)
        {
            var relation = empRelation;

            switch (relation)
            {
                case RelationEnum.Adamsy:
                    return "nyň";

                case RelationEnum.Agtygy:
                    return "nyň";

                case RelationEnum.Atasy:
                    return "nyň";

                case RelationEnum.AýalDogany:
                    return "nyň";

                case RelationEnum.Aýaly:
                    return "nyň";

                case RelationEnum.Ejesi:
                    return "niň";

                case RelationEnum.Enesi:
                    return "nyň";

                case RelationEnum.ErkekDogany:
                    return "nyň";

                case RelationEnum.Gyzy:
                    return "nyň";

                case RelationEnum.Kakasy:
                    return "nyň";

                case RelationEnum.Ogly:
                    return "nyň";

                default: return ""; ;

            }







        }

        public static bool SameRelationExists(IApplication app, RelationEnum relation, IPersonn person)
        {
            bool relationexists = false;


            foreach (var item in app.PersonInApplication)
            {




                if (item.AppliedPerson.EmployeeRelation == relation && item.AppliedPerson == person)
                {
                    relationexists = true;

                }

                else
                {
                    relationexists = false;
                }


            }

            return relationexists;




        }



        #region Get BorderZone For Visa

        public static bool CountBorderZones(IApplication application)
        {

            if (application.BorderZoneForVisa != null)
            {
                int countBZ = 0;
                int dasoguz = 0;
                int tagtabazar = 0;
                int serhetabat = 0;
                int yoloten = 0;
                int sarahs = 0;
                int garabogaz = 0;
                int etrek = 0;
                int farap = 0;

                if (application.BorderZoneForVisa.Daşoguz == true)
                {
                    dasoguz = 1;

                }
                if (application.BorderZoneForVisa.Tagtabazar == true)
                {
                    tagtabazar = 1;

                }
                if (application.BorderZoneForVisa.Serhetabat == true)
                {
                    serhetabat = 1;

                }
                if (application.BorderZoneForVisa.Ýolöten == true)
                {
                    yoloten = 1;

                }
                if (application.BorderZoneForVisa.Sarahs == true)
                {
                    sarahs = 1;

                }
                if (application.BorderZoneForVisa.Garabogaz == true)
                {
                    garabogaz = 1;

                }
                if (application.BorderZoneForVisa.Etrek == true)
                {
                    etrek = 1;

                }
                if (application.BorderZoneForVisa.Farap == true)
                {
                    farap = 1;

                }


                countBZ = dasoguz + tagtabazar + serhetabat + yoloten + sarahs + garabogaz + etrek + farap;

                if (countBZ > 1)
                {
                    return true;

                }
                else return false;
            }
            else return false;

        }

        public static string Get_BZ_Daşoguz(IBorderZoneForVisa bzForVisa)
        {


            if (bzForVisa != null)
            {

                if (bzForVisa.Daşoguz && bzForVisa.AppConfig != null && bzForVisa.AppConfig.InRussian)
                {
                    if (bzForVisa.Tagtabazar == true | bzForVisa.Tagtabazar == true | bzForVisa.Serhetabat == true | bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Дашогуз" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Дашогуз"; //app.Tagtabazar_R;

                }

                else
                    if (bzForVisa.Daşoguz && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Tagtabazar == true | bzForVisa.Tagtabazar == true | bzForVisa.Serhetabat == true | bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Daşoguz şäher" + ", "; //app.tagtabazar_r;
                        }
                        else

                            return "Daşoguz şäher"; //app.tagtabazar_r;

                    }

                    else return null;
            }
            else return null;








        }

        public static string Get_BZ_Tagtabazar(IBorderZoneForVisa bzForVisa)
        {

            if (bzForVisa != null)
            {

                if (bzForVisa.Tagtabazar && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Serhetabat == true | bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Тахтабазар" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Тахтабазар"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Tagtabazar && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Serhetabat == true | bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Tagtabazar etrap" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Tagtabazar etrap"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_Serhetabat(IBorderZoneForVisa bzForVisa)
        {


            if (bzForVisa != null)
            {
                if (bzForVisa.Serhetabat && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Серхетабат" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Серхетабат"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Serhetabat && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Ýolöten == true | bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Serhetabat etrap" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Serhetabat etrap"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;








        }

        public static string Get_BZ_Ýolöten(IBorderZoneForVisa bzForVisa)
        {

            if (bzForVisa != null)
            {

                if (bzForVisa.Ýolöten && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Ялатань" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Ялатань"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Ýolöten && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Farap == true | bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Ýolöten etrap" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Ýolöten etrap"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_Farap(IBorderZoneForVisa bzForVisa)
        {

            if (bzForVisa != null)
            {

                if (bzForVisa.Farap && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Фарап" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Фарап"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Farap && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Sarahs == true | bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Farap etrap" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Farap etrap"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_Sarahs(IBorderZoneForVisa bzForVisa)
        {


            if (bzForVisa != null)
            {
                if (bzForVisa.Sarahs && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                    {

                        return "Серахс" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Серахс"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Sarahs && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Garabogaz == true | bzForVisa.Etrek == true)
                        {

                            return "Sarags etrap" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Sarags etrap"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_Garabogaz(IBorderZoneForVisa bzForVisa)
        {


            if (bzForVisa != null)
            {
                if (bzForVisa.Garabogaz && bzForVisa.AppConfig.InRussian)
                {

                    if (bzForVisa.Etrek == true)
                    {

                        return "Гарабогаз" + ", "; //app.Tagtabazar_R;
                    }
                    else

                        return "Гарабогаз"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Garabogaz && bzForVisa.AppConfig.InTurkmen)
                    {

                        if (bzForVisa.Etrek == true)
                        {

                            return "Garabogaz şäher" + ", "; //app.Tagtabazar_R;
                        }
                        else

                            return "Garabogaz şäher"; //app.Tagtabazar_R;
                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_Etrek(IBorderZoneForVisa bzForVisa)
        {

            if (bzForVisa != null)
            {

                if (bzForVisa.Etrek && bzForVisa.AppConfig.InRussian)
                {





                    return "Атрек"; //app.Tagtabazar_R;
                }

                else
                    if (bzForVisa.Etrek && bzForVisa.AppConfig.InTurkmen)
                    {



                        return "Etrek etrap"; //app.Tagtabazar_R;

                    }
                    else return null;
            }
            else return null;














        }

        public static string Get_BZ_collection(IBorderZoneForVisa bzForVisa)
        {


            string dasoguz = Helper.Get_BZ_Daşoguz(bzForVisa);
            string tagtabazar = Helper.Get_BZ_Tagtabazar(bzForVisa);
            string serhetabat = Helper.Get_BZ_Serhetabat(bzForVisa);
            string yoloten = Helper.Get_BZ_Ýolöten(bzForVisa);
            string farap = Helper.Get_BZ_Farap(bzForVisa);
            string sarags = Helper.Get_BZ_Sarahs(bzForVisa);
            string garabogaz = Helper.Get_BZ_Garabogaz(bzForVisa);
            string etrek = Helper.Get_BZ_Etrek(bzForVisa);
            return dasoguz + " " + tagtabazar + " " + serhetabat + " " + yoloten + " " + farap + " " + sarags + " " + garabogaz + " " + etrek;



        }


        #endregion

        #region WorkPermitLocations

        public static string Get_WPL_Aşgabat_ş(IWorkPermitLocation wpLocation)
        {

          
            if (wpLocation.AşgabatŞäheri)
            {

                return "Aşgabat şäheri, ";
            }

            else if (!wpLocation.AşgabatŞäheri)
            {
                return null;

            }
            else return null;


        }

        public static string Get_WPL_Tejen_ş(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.TejenŞäheri)
            {

                return "Tejen şäheri, ";

            }
          

            else if (!wpLocation.TejenŞäheri)
            {
                return null;

            }
            else return null;


        }

        public static string Get_WPL_Balkanabat_ş(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.BalkanabatŞäheri)
            {

                return "Balkanabat şäheri, ";
            }

            else if (!wpLocation.BalkanabatŞäheri)
            {
                return null;

            }
            else return null;


        }

        public static string Get_WPL_Daşoguz_ş(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.DaşoguzŞäheri)
            {

                return "Daşoguz şäheri, ";
            }

            else if (!wpLocation.DaşoguzŞäheri)
            {
                return null;

            }
            else return null;


        }


        public static string Get_WPL_Türkmenabat_ş(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.TürkmenabatŞäheri)
            {

                return "Türkmenabat şäheri, ";
            }

            else if (!wpLocation.TürkmenabatŞäheri)
            {
                return null;

            }
            else return null;


        }

        public static string Get_WPL_Mary_ş(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.MaryŞäheri)
            {

                return "Mary şäheri, ";
            }

            else if (!wpLocation.MaryŞäheri)
            {
                return null;

            }
            else return null;


        }


        // Ahal welayaty
        //string baharlyEtraby

        public static string Get_WPL_Baharly_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.BaharlyEtraby)
            {

                return "Baharly etraby, ";
            }

            else if (!wpLocation.BaharlyEtraby)
            {
                return null;

            }
            else return null;


        }

        // string gökdepeEtraby

        public static string Get_WPL_Gokdepe_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.GökdepeEtraby)
            {

                return "Gökdepe etraby, ";
            }

            else if (!wpLocation.GökdepeEtraby)
            {
                return null;

            }
            else return null;


        }

        // string ruhabatEtraby


        public static string Get_WPL_Ruhabat_e(IWorkPermitLocation wpLocation)
        {

         if (wpLocation.RuhabatEtraby)
            {

                return "Ruhabat etraby, ";
            }

            else if (!wpLocation.RuhabatEtraby)
            {
                return null;

            }
            else return null;


        }


        //string anewŞäheri
        public static string Get_WPL_Anew_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.ÄnewŞäheri)
            {

                return "Änew şäheri, ";
            }

            else if (!wpLocation.ÄnewŞäheri)
            {
                return null;

            }
            else return null;


        }



        // string akbugdaýEtraby
        public static string Get_WPL_Akbugday_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.AkbugdaýEtraby)
            {

                return "Akbugdaý etraby, ";
            }

            else if (!wpLocation.AkbugdaýEtraby)
            {
                return null;

            }
            else return null;


        }


        // Kaka etraby

        public static string Get_WPL_Kaka_e(IWorkPermitLocation wpLocation)
        {

         if (wpLocation.KakaEtraby)
            {

                return "Kaka etraby, ";
            }

            else if (!wpLocation.KakaEtraby)
            {
                return null;

            }
            else return null;


        }

        //string tejenEtraby


        public static string Get_WPL_Tejen_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.TejenEtraby)
            {

                return "Tejen etraby, ";
            }

            else if (!wpLocation.TejenEtraby)
            {
                return null;

            }
            else return null;


        }


        //  string altynAsyrEtraby


        public static string Get_WPL_AltynAsyr_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.AltynAsyrEtraby)
            {

                return "Altyn asyr etraby, ";
            }

            else if (!wpLocation.AltynAsyrEtraby)
            {
                return null;

            }
            else return null;


        }

        //string babadaýhanEtraby


        public static string Get_WPL_Babadaýhan_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.BabadaýhanEtraby)
            {

                return "Babadaýhan etraby, ";
            }

            else if (!wpLocation.BabadaýhanEtraby)
            {
                return null;

            }
            else return null;


        }

        //string sarahsEtraby

        public static string Get_WPL_Sarahs_e(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.SarahsEtraby)
            {

                return "Sarahs etraby, ";
            }

            else if (!wpLocation.SarahsEtraby)
            {
                return null;

            }
            else return null;


        }

        //string abadanŞäheri


        public static string Get_WPL_Abadan_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.AbadanŞäheri )
            {

                return "Abadan şäheri, ";
            }

            else if (!wpLocation.AbadanŞäheri)
            {
                return null;

            }
            else return null;


        }

        // BALKAN _________________________________________________________________________________W

        // string esengulyEtraby


        public static string Get_WPL_Esenguly_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.EsengulyEtraby)
            {

                return "Esenguly etraby, ";
            }

            else if (!wpLocation.EsengulyEtraby)
            {
                return null;

            }
            else return null;


        }

        // string bereketEtraby

        public static string Get_WPL_Bereket_e(IWorkPermitLocation wpLocation)
        {
        if (wpLocation.BereketEtraby)
            {

                return "Bereket etraby, ";
            }

            else if (!wpLocation.BereketEtraby)
            {
                return null;

            }
            else return null;


        }

        // string bereketŞäheri


        public static string Get_WPL_Bereket_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.BereketŞäheri)
            {

                return "Bereket şäheri, ";
            }

            else if (!wpLocation.BereketŞäheri)
            {
                return null;

            }
            else return null;


        }


        // string serdarEtraby

        public static string Get_WPL_Serdar_e(IWorkPermitLocation wpLocation)
        {

         if (wpLocation.SerdarEtraby)
            {

                return "Serdar etraby, ";
            }

            else if (!wpLocation.SerdarEtraby)
            {
                return null;

            }
            else return null;


        }

        // string magtymgulyEtraby

        public static string Get_WPLMagtymguly_e(IWorkPermitLocation wpLocation)
        {

         if (wpLocation.MagtymgulyEtraby)
            {

                return "Magtymguly etraby, ";
            }

            else if (!wpLocation.MagtymgulyEtraby)
            {
                return null;

            }
            else return null;


        }

        //string etreketraby

        public static string Get_WPL_Etrek_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.EtrekEtraby )
            {

                return "Etrek etraby, ";
            }

            else if (!wpLocation.EtrekEtraby)
            {
                return null;

            }
            else return null;


        }


        //string türkmenbaşyEtraby

        public static string Get_WPL_Turkmenbasy_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.TürkmenbaşyEtraby)
            {

                return "Türkmenbaşy etraby, ";
            }

            else if (!wpLocation.TürkmenbaşyEtraby)
            {
                return null;

            }
            else return null;


        }


        // string türkmenbaşyŞäheri

        public static string Get_WPL_Turkmenbasy_s(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.TürkmenbaşyŞäheri)
            {

                return "Türkmenbaşy şäheri, ";
            }

            else if (!wpLocation.TürkmenbaşyŞäheri)
            {
                return null;

            }
            else return null;


        }


        // string gumdagŞäheri

        public static string Get_WPL_Gumdag_s(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.GumdagŞäheri)
            {

                return "Gumdag şäheri, ";
            }

            else if (!wpLocation.GumdagŞäheri)
            {
                return null;

            }
            else return null;


        }

        // string hazarŞäheri


        public static string Get_WPL_Hazar_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.HazarŞäheri)
            {

                return "Hazar şäheri, ";
            }

            else if (!wpLocation.HazarŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string garabogazŞäheri

        public static string Get_WPL_Garabogaz_s(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.GarabogazŞäheri)
            {

                return "Garabogaz şäheri, ";
            }

            else if (!wpLocation.GarabogazŞäheri)
            {
                return null;

            }
            else return null;


        }

        // string serdarŞäheri

        public static string Get_WPL_Serdar_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.SerdarŞäheri)
            {

                return "Serdar şäheri, ";
            }

            else if (!wpLocation.SerdarŞäheri)
            {
                return null;

            }
            else return null;


        }

        // DASHOGUZ

        // string gurbansoltanEjeAdEtraby

        public static string Get_WPL_GurbansoltanE_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.GurbansoltanEjeAdEtraby)
            {

                return "Gurbansoltan eje ad. etraby, ";
            }

            else if (!wpLocation.GurbansoltanEjeAdEtraby)
            {
                return null;

            }
            else return null;


        }

        // string saparmyratTürkmenbaşyAdEetraby


        public static string Get_WPL_SaparTurmenbasy_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.SaparmyratTürkmenbaşyAdEetraby)
            {

                return "Saparmyrat Türkmenbaşy ad. etraby, ";
            }

            else if (!wpLocation.SaparmyratTürkmenbaşyAdEetraby)
            {
                return null;

            }
            else return null;


        }

        // string sANyýazowAdEtraby

        public static string Get_WPL_SANAd_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.SANyýazowAdEtraby)
            {

                return "S.A. Nyýazow ad. etraby, ";
            }

            else if (!wpLocation.SANyýazowAdEtraby)
            {
                return null;

            }
            else return null;


        }

        // string göroglyEtraby

        public static string Get_WPL_Gorogly_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.GöroglyEtraby)
            {

                return "Görogly etraby, ";
            }

            else if (!wpLocation.GöroglyEtraby)
            {
                return null;

            }
            else return null;


        }

        //string boldumsazEtraby


        public static string Get_WPL_Boldumsaz_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.BoldumsazEtraby)
            {

                return "Boldumsaz etraby, ";
            }

            else if (!wpLocation.BoldumsazEtraby)
            {
                return null;

            }
            else return null;


        }

        //string köneürgençEtraby

        public static string Get_WPL_Koneurgenç_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.KöneürgençEtraby)
            {

                return "Köneürgenç etraby, ";
            }

            else if (!wpLocation.KöneürgençEtraby)
            {
                return null;

            }
            else return null;


        }

        //string akdepeEtraby

        public static string Get_WPL_Akdepe_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.AkdepeEtraby)
            {

                return "Akdepe etraby, ";
            }

            else if (!wpLocation.AkdepeEtraby)
            {
                return null;

            }
            else return null;


        }

        //string gubadagEtraby

        public static string Get_WPL_Gubadag_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.GubadagEtraby)
            {

                return "Gubadag etraby, ";
            }

            else if (!wpLocation.GubadagEtraby)
            {
                return null;

            }
            else return null;


        }

        //string ruhubelentEtraby

        public static string Get_WPL_Ruhubelent_e(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.RuhubelentEtraby)
            {

                return "Ruhubelent etraby, ";
            }

             else if (!wpLocation.RuhubelentEtraby)
            {
                return null;

            }
            else return null;


        }


        //string köneürgençŞäheri


        public static string Get_WPL_Koneurgenç_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.KöneürgençŞäheri)
            {

                return "Köneürgenç şäheri, ";
            }

            else if (!wpLocation.KöneürgençŞäheri)
            {
                return null;

            }
            else return null;


        }


        // MARY

        //string baýramalyŞäheri

        public static string Get_WPL_Bayramaly_s(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.BaýramalyŞäheri)
            {

                return "Baýramaly şäheri, ";
            }

            else if (!wpLocation.BaýramalyŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string wekilbazarEtraby

        public static string Get_WPL_Wekilbazar_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.WekilbazarEtraby)
            {

                return "Wekilbazar etraby, ";
            }

            else if (!wpLocation.WekilbazarEtraby)
            {
                return null;

            }
            else return null;


        }

        //string yolötenEtraby

        public static string Get_WPL_Yoloten_e(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.ÝolötenEtraby)
            {

                return "Ýolöten etraby, ";
            }

            else if (!wpLocation.ÝolötenEtraby)
            {
                return null;

            }
            else return null;


        }

        //string yolötenŞäheri

        public static string Get_WPL_Yoloten_s(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.ÝolötenŞäheri)
            {

                return "Ýolöten şäheri, ";
            }

            else if (!wpLocation.ÝolötenŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string garagumEtraby

        public static string Get_WPL_Garagum_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.GaragumEtraby)
            {

                return "Garagum etraby, ";
            }

            else if (!wpLocation.GaragumEtraby)
            {
                return null;

            }
            else return null;


        }

        //string serhetabatŞäheri

        public static string Get_WPL_Serhetabat_s(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.SerhetabatŞäheri )
            {

                return "Serhetabat şäheri, ";
            }

            else if (!wpLocation.SerhetabatŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string serhetabatEtraby

        public static string Get_WPL_Serhetabat_e(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.SerhetabatEtraby)
            {

                return "Serhetabat etraby, ";
            }

            else if (!wpLocation.SerhetabatEtraby)
            {
                return null;

            }
            else return null;


        }

        //string maryEtraby

        public static string Get_WPL_Mary_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.MaryEtraby)
            {

                return "Mary etraby, ";
            }

            else if (!wpLocation.MaryEtraby)
            {
                return null;

            }
            else return null;


        }

        //string murgapEtraby

        public static string Get_WPL_Murgap_e(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.MurgapEtraby)
            {

                return "Murgap etraby, ";
            }

            else if (!wpLocation.MurgapEtraby)
            {
                return null;

            }
            else return null;


        }

        //string oguzhanEtraby

        public static string Get_WPL_Oguzhan_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.OguzhanEtraby)
            {

                return "Oguzhan etraby, ";
            }

            else if (!wpLocation.OguzhanEtraby)
            {
                return null;

            }
            else return null;


        }

        //string şatlykŞäheri

        public static string Get_WPL_Satlyk_s(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.ŞatlykŞäheri)
            {

                return "Şatlyk şäheri, ";
            }

            else if (!wpLocation.ŞatlykŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string sakarçägeEtraby 

        public static string Get_WPL_Sakarçage_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.SakarçägeEtraby)
            {

                return "Sakarçäge etraby, ";
            }

            else if (!wpLocation.SakarçägeEtraby)
            {
                return null;

            }
            else return null;


        }

        //string tagtabazarEtraby

        public static string Get_WPL_Tagtabazar_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.TagtabazarEtraby)
            {

                return "Tagtabazar etraby, ";
            }

            else if (!wpLocation.TagtabazarEtraby)
            {
                return null;

            }
            else return null;


        }

        //string türkmengalaEtraby


        public static string Get_WPL_Turkmengala_e(IWorkPermitLocation wpLocation)
        {

          
             if (wpLocation.TürkmengalaEtraby)
            {

                return "Türkmengala etraby, ";
            }

            else if (!wpLocation.TürkmengalaEtraby)
            {
                return null;

            }
            else return null;


        }

        //string altynSähraEtraby

        public static string Get_WPL_Altynsahra_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.AltynSähraEtraby)
            {

                return "Altynsähar etraby, ";
            }

            else if (!wpLocation.AltynSähraEtraby)
            {
                return null;

            }
            else return null;


        }

        //string baýramalyEtraby

        public static string Get_WPL_Bayramaly_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.BaýramalyEtraby)
            {

                return "Baýramaly etraby, ";
            }

            else if (!wpLocation.BaýramalyEtraby)
            {
                return null;

            }
            else return null;


        }

        //LEBAP

        //string birataEtraby

        public static string Get_WPL_Birata_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.BirataEtraby)
            {

                return "Birata etraby, ";
            }

            else if (!wpLocation.BirataEtraby)
            {
                return null;

            }
            else return null;


        }

        //string gazojakŞäheri

        public static string Get_WPL_Gazojak_s(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.GazojakŞäheri)
            {

                return "Gazojak şäheri, ";
            }

            else if (!wpLocation.GazojakŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string garaşsyzlykEtraby


        public static string Get_WPL_Garasyzlyk_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.GaraşsyzlykEtraby)
            {

                return "Garaşsyzlyk etraby, ";
            }

            else if (!wpLocation.GaraşsyzlykEtraby)
            {
                return null;

            }
            else return null;


        }

        //string galkynyşEtraby

        public static string Get_WPL_Galkynyş_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.GalkynyşEtraby)
            {

                return "Galkynyş etraby, ";
            }

            else if (!wpLocation.GalkynyşEtraby)
            {
                return null;

            }
            else return null;


        }

        //string garabekewülEtraby

        public static string Get_WPL_Garabekewül_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.GarabekewülEtraby)
            {

                return "Garabekewül etraby, ";
            }

            else if (!wpLocation.GarabekewülEtraby)
            {
                return null;

            }
            else return null;


        }

        //string atamyratEtraby

        public static string Get_WPL_Atamyrat_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.AtamyratEtraby)
            {

                return "Atamyrat etraby, ";
            }

            else if (!wpLocation.AtamyratEtraby)
            {
                return null;

            }
            else return null;


        }

        //string atamyratŞäheri

        public static string Get_WPL_Atamyrat_s(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.AtamyratŞäheri)
            {

                return "Atamyrat şäheri, ";
            }

            else if (!wpLocation.AtamyratŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string sakarEtraby

        public static string Get_WPL_Sakar_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.SakarEtraby)
            {

                return "Sakar etraby, ";
            }

            else if (!wpLocation.SakarEtraby)
            {
                return null;

            }
            else return null;


        }


        //string saýatEtraby

        public static string Get_WPL_Sayat_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.SaýatEtraby)
            {

                return "Saýat etraby, ";
            }

            else if (!wpLocation.SaýatEtraby)
            {
                return null;

            }
            else return null;


        }

        //string halaçEtraby

        public static string Get_WPL_Halaç_e(IWorkPermitLocation wpLocation)
        {

         if (wpLocation.HalaçEtraby)
            {

                return "Halaç etraby, ";
            }

            else if (!wpLocation.HalaçEtraby)
            {
                return null;

            }
            else return null;


        }

        //string farapEtraby

        public static string Get_WPL_Farap_e(IWorkPermitLocation wpLocation)
        {

           
             if (wpLocation.FarapEtraby)
            {

                return "Farap etraby, ";
            }

            else if (!wpLocation.FarapEtraby)
            {
                return null;

            }
            else return null;


        }


        //string hojambazEtraby

        public static string Get_WPL_HojambazEtraby_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.HojambazEtraby)
            {

                return "Hojambaz etraby, ";
            }

            else if (!wpLocation.HojambazEtraby)
            {
                return null;

            }
            else return null;


        }

        //string serdarabatEtraby

        public static string Get_WPL_Serdarabat_e(IWorkPermitLocation wpLocation)
        {

          if (wpLocation.SerdarabatEtraby)
            {

                return "Serdarabat etraby, ";
            }

            else if (!wpLocation.SerdarabatEtraby)
            {
                return null;

            }
            else return null;


        }

        //string köýtendagEtraby

        public static string Get_WPL_Koytendag_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.KöýtendagEtraby)
            {

                return "Köýtendag etraby, ";
            }

            else if (!wpLocation.KöýtendagEtraby)
            {
                return null;

            }
            else return null;


        }

        //string beýikSaparmyratTürkmenbaşyAdEtraby

        public static string Get_WPL_BeyikSapTurkmenb_e(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.BeýikSaparmyratTürkmenbaşyAdEtraby)
            {

                return "Beýik Saparmyrat Türkmenbaşy adyndaky etrap, ";
            }

            else if (!wpLocation.BeýikSaparmyratTürkmenbaşyAdEtraby)
            {
                return null;

            }
            else return null;


        }

        //string döwletliEtraby

        public static string Get_WPL_Dowletli_e(IWorkPermitLocation wpLocation)
        {

            if (wpLocation.DöwletliEtraby)
            {

                return "Döwletli etraby, ";
            }

            else if (!wpLocation.DöwletliEtraby)
            {
                return null;

            }
            else return null;


        }

        //string seýdiŞäheri

        public static string Get_WPL_Seydi_s(IWorkPermitLocation wpLocation)
        {

           if (wpLocation.SeýdiŞäheri)
            {

                return "Seýdi şäheri, ";
            }

            else if (!wpLocation.SeýdiŞäheri)
            {
                return null;

            }
            else return null;


        }

        //string magdanlyŞäheri

        public static string Get_WPL_Magdanly_s(IWorkPermitLocation wpLocation)
        {

             if (wpLocation.MagdanlyŞäheri)
            {

                return "Magdanly şäheri, ";
            }

            else if (!wpLocation.MagdanlyŞäheri)
            {
                return null;

            }
            else return null;


        }

        public static string Get_WPL_Сollection(IWorkPermitLocation wpLocation)
        {





           
            

            string ashgabat = Get_WPL_Aşgabat_ş(wpLocation);
            //Ahal
           
            string baharlyEtraby = Get_WPL_Baharly_e(wpLocation);
            
            string gökdepeEtraby = Get_WPL_Gokdepe_e(wpLocation);
           
            string ruhabatEtraby = Get_WPL_Ruhabat_e(wpLocation);

            string akbugdaýEtraby = Get_WPL_Akbugday_e(wpLocation);

            string anewŞäheri = Get_WPL_Anew_s(wpLocation);
            string kakaEtraby = Get_WPL_Kaka_e(wpLocation);
            string tejenEtraby = Get_WPL_Tejen_e(wpLocation);
            string tejen = Get_WPL_Tejen_ş(wpLocation);


            string altynAsyrEtraby = Get_WPL_AltynAsyr_e(wpLocation);
            string babadaýhanEtraby = Get_WPL_Babadaýhan_e(wpLocation);
            string sarahsEtraby = Get_WPL_Sarahs_e(wpLocation);

            string abadanŞäheri = Get_WPL_Abadan_s(wpLocation);

            string ahal = baharlyEtraby + gökdepeEtraby +ruhabatEtraby+ akbugdaýEtraby + anewŞäheri + kakaEtraby + tejenEtraby + tejen + altynAsyrEtraby + babadaýhanEtraby + sarahsEtraby + abadanŞäheri;

            // Balkan
            string balkanabat = Get_WPL_Balkanabat_ş(wpLocation);
            string esengulyEtraby = Get_WPL_Esenguly_e(wpLocation); 
            string bereketEtraby = Get_WPL_Bereket_e(wpLocation);
            string bereketŞäheri = Get_WPL_Bereket_s(wpLocation);

            string serdarEtraby = Get_WPL_Serdar_e(wpLocation);

            string magtymgulyEtraby = Get_WPLMagtymguly_e(wpLocation);
            string etreketraby = Get_WPL_Etrek_e(wpLocation);

            string türkmenbaşyEtraby = Get_WPL_Turkmenbasy_e(wpLocation);



            string türkmenbaşyŞäheri=Get_WPL_Turkmenbasy_s(wpLocation);

            string gumdagŞäheri = Get_WPL_Gumdag_s(wpLocation);

            string hazarŞäheri = Get_WPL_Hazar_s(wpLocation);

            string garabogazŞäheri = Get_WPL_Garabogaz_s(wpLocation);


            string serdarŞäheri = Get_WPL_Serdar_s(wpLocation);

            string balkan = balkanabat + esengulyEtraby + bereketEtraby + bereketŞäheri + serdarEtraby + magtymgulyEtraby + etreketraby + türkmenbaşyEtraby + türkmenbaşyŞäheri + gumdagŞäheri + hazarŞäheri + garabogazŞäheri + serdarŞäheri;
            // Dasoguz

            string dashoguz = Get_WPL_Daşoguz_ş(wpLocation);
            string gurbansoltanEjeAdEtraby = Get_WPL_GurbansoltanE_e(wpLocation);

            string saparmyratTürkmenbaşyAdEetraby = Get_WPL_SaparTurmenbasy_e(wpLocation);

            string sANyýazowAdEtraby = Get_WPL_SANAd_e(wpLocation);

            string göroglyEtraby=Get_WPL_Gorogly_e(wpLocation);

            string boldumsazEtraby = Get_WPL_Boldumsaz_e(wpLocation);

            string köneürgençEtraby = Get_WPL_Koneurgenç_e(wpLocation);

            string akdepeEtraby = Get_WPL_Akdepe_e(wpLocation);

            string gubadagEtraby=Get_WPL_Gubadag_e(wpLocation);
            string ruhubelentEtraby = Get_WPL_Ruhubelent_e(wpLocation);



            string köneürgençŞäheri = Get_WPL_Koneurgenç_s(wpLocation);

            string dashoguzw = dashoguz + gurbansoltanEjeAdEtraby + saparmyratTürkmenbaşyAdEetraby + sANyýazowAdEtraby + göroglyEtraby + boldumsazEtraby + köneürgençEtraby + akdepeEtraby + gubadagEtraby + ruhubelentEtraby + köneürgençŞäheri;
            //Mary

            string mary = Get_WPL_Mary_ş(wpLocation);
            string baýramalyŞäheri = Get_WPL_Bayramaly_s(wpLocation);

            string wekilbazarEtraby = Get_WPL_Wekilbazar_e(wpLocation);

            string yolötenEtraby = Get_WPL_Yoloten_e(wpLocation);

            string yolötenŞäheri=Get_WPL_Yoloten_s(wpLocation);

            string garagumEtraby = Get_WPL_Garagum_e(wpLocation);

            string serhetabatŞäheri = Get_WPL_Serhetabat_s(wpLocation);

            string serhetabatEtraby = Get_WPL_Serhetabat_e(wpLocation);

            string maryEtraby = Get_WPL_Mary_e(wpLocation);

            string murgapEtraby = Get_WPL_Murgap_e(wpLocation);

            string oguzhanEtraby = Get_WPL_Oguzhan_e(wpLocation);

            string şatlykŞäheri=Get_WPL_Satlyk_s(wpLocation);

            string sakarçägeEtraby = Get_WPL_Sakarçage_e(wpLocation);

            string tagtabazarEtraby = Get_WPL_Tagtabazar_e(wpLocation);

            string türkmengalaEtraby = Get_WPL_Turkmengala_e(wpLocation);

            string altynSähraEtraby = Get_WPL_Altynsahra_e(wpLocation);

            string baýramalyEtraby = Get_WPL_Bayramaly_e(wpLocation);

            string maryw = mary + baýramalyŞäheri + wekilbazarEtraby + yolötenEtraby + yolötenŞäheri + garagumEtraby + 
            serhetabatŞäheri + serhetabatEtraby + maryEtraby
            + murgapEtraby + oguzhanEtraby + şatlykŞäheri + sakarçägeEtraby 
            + tagtabazarEtraby + türkmengalaEtraby + altynSähraEtraby + baýramalyEtraby;
            // Lebap
            string turkmenabat = Get_WPL_Türkmenabat_ş(wpLocation);
            string birataEtraby = Get_WPL_Birata_e(wpLocation);

            string gazojakŞäheri = Get_WPL_Gazojak_s(wpLocation);

            string garaşsyzlykEtraby = Get_WPL_Garasyzlyk_e(wpLocation);

            string galkynyşEtraby = Get_WPL_Galkynyş_e(wpLocation);

            string garabekewülEtraby = Get_WPL_Garabekewül_e(wpLocation);

            string atamyratEtraby = Get_WPL_Atamyrat_e(wpLocation);

            string atamyratŞäheri = Get_WPL_Atamyrat_s(wpLocation);

            string sakarEtraby = Get_WPL_Sakar_e(wpLocation);

            string saýatEtraby = Get_WPL_Sayat_e(wpLocation);

            string halaçEtraby = Get_WPL_Halaç_e(wpLocation);

            string farapEtraby = Get_WPL_Farap_e(wpLocation);

            string hojambazEtraby = Get_WPL_HojambazEtraby_e(wpLocation);

            string serdarabatEtraby = Get_WPL_Serdarabat_e(wpLocation);
            string köýtendagEtraby = Get_WPL_Koytendag_e(wpLocation);

            string beýikSaparmyratTürkmenbaşyAdEtraby = Get_WPL_BeyikSapTurkmenb_e(wpLocation);

            string döwletliEtraby = Get_WPL_Dowletli_e(wpLocation);

            string seýdiŞäheri = Get_WPL_Seydi_s(wpLocation);

            string magdanlyŞäheri = Get_WPL_Magdanly_s(wpLocation);

            string lebapw = turkmenabat + birataEtraby + gazojakŞäheri + garaşsyzlykEtraby + galkynyşEtraby + garabekewülEtraby + atamyratEtraby

            + atamyratŞäheri + sakarEtraby + saýatEtraby + halaçEtraby + farapEtraby + hojambazEtraby + serdarabatEtraby + köýtendagEtraby

            + beýikSaparmyratTürkmenbaşyAdEtraby + döwletliEtraby + seýdiŞäheri + magdanlyŞäheri;

            string wplocations = ashgabat + ahal + balkan + dashoguzw + maryw + lebapw;

            if (!String.IsNullOrEmpty(wplocations))
            {

                return wplocations.Remove(wplocations.Length - 2);
            }
            else return null;
            
        }


        #endregion

        #region ApplicationForWorkPermit

        public static IPersonInApplication Get_ApplicationFoWorkPermit(IPersonn person, DateTime wpIssuedDate)
        {
            if (person != null && person.EmployeeInApplications != null)
            {
                IPersonInApplication applicationForWP = null;

                foreach (var personInApp in person.EmployeeInApplications)
                {
                    if (personInApp.Application.ApplicationTypeForEmployee != null)
                    {
                        if ((personInApp.AppliedPerson.IsEmployee && personInApp.Application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForVisaExtention && personInApp.Application.IsWizaWithWorkPermit.WizaAndWorkPermitRequired == IsWPForWizaRequired.WizaAndWorkPermit && personInApp.Application.ManualApplicationDate < wpIssuedDate) | (personInApp.Application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee == SubType.ApplicationForInvitation && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.InvitationAndWorkPermit && personInApp.Application.ManualApplicationDate < wpIssuedDate))
                        {
                            applicationForWP = personInApp;

                            break;




                        }
                    }


                }
                return applicationForWP;
            }

            else return null;


        }



        #endregion


        public static IPersonInApplication Get_PersonInApplicationForVisaEmp(IPersonn person, IVisa visa)
        {
            // Employee


            IPersonInApplication appForVisa = null;

            foreach (var personInApp in person.EmployeeInApplications)
            {

                var apptype = personInApp.Application.SubType;


                switch (apptype)
                {

                    #region case
                    case SubType.ApplicationForInvitation:

                        if (personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;

                    case SubType.RugsatnamaMöhletineGöräÇakylyk:

                        if (personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;

                    case SubType.ApplicationForChangingPassport:

                        if (personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;


                    case SubType.ApplicationForChangingVisaCategory:

                        if (personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;

                    case SubType.ApplicationForVisaExtention:

                        if (personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;



                    #endregion


                }


            }

            return appForVisa;




        }


        public static IPersonInApplication Get_PersonInApplicationForVisaFM(IPersonn person, IVisa visa)
        {
            // Employee


            IPersonInApplication appForVisa = null;

            foreach (var personInApp in person.FamilyMemberInApplications)
            {

                var apptype = personInApp.Application.SubType;


                switch (apptype)
                {

                    #region case
                    case SubType.ApplicationForInvitation:

                        if (personInApp.Passport == visa.Passport && personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;

                    case SubType.ApplicationForChangingPassport:

                        if (personInApp.Passport == visa.Passport && personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;


                    case SubType.ApplicationForChangingVisaCategory:

                        if (personInApp.Passport == visa.Passport && personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate)
                        {
                            appForVisa = personInApp;
                        }
                        break;

                    case SubType.ApplicationForVisaExtention:

                        if (personInApp.Passport == visa.Passport && personInApp.Application.ManualApplicationDate <= visa.VisaIssuedDate | personInApp.Application.ProcessNumber == visa.ASNumber)
                        {
                            appForVisa = personInApp;
                        }
                        break;



                    #endregion


                }


            }

            return appForVisa;




        }

        public static IPersonInApplication Get_PersonInAppForVisa(IPersonn person, IVisa visa)
        {

            if ( person !=null && person.IsEmployee)
            {
                return Get_PersonInApplicationForVisaEmp(person, visa);


            }

            else if (person != null && person.IsFamilyMember)
            {

                return Get_PersonInApplicationForVisaFM(person, visa);
            }

            else return null;



        }

        public static int GetRemainingDaysBeforeExpire(DateTime dateOfExpire)
        {


            if (dateOfExpire >= DateTime.Today)
            {

                return (int)(dateOfExpire - DateTime.Today).TotalDays;


            }

            else return 0;


        }

        public static SubType Get_ApplicationType(IApplication application)
        {


            if (application != null && application.ForEmployee && application.ApplicationTypeForEmployee != null)
            {
                var apptype = application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee;
                switch (apptype)
                {

                    case SubType.ApplicationForInvitation:
                        return SubType.ApplicationForInvitation;
                    case SubType.RugsatnamaMöhletineGöräÇakylyk:
                        return SubType.RugsatnamaMöhletineGöräÇakylyk;
                    case SubType.ApplicationForChangingInvitation:
                        return SubType.ApplicationForChangingInvitation;
                    case SubType.ApplicationForSevicePasport:
                        return SubType.ApplicationForSevicePasport;
                    case SubType.ApplicationForVisaExtention:
                        return SubType.ApplicationForVisaExtention;
                    case SubType.ApplicationForBorderZonePermision:
                        return SubType.ApplicationForBorderZonePermision;
                    case SubType.ApplicationForCameFromBusinessTrip:
                        return SubType.ApplicationForCameFromBusinessTrip;
                    case SubType.ApplicationForCancellingVisaAndWorkpermit:
                        return SubType.ApplicationForCancellingVisaAndWorkpermit;
                    case SubType.ApplicationForCancellingVisa:
                        return SubType.ApplicationForCancellingVisa;
                    case SubType.ApplicationForCancellingWorkPermit:
                        return SubType.ApplicationForCancellingWorkPermit;
                    
                    case SubType.ApplicationForChagingInformation:
                        return SubType.ApplicationForChagingInformation;
                    case SubType.ApplicationForChangingPassport:
                        return SubType.ApplicationForChangingPassport;
                    case SubType.ApplicationForChangingVisaCategory:
                        return SubType.ApplicationForChangingVisaCategory;
                    case SubType.ApplicationForExtendingWorkPermitLocation:
                        return SubType.ApplicationForExtendingWorkPermitLocation;
                    case SubType.ApplicationForRegisteringToANewLocation:
                        return SubType.ApplicationForRegisteringToANewLocation;
                    case SubType.ApplicationForRegistrationExtention:
                        return SubType.ApplicationForRegistrationExtention;

                    case SubType.ApplicationForGoBusinessTrip:
                        return SubType.ApplicationForGoBusinessTrip;
                    case SubType.ApplicationForRegistrationUpOnArrival:
                        return SubType.ApplicationForRegistrationUpOnArrival;
                    case SubType.ApplicationForStrikeOffRegister:
                        return SubType.ApplicationForStrikeOffRegister;
                    case SubType.ApplicationForExitVisa:
                        return SubType.ApplicationForExitVisa;

                    default: return SubType.None;
                }






            }

            else if (application != null && application.ForFamilyMember && application.ApplicationTypeForFamilyMember != null)
            {
                var apptypeFM = application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMember;
                switch (apptypeFM)
                {

                    case SubType.ApplicationForInvitation:
                        return SubType.ApplicationForInvitation;
                    case SubType.ApplicationForChangingInvitation:
                        return SubType.ApplicationForChangingInvitation;
                    case SubType.ApplicationForSevicePasport:
                        return SubType.ApplicationForSevicePasport;
                    case SubType.ApplicationForVisaExtention:
                        return SubType.ApplicationForVisaExtention;
                    case SubType.ApplicationForBorderZonePermision:
                        return SubType.ApplicationForBorderZonePermision;
                    case SubType.ApplicationForCameFromBusinessTrip:
                        return SubType.ApplicationForCameFromBusinessTrip;
                    case SubType.ApplicationForCancellingVisaAndWorkpermit:
                        return SubType.ApplicationForCancellingVisaAndWorkpermit;
                    case SubType.ApplicationForCancellingVisa:
                        return SubType.ApplicationForCancellingVisa;
                    case SubType.ApplicationForCancellingWorkPermit:
                        return SubType.ApplicationForCancellingWorkPermit;
                    case SubType.ApplicationForChagingInformation:
                        return SubType.ApplicationForChagingInformation;
                    case SubType.ApplicationForChangingPassport:
                        return SubType.ApplicationForChangingPassport;
                    case SubType.ApplicationForChangingVisaCategory:
                        return SubType.ApplicationForChangingVisaCategory;
                    case SubType.ApplicationForExtendingWorkPermitLocation:
                        return SubType.ApplicationForExtendingWorkPermitLocation;
                    case SubType.ApplicationForRegisteringToANewLocation:
                        return SubType.ApplicationForRegisteringToANewLocation;
                    case SubType.ApplicationForRegistrationExtention:
                        return SubType.ApplicationForRegistrationExtention;

                    case SubType.ApplicationForGoBusinessTrip:
                        return SubType.ApplicationForGoBusinessTrip;
                    case SubType.ApplicationForRegistrationUpOnArrival:
                        return SubType.ApplicationForRegistrationUpOnArrival;
                    case SubType.ApplicationForStrikeOffRegister:
                        return SubType.ApplicationForStrikeOffRegister;

                    default: return SubType.None;
                }






            }

            else return SubType.None;

        }

        public static ApplicationStateEnum Get_ApplicationStateEmp(IApplication application)
        {
            if (application.ForEmployee && application.ApplicationTypeForEmployee != null)
            {

                var applicationType = application.ApplicationTypeForEmployee.TypeOfApplicationForEmployee;

                switch (applicationType)
                {
                    case DC.SubType.ApplicationForInvitation:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion

                    case DC.SubType.RugsatnamaMöhletineGöräÇakylyk:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion


                    case DC.SubType.ApplicationForChangingInvitation:
                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion

                    case DC.SubType.ApplicationForRegistrationUpOnArrival:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion


                    case DC.SubType.ApplicationForRegistrationExtention:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForRegisteringToANewLocation:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion



                    //    break;
                    case DC.SubType.ApplicationForChagingInformation:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion


                    //    break;
                    case DC.SubType.ApplicationForStrikeOffRegister:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForVisaExtention:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion
                    //    break;

                    case DC.SubType.ApplicationForExitVisa:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion
                    //    break;

                    case DC.SubType.ApplicationForChangingVisaCategory:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;



                        }

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion



                    //    break;
                    case DC.SubType.ApplicationForChangingPassport:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;



                        }

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion


                    //    break;
                    case DC.SubType.ApplicationForSevicePasport:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForBorderZonePermision:
                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckEmployeeStateInBZPermitNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckEmployeeStateInBZPermitNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion
                    //    break;

                    //    break;
                    case DC.SubType.ApplicationForCancellingVisaAndWorkpermit:
         
                        #region

                        if (!application.IsComplete)
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.IsComplete)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;

                      case DC.SubType.ApplicationForCancellingWorkPermitAndInvitation:
         
                        #region

                        if (!application.IsComplete)
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.IsComplete)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;
                        #endregion

                      case DC.SubType.ApplicationForExtendingWorkPermitLocation:

                        #region

                        if (!application.IsComplete)
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.IsComplete)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;
                        #endregion

                       case DC.SubType.ApplicationForCancellingVisa:


                        if (!application.IsComplete)
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.IsComplete)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForCancellingWorkPermit:



                        if (!application.IsComplete)
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.IsComplete)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                   case DC.SubType.ApplicationForGoBusinessTrip:
                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion


                    //    break;
                    //case DC.SubType.ApplicationForCameFromBusinessTrip:

                    //    break;
                    //case DC.SubType.ApplicationForExtendingWorkPermitLocation:

                    //    break;
                    //case DC.SubType.None:

                    //    break;

                    default: return ApplicationStateEnum.None;
                }

            }
            else return ApplicationStateEnum.None;


        }

        public static ApplicationStateEnum Get_ApplicationStateFM(IApplication application)
        {
            if (application.ForFamilyMember && application.ApplicationTypeForFamilyMember != null)
            {

                var applicationType = application.ApplicationTypeForFamilyMember.TypeOfApplicationForFamilyMember;

                switch (applicationType)
                {
                    case DC.SubType.ApplicationForInvitation:

                        #region
                        // office

                        if (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber))

                            return ApplicationStateEnum.Office;
                        // OnProcess
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !String.IsNullOrEmpty(application.ProcessNumber) && Helper.CheckPersonStateInInvitationNotProcessed(application))

                            return ApplicationStateEnum.OnProcess;

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !String.IsNullOrEmpty(application.ProcessNumber) && !Helper.CheckPersonStateInInvitationNotProcessed(application))

                            return ApplicationStateEnum.Processed;

                       //Processed




                        else return ApplicationStateEnum.None;

                        #endregion


                    case DC.SubType.ApplicationForChangingInvitation:
                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion

                    case DC.SubType.ApplicationForRegistrationUpOnArrival:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion


                    case DC.SubType.ApplicationForRegistrationExtention:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForRegisteringToANewLocation:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;


                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInRegistrationUpOnArrivalNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;


                        }
                        else return ApplicationStateEnum.None;

                        #endregion



                    //    break;
                    case DC.SubType.ApplicationForChagingInformation:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion


                    //    break;
                    case DC.SubType.ApplicationForStrikeOffRegister:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForVisaExtention:

                        #region
                        // office

                        if (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber))

                            return ApplicationStateEnum.Office;
                        // OnProcess
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !String.IsNullOrEmpty(application.ProcessNumber) && Helper.CheckPersonStateInVExtentionNotProcessed(application))

                            return ApplicationStateEnum.OnProcess;

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !String.IsNullOrEmpty(application.ProcessNumber) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))

                            return ApplicationStateEnum.Processed;

                       //Processed




                        else return ApplicationStateEnum.None;

                        #endregion

                    case DC.SubType.ApplicationForChangingVisaCategory:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;



                        }

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion



                    //    break;
                    case DC.SubType.ApplicationForChangingPassport:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.OnProcess;



                        }

                        else if (application.ProcessDate > new DateTime(2000, 01, 01) && !Helper.CheckPersonStateInVExtentionNotProcessed(application))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion


                    //    break;
                    case DC.SubType.ApplicationForSevicePasport:

                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckPersonStateInInvitationNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    case DC.SubType.ApplicationForBorderZonePermision:
                        #region
                        // office
                        if (application.DateForwardedToMonistery < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;
                        }
                        // >> Ministery
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.MinisteriesDocumentNumber)))
                        {

                            return ApplicationStateEnum.ToMinistery;

                        }
                        // Ministery >>
                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate < new DateTime(2000, 01, 01) | String.IsNullOrEmpty(application.ProcessNumber)))
                        {

                            return ApplicationStateEnum.FromMinistery;

                        }

                            // OnProcess

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && Helper.CheckEmployeeStateInBZPermitNotProcessed(application))
                        {

                            return ApplicationStateEnum.OnProcess;

                        }
                        //Processed

                        else if (application.DateForwardedToMonistery > new DateTime(2000, 01, 01) && (application.MinisteriesDocumentDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.MinisteriesDocumentNumber)) && (application.ProcessDate > new DateTime(2000, 01, 01) | !String.IsNullOrEmpty(application.ProcessNumber)) && !Helper.CheckEmployeeStateInBZPermitNotProcessed(application))
                        {

                            return ApplicationStateEnum.Processed;

                        }


                        else return ApplicationStateEnum.None;

                        #endregion
                    //    break;

                    //    break;
                    case DC.SubType.ApplicationForCancellingVisa:

                        #region

                        if (application.ProcessDate < new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Office;

                        }
                        else if (application.ProcessDate > new DateTime(2000, 01, 01))
                        {
                            return ApplicationStateEnum.Processed;



                        }

                        else return ApplicationStateEnum.None;

                        #endregion

                    //    break;
                    //case DC.SubType.ApplicationForGoBusinessTrip:

                    //    break;
                    //case DC.SubType.ApplicationForCameFromBusinessTrip:

                    //    break;
                    //case DC.SubType.ApplicationForExtendingWorkPermitLocation:

                    //    break;
                    //case DC.SubType.None:

                    //    break;

                    default: return ApplicationStateEnum.None;
                }

            }
            else return ApplicationStateEnum.None;


        }

        public static ApplicationStateEnum Get_ApplicationState(IApplication application)
        {

            if (application.ForFamilyMember)
            {

                return Helper.Get_ApplicationStateFM(application);

            }

            else if (application.ForEmployee)
            {
                return Helper.Get_ApplicationStateEmp(application);

            }

            else return ApplicationStateEnum.None;

        }

        public static ApplicationStateEnum GEt_PersonInAppStateEmp(IPersonInApplication personInApp)
        {

            if (personInApp.Cancelled)
            {

                return ApplicationStateEnum.Cancelled;
            }
            else 

            if (personInApp.Application != null)
            {
                SubType applicationType = personInApp.Application.SubType;

                switch (applicationType)
                {
                       
                    case DC.SubType.ApplicationForInvitation:
                        /*
                        if (personInApp.Invitation != null && personInApp.Application.IsInvitationWithWorkPermitVisibility == true && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.InvitationAndWorkPermit && personInApp.NewWorkPermit == null)
                        {
                            return ApplicationStateEnum.InvitationIssuedWorkPermitNot;
                        }
                            */
                         if (personInApp.Invitation != null)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.Invitation != null && personInApp.Application.IsInvitationWithWorkPermitVisibility == true && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.OnlyInvitation)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.Invitation == null && personInApp.RejectionLet == null)
                        {
                            return personInApp.Application.ApplicationState;
                        }


                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        else return ApplicationStateEnum.None;

                    case DC.SubType.RugsatnamaMöhletineGöräÇakylyk:

                        if (personInApp.Invitation != null && personInApp.Application.IsInvitationWithWorkPermitVisibility == true && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.InvitationAndWorkPermit)
                        {
                            return ApplicationStateEnum.InvitationIssuedWorkPermitNot;
                        }
                            
                        else if (personInApp.Invitation != null && personInApp.Application.IsInvitationWithWorkPermitVisibility == true && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.InvitationAndWorkPermit && personInApp.NewWorkPermit != null)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.Invitation != null && personInApp.Application.IsInvitationWithWorkPermitVisibility == true && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.OnlyInvitation)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.Invitation == null && personInApp.RejectionLet == null)
                        {
                            return personInApp.Application.ApplicationState;
                        }


                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        else return ApplicationStateEnum.None;
                    case DC.SubType.ApplicationForChangingInvitation:




                        if (personInApp.Invitation == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }


                        else if (personInApp.Invitation != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;


                    case DC.SubType.ApplicationForRegistrationUpOnArrival:

                        if (personInApp.RegistrationNumber != null)
                        {

                            return ApplicationStateEnum.Processed;
                        }

                        else return personInApp.Application.ApplicationState;


                    case DC.SubType.ApplicationForRegistrationExtention:

                        return personInApp.Application.ApplicationState;


                    //    break;
                    case DC.SubType.ApplicationForRegisteringToANewLocation:

                        if (personInApp.RegistrationNumber != null)
                        {

                            return ApplicationStateEnum.Processed;
                        }

                        else return personInApp.Application.ApplicationState;

                    //    break;
                    case DC.SubType.ApplicationForChagingInformation:

                        return personInApp.Application.ApplicationState;

                    //    break;
                    case DC.SubType.ApplicationForStrikeOffRegister:

                        return personInApp.Application.ApplicationState;
                    //    break;
                    case DC.SubType.ApplicationForVisaExtention:

                        if (personInApp.NewVisa != null)
                        {
                            return ApplicationStateEnum.Processed;
                        }
                            /*
                        else if (personInApp.NewVisa != null && personInApp.Application.IsWizaWithWorkPermitVisibility == true && personInApp.Application.IsWizaWithWorkPermit.WizaAndWorkPermitRequired == IsWPForWizaRequired.WizaAndWorkPermit && personInApp.NewWorkPermit != null)
                        {
                            return ApplicationStateEnum.Processed;
                        }
                            */

                        else if (personInApp.NewVisa != null && personInApp.Application.IsWizaWithWorkPermitVisibility == true && personInApp.Application.IsWizaWithWorkPermit.WizaAndWorkPermitRequired == IsWPForWizaRequired.OnlyWiza)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.NewVisa == null && personInApp.RejectionLet == null)
                        {
                            return personInApp.Application.ApplicationState;
                        }


                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForExitVisa:
                        return personInApp.Application.ApplicationState;


                    case DC.SubType.ApplicationForChangingVisaCategory:




                        if (personInApp.NewVisa == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }
                        else if (personInApp.NewVisa != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }



                        else return ApplicationStateEnum.None;
                    case DC.SubType.ApplicationForChangingPassport:


                        if (personInApp.NewVisa == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }
                        else if (personInApp.NewVisa != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForSevicePasport:



                        if (personInApp.Invitation == null && personInApp.RejectionLet == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }

                        else if (personInApp.Invitation != null)
                        {

                            return personInApp.Application.ApplicationState;

                        }
                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }
                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForBorderZonePermision:

                        if (personInApp.Visa.HasBorderZonePermit != true && personInApp.RejectionLet == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }

                        else if (personInApp.Visa.HasBorderZonePermit == true && personInApp.RejectionLet == null)
                        {

                            return ApplicationStateEnum.Processed;

                        }
                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }
                        else return ApplicationStateEnum.None;
                    case DC.SubType.ApplicationForCancellingVisaAndWorkpermit:

                        return personInApp.Application.ApplicationState;

                    case DC.SubType.ApplicationForCancellingVisa:

                        return personInApp.Application.ApplicationState;
                    case DC.SubType.ApplicationForCancellingWorkPermit:

                        return personInApp.Application.ApplicationState;

                    case DC.SubType.ApplicationForGoBusinessTrip:

                        return personInApp.Application.ApplicationState;

                    default: return ApplicationStateEnum.None;


                }
            }

            else return ApplicationStateEnum.None;


        }

        public static ApplicationStateEnum GEt_PersonInAppStateFM(IPersonInApplication personInApp)
        {
            if (personInApp.Cancelled)
            {

                return ApplicationStateEnum.Cancelled;
            }
            else 

            if (personInApp.Application != null)
            {
                SubType applicationType = personInApp.Application.SubType;

                switch (applicationType)
                {
                    case DC.SubType.ApplicationForInvitation:


                        if (personInApp.Invitation != null)
                        {
                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.Invitation == null && personInApp.RejectionLet == null)
                        {
                            return personInApp.Application.ApplicationState;
                        }

                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        else return ApplicationStateEnum.None;


                    case DC.SubType.ApplicationForChangingInvitation:

                        if (personInApp.Application.ApplicationState != ApplicationStateEnum.Processed)
                        {
                            return personInApp.Application.ApplicationState;
                        }
                        else if (personInApp.Invitation != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;


                    case DC.SubType.ApplicationForRegistrationUpOnArrival:

                        if (personInApp.RegistrationNumber != null)
                        {

                            return ApplicationStateEnum.Processed;
                        }

                        else return personInApp.Application.ApplicationState;


                    case DC.SubType.ApplicationForRegistrationExtention:

                        return personInApp.Application.ApplicationState;


                    //    break;
                    case DC.SubType.ApplicationForRegisteringToANewLocation:

                        if (personInApp.RegistrationNumber != null)
                        {

                            return ApplicationStateEnum.Processed;
                        }

                        else return personInApp.Application.ApplicationState;

                    //    break;
                    case DC.SubType.ApplicationForChagingInformation:

                        return personInApp.Application.ApplicationState;

                    //    break;
                    case DC.SubType.ApplicationForStrikeOffRegister:

                        return personInApp.Application.ApplicationState;
                    //    break;
                    case DC.SubType.ApplicationForVisaExtention:

                        if (personInApp.NewVisa == null && personInApp.RejectionLet == null)
                        {
                            return personInApp.Application.ApplicationState;
                        }

                        else if (personInApp.NewVisa != null)
                        {

                            return ApplicationStateEnum.Processed;
                        }

                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForChangingVisaCategory:


                        if (personInApp.NewVisa == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }

                        else if (personInApp.NewVisa != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }



                        else return ApplicationStateEnum.None;
                    case DC.SubType.ApplicationForChangingPassport:


                        if (personInApp.NewVisa == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }
                        else if (personInApp.NewVisa != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }



                        else return ApplicationStateEnum.None;

                    case DC.SubType.ApplicationForSevicePasport:


                        if (personInApp.Invitation == null && personInApp.RejectionLet == null)
                        {

                            return personInApp.Application.ApplicationState;

                        }
                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }

                        if (personInApp.Invitation != null)
                        {

                            return ApplicationStateEnum.Processed;

                        }

                        else return ApplicationStateEnum.None;
                    case DC.SubType.ApplicationForBorderZonePermision:

                        if (personInApp.Visa.HasBorderZonePermit != true)
                        {

                            return personInApp.Application.ApplicationState;

                        }

                        else if (personInApp.Visa.HasBorderZonePermit == true)
                        {
                            return ApplicationStateEnum.Processed;

                        }

                        else if (personInApp.RejectionLet != null)
                        {
                            return ApplicationStateEnum.Rejected;

                        }
                        else return ApplicationStateEnum.None;



                    default: return ApplicationStateEnum.None;


                }
            }

            else return ApplicationStateEnum.None;


        }

        public static bool CheckPersonStateInInvitationNotProcessed(IApplication application)
        {
            bool isNull = false;
            foreach (var person in application.PersonInApplication)
            {

                
                if (person.Invitation == null && person.RejectionLet == null && person.Invitation == null && !person.Cancelled && !person.Rejected && !person.IsComplete)
                {



                    isNull = true;

                    break;



                }
                
                /*
                if (person.PersonState == ApplicationStateEnum.OnProcess
                    | person.PersonState == ApplicationStateEnum.Office
                    | person.PersonState == ApplicationStateEnum.FromMinistery
                    | person.PersonState == ApplicationStateEnum.OnProcess
                    | person.PersonState == ApplicationStateEnum.ToMinistery
                    )
                {



                    isNull = true;

                    break;



                }
                */
            }


            return isNull;

        }

        public static bool CheckPersonStateInRegistrationUpOnArrivalNotProcessed(IApplication application)
        {
            bool isNull = false;
            foreach (var person in application.PersonInApplication)
            {


                if (String.IsNullOrEmpty(person.RegistrationNumber))
                {



                    isNull = true;

                    break;



                }



            }


            return isNull;

        }

        public static bool CheckPersonStateInVExtentionNotProcessed(IApplication application)
        {
            bool isNull = false;
            foreach (var person in application.PersonInApplication)
            {


                if (person.NewVisa == null && person.RejectionLet == null)
                {



                    isNull = true;

                    break;



                }



            }


            return isNull;

        }

        public static bool CheckPersonStateInChangeInvitationNotProcessed(IApplication application)
        {
            bool isNull = false;
            foreach (var person in application.PersonInApplication)
            {


                if (person.ApplicationForChangingInvitation == null)
                {



                    isNull = true;

                    break;



                }



            }


            return isNull;

        }

        public static bool CheckEmployeeStateInBZPermitNotProcessed(IApplication application)
        {
            bool isNull = false;
            foreach (var emp in application.PersonInApplication)
            {


                if (emp.Visa.HasBorderZonePermit == false)
                {



                    isNull = true;

                    break;



                }



            }


            return isNull;

        }

        public static IApplicationResult Get_Invit(IApplication app, IPersonn person)
        {

            IApplicationResult invit = null;

            if (app.ForEmployee && person != null && person.EmployeeInResult != null)
            {
                foreach (var pInInvitation in person.EmployeeInResult)
                {

                    foreach (var pInApp in person.EmployeeInApplications)
                    {
                        if (pInInvitation != null && pInInvitation.Invitation != null && pInApp != null && pInInvitation.Invitation.Application == app && pInInvitation.Invitation.Result == ApplicationResultEnum.Invitation)
                        {

                            invit = pInInvitation.Invitation;
                            break;
                        }

                    }



                }
            }

            else if (app.ForFamilyMember && person != null && person.FamilyMemberInResult != null)
            {

                foreach (var pInInvitation in person.FamilyMemberInResult)
                {

                    foreach (var pInApp in person.FamilyMemberInApplications)
                    {
                        if (pInInvitation != null && pInInvitation.Invitation != null && pInApp != null && pInInvitation.Invitation.Application == app && pInInvitation.Invitation.Result == ApplicationResultEnum.Invitation)
                        {

                            invit = pInInvitation.Invitation;
                            break;
                        }

                    }



                }


            }
            return invit;

        }

        public static IApplicationResult Get_Rejection(IApplication app, IPersonn person)
        {

            IApplicationResult invit = null;

            if (app.ForEmployee && person != null && person.EmployeeInResult != null)
            {
                foreach (var pInInvitation in person.EmployeeInResult)
                {

                    foreach (var pInApp in person.EmployeeInApplications)
                    {
                        if (pInInvitation != null && pInInvitation.Invitation != null && pInApp != null && pInInvitation.Invitation.Application == app && pInInvitation.Invitation.Result == ApplicationResultEnum.Rejection)
                        {

                            invit = pInInvitation.Invitation;
                            break;
                        }

                    }



                }
            }

            else if (app.ForFamilyMember && person != null && person.FamilyMemberInResult != null)
            {

                foreach (var pInInvitation in person.FamilyMemberInResult)
                {

                    foreach (var pInApp in person.FamilyMemberInApplications)
                    {
                        if (pInInvitation != null && pInInvitation.Invitation != null && pInApp != null && pInInvitation.Invitation.Application == app && pInInvitation.Invitation.Result == ApplicationResultEnum.Rejection)
                        {

                            invit = pInInvitation.Invitation;
                            break;
                        }

                    }



                }


            }
            return invit;

        }


        public static IUrgency Get_Urgency(SubType st, IObjectSpace obspace)
        {
            var urgencyOranGyssagly = obspace.FindObject<IUrgency>(new BinaryOperator("Priority", 1));

            var urgencyGyssagly = obspace.FindObject<IUrgency>(new BinaryOperator("Priority", 2));

            var urgencyAdaty = obspace.FindObject<IUrgency>(new BinaryOperator("Priority", 3));


            switch (st)
            {
                case SubType.ApplicationForInvitation:

                    return urgencyGyssagly;

                case SubType.RugsatnamaMöhletineGöräÇakylyk:

                    return urgencyGyssagly;

                case SubType.ApplicationForBorderZonePermision:
                    return urgencyGyssagly;

                case SubType.ApplicationForChangingPassport:
                    return urgencyAdaty;

                case SubType.ApplicationForChangingVisaCategory:
                    return urgencyAdaty;

                case SubType.ApplicationForSevicePasport:
                    return urgencyGyssagly;

                case SubType.ApplicationForVisaExtention:
                    return urgencyAdaty;
                default: return urgencyAdaty;


            }




        }

        public static string GetBorderZoneCollectionForPersonInApplication(IPersonInApplication personInApplication)
        {

            if (personInApplication.Application != null)
            {
                SubType app = personInApplication.Application.SubType;

                switch (app)
                {
                    case SubType.ApplicationForBorderZonePermision:

                        return personInApplication.Application.BorderZoneCollectionForLine;

                    case SubType.ApplicationForCameFromBusinessTrip:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForCancellingVisaAndWorkpermit:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForCancellingVisa:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForCancellingWorkPermit:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForChagingInformation:

                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForChangingInvitation:

                        return personInApplication.Application.BorderZoneCollectionForLine;
                    case SubType.ApplicationForChangingPassport:

                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForChangingVisaCategory:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForExtendingWorkPermitLocation:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForGoBusinessTrip:

                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForInvitation:
                        return personInApplication.Application.BorderZoneCollectionForLine;
                    case SubType.RugsatnamaMöhletineGöräÇakylyk:
                        return personInApplication.Application.BorderZoneCollectionForLine;

                    case SubType.ApplicationForRegisteringToANewLocation:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForRegistrationExtention:

                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForRegistrationUpOnArrival:

                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;
                    case SubType.ApplicationForSevicePasport:

                        return personInApplication.Application.BorderZoneCollectionForLine;

                    case SubType.ApplicationForStrikeOffRegister:
                        if (personInApplication.Visa != null && personInApplication.Visa.HasBorderZonePermit)
                        {

                            return personInApplication.Visa.BorderZone.BorderZoneCollectionForVisa;
                        }
                        else return null;

                    case SubType.ApplicationForVisaExtention:
                        return personInApplication.Application.BorderZoneCollectionForLine;
                    default: return null;
                }

            }

            else return null;
        }

        public static IPersonInApplication GetLastRegistrationFM(IPersonn p)
        {
            IPersonInApplication app = null;
            IPersonInApplication temp = null; ;

            foreach (var personInApp in p.FamilyMemberInApplications)
            {

                if (personInApp.ApplicationType == SubType.ApplicationForRegisteringToANewLocation || personInApp.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival)
                {
                    temp = personInApp;

                    if (temp != null && personInApp.Application != null && personInApp.Application.ManualApplicationDate >= temp.Application.ManualApplicationDate)
                    {

                        app = personInApp;


                        break;
                    }




                }

            }
            return app;



        }

        public static IPersonInApplication GetLastRegistrationEmp(IPersonn p)
        {
            IPersonInApplication app = null;
           List< IPersonInApplication> temp = new List<IPersonInApplication>(); ;

            foreach (var personInApp in p.EmployeeInApplications)
            {

                if (personInApp.ApplicationType == SubType.ApplicationForRegisteringToANewLocation || personInApp.ApplicationType == SubType.ApplicationForRegistrationUpOnArrival)
                {
                    temp.Add( personInApp);

                 
                    app =temp. OrderByDescending(t => t.Application.ManualApplicationDate).First(); 



                }

            }

            if (app != null && app.Application !=null && app.Application.RegistrationDate !=null && p.LastTravelInfo !=null && app.Application.ManualApplicationDate >= p.LastTravelInfo.TravelDate) 

            {
            

            return app ;
         

            }

            else return null;
            
           
           

        }

        public static IPersonInApplication GetLastStrikeOffFM(IPersonn p)
        {
            IPersonInApplication app = null;
            IPersonInApplication temp = null; ;

            foreach (var personInApp in p.FamilyMemberInApplications)
            {

                if (personInApp.ApplicationType == SubType.ApplicationForStrikeOffRegister)
                {
                    temp = personInApp;

                    if (temp != null && personInApp.Application != null && personInApp.Application.ManualApplicationDate >= temp.Application.ManualApplicationDate && personInApp.AppliedPerson.LastRegistration != null && temp.AppliedPerson.LastRegistration.Application.ManualApplicationDate >= p.LastTravelInfo.TravelDate)
                    {

                        app = personInApp;


                        break;
                    }
                    else if (temp != null && personInApp.Application != null && personInApp.Application.ManualApplicationDate >= temp.Application.ManualApplicationDate && personInApp.AppliedPerson.LastRegistration == null)
                    {

                        app = personInApp;


                        break;
                    }




                }

            }
            return app;



        }


        public static IPersonInApplication GetLastStrikeOffEmp(IPersonn p)
        {
            IPersonInApplication app = null;
            IPersonInApplication temp = null; ;

            foreach (var personInApp in p.EmployeeInApplications)
            {

                if (personInApp.ApplicationType == SubType.ApplicationForStrikeOffRegister)
                {
                    temp = personInApp;

                    if (temp != null && personInApp.Application.ApplicationFor ==ApplicationForEnum.Employee && personInApp.Application != null && personInApp.Application.ManualApplicationDate >= temp.Application.ManualApplicationDate && personInApp.AppliedPerson.LastRegistration != null && personInApp.AppliedPerson.LastRegistration.Application.ManualApplicationDate < personInApp.Application.ManualApplicationDate)
                    {

                        app = personInApp;


                        break;


                    }

                    else if (temp != null && personInApp.Application.ApplicationFor == ApplicationForEnum.Employee && personInApp.Application != null && personInApp.Application.ManualApplicationDate >= temp.Application.ManualApplicationDate && personInApp.AppliedPerson.LastRegistration == null)
                    {

                        app = personInApp;


                        break;
                    }




                }

            }
            return app;



        }


        public static IPersonInApplication GetLastInvitationEmp(IPersonn person)
        {

            IPersonInApplication app=null;
            List<IPersonInApplication> temp = new List<IPersonInApplication>();

            foreach (var personInApp in person.EmployeeInApplications)
            {
                app = personInApp;

                if (personInApp.ApplicationType == SubType.ApplicationForInvitation | personInApp.ApplicationType == SubType.ApplicationForChangingInvitation | personInApp.ApplicationType == SubType.RugsatnamaMöhletineGöräÇakylyk)  
                {
                           
                            
                   temp.Add(personInApp);
                   
                   
                   

                }




            }
            if (temp.Count!=0 && app !=null)
            {
                app = temp.OrderByDescending(t => t.Application.ManualApplicationDate).First();
            }
            else
            { app = null; }
            return app;


             


        }


        public static IPersonInApplication GetLastInvitationFM(IPersonn person)
        {

            IPersonInApplication app = null;
            List<IPersonInApplication> temp = new List<IPersonInApplication>();

            foreach (var personInApp in person.FamilyMemberInApplications)
            {
                app = personInApp;

                if (personInApp.ApplicationType == SubType.ApplicationForInvitation | personInApp.ApplicationType == SubType.ApplicationForChangingInvitation | personInApp.ApplicationType == SubType.RugsatnamaMöhletineGöräÇakylyk)
                {


                    temp.Add(personInApp);




                }




            }
            if (temp.Count != 0 && app != null)
            {
                app = temp.OrderByDescending(t => t.Application.ManualApplicationDate).First();
            }
            else
            { app = null; }
            return app;


        }


        public static int CountForeignEmpInWP(IWorkPermitLetter wpletter)
        {

            int countwp = 0;
            foreach (var wp in wpletter.WorkPermits)
            {

                if (wp == wp.Employee.LastWorkPermit && wp.WorkPermitState != WorkPermitStateEnum.CANCELLED && wp.RemainingDays != 0)
                {

                    countwp++;

                }




            }

            return countwp;


        }


        public static int CountForeignEmpInWPLetter(ICompany company)
        {

            int countwp = 0;
            foreach (var wpl in company.WorkPermitLetter)
            {

                if (wpl.CountWP > 0)
                {

                    countwp = countwp + wpl.CountWP;

                }




            }

            return countwp;


        }

        public static IPersonInResult GetPersonInResultEmp(IPersonn person, IPersonInApplication personInApp)
        {

            if (person.IsEmployee && person.EmployeeInResult.Count > 0)
            {
                IPersonInResult pInResult = null;
                foreach (var employeeInResult in person.EmployeeInResult)
                {
                   
                    if (employeeInResult.Invitation == personInApp.Invitation)
                    {

                        pInResult = employeeInResult;
                       
                    } 

                }
                return pInResult;


            }
            else return null;
        
        
        }

        public static IPersonInResult GetPersonInResultFM(IPersonn person, IPersonInApplication personInApp)
        {

            if (person.IsFamilyMember && person.FamilyMemberInResult.Count > 0)
            {
                IPersonInResult pInResult = null;
                foreach (var employeeInResult in person.EmployeeInResult)
                {

                    if (employeeInResult.Invitation == personInApp.Invitation)
                    {

                        pInResult = employeeInResult;

                    }

                }
                return pInResult;


            }
            else return null;


        }

        public static IPersonInResult GetPersonInResult(IPersonn person, IPersonInApplication personInApp)
        {

            if (person.IsEmployee)
            {

                return Helper.GetPersonInResultEmp(person, personInApp);


            }
            else if (person.IsFamilyMember)
            {

                return Helper.GetPersonInResultFM(person, personInApp);

            }
            else return null;


        }

        public static bool GetEmployeeIsValid(IPersonn person , IPersonInResult personInResult)

        {

            if (person.IsEmployee && person.EmployeeInApplications.Count > 0 && personInResult!=null)
            {
                bool isValid = false;

                foreach (var personInApp in person.EmployeeInApplications)
                {

                    if (personInApp.Application == personInResult.Invitation.Application)
                    {
                        isValid = true;

                        break;
                    }


                }
                return isValid;


            }
            else return false;
        
        }

        public static bool GetFamilyMemberIsValid(IPersonn person, IPersonInResult personInResult)
        {

            if (person.IsFamilyMember && person.FamilyMemberInApplications.Count > 0 && personInResult != null)
            {
                bool isValid = false;

                foreach (var personInApp in person.FamilyMemberInApplications)
                {

                    if (personInApp.Application == personInResult.Invitation.Application)
                    {
                        isValid = true;

                        break;
                    }


                }
                return isValid;


            }
            else return false;

        }


        public static bool GetPersonIsValid(IPersonn person, IPersonInResult personInResult)
        {

            if (person.IsEmployee)
            {

                return Helper.GetEmployeeIsValid(person, personInResult);


            }
            else if (person.IsFamilyMember)
            {

                return Helper.GetFamilyMemberIsValid(person, personInResult);


            }
            else return false;


        }


    }
}
