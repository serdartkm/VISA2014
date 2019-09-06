using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using Spire.Pdf.Widget;
using System.Drawing;
using DevExpress.ExpressApp;

namespace VISA2014.Module.DC
{
    class Helperd
    {

        public static void FillPDFForm(IApplication app, IObjectSpace os) {
            IPersonInApplication person = app.PersonInApplication.First();
            PdfDocument pdfdoc = new PdfDocument();
            pdfdoc.LoadFromFile(@"d:\Visa_Application_TM_QR_08.pdf");
            PdfFormWidget form = pdfdoc.Form as PdfFormWidget;
            if (form.XFAForm != null)
            {
                List<XfaField> loFields = form.XFAForm.XfaFields;
                for (int i = 0; i < loFields.Count; i++)
                {

                    //.1.SURAT
                    if (loFields[i] is XfaImageField)
                    {
                        Image image = Image.FromFile(@"d:\person.jpeg");
                        (loFields[i] as XfaImageField).Image = person.Employee.Photo;


                    }

                    //----------------YUZTUTMANYN MAGLUMATLARY
                    //2.Yuztutmanyn gornusi
                
                    if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0].L01[0]")
                    {

                        Console.WriteLine((loFields[i] as XfaChoiceListField).Name);
                        (loFields[i] as XfaChoiceListField).SelectedItem = "3";

                    }


                    //FAMILIYASY
                    if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0].L03[0]")
                    {
                        Console.WriteLine((loFields[i] as XfaTextField).Name);
                        (loFields[i] as XfaTextField).Value = "Amanow";

                    }


                    if (loFields[i] is XfaCheckButtonField && (loFields[i] as XfaCheckButtonField).Name == "topmostSubform[0].Page1[0].IP[1].#field[0]")
                    {
                        Console.WriteLine((loFields[i] as XfaCheckButtonField).Name);
                        (loFields[i] as XfaCheckButtonField).Checked = true;
                        //"topmostSubform[0].Page1[0].IP[1].#field[0]"
                    }

                    if (loFields[i] is XfaCheckButtonField && (loFields[i] as XfaCheckButtonField).Name == "topmostSubform[0].Page1[0].IP[0].IP[0]")
                    {
                        Console.WriteLine((loFields[i] as XfaCheckButtonField).Name);
                        (loFields[i] as XfaCheckButtonField).Checked = false;
                        //"topmostSubform[0].Page1[0].IP[1].#field[0]"
                    }
                 
                  

                
                    //form.XFAForm[form.XFAForm.Fields[i]] = "Hello";
                }

            }
            pdfdoc.SaveToFile(@"d:\visanew.pdf");
          



        
        }





        private static string GetAppType(string typeInApp) {

            //IN PDF----------------
            //1.WIZA RESMILESDIRMEK
            //2.CAKYLIK
            //3. WIZA MOHLETINI UZALTMAK
            //5.BIRGEZEKDEN KOPE GECMEK
            //6.PASPORTDAN PASPORTA GECMEK
            //8.kopgezeklikden bir gezeklige gecmek
            //9.CYKYS VISA RESMILESDIRMEK
            //20.GOSM -GOSMACA
            //23.GECM -IS YERINI UYTGETMEK
            //21.RUGS -RUGSATNAMA BERMEK
            //24.UZGM -VISA UZALTMAK VE IS YERINI UYTGETMEK
            //25.SERH -SERHET YAKA GITMEK


            switch (typeInApp)
            { 
                case "1":
                    return "2";
                case "2":
                    return "2";
                default:
                    return "2";
            }
            return "";
        }


        private static string GetUrgency (string typeInPDF ){
             //--IN PDF
             //1 ADATY
             // 2 TIZ
             // 3 ORAN TIZ
            return "";
        }

        private static string GetGender(string typeInPDF)
        {
            //--IN PDF
            //1 M
            //2 F
            //3 X
            return "";
        }


        private static string GetCountry(string typeInPDF)
        {
            //--IN PDF
            /*
     <items>
        <text> </text>
        <text>ABW-ARUBA</text>
        <text>AFG-OWGANYSTAN</text>
        <text>AGO-ANGOLA</text>
        <text>AIA-ANGUILLA</text>
        <text>ALA-ALAND ISLANDS</text>
        <text>ALB-ALBANIYA</text>
        <text>AND-ANDORRA</text>
        <text>ANT-ANTIL ADALARY</text>
        <text>ARE-BIRLESEN ARAB EMIR</text>
        <text>ARG-ARGENTINA</text>
        <text>ARM-ERMENISTAN</text>
        <text>ASM-AMERIKAN SAMOA</text>
        <text>ATA-ANTARKTIKA</text>
        <text>ATF-FRANSUZ GUNBATAR YERI</text>
        <text>ATG-ANTIGUA WE BARBUDA</text>
        <text>AUS-AWSRTRALIYA</text>
        <text>AUT-AWSTRIYA</text>
        <text>AZE-AZERBEYJAN</text>
        <text>BDI-BURUNDI</text>
        <text>BEL-BELGIYA</text>
        <text>BEN-BENIN</text>
        <text>BFA-BURKINA-FASO</text>
        <text>BGD-BANGLADES</text>
        <text>BGR-BOLGARIYA</text>
        <text>BHR-BAHREYN</text>
        <text>BHS-BAGAM ADALARY</text>
        <text>BIH-BOSNIYA WE GERSEGOWINA</text>
        <text>BLR-BELARUS</text>
        <text>BLZ-BELIZ</text>
        <text>BMU- BERMUD ADALARY</text>
        <text>BOL-BOLIVIYA</text>
        <text>BRA-BRAZILIYA</text>
        <text>BRB-BARBADOS</text>
        <text>BRN-BRUNEY DRASSALAM</text>
        <text>BTN-BUTAN</text>
        <text>BVT-BOWE</text>
        <text>BWA-BOTSVANA</text>
        <text>CAF-MERKEZI AFRIKA RESPUB</text>
        <text>CAN-KANADA</text>
        <text>CCK-KOKOS ADALARY (AWSTRALIYA)</text>
        <text>CHE-SWEYSARIYA</text>
        <text>CHL-CHILI</text>
        <text>CHN-HYTAY</text>
        <text>CIV-KOT-DIWUAR</text>
        <text>CMR-KAMERUN</text>
        <text>COD-KONGO</text>
        <text>COK-KUK ADALARY</text>
        <text>COL-KOLUMBIYA</text>
        <text>COM-KOMOR ADALARY</text>
        <text>CPV-KABO-WERDE</text>
        <text>CRI-KOSTA-RIKA</text>
        <text>CYP-KIPR</text>
        <text>CUB-KUBA</text>
        <text>CXR-ROJDESTWO ADASY</text>
        <text>CYM-KAYMAN ADALARY (BRITANIYA)</text>
        <text>CZE-CHEHIYA</text>
        <text>DEU-GERMANIYA</text>
        <text>DJI-JIBUTI</text>
        <text>DMA-DOMINIKA</text>
        <text>DNK-DANIYA</text>
        <text>DOM-DOMINIKAN RESPUBLIK</text>
        <text>DZA-ALJIR</text>
        <text>ECU-EKWADOR</text>
        <text>EGY-MUSUR</text>
        <text>ERI-ERITREYA</text>
        <text>ESH - SAHARA GUNBATAR</text>
        <text>ESP-ISPANIYA</text>
        <text>EST-ESTONIYA</text>
        <text>ETH-EFIOPIYA</text>
        <text>FIN-FINLYANDIYA</text>
        <text>FJI-FIJI</text>
        <text>FLK-FOLKLEND ADALARY</text>
        <text>FRA-FRANSIYA</text>
        <text>FRO-FARER ADALARY</text>
        <text>FSM-MIKRONEZIYA</text>
        <text>GAB-GABON</text>
        <text>GBR-WELIKOBRITANIYA</text>
        <text>GEO-GRUZIYA</text>
        <text>GGY-GUERNSEY</text>
        <text>GHA-GANA</text>
        <text>GIB-GIBRALTAR</text>
        <text>GIN-GWINEYA</text>
        <text>GLP-GWADELUPA</text>
        <text>GMB-GAMBIYA</text>
        <text>GNB-GWINEYA BISAU</text>
        <text>GNQ-EKWATORIAL GWINEA</text>
        <text>GRC-GRESIYA</text>
        <text>GRD-GRENADA</text>
        <text>GRL-GRENLANDIYA</text>
        <text>GTM-GWATEMALA</text>
        <text>GUF-GWIANA</text>
        <text>GUM-GUAM</text>
        <text>GUY-GAYANA</text>
        <text>HKG-GONKONG</text>
        <text>HMD-HERD WE MAKDONALD</text>
        <text>HND-GONDURAS</text>
        <text>HRV-HORWATIYA</text>
        <text>HTI-GAITI</text>
        <text>HUN-WENGRIYA</text>
        <text>IDN-INDONEZIYA</text>
        <text>IMM-ISLE OF MAN</text>
        <text>IND-HINDISTAN</text>
        <text>IOT-HINDI OKEAN BRITAN YERI</text>
        <text>IRL-IRLANDIYA</text>
        <text>IRN-EYRAN</text>
        <text>IRQ-IRAK</text>
        <text>ISL-ISLANDIYA</text>
        <text>ISR-IZRAIL</text>
        <text>ITA-ITALIYA</text>
        <text>JAM-YAMAYKA</text>
        <text>JEY-JERSEY</text>
        <text>JOR-IORDANIYA</text>
        <text>JPN-YAPONIYA</text>
        <text>KAZ-GAZAGYSTAN</text>
        <text>KEN-KENIYA</text>
        <text>KGZ-GYRGYZSTAN</text>
        <text>KHM-KAMBODJA</text>
        <text>KIR-KIRIBATI</text>
        <text>KNA-SENT KITS WE NEWS</text>
        <text>KOR-KOREYA RESPUBLIKA</text>
        <text>KWT-KUWEYT</text>
        <text>LAO-LAOS</text>
        <text>LBN-LIVAN</text>
        <text>LBR-LIBERIYA</text>
        <text>LBY-LIWIYA</text>
        <text>LCA-SENT LUSIYA</text>
        <text>LIE-LIHTENSTEIN</text>
        <text>LKA-SRI LANKA</text>
        <text>LSO-LESOTO</text>
        <text>LTU-LITWA</text>
        <text>LUX-LUKSEMBURG</text>
        <text>LVA-LATWIYA</text>
        <text>MAC-MAKAO</text>
        <text>MAR-MAROKKO</text>
        <text>MCO-MONAKO</text>
        <text>MDA-MOLDOWA</text>
        <text>MDG-MADAKASKAR</text>
        <text>MDV-MALDIWY</text>
        <text>MEX-MEKSIKA</text>
        <text>MHL-MARSHAL ADALARY</text>
        <text>MKD-MAKEDONIYA</text>
        <text>MLI-MALI</text>
        <text>MLT-MALTA</text>
        <text>MMR-MYANMA</text>
        <text>MNE-MONTENEGRO</text>
        <text>MNG-MONGOLIYA</text>
        <text>MNP-DEMIRGAZYK MARIAN ADA</text>
        <text>MOZ-MOZAMBIK</text>
        <text>MRT-MAWRITANIYA</text>
        <text>MSR-MONTSERRAT</text>
        <text>MTQ-MARTINIKA</text>
        <text>MUS-MAWRIKIY</text>
        <text>MWI-MALAWI</text>
        <text>MYS-MALAYZIYA</text>
        <text>MYT-MAYOTTA</text>
        <text>NAM-NAMIBIYA</text>
        <text>NCL-TAZE KALEDONIYA</text>
        <text>NER-NIGER</text>
        <text>NFK-NORFOLK</text>
        <text>NGA-NIGERIYA</text>
        <text>NIC-NIKARAGUA</text>
        <text>NIU-NIUE</text>
        <text>NLD-NIDERLANDY</text>
        <text>NOR-NORWEGIYA</text>
        <text>NPL-NEPAL</text>
        <text>NRU-NAURU</text>
        <text>NZL-TAZE ZELANDIYA</text>
        <text>OMN-OMAN</text>
        <text>OTH-OTHERS(BEYLEKILER)</text>
        <text>PAK-PAKISTAN</text>
        <text>PAN-PANAMA</text>
        <text>PCN-PITKERN ADALARY (GB)</text>
        <text>PER-PERU</text>
        <text>PHL-FILIPPINY</text>
        <text>PLW-PALAU</text>
        <text>PNG-PAPUA TAZE GWINEA</text>
        <text>POL-POLSA</text>
        <text>PRI-PUERTO RIKO</text>
        <text>PRK- KOREYA (KNDR)</text>
        <text>PRT-PORTUGALIYA</text>
        <text>PRY-PARAGWAY</text>
        <text>PSE-PALESTINA</text>
        <text>PYF-FRANSUZ POLINEZIYA</text>
        <text>QAT-KATAR</text>
        <text>REU-REYUNYON</text>
        <text>RKS-KOSOWA RESPUBLIKASY</text>
        <text>ROU-RUMINIYA</text>
        <text>RUS-RUSSIYA FEDERASIYASY</text>
        <text>RWA-RUANDA</text>
        <text>SAU-SAUD ARABYSTAN</text>
        <text>SDN-SUDAN</text>
        <text>SEN-SENEGAL</text>
        <text>SGP-SINGAPUR</text>
        <text>SGS-GUNORTA GEORGIYA WE SANDWICH</text>
        <text>SHN-YELENA ADASY</text>
        <text>SJM-SPITSBERGEN ADALARY</text>
        <text>SLB-SOLOMON ADALARY</text>
        <text>SLE-SIERRA LEONE</text>
        <text>SLV-SALWADOR</text>
        <text>SMR-SAN MARINO</text>
        <text>SOM-SOMALI</text>
        <text>SPM-SEN PIER WE MIKELON</text>
        <text>SRB-SERBIA</text>
        <text>SSD-GUNORTA SUDAN</text>
        <text>STP-SAN TOME WE PRINSIPI</text>
        <text>SUR-SURINAM</text>
        <text>SVK-SLOWAKIYA</text>
        <text>SVN-SLOWENIYA</text>
        <text>SWE-SWESIYA</text>
        <text>SWZ-SWAZILEND</text>
        <text>SYC-SEYSHEL ADALARY</text>
        <text>SYR-SIRIYA</text>
        <text>TCA-TERKS WE KAYKOS ADALARY</text>
        <text>TCD-CHAD</text>
        <text>TGO-TOGO</text>
        <text>THA-TAYLAND</text>
        <text>TJK-TAJIKISTAN</text>
        <text>TKL-TOKELAU ADALARY</text>
        <text>TKM-TURKMENISTAN</text>
        <text>TLS-TIMOR-LESTE</text>
        <text>TON-TONGA</text>
        <text>TTO-TRINIDAD WE TOBAGO</text>
        <text>TUN-TUNIS</text>
        <text>TUR-TURKIYE RESP.</text>
        <text>TUV-TUWALU</text>
        <text>TWN-TAYWAN</text>
        <text>TZA-TANZANIYA</text>
        <text>UGA-UGANDA</text>
        <text>UKR-UKRAINA</text>
        <text>UMI-YUWAS OKEAN ADALARY</text>
        <text>UN-BIRLESEN MILLET GURAMA</text>
        <text>URY-URUGVAY</text>
        <text>USA-AMERICANYN BIRL.STATL</text>
        <text>UTO-UTOPIYA</text>
        <text>UZB-OZBEKISTAN</text>
        <text>VAT-WATIKAN</text>
        <text>VCT-SENT WINSENT GRENADINY</text>
        <text>VEN-WENESUELA</text>
        <text>VGB-VIRGIN ADA (BRITAN)</text>
        <text>VIR-VIRGIN ADA (USA)</text>
        <text>VNM-WETNAM</text>
        <text>VUT-WANUATU</text>
        <text>WLF-WOLLIS FUTUNA ADASY</text>
        <text>WSM-GUNBATAR SAMOA</text>
        <text>XXA-RAYATSYZ</text>
        <text>XXX-RAYATLYGY NABELLI</text>
        <text>YEM-YEMEN</text>
        <text>YUG-YUGOSLAWIYA</text>
        <text>ZAF-GUNORTA AFRIKA</text>
        <text>ZAR-ZAIR</text>
        <text>ZIM-ZIMBABWE</text>
        <text>ZMB-ZAMBIYA</text>
     </items>
     
  </field>
           
             */
            return "";
        }


        private static string GetPassportType(string typeInPDF)
        {
            //--IN PDF
            //MP
            //APD
            //AGL
            //AML
            //AUN
            //YG
            //BS
            //PD
            //SP
            //UN
            //US
            //YD
            //SH
            //DZ
            //PG
            //LBG
            //PT
            //EU
            return "";
        }


        private static string GetMaritalStatus(string typeInPDF)
        {
            //--IN PDF

            //1. Sallah/Durmuşa çykmadyk
            //2.Öýlenen/Durmuşa çykan
            //3.Aýrylyşan
            //4.Dul
            return "";
        }


        private static string GetEducation(string typeInPDF)
        {
            //--IN PDf

            //5. ORTA
            //2.YOKARY
            //3.MEKDEP OKUWCYSY
            //4.MEKDEP YASYNA YETMEDIK
            //1.YORITE ORTA
            return "";
        }

        private static string GetVisaType(string typeInPDF)
        {
            //--IN PDF
  
            //14.BS1 - ISEWURLIK
            //20.IN - MAYA GOYUM
            //10.EX - CYKYS
            //9.TU - SYYAHATCYLYK
            //19.TR1 - USTASYR
            //14.TR2 - USTASYR
            //7.ST - STUDENT
            //6. DR - SURUJI
            //5.HL - SAGLYK
            //16.PR1 - HUSUSY (90)
            //17. PR2 - HUSUSY (365)
            //2. OF - GULLUK
            //1.DP - DIPLOMAT
            //11.WP - ISHCHI WIZA
            //15. BS2 - ISEWURLIK
            //22. SP1 - SPORT
            //23. SP2 - SPORT
            //21.FM - MASGALA
            //24.HM - YNSANPERWERLIK
            return "";
        }

        private static string GetVisaCategory(string typeInPDF)
        {
            //--IN PDF

            //1.1x - BIR GEZEKLIK
            //2.2x - IKI GEZEKLIK
            //4.Kx - KOP GEZEKLIK

            return "";
        }

        private static string GetVisaPeriod(string typeInPDF)
        {
            //--IN PDF

        

            //15.Gün
            //16.Aý
            //17.Ýyl

            return "";
        }

        private static string GetRegions(string typeInPDF)
        {
            //--IN PDF


            //AS Ashgabat
            //AH Ahal
            //MR Mary
            //LB Lebap
            //DZ Dashoguz
            //BN Balkan
            return "";
        }

        private static string GetCities(string typeInPDF)
        {
            //--IN PDF
            /*
      <text>AH48 AH-AKBUGDAY ETR.</text>
      <text>AH71 AH-ALTYN-ASYR ETR.</text>
      <text>AH65 AH-BABADAYHAN ETR.</text>
      <text>AH64 AH-BAHARLY ETR.</text>
      <text>AH76 AH-DERWEZE ETR.</text>
      <text>AH47 AH-GOKDEPE ETR.</text>
      <text>AH41 AH-KAKA ETR.</text>
      <text>AH30 AH-RUHABAT ETR.</text>
      <text>AH27 AH-SARAHS ETR.</text>
      <text>AH20 AH-TEJEN ETR.</text>
      <text>AH7 AH-TEJEN SAH.</text>
      <text>AS73 AS-ABADAN ETR.</text>
      <text>AS70 AS-ARCABIL ETR.</text>
      <text>AS69 AS-ASGABAT SAH.</text>
      <text>AS66 AS-AZATLYK ETR.</text>
      <text>AS57 AS-CANDYBIL ETR.</text>
      <text>AS39 AS-KOPETDAG ETR.</text>
      <text>AS33 AS-NIYAZOW ETR.</text>
      <text>BN6 BN-ALTYN ASYR ETR.</text>
      <text>BN63 BN-BALKANABAT SAH.</text>
      <text>BN61 BN-BEREKET ETR.</text>
      <text>BN55 BN-ESENGULY ETR.</text>
      <text>BN54 BN-ETREK ETR.</text>
      <text>BN10 BN-GARABOGAZ SAH.</text>
      <text>BN49 BN-GARRYGALA ETR.</text>
      <text>BN9 BN-GUMDAG SAH.</text>
      <text>BN43 BN-HAZAR SAH.</text>
      <text>BN25 BN-SERDAR ETR.</text>
      <text>BN15 BN-TURKMENBASY ETR.</text>
      <text>BN5 BN-TURKMENBASY SAH.</text>
      <text>DD1 DD-DASRY DOWLETDE</text>
      <text>DZ72 DZ-AKDEPE ETR.</text>
      <text>DZ59 DZ-BOLDUMSAZ ETR.</text>
      <text>DZ56 DZ-DASOGUZ SAH.</text>
      <text>DZ46 DZ-GOROGLY ETR.</text>
      <text>DZ45 DZ-GUBADAG ETR.</text>
      <text>DZ12 DZ-GURBANSOLTAN EJE ETR.</text>
      <text>DZ40 DZ-KONEURGENC ETR.</text>
      <text>DZ34 DZ-NIYAZOW ETR.</text>
      <text>DZ74 DZ-RUHUBELENT ETR.</text>
      <text>DZ8 DZ-TURMENBASY ETR.</text>
      <text>LB68 LB-ATAMYRAT ETR.</text>
      <text>LB67 LB-ATAMYRAT SAH. (KERKI)</text>
      <text>LB60 LB-BIRATA ETR. (DARGANATA)</text>
      <text>LB75 LB-DOWLETLI ETR</text>
      <text>LB53 LB-FARAP ETR.</text>
      <text>LB52 LB-GALKYNYS ETR. (DANEW)</text>
      <text>LB51 LB-GARABEKEWUL ETR.</text>
      <text>LB58 LB-GARASSYZLYK ETR. (BOYNUZYN)</text>
      <text>LB17 LB-GURBASOLTAN EJE ETR.</text>
      <text>LB44 LB-HALAC ETR.</text>
      <text>LB42 LB-HOJAMBAZ ETR.</text>
      <text>LB38 LB-KOYTENDAG ETR. (CARSANGY)</text>
      <text>LB37 LB-MAGDANLY SAH. (GOWURDAK)</text>
      <text>LB29 LB-SAKAR ETR.</text>
      <text>LB26 LB-SAYAT ETR.</text>
      <text>LB24 LB-SERDARABAT ETR. (CARJEW)</text>
      <text>LB22 LB-SEYDI SAH. (NEFTEZAWOD)</text>
      <text>LB18 LB-TURKMENABAT SAH.</text>
      <text>LB32 LB-TURKMENBASY ETR. (DOSTLYK)</text>
      <text>MR77 MR-ALTYN SAHRA ETR.</text>
      <text>MR4 MR-BAYRAMALY ETR.</text>
      <text>MR62 MR-BAYRAMALY SAH.</text>
      <text>MR50 MR-GARAGUM ETR.</text>
      <text>MR36 MR-MARY ETR.</text>
      <text>MR19 MR-MARY SAH.</text>
      <text>MR35 MR-MURGAP ETR.</text>
      <text>MR31 MR-OGUZHAN ETR. (PARAHAT)</text>
      <text>MR28 MR-SAKARCAGE ETR.</text>
      <text>MR3 MR-SATLYK SAH.</text>
      <text>MR23 MR-SERHETABAT ETR. (GUSGY)</text>
      <text>MR2 MR-SERHETABAT SAH.</text>
      <text>MR21 MR-TAGTABAZAR ETR.</text>
      <text>MR14 MR-TURKMENGALA ETR.</text>
      <text>MR13 MR-WEKILBAZAR ETR.</text>
      <text>MR11 MR-YOLETEN ETR.</text>
 
             
             */
            return "";
        }

        private static string GetMGP(string typeInPDF)
        {
            //--IN PDF

            /*
      <text>YMNA - YMAMNAZAR AWTO</text>
      <text>TBYP - TURKMENBASY DENIZ YUK PORTY</text>
      <text>TBMP - TURKMENBASY YOLAGCY PORTY</text>
      <text>TABD - TURKMENABAT D-YOL</text>
      <text>TLMD - TALLYMERJEN D-YOL</text>
      <text>TLMA - TALLYMERJEN AWTO</text>
      <text>SERA - SERHETABAT AWTO</text>
      <text>SRHD - SARAHS D-YOL</text>
      <text>SRHA - SARAHS AWTO</text>
      <text>TABA-TURKMENABAT AEROPORT</text>
      <text>MRAP - MARY AEROPORT</text>
      <text>HDNA - HOWDAN AWTO</text>
      <text>KNUA - KONEURGENC AWTO</text>
      <text>HAZP-HAZAR PORTY</text>
      <text>GZJA - GAZOCAK D-YOL</text>
      <text>GBZA - GARABOGAZ AWTO</text>
      <text>FRPD - FARAP D-YOL</text>
      <text>DZAP - DASOGUZ AEREPORT</text>
      <text>FRPA - FARAP AWTO</text>
      <text>DZAY - DASOGUZ AWTO</text>
      <text>DZDY - DASOGUZ D-YOL</text>
      <text>TBSA-T-BASY AEROPORT</text>
      <text>ARTA - ARTYK AWTO</text>
      <text>ADDY - AMYDERYA D-YOL</text>
      <text>AASA - ALTYN ASYR AWTO</text>
      <text>AKDY - AKDERE D-YOL</text>
      <text>AKDA - AKDERE AWTO</text>
      <text>ASAP - ASGABAT HALKARA AEROPORT</text>
      <text>SRDY - SERHETYAKA D-YOL</text>
      <text>ASAK - ASHGABAT AEROPORT</text>
      <text>AYDY - AK YAYLA D-YOL</text>
      <text>EKRM - EKEREM DM MGP</text>
   </items>
             */

            return "";
        }


       
    }
}
