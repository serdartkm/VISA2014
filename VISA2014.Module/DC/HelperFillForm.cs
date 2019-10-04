using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using Spire.Pdf.Widget;
using System.Drawing;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{
    class HelperFillForm
    {


        public static PdfDocument Fill(IPersonInApplication personInApp)
        {


            PdfDocument pdfdoc = new PdfDocument();

            pdfdoc.LoadFromFile("Visa_Application_TM_QR_08.pdf");
            //  pdfdoc.LoadFromFile("Visa_Application_TM_QR_08.pdf");
            PdfFormWidget form = pdfdoc.Form as PdfFormWidget;
            if (form.XFAForm != null)
            {
                List<XfaField> loFields = form.XFAForm.XfaFields;
             //   FillFormForPerson(personInApp, loFields);
            //    FillVisa(personInApp, loFields);

              
                for (int i = 0; i < loFields.Count; i++) {
                    FillApplicationType(personInApp, loFields[i]);
                    FillUrgency(personInApp, loFields[i]);
                    FillInviterInfo(personInApp, loFields[i]);
                    FillPersonalInfo(personInApp, loFields[i]);
                    FillPersonsPreviousVisa(personInApp, loFields[i]);
                    FillVisaDerejesi(personInApp, loFields[i]);
                    FillLocalAddressInfo(personInApp, loFields[i]);
                    FillPersonVisaPeriodForExitVisa(personInApp, loFields[i]);

                    if (personInApp.PersonType.IsEmployee)
                    {
                        FillEmploymentInfo(personInApp, loFields[i]);
                       FillEmployeeVisaPeriodForExtention(personInApp, loFields[i]);
                        FillEmployeeVisaPeriodForInvitation(personInApp, loFields[i]);
                        FillEducationInfo(personInApp, loFields[i]);
                    }
                    else {
                        FillFMVisaPeriodForExtention(personInApp, loFields[i]);
                        FillFMVisaPeriodForInvitation(personInApp, loFields[i]);
                        FillFMInfo(personInApp, loFields[i]);
                    }
                }

            }

            return pdfdoc;
        }


      
        /*
        private static void FillFormForPerson(IPersonInApplication personInApp, List<XfaField> loFields)
        {











            //24.EMAIL

            //--------------------WIZA MAGLUMATLARY
            //32.WIZANYN DEREJESI
            //33.WIZANYN GORNUSI
            //34.WIZANYN MOHLETI
            //35.WIZANYN BASLANYAN
            //36.WIZANYN TAMAMLANYAN WAGTY
            //37.SONKY BERLEN WIZASYNYN DEREJESI, GORNUSI, BELGISI VE MOHLETI
            //38.BARJAK SERHET YAKALARY
            //40.BOLJAK WELAYATY
            //41.BOLJAK ETRABY
            //42.BOLJAK SALGYSY
            for (int i = 0; i < loFields.Count; i++)
            {

         

            
                

                //1.PHOTO

                if (loFields[i] is XfaImageField)
                {
                    Image image = personInApp.PersonType.Photo;
                    //Console.WriteLine((loFields[i] as XfaImageField).Name);
                    (loFields[i] as XfaImageField).Image = image;

                }
               

                //4.CAGYRYAN TARAP YURIDIKI SAHS

                if (loFields[i] is XfaCheckButtonField && (loFields[i] as XfaCheckButtonField).Name == "topmostSubform[0].Page1[0].IP[1].#field[0]")
                {

                    (loFields[i] as XfaCheckButtonField).Checked = true;
                    //"topmostSubform[0].Page1[0].IP[1].#field[0]"
                }


                //5.KARHANANYN ADY

                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0].L10[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.TitleOfCompany);

                }
                //6.HUKUK SALGYSY


                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0].L11[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.AddressOfCompany);

                }
                //7 Email
                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0].L12[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.Email);

                }

                //8.TELEFON
                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0].L13[0]")
                {

                    (loFields[i] as XfaTextField).Value = personInApp.Application.SigningPerson.PhoneOfNumber;

                }

                //9.FAMILIYASY

                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._01[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastName).ToUpper();

                }

                //11.ADY
                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._03[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.FirstName).ToUpper();

                }

                //12.DOGLAN SENESI
                if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._04[0]")
                {

                    (loFields[i] as XfaDateTimeField).Value = personInApp.PersonType.BirthDate.ToString("dd.MM.yyyy");

                }

                //13.GYNSY

                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._05[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.PersonType.Gender.mgCode;

                }
                //14.RAYATLYGY

                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._06[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Passport.Citizenship.mgCode;

                }


                //15.DOGLAN YURTDY
                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._07[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.PersonType.BirthCountry.mgCode;

                }

                //16.DOGLAN YERI

                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._08[0]")
                {

                    (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.BirthPlace);

                }


                //17.SAHSY BELGISI


                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._09[0]")
                {

                    (loFields[i] as XfaTextField).Value = personInApp.Passport.PersonalNumber.Replace('-', '0');

                }
                //18.PASPORTUNUN GORNUSI
                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._10[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Passport.PassportType.mgCode;

                }

                //19.PASPORTYNYN BELGISI
                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._11[0]")
                {

                    (loFields[i] as XfaTextField).Value = personInApp.Passport.PassportNumber.Replace(" ","");

                }


                //20.BERLEN SENESI

                if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._12[0]")
                {

                    (loFields[i] as XfaDateTimeField).Value = personInApp.Passport.PassportIssuedDate.ToString("dd.MM.yyyy");

                }
                //21.PASPORT MOHLETI
                if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._13[0]")
                {

                    (loFields[i] as XfaDateTimeField).Value = personInApp.Passport.PassportExpiringDate.ToString("dd.MM.yyyy");

                }

                //22.BERLEN YURDY

                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._14[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Passport.PassportIssuedCountry.mgCode;

                }

                //23. DASARY YURTDAKY YASAYAN SALGYSY

                if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page1[0]._15[0]")
                {

                    (loFields[i] as XfaTextField).Value = personInApp.PersonType.ForeignAddressCountry.NameOfCountry + ", " + UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.ForeignAddress);

                }
                //25.MASGALA YAGDAY

                if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._18[0]")
                {

                    (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.PersonType.MaritalStatus.mgCode;

                }



                //form.XFAForm[form.XFAForm.Fields[i]] = "Hello";
            }



        }
*/


     /*
        
        private static void FillVisa(IPersonInApplication personInApp, List<XfaField> loFields)
        {


            for (int i = 0; i < loFields.Count; i++)
            {
                   //Boljak welayaty
                        if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._33[0]")
                        {
                           if(personInApp.PersonType.LastAddressOfResidence!=null && personInApp.PersonType.LastAddressOfResidence.Address.Region!=null){
                                (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.PersonType.LastAddressOfResidence.Address.Region.mgCode;
                           }
                        }

                        //Boljak etraby
                        if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._34[0]")
                        {

                            if (personInApp.PersonType.LastAddressOfResidence != null && personInApp.PersonType.LastAddressOfResidence.Address.ŞäherEtrap != null)
                            {
                                (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.PersonType.LastAddressOfResidence.Address.ŞäherEtrap.mgCode;
                            }

                        }

                        //Boljak salgysy
                        if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page2[0]._35[0]")
                        {
                            if (personInApp.PersonType.LastAddressOfResidence != null) {
                                (loFields[i] as XfaTextField).Value =  UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastAddressOfResidence.Address.AddressLine);
                            }
                        

                        }

                        if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page2[0]._30[0]")
                        {

                            if (personInApp.PersonType != null && personInApp.PersonType.LastVisa != null)
                            {

                                string derejesi = personInApp.Employee.LastVisa.VisaType.TypeOfVisaL;
                                string gornusi = personInApp.Employee.LastVisa.VisaCategory.CategoryOfVisaL;
                                string belgisi = personInApp.Employee.LastVisa.VisaNumber;
                                string baslanyansene = personInApp.Employee.LastVisa.VisaStartDate.ToString("dd.MM.yyyy");
                                string tamamlansene = personInApp.Employee.LastVisa.VisaEndDate.ToString("dd.MM.yyyy");
                                (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(derejesi + ", " + gornusi + ", " + belgisi + ", " + baslanyansene + "-" + tamamlansene);

                           
                            
                            }


                        }



                if (personInApp.Application.SubType == SubType.ApplicationForInvitation)
                {

                    

                    //wiza infor
                    //VISA GEZEKLIGI
                    if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                    {

                        (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                    }
                    //VISA GORNUSI //derejesi
                    if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._25[0]")
                    {
                        if (personInApp.PersonType.IsEmployee && personInApp.Application.VisaPeriod.mgCode == "16" && personInApp.Application.VisaPeriod.PeriodInNumber > 1)
                        {
                            (loFields[i] as XfaChoiceListField).SelectedItem = "11";
                        }
                        else {
                            (loFields[i] as XfaChoiceListField).SelectedItem = "14";
                        }

                    }

                   

                    //VISA MOHLETI SAN
                    if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page2[0]._27[0]")
                    {


                        (loFields[i] as XfaTextField).Value = personInApp.Application.VisaPeriod.PeriodInNumber.ToString();

                    }
                    //VISA MOHLETI AY YYL GUN 
                    if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._271[0]")
                    {

                        (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Application.VisaPeriod.mgCode;

                    }
                    //Bar jak serhet yakasy
                    if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page2[0]._31[0]")
                    {
                        if (personInApp.Application.BorderZoneCollectionForLine!=null)
                        {
                            (loFields[i] as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters( personInApp.Application.BorderZoneCollectionForLine);
                        }
                        

                    }
                }

                else

                    //VISA EXTENSION
                    if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
                    {


                        if (personInApp.PersonType.IsEmployee)
                        {


                            //wiza infor
                            //VISA GEZEKLIGI
                            if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                            {

                                (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                            }
                            //VISA GORNUSI //derejesi
                            if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._25[0]")
                            {

                                if (personInApp.PersonType.IsEmployee && personInApp.Application.VisaPeriod.mgCode == "16" && personInApp.Application.VisaPeriod.PeriodInNumber > 1)
                                {
                                    (loFields[i] as XfaChoiceListField).SelectedItem = "11";
                                }
                                else
                                {
                                    (loFields[i] as XfaChoiceListField).SelectedItem = "14";
                                }

                            }
                            //wiza infor
                            //VISA start date
                            if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._28[0]")
                            {
                                if (personInApp.PersonType.LastVisa != null)
                                {
                                    (loFields[i] as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(1).ToString("dd.MM.yyyy");
                                }


                            }
                            //VISA end date
                            if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._29[0]")
                            {
                                if (personInApp.PersonType.LastVisa != null)
                                {
                                    (loFields[i] as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(personInApp.Application.VisaPeriod.CountMonth).ToString("dd.MM.yyyy");
                                }


                            }

                        }
                        else
                        {


                            //VISA GEZEKLIGI
                            if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                            {

                                (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                            }

                            //wiza infor
                            //VISA start date
                            if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._28[0]")
                            {
                                if (personInApp.PersonType.Employee != null && personInApp.PersonType.Employee.LastVisa != null)
                                {
                                    (loFields[i] as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(1).ToString("dd.MM.yyyy");
                                }


                            }

                            //VISA end date
                            if (loFields[i] is XfaDateTimeField && (loFields[i] as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._29[0]")
                            {
                                if (personInApp.PersonType.LastVisa != null)
                                {
                                    (loFields[i] as XfaDateTimeField).Value = personInApp.PersonType.Employee.LastVisa.VisaEndDate.ToString("dd.MM.yyyy");
                                }


                            }

                        }

                     

                        //VISA MOHLETI SAN
                        if (loFields[i] is XfaTextField && (loFields[i] as XfaTextField).Name == "topmostSubform[0].Page2[0]._27[0]")
                        {


                            (loFields[i] as XfaTextField).Value = personInApp.Application.VisaPeriod.PeriodInNumber.ToString();

                        }
                        //VISA MOHLETI AY YYL GUN 
                        if (loFields[i] is XfaChoiceListField && (loFields[i] as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._271[0]")
                        {

                            (loFields[i] as XfaChoiceListField).SelectedItem = personInApp.Application.VisaPeriod.mgCode;

                        }
                     
                    }

            }

        }
*/

        //1...ApplicationType L01
        private static void FillApplicationType(IPersonInApplication personInApp, XfaField loField)
        {

           

                //0.APPLICATIONTYPE

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0].L01[0]")
                {

                    if (personInApp.Application.SubType == SubType.ApplicationForInvitation)
                    {

                        (loField as XfaChoiceListField).SelectedItem = "2";


                    }
                    else
                        if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
                        {

                            (loField as XfaChoiceListField).SelectedItem = "3";


                        }

                        else
                            if (personInApp.Application.SubType == SubType.ApplicationForChangingPassport)
                            {

                                (loField as XfaChoiceListField).SelectedItem = "6";
                            }

                            else
                                if (personInApp.Application.SubType == SubType.ApplicationForBorderZonePermision)
                                {

                                    (loField as XfaChoiceListField).SelectedItem = "23";
                                }
                                else if (personInApp.Application.SubType == SubType.ApplicationForExitVisa)
                                {
                                    (loField as XfaChoiceListField).SelectedItem = "9";
                                }

                }

           
        }
        //2... Urgency L02
        private static void FillUrgency(IPersonInApplication personInApp, XfaField loField)
        {
           
          
                //3.TIZLIGI

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0].L02[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.Urgency.mgCode;

                }
            
            

        }
        //3... Inviter Info 
        private static void FillInviterInfo(IPersonInApplication personInApp, XfaField loField)
        {

            //4.CAGYRYAN TARAP YURIDIKI SAHS

            if (loField is XfaCheckButtonField && (loField as XfaCheckButtonField).Name == "topmostSubform[0].Page1[0].IP[1].#field[0]")
            {

                (loField as XfaCheckButtonField).Checked = true;
                //"topmostSubform[0].Page1[0].IP[1].#field[0]"
            }


            //5.KARHANANYN ADY

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0].L10[0]")
            {

                (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.TitleOfCompany);

            }
            //6.HUKUK SALGYSY


            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0].L11[0]")
            {

                (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.AddressOfCompany);

            }
            //7 Email
            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0].L12[0]")
            {

                (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.SigningPerson.Email);

            }

            //8.TELEFON
            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0].L13[0]")
            {

                (loField as XfaTextField).Value = personInApp.Application.SigningPerson.PhoneOfNumber;

            }

    
        }

        //4... Personal info

        private static void FillPersonalInfo(IPersonInApplication personInApp, XfaField loField)
        { 
          //1.PHOTO

                if (loField is XfaImageField)
                {
                    Image image = personInApp.PersonType.Photo;
                    //Console.WriteLine((loFields[i] as XfaImageField).Name);
                    (loField as XfaImageField).Image = image;

                }
               

                //9.FAMILIYASY

                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._01[0]")
                {

                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastName).ToUpper();

                }

                //11.ADY
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._03[0]")
                {

                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.FirstName).ToUpper();

                }

                //12.DOGLAN SENESI
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._04[0]")
                {

                    (loField as XfaDateTimeField).Value = personInApp.PersonType.BirthDate.ToString("dd.MM.yyyy");

                }

                //13.GYNSY

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._05[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.Gender.mgCode;

                }
                //14.RAYATLYGY

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._06[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Passport.Citizenship.mgCode;

                }


                //15.DOGLAN YURTDY
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._07[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.BirthCountry.mgCode;

                }

                //16.DOGLAN YERI

                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._08[0]")
                {

                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.BirthPlace);

                }


                //17.SAHSY BELGISI


                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._09[0]")
                {

                    (loField as XfaTextField).Value = personInApp.Passport.PersonalNumber.Replace('-', '0');

                }
                //18.PASPORTUNUN GORNUSI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._10[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Passport.PassportType.mgCode;

                }

                //19.PASPORTYNYN BELGISI
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._11[0]")
                {

                    (loField as XfaTextField).Value = personInApp.Passport.PassportNumber.Replace(" ","");

                }


                //20.BERLEN SENESI

                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._12[0]")
                {

                    (loField as XfaDateTimeField).Value = personInApp.Passport.PassportIssuedDate.ToString("dd.MM.yyyy");

                }
                //21.PASPORT MOHLETI
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page1[0]._13[0]")
                {

                    (loField as XfaDateTimeField).Value = personInApp.Passport.PassportExpiringDate.ToString("dd.MM.yyyy");

                }

                //22.BERLEN YURDY

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._14[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Passport.PassportIssuedCountry.mgCode;

                }

                //23. DASARY YURTDAKY YASAYAN SALGYSY

                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._15[0]")
                {

                    (loField as XfaTextField).Value = personInApp.PersonType.ForeignAddressCountry.NameOfCountry + ", " + UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.ForeignAddress);

                }
                //25.MASGALA YAGDAY

                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._18[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.MaritalStatus.mgCode;

                }

                //26.MASGALA AGZALARY
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._181[0]")
                {

                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.MaritalStatus.StatusL);

                }

                //form.XFAForm[form.XFAForm.Fields[i]] = "Hello";
            

        
        }

        //Previous Visa _30  ALL
        private static void FillPersonsPreviousVisa(IPersonInApplication personInApp, XfaField loField)
        {
           
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._30[0]")
                {

                    if (personInApp.PersonType != null && personInApp.PersonType.LastVisa != null)
                    {

                        string derejesi = personInApp.PersonType.LastVisa.VisaType.TypeOfVisaL;
                        string gornusi = personInApp.PersonType.LastVisa.VisaCategory.CategoryOfVisaL;
                        string belgisi = personInApp.PersonType.LastVisa.VisaNumber;
                        string baslanyansene = personInApp.PersonType.LastVisa.VisaStartDate.ToString("dd.MM.yyyy");
                        string tamamlansene = personInApp.PersonType.LastVisa.VisaEndDate.ToString("dd.MM.yyyy");
                        (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(derejesi + ", " + gornusi + ", " + belgisi + ", " + baslanyansene + "-" + tamamlansene);



                    }


                }
            
        }

        private static void FillEmployeeVisaPeriodForExtention(IPersonInApplication personInApp, XfaField loField)
        {
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
            {

                //wiza infor
                //VISA GEZEKLIGI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                }

                //wiza infor
                //VISA start date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._28[0]")
                {
                    if (personInApp.PersonType.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(1).ToString("dd.MM.yyyy");
                    }


                }
                //VISA end date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._29[0]")
                {
                    if (personInApp.PersonType.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(personInApp.Application.VisaPeriod.CountMonth).ToString("dd.MM.yyyy");
                    }


                }


            }
        }

        private static void FillPersonVisaPeriodForExitVisa(IPersonInApplication personInApp, XfaField loField)
        {
            if (personInApp.Application.SubType == SubType.ApplicationForExitVisa)
            {

                //wiza infor
                //VISA GEZEKLIGI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem ="1";

                }

                //wiza infor
                //VISA start date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._28[0]")
                {
                    if (personInApp.PersonType.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(1).ToString("dd.MM.yyyy");
                    }


                }
                //VISA end date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._29[0]")
                {
                    if (personInApp.PersonType.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(personInApp.Application.VisaPeriod.CountMonth).ToString("dd.MM.yyyy");
                    }


                }


            }
        }


        private static void FillFMVisaPeriodForExtention(IPersonInApplication personInApp, XfaField loField)
        {
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
            {
                //VISA GEZEKLIGI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                }

                //wiza infor
                //VISA start date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._28[0]")
                {
                    if (personInApp.PersonType.Employee != null && personInApp.PersonType.Employee.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.LastVisa.VisaEndDate.AddDays(1).ToString("dd.MM.yyyy");
                    }


                }

                //VISA end date
                if (loField is XfaDateTimeField && (loField as XfaDateTimeField).Name == "topmostSubform[0].Page2[0]._29[0]")
                {
                    if (personInApp.PersonType.LastVisa != null)
                    {
                        (loField as XfaDateTimeField).Value = personInApp.PersonType.Employee.LastVisa.VisaEndDate.ToString("dd.MM.yyyy");
                    }


                }



                //VISA MOHLETI SAN
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._27[0]")
                {


                    (loField as XfaTextField).Value = personInApp.Application.VisaPeriod.PeriodInNumber.ToString();

                }
                //VISA MOHLETI AY YYL GUN 
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._271[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaPeriod.mgCode;

                }


            }
            
        }


        private static void FillEmployeeVisaPeriodForInvitation(IPersonInApplication personInApp, XfaField loField)
        {

            if (personInApp.Application.SubType == SubType.ApplicationForInvitation)
            {

                //wiza infor
                //VISA GEZEKLIGI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                }


                //VISA MOHLETI SAN
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._27[0]")
                {


                    (loField as XfaTextField).Value = personInApp.Application.VisaPeriod.PeriodInNumber.ToString();

                }
                //VISA MOHLETI AY YYL GUN 
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._271[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaPeriod.mgCode;

                }
                //Bar jak serhet yakasy
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._31[0]")
                {
                    if (personInApp.Application.BorderZoneCollectionForLine != null)
                    {
                        (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.BorderZoneCollectionForLine);
                    }

                }
            }
        }

        private static void FillFMVisaPeriodForInvitation(IPersonInApplication personInApp, XfaField loField) {

            if (personInApp.Application.SubType == SubType.ApplicationForInvitation)
            {
                //wiza infor
                //VISA GEZEKLIGI
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._26[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaCategory.mgCode;

                }




                //VISA MOHLETI SAN
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._27[0]")
                {


                    (loField as XfaTextField).Value = personInApp.Application.VisaPeriod.PeriodInNumber.ToString();

                }
                //VISA MOHLETI AY YYL GUN 
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._271[0]")
                {

                    (loField as XfaChoiceListField).SelectedItem = personInApp.Application.VisaPeriod.mgCode;

                }
                //Bar jak serhet yakasy
                if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._31[0]")
                {
                    if (personInApp.Application.BorderZoneCollectionForLine != null)
                    {
                        (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.BorderZoneCollectionForLine);
                    }


                }

             
            }


        }

        private static void FillVisaDerejesi(IPersonInApplication personInApp, XfaField loField)
        {

            if (personInApp.Application.SubType == SubType.ApplicationForExitVisa) {
                //VISA GORNUSI //derejesi
                if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._25[0]")
                {


                    (loField as XfaChoiceListField).SelectedItem = "10";


                }
            }
            else if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention  | personInApp.Application.SubType== SubType.ApplicationForInvitation) {
                // 14 BS1
                //21 FM
                //10 ex
                //11 WP 
                if (personInApp.AppliedPerson.IsEmployee)
                {
                    //VISA GORNUSI //derejesi
                    if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._25[0]")
                    {

                     
                            if (personInApp.Application.IsInvitationWithWorkPermit !=null && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.InvitationAndWorkPermit)
                            {
                                (loField as XfaChoiceListField).SelectedItem = "11";
                            }
                       
                        

                     
                            if (personInApp.Application.IsInvitationWithWorkPermit != null && personInApp.Application.IsInvitationWithWorkPermit.InvitationAndWorkPermitRequired == WPForInvitationRequired.OnlyInvitation)
                            {
                                (loField as XfaChoiceListField).SelectedItem = "14";
                            }
                         
                            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
                            {
                                (loField as XfaChoiceListField).SelectedItem = "11";
                            }
                        

                            

                        else if (personInApp.PersonType.IsFamilyMember)
                        {
                            (loField as XfaChoiceListField).SelectedItem = "21";
                        }

                        else if (personInApp.Application.SubType == SubType.ApplicationForExitVisa) {

                            (loField as XfaChoiceListField).SelectedItem = "10";
                        }
                        else
                        {
                            (loField as XfaChoiceListField).SelectedItem = "14"; 

                        }

                    }

                }
                else {

                    //VISA GORNUSI //derejesi
                    if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._25[0]")
                    {


                        (loField as XfaChoiceListField).SelectedItem = "21";


                    }
                }
            }

            

        }

        private static void FillLocalAddressInfo(IPersonInApplication personInApp, XfaField loField)
        {

            //Boljak welayaty
            if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._33[0]")
            {
                if (personInApp.PersonType.LastAddressOfResidence != null && personInApp.PersonType.LastAddressOfResidence.Address.Region != null)
                {
                    (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.LastAddressOfResidence.Address.Region.mgCode;
                }
            }

            //Boljak etraby
            if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page2[0]._34[0]")
            {

                if (personInApp.PersonType.LastAddressOfResidence != null && personInApp.PersonType.LastAddressOfResidence.Address.ŞäherEtrap != null)
                {
                    (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.LastAddressOfResidence.Address.ŞäherEtrap.mgCode;
                }

            }

            //Boljak salgysy
            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._35[0]")
            {
                if (personInApp.PersonType.LastAddressOfResidence != null)
                {
                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastAddressOfResidence.Address.AddressLine);
                }


            }
        }

        private static void FillEmploymentInfo(IPersonInApplication personInApp, XfaField loField)
        {

            //30.HEREKET CAGI

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._38[0]")
            {
                if (personInApp.Application.Bellik != null && !String.IsNullOrEmpty( personInApp.Application.Bellik.BelliklerL))
               {
                   (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.Application.Bellik.BelliklerL);
                }


            }

            //31.WEZIPESI

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._23[0]")
            {
               if(personInApp.PersonType.LastPosition !=null && personInApp.PersonType.LastPosition.Position.TitleOfPosition.Length>0){
                  (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastPosition.Position.TitleOfPosition);
                }
             

            }
        }

        private static void FillEducationInfo(IPersonInApplication personInApp, XfaField loField)
        {

            //27.BILIM DEREJESI
            if (loField is XfaChoiceListField && (loField as XfaChoiceListField).Name == "topmostSubform[0].Page1[0]._19[0]")
            {

                (loField as XfaChoiceListField).SelectedItem = personInApp.PersonType.LastEducation.EducationLevel.mgCode;

            }

            //28.HUNARI

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._20[0]")
            {
                if (personInApp.PersonType.LastEducation != null && personInApp.PersonType.LastEducation.EducationInstitution.TitleOfIEducationInstitution != null)
                {
                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastEducation.Spcialty.TitleOfSpeciality);
                }


            }



            //29.OKAN YERI

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page1[0]._21[0]")
            {
                if (personInApp.PersonType.LastEducation != null && personInApp.PersonType.LastEducation.EducationInstitution.TitleOfIEducationInstitution != null)
                {

                    (loField as XfaTextField).Value = personInApp.PersonType.LastEducation.EducationCountry.NameOfCountry + ", " + UpdateHelperClasses.ReplaceLetters(personInApp.PersonType.LastEducation.EducationInstitution.TitleOfIEducationInstitution);
                }


            }
        }

        private static void FillFMInfo(IPersonInApplication personInApp, XfaField loField)
        {
            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._39[0]")
            {
                if (personInApp.FamilyMember != null)
                {
                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(personInApp.FamilyMember.FamilyMemberRelation.RelativeAsL);
                }


            }

            if (loField is XfaTextField && (loField as XfaTextField).Name == "topmostSubform[0].Page2[0]._37[0]")
            {

                if (personInApp.PersonType != null && personInApp.PersonType.IsFamilyMember && personInApp.PersonType.Employee != null && personInApp.PersonType.Employee.LastVisa != null)
                {

                    string derejesi = personInApp.PersonType.Employee.LastVisa.VisaType.TypeOfVisaL;
                    string gornusi = personInApp.PersonType.Employee.LastVisa.VisaCategory.CategoryOfVisaL;
                    string belgisi = personInApp.PersonType.Employee.LastVisa.VisaNumber;
                    string baslanyansene = personInApp.PersonType.Employee.LastVisa.VisaStartDate.ToString("dd.MM.yyyy");
                    string tamamlansene = personInApp.PersonType.Employee.LastVisa.VisaEndDate.ToString("dd.MM.yyyy");
                    (loField as XfaTextField).Value = UpdateHelperClasses.ReplaceLetters(derejesi + ", " + gornusi + ", " + belgisi + ", " + baslanyansene + "-" + tamamlansene);



                }


            }
        }
    }
}
