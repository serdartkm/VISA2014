using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using VISA2014.Module.BusinessObjects;
using VISA2014.Module.DC;
using DevExpress.ExpressApp.Reports;
using DevExpress.ExpressApp.Security.Strategy;  
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base.General;
using DatabaseUserSettings;
using DatabaseUserSettings.BusinessObjects;

namespace VISA2014.Module.DatabaseUpdate
{

    public class Updater : ModuleUpdater
    {

        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        
        #region UpdateDatabaseAfterUpdateSchema
        #region UpdateDatabaseAfterUpdateSchema
     
        private void CreateReport(string reportName)
        {
            ReportData reportdata = ObjectSpace.FindObject<ReportData>(
               new BinaryOperator("Name", reportName));
           /*
            if (reportdata == null)
            {
                
                reportdata = ObjectSpace.CreateObject<ReportData>();
                XafReport rep = new XafReport();
                rep.ObjectSpace = ObjectSpace;
                rep.LoadLayout(GetType().Assembly.GetManifestResourceStream("VISA2014.Module.EmbeddedReport." + reportName + ".repx"));
                
                rep.ReportName = reportName;
                reportdata.SaveReport(rep);
                reportdata.Save();
                reportdata.IsInplaceReport = true;
                
                 
            }
            */
        }


        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();



         //  UpdateHelperClasses.UpdateMgCode(ObjectSpace);




            #region security
            SecuritySystemRole adminRole = ObjectSpace.FindObject<SecuritySystemRole>(
        new BinaryOperator("Name", SecurityStrategy.AdministratorRoleName));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                adminRole.Name = SecurityStrategy.AdministratorRoleName;
                adminRole.IsAdministrative = true;
                adminRole.Save();
            }


            SecuritySystemUser configuratorUser = ObjectSpace.FindObject<SecuritySystemUser>(
            new BinaryOperator("UserName", DatabaseUserSettingsModule.ConfiguratorUserName));
            
            if (configuratorUser == null)
            {
                configuratorUser = ObjectSpace.CreateObject<SecuritySystemUser>();
                configuratorUser.UserName = DatabaseUserSettingsModule.ConfiguratorUserName;
                configuratorUser.IsActive = true;
                configuratorUser.Roles.Add(GetConfiguratorRole());
                configuratorUser.Save();
            }


            SecuritySystemUser adminUser = ObjectSpace.FindObject<SecuritySystemUser>(
                new BinaryOperator("UserName", "Adminn"));
            if (adminUser == null)
            {
                adminUser = ObjectSpace.CreateObject<SecuritySystemUser>();
                adminUser.UserName = "Adminn";
                adminUser.SetPassword("");
                adminUser.Roles.Add(adminRole);
            }

            SecuritySystemRole userRole = ObjectSpace.FindObject<SecuritySystemRole>(
                new BinaryOperator("Name", "user"));

            if (userRole == null)
            {
                userRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                userRole.Name = "user";

                #region Company

                // ICompany

                SecuritySystemTypePermissionObject companyName = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                companyName.TargetType = typeof(ICompany);
                companyName.AllowRead = true;
                companyName.AllowWrite = true;
                companyName.AllowNavigate = true;


                // Company Representative
                SecuritySystemTypePermissionObject compRepresentative = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                compRepresentative.TargetType = typeof(ICompanyRepresentative);
                compRepresentative.AllowRead = true;
                compRepresentative.AllowWrite = true;
                compRepresentative.AllowNavigate = true;
                compRepresentative.AllowCreate = true;


                // Position

                SecuritySystemTypePermissionObject position = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                position.TargetType = typeof(IPosition);
                position.AllowRead = true;
                position.AllowWrite = true;
                position.AllowNavigate = true;
                position.AllowCreate = true;


                // Department

                SecuritySystemTypePermissionObject department = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                department.TargetType = typeof(IDepartment);
                department.AllowRead = true;
                department.AllowWrite = true;
                department.AllowNavigate = true;
                department.AllowDelete = true;
                department.AllowCreate = true;

                #endregion

                #region Person

                // Person
                SecuritySystemTypePermissionObject person = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                person.TargetType = typeof(IPersonn);
                person.AllowRead = true;
                person.AllowWrite = true;
                person.AllowNavigate = true;
                person.AllowDelete = true;
                person.AllowCreate = true;
                // Gender
                SecuritySystemTypePermissionObject gender = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                gender.TargetType = typeof(IGender);
                gender.AllowRead = true;
                gender.AllowWrite = true;
                gender.AllowNavigate = true;
                gender.AllowDelete = true;

                // Marital Status

                SecuritySystemTypePermissionObject maritalStatus = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                maritalStatus.TargetType = typeof(IMaritalStatus);
                maritalStatus.AllowRead = true;
                maritalStatus.AllowWrite = true;
                maritalStatus.AllowNavigate = true;


                // AddressOfResidence

                SecuritySystemTypePermissionObject addressOfResidence = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                addressOfResidence.TargetType = typeof(IAddressOfResidence);
                addressOfResidence.AllowRead = true;
                addressOfResidence.AllowWrite = true;
                addressOfResidence.AllowNavigate = true;
                addressOfResidence.AllowDelete = true;
                addressOfResidence.AllowCreate = true;

                // Address
                SecuritySystemTypePermissionObject address = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                address.TargetType = typeof(IAddresses);
                address.AllowRead = true;
                address.AllowWrite = true;
                address.AllowNavigate = true;
                address.AllowCreate = true;

                SecuritySystemTypePermissionObject documentOfaddress = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                documentOfaddress.TargetType = typeof(IDocumentOfAddress);
                documentOfaddress.AllowRead = true;
                documentOfaddress.AllowWrite = true;
                documentOfaddress.AllowNavigate = true;
                documentOfaddress.AllowCreate = true;

                // Education

                SecuritySystemTypePermissionObject education = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                education.TargetType = typeof(IEducation);
                education.AllowRead = true;
                education.AllowWrite = true;
                education.AllowNavigate = true;
                education.AllowDelete = true;
                education.AllowCreate = true;
                // Education Insitution

                SecuritySystemTypePermissionObject educIns = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                educIns.TargetType = typeof(IEducationInstitution);
                educIns.AllowRead = true;
                educIns.AllowWrite = true;
                educIns.AllowNavigate = true;
                educIns.AllowCreate = true;

                // Education Level

                SecuritySystemTypePermissionObject educLevel = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                educLevel.TargetType = typeof(IEducationLevel);
                educLevel.AllowRead = true;

                educLevel.AllowNavigate = true;



                // Specialty

                SecuritySystemTypePermissionObject spefialty = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                spefialty.TargetType = typeof(ISpeciality);
                spefialty.AllowRead = true;
                spefialty.AllowWrite = true;
                spefialty.AllowNavigate = true;
                spefialty.AllowCreate = true;

                // WorkHistory

                SecuritySystemTypePermissionObject workhistory = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                workhistory.TargetType = typeof(IWorkHistory);
                workhistory.AllowRead = true;
                workhistory.AllowWrite = true;
                workhistory.AllowNavigate = true;
                workhistory.AllowDelete = true;
                workhistory.AllowCreate = true;


                // Travelinfo

                SecuritySystemTypePermissionObject travelInfo = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                travelInfo.TargetType = typeof(ITravelInformation);
                travelInfo.AllowRead = true;
                travelInfo.AllowWrite = true;
                travelInfo.AllowNavigate = true;
                travelInfo.AllowDelete = true;
                travelInfo.AllowCreate = true;

                // Employee

                SecuritySystemTypePermissionObject employee = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                employee.TargetType = typeof(IEmployee);
                employee.AllowRead = true;
                employee.AllowWrite = true;
                employee.AllowNavigate = true;
                employee.AllowDelete = true;
                employee.AllowCreate = true;


                //Family Member 


                SecuritySystemTypePermissionObject family = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                family.TargetType = typeof(IFamilyMember);
                family.AllowRead = true;
                family.AllowWrite = true;
                family.AllowNavigate = true;
                family.AllowDelete = true;
                family.AllowCreate = true;

                //Family Member Relation


                SecuritySystemTypePermissionObject fmRelation = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                fmRelation.TargetType = typeof(IRelation);
                fmRelation.AllowRead = true;

                fmRelation.AllowNavigate = true;


                #endregion

                #region Application

                // UserCode 

                SecuritySystemTypePermissionObject userCode = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                userCode.TargetType = typeof(UserCode);
                userCode.AllowRead = true;
                userCode.AllowWrite = true;
                userCode.AllowNavigate = true;
                userCode.AllowDelete = true;
                userCode.AllowCreate = true;



                // App Conf 


                SecuritySystemTypePermissionObject appConf = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                appConf.TargetType = typeof(AppConf);
                appConf.AllowRead = true;

                // ICopy

                SecuritySystemTypePermissionObject docCopy = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                docCopy.TargetType = typeof(ICopy);
                docCopy.AllowRead = true;
                docCopy.AllowWrite = true;
                docCopy.AllowNavigate = true;
                docCopy.AllowDelete = true;
                docCopy.AllowCreate = true;



                //IApplication

                SecuritySystemTypePermissionObject application = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                application.TargetType = typeof(IApplication);
                application.AllowRead = true;
                application.AllowWrite = true;
                application.AllowNavigate = true;
                application.AllowDelete = true;
                application.AllowCreate = true;
                // IContract
                SecuritySystemTypePermissionObject contract = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                contract.TargetType = typeof(IContract);
                contract.AllowRead = true;
                contract.AllowWrite = true;
                contract.AllowNavigate = true;
                contract.AllowDelete = true;
                contract.AllowCreate = true;
                // ILongProcessApp
                SecuritySystemTypePermissionObject longProcessApp = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                longProcessApp.TargetType = typeof(ILongProcessApplication);
                longProcessApp.AllowRead = true;
                longProcessApp.AllowWrite = true;
                longProcessApp.AllowNavigate = true;
                longProcessApp.AllowDelete = true;
                longProcessApp.AllowCreate = true;

                // ISimpleProcessApp
                SecuritySystemTypePermissionObject simpleProcessApp = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                simpleProcessApp.TargetType = typeof(ISimpleProcessApplication);
                simpleProcessApp.AllowRead = true;
                simpleProcessApp.AllowWrite = true;
                simpleProcessApp.AllowNavigate = true;
                simpleProcessApp.AllowDelete = true;
                simpleProcessApp.AllowCreate = true;
                // IAppliedMinistery
                SecuritySystemTypePermissionObject appliedMinistery = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                appliedMinistery.TargetType = typeof(IAppliedMinistery);
                appliedMinistery.AllowRead = true;
                appliedMinistery.AllowWrite = true;
                appliedMinistery.AllowNavigate = true;
                appliedMinistery.AllowCreate = true;
                //  Person In Application

                SecuritySystemTypePermissionObject pInApplication = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                pInApplication.TargetType = typeof(IPersonInApplication);
                pInApplication.AllowRead = true;
                pInApplication.AllowWrite = true;
                pInApplication.AllowNavigate = true;
                pInApplication.AllowDelete = true;
                pInApplication.AllowCreate = true;
                //Application For Family Member

                SecuritySystemTypePermissionObject applicationForFamilyMember = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                applicationForFamilyMember.TargetType = typeof(ApplicationTypeForFamilyMember);
                applicationForFamilyMember.AllowRead = true;
                applicationForFamilyMember.AllowNavigate = true;

                //Application For Employee

                SecuritySystemTypePermissionObject applicationForEmployee = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                applicationForEmployee.TargetType = typeof(ApplicationTypeForEmployee);
                applicationForEmployee.AllowRead = true;
                applicationForEmployee.AllowNavigate = true;

                //AppConfig

                SecuritySystemTypePermissionObject appConFig = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                appConFig.TargetType = typeof(AppConf);
                appConFig.AllowRead = true;
                appConFig.AllowNavigate = true;

                //Urgency

                SecuritySystemTypePermissionObject urgency = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                urgency.TargetType = typeof(IUrgency);
                urgency.AllowRead = true;
                urgency.AllowNavigate = true;


                //BaseApplicationType

                SecuritySystemTypePermissionObject baseApplicationType = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                baseApplicationType.TargetType = typeof(BaseApplicationType);
                baseApplicationType.AllowRead = true;
                baseApplicationType.AllowNavigate = true;

                //IsInvitationWithWorkPermit

                SecuritySystemTypePermissionObject isInvitationWithWPermit = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                isInvitationWithWPermit.TargetType = typeof(IsInvitationWithWorkPermit);
                isInvitationWithWPermit.AllowRead = true;
                isInvitationWithWPermit.AllowNavigate = true;

                // Is Visa With Work Permit

                SecuritySystemTypePermissionObject isVisaWithWPermit = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                isVisaWithWPermit.TargetType = typeof(IsWizaWithWorkPermit);
                isVisaWithWPermit.AllowRead = true;
                isVisaWithWPermit.AllowNavigate = true;

                //Border Zone For Visa

                SecuritySystemTypePermissionObject borderZoneForVisa = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                borderZoneForVisa.TargetType = typeof(IBorderZoneForVisa);
                borderZoneForVisa.AllowRead = true;
                borderZoneForVisa.AllowNavigate = true;
                borderZoneForVisa.AllowWrite = true;
                borderZoneForVisa.AllowCreate = true;

                // Department For Registration

                SecuritySystemTypePermissionObject departmentForReg = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                departmentForReg.TargetType = typeof(DepartmentForRegistration);
                departmentForReg.AllowRead = true;
                departmentForReg.AllowNavigate = true;


                // CheckPoint 

                SecuritySystemTypePermissionObject checkpoint = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                checkpoint.TargetType = typeof(CheckPoint);
                checkpoint.AllowRead = true;
                checkpoint.AllowNavigate = true;

                //Preferred visa category
                SecuritySystemTypePermissionObject preferredVisaCategory = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                preferredVisaCategory.TargetType = typeof(PrefferedVisaCategory);
                preferredVisaCategory.AllowRead = true;
                preferredVisaCategory.AllowNavigate = true;


                //Purpose Of travel
                SecuritySystemTypePermissionObject purposeOftravel = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                purposeOftravel.TargetType = typeof(PurposeOfTravel);
                purposeOftravel.AllowRead = true;
                purposeOftravel.AllowNavigate = true;


                #endregion

                #region Result

                // IResultLetter

                SecuritySystemTypePermissionObject resultletter = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                resultletter.TargetType = typeof(IApplicationResult);
                resultletter.AllowRead = true;
                resultletter.AllowWrite = true;
                resultletter.AllowNavigate = true;
                resultletter.AllowDelete = true;
                resultletter.AllowCreate = true;
                //  Person In Invitation

                SecuritySystemTypePermissionObject personInResult = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                personInResult.TargetType = typeof(IPersonInResult);
                personInResult.AllowRead = true;
                personInResult.AllowWrite = true;
                personInResult.AllowNavigate = true;
                personInResult.AllowDelete = true;
                personInResult.AllowCreate = true;





                // Invitation Rejected


                #endregion

                #region Visa
                SecuritySystemTypePermissionObject visa = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                visa.TargetType = typeof(IVisa);
                visa.AllowRead = true;
                visa.AllowWrite = true;
                visa.AllowNavigate = true;
                visa.AllowDelete = true;
                visa.AllowCreate = true;


                SecuritySystemTypePermissionObject country = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                country.TargetType = typeof(ICountries);
                country.AllowRead = true;
                country.AllowWrite = true;
                country.AllowNavigate = true;


                SecuritySystemTypePermissionObject visaCategory = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                visaCategory.TargetType = typeof(IVisaCategory);
                visaCategory.AllowRead = true;
                visaCategory.AllowNavigate = true;

                SecuritySystemTypePermissionObject visaType = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                visaType.TargetType = typeof(IVisaType);
                visaType.AllowRead = true;

                visaType.AllowNavigate = true;


                SecuritySystemTypePermissionObject visaPeriod = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                visaPeriod.TargetType = typeof(IVisaPeriod);
                visaPeriod.AllowRead = true;
                visaPeriod.AllowWrite = true;
                visaPeriod.AllowNavigate = true;
                visaPeriod.AllowCreate = true;

                SecuritySystemTypePermissionObject visaIssuedPlace = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                visaIssuedPlace.TargetType = typeof(IVisaIssuedPlace);
                visaIssuedPlace.AllowRead = true;
                visaIssuedPlace.AllowWrite = true;
                visaIssuedPlace.AllowNavigate = true;
                visaIssuedPlace.AllowDelete = true;
                visaIssuedPlace.AllowCreate = true;

                #endregion

                #region Passport
                SecuritySystemTypePermissionObject passport = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                passport.TargetType = typeof(IPassport);
                passport.AllowRead = true;
                passport.AllowWrite = true;
                passport.AllowNavigate = true;
                passport.AllowDelete = true;
                passport.AllowCreate = true;

                SecuritySystemTypePermissionObject passportType = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                passportType.TargetType = typeof(IPassportType);
                passportType.AllowRead = true;
                passportType.AllowWrite = true;
                passportType.AllowNavigate = true;
                passportType.AllowCreate = true;


                #endregion

                #region WorkPermit

                // WorkPermit Letter
                SecuritySystemTypePermissionObject wpLetter = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                wpLetter.TargetType = typeof(IWorkPermitLetter);
                wpLetter.AllowRead = true;
                wpLetter.AllowWrite = true;
                wpLetter.AllowNavigate = true;
                wpLetter.AllowDelete = true;
                wpLetter.AllowCreate = true;


                // Work Permit
                SecuritySystemTypePermissionObject wPermit = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                wPermit.TargetType = typeof(IWorkPermit);
                wPermit.AllowRead = true;
                wPermit.AllowWrite = true;
                wPermit.AllowNavigate = true;
                wPermit.AllowDelete = true;
                wPermit.AllowCreate = true;

                // Work Permit Location
                SecuritySystemTypePermissionObject wpLocation = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                wpLocation.TargetType = typeof(IWorkPermitLocation);
                wpLocation.AllowRead = true;
                wpLocation.AllowWrite = true;
                wpLocation.AllowNavigate = true;
                wpLocation.AllowDelete = true;
                wpLocation.AllowCreate = true;

                #endregion

                #region Report

                SecuritySystemTypePermissionObject report = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                report.TargetType = typeof(ReportData);
                report.AllowRead = true;
                report.AllowNavigate = true;
                report.AllowCreate = true;
                report.AllowWrite = true;
                #endregion

                #region Locations
                // Regions
                SecuritySystemTypePermissionObject region = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                region.TargetType = typeof(IRegion);
                region.AllowRead = true;

                region.AllowNavigate = true;
                // Çountries

                SecuritySystemTypePermissionObject countries = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                countries.TargetType = typeof(ICountries);
                countries.AllowRead = true;
                countries.AllowWrite = true;
                country.AllowNavigate = true;


                // Cities
                SecuritySystemTypePermissionObject cities = ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                cities.TargetType = typeof(IŞäherEtrap);
                cities.AllowRead = true;
                cities.AllowNavigate = true;


                #endregion

                #region  // Add type Permissions To userRole

                // Comapny 
                userRole.TypePermissions.Add(companyName);
                userRole.TypePermissions.Add(compRepresentative);
                userRole.TypePermissions.Add(position);
                userRole.TypePermissions.Add(department);


                // Person
                userRole.TypePermissions.Add(person);
                userRole.TypePermissions.Add(employee);
                userRole.TypePermissions.Add(report);
                userRole.TypePermissions.Add(family);
                userRole.TypePermissions.Add(fmRelation);
                userRole.TypePermissions.Add(gender);
                userRole.TypePermissions.Add(maritalStatus);
                userRole.TypePermissions.Add(addressOfResidence);
                userRole.TypePermissions.Add(address);
                userRole.TypePermissions.Add(education);
                userRole.TypePermissions.Add(educIns);
                userRole.TypePermissions.Add(educLevel);
                userRole.TypePermissions.Add(spefialty);
                userRole.TypePermissions.Add(workhistory);

                userRole.TypePermissions.Add(resultletter);
                userRole.TypePermissions.Add(pInApplication);
                userRole.TypePermissions.Add(personInResult);
                userRole.TypePermissions.Add(travelInfo);
                userRole.TypePermissions.Add(documentOfaddress);


                // Application
                //  userRole.TypePermissions.Add(appConf);
                userRole.TypePermissions.Add(application);
                userRole.TypePermissions.Add(contract);
                userRole.TypePermissions.Add(longProcessApp);
                userRole.TypePermissions.Add(simpleProcessApp);
                userRole.TypePermissions.Add(appliedMinistery);
                userRole.TypePermissions.Add(applicationForEmployee);
                userRole.TypePermissions.Add(applicationForFamilyMember);
                userRole.TypePermissions.Add(appConFig);
                userRole.TypePermissions.Add(baseApplicationType);
                userRole.TypePermissions.Add(urgency);
                userRole.TypePermissions.Add(isInvitationWithWPermit);
                userRole.TypePermissions.Add(isVisaWithWPermit);
                userRole.TypePermissions.Add(borderZoneForVisa);


                userRole.TypePermissions.Add(departmentForReg);
                userRole.TypePermissions.Add(checkpoint);
                userRole.TypePermissions.Add(preferredVisaCategory);
                userRole.TypePermissions.Add(purposeOftravel);
                // visa
                userRole.TypePermissions.Add(visa);
                userRole.TypePermissions.Add(country);
                userRole.TypePermissions.Add(visaCategory);
                userRole.TypePermissions.Add(visaType);
                userRole.TypePermissions.Add(visaPeriod);
                userRole.TypePermissions.Add(visaIssuedPlace);
                // passport
                userRole.TypePermissions.Add(passport);
                userRole.TypePermissions.Add(passportType);

                // WorkPermit

                userRole.TypePermissions.Add(wPermit);
                userRole.TypePermissions.Add(wpLocation);
                userRole.TypePermissions.Add(wpLetter);

                //Locations 

                userRole.TypePermissions.Add(region);
                userRole.TypePermissions.Add(cities);
                userRole.TypePermissions.Add(countries);
                #endregion

                SecuritySystemObjectPermissionsObject limitvisa = ObjectSpace.CreateObject<SecuritySystemObjectPermissionsObject>();
                limitvisa.Criteria = "";
            }//userrole

            SecuritySystemUser User = ObjectSpace.FindObject<SecuritySystemUser>(
              new BinaryOperator("UserName", "user"));
            if (User == null)
            {
                User = ObjectSpace.CreateObject<SecuritySystemUser>();
                User.UserName = "user";
                User.SetPassword("");
                User.Roles.Add(userRole);
            }



            #endregion

            #region Reports
          //  CreateReport("PersonInApplication");
            CreateReport("A.Maglumat (Gap insaat)");
            CreateReport("A.Maglumat (OwadanAda)");
            CreateReport("A.Maglumat");
            CreateReport("AppForEmpInvit");
            CreateReport("Application");
            CreateReport("Borçnama(Endustrial)");
            CreateReport("Borçnama");
            CreateReport("ÇakylykGöçürmekNusga");
            CreateReport("Çalışma izni");
            CreateReport("Contract with Employee");
            CreateReport("Contract(Owadan ada)");
            CreateReport("Contract");
            CreateReport("Current Work Permits");
            CreateReport("DiplomCopy");
            CreateReport("Employee in Invitation");
            CreateReport("Employee");
            CreateReport("Employees On Invitation");
            CreateReport("FamiliProofDoc");
            CreateReport("Family Member in Invitation");
            CreateReport("Family Member On Invitation");
            CreateReport("Form");
            CreateReport("Form16 arkasy");
            CreateReport("Form16 Family Member");
            CreateReport("Form16.");
            CreateReport("Form16");
            CreateReport("Hakimlik sanawy");
           // CreateReport("Hasaba alnanlar");
         //   CreateReport("Hasaba duranlar(Işär)");
           // CreateReport("Hasaba duranlar(ma)");
           // CreateReport("Hasapda çykarlanlar (Işgär)");
           // CreateReport("Hasapdan çykarlanlar(ma)");
           // CreateReport("Iş rugsatnama möhleti tamamlanýan");
            CreateReport("Hasapdan çykarylan");
            CreateReport("Iş rugsatnamaly");
            CreateReport("Iş rugsatnamasyz");
            CreateReport("LojmanHat");
            CreateReport("Ministr sanawy");
          //  CreateReport("Pasport möhleti tamamlanýan(Işgar)");
           // CreateReport("Pasport möhleti tamamlanýan(ma)");
           // CreateReport("Pasport möhleti tamamlanýan");
            CreateReport("PasportCopy");
            CreateReport("PassportNusga");
            CreateReport("PassportWeVızaNusga");
            CreateReport("Personal List(Işgär)");
            CreateReport("Personal List(ma)");
            CreateReport("Personal List");
            CreateReport("PersonalList");
            CreateReport("PersonInApplication");
          //  CreateReport("RaporVizaExtention");
           // CreateReport("RaporVizaExtentionFM");
            CreateReport("Raýat-Hukuk şertnama");
           // CreateReport("Rejected Employee");
            CreateReport("Rejected Family Member");
            CreateReport("Rugsatnama Nusga");
            CreateReport("Şahsy maglumat(Işgär)");
            CreateReport("Şahsy maglumat(ma)");
            CreateReport("Şertnama");

            #endregion

      



            #endregion

            #region Company
            var company = ObjectSpace.FindObject<ICompany>(new BinaryOperator("CompanyId", 1));

            if (company == null)
            {

                company = ObjectSpace.CreateObject<ICompany>();
                company.AddressOfCompany = "Tegeran 25";
                company.CompanyId = 1;
               // company.logo = Properties.Resources.ExpressAppLogo;
                company.PhoneOfNumber = "8-012-01-01";
                company.TaxRegistrationNumber = "01254876358";
                company.TitleOfCompany = "Haýat Inşaat kärhanasy";
                company.NumberOfLocalEmployee = 2;

                var companyReprezentative = ObjectSpace.CreateObject<ICompanyRepresentative>();
                companyReprezentative.FullName = "Amanow Meret Jumaýewiç";
                companyReprezentative.PassportDetails = "AH-00154487, Gökdepe etraby, 01.01.2010 ý ";
                companyReprezentative.PhoneNumbers = "el: 864010507, Iş-33-48-44";
                companyReprezentative.Company = company;

                company.CurrentReprezentative = companyReprezentative;
                company.ContractEndPeriod = 10;
                company.ContractStartPeriod = 10;




            #endregion

                #region AppConf

                var appConf = ObjectSpace.CreateObject<AppConf>();
                appConf.ID = 1;
                appConf.InTurkmen = true;
                appConf.UseCompanyLogo = true;

                appConf.StartDate = DateTime.Today;
                appConf.TotalPreviousRegisteredDoc = 3;

                appConf.AddressExpireDay = 30;
                appConf.PassportExpireDay = 185;
                appConf.VisaExpireDay = 90;
                appConf.WorkPermitExpireDate = 90;

                #endregion

                #region BaseApplicationType


                var baseAppForInvitation = ObjectSpace.CreateObject<BaseApplicationType>();
                baseAppForInvitation.TypeOfBaseApplication = AppType.Invitation;
                baseAppForInvitation.IsLongProcessApp = true;



                var baseAppForRegistration = ObjectSpace.CreateObject<BaseApplicationType>();
                baseAppForRegistration.TypeOfBaseApplication = AppType.Registration;




                var baseAppForVisa = ObjectSpace.CreateObject<BaseApplicationType>();
                baseAppForVisa.TypeOfBaseApplication = AppType.Visa;
                baseAppForVisa.IsLongProcessApp = true;



                var baseAppForBorderZone = ObjectSpace.CreateObject<BaseApplicationType>();
                baseAppForBorderZone.TypeOfBaseApplication = AppType.BorderZone;
                baseAppForBorderZone.IsLongProcessApp = true;






                var baseAppForOthers = ObjectSpace.CreateObject<BaseApplicationType>();
                baseAppForOthers.TypeOfBaseApplication = AppType.Others;




                #endregion



                #region ApplicationTypeForEmployee


                var appTypeForEmpInvitation = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpInvitation.TypeOfApplicationForEmployee = SubType.ApplicationForInvitation;
                appTypeForEmpInvitation.TypeOfApplicationForEmployeeID = 0;
                appTypeForEmpInvitation.HasUrgency = true;
                appTypeForEmpInvitation.IsAplicableToMinistery = true;
                appTypeForEmpInvitation.IsBorderZoneRequired = true;
                appTypeForEmpInvitation.BaseApplicationType = baseAppForInvitation;
                appTypeForEmpInvitation.IsVisaCategoryVisible = true;
                appTypeForEmpInvitation.IsVisaPeriodVisible = true;
                appTypeForEmpInvitation.IsAddressVisible = true;
                appTypeForEmpInvitation.Invitation = true;
                appTypeForEmpInvitation.Position = true;
                appTypeForEmpInvitation.BorderZoneForPersonInApplication = true;
                appTypeForEmpInvitation.IsAddressedToChiefOfOrganization = true;
                appTypeForEmpInvitation.IsLongProcessApplication = true;
                appTypeForEmpInvitation.ApplicationResultVisibility = true;
                appTypeForEmpInvitation.ProcessNumberVisible = true;

                var appTypeForEmpInvitationR = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpInvitationR.TypeOfApplicationForEmployee = SubType.RugsatnamaMöhletineGöräÇakylyk;
                appTypeForEmpInvitationR.TypeOfApplicationForEmployeeID = 20;
                appTypeForEmpInvitationR.HasUrgency = true;
                appTypeForEmpInvitationR.IsAplicableToMinistery = true;
                appTypeForEmpInvitationR.IsBorderZoneRequired = true;
                appTypeForEmpInvitationR.BaseApplicationType = baseAppForInvitation;
                appTypeForEmpInvitationR.IsVisaCategoryVisible = true;
                appTypeForEmpInvitationR.IsVisaPeriodVisible = true;
                appTypeForEmpInvitationR.IsAddressVisible = true;
                appTypeForEmpInvitationR.Invitation = true;
                appTypeForEmpInvitationR.Position = true;
                appTypeForEmpInvitationR.BorderZoneForPersonInApplication = true;
                appTypeForEmpInvitationR.IsAddressedToChiefOfOrganization = true;
                appTypeForEmpInvitationR.IsLongProcessApplication = true;
                appTypeForEmpInvitationR.ApplicationResultVisibility = true;
                appTypeForEmpInvitationR.ProcessNumberVisible = true;


                var appTypeForSevicePasport = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForSevicePasport.TypeOfApplicationForEmployee = SubType.ApplicationForSevicePasport;
                appTypeForSevicePasport.TypeOfApplicationForEmployeeID = 1;
                appTypeForSevicePasport.HasUrgency = false;
                appTypeForSevicePasport.IsAplicableToMinistery = true;
                appTypeForSevicePasport.IsBorderZoneRequired = true;
                appTypeForSevicePasport.BaseApplicationType = baseAppForInvitation;
                appTypeForSevicePasport.IsVisaCategoryVisible = false;
                appTypeForSevicePasport.IsVisaPeriodVisible = false;
                appTypeForSevicePasport.Position = true;
                appTypeForSevicePasport.BorderZoneForPersonInApplication = true;
                appTypeForSevicePasport.IsAddressedToChiefOfOrganization = true;
                appTypeForSevicePasport.IsLongProcessApplication = true;
                appTypeForSevicePasport.ApplicationResultVisibility = true;
                appTypeForSevicePasport.ProcessNumberVisible = true;
                appTypeForSevicePasport.Invitation = true;
                appTypeForSevicePasport.IsAddressVisible = true;

                var appTypeForEmpChangingInvitation = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpChangingInvitation.TypeOfApplicationForEmployee = SubType.ApplicationForChangingInvitation;
                appTypeForEmpChangingInvitation.TypeOfApplicationForEmployeeID = 2;
                appTypeForEmpChangingInvitation.HasUrgency = false;
                appTypeForEmpChangingInvitation.IsAplicableToMinistery = false;
                appTypeForEmpChangingInvitation.IsBorderZoneRequired = false;
                appTypeForEmpChangingInvitation.BaseApplicationType = baseAppForInvitation;
                appTypeForEmpChangingInvitation.IsVisaCategoryVisible = false;
                appTypeForEmpChangingInvitation.IsVisaPeriodVisible = false;
                appTypeForEmpChangingInvitation.InvitationToBeChanged = true;
                appTypeForEmpChangingInvitation.Position = true;
                appTypeForEmpChangingInvitation.Invitation = true;
                appTypeForEmpChangingInvitation.TDMGAdy = true;
                appTypeForEmpChangingInvitation.IsAddressVisible = true;
                appTypeForEmpChangingInvitation.ApplicationResultVisibility = true;

                var appTypeForEmpRegistrationUpOnArrival = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpRegistrationUpOnArrival.TypeOfApplicationForEmployee = SubType.ApplicationForRegistrationUpOnArrival;
                appTypeForEmpRegistrationUpOnArrival.TypeOfApplicationForEmployeeID = 3;
                appTypeForEmpRegistrationUpOnArrival.HasUrgency = false;
                appTypeForEmpRegistrationUpOnArrival.IsAplicableToMinistery = false;
                appTypeForEmpRegistrationUpOnArrival.IsBorderZoneRequired = false;
                appTypeForEmpRegistrationUpOnArrival.BaseApplicationType = baseAppForRegistration;
                appTypeForEmpRegistrationUpOnArrival.IsVisaCategoryVisible = false;
                appTypeForEmpRegistrationUpOnArrival.IsVisaPeriodVisible = false;
                appTypeForEmpRegistrationUpOnArrival.AddressOfResidence = true;
                appTypeForEmpRegistrationUpOnArrival.Position = true;
                appTypeForEmpRegistrationUpOnArrival.RegistrationDataForPersonInApplication = true;
                appTypeForEmpRegistrationUpOnArrival.VisaVisibleForPersonInApplication = true;
                appTypeForEmpRegistrationUpOnArrival.RegistrationNumberAndDateVisible = true;
                appTypeForEmpRegistrationUpOnArrival.DepartmentForRegistrationVisible = true;


                var appTypeForEmpRegistrationExtention = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpRegistrationExtention.TypeOfApplicationForEmployee = SubType.ApplicationForRegistrationExtention;
                appTypeForEmpRegistrationExtention.TypeOfApplicationForEmployeeID = 4;
                appTypeForEmpRegistrationExtention.HasUrgency = false;
                appTypeForEmpRegistrationExtention.IsAplicableToMinistery = false;
                appTypeForEmpRegistrationExtention.IsBorderZoneRequired = false;
                appTypeForEmpRegistrationExtention.BaseApplicationType = baseAppForRegistration;
                appTypeForEmpRegistrationExtention.IsVisaCategoryVisible = false;
                appTypeForEmpRegistrationExtention.IsVisaPeriodVisible = false;
                appTypeForEmpRegistrationExtention.AddressOfResidence = true;
                appTypeForEmpRegistrationExtention.Position = true;
                appTypeForEmpRegistrationExtention.VisaVisibleForPersonInApplication = true;
                appTypeForEmpRegistrationExtention.DepartmentForRegistrationVisible = true;


                var appTypeForEmpRegisteringToANewLocation = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpRegisteringToANewLocation.TypeOfApplicationForEmployee = SubType.ApplicationForRegisteringToANewLocation;
                appTypeForEmpRegisteringToANewLocation.TypeOfApplicationForEmployeeID = 5;
                appTypeForEmpRegisteringToANewLocation.HasUrgency = false;
                appTypeForEmpRegisteringToANewLocation.IsAplicableToMinistery = false;
                appTypeForEmpRegisteringToANewLocation.IsBorderZoneRequired = false;
                appTypeForEmpRegisteringToANewLocation.BaseApplicationType = baseAppForRegistration;
                appTypeForEmpRegisteringToANewLocation.IsVisaPeriodVisible = false;
                appTypeForEmpRegisteringToANewLocation.IsVisaCategoryVisible = false;
                appTypeForEmpRegisteringToANewLocation.AddressOfResidence = true;
                appTypeForEmpRegisteringToANewLocation.Position = true;
                appTypeForEmpRegisteringToANewLocation.RegistrationDataForPersonInApplication = true;
                appTypeForEmpRegisteringToANewLocation.VisaVisibleForPersonInApplication = true;
                appTypeForEmpRegisteringToANewLocation.RegistrationNumberAndDateVisible = true;
                appTypeForEmpRegisteringToANewLocation.DepartmentForRegistrationVisible = true;

                var appTypeForEmpChagingInformation = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpChagingInformation.TypeOfApplicationForEmployee = SubType.ApplicationForChagingInformation;
                appTypeForEmpChagingInformation.TypeOfApplicationForEmployeeID = 6;
                appTypeForEmpChagingInformation.HasUrgency = false;
                appTypeForEmpChagingInformation.IsAplicableToMinistery = false;
                appTypeForEmpChagingInformation.IsBorderZoneRequired = false;
                appTypeForEmpChagingInformation.BaseApplicationType = baseAppForRegistration;
                appTypeForEmpChagingInformation.IsVisaCategoryVisible = false;
                appTypeForEmpChagingInformation.IsVisaPeriodVisible = false;
                appTypeForEmpChagingInformation.AddressOfResidence = true;
                appTypeForEmpChagingInformation.Position = true;
                appTypeForEmpChagingInformation.VisaVisibleForPersonInApplication = true;
                appTypeForEmpChagingInformation.DepartmentForRegistrationVisible = true;

                var appTypeForEmpStrikeOffRegister = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpStrikeOffRegister.TypeOfApplicationForEmployee = SubType.ApplicationForStrikeOffRegister;
                appTypeForEmpStrikeOffRegister.TypeOfApplicationForEmployeeID = 7;
                appTypeForEmpStrikeOffRegister.HasUrgency = false;
                appTypeForEmpStrikeOffRegister.IsAplicableToMinistery = false;
                appTypeForEmpStrikeOffRegister.IsBorderZoneRequired = false;
                appTypeForEmpStrikeOffRegister.BaseApplicationType = baseAppForRegistration;
                appTypeForEmpStrikeOffRegister.IsVisaCategoryVisible = false;
                appTypeForEmpStrikeOffRegister.IsVisaPeriodVisible = false;
                appTypeForEmpStrikeOffRegister.AddressOfResidence = true;
                appTypeForEmpStrikeOffRegister.Position = true;
                appTypeForEmpStrikeOffRegister.VisaVisibleForPersonInApplication = true;
                appTypeForEmpStrikeOffRegister.DepartmentForRegistrationVisible = true;

                var appTypeForEmpVisaExtention = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpVisaExtention.TypeOfApplicationForEmployee = SubType.ApplicationForVisaExtention;
                appTypeForEmpVisaExtention.TypeOfApplicationForEmployeeID = 8;
                appTypeForEmpVisaExtention.HasUrgency = true;
                appTypeForEmpVisaExtention.IsAplicableToMinistery = true;
                appTypeForEmpVisaExtention.IsBorderZoneRequired = true;
                appTypeForEmpVisaExtention.BaseApplicationType = baseAppForVisa;
                appTypeForEmpVisaExtention.IsVisaPeriodVisible = true;
                appTypeForEmpVisaExtention.IsVisaCategoryVisible = true;
                appTypeForEmpVisaExtention.ProcessNumberVisible = true;

                appTypeForEmpVisaExtention.AddressOfResidence = true;
                appTypeForEmpVisaExtention.Position = true;
                appTypeForEmpVisaExtention.BorderZoneForPersonInApplication = true;
                appTypeForEmpVisaExtention.VisaVisibleForPersonInApplication = true;
                appTypeForEmpVisaExtention.IsAddressedToChiefOfOrganization = true;
                appTypeForEmpVisaExtention.IsLongProcessApplication = true;
                appTypeForEmpVisaExtention.ApplicationResultVisibility = true;
                appTypeForEmpVisaExtention.WorkPermitForPersonInLineVisible = true;
                var appTypeForEmpChangingVisaCategory = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpChangingVisaCategory.TypeOfApplicationForEmployee = SubType.ApplicationForChangingVisaCategory;
                appTypeForEmpChangingVisaCategory.TypeOfApplicationForEmployeeID = 9;
                appTypeForEmpChangingVisaCategory.HasUrgency = true;
                appTypeForEmpChangingVisaCategory.IsAplicableToMinistery = false;
                appTypeForEmpChangingVisaCategory.IsBorderZoneRequired = false;
                appTypeForEmpChangingVisaCategory.BaseApplicationType = baseAppForVisa;
                appTypeForEmpChangingVisaCategory.IsVisaCategoryVisible = false;
                appTypeForEmpChangingVisaCategory.IsVisaPeriodVisible = false;
                appTypeForEmpChangingVisaCategory.AddressOfResidence = true;
                appTypeForEmpChangingVisaCategory.Position = true;
                appTypeForEmpChangingVisaCategory.VisaVisibleForPersonInApplication = true;
                appTypeForEmpChangingVisaCategory.ProcessNumberVisible = true;
                appTypeForEmpChangingVisaCategory.PrefferedVisaCategoryVisibility = true;
                appTypeForEmpChangingVisaCategory.TDMGAdy = true;
                var appTypeForEmpChangingPassport = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpChangingPassport.TypeOfApplicationForEmployee = SubType.ApplicationForChangingPassport;
                appTypeForEmpChangingPassport.TypeOfApplicationForEmployeeID = 10;
                appTypeForEmpChangingPassport.HasUrgency = true;
                appTypeForEmpChangingPassport.IsAplicableToMinistery = false;
                appTypeForEmpChangingPassport.IsBorderZoneRequired = false;
                appTypeForEmpChangingPassport.BaseApplicationType = baseAppForVisa;
                appTypeForEmpChangingPassport.IsVisaCategoryVisible = false;
                appTypeForEmpChangingPassport.IsVisaPeriodVisible = false;
                appTypeForEmpChangingPassport.AddressOfResidence = true;
                appTypeForEmpChangingPassport.Position = true;
                appTypeForEmpChangingPassport.VisaVisibleForPersonInApplication = true;
                appTypeForEmpChangingPassport.ProcessNumberVisible = true;
                appTypeForEmpChangingPassport.PreviousPassportInAppLineVisible = true;
                appTypeForEmpChangingPassport.TDMGAdy = true;


                var appTypeForEmpCancellingVisaAndWorkpermit = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpCancellingVisaAndWorkpermit.TypeOfApplicationForEmployee = SubType.ApplicationForCancellingVisaAndWorkpermit;
                appTypeForEmpCancellingVisaAndWorkpermit.TypeOfApplicationForEmployeeID = 11;
                appTypeForEmpCancellingVisaAndWorkpermit.HasUrgency = false;
                appTypeForEmpCancellingVisaAndWorkpermit.IsAplicableToMinistery = false;
                appTypeForEmpCancellingVisaAndWorkpermit.IsBorderZoneRequired = false;
                appTypeForEmpCancellingVisaAndWorkpermit.BaseApplicationType = baseAppForVisa;
                appTypeForEmpCancellingVisaAndWorkpermit.IsVisaCategoryVisible = false;
                appTypeForEmpCancellingVisaAndWorkpermit.IsVisaPeriodVisible = false;
                appTypeForEmpCancellingVisaAndWorkpermit.AddressOfResidence = true;
                appTypeForEmpCancellingVisaAndWorkpermit.Position = true;
                appTypeForEmpCancellingVisaAndWorkpermit.VisaVisibleForPersonInApplication = true;
                appTypeForEmpCancellingVisaAndWorkpermit.WorkPermitForPersonInLineVisible = true;
                appTypeForEmpCancellingVisaAndWorkpermit.TDMGAdy = true;
                var appTypeForEmpBorderZonePermision = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpBorderZonePermision.TypeOfApplicationForEmployee = SubType.ApplicationForBorderZonePermision;
                appTypeForEmpBorderZonePermision.TypeOfApplicationForEmployeeID = 12;
                appTypeForEmpBorderZonePermision.HasUrgency = true;
                appTypeForEmpBorderZonePermision.IsAplicableToMinistery = false;
                appTypeForEmpBorderZonePermision.IsBorderZoneRequired = true;
                appTypeForEmpBorderZonePermision.BaseApplicationType = baseAppForBorderZone;
                appTypeForEmpBorderZonePermision.IsVisaCategoryVisible = false;
                appTypeForEmpBorderZonePermision.IsVisaPeriodVisible = false;
                appTypeForEmpBorderZonePermision.AddressOfResidence = true;
                appTypeForEmpBorderZonePermision.Position = true;
                appTypeForEmpBorderZonePermision.BorderZoneForPersonInApplication = true;
                appTypeForEmpBorderZonePermision.VisaVisibleForPersonInApplication = true;
                appTypeForEmpBorderZonePermision.ProcessNumberVisible = true;
                appTypeForEmpBorderZonePermision.BorderZonePeriodVisibility = true;
                appTypeForEmpBorderZonePermision.IsLongProcessApplication = true;
                appTypeForEmpBorderZonePermision.IsAplicableToMinistery = true;
                appTypeForEmpBorderZonePermision.IsAddressedToChiefOfOrganization = true;

                var appTypeForEmpGoBusinessTrip = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpGoBusinessTrip.TypeOfApplicationForEmployee = SubType.ApplicationForGoBusinessTrip;
                appTypeForEmpGoBusinessTrip.TypeOfApplicationForEmployeeID = 13;
                appTypeForEmpGoBusinessTrip.HasUrgency = false;
                appTypeForEmpGoBusinessTrip.IsAplicableToMinistery = false;
                appTypeForEmpGoBusinessTrip.IsBorderZoneRequired = false;
                appTypeForEmpGoBusinessTrip.BaseApplicationType = baseAppForOthers;
                appTypeForEmpGoBusinessTrip.IsVisaCategoryVisible = false;
                appTypeForEmpGoBusinessTrip.IsVisaPeriodVisible = false;
                appTypeForEmpGoBusinessTrip.AddressOfResidence = true;
                appTypeForEmpGoBusinessTrip.Position = true;
                appTypeForEmpGoBusinessTrip.VisaVisibleForPersonInApplication = true;
                appTypeForEmpGoBusinessTrip.DepartmentForRegistrationVisible = true;
                appTypeForEmpGoBusinessTrip.BusinessTripDestinationVisibility = true;

                var appTypeForEmpCameFromBusinessTrip = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpCameFromBusinessTrip.TypeOfApplicationForEmployee = SubType.ApplicationForCameFromBusinessTrip;
                appTypeForEmpCameFromBusinessTrip.TypeOfApplicationForEmployeeID = 14;
                appTypeForEmpCameFromBusinessTrip.HasUrgency = false;
                appTypeForEmpCameFromBusinessTrip.IsAplicableToMinistery = false;
                appTypeForEmpCameFromBusinessTrip.IsBorderZoneRequired = false;
                appTypeForEmpCameFromBusinessTrip.BaseApplicationType = baseAppForOthers;
                appTypeForEmpCameFromBusinessTrip.IsVisaCategoryVisible = false;
                appTypeForEmpCameFromBusinessTrip.IsVisaPeriodVisible = false;
                appTypeForEmpCameFromBusinessTrip.AddressOfResidence = true;
                appTypeForEmpCameFromBusinessTrip.Position = true;
                appTypeForEmpCameFromBusinessTrip.VisaVisibleForPersonInApplication = true;
                appTypeForEmpCameFromBusinessTrip.DepartmentForRegistrationVisible = true;

                var appTypeForEmpExtendingWorkPermitLocation = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpExtendingWorkPermitLocation.TypeOfApplicationForEmployee = SubType.ApplicationForExtendingWorkPermitLocation;
                appTypeForEmpExtendingWorkPermitLocation.TypeOfApplicationForEmployeeID = 15;
                appTypeForEmpExtendingWorkPermitLocation.IsAplicableToMinistery = false;
                appTypeForEmpExtendingWorkPermitLocation.BaseApplicationType = baseAppForOthers;
                appTypeForEmpExtendingWorkPermitLocation.IsBorderZoneRequired = false;
                appTypeForEmpExtendingWorkPermitLocation.HasUrgency = false;
                appTypeForEmpExtendingWorkPermitLocation.IsVisaCategoryVisible = false;
                appTypeForEmpExtendingWorkPermitLocation.IsVisaPeriodVisible = false;
                appTypeForEmpExtendingWorkPermitLocation.AddressOfResidence = true;
                appTypeForEmpExtendingWorkPermitLocation.Position = true;
                appTypeForEmpExtendingWorkPermitLocation.VisaVisibleForPersonInApplication = true;

                var appTypeForEmpExitVisa = ObjectSpace.CreateObject<ApplicationTypeForEmployee>();
                appTypeForEmpExitVisa.TypeOfApplicationForEmployee = SubType.ApplicationForExitVisa;
                appTypeForEmpExitVisa.TypeOfApplicationForEmployeeID = 55;
                appTypeForEmpExitVisa.IsAplicableToMinistery = false;
                appTypeForEmpExitVisa.BaseApplicationType = baseAppForOthers;
                appTypeForEmpExitVisa.IsBorderZoneRequired = false;
                appTypeForEmpExitVisa.HasUrgency = false;
                appTypeForEmpExitVisa.IsVisaCategoryVisible = false;
                appTypeForEmpExitVisa.IsVisaPeriodVisible = false;
                appTypeForEmpExitVisa.AddressOfResidence = true;
                appTypeForEmpExitVisa.Position = true;
                appTypeForEmpExitVisa.VisaVisibleForPersonInApplication = true;

                #endregion

                #region ApplicationTypeForFamilyMemmber





                var appTypeForFMInvitation = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMInvitation.TypeOfApplicationForFamilyMember = SubType.ApplicationForInvitation;
                appTypeForFMInvitation.TypeOfApplicationForFamilyMemberID = 0;
                appTypeForFMInvitation.HasUrgency = true;
                appTypeForFMInvitation.IsAplicableToMinistery = false;
                appTypeForFMInvitation.IsBorderZoneRequired = true;
                appTypeForFMInvitation.BaseApplicationType = baseAppForInvitation;
                appTypeForFMInvitation.IsVisaCategoryVisible = true;
                appTypeForFMInvitation.IsVisaPeriodVisible = true;
                appTypeForFMInvitation.IsAddressVisible = true;
                appTypeForFMInvitation.Invitation = true;
                appTypeForFMInvitation.Position = true;
                appTypeForFMInvitation.BorderZoneForPersonInApplication = true;

                appTypeForFMInvitation.TDMGAdy = true;
                appTypeForFMInvitation.ApplicationResultVisibility = true;
                appTypeForFMInvitation.ProcessNumberVisible = true;



                var appTypeForFMChangingInvitation = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMChangingInvitation.TypeOfApplicationForFamilyMember = SubType.ApplicationForChangingInvitation;
                appTypeForFMChangingInvitation.TypeOfApplicationForFamilyMemberID = 2;
                appTypeForFMChangingInvitation.HasUrgency = false;
                appTypeForFMChangingInvitation.IsAplicableToMinistery = false;
                appTypeForFMChangingInvitation.IsBorderZoneRequired = false;
                appTypeForFMChangingInvitation.BaseApplicationType = baseAppForInvitation;
                appTypeForFMChangingInvitation.IsVisaCategoryVisible = false;
                appTypeForFMChangingInvitation.IsVisaPeriodVisible = false;
                appTypeForFMChangingInvitation.InvitationToBeChanged = true;
                appTypeForFMChangingInvitation.Position = true;
                appTypeForFMChangingInvitation.Invitation = true;
                appTypeForFMChangingInvitation.TDMGAdy = true;
                appTypeForFMChangingInvitation.IsAddressVisible = true;
                appTypeForFMChangingInvitation.ApplicationResultVisibility = true;

                var appTypeForFMRegistrationUpOnArrival = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMRegistrationUpOnArrival.TypeOfApplicationForFamilyMember = SubType.ApplicationForRegistrationUpOnArrival;
                appTypeForFMRegistrationUpOnArrival.TypeOfApplicationForFamilyMemberID = 3;
                appTypeForFMRegistrationUpOnArrival.HasUrgency = false;
                appTypeForFMRegistrationUpOnArrival.IsAplicableToMinistery = false;
                appTypeForFMRegistrationUpOnArrival.IsBorderZoneRequired = false;
                appTypeForFMRegistrationUpOnArrival.BaseApplicationType = baseAppForRegistration;
                appTypeForFMRegistrationUpOnArrival.IsVisaCategoryVisible = false;
                appTypeForFMRegistrationUpOnArrival.IsVisaPeriodVisible = false;
                appTypeForFMRegistrationUpOnArrival.AddressOfResidence = true;
                appTypeForFMRegistrationUpOnArrival.Position = true;
                appTypeForFMRegistrationUpOnArrival.RegistrationDataForPersonInApplication = true;
                appTypeForFMRegistrationUpOnArrival.VisaVisibleForPersonInApplication = true;
                appTypeForFMRegistrationUpOnArrival.RegistrationNumberAndDateVisible = true;
                appTypeForFMRegistrationUpOnArrival.DepartmentForRegistrationVisible = true;

                var appTypeForFMRegistrationExtention = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMRegistrationExtention.TypeOfApplicationForFamilyMember = SubType.ApplicationForRegistrationExtention;
                appTypeForFMRegistrationExtention.TypeOfApplicationForFamilyMemberID = 4;
                appTypeForFMRegistrationExtention.HasUrgency = false;
                appTypeForFMRegistrationExtention.IsAplicableToMinistery = false;
                appTypeForFMRegistrationExtention.IsBorderZoneRequired = false;
                appTypeForFMRegistrationExtention.BaseApplicationType = baseAppForRegistration;
                appTypeForFMRegistrationExtention.IsVisaCategoryVisible = false;
                appTypeForFMRegistrationExtention.IsVisaPeriodVisible = false;
                appTypeForFMRegistrationExtention.AddressOfResidence = true;
                appTypeForFMRegistrationExtention.Position = true;
                appTypeForFMRegistrationExtention.VisaVisibleForPersonInApplication = true;
                appTypeForFMRegistrationExtention.DepartmentForRegistrationVisible = true;

                var appTypeForFMRegisteringToANewLocation = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMRegisteringToANewLocation.TypeOfApplicationForFamilyMember = SubType.ApplicationForRegisteringToANewLocation;
                appTypeForFMRegisteringToANewLocation.TypeOfApplicationForFamilyMemberID = 5;
                appTypeForFMRegisteringToANewLocation.HasUrgency = false;
                appTypeForFMRegisteringToANewLocation.IsAplicableToMinistery = false;
                appTypeForFMRegisteringToANewLocation.IsBorderZoneRequired = false;
                appTypeForFMRegisteringToANewLocation.BaseApplicationType = baseAppForRegistration;
                appTypeForFMRegisteringToANewLocation.IsVisaCategoryVisible = false;
                appTypeForFMRegisteringToANewLocation.IsVisaPeriodVisible = false;
                appTypeForFMRegisteringToANewLocation.AddressOfResidence = true;
                appTypeForFMRegisteringToANewLocation.Position = true;
                appTypeForFMRegisteringToANewLocation.RegistrationDataForPersonInApplication = true;
                appTypeForFMRegisteringToANewLocation.VisaVisibleForPersonInApplication = true;
                appTypeForFMRegisteringToANewLocation.RegistrationNumberAndDateVisible = true;
                appTypeForFMRegisteringToANewLocation.DepartmentForRegistrationVisible = true;

                var appTypeForFMChagingInformation = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMChagingInformation.TypeOfApplicationForFamilyMember = SubType.ApplicationForChagingInformation;
                appTypeForFMChagingInformation.TypeOfApplicationForFamilyMemberID = 6;
                appTypeForFMChagingInformation.HasUrgency = false;
                appTypeForFMChagingInformation.IsAplicableToMinistery = false;
                appTypeForFMChagingInformation.IsBorderZoneRequired = false;
                appTypeForFMChagingInformation.BaseApplicationType = baseAppForRegistration;
                appTypeForFMChagingInformation.IsVisaCategoryVisible = false;
                appTypeForFMChagingInformation.IsVisaPeriodVisible = false;
                appTypeForFMChagingInformation.AddressOfResidence = true;
                appTypeForFMChagingInformation.Position = true;
                appTypeForFMChagingInformation.VisaVisibleForPersonInApplication = true;
                appTypeForFMChagingInformation.DepartmentForRegistrationVisible = true;

                var appTypeForFMStrikeOffRegister = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMStrikeOffRegister.TypeOfApplicationForFamilyMember = SubType.ApplicationForStrikeOffRegister;
                appTypeForFMStrikeOffRegister.TypeOfApplicationForFamilyMemberID = 7;
                appTypeForFMStrikeOffRegister.BaseApplicationType = baseAppForRegistration;
                appTypeForFMStrikeOffRegister.IsAplicableToMinistery = false;
                appTypeForFMStrikeOffRegister.IsBorderZoneRequired = false;
                appTypeForFMStrikeOffRegister.HasUrgency = false;
                appTypeForFMStrikeOffRegister.IsVisaCategoryVisible = false;
                appTypeForFMStrikeOffRegister.IsVisaPeriodVisible = false;
                appTypeForFMStrikeOffRegister.AddressOfResidence = true;
                appTypeForFMStrikeOffRegister.Position = true;
                appTypeForFMStrikeOffRegister.VisaVisibleForPersonInApplication = true;
                appTypeForFMStrikeOffRegister.DepartmentForRegistrationVisible = true;

                var appTypeForFMVisaExtention = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMVisaExtention.TypeOfApplicationForFamilyMember = SubType.ApplicationForVisaExtention;
                appTypeForFMVisaExtention.TypeOfApplicationForFamilyMemberID = 8;
                appTypeForFMVisaExtention.BaseApplicationType = baseAppForVisa;
                appTypeForFMVisaExtention.IsAplicableToMinistery = false;
                appTypeForFMVisaExtention.IsBorderZoneRequired = true;
                appTypeForFMVisaExtention.HasUrgency = true;
                appTypeForFMVisaExtention.IsVisaCategoryVisible = true;
                appTypeForFMVisaExtention.IsVisaPeriodVisible = true;
                appTypeForFMVisaExtention.AddressOfResidence = true;
                appTypeForFMVisaExtention.Position = true;
                appTypeForFMVisaExtention.BorderZoneForPersonInApplication = true;
                appTypeForFMVisaExtention.VisaVisibleForPersonInApplication = true;
                appTypeForFMVisaExtention.TDMGAdy = true;
                appTypeForFMVisaExtention.ApplicationResultVisibility = true;
                appTypeForFMVisaExtention.ProcessNumberVisible = true;

                var appTypeForFMChangingVisaCategory = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMChangingVisaCategory.TypeOfApplicationForFamilyMember = SubType.ApplicationForChangingVisaCategory;
                appTypeForFMChangingVisaCategory.TypeOfApplicationForFamilyMemberID = 9;
                appTypeForFMChangingVisaCategory.BaseApplicationType = baseAppForVisa;
                appTypeForFMChangingVisaCategory.IsAplicableToMinistery = false;
                appTypeForFMChangingVisaCategory.IsBorderZoneRequired = false;
                appTypeForFMChangingVisaCategory.HasUrgency = true;
                appTypeForFMChangingVisaCategory.IsVisaCategoryVisible = false;
                appTypeForFMChangingVisaCategory.IsVisaPeriodVisible = false;
                appTypeForFMChangingVisaCategory.AddressOfResidence = true;
                appTypeForFMChangingVisaCategory.Position = true;
                appTypeForFMChangingVisaCategory.VisaVisibleForPersonInApplication = true;
                appTypeForFMChangingVisaCategory.ProcessNumberVisible = true;
                appTypeForFMChangingVisaCategory.PrefferedVisaCategoryVisibility = true;
                appTypeForFMChangingVisaCategory.TDMGAdy = true;
                appTypeForFMChangingVisaCategory.TDMGAdy = true;

                var appTypeForFMChangingPassport = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMChangingPassport.TypeOfApplicationForFamilyMember = SubType.ApplicationForChangingPassport;
                appTypeForFMChangingPassport.TypeOfApplicationForFamilyMemberID = 10;
                appTypeForFMChangingPassport.BaseApplicationType = baseAppForVisa;
                appTypeForFMChangingPassport.IsAplicableToMinistery = false;
                appTypeForFMChangingPassport.IsBorderZoneRequired = false;

                appTypeForFMChangingPassport.HasUrgency = true;
                appTypeForFMChangingPassport.IsVisaCategoryVisible = false;
                appTypeForFMChangingPassport.IsVisaPeriodVisible = false;
                appTypeForFMChangingPassport.AddressOfResidence = true;
                appTypeForFMChangingPassport.Position = true;
                appTypeForFMChangingPassport.VisaVisibleForPersonInApplication = true;
                appTypeForFMChangingPassport.ProcessNumberVisible = true;
                appTypeForFMChangingPassport.PreviousPassportInAppLineVisible = true;
                appTypeForFMChangingPassport.TDMGAdy = true;

                var appTypeForFMBorderZonePermision = ObjectSpace.CreateObject<ApplicationTypeForFamilyMember>();
                appTypeForFMBorderZonePermision.TypeOfApplicationForFamilyMember = SubType.ApplicationForBorderZonePermision;
                appTypeForFMBorderZonePermision.TypeOfApplicationForFamilyMemberID = 12;
                appTypeForFMBorderZonePermision.BaseApplicationType = baseAppForBorderZone;
                appTypeForFMBorderZonePermision.HasUrgency = true;
                appTypeForFMBorderZonePermision.IsBorderZoneRequired = true;
                appTypeForFMBorderZonePermision.IsAplicableToMinistery = false;
                appTypeForFMBorderZonePermision.IsVisaCategoryVisible = false;
                appTypeForFMBorderZonePermision.IsVisaPeriodVisible = false;
                appTypeForFMBorderZonePermision.AddressOfResidence = true;
                appTypeForFMBorderZonePermision.Position = true;
                appTypeForFMBorderZonePermision.BorderZoneForPersonInApplication = true;
                appTypeForFMBorderZonePermision.VisaVisibleForPersonInApplication = true;
                appTypeForFMBorderZonePermision.ProcessNumberVisible = true;
                appTypeForFMBorderZonePermision.BorderZonePeriodVisibility = true;

                #endregion

                #region IsWorkPermitForInvitationRequired






                var wpForInvitNotRequired = ObjectSpace.CreateObject<IsInvitationWithWorkPermit>();
                wpForInvitNotRequired.InvitationAndWorkPermitRequired = WPForInvitationRequired.OnlyInvitation;
                wpForInvitNotRequired.InvitationAndWorkPermitRequiredL = "çakylyk";





                var wpForInvitRequired = ObjectSpace.CreateObject<IsInvitationWithWorkPermit>();
                wpForInvitRequired.InvitationAndWorkPermitRequired = WPForInvitationRequired.InvitationAndWorkPermit;
                wpForInvitRequired.InvitationAndWorkPermitRequiredL = "çakylyk we iş rugsatnama";






                #endregion

                #region IsWorkPermitForVisaRequired

                var wpForVisaNotRequired = ObjectSpace.CreateObject<IsWizaWithWorkPermit>();
                wpForVisaNotRequired.WizaAndWorkPermitRequired = IsWPForWizaRequired.OnlyWiza;
                wpForVisaNotRequired.WizaAndWorkPermitRequiredL = "wiza";





                var wpForVisaRequired = ObjectSpace.CreateObject<IsWizaWithWorkPermit>();
                wpForVisaRequired.WizaAndWorkPermitRequired = IsWPForWizaRequired.WizaAndWorkPermit;
                wpForVisaRequired.WizaAndWorkPermitRequiredL = "wiza we iş rugsatnama";




                #endregion


                #region Department For Registration

                var TDMG = ObjectSpace.CreateObject<DepartmentForRegistration>();
                TDMG.TitleOfDepartmentForRegistration = "TDMG";
                TDMG.DepartmentForRegistrationL = "Türkmenistanyň Döwlet migrasiýa gullugyna";

                var TDMGLB = ObjectSpace.CreateObject<DepartmentForRegistration>();
                TDMGLB.TitleOfDepartmentForRegistration = "TDMGLB";
                TDMGLB.DepartmentForRegistrationL = "Lebap welaýaty boýunça migrasiýa müdirligine";


                var TDMGMR = ObjectSpace.CreateObject<DepartmentForRegistration>();
                TDMGMR.TitleOfDepartmentForRegistration = "TDMGMR";
                TDMGMR.DepartmentForRegistrationL = "Mary welaýaty boýunça migrasiýa müdirligine";

                var TDMGAH = ObjectSpace.CreateObject<DepartmentForRegistration>();
                TDMGAH.TitleOfDepartmentForRegistration = "TDMGAH";
                TDMGAH.DepartmentForRegistrationL = "Ahal welaýaty boýunça migrasiýa müdirligine";

                var TDMGBN = ObjectSpace.CreateObject<DepartmentForRegistration>();
                TDMGBN.TitleOfDepartmentForRegistration = "TDMGBN";
                TDMGBN.DepartmentForRegistrationL = "Balkan welaýaty boýunça migrasiýa müdirligine";

                #endregion

                #region CheckPoint

                var checkpointAşgabatŞäherHowaMenzilindäkiMGP = ObjectSpace.CreateObject<CheckPoint>();
                checkpointAşgabatŞäherHowaMenzilindäkiMGP.TitleOfCheckPoint = CheckPointEn.AşgabatŞäherHowaMenzilindäkiMGP;
                checkpointAşgabatŞäherHowaMenzilindäkiMGP.TitleOfCheckPointL = "Aşgabat şäher howa menzilindäki MGP";


                var checkpointHowdanMGP = ObjectSpace.CreateObject<CheckPoint>();
                checkpointHowdanMGP.TitleOfCheckPoint = CheckPointEn.HowdanMGP;
                checkpointHowdanMGP.TitleOfCheckPointL = "Howdan MGP";

                var checkpointDaşoguzMGP = ObjectSpace.CreateObject<CheckPoint>();
                checkpointDaşoguzMGP.TitleOfCheckPoint = CheckPointEn.DaşoguzMGP;
                checkpointDaşoguzMGP.TitleOfCheckPointL = "Daşoguz ş. MGP";

                var KöneürgençMGP = ObjectSpace.CreateObject<CheckPoint>();
                KöneürgençMGP.TitleOfCheckPoint = CheckPointEn.KöneürgençMGP;
                KöneürgençMGP.TitleOfCheckPointL = "Köneürgenç ş. MGP";

                var FarapMGP = ObjectSpace.CreateObject<CheckPoint>();
                FarapMGP.TitleOfCheckPoint = CheckPointEn.FarapMGP;
                FarapMGP.TitleOfCheckPointL = "Farap MGP";

                var YmamnazarMGP = ObjectSpace.CreateObject<CheckPoint>();
                YmamnazarMGP.TitleOfCheckPoint = CheckPointEn.YmamnazarMGP;
                YmamnazarMGP.TitleOfCheckPointL = "Ymamnazar MGP";


                var TallymerjenMGP = ObjectSpace.CreateObject<CheckPoint>();
                TallymerjenMGP.TitleOfCheckPoint = CheckPointEn.TallymerjenMGP;
                TallymerjenMGP.TitleOfCheckPointL = "Tallymerjen MGP";

                var SerhetabatMGP = ObjectSpace.CreateObject<CheckPoint>();
                SerhetabatMGP.TitleOfCheckPoint = CheckPointEn.SerhetabatMGP;
                SerhetabatMGP.TitleOfCheckPointL = "Serhetabat ş. MGP";

                var ArtykMGP = ObjectSpace.CreateObject<CheckPoint>();
                ArtykMGP.TitleOfCheckPoint = CheckPointEn.ArtykMGP;
                ArtykMGP.TitleOfCheckPointL = "Artyk MGP";

                var SarahsMGP = ObjectSpace.CreateObject<CheckPoint>();
                SarahsMGP.TitleOfCheckPoint = CheckPointEn.SarahsMGP;
                SarahsMGP.TitleOfCheckPointL = "Sarahs MGP";


                var EtrekMGP = ObjectSpace.CreateObject<CheckPoint>();
                EtrekMGP.TitleOfCheckPoint = CheckPointEn.EtrekMGP;
                EtrekMGP.TitleOfCheckPointL = "Etrek MGP";

                var GarabogazMGP = ObjectSpace.CreateObject<CheckPoint>();
                GarabogazMGP.TitleOfCheckPoint = CheckPointEn.GarabogazMGP;
                GarabogazMGP.TitleOfCheckPointL = "Garabogaz MGP";

                var TürkmenbaşyDeňizMenzilindäkiMGP = ObjectSpace.CreateObject<CheckPoint>();
                TürkmenbaşyDeňizMenzilindäkiMGP.TitleOfCheckPoint = CheckPointEn.TürkmenbaşyDeňizMenzilindäkiMGP;
                TürkmenbaşyDeňizMenzilindäkiMGP.TitleOfCheckPointL = "Türkmenbaşy deňiz menzilindäki MGP";

                var TürkmenbaşyHowaMenzilindäkiMGP = ObjectSpace.CreateObject<CheckPoint>();
                TürkmenbaşyHowaMenzilindäkiMGP.TitleOfCheckPoint = CheckPointEn.TürkmenbaşyHowaMenzilindäkiMGP;
                TürkmenbaşyHowaMenzilindäkiMGP.TitleOfCheckPointL = "Türkmenbaşy howa menzilindäki MGP";
                #endregion


                #region PurposeOFTravel

                var Work = ObjectSpace.CreateObject<PurposeOfTravel>();
                Work.TravelPurpose = TravelPurposeEn.Work;
                Work.PurposeOfTravelL = "Işlemek üçin";

                var FamilyMember = ObjectSpace.CreateObject<PurposeOfTravel>();
                FamilyMember.TravelPurpose = TravelPurposeEn.FamilyMember;
                FamilyMember.PurposeOfTravelL = "Maşgala agzasy";

                var Visit = ObjectSpace.CreateObject<PurposeOfTravel>();
                Visit.TravelPurpose = TravelPurposeEn.Visit;
                Visit.PurposeOfTravelL = "Myhmançylyga";

                var Vacation = ObjectSpace.CreateObject<PurposeOfTravel>();
                Vacation.TravelPurpose = TravelPurposeEn.Vacation;
                Vacation.PurposeOfTravelL = "Dynç alyş";

                var Quit = ObjectSpace.CreateObject<PurposeOfTravel>();
                Quit.TravelPurpose = TravelPurposeEn.Quit;
                Quit.PurposeOfTravelL = "Işden çykmak";

                var BusinessTrip = ObjectSpace.CreateObject<PurposeOfTravel>();
                BusinessTrip.TravelPurpose = TravelPurposeEn.BusinessTrip;
                BusinessTrip.PurposeOfTravelL = "Iş saparyna";

                #endregion


                #region Urgency

                var urgencyAdaty = ObjectSpace.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgency", AppUrgency.Adaty));

                if (urgencyAdaty == null)
                {

                    urgencyAdaty = ObjectSpace.CreateObject<IUrgency>();
                    urgencyAdaty.ApplicationUrgency = AppUrgency.Adaty;
                    urgencyAdaty.ApplicationUrgencyH = "Adaty tertipde !";
                    urgencyAdaty.ApplicationUrgencyL = "";
                    urgencyAdaty.Priority = 3;


                }

                var urgencyGyssagly = ObjectSpace.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgency", AppUrgency.Gyssagtly));

                if (urgencyGyssagly == null)
                {

                    urgencyGyssagly = ObjectSpace.CreateObject<IUrgency>();
                    urgencyGyssagly.ApplicationUrgency = AppUrgency.Gyssagtly;
                    urgencyGyssagly.ApplicationUrgencyH = "Gyssagly tertipde!";
                    urgencyGyssagly.ApplicationUrgencyL = "gyssagly tertipde";
                    urgencyGyssagly.Priority = 2;


                }

                var urgencyÖränGyssagly = ObjectSpace.FindObject<IUrgency>(new BinaryOperator("ApplicationUrgency", AppUrgency.ÖränGyssagly));

                if (urgencyÖränGyssagly == null)
                {

                    urgencyÖränGyssagly = ObjectSpace.CreateObject<IUrgency>();
                    urgencyÖränGyssagly.ApplicationUrgency = AppUrgency.ÖränGyssagly;
                    urgencyÖränGyssagly.ApplicationUrgencyH = "Örän gyssagly!";
                    urgencyÖränGyssagly.ApplicationUrgencyL = " örän gyssagly tertipde";
                    urgencyÖränGyssagly.Priority = 1;


                }

                #endregion


                #region AppliedMinistery

                var amTDSSGM = ObjectSpace.FindObject<IAppliedMinistery>(new BinaryOperator("TitleOfMinistery", "TDSSGM"));

                if (amTDSSGM == null)
                {

                    amTDSSGM = ObjectSpace.CreateObject<IAppliedMinistery>();
                    amTDSSGM.TitleOfMinistery = "TDSSGM";
                    amTDSSGM.TitleOfMinisteryL = "Türkmenistanyň Derman Senagaty we Saglygy goraýyş ministrligine";
                    amTDSSGM.MinistersPosition = "Türkmenistanyň Derman Senagaty we Saglygy goraýyş ministri";
                    amTDSSGM.MinistersFullName = "A.Amanow";
                    amTDSSGM.formOfAddress = "Hormatly A.Amanow!";


                }

                var amTIIM = ObjectSpace.FindObject<IAppliedMinistery>(new BinaryOperator("TitleOfMinistery", "TIIM"));

                if (amTIIM == null)
                {

                    amTIIM = ObjectSpace.CreateObject<IAppliedMinistery>();
                    amTIIM.TitleOfMinistery = "TIIM";
                    amTIIM.TitleOfMinisteryL = "Türkmenistanyň Içeri işler ministrligine";
                    amTIIM.MinistersPosition = "Türkmenistanyň Içeri işler ministri";
                    amTIIM.MinistersFullName = "A.Amanow";
                    amTIIM.formOfAddress = "Hormatly A.Amanow!";


                }

                var amTDIM = ObjectSpace.FindObject<IAppliedMinistery>(new BinaryOperator("TitleOfMinistery", "TDIM"));

                if (amTDIM == null)
                {

                    amTDIM = ObjectSpace.CreateObject<IAppliedMinistery>();
                    amTDIM.TitleOfMinistery = "TDIM";
                    amTDIM.TitleOfMinisteryL = "Türkmenistanyň Daşary işler ministrligine";
                    amTDIM.MinistersPosition = "Türkmenistanyň Daşary işler ministri";
                    amTDIM.MinistersFullName = "A.Amanow";
                    amTDIM.formOfAddress = "Hormatly A.Amanow!";


                }



                #endregion

                #region Contract


                var contractWithTIIM = ObjectSpace.FindObject<IContract>(new BinaryOperator("NumberOfContract", "000001"));

                if (contractWithTIIM == null)
                {

                    contractWithTIIM = ObjectSpace.CreateObject<IContract>();
                    contractWithTIIM.NumberOfContract = "000001";
                    contractWithTIIM.ContentOfContract = "Türkmenistanyň Prezidentiniň 2011-nji ýylyň Iýul aýynyň 8-nda çykaran 00000 belgili kararyna laýyklykda Türkmenistanyň Içeri işler ministrligine Aşgabat şäherinde «Okuw merkezini » gurmak barada Türkiýäniň «Plany İnşaat Yatırım ve Dış Ticaret A. Ş.» şereketi bilen şertnama baglaşmaga ygtyýar berildi";
                    contractWithTIIM.AppliedMinistery = amTIIM;


                }

                var contractWithTDIM = ObjectSpace.FindObject<IContract>(new BinaryOperator("NumberOfContract", "000002"));

                if (contractWithTDIM == null)
                {

                    contractWithTDIM = ObjectSpace.CreateObject<IContract>();
                    contractWithTDIM.NumberOfContract = "000002";
                    contractWithTDIM.ContentOfContract = "Türkmenistanyň Prezidentiniň 2011-nji ýylyň Iýul aýynyň 8-nda çykaran 00000 belgili kararyna laýyklykda Türkmenistanyň Daşary işler ministrligine Aşgabat şäherinde « Ýaşaýyş jaýyny » gurmak barada Türkiýäniň «Plany İnşaat Yatırım ve Dış Ticaret A. Ş.» şereketi bilen şertnama baglaşmaga ygtyýar berildi";
                    contractWithTDIM.AppliedMinistery = amTDIM;


                }


                var contractWithTDSSGM = ObjectSpace.FindObject<IContract>(new BinaryOperator("NumberOfContract", "000003"));

                if (contractWithTDSSGM == null)
                {

                    contractWithTDSSGM = ObjectSpace.CreateObject<IContract>();
                    contractWithTDSSGM.NumberOfContract = "000003";
                    contractWithTDSSGM.ContentOfContract = "Türkmenistanyň Prezidentiniň 2011-nji ýylyň Iýul aýynyň 8-nda çykaran 00000 belgili kararyna laýyklykda Türkmenistanyň Saglygy goraýyş we derman senagaty ministrligine Aşgabat şäherinde « Ýaşaýyş jaýyny » gurmak barada Türkiýäniň «Plany İnşaat Yatırım ve Dış Ticaret A. Ş.» şereketi bilen şertnama baglaşmaga ygtyýar berildi";
                    contractWithTDSSGM.AppliedMinistery = amTDSSGM;


                }


                #endregion

                #region VisaType
                var visaTypeWP = ObjectSpace.FindObject<IVisaType>(new BinaryOperator("TypeOfVisa", "WP"));

                if (visaTypeWP == null)
                {

                    visaTypeWP = ObjectSpace.CreateObject<IVisaType>();
                    visaTypeWP.TypeOfVisa = "WP";
                    visaTypeWP.TypeOfVisaL = "WP";



                }

                var visaTypeBS = ObjectSpace.FindObject<IVisaType>(new BinaryOperator("TypeOfVisa", "BS"));

                if (visaTypeBS == null)
                {

                    visaTypeBS = ObjectSpace.CreateObject<IVisaType>();
                    visaTypeBS.TypeOfVisa = "BS";
                    visaTypeBS.TypeOfVisaL = "BS";



                }

                var visaTypeGL = ObjectSpace.FindObject<IVisaType>(new BinaryOperator("TypeOfVisa", "GL"));

                if (visaTypeGL == null)
                {

                    visaTypeGL = ObjectSpace.CreateObject<IVisaType>();
                    visaTypeGL.TypeOfVisa = "GL";
                    visaTypeGL.TypeOfVisaL = "GL";



                }

                #endregion

                #region VisaPeriod

                var visaPeriodBirAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "1 aý"));

                if (visaPeriodBirAy == null)
                {

                    visaPeriodBirAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodBirAy.PeriodOfVisa = "1 aý";
                    visaPeriodBirAy.PeriodOfVisaL = "1 (bir) aý";
                    visaPeriodBirAy.CountMonth = 1;


                }

                var visaPeriodIkiAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "2 aý"));

                if (visaPeriodIkiAy == null)
                {

                    visaPeriodIkiAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodIkiAy.PeriodOfVisa = "2 aý";
                    visaPeriodIkiAy.PeriodOfVisaL = "2 (iki) aý";
                    visaPeriodIkiAy.CountMonth = 2;


                }

                var visaPeriodÜçAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "3 aý"));

                if (visaPeriodÜçAy == null)
                {

                    visaPeriodÜçAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodÜçAy.PeriodOfVisa = "3 aý";
                    visaPeriodÜçAy.PeriodOfVisaL = "3 (üç) aý";
                    visaPeriodÜçAy.CountMonth = 3;


                }


                var visaPeriodDörtAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "3 aý"));

                if (visaPeriodDörtAy == null)
                {

                    visaPeriodDörtAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodDörtAy.PeriodOfVisa = "4 aý";
                    visaPeriodDörtAy.PeriodOfVisaL = "4 (dört) aý";
                    visaPeriodDörtAy.CountMonth = 4;


                }


                var visaPeriodBäşAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "3 aý"));

                if (visaPeriodBäşAy == null)
                {

                    visaPeriodBäşAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodBäşAy.PeriodOfVisa = "5 aý";
                    visaPeriodBäşAy.PeriodOfVisaL = "5 (bäş) aý";
                    visaPeriodBäşAy.CountMonth = 5;


                }

                var visaPeriodAltyAy = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "6 aý"));

                if (visaPeriodAltyAy == null)
                {

                    visaPeriodAltyAy = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodAltyAy.PeriodOfVisa = "6 aý";
                    visaPeriodAltyAy.PeriodOfVisaL = "6 (alty) aý";
                    visaPeriodAltyAy.CountMonth = 6;


                }


                var visaPeriodBirYyl = ObjectSpace.FindObject<IVisaPeriod>(new BinaryOperator("PeriodOfVisa", "1 ýyl"));

                if (visaPeriodBirYyl == null)
                {

                    visaPeriodBirYyl = ObjectSpace.CreateObject<IVisaPeriod>();
                    visaPeriodBirYyl.PeriodOfVisa = "1 ýyl";
                    visaPeriodBirYyl.PeriodOfVisaL = "1 (bir) ýyl";
                    visaPeriodBirYyl.CountMonth = 12;



                }

                #endregion

                #region VisaCategory

                var visaCategoryBirgezeklik = ObjectSpace.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", VisaCategoryEnum.BirGezeklik));

                if (visaCategoryBirgezeklik == null)
                {

                    visaCategoryBirgezeklik = ObjectSpace.CreateObject<IVisaCategory>();
                    visaCategoryBirgezeklik.CategoryOfVisa = VisaCategoryEnum.BirGezeklik;
                    visaCategoryBirgezeklik.CategoryOfVisaL = "bir gezeklik";



                }

                var visaCategoryKöpgezeklik = ObjectSpace.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", VisaCategoryEnum.KöpGezeklik));

                if (visaCategoryKöpgezeklik == null)
                {

                    visaCategoryKöpgezeklik = ObjectSpace.CreateObject<IVisaCategory>();
                    visaCategoryKöpgezeklik.CategoryOfVisa = VisaCategoryEnum.KöpGezeklik;
                    visaCategoryKöpgezeklik.CategoryOfVisaL = "köp gezeklik";



                }
                var visaCategoryIkigezeklik = ObjectSpace.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", VisaCategoryEnum.IkiGezeklik));

                if (visaCategoryIkigezeklik == null)
                {

                    visaCategoryIkigezeklik = ObjectSpace.CreateObject<IVisaCategory>();
                    visaCategoryIkigezeklik.CategoryOfVisa = VisaCategoryEnum.IkiGezeklik;
                    visaCategoryIkigezeklik.CategoryOfVisaL = "iki gezeklik";



                }

                var visaCategoryÜçgezeklik = ObjectSpace.FindObject<IVisaCategory>(new BinaryOperator("CategoryOfVisa", VisaCategoryEnum.ÜçGezeklik));

                if (visaCategoryÜçgezeklik == null)
                {

                    visaCategoryÜçgezeklik = ObjectSpace.CreateObject<IVisaCategory>();
                    visaCategoryÜçgezeklik.CategoryOfVisa = VisaCategoryEnum.ÜçGezeklik;
                    visaCategoryÜçgezeklik.CategoryOfVisaL = "üç gezeklik";



                }
                #endregion

                #region VisaIssuedPlace



                var visaIssuedPlaceASAP = ObjectSpace.CreateObject<IVisaIssuedPlace>();
                visaIssuedPlaceASAP.IssuedPlaceOfVisa = VisaIssuedPlacesEnum.Türkmenistanda;
                visaIssuedPlaceASAP.IssuedPlaceOfVisaL = "Aşgabat şäher howa menzilindäki MGP";
                visaIssuedPlaceASAP.IsDefault = true;






                var visaIssuedPlaceHDN = ObjectSpace.CreateObject<IVisaIssuedPlace>();
                visaIssuedPlaceHDN.IssuedPlaceOfVisa = VisaIssuedPlacesEnum.Türkmenistanda;
                visaIssuedPlaceHDN.IssuedPlaceOfVisaL = "Howdan MGP";


                var visaIssuedPlaceASG = ObjectSpace.CreateObject<IVisaIssuedPlace>();
                visaIssuedPlaceASG.IssuedPlaceOfVisa = VisaIssuedPlacesEnum.Türkmenistanda;
                visaIssuedPlaceASG.IssuedPlaceOfVisaL = "Aşgabat şäheri";


                #endregion

                #region Gender



                var genderE = ObjectSpace.CreateObject<IGender>();
                genderE.TypeOfGender = GenderEnum.Erkek;
                genderE.TypeOfGenderL = "Erkek";







                var genderA = ObjectSpace.CreateObject<IGender>();
                genderA.TypeOfGender = GenderEnum.Aýal;
                genderA.TypeOfGenderL = "Aýal";






                #endregion

                #region Marital Statud


                var maritalStatusÖýlenen = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Öýlenen));

                if (maritalStatusÖýlenen == null)
                {

                    maritalStatusÖýlenen = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusÖýlenen.Status = MaritalStatus.Öýlenen;
                    maritalStatusÖýlenen.StatusL = "Öýlenen";
                    maritalStatusÖýlenen.Gender = genderE;


                }

                var maritalStatusSallah = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Sallah));

                if (maritalStatusSallah == null)
                {

                    maritalStatusSallah = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusSallah.Status = MaritalStatus.Sallah;
                    maritalStatusSallah.StatusL = "Sallah";
                    maritalStatusSallah.Gender = genderE;


                }

                var maritalStatusDÇ = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.DurmuşaÇykan));

                if (maritalStatusDÇ == null)
                {

                    maritalStatusDÇ = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusDÇ.Status = MaritalStatus.DurmuşaÇykan;
                    maritalStatusDÇ.StatusL = "Durmuşa çykan";
                    maritalStatusDÇ.Gender = genderA;


                }

                var maritalStatusDÇK = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.DurmuşaÇykan));

                if (maritalStatusDÇK == null)
                {

                    maritalStatusDÇK = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusDÇK.Status = MaritalStatus.DurmuşaÇykmadyk;
                    maritalStatusDÇK.StatusL = "Durmuşa çykmadyk";
                    maritalStatusDÇK.Gender = genderA;


                }

                var maritalStatusÇaga = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Çaga));

                if (maritalStatusÇaga == null)
                {

                    maritalStatusÇaga = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusÇaga.Status = MaritalStatus.Çaga;
                    maritalStatusÇaga.StatusL = "Çaga";
                    maritalStatusÇaga.Gender = genderA;


                }

                var maritalStatusÇagaO = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Çaga));

                if (maritalStatusÇagaO == null)
                {

                    maritalStatusÇagaO = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusÇagaO.Status = MaritalStatus.Çaga;
                    maritalStatusÇagaO.StatusL = "Çaga";
                    maritalStatusÇagaO.Gender = genderE;


                }

                var maritalStatusAýrylşan = ObjectSpace.FindObject<IMaritalStatus>(new BinaryOperator("Status", MaritalStatus.Aýrylşan));

                if (maritalStatusAýrylşan == null)
                {

                    maritalStatusAýrylşan = ObjectSpace.CreateObject<IMaritalStatus>();
                    maritalStatusAýrylşan.Status = MaritalStatus.Aýrylşan;
                    maritalStatusAýrylşan.StatusL = "Aýrylşan";



                }

                #endregion

                #region Country


                //1

                var countryTUR = ObjectSpace.CreateObject<ICountries>();
                countryTUR.CountryEnum = CountryEnum.TUR;
                countryTUR.NameOfCountry = "TUR";
                countryTUR.NameOfCountryL = "TUR";




                //2

                var countryRUS = ObjectSpace.CreateObject<ICountries>();
                countryRUS.CountryEnum = CountryEnum.RUS;
                countryRUS.NameOfCountry = "RUS";
                countryRUS.NameOfCountryL = "RUS";


                //3


                var countryTKM = ObjectSpace.CreateObject<ICountries>();
                countryTKM.CountryEnum = CountryEnum.TKM;
                countryTKM.NameOfCountry = "TKM";
                countryTKM.NameOfCountryL = "TKM";

                //4
                var countryGBR = ObjectSpace.CreateObject<ICountries>();
                countryGBR.CountryEnum = CountryEnum.GBR;
                countryGBR.NameOfCountry = "GBR";
                countryGBR.NameOfCountryL = "GBR";


                //5

                var countryDEU = ObjectSpace.CreateObject<ICountries>();
                countryDEU.CountryEnum = CountryEnum.DEU;
                countryDEU.NameOfCountry = "DEU";
                countryDEU.NameOfCountryL = "DEU";



                //6


                var countryCHN = ObjectSpace.CreateObject<ICountries>();
                countryCHN.CountryEnum = CountryEnum.CHN;
                countryCHN.NameOfCountry = "CHN";
                countryCHN.NameOfCountryL = "CHN";


                //7
                var countryUSA = ObjectSpace.CreateObject<ICountries>();
                countryUSA.CountryEnum = CountryEnum.USA;
                countryUSA.NameOfCountry = "USA";
                countryUSA.NameOfCountryL = "USA";


                //8

                var countryUKR = ObjectSpace.CreateObject<ICountries>();
                countryUKR.CountryEnum = CountryEnum.UKR;
                countryUKR.NameOfCountry = "UKR";
                countryUKR.NameOfCountryL = "UKR";
                //9

                var countryTJK = ObjectSpace.CreateObject<ICountries>();
                countryTJK.CountryEnum = CountryEnum.TJK;
                countryTJK.NameOfCountry = "TJK";
                countryTJK.NameOfCountryL = "TJK";



                //10


                var countryAFG = ObjectSpace.CreateObject<ICountries>();
                countryAFG.CountryEnum = CountryEnum.AFG;
                countryAFG.NameOfCountry = "AFG";
                countryAFG.NameOfCountryL = "AFG";


                //11
                var countryASM = ObjectSpace.CreateObject<ICountries>();
                countryASM.CountryEnum = CountryEnum.ASM;
                countryASM.NameOfCountry = "ASM";
                countryASM.NameOfCountryL = "ASM";



                //12

                var countryAGO = ObjectSpace.CreateObject<ICountries>();
                countryAGO.CountryEnum = CountryEnum.AGO;
                countryAGO.NameOfCountry = "AGO";
                countryAGO.NameOfCountryL = "AGO";

                //13

                var countryAIA = ObjectSpace.CreateObject<ICountries>();
                countryAIA.CountryEnum = CountryEnum.AIA;
                countryAIA.NameOfCountry = "AIA";
                countryAIA.NameOfCountryL = "AIA";


                //14
                var countryATG = ObjectSpace.CreateObject<ICountries>();
                countryATG.CountryEnum = CountryEnum.ATG;
                countryATG.NameOfCountry = "ATG";
                countryATG.NameOfCountryL = "ATG";
                //15

                var countryARG = ObjectSpace.CreateObject<ICountries>();
                countryARG.CountryEnum = CountryEnum.ARG;
                countryARG.NameOfCountry = "ARG";
                countryARG.NameOfCountryL = "ARG";

                //16
                var countryARM = ObjectSpace.CreateObject<ICountries>();
                countryARM.CountryEnum = CountryEnum.ARM;
                countryARM.NameOfCountry = "ARM";
                countryARM.NameOfCountryL = "ARM";

                //17
                var countryABW = ObjectSpace.CreateObject<ICountries>();
                countryABW.CountryEnum = CountryEnum.ABW;
                countryABW.NameOfCountry = "ABW";
                countryABW.NameOfCountryL = "ABW";

                //18
                var countryAUS = ObjectSpace.CreateObject<ICountries>();
                countryAUS.CountryEnum = CountryEnum.AUS;
                countryAUS.NameOfCountry = "AUS";
                countryAUS.NameOfCountryL = "AUS";
                //19
                var countryAUT = ObjectSpace.CreateObject<ICountries>();
                countryAUT.CountryEnum = CountryEnum.AUT;
                countryAUT.NameOfCountry = "AUT";
                countryAUT.NameOfCountryL = "AUT";

                //20
                var countryAZE = ObjectSpace.CreateObject<ICountries>();
                countryAZE.CountryEnum = CountryEnum.AZE;
                countryAZE.NameOfCountry = "AZE";
                countryAZE.NameOfCountryL = "AZE";

                //21
                var countryBHS = ObjectSpace.CreateObject<ICountries>();
                countryBHS.CountryEnum = CountryEnum.BHS;
                countryBHS.NameOfCountry = "BHS";
                countryBHS.NameOfCountryL = "BHS";

                //22
                var countryBHR = ObjectSpace.CreateObject<ICountries>();
                countryBHR.CountryEnum = CountryEnum.BHR;
                countryBHR.NameOfCountry = "BHR";
                countryBHR.NameOfCountryL = "BHR";

                //23
                var countryBGD = ObjectSpace.CreateObject<ICountries>();
                countryBGD.CountryEnum = CountryEnum.BGD;
                countryBGD.NameOfCountry = "BGD";
                countryBGD.NameOfCountryL = "BGD";

                //24
                var countryBRB = ObjectSpace.CreateObject<ICountries>();
                countryBRB.CountryEnum = CountryEnum.BRB;
                countryBRB.NameOfCountry = "BRB";
                countryBRB.NameOfCountryL = "BRB";

                //25
                var countryBLR = ObjectSpace.CreateObject<ICountries>();
                countryBLR.CountryEnum = CountryEnum.BLR;
                countryBLR.NameOfCountry = "BLR";
                countryBLR.NameOfCountryL = "BLR";

                //26
                var countryBEL = ObjectSpace.CreateObject<ICountries>();
                countryBEL.CountryEnum = CountryEnum.BEL;
                countryBEL.NameOfCountry = "BEL";
                countryBEL.NameOfCountryL = "BEL";

                //27
                var countryBLZ = ObjectSpace.CreateObject<ICountries>();
                countryBLZ.CountryEnum = CountryEnum.BLZ;
                countryBLZ.NameOfCountry = "BLZ";
                countryBLZ.NameOfCountryL = "BLZ";

                //28
                var countryBEN = ObjectSpace.CreateObject<ICountries>();
                countryBEN.CountryEnum = CountryEnum.BEN;
                countryBEN.NameOfCountry = "BEN";
                countryBEN.NameOfCountryL = "BEN";

                //29
                var countryBMU = ObjectSpace.CreateObject<ICountries>();
                countryBMU.CountryEnum = CountryEnum.BMU;
                countryBMU.NameOfCountry = "BMU";
                countryBMU.NameOfCountryL = "BMU";


                //30
                var countryBTN = ObjectSpace.CreateObject<ICountries>();
                countryBTN.CountryEnum = CountryEnum.BTN;
                countryBTN.NameOfCountry = "BTN";
                countryBTN.NameOfCountryL = "BTN";

                //31
                var countryBOL = ObjectSpace.CreateObject<ICountries>();
                countryBOL.CountryEnum = CountryEnum.BOL;
                countryBOL.NameOfCountry = "BOL";
                countryBOL.NameOfCountryL = "BOL";

                //32
                var countryBIH = ObjectSpace.CreateObject<ICountries>();
                countryBIH.CountryEnum = CountryEnum.BIH;
                countryBIH.NameOfCountry = "BIH";
                countryBIH.NameOfCountryL = "BIH";
                //33

                var countryBWA = ObjectSpace.CreateObject<ICountries>();
                countryBWA.CountryEnum = CountryEnum.BWA;
                countryBWA.NameOfCountry = "BWA";
                countryBWA.NameOfCountryL = "BWA";

                //34
                var countryBVT = ObjectSpace.CreateObject<ICountries>();
                countryBVT.CountryEnum = CountryEnum.BVT;
                countryBVT.NameOfCountry = "BVT";
                countryBVT.NameOfCountryL = "BVT";

                //35
                var countryBRA = ObjectSpace.CreateObject<ICountries>();
                countryBRA.CountryEnum = CountryEnum.BRA;
                countryBRA.NameOfCountry = "BRA";
                countryBRA.NameOfCountryL = "BRA";

                //36
                var countryIOT = ObjectSpace.CreateObject<ICountries>();
                countryIOT.CountryEnum = CountryEnum.IOT;
                countryIOT.NameOfCountry = "IOT";
                countryIOT.NameOfCountryL = "IOT";
                //37
                var countryBRN = ObjectSpace.CreateObject<ICountries>();
                countryBRN.CountryEnum = CountryEnum.BRN;
                countryBRN.NameOfCountry = "BRN";
                countryBRN.NameOfCountryL = "BRN";

                //38
                var countryBGR = ObjectSpace.CreateObject<ICountries>();
                countryBGR.CountryEnum = CountryEnum.BGR;
                countryBGR.NameOfCountry = "BGR";
                countryBGR.NameOfCountryL = "BGR";


                //39
                var countryBFA = ObjectSpace.CreateObject<ICountries>();
                countryBFA.CountryEnum = CountryEnum.BFA;
                countryBFA.NameOfCountry = "BFA";
                countryBFA.NameOfCountryL = "BFA";


                //40
                var countryBDI = ObjectSpace.CreateObject<ICountries>();
                countryBDI.CountryEnum = CountryEnum.BDI;
                countryBDI.NameOfCountry = "BDI";
                countryBDI.NameOfCountryL = "BDI";


                //41
                var countryKHM = ObjectSpace.CreateObject<ICountries>();
                countryKHM.CountryEnum = CountryEnum.KHM;
                countryKHM.NameOfCountry = "KHM";
                countryKHM.NameOfCountryL = "KHM";


                //42
                var countryCMR = ObjectSpace.CreateObject<ICountries>();
                countryCMR.CountryEnum = CountryEnum.CMR;
                countryCMR.NameOfCountry = "CMR";
                countryCMR.NameOfCountryL = "CMR";


                //43
                var countryCAN = ObjectSpace.CreateObject<ICountries>();
                countryCAN.CountryEnum = CountryEnum.CAN;
                countryCAN.NameOfCountry = "CAN";
                countryCAN.NameOfCountryL = "CAN";



                //44
                var countryCPV = ObjectSpace.CreateObject<ICountries>();
                countryCPV.CountryEnum = CountryEnum.CPV;
                countryCPV.NameOfCountry = "CPV";
                countryCPV.NameOfCountryL = "CPV";

                //45
                var countryCYM = ObjectSpace.CreateObject<ICountries>();
                countryCYM.CountryEnum = CountryEnum.CYM;
                countryCYM.NameOfCountry = "CYM";
                countryCYM.NameOfCountryL = "CYM";

                //46
                var countryCAF = ObjectSpace.CreateObject<ICountries>();
                countryCAF.CountryEnum = CountryEnum.CAF;
                countryCAF.NameOfCountry = "CAF";
                countryCAF.NameOfCountryL = "CAF";


                //47
                var countryTCD = ObjectSpace.CreateObject<ICountries>();
                countryTCD.CountryEnum = CountryEnum.TCD;
                countryTCD.NameOfCountry = "TCD";
                countryTCD.NameOfCountryL = "TCD";


                //48
                var countryCHL = ObjectSpace.CreateObject<ICountries>();
                countryCHL.CountryEnum = CountryEnum.CHL;
                countryCHL.NameOfCountry = "CHL";
                countryCHL.NameOfCountryL = "CHL";


                //49
                var countryCXR = ObjectSpace.CreateObject<ICountries>();
                countryCXR.CountryEnum = CountryEnum.CXR;
                countryCXR.NameOfCountry = "CXR";
                countryCXR.NameOfCountryL = "CXR";


                //50

                var countryCCK = ObjectSpace.CreateObject<ICountries>();
                countryCCK.CountryEnum = CountryEnum.CCK;
                countryCCK.NameOfCountry = "CCK";
                countryCCK.NameOfCountryL = "CCK";


                //51
                var countryCOL = ObjectSpace.CreateObject<ICountries>();
                countryCOL.CountryEnum = CountryEnum.COL;
                countryCOL.NameOfCountry = "COL";
                countryCOL.NameOfCountryL = "COL";


                //52
                var countryCOM = ObjectSpace.CreateObject<ICountries>();
                countryCOM.CountryEnum = CountryEnum.COM;
                countryCOM.NameOfCountry = "COM";
                countryCOM.NameOfCountryL = "COM";


                //53
                var countryCOG = ObjectSpace.CreateObject<ICountries>();
                countryCOG.CountryEnum = CountryEnum.COG;
                countryCOG.NameOfCountry = "COG";
                countryCOG.NameOfCountryL = "COG";


                //54
                var countryCOD = ObjectSpace.CreateObject<ICountries>();
                countryCOD.CountryEnum = CountryEnum.COD;
                countryCOD.NameOfCountry = "COD";
                countryCOD.NameOfCountryL = "COD";


                //55
                var countryCOK = ObjectSpace.CreateObject<ICountries>();
                countryCOK.CountryEnum = CountryEnum.COK;
                countryCOK.NameOfCountry = "COK";
                countryCOK.NameOfCountryL = "COK";


                //56
                var countryCRI = ObjectSpace.CreateObject<ICountries>();
                countryCRI.CountryEnum = CountryEnum.CRI;
                countryCRI.NameOfCountry = "CRI";
                countryCRI.NameOfCountryL = "CRI";


                //57
                var countryCIV = ObjectSpace.CreateObject<ICountries>();
                countryCIV.CountryEnum = CountryEnum.CIV;
                countryCIV.NameOfCountry = "CIV";
                countryCIV.NameOfCountryL = "CIV";


                //58
                var countryHRV = ObjectSpace.CreateObject<ICountries>();
                countryHRV.CountryEnum = CountryEnum.HRV;
                countryHRV.NameOfCountry = "HRV";
                countryHRV.NameOfCountryL = "HRV";


                //59
                var countryCUB = ObjectSpace.CreateObject<ICountries>();
                countryCUB.CountryEnum = CountryEnum.CUB;
                countryCUB.NameOfCountry = "CUB";
                countryCUB.NameOfCountryL = "CUB";


                //60
                var countryCYP = ObjectSpace.CreateObject<ICountries>();
                countryCYP.CountryEnum = CountryEnum.CYP;
                countryCYP.NameOfCountry = "CYP";
                countryCYP.NameOfCountryL = "CYP";


                //61
                var countryCZE = ObjectSpace.CreateObject<ICountries>();
                countryCZE.CountryEnum = CountryEnum.CZE;
                countryCZE.NameOfCountry = "CZE";
                countryCZE.NameOfCountryL = "CZE";


                //62
                var countryDNK = ObjectSpace.CreateObject<ICountries>();
                countryDNK.CountryEnum = CountryEnum.DNK;
                countryDNK.NameOfCountry = "DNK";
                countryDNK.NameOfCountryL = "DNK";


                //63
                var countryDJI = ObjectSpace.CreateObject<ICountries>();
                countryDJI.CountryEnum = CountryEnum.DJI;
                countryDJI.NameOfCountry = "DJI";
                countryDJI.NameOfCountryL = "DJI";


                //64
                var countryDMA = ObjectSpace.CreateObject<ICountries>();
                countryDMA.CountryEnum = CountryEnum.DMA;
                countryDMA.NameOfCountry = "DMA";
                countryDMA.NameOfCountryL = "DMA";

                //65
                var countryDOM = ObjectSpace.CreateObject<ICountries>();
                countryDOM.CountryEnum = CountryEnum.DOM;
                countryDOM.NameOfCountry = "DOM";
                countryDOM.NameOfCountryL = "DOM";


                //66
                var countryTMP = ObjectSpace.CreateObject<ICountries>();
                countryTMP.CountryEnum = CountryEnum.TMP;
                countryTMP.NameOfCountry = "TMP";
                countryTMP.NameOfCountryL = "TMP";


                //67
                var countryECU = ObjectSpace.CreateObject<ICountries>();
                countryECU.CountryEnum = CountryEnum.ECU;
                countryECU.NameOfCountry = "ECU";
                countryECU.NameOfCountryL = "ECU";


                //68
                var countryEGY = ObjectSpace.CreateObject<ICountries>();
                countryEGY.CountryEnum = CountryEnum.EGY;
                countryEGY.NameOfCountry = "EGY";
                countryEGY.NameOfCountryL = "EGY";


                //69
                var countrySLV = ObjectSpace.CreateObject<ICountries>();
                countrySLV.CountryEnum = CountryEnum.SLV;
                countrySLV.NameOfCountry = "SLV";
                countrySLV.NameOfCountryL = "SLV";


                //70
                var countryGNQ = ObjectSpace.CreateObject<ICountries>();
                countryGNQ.CountryEnum = CountryEnum.GNQ;
                countryGNQ.NameOfCountry = "GNQ";
                countryGNQ.NameOfCountryL = "GNQ";


                //71
                var countryERI = ObjectSpace.CreateObject<ICountries>();
                countryERI.CountryEnum = CountryEnum.ERI;
                countryERI.NameOfCountry = "ERI";
                countryERI.NameOfCountryL = "ERI";


                //72
                var countryEST = ObjectSpace.CreateObject<ICountries>();
                countryEST.CountryEnum = CountryEnum.EST;
                countryEST.NameOfCountry = "EST";
                countryEST.NameOfCountryL = "EST";


                //73
                var countryETH = ObjectSpace.CreateObject<ICountries>();
                countryETH.CountryEnum = CountryEnum.ETH;
                countryETH.NameOfCountry = "ETH";
                countryETH.NameOfCountryL = "ETH";

                //74
                var countryFLK = ObjectSpace.CreateObject<ICountries>();
                countryFLK.CountryEnum = CountryEnum.FLK;
                countryFLK.NameOfCountry = "FLK";
                countryFLK.NameOfCountryL = "FLK";


                //75
                var countryFRO = ObjectSpace.CreateObject<ICountries>();
                countryFRO.CountryEnum = CountryEnum.FRO;
                countryFRO.NameOfCountry = "FRO";
                countryFRO.NameOfCountryL = "FRO";


                //76
                var countryFJI = ObjectSpace.CreateObject<ICountries>();
                countryFJI.CountryEnum = CountryEnum.FJI;
                countryFJI.NameOfCountry = "FJI";
                countryFJI.NameOfCountryL = "FJI";


                //77
                var countryFIN = ObjectSpace.CreateObject<ICountries>();
                countryFIN.CountryEnum = CountryEnum.FIN;
                countryFIN.NameOfCountry = "FIN";
                countryFIN.NameOfCountryL = "FIN";


                //78
                var countryFRA = ObjectSpace.CreateObject<ICountries>();
                countryFRA.CountryEnum = CountryEnum.FRA;
                countryFRA.NameOfCountry = "FRA";
                countryFRA.NameOfCountryL = "FRA";


                //79
                var countryFXX = ObjectSpace.CreateObject<ICountries>();
                countryFXX.CountryEnum = CountryEnum.FXX;
                countryFXX.NameOfCountry = "FXX";
                countryFXX.NameOfCountryL = "FXX";


                //80
                var countryGUF = ObjectSpace.CreateObject<ICountries>();
                countryGUF.CountryEnum = CountryEnum.GUF;
                countryGUF.NameOfCountry = "GUF";
                countryGUF.NameOfCountryL = "GUF";


                //81
                var countryPYF = ObjectSpace.CreateObject<ICountries>();
                countryPYF.CountryEnum = CountryEnum.PYF;
                countryPYF.NameOfCountry = "PYF";
                countryPYF.NameOfCountryL = "PYF";


                //82
                var countryATF = ObjectSpace.CreateObject<ICountries>();
                countryATF.CountryEnum = CountryEnum.ATF;
                countryATF.NameOfCountry = "ATF";
                countryATF.NameOfCountryL = "ATF";


                //83
                var countryGAB = ObjectSpace.CreateObject<ICountries>();
                countryGAB.CountryEnum = CountryEnum.GAB;
                countryGAB.NameOfCountry = "GAB";
                countryGAB.NameOfCountryL = "GAB";


                //84
                var countryGMB = ObjectSpace.CreateObject<ICountries>();
                countryGMB.CountryEnum = CountryEnum.GMB;
                countryGMB.NameOfCountry = "GMB";
                countryGMB.NameOfCountryL = "GMB";


                //85
                var countryGEO = ObjectSpace.CreateObject<ICountries>();
                countryGEO.CountryEnum = CountryEnum.GEO;
                countryGEO.NameOfCountry = "GEO";
                countryGEO.NameOfCountryL = "GEO";


                //86
                var countryGIB = ObjectSpace.CreateObject<ICountries>();
                countryGIB.CountryEnum = CountryEnum.GIB;
                countryGIB.NameOfCountry = "GIB";
                countryGIB.NameOfCountryL = "GIB";

                //87
                var countryGRC = ObjectSpace.CreateObject<ICountries>();
                countryGRC.CountryEnum = CountryEnum.GRC;
                countryGRC.NameOfCountry = "GRC";
                countryGRC.NameOfCountryL = "GRC";


                //88
                var countryGRL = ObjectSpace.CreateObject<ICountries>();
                countryGRL.CountryEnum = CountryEnum.GRL;
                countryGRL.NameOfCountry = "GRL";
                countryGRL.NameOfCountryL = "GRL";


                //89

                var countryGRD = ObjectSpace.CreateObject<ICountries>();
                countryGRD.CountryEnum = CountryEnum.GRD;
                countryGRD.NameOfCountry = "GRD";
                countryGRD.NameOfCountryL = "GRD";


                //90
                var countryGLP = ObjectSpace.CreateObject<ICountries>();
                countryGLP.CountryEnum = CountryEnum.GLP;
                countryGLP.NameOfCountry = "GLP";
                countryGLP.NameOfCountryL = "GLP";



                //91
                var countryGUM = ObjectSpace.CreateObject<ICountries>();
                countryGUM.CountryEnum = CountryEnum.GUM;
                countryGUM.NameOfCountry = "GUM";
                countryGUM.NameOfCountryL = "GUM";


                //92
                var countryGTM = ObjectSpace.CreateObject<ICountries>();
                countryGTM.CountryEnum = CountryEnum.GTM;
                countryGTM.NameOfCountry = "GTM";
                countryGTM.NameOfCountryL = "GTM";



                //93
                var countryGIN = ObjectSpace.CreateObject<ICountries>();
                countryGIN.CountryEnum = CountryEnum.GIN;
                countryGIN.NameOfCountry = "GIN";
                countryGIN.NameOfCountryL = "GIN";

                //94

                var countryGNB = ObjectSpace.CreateObject<ICountries>();
                countryGNB.CountryEnum = CountryEnum.GNB;
                countryGNB.NameOfCountry = "GNB";
                countryGNB.NameOfCountryL = "GNB";


                //95
                var countryGUY = ObjectSpace.CreateObject<ICountries>();
                countryGUY.CountryEnum = CountryEnum.GUY;
                countryGUY.NameOfCountry = "GUY";
                countryGUY.NameOfCountryL = "GUY";


                //96
                var countryHTI = ObjectSpace.CreateObject<ICountries>();
                countryHTI.CountryEnum = CountryEnum.HTI;
                countryHTI.NameOfCountry = "HTI";
                countryHTI.NameOfCountryL = "HTI";


                //97
                var countryHMD = ObjectSpace.CreateObject<ICountries>();
                countryHMD.CountryEnum = CountryEnum.HMD;
                countryHMD.NameOfCountry = "HMD";
                countryHMD.NameOfCountryL = "HMD";


                //98
                var countryVAT = ObjectSpace.CreateObject<ICountries>();
                countryVAT.CountryEnum = CountryEnum.VAT;
                countryVAT.NameOfCountry = "VAT";
                countryVAT.NameOfCountryL = "VAT";



                //99
                var countryHND = ObjectSpace.CreateObject<ICountries>();
                countryHND.CountryEnum = CountryEnum.HND;
                countryHND.NameOfCountry = "HND";
                countryHND.NameOfCountryL = "HND";


                //100
                var countryHKG = ObjectSpace.CreateObject<ICountries>();
                countryHKG.CountryEnum = CountryEnum.HKG;
                countryHKG.NameOfCountry = "HKG";
                countryHKG.NameOfCountryL = "HKG";



                //101
                var countryHUN = ObjectSpace.CreateObject<ICountries>();
                countryHUN.CountryEnum = CountryEnum.HUN;
                countryHUN.NameOfCountry = "HUN";
                countryHUN.NameOfCountryL = "HUN";



                //102
                var countryISL = ObjectSpace.CreateObject<ICountries>();
                countryISL.CountryEnum = CountryEnum.ISL;
                countryISL.NameOfCountry = "ISL";
                countryISL.NameOfCountryL = "ISL";



                //103
                var countryIND = ObjectSpace.CreateObject<ICountries>();
                countryIND.CountryEnum = CountryEnum.IND;
                countryIND.NameOfCountry = "IND";
                countryIND.NameOfCountryL = "IND";


                //104

                var countryIRN = ObjectSpace.CreateObject<ICountries>();
                countryIRN.CountryEnum = CountryEnum.IRN;
                countryIRN.NameOfCountry = "IRN";
                countryIRN.NameOfCountryL = "IRN";



                //105
                var countryIRQ = ObjectSpace.CreateObject<ICountries>();
                countryIRQ.CountryEnum = CountryEnum.IRQ;
                countryIRQ.NameOfCountry = "IRQ";
                countryIRQ.NameOfCountryL = "IRQ";


                //106
                var countryIRL = ObjectSpace.CreateObject<ICountries>();
                countryIRL.CountryEnum = CountryEnum.IRL;
                countryIRL.NameOfCountry = "IRL";
                countryIRL.NameOfCountryL = "IRL";


                //107

                var countryISR = ObjectSpace.CreateObject<ICountries>();
                countryISR.CountryEnum = CountryEnum.ISR;
                countryISR.NameOfCountry = "ISR";
                countryISR.NameOfCountryL = "ISR";

                //108
                var countryITA = ObjectSpace.CreateObject<ICountries>();
                countryITA.CountryEnum = CountryEnum.ITA;
                countryITA.NameOfCountry = "ITA";
                countryITA.NameOfCountryL = "ITA";


                //109
                var countryJAM = ObjectSpace.CreateObject<ICountries>();
                countryJAM.CountryEnum = CountryEnum.JAM;
                countryJAM.NameOfCountry = "JAM";
                countryJAM.NameOfCountryL = "JAM";


                //110
                var countryJPN = ObjectSpace.CreateObject<ICountries>();
                countryJPN.CountryEnum = CountryEnum.JPN;
                countryJPN.NameOfCountry = "JPN";
                countryJPN.NameOfCountryL = "JPN";



                //111
                var countryJOR = ObjectSpace.CreateObject<ICountries>();
                countryJOR.CountryEnum = CountryEnum.JOR;
                countryJOR.NameOfCountry = "JOR";
                countryJOR.NameOfCountryL = "JOR";


                //112
                var countryKAZ = ObjectSpace.CreateObject<ICountries>();
                countryKAZ.CountryEnum = CountryEnum.KAZ;
                countryKAZ.NameOfCountry = "KAZ";
                countryKAZ.NameOfCountryL = "KAZ";


                //113
                var countryKEN = ObjectSpace.CreateObject<ICountries>();
                countryKEN.CountryEnum = CountryEnum.KEN;
                countryKEN.NameOfCountry = "KEN";
                countryKEN.NameOfCountryL = "KEN";

                //114
                var countryKIR = ObjectSpace.CreateObject<ICountries>();
                countryKIR.CountryEnum = CountryEnum.KIR;
                countryKIR.NameOfCountry = "KIR";
                countryKIR.NameOfCountryL = "KIR";



                //115
                var countryPRK = ObjectSpace.CreateObject<ICountries>();
                countryPRK.CountryEnum = CountryEnum.PRK;
                countryPRK.NameOfCountry = "PRK";
                countryPRK.NameOfCountryL = "PRK";


                //116
                var countryKOR = ObjectSpace.CreateObject<ICountries>();
                countryKOR.CountryEnum = CountryEnum.KOR;
                countryKOR.NameOfCountry = "KOR";
                countryKOR.NameOfCountryL = "KOR";


                //117
                var countryKWT = ObjectSpace.CreateObject<ICountries>();
                countryKWT.CountryEnum = CountryEnum.KWT;
                countryKWT.NameOfCountry = "KWT";
                countryKWT.NameOfCountryL = "KWT";


                //118
                var countryKGZ = ObjectSpace.CreateObject<ICountries>();
                countryKGZ.CountryEnum = CountryEnum.KGZ;
                countryKGZ.NameOfCountry = "KGZ";
                countryKGZ.NameOfCountryL = "KGZ";



                //119
                var countryLAO = ObjectSpace.CreateObject<ICountries>();
                countryLAO.CountryEnum = CountryEnum.LAO;
                countryLAO.NameOfCountry = "LAO";
                countryLAO.NameOfCountryL = "LAO";


                //120
                var countryLVA = ObjectSpace.CreateObject<ICountries>();
                countryLVA.CountryEnum = CountryEnum.LVA;
                countryLVA.NameOfCountry = "LVA";
                countryLVA.NameOfCountryL = "LVA";


                //121
                var countryLBN = ObjectSpace.CreateObject<ICountries>();
                countryLBN.CountryEnum = CountryEnum.LBN;
                countryLBN.NameOfCountry = "LBN";
                countryLBN.NameOfCountryL = "LBN";


                //122
                var countryLSO = ObjectSpace.CreateObject<ICountries>();
                countryLSO.CountryEnum = CountryEnum.LSO;
                countryLSO.NameOfCountry = "LSO";
                countryLSO.NameOfCountryL = "LSO";


                //123
                var countryLBR = ObjectSpace.CreateObject<ICountries>();
                countryLBR.CountryEnum = CountryEnum.LBR;
                countryLBR.NameOfCountry = "LBR";
                countryLBR.NameOfCountryL = "LBR";

                //124

                var countryLBY = ObjectSpace.CreateObject<ICountries>();
                countryLBY.CountryEnum = CountryEnum.LBY;
                countryLBY.NameOfCountry = "LBY";
                countryLBY.NameOfCountryL = "LBY";



                //125
                var countryLIE = ObjectSpace.CreateObject<ICountries>();
                countryLIE.CountryEnum = CountryEnum.LIE;
                countryLIE.NameOfCountry = "LIE";
                countryLIE.NameOfCountryL = "LIE";



                //126
                var countryLTU = ObjectSpace.CreateObject<ICountries>();
                countryLTU.CountryEnum = CountryEnum.LTU;
                countryLTU.NameOfCountry = "LTU";
                countryLTU.NameOfCountryL = "LTU";



                //127

                var countryLUX = ObjectSpace.CreateObject<ICountries>();
                countryLUX.CountryEnum = CountryEnum.LUX;
                countryLUX.NameOfCountry = "LUX";
                countryLUX.NameOfCountryL = "LUX";


                //128
                var countryMAC = ObjectSpace.CreateObject<ICountries>();
                countryMAC.CountryEnum = CountryEnum.MAC;
                countryMAC.NameOfCountry = "MAC";
                countryMAC.NameOfCountryL = "MAC";



                //129

                var countryMKD = ObjectSpace.CreateObject<ICountries>();
                countryMKD.CountryEnum = CountryEnum.MKD;
                countryMKD.NameOfCountry = "MKD";
                countryMKD.NameOfCountryL = "MKD";

                //130
                var countryMDG = ObjectSpace.CreateObject<ICountries>();
                countryMDG.CountryEnum = CountryEnum.MDG;
                countryMDG.NameOfCountry = "MDG";
                countryMDG.NameOfCountryL = "MDG";


                //131
                var countryMWI = ObjectSpace.CreateObject<ICountries>();
                countryMWI.CountryEnum = CountryEnum.MWI;
                countryMWI.NameOfCountry = "MWI";
                countryMWI.NameOfCountryL = "MWI";


                //132
                var countryMYS = ObjectSpace.CreateObject<ICountries>();
                countryMYS.CountryEnum = CountryEnum.MYS;
                countryMYS.NameOfCountry = "MYS";
                countryMYS.NameOfCountryL = "MYS";


                //133
                var countryMDV = ObjectSpace.CreateObject<ICountries>();
                countryMDV.CountryEnum = CountryEnum.MDV;
                countryMDV.NameOfCountry = "MDV";
                countryMDV.NameOfCountryL = "MDV";


                //134
                var countryMLI = ObjectSpace.CreateObject<ICountries>();
                countryMLI.CountryEnum = CountryEnum.MLI;
                countryMLI.NameOfCountry = "MLI";
                countryMLI.NameOfCountryL = "MLI";


                //135
                var countryMLT = ObjectSpace.CreateObject<ICountries>();
                countryMLT.CountryEnum = CountryEnum.MLT;
                countryMLT.NameOfCountry = "MLT";
                countryMLT.NameOfCountryL = "MLT";


                //136
                var countryMHL = ObjectSpace.CreateObject<ICountries>();
                countryMHL.CountryEnum = CountryEnum.MHL;
                countryMHL.NameOfCountry = "MHL";
                countryMHL.NameOfCountryL = "MHL";


                //137
                var countryMTQ = ObjectSpace.CreateObject<ICountries>();
                countryMTQ.CountryEnum = CountryEnum.MTQ;
                countryMTQ.NameOfCountry = "MTQ";
                countryMTQ.NameOfCountryL = "MTQ";


                //138
                var countryMRT = ObjectSpace.CreateObject<ICountries>();
                countryMRT.CountryEnum = CountryEnum.MRT;
                countryMRT.NameOfCountry = "MRT";
                countryMRT.NameOfCountryL = "MRT";


                //139
                var countryMUS = ObjectSpace.CreateObject<ICountries>();
                countryMUS.CountryEnum = CountryEnum.MUS;
                countryMUS.NameOfCountry = "MUS";
                countryMUS.NameOfCountryL = "MUS";


                //140
                var countryMYT = ObjectSpace.CreateObject<ICountries>();
                countryMYT.CountryEnum = CountryEnum.MYT;
                countryMYT.NameOfCountry = "MYT";
                countryMYT.NameOfCountryL = "MYT";



                //141
                var countryMEX = ObjectSpace.CreateObject<ICountries>();
                countryMEX.CountryEnum = CountryEnum.MEX;
                countryMEX.NameOfCountry = "MEX";
                countryMEX.NameOfCountryL = "MEX";

                //142

                var countryFSM = ObjectSpace.CreateObject<ICountries>();
                countryFSM.CountryEnum = CountryEnum.FSM;
                countryFSM.NameOfCountry = "FSM";
                countryFSM.NameOfCountryL = "FSM";


                //143
                var countryMDA = ObjectSpace.CreateObject<ICountries>();
                countryMDA.CountryEnum = CountryEnum.MDA;
                countryMDA.NameOfCountry = "MDA";
                countryMDA.NameOfCountryL = "MDA";


                //144
                var countryMCO = ObjectSpace.CreateObject<ICountries>();
                countryMCO.CountryEnum = CountryEnum.MCO;
                countryMCO.NameOfCountry = "MCO";
                countryMCO.NameOfCountryL = "MCO";


                //145
                var countryMNG = ObjectSpace.CreateObject<ICountries>();
                countryMNG.CountryEnum = CountryEnum.MNG;
                countryMNG.NameOfCountry = "MNG";
                countryMNG.NameOfCountryL = "MNG";


                //146
                var countryMSR = ObjectSpace.CreateObject<ICountries>();
                countryMSR.CountryEnum = CountryEnum.MSR;
                countryMSR.NameOfCountry = "MSR";
                countryMSR.NameOfCountryL = "MSR";


                //147
                var countryMAR = ObjectSpace.CreateObject<ICountries>();
                countryMAR.CountryEnum = CountryEnum.MAR;
                countryMAR.NameOfCountry = "MAR";
                countryMAR.NameOfCountryL = "MAR";


                //148
                var countryMOZ = ObjectSpace.CreateObject<ICountries>();
                countryMOZ.CountryEnum = CountryEnum.MOZ;
                countryMOZ.NameOfCountry = "MOZ";
                countryMOZ.NameOfCountryL = "MOZ";


                //149

                var countryMMR = ObjectSpace.CreateObject<ICountries>();
                countryMMR.CountryEnum = CountryEnum.MMR;
                countryMMR.NameOfCountry = "MMR";
                countryMMR.NameOfCountryL = "MMR";


                //150
                var countryNAM = ObjectSpace.CreateObject<ICountries>();
                countryNAM.CountryEnum = CountryEnum.NAM;
                countryNAM.NameOfCountry = "NAM";
                countryNAM.NameOfCountryL = "NAM";



                //151
                var countryNRU = ObjectSpace.CreateObject<ICountries>();
                countryNRU.CountryEnum = CountryEnum.NRU;
                countryNRU.NameOfCountry = "NRU";
                countryNRU.NameOfCountryL = "NRU";



                //152
                var countryNPL = ObjectSpace.CreateObject<ICountries>();
                countryNPL.CountryEnum = CountryEnum.NPL;
                countryNPL.NameOfCountry = "NPL";
                countryNPL.NameOfCountryL = "NPL";


                //153

                var countryNLD = ObjectSpace.CreateObject<ICountries>();
                countryNLD.CountryEnum = CountryEnum.NLD;
                countryNLD.NameOfCountry = "NLD";
                countryNLD.NameOfCountryL = "NLD";



                //154
                var countryANT = ObjectSpace.CreateObject<ICountries>();
                countryANT.CountryEnum = CountryEnum.ANT;
                countryANT.NameOfCountry = "ANT";
                countryANT.NameOfCountryL = "ANT";


                //155

                var countryNCL = ObjectSpace.CreateObject<ICountries>();
                countryNCL.CountryEnum = CountryEnum.NCL;
                countryNCL.NameOfCountry = "NCL";
                countryNCL.NameOfCountryL = "NCL";



                //156
                var countryNZL = ObjectSpace.CreateObject<ICountries>();
                countryNZL.CountryEnum = CountryEnum.NZL;
                countryNZL.NameOfCountry = "NZL";
                countryNZL.NameOfCountryL = "NZL";


                //157
                var countryNIC = ObjectSpace.CreateObject<ICountries>();
                countryNIC.CountryEnum = CountryEnum.NIC;
                countryNIC.NameOfCountry = "NIC";
                countryNIC.NameOfCountryL = "NIC";


                //158
                var countryNER = ObjectSpace.CreateObject<ICountries>();
                countryNER.CountryEnum = CountryEnum.NER;
                countryNER.NameOfCountry = "NER";
                countryNER.NameOfCountryL = "NER";


                //159
                var countryNGA = ObjectSpace.CreateObject<ICountries>();
                countryNGA.CountryEnum = CountryEnum.NGA;
                countryNGA.NameOfCountry = "NGA";
                countryNGA.NameOfCountryL = "NGA";


                //160
                var countryNIU = ObjectSpace.CreateObject<ICountries>();
                countryNIU.CountryEnum = CountryEnum.NIU;
                countryNIU.NameOfCountry = "NIU";
                countryNIU.NameOfCountryL = "NIU";


                //161
                var countryNFK = ObjectSpace.CreateObject<ICountries>();
                countryNFK.CountryEnum = CountryEnum.NFK;
                countryNFK.NameOfCountry = "NFK";
                countryNFK.NameOfCountryL = "NFK";

                //162
                var countryMNP = ObjectSpace.CreateObject<ICountries>();
                countryMNP.CountryEnum = CountryEnum.MNP;
                countryMNP.NameOfCountry = "MNP";
                countryMNP.NameOfCountryL = "MNP";


                //163
                var countryNOR = ObjectSpace.CreateObject<ICountries>();
                countryNOR.CountryEnum = CountryEnum.NOR;
                countryNOR.NameOfCountry = "NOR";
                countryNOR.NameOfCountryL = "NOR";

                //164
                var countryOMN = ObjectSpace.CreateObject<ICountries>();
                countryOMN.CountryEnum = CountryEnum.OMN;
                countryOMN.NameOfCountry = "OMN";
                countryOMN.NameOfCountryL = "OMN";

                //165
                var countryPAK = ObjectSpace.CreateObject<ICountries>();
                countryPAK.CountryEnum = CountryEnum.PAK;
                countryPAK.NameOfCountry = "PAK";
                countryPAK.NameOfCountryL = "PAK";

                //166
                var countryPLW = ObjectSpace.CreateObject<ICountries>();
                countryPLW.CountryEnum = CountryEnum.PLW;
                countryPLW.NameOfCountry = "PLW";
                countryPLW.NameOfCountryL = "PLW";

                //167
                var countryPAN = ObjectSpace.CreateObject<ICountries>();
                countryPAN.CountryEnum = CountryEnum.PAN;
                countryPAN.NameOfCountry = "PAN";
                countryPAN.NameOfCountryL = "PAN";


                //168
                var countryPNG = ObjectSpace.CreateObject<ICountries>();
                countryPNG.CountryEnum = CountryEnum.PNG;
                countryPNG.NameOfCountry = "PNG";
                countryPNG.NameOfCountryL = "PNG";



                //169

                var countryPRY = ObjectSpace.CreateObject<ICountries>();
                countryPRY.CountryEnum = CountryEnum.PRY;
                countryPRY.NameOfCountry = "PRY";
                countryPRY.NameOfCountryL = "PRY";


                //170
                var countryPER = ObjectSpace.CreateObject<ICountries>();
                countryPER.CountryEnum = CountryEnum.PER;
                countryPER.NameOfCountry = "PER";
                countryPER.NameOfCountryL = "PER";


                //171
                var countryPHL = ObjectSpace.CreateObject<ICountries>();
                countryPHL.CountryEnum = CountryEnum.PHL;
                countryPHL.NameOfCountry = "PHL";
                countryPHL.NameOfCountryL = "PHL";


                //172
                var countryPCN = ObjectSpace.CreateObject<ICountries>();
                countryPCN.CountryEnum = CountryEnum.PCN;
                countryPCN.NameOfCountry = "PCN";
                countryPCN.NameOfCountryL = "PCN";


                //173
                var countryPOL = ObjectSpace.CreateObject<ICountries>();
                countryPOL.CountryEnum = CountryEnum.POL;
                countryPOL.NameOfCountry = "POL";
                countryPOL.NameOfCountryL = "POL";


                //174
                var countryPRI = ObjectSpace.CreateObject<ICountries>();
                countryPRI.CountryEnum = CountryEnum.PRI;
                countryPRI.NameOfCountry = "PRI";
                countryPRI.NameOfCountryL = "PRI";


                //175



                //176
                var countryQAT = ObjectSpace.CreateObject<ICountries>();
                countryQAT.CountryEnum = CountryEnum.QAT;
                countryQAT.NameOfCountry = "QAT";
                countryQAT.NameOfCountryL = "QAT";


                //177
                var countryREU = ObjectSpace.CreateObject<ICountries>();
                countryREU.CountryEnum = CountryEnum.REU;
                countryREU.NameOfCountry = "REU";
                countryREU.NameOfCountryL = "REU";


                //178
                var countryROM = ObjectSpace.CreateObject<ICountries>();
                countryROM.CountryEnum = CountryEnum.ROM;
                countryROM.NameOfCountry = "ROM";
                countryROM.NameOfCountryL = "ROM";


                //179
                var countryRWA = ObjectSpace.CreateObject<ICountries>();
                countryRWA.CountryEnum = CountryEnum.RWA;
                countryRWA.NameOfCountry = "RWA";
                countryRWA.NameOfCountryL = "RWA";


                //180
                var countryKNA = ObjectSpace.CreateObject<ICountries>();
                countryKNA.CountryEnum = CountryEnum.KNA;
                countryKNA.NameOfCountry = "KNA";
                countryKNA.NameOfCountryL = "KNA";

                //181
                var countryLCA = ObjectSpace.CreateObject<ICountries>();
                countryLCA.CountryEnum = CountryEnum.LCA;
                countryLCA.NameOfCountry = "LCA";
                countryLCA.NameOfCountryL = "LCA";

                //182
                var countryVCT = ObjectSpace.CreateObject<ICountries>();
                countryVCT.CountryEnum = CountryEnum.VCT;
                countryVCT.NameOfCountry = "VCT";
                countryVCT.NameOfCountryL = "VCT";


                //183
                var countryWSM = ObjectSpace.CreateObject<ICountries>();
                countryWSM.CountryEnum = CountryEnum.WSM;
                countryWSM.NameOfCountry = "WSM";
                countryWSM.NameOfCountryL = "WSM";


                //184
                var countrySMR = ObjectSpace.CreateObject<ICountries>();
                countrySMR.CountryEnum = CountryEnum.SMR;
                countrySMR.NameOfCountry = "SMR";
                countrySMR.NameOfCountryL = "SMR";


                //185
                var countrySTP = ObjectSpace.CreateObject<ICountries>();
                countrySTP.CountryEnum = CountryEnum.STP;
                countrySTP.NameOfCountry = "STP";
                countrySTP.NameOfCountryL = "STP";

                //186
                var countrySAU = ObjectSpace.CreateObject<ICountries>();
                countrySAU.CountryEnum = CountryEnum.SAU;
                countrySAU.NameOfCountry = "SAU";
                countrySAU.NameOfCountryL = "SAU";


                //187
                var countrySEN = ObjectSpace.CreateObject<ICountries>();
                countrySEN.CountryEnum = CountryEnum.SEN;
                countrySEN.NameOfCountry = "SEN";
                countrySEN.NameOfCountryL = "SEN";

                //188
                var countrySYC = ObjectSpace.CreateObject<ICountries>();
                countrySYC.CountryEnum = CountryEnum.SYC;
                countrySYC.NameOfCountry = "SYC";
                countrySYC.NameOfCountryL = "SYC";


                //189



                //190
                var countrySLE = ObjectSpace.CreateObject<ICountries>();
                countrySLE.CountryEnum = CountryEnum.SLE;
                countrySLE.NameOfCountry = "SLE";
                countrySLE.NameOfCountryL = "SLE";


                //191
                var countrySGP = ObjectSpace.CreateObject<ICountries>();
                countrySGP.CountryEnum = CountryEnum.SGP;
                countrySGP.NameOfCountry = "SGP";
                countrySGP.NameOfCountryL = "SGP";


                //192
                var countrySVK = ObjectSpace.CreateObject<ICountries>();
                countrySVK.CountryEnum = CountryEnum.SVK;
                countrySVK.NameOfCountry = "SVK";
                countrySVK.NameOfCountryL = "SVK";

                //193
                var countrySVN = ObjectSpace.CreateObject<ICountries>();
                countrySVN.CountryEnum = CountryEnum.SVN;
                countrySVN.NameOfCountry = "SVN";
                countrySVN.NameOfCountryL = "SVN";

                //194
                var countrySLB = ObjectSpace.CreateObject<ICountries>();
                countrySLB.CountryEnum = CountryEnum.SLB;
                countrySLB.NameOfCountry = "SLB";
                countrySLB.NameOfCountryL = "SLB";

                //195
                var countrySOM = ObjectSpace.CreateObject<ICountries>();
                countrySOM.CountryEnum = CountryEnum.SOM;
                countrySOM.NameOfCountry = "SOM";
                countrySOM.NameOfCountryL = "SOM";

                //196
                var countryZAF = ObjectSpace.CreateObject<ICountries>();
                countryZAF.CountryEnum = CountryEnum.ZAF;
                countryZAF.NameOfCountry = "ZAF";
                countryZAF.NameOfCountryL = "ZAF";

                //197
                var countrySGS = ObjectSpace.CreateObject<ICountries>();
                countrySGS.CountryEnum = CountryEnum.SGS;
                countrySGS.NameOfCountry = "SGS";
                countrySGS.NameOfCountryL = "SGS";

                //198
                var countryESP = ObjectSpace.CreateObject<ICountries>();
                countryESP.CountryEnum = CountryEnum.ESP;
                countryESP.NameOfCountry = "ESP";
                countryESP.NameOfCountryL = "ESP";

                //199
                var countryLKA = ObjectSpace.CreateObject<ICountries>();
                countryLKA.CountryEnum = CountryEnum.LKA;
                countryLKA.NameOfCountry = "LKA";
                countryLKA.NameOfCountryL = "LKA";

                //200
                var countrySHN = ObjectSpace.CreateObject<ICountries>();
                countrySHN.CountryEnum = CountryEnum.SHN;
                countrySHN.NameOfCountry = "SHN";
                countrySHN.NameOfCountryL = "SHN";

                //201
                var countrySPM = ObjectSpace.CreateObject<ICountries>();
                countrySPM.CountryEnum = CountryEnum.SPM;
                countrySPM.NameOfCountry = "SPM";
                countrySPM.NameOfCountryL = "SPM";


                //202
                var countrySDN = ObjectSpace.CreateObject<ICountries>();
                countrySDN.CountryEnum = CountryEnum.SDN;
                countrySDN.NameOfCountry = "SDN";
                countrySDN.NameOfCountryL = "SDN";

                //203
                var countrySUR = ObjectSpace.CreateObject<ICountries>();
                countrySUR.CountryEnum = CountryEnum.SUR;
                countrySUR.NameOfCountry = "SUR";
                countrySUR.NameOfCountryL = "SUR";

                //204
                var countrySJM = ObjectSpace.CreateObject<ICountries>();
                countrySJM.CountryEnum = CountryEnum.SJM;
                countrySJM.NameOfCountry = "SJM";
                countrySJM.NameOfCountryL = "SJM";






                //205
                var countrySWZ = ObjectSpace.CreateObject<ICountries>();
                countrySWZ.CountryEnum = CountryEnum.SWZ;
                countrySWZ.NameOfCountry = "SWZ";
                countrySWZ.NameOfCountryL = "SWZ";



                //206
                var countrySWE = ObjectSpace.CreateObject<ICountries>();
                countrySWE.CountryEnum = CountryEnum.SWE;
                countrySWE.NameOfCountry = "SWE";
                countrySWE.NameOfCountryL = "SWE";

                //207

                var countryCHE = ObjectSpace.CreateObject<ICountries>();
                countryCHE.CountryEnum = CountryEnum.CHE;
                countryCHE.NameOfCountry = "CHE";
                countryCHE.NameOfCountryL = "CHE";


                //208
                var countrySYR = ObjectSpace.CreateObject<ICountries>();
                countrySYR.CountryEnum = CountryEnum.SYR;
                countrySYR.NameOfCountry = "SYR";
                countrySYR.NameOfCountryL = "SYR";

                //209
                var countryTWN = ObjectSpace.CreateObject<ICountries>();
                countryTWN.CountryEnum = CountryEnum.TWN;
                countryTWN.NameOfCountry = "TWN";
                countryTWN.NameOfCountryL = "TWN";

                //210
                var countryTZA = ObjectSpace.CreateObject<ICountries>();
                countryTZA.CountryEnum = CountryEnum.TZA;
                countryTZA.NameOfCountry = "TZA";
                countryTZA.NameOfCountryL = "TZA";


                //211
                var countryTHA = ObjectSpace.CreateObject<ICountries>();
                countryTHA.CountryEnum = CountryEnum.THA;
                countryTHA.NameOfCountry = "THA";
                countryTHA.NameOfCountryL = "THA";


                //212
                var countryTGO = ObjectSpace.CreateObject<ICountries>();
                countryTGO.CountryEnum = CountryEnum.TGO;
                countryTGO.NameOfCountry = "TGO";
                countryTGO.NameOfCountryL = "TGO";


                //213
                var countryTKL = ObjectSpace.CreateObject<ICountries>();
                countryTKL.CountryEnum = CountryEnum.TKL;
                countryTKL.NameOfCountry = "TKL";
                countryTKL.NameOfCountryL = "TKL";


                //214
                var countryTON = ObjectSpace.CreateObject<ICountries>();
                countryTON.CountryEnum = CountryEnum.TON;
                countryTON.NameOfCountry = "TON";
                countryTON.NameOfCountryL = "TON";


                //215
                var countryTTO = ObjectSpace.CreateObject<ICountries>();
                countryTTO.CountryEnum = CountryEnum.TTO;
                countryTTO.NameOfCountry = "TTO";
                countryTTO.NameOfCountryL = "TTO";


                //216
                var countryTUN = ObjectSpace.CreateObject<ICountries>();
                countryTUN.CountryEnum = CountryEnum.TUN;
                countryTUN.NameOfCountry = "TUN";
                countryTUN.NameOfCountryL = "TUN";


                //217
                var countryTCA = ObjectSpace.CreateObject<ICountries>();
                countryTCA.CountryEnum = CountryEnum.TCA;
                countryTCA.NameOfCountry = "TCA";
                countryTCA.NameOfCountryL = "TCA";


                //218
                var countryTUV = ObjectSpace.CreateObject<ICountries>();
                countryTUV.CountryEnum = CountryEnum.TUV;
                countryTUV.NameOfCountry = "TUV";
                countryTUV.NameOfCountryL = "TUV";


                //219
                var countryUGA = ObjectSpace.CreateObject<ICountries>();
                countryUGA.CountryEnum = CountryEnum.UGA;
                countryUGA.NameOfCountry = "UGA";
                countryUGA.NameOfCountryL = "UGA";


                //220
                var countryARE = ObjectSpace.CreateObject<ICountries>();
                countryARE.CountryEnum = CountryEnum.ARE;
                countryARE.NameOfCountry = "ARE";
                countryARE.NameOfCountryL = "ARE";


                //221
                var countryUMI = ObjectSpace.CreateObject<ICountries>();
                countryUMI.CountryEnum = CountryEnum.UMI;
                countryUMI.NameOfCountry = "UMI";


                //222
                var countryURY = ObjectSpace.CreateObject<ICountries>();
                countryURY.CountryEnum = CountryEnum.URY;
                countryURY.NameOfCountry = "URY";
                countryURY.NameOfCountryL = "URY";


                //223
                var countryUZB = ObjectSpace.CreateObject<ICountries>();
                countryUZB.CountryEnum = CountryEnum.UZB;
                countryUZB.NameOfCountry = "UZB";
                countryUZB.NameOfCountryL = "UZB";


                //224
                var countryVUT = ObjectSpace.CreateObject<ICountries>();
                countryVUT.CountryEnum = CountryEnum.VUT;
                countryVUT.NameOfCountry = "VUT";
                countryVUT.NameOfCountryL = "VUT";


                //225
                var countryVEN = ObjectSpace.CreateObject<ICountries>();
                countryVEN.CountryEnum = CountryEnum.VEN;
                countryVEN.NameOfCountry = "VEN";
                countryVEN.NameOfCountryL = "VEN";


                //226
                var countryVNM = ObjectSpace.CreateObject<ICountries>();
                countryVNM.CountryEnum = CountryEnum.VNM;
                countryVNM.NameOfCountry = "VNM";
                countryVNM.NameOfCountryL = "VNM";


                //227
                var countryVGB = ObjectSpace.CreateObject<ICountries>();
                countryVGB.CountryEnum = CountryEnum.VGB;
                countryVGB.NameOfCountry = "VGB";
                countryVGB.NameOfCountryL = "VGB";


                //228
                var countryVIR = ObjectSpace.CreateObject<ICountries>();
                countryVIR.CountryEnum = CountryEnum.VIR;
                countryVIR.NameOfCountry = "VIR";
                countryVIR.NameOfCountryL = "VIR";

                //229

                var countryWLF = ObjectSpace.CreateObject<ICountries>();
                countryWLF.CountryEnum = CountryEnum.WLF;
                countryWLF.NameOfCountry = "WLF";
                countryWLF.NameOfCountryL = "WLF";

                //230

                var countryESH = ObjectSpace.CreateObject<ICountries>();
                countryESH.CountryEnum = CountryEnum.ESH;
                countryESH.NameOfCountry = "ESH";
                countryESH.NameOfCountryL = "ESH";


                //231
                var countryYEM = ObjectSpace.CreateObject<ICountries>();
                countryYEM.CountryEnum = CountryEnum.YEM;
                countryYEM.NameOfCountry = "YEM";
                countryYEM.NameOfCountryL = "YEM";

                //232

                var countryZMB = ObjectSpace.CreateObject<ICountries>();
                countryZMB.CountryEnum = CountryEnum.ZMB;
                countryZMB.NameOfCountry = "ZMB";
                countryZMB.NameOfCountryL = "ZMB";


                //233
                var countryZWE = ObjectSpace.CreateObject<ICountries>();
                countryZWE.CountryEnum = CountryEnum.ZWE;
                countryZWE.NameOfCountry = "ZWE";
                countryZWE.NameOfCountryL = "ZWE";


                //234
                var countryROU = ObjectSpace.CreateObject<ICountries>();
                countryROU.CountryEnum = CountryEnum.ROU;
                countryROU.NameOfCountry = "ROU";
                countryROU.NameOfCountryL = "ROU";















                # endregion


                #region Prefred Visa Category

                var prefVisaCatOnceToMulty = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatOnceToMulty.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.OnceToMulty;
                prefVisaCatOnceToMulty.PreferredVisaCategoryL = "bir gezeklikden köp gezeklige";
                prefVisaCatOnceToMulty.PreferredVisaCategoryR = "с однократного на много кратный";



                var prefVisaCatMultyToOnce = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatMultyToOnce.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.MultyToOnce;
                prefVisaCatMultyToOnce.PreferredVisaCategoryL = "köp gezeklikden bir gezeklige";
                prefVisaCatMultyToOnce.PreferredVisaCategoryR = "с многократного на одно кратный";




                var prefVisaCatTwiceToOne = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatTwiceToOne.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.TwoToOnce;
                prefVisaCatTwiceToOne.PreferredVisaCategoryL = "iki gezeklikden bir gezeklige";
                prefVisaCatTwiceToOne.PreferredVisaCategoryR = "с двухкратного на одно кратный";

                var prefVisaCatOnceToTwice = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatOnceToTwice.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.OnceToTwice;
                prefVisaCatOnceToTwice.PreferredVisaCategoryL = "bir gezeklikden iki gezeklige";
                prefVisaCatOnceToTwice.PreferredVisaCategoryR = "с однократного на двух кратный";

                var prefVisaCatOnceToThree = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatOnceToThree.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.OnceToThree;
                prefVisaCatOnceToThree.PreferredVisaCategoryL = "bir gezeklikden üç gezeklige";
                prefVisaCatOnceToThree.PreferredVisaCategoryR = "с однократного на трех кратный";



                var prefVisaCatMultyToTwice = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatMultyToTwice.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.MultyToTwice;
                prefVisaCatMultyToTwice.PreferredVisaCategoryL = "köp gezeklikden iki gezeklige";
                prefVisaCatMultyToTwice.PreferredVisaCategoryR = "с многократного на двух кратный";


                var prefVisaCatMultyToThree = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatMultyToThree.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.MultyToThree;
                prefVisaCatMultyToThree.PreferredVisaCategoryL = "köp gezeklikden üç gezeklige";
                prefVisaCatMultyToThree.PreferredVisaCategoryR = "с многократного на трех кратный";


                var prefVisaCatTwiceToThree = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatTwiceToThree.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.TwoToOnce;
                prefVisaCatTwiceToThree.PreferredVisaCategoryL = "iki gezeklikden üç gezeklige";
                prefVisaCatTwiceToThree.PreferredVisaCategoryR = "с двухкратного на трех кратный";


                var prefVisaCatTwiceToMulty = ObjectSpace.CreateObject<PrefferedVisaCategory>();
                prefVisaCatTwiceToMulty.PreferedVisaCategoryEnum = PreferedVisaCategoryEnum.TwoToOnce;
                prefVisaCatTwiceToMulty.PreferredVisaCategoryL = "iki gezeklikden köp gezeklige";
                prefVisaCatTwiceToMulty.PreferredVisaCategoryR = "с двухкратного на много кратный";


                #endregion

                #region Regions




                var regionAH = ObjectSpace.CreateObject<IRegion>();
                regionAH.NameOfRegion = RegionEnum.AhalWelaýaty;
                regionAH.NameOfRegionL = "Ahal welaýaty";








                var regionAS = ObjectSpace.CreateObject<IRegion>();
                regionAS.NameOfRegion = RegionEnum.AşgabatŞäheri;
                regionAS.NameOfRegionL = "Aşgabat şäheri";







                var regionBN = ObjectSpace.CreateObject<IRegion>();
                regionBN.NameOfRegion = RegionEnum.BalkanWelaýaty;
                regionBN.NameOfRegionL = "Balkan welaýaty";








                var regionDZ = ObjectSpace.CreateObject<IRegion>();
                regionDZ.NameOfRegion = RegionEnum.DaşoguzWelaýaty;
                regionDZ.NameOfRegionL = "Daşoguz welaýaty";









                var regionLB = ObjectSpace.CreateObject<IRegion>();
                regionLB.NameOfRegion = RegionEnum.LebapWelaýaty;
                regionLB.NameOfRegionL = "Lebap welaýaty";








                var regionMR = ObjectSpace.CreateObject<IRegion>();
                regionMR.NameOfRegion = RegionEnum.MaryWelaýaty;
                regionMR.NameOfRegionL = "Mary welaýaty";






                #endregion

                #region city



                var cityAS = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityAS.Region = regionAS;
                cityAS.CityType = CityTypeEnum.Şäher;
                cityAS.ŞäherEtrapL = "Çandybil etraby";


                var cityAÇandybilet = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityAÇandybilet.Region = regionAS;
                cityAÇandybilet.CityType = CityTypeEnum.Şäher;
                cityAÇandybilet.ŞäherEtrapL = "Aşgabat şäheri";


                // Ahal Welayaty

                var cityBaharlyE = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityBaharlyE.Region = regionAH;
                cityBaharlyE.CityType = CityTypeEnum.Etrap;
                cityBaharlyE.ŞäherEtrapL = "Baharly etraby";

                var cityBaharlyS = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityBaharlyS.Region = regionAH;
                cityBaharlyS.CityType = CityTypeEnum.Şäher;
                cityBaharlyS.ŞäherEtrapL = "Baharly şäheri";

                var cityGokdepeE = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityGokdepeE.Region = regionAH;
                cityGokdepeE.CityType = CityTypeEnum.Etrap;
                cityGokdepeE.ŞäherEtrapL = "Gökdepe etraby";

                var cityGokdepeS = ObjectSpace.CreateObject<IŞäherEtrap>();
                cityGokdepeS.Region = regionAH;
                cityGokdepeS.CityType = CityTypeEnum.Şäher;
                cityGokdepeS.ŞäherEtrapL = "Gökdepe şäheri";

                var RuhabatE = ObjectSpace.CreateObject<IŞäherEtrap>();
                RuhabatE.Region = regionAH;
                RuhabatE.CityType = CityTypeEnum.Etrap;
                RuhabatE.ŞäherEtrapL = "Ruhabat etraby";

                var AkbugdaýE = ObjectSpace.CreateObject<IŞäherEtrap>();
                AkbugdaýE.Region = regionAH;
                AkbugdaýE.CityType = CityTypeEnum.Etrap;
                AkbugdaýE.ŞäherEtrapL = "Akbugdaý etraby";

                var AnewS = ObjectSpace.CreateObject<IŞäherEtrap>();
                AnewS.Region = regionAH;
                AnewS.CityType = CityTypeEnum.Şäher;
                AnewS.ŞäherEtrapL = "Änew şäheri";


                var KakaE = ObjectSpace.CreateObject<IŞäherEtrap>();
                KakaE.Region = regionAH;
                KakaE.CityType = CityTypeEnum.Etrap;
                KakaE.ŞäherEtrapL = "Kaka etraby";

                var tejenEtraby = ObjectSpace.CreateObject<IŞäherEtrap>();
                tejenEtraby.Region = regionAH;
                tejenEtraby.CityType = CityTypeEnum.Etrap;
                tejenEtraby.ŞäherEtrapL = "Tejen etraby";

                var tejenŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                tejenŞ.Region = regionAH;
                tejenŞ.CityType = CityTypeEnum.Şäher;
                tejenŞ.ŞäherEtrapL = "Tejen şäheri";

                var altynAsyrEtraby = ObjectSpace.CreateObject<IŞäherEtrap>();
                altynAsyrEtraby.Region = regionAH;
                altynAsyrEtraby.CityType = CityTypeEnum.Etrap;
                altynAsyrEtraby.ŞäherEtrapL = "Altyn asyr etraby";

                var babadaýhanE = ObjectSpace.CreateObject<IŞäherEtrap>();
                babadaýhanE.Region = regionAH;
                babadaýhanE.CityType = CityTypeEnum.Etrap;
                babadaýhanE.ŞäherEtrapL = "Babadaýhan etraby";

                var sarahsE = ObjectSpace.CreateObject<IŞäherEtrap>();
                sarahsE.Region = regionAH;
                sarahsE.CityType = CityTypeEnum.Etrap;
                sarahsE.ŞäherEtrapL = "Sarahs etraby";

                var abadanS = ObjectSpace.CreateObject<IŞäherEtrap>();
                abadanS.Region = regionAH;
                abadanS.CityType = CityTypeEnum.Şäher;
                abadanS.ŞäherEtrapL = "Abadan şäheri";


                // Balkan





                var esengulyE = ObjectSpace.CreateObject<IŞäherEtrap>();
                esengulyE.Region = regionBN;
                esengulyE.CityType = CityTypeEnum.Etrap;
                esengulyE.ŞäherEtrapL = "Esenguly etraby";

                var bereketE = ObjectSpace.CreateObject<IŞäherEtrap>();
                bereketE.Region = regionBN;
                bereketE.CityType = CityTypeEnum.Etrap;
                bereketE.ŞäherEtrapL = "Bereket etraby";


                var bereketŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                bereketŞ.Region = regionBN;
                bereketŞ.CityType = CityTypeEnum.Şäher;
                bereketŞ.ŞäherEtrapL = "Bereket şäheri";


                var serdarE = ObjectSpace.CreateObject<IŞäherEtrap>();
                serdarE.Region = regionBN;
                serdarE.CityType = CityTypeEnum.Etrap;
                serdarE.ŞäherEtrapL = "Serdar etraby";


                var magtymgulyE = ObjectSpace.CreateObject<IŞäherEtrap>();
                magtymgulyE.Region = regionBN;
                magtymgulyE.CityType = CityTypeEnum.Etrap;
                magtymgulyE.ŞäherEtrapL = "Magtymguly etraby";


                var etrekE = ObjectSpace.CreateObject<IŞäherEtrap>();
                etrekE.Region = regionBN;
                etrekE.CityType = CityTypeEnum.Etrap;
                etrekE.ŞäherEtrapL = "Etrek etraby";


                var turkmenbaşyE = ObjectSpace.CreateObject<IŞäherEtrap>();
                turkmenbaşyE.Region = regionBN;
                turkmenbaşyE.CityType = CityTypeEnum.Etrap;
                turkmenbaşyE.ŞäherEtrapL = "Türkmenbaşy etraby";



                var balkanabatŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                balkanabatŞ.Region = regionBN;
                balkanabatŞ.CityType = CityTypeEnum.Şäher;
                balkanabatŞ.ŞäherEtrapL = "Balkanabat şäheri";



                var turkmenbaşyŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                turkmenbaşyŞ.Region = regionBN;
                turkmenbaşyŞ.CityType = CityTypeEnum.Şäher;
                turkmenbaşyŞ.ŞäherEtrapL = "Türkmenbaşy şäheri";



                var gumdagŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                gumdagŞ.Region = regionBN;
                gumdagŞ.CityType = CityTypeEnum.Şäher;
                gumdagŞ.ŞäherEtrapL = "Gumdag şäheri";


                var hazarŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                hazarŞ.Region = regionBN;
                hazarŞ.CityType = CityTypeEnum.Şäher;
                hazarŞ.ŞäherEtrapL = "Hazar şäheri";


                var garabogazŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                garabogazŞ.Region = regionBN;
                garabogazŞ.CityType = CityTypeEnum.Şäher;
                garabogazŞ.ŞäherEtrapL = "Garabogaz şäheri";


                var serdarŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                serdarŞ.Region = regionBN;
                serdarŞ.CityType = CityTypeEnum.Şäher;
                serdarŞ.ŞäherEtrapL = "Serdar şäheri";

                // Daşoguz welaýaty

                var gurbansoltanEjeE = ObjectSpace.CreateObject<IŞäherEtrap>();
                gurbansoltanEjeE.Region = regionDZ;
                gurbansoltanEjeE.CityType = CityTypeEnum.Etrap;
                gurbansoltanEjeE.ŞäherEtrapL = "Gurbansoltan-eje ad. etraby";


                var saparmyratTE = ObjectSpace.CreateObject<IŞäherEtrap>();
                saparmyratTE.Region = regionDZ;
                saparmyratTE.CityType = CityTypeEnum.Etrap;
                saparmyratTE.ŞäherEtrapL = "Saparmyrat Türkmenbaşy ad. etraby";



                var sANE = ObjectSpace.CreateObject<IŞäherEtrap>();
                sANE.Region = regionDZ;
                sANE.CityType = CityTypeEnum.Etrap;
                sANE.ŞäherEtrapL = "S.A.Nyýazow ad. etraby";



                var goroglyEtr = ObjectSpace.CreateObject<IŞäherEtrap>();
                goroglyEtr.Region = regionDZ;
                goroglyEtr.CityType = CityTypeEnum.Etrap;
                goroglyEtr.ŞäherEtrapL = "Görogly etraby";



                var boldumsazE = ObjectSpace.CreateObject<IŞäherEtrap>();
                boldumsazE.Region = regionDZ;
                boldumsazE.CityType = CityTypeEnum.Etrap;
                boldumsazE.ŞäherEtrapL = "Boldumsaz etraby";



                var koneürgençE = ObjectSpace.CreateObject<IŞäherEtrap>();
                koneürgençE.Region = regionDZ;
                koneürgençE.CityType = CityTypeEnum.Etrap;
                koneürgençE.ŞäherEtrapL = "Köneürgenç etraby";



                var akdepeE = ObjectSpace.CreateObject<IŞäherEtrap>();
                akdepeE.Region = regionDZ;
                akdepeE.CityType = CityTypeEnum.Etrap;
                akdepeE.ŞäherEtrapL = "Akdepe etraby";



                var gubadagE = ObjectSpace.CreateObject<IŞäherEtrap>();
                gubadagE.Region = regionDZ;
                gubadagE.CityType = CityTypeEnum.Etrap;
                gubadagE.ŞäherEtrapL = "Gubadag etraby";



                var ruhubelentE = ObjectSpace.CreateObject<IŞäherEtrap>();
                ruhubelentE.Region = regionDZ;
                ruhubelentE.CityType = CityTypeEnum.Etrap;
                ruhubelentE.ŞäherEtrapL = "Ruhubelent etraby";



                var daşoguzŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                daşoguzŞ.Region = regionDZ;
                daşoguzŞ.CityType = CityTypeEnum.Şäher;
                daşoguzŞ.ŞäherEtrapL = "Daşoguz şäheri";



                var köneürgençŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                köneürgençŞ.Region = regionDZ;
                köneürgençŞ.CityType = CityTypeEnum.Şäher;
                köneürgençŞ.ŞäherEtrapL = "Köneürgenç şäheri";


                // Mary welaýaty


                var bayramalyŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                bayramalyŞ.Region = regionMR;
                bayramalyŞ.CityType = CityTypeEnum.Şäher;
                bayramalyŞ.ŞäherEtrapL = "Baýramaly şäheri";



                var wekilbazarE = ObjectSpace.CreateObject<IŞäherEtrap>();
                wekilbazarE.Region = regionMR;
                wekilbazarE.CityType = CityTypeEnum.Etrap;
                wekilbazarE.ŞäherEtrapL = "Wekilbazar etraby";



                var ýolötenE = ObjectSpace.CreateObject<IŞäherEtrap>();
                ýolötenE.Region = regionMR;
                ýolötenE.CityType = CityTypeEnum.Etrap;
                ýolötenE.ŞäherEtrapL = "Ýolöten etraby";

                var ýolötenŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                ýolötenŞ.Region = regionMR;
                ýolötenŞ.CityType = CityTypeEnum.Şäher;
                ýolötenŞ.ŞäherEtrapL = "Ýolöten şäheri";

                var garagumE = ObjectSpace.CreateObject<IŞäherEtrap>();
                garagumE.Region = regionMR;
                garagumE.CityType = CityTypeEnum.Etrap;
                garagumE.ŞäherEtrapL = "Garagum etraby";



                var serhetAbatŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                serhetAbatŞ.Region = regionMR;
                serhetAbatŞ.CityType = CityTypeEnum.Şäher;
                serhetAbatŞ.ŞäherEtrapL = "Serhetabat şäheri";

                var serhetAbatE = ObjectSpace.CreateObject<IŞäherEtrap>();
                serhetAbatE.Region = regionMR;
                serhetAbatE.CityType = CityTypeEnum.Etrap;
                serhetAbatE.ŞäherEtrapL = "Serhetabat etraby";

                var maryE = ObjectSpace.CreateObject<IŞäherEtrap>();
                maryE.Region = regionMR;
                maryE.CityType = CityTypeEnum.Etrap;
                maryE.ŞäherEtrapL = "Mary etraby";



                var murgapE = ObjectSpace.CreateObject<IŞäherEtrap>();
                murgapE.Region = regionMR;
                murgapE.CityType = CityTypeEnum.Etrap;
                murgapE.ŞäherEtrapL = "Murgap etraby";



                var oguzhanE = ObjectSpace.CreateObject<IŞäherEtrap>();
                oguzhanE.Region = regionMR;
                oguzhanE.CityType = CityTypeEnum.Etrap;
                oguzhanE.ŞäherEtrapL = "Oguzhan etraby";



                var şatlykŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                şatlykŞ.Region = regionMR;
                şatlykŞ.CityType = CityTypeEnum.Şäher;
                şatlykŞ.ŞäherEtrapL = "Şatlyk şäheri";



                var sakarçägeE = ObjectSpace.CreateObject<IŞäherEtrap>();
                sakarçägeE.Region = regionMR;
                sakarçägeE.CityType = CityTypeEnum.Etrap;
                sakarçägeE.ŞäherEtrapL = "Sakarçäge etraby";



                var tagtabazarE = ObjectSpace.CreateObject<IŞäherEtrap>();
                tagtabazarE.Region = regionMR;
                tagtabazarE.CityType = CityTypeEnum.Etrap;
                tagtabazarE.ŞäherEtrapL = "Tagtabazar etraby";



                var turkmengalaE = ObjectSpace.CreateObject<IŞäherEtrap>();
                turkmengalaE.Region = regionMR;
                turkmengalaE.CityType = CityTypeEnum.Etrap;
                turkmengalaE.ŞäherEtrapL = "Türkmengala etraby";



                var altynSähraE = ObjectSpace.CreateObject<IŞäherEtrap>();
                altynSähraE.Region = regionMR;
                altynSähraE.CityType = CityTypeEnum.Etrap;
                altynSähraE.ŞäherEtrapL = "Altyn sähra etraby";




                var maryŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                maryŞ.Region = regionMR;
                maryŞ.CityType = CityTypeEnum.Şäher;
                maryŞ.ŞäherEtrapL = "Mary şäheri";




                var baýramalyE = ObjectSpace.CreateObject<IŞäherEtrap>();
                baýramalyE.Region = regionMR;
                baýramalyE.CityType = CityTypeEnum.Etrap;
                baýramalyE.ŞäherEtrapL = "Baýramaly etraby";


                //Lebap welaýaty

                var birataE = ObjectSpace.CreateObject<IŞäherEtrap>();
                birataE.Region = regionLB;
                birataE.CityType = CityTypeEnum.Etrap;
                birataE.ŞäherEtrapL = "Birata etraby";




                var gazojakŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                gazojakŞ.Region = regionLB;
                gazojakŞ.CityType = CityTypeEnum.Şäher;
                gazojakŞ.ŞäherEtrapL = "Gazojak şäheri";


                var garaşsyzlykE = ObjectSpace.CreateObject<IŞäherEtrap>();
                garaşsyzlykE.Region = regionLB;
                garaşsyzlykE.CityType = CityTypeEnum.Etrap;
                garaşsyzlykE.ŞäherEtrapL = "Garaşsyzlyk etraby";


                var galkynyşE = ObjectSpace.CreateObject<IŞäherEtrap>();
                galkynyşE.Region = regionLB;
                galkynyşE.CityType = CityTypeEnum.Etrap;
                galkynyşE.ŞäherEtrapL = "Galkynyş etraby";


                var garabekewülE = ObjectSpace.CreateObject<IŞäherEtrap>();
                garabekewülE.Region = regionLB;
                garabekewülE.CityType = CityTypeEnum.Etrap;
                garabekewülE.ŞäherEtrapL = "Garabekewül etraby";


                var atamyratE = ObjectSpace.CreateObject<IŞäherEtrap>();
                atamyratE.Region = regionLB;
                atamyratE.CityType = CityTypeEnum.Etrap;
                atamyratE.ŞäherEtrapL = "Atamyrat etraby";



                var atamyratŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                atamyratŞ.Region = regionLB;
                atamyratŞ.CityType = CityTypeEnum.Şäher;
                atamyratŞ.ŞäherEtrapL = "Atamyrat şäheri";



                var sakarE = ObjectSpace.CreateObject<IŞäherEtrap>();
                sakarE.Region = regionLB;
                sakarE.CityType = CityTypeEnum.Etrap;
                sakarE.ŞäherEtrapL = "Sakar etraby";



                var saýatE = ObjectSpace.CreateObject<IŞäherEtrap>();
                saýatE.Region = regionLB;
                saýatE.CityType = CityTypeEnum.Etrap;
                saýatE.ŞäherEtrapL = "Saýat etraby";



                var farapE = ObjectSpace.CreateObject<IŞäherEtrap>();
                farapE.Region = regionLB;
                farapE.CityType = CityTypeEnum.Etrap;
                farapE.ŞäherEtrapL = "Farap etraby";



                var halaçE = ObjectSpace.CreateObject<IŞäherEtrap>();
                halaçE.Region = regionLB;
                halaçE.CityType = CityTypeEnum.Etrap;
                halaçE.ŞäherEtrapL = "Halaç etraby";



                var hojambazE = ObjectSpace.CreateObject<IŞäherEtrap>();
                hojambazE.Region = regionLB;
                hojambazE.CityType = CityTypeEnum.Etrap;
                hojambazE.ŞäherEtrapL = "Hojambaz etraby";



                var serdarabatE = ObjectSpace.CreateObject<IŞäherEtrap>();
                serdarabatE.Region = regionLB;
                serdarabatE.CityType = CityTypeEnum.Etrap;
                serdarabatE.ŞäherEtrapL = "Serdarabat etraby";



                var köýtendagE = ObjectSpace.CreateObject<IŞäherEtrap>();
                köýtendagE.Region = regionLB;
                köýtendagE.CityType = CityTypeEnum.Etrap;
                köýtendagE.ŞäherEtrapL = "Köýtendag etraby";



                var beýikSTAE = ObjectSpace.CreateObject<IŞäherEtrap>();
                beýikSTAE.Region = regionLB;
                beýikSTAE.CityType = CityTypeEnum.Etrap;
                beýikSTAE.ŞäherEtrapL = "Beýik Saparmyrat Türkmenbaşy ad. etraby";



                var döwletliE = ObjectSpace.CreateObject<IŞäherEtrap>();
                döwletliE.Region = regionLB;
                döwletliE.CityType = CityTypeEnum.Etrap;
                döwletliE.ŞäherEtrapL = "Döwletli etraby";



                var seýdiŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                seýdiŞ.Region = regionLB;
                seýdiŞ.CityType = CityTypeEnum.Şäher;
                seýdiŞ.ŞäherEtrapL = "Seýdi şäheri";



                var magdanlyŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                magdanlyŞ.Region = regionLB;
                magdanlyŞ.CityType = CityTypeEnum.Şäher;
                magdanlyŞ.ŞäherEtrapL = "Magdanly şäheri";



                var TürkmenbatŞ = ObjectSpace.CreateObject<IŞäherEtrap>();
                TürkmenbatŞ.Region = regionLB;
                TürkmenbatŞ.CityType = CityTypeEnum.Şäher;
                TürkmenbatŞ.ŞäherEtrapL = "Türkmenabat şäheri";



                var ANE = ObjectSpace.CreateObject<IŞäherEtrap>();
                ANE.Region = regionLB;
                ANE.CityType = CityTypeEnum.Etrap;
                ANE.ŞäherEtrapL = "Türkmenistanyň Gahrymany Atamyrat Nyýazow etraby";



                var tGGEE = ObjectSpace.CreateObject<IŞäherEtrap>();
                tGGEE.Region = regionLB;
                tGGEE.CityType = CityTypeEnum.Etrap;
                tGGEE.ŞäherEtrapL = "Türkmenistanyň Gahrymany Gurbansoltan eje etraby";



                #endregion

                #region PassportType


                var passportTypeAD = ObjectSpace.CreateObject<IPassportType>();
                passportTypeAD.TypeOfPassport = PassportTypeEnum.Ordinary;
                passportTypeAD.TypeOfPassportL = "AD";










                var passportTypeGL = ObjectSpace.CreateObject<IPassportType>();
                passportTypeGL.TypeOfPassport = PassportTypeEnum.Service;
                passportTypeGL.TypeOfPassportL = "GL";


                var passportTypeDP = ObjectSpace.CreateObject<IPassportType>();
                passportTypeDP.TypeOfPassport = PassportTypeEnum.Diplomatic;
                passportTypeDP.TypeOfPassportL = "DP";




                #endregion


                #region Department


                var department = ObjectSpace.CreateObject<IDepartment>();
                department.TitleOfDepartment = "Office";








                #endregion


                #region Position


                var position = ObjectSpace.CreateObject<IPosition>();
                position.TitleOfPosition = "Superwizer";
                position.Code = "100";

                // Andrew Fuller

                var positionAndrewFuller = ObjectSpace.CreateObject<IPosition>();
                positionAndrewFuller.Code = "005";
                positionAndrewFuller.TitleOfPosition = "Proýekt bölüminiň başlygy";







                #endregion



                #region Document Of Address




                var documentOfAddressPatent = ObjectSpace.CreateObject<IDocumentOfAddress>();
                documentOfAddressPatent.TypeOfDocument = "Patent";







                var documentOfAddressLojman = ObjectSpace.CreateObject<IDocumentOfAddress>();
                documentOfAddressLojman.TypeOfDocument = "Lojman";





                #endregion


                #region Address



                var address = ObjectSpace.CreateObject<IAddresses>();
                address.ŞäherEtrap = cityAS;
                address.DocumentOfAddress = documentOfAddressPatent;
                address.ExpiringDateOfAddressDocument = new DateTime(2012, 04, 04);
                address.Region = regionAS;
                address.AddressLine = "Tegeran 10";



                var address1 = ObjectSpace.CreateObject<IAddresses>();
                address1.ŞäherEtrap = cityAS;
                address1.DocumentOfAddress = documentOfAddressPatent;
                address1.ExpiringDateOfAddressDocument = new DateTime(2012, 04, 04);
                address1.Region = regionAS;
                address1.AddressLine = "Görogly 24";

                // Ander Fuller 
                var addressOfAndrewFuller = ObjectSpace.CreateObject<IAddresses>();
                addressOfAndrewFuller.ŞäherEtrap = cityAS;
                addressOfAndrewFuller.DocumentOfAddress = documentOfAddressPatent;
                addressOfAndrewFuller.ExpiringDateOfAddressDocument = new DateTime(2013, 08, 01);
                addressOfAndrewFuller.Region = regionAS;
                addressOfAndrewFuller.AddressLine = "Türkmenbaşy Şaýoly 145 AF";
                // Ander Fuller 
                var addressOfResidAndrewFuller = ObjectSpace.CreateObject<IAddressOfResidence>();
                addressOfResidAndrewFuller.Address = addressOfAndrewFuller;
                addressOfResidAndrewFuller.StartDateOfResidence = new DateTime(2013, 01, 01);

                // Janet Levering

                var addressOfJanet = ObjectSpace.CreateObject<IAddresses>();
                addressOfJanet.ŞäherEtrap = cityAS;
                addressOfJanet.DocumentOfAddress = documentOfAddressPatent;
                addressOfJanet.ExpiringDateOfAddressDocument = new DateTime(2013, 08, 01);
                addressOfJanet.Region = regionAS;
                addressOfJanet.AddressLine = "Address Of Janet Levering";

                var addressOfResJanet = ObjectSpace.CreateObject<IAddressOfResidence>();
                addressOfResJanet.Address = addressOfJanet;
                addressOfResJanet.StartDateOfResidence = new DateTime(2013, 02, 01);


                #endregion


                #region AddressOfResidence
                var addressOfResidence = ObjectSpace.CreateObject<IAddressOfResidence>();
                addressOfResidence.Address = address;
                addressOfResidence.StartDateOfResidence = new DateTime(2012, 01, 01);

                var addressOfResidence1 = ObjectSpace.CreateObject<IAddressOfResidence>();
                addressOfResidence1.Address = address1;
                addressOfResidence1.StartDateOfResidence = new DateTime(2012, 01, 01);


                #endregion


                #region AddressOnBusinessTrip


                #endregion


                #region  SigningPerson






                var signingPerson = ObjectSpace.CreateObject<IEmployee>();
                signingPerson.FirstName = "Ömer";
                signingPerson.LastName = "Mehmet";
                signingPerson.BirthDate = new DateTime(1900, 01, 01);
                signingPerson.ForeignAddress = "Ankara";
                signingPerson.ForeignAddressCountry = countryTUR;
                signingPerson.BirthPlace = "Ankara";
                signingPerson.BirthCountry = countryTUR;
                signingPerson.Gender = genderE;
                signingPerson.MaritalStatus = maritalStatusÖýlenen;
                signingPerson.IsEmployee = true;
                signingPerson.AddressOfResidences.Add(addressOfResidence);

                company.DocSigningPerson = signingPerson;






                #endregion


                #region Relation

                var relationAyaly = ObjectSpace.CreateObject<IRelation>();
                relationAyaly.RelativeAs = RelationEnum.Aýaly;
                relationAyaly.RelativeAsL = "aýaly";
                relationAyaly.Gender = genderA;
                relationAyaly.EndingLI = "na";
                relationAyaly.EndingLV = "nyň";


                var relationOgly = ObjectSpace.CreateObject<IRelation>();
                relationOgly.RelativeAs = RelationEnum.Ogly;
                relationOgly.RelativeAsL = "ogly";
                relationOgly.Gender = genderE;
                //    relationOgly.RelativeAsR = "сын";
                relationOgly.EndingLI = "na";
                relationOgly.EndingLV = "nyň";
                //    relationOgly.EndingRI = "ну";
                //    relationOgly.EndingRV = "на";
                //  relationOgly.EmployeeAs = RelationEnum.Kakasy;
                //  relationOgly.EmployeeGender=genderE;
                //  relationOgly.EmployeeAsL = "kakasy";
                //  relationOgly.EmployeeAsR = "отц";
                //    relationOgly.EndingELI = "nyň";
                //    relationOgly.EndingELV = "nyň";
                //  relationOgly.EndingERI = "a";
                // relationOgly.EndingERV = "a";






                var relationGyzyE = ObjectSpace.CreateObject<IRelation>();
                relationGyzyE.RelativeAs = RelationEnum.Gyzy;
                relationGyzyE.RelativeAsL = "gyzy";
                relationGyzyE.Gender = genderA;
                relationGyzyE.EndingLI = "na";
                relationGyzyE.EndingLV = "nyň";



                var relationAdamsy = ObjectSpace.CreateObject<IRelation>();
                relationAdamsy.RelativeAs = RelationEnum.Adamsy;
                relationAdamsy.RelativeAsL = "adamsy";
                relationAdamsy.Gender = genderE;
                relationAdamsy.EndingLI = "na";
                relationAdamsy.EndingLV = "nyň";



                var relationEjesi = ObjectSpace.CreateObject<IRelation>();
                relationEjesi.RelativeAs = RelationEnum.Ejesi;
                relationEjesi.RelativeAsL = "ejesi";
                relationEjesi.Gender = genderA;
                relationEjesi.EndingLI = "ne";
                relationEjesi.EndingLV = "niň";

                var relationKakasy = ObjectSpace.CreateObject<IRelation>();
                relationKakasy.RelativeAs = RelationEnum.Kakasy;
                relationKakasy.RelativeAsL = "kakasy";
                relationKakasy.Gender = genderE;
                relationKakasy.EndingLI = "na";
                relationKakasy.EndingLV = "nyň";










                #endregion


                #region Passport

                // Passport Andrew Fuller
                var passportAndrewFuller = ObjectSpace.CreateObject<IPassport>();
                passportAndrewFuller.PassportNumber = "AF000000000";
                passportAndrewFuller.PassportIssuedPlace = "Californiýa";
                passportAndrewFuller.PassportIssuedDate = new DateTime(2012, 10, 24);
                passportAndrewFuller.PassportIssuedCountry = countryTUR;
                passportAndrewFuller.PassportExpiringDate = new DateTime(2015, 01, 01);
                passportAndrewFuller.PassportType = passportTypeAD;
                passportAndrewFuller.Citizenship = countryUSA;
                passportAndrewFuller.PersonalNumber = "0000000PNAF";


                // Signing Person

                var passporSigningPerson = ObjectSpace.CreateObject<IPassport>();
                passporSigningPerson.PassportNumber = "SP000000000";
                passporSigningPerson.PassportIssuedPlace = "Ankara";
                passporSigningPerson.PassportIssuedDate = new DateTime(2012, 10, 24);
                passporSigningPerson.PassportIssuedCountry = countryTUR;
                passporSigningPerson.PassportExpiringDate = new DateTime(2015, 01, 01);
                passporSigningPerson.PassportType = passportTypeAD;
                passporSigningPerson.Citizenship = countryTUR;
                passporSigningPerson.PersonalNumber = "0000000PSP";
                passporSigningPerson.Person = signingPerson;

                // Passport Janet Levering

                var passportJanet = ObjectSpace.CreateObject<IPassport>();
                passportJanet.PassportNumber = "JL000000000";
                passportJanet.PassportIssuedPlace = "CaliforniýaJL";
                passportJanet.PassportIssuedDate = new DateTime(2012, 10, 24);
                passportJanet.PassportIssuedCountry = countryTUR;
                passportJanet.PassportExpiringDate = new DateTime(2015, 01, 01);
                passportJanet.PassportType = passportTypeAD;
                passportJanet.Citizenship = countryUSA;
                passportJanet.PersonalNumber = "0000000PNJL";








                #endregion


                #region Visa

                //Andrew Fuller
                var visaAndrewFuller = ObjectSpace.CreateObject<IVisa>();
                visaAndrewFuller.VisaNumber = "AFV0000000";
                visaAndrewFuller.VisaType = visaTypeBS;
                visaAndrewFuller.VisaCategory = visaCategoryBirgezeklik;
                visaAndrewFuller.VisaIssuedDate = new DateTime(2013, 01, 01);
                visaAndrewFuller.VisaStartDate = new DateTime(2013, 01, 01);
                visaAndrewFuller.VisaEndDate = new DateTime(2013, 06, 30);
                visaAndrewFuller.VisaIssuedPlace = visaIssuedPlaceASAP;
                visaAndrewFuller.Passport = passportAndrewFuller;
                visaAndrewFuller.ASNumber = "AS-0001";
                // Janet Leverig

                var visaJanet = ObjectSpace.CreateObject<IVisa>();
                visaJanet.VisaNumber = "JLV0000000";
                visaJanet.VisaType = visaTypeBS;
                visaJanet.VisaCategory = visaCategoryBirgezeklik;
                visaJanet.VisaIssuedDate = new DateTime(2013, 01, 01);
                visaJanet.VisaStartDate = new DateTime(2013, 01, 01);
                visaJanet.VisaEndDate = new DateTime(2013, 06, 30);
                visaJanet.VisaIssuedPlace = visaIssuedPlaceASAP;
                visaJanet.Passport = passportJanet;
                visaJanet.ASNumber = "AS-0002";
                #endregion


                #region WorkHistory



                var workHistory = ObjectSpace.CreateObject<IWorkHistory>();
                workHistory.Department = department;
                workHistory.StartDateOnThisPosition = new DateTime(2012, 01, 01);
                workHistory.Position = position;
                workHistory.Department = department;
                workHistory.Employee = signingPerson;







                #endregion


                #region Plural

                //ИМ  кто что
                // РП кого чего
                // ДП кому чему
                // ВП кого что
                // ТП с кем с чем
                // ПП о ком о чем


                var plural1 = ObjectSpace.CreateObject<IPlural>();
                plural1.Plural1 = "olar";
                plural1.Single1 = "oňa";
                plural1.Plural2 = "daşary ýurt raýatlary";
                plural1.Single2 = "daşary ýurt raýaty";
                plural1.Plural3 = "wizasy";
                plural1.Single3 = "wizalary";
                plural1.id = 1;

                // DYR


                // ДП м.ч.
                plural1.DYR_ДП_PL_rus = "иностранным гражданам";
                plural1.DYR_ДП_PL_tkm = "daşary ýurt raýatlaryna";

                plural1.DYR_РП_PL_rus = "иностранных граждан";
                plural1.DYR_РП_РL_tkm = "daşary ýurt raýatlarynyň";


                plural1.DYR_РП_rus = "иностранного гражданина";
                plural1.DYR_РП_tkm = "daşary ýurt raýatynyň";
                // ДП е.ч.
                plural1.DYR_ДП_rus = "иностранному гражданину";
                plural1.DYR_ДП_tkm = "daşary ýurt raýatyna";

                // ВП м.ч.
                plural1.DYR_ВП_PL_rus = "иностранных граждан";
                plural1.DYR_ВП_PL_tkm = "daşary ýurt raýatlaryny";

                // ВП е.ч.
                plural1.DYR_ВП_rus = "иностранного гражданина";
                plural1.DYR_ВП_tkm = "daşary ýurt raýatyny";



                // FamilyMember


                // ДП м.ч.
                plural1.FM_ДП_PL_rus = "членам семъи";
                plural1.FM_ДП_PL_tkm = "maşgala agzalarynyň";

                // ДП е.ч.
                plural1.FM_ДП_rus = "члену семъи";
                plural1.FM_ДП_tkm = "maşgala agzasynyň";

                // ВП м.ч.
                plural1.FM_ВП_PL_rus = "членов семъи";
                plural1.FM_ВП_PL_tkm = "maşgala agzalaryny";

                // ВП е.ч.
                plural1.FM_ВП_rus = "члена семъи";
                plural1.FM_ВП_tkm = "maşgala agzasyny";


                // Wiza tkm
                plural1.Wiza_ВП_PL_tkm = "wizalarynyň we hasaba alyş möhletiniň";
                plural1.Wiza_ВП_tkm = "wizasynyň we hasaba alyş möhletiniň";
                plural1.WizaAndWorkPermit_ВП_PL_tkm = "wizalarynyň, iş rugsatnamalarynyň we hasaba alyş möhletiniň";
                plural1.WizaAndWorkPermit_ВП_tkm = "wizasynyň, iş rugsatnamasynyň we hasaba alyş möhletiniň";

                //Wiza РП

                plural1.Wiza_РП_PL_tkm = "wizalaryny we hasaba alyş möhletini";
                plural1.Wiza_РП_tkm = "wizasyny we hasaba alyş möhletini";


                // Wiza rus

                plural1.Wiza_ВП_PL_rus = "визу";
                plural1.Wiza_ВП_rus = "визу";
                plural1.WizaAndWorkPermit_ВП_PL_rus = "визу и трудовые разрешения";
                plural1.WizaAndWorkPermit_ВП_rus = "визу и трудовое рзрешение";


                // Çakylyk tkm

                plural1.Invitation_ВП_PL_tkm = "çakylyk";
                plural1.Invitation_ВП_tkm = "çakylyk ";
                plural1.InvitationAndWorkPermit_ВП_PL_tkm = "çakylyk we iş rugsatnamalarynyň";
                plural1.InvitationAndWorkPermit_ВП_tkm = "çakylyk we iş rugsatnamasynyň";

                // Çakylyk rus

                plural1.Invitation_ВП_PL_rus = "приглашение";
                plural1.Invitation_ВП_rus = "приглашение";
                plural1.InvitationAndWorkPermit_ВП_PL_rus = "приглашение и трудовые разрешения";
                plural1.InvitationAndWorkPermit_ВП_rus = "приглашение и трудовые разрешения";

                // Border Zone

                plural1.BorderZone_ВП_PL_rus = "посещение в пограничные зоны";
                plural1.BorderZone_ВП_rus = "посещение в пограничную зону";
                plural1.BorderZone_ВП_tkm = "serhet ýakasyna barmaga";
                plural1.BorderZone_ВП_PL_tkm = "serhet ýakalaryna barmaga";

                // Rugsat berilmegini
                plural1.RugsatBermek_bir_tkm = "rugsat bermegiňizi";
                plural1.RugsatBermek_iki_tkm = "rugsat berilmegine";
                #endregion


                #region Specialty




                var speciGi = ObjectSpace.CreateObject<ISpeciality>();
                speciGi.TitleOfSpeciality = "Gurluşyk inženeri";

                var ortaBilim = ObjectSpace.CreateObject<ISpeciality>();

                ortaBilim.TitleOfSpeciality = "Orta bilim";

                //Andrew Fuller

                var specialtyAndrewFuller = ObjectSpace.CreateObject<ISpeciality>();
                specialtyAndrewFuller.TitleOfSpeciality = "Arhitektor";

                // Janet Levering

                var specOfJanet = ObjectSpace.CreateObject<ISpeciality>();
                specOfJanet.TitleOfSpeciality = "SpecialtyOfJanet";

                #endregion


                #region Purpose Of Travel

                var purposeOfravelWork = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelWork.TravelPurpose = TravelPurposeEn.Work;
                purposeOfravelWork.PurposeOfTravelL = "Işlemek üçin";


                var purposeOfravelBTrip = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelBTrip.TravelPurpose = TravelPurposeEn.BusinessTrip;
                purposeOfravelBTrip.PurposeOfTravelL = "Iş saparyna";

                var purposeOfravelFM = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelFM.TravelPurpose = TravelPurposeEn.FamilyMember;
                purposeOfravelFM.PurposeOfTravelL = "Maşgala agzasy";

                var purposeOfravelVaçation = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelVaçation.TravelPurpose = TravelPurposeEn.Vacation;
                purposeOfravelVaçation.PurposeOfTravelL = "Dynç almak üçin";

                var purposeOfravelVisit = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelVisit.TravelPurpose = TravelPurposeEn.Visit;
                purposeOfravelVisit.PurposeOfTravelL = "Myhmançylygy";

                var purposeOfravelQuit = ObjectSpace.CreateObject<PurposeOfTravel>();
                purposeOfravelQuit.TravelPurpose = TravelPurposeEn.Quit;
                purposeOfravelQuit.PurposeOfTravelL = "Işden çykmagy";
                #endregion

                #region Travel Infor

                // Andrew Fuller
                var travelInforAndrewFuller = ObjectSpace.CreateObject<ITravelInformation>();
                travelInforAndrewFuller.CheckPoint = checkpointAşgabatŞäherHowaMenzilindäkiMGP;
                travelInforAndrewFuller.PurposeOfTravel = purposeOfravelWork;
                travelInforAndrewFuller.TravelDate = new DateTime(2013, 01, 01);
                travelInforAndrewFuller.TravelType = TravelTypeEnum.Entry;

                // Janet Levering

                var travelInforJanet = ObjectSpace.CreateObject<ITravelInformation>();
                travelInforJanet.CheckPoint = checkpointAşgabatŞäherHowaMenzilindäkiMGP;
                travelInforJanet.PurposeOfTravel = purposeOfravelFM;
                travelInforJanet.TravelDate = new DateTime(2013, 01, 01);
                travelInforJanet.TravelType = TravelTypeEnum.Entry;


                #endregion


                #region Education Level




                var educationLevelOrta = ObjectSpace.CreateObject<IEducationLevel>();
                educationLevelOrta.TitleOfEducationLevel = "Orta";





                var educationLevelÝöriteOrta = ObjectSpace.CreateObject<IEducationLevel>();
                educationLevelÝöriteOrta.TitleOfEducationLevel = "Ýörite Orta";





                var educationLevelYokary = ObjectSpace.CreateObject<IEducationLevel>();
                educationLevelYokary.TitleOfEducationLevel = "Ýokary";





                #endregion


               



            
           


       


        












           //end COMPANY


         
 
          


            } // End Company









           
            

        }//end of UpdateDatabaseAfterUpdateSchema()

           

        #endregion// end of UpdateDatabaseAfterUpdateSchema()

        private SecuritySystemRole GetConfiguratorRole()
        {
            SecuritySystemRole configuratorRole = ObjectSpace.FindObject<SecuritySystemRole>(
            new BinaryOperator("Name", DatabaseUserSettingsModule.ConfiguratorRoleName));
            if (configuratorRole == null)
            {
                configuratorRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                configuratorRole.Name = DatabaseUserSettingsModule.ConfiguratorRoleName;
                configuratorRole.ChildRoles.Add(GetConfiguratorRole());
                SecuritySystemTypePermissionObject userSettingsAspectPermissions =
                    ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                userSettingsAspectPermissions.TargetType = typeof(XPUserSettingsAspect);
                userSettingsAspectPermissions.AllowCreate = true;
                userSettingsAspectPermissions.AllowDelete = true;
                userSettingsAspectPermissions.AllowNavigate = true;
                userSettingsAspectPermissions.AllowRead = true;
                userSettingsAspectPermissions.AllowWrite = true;
                configuratorRole.TypePermissions.Add(userSettingsAspectPermissions);
                SecuritySystemTypePermissionObject userSettingsPermissions =
                    ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                userSettingsPermissions.TargetType = typeof(XPUserSettings);
                userSettingsPermissions.AllowCreate = true;
                userSettingsPermissions.AllowDelete = true;
                userSettingsPermissions.AllowNavigate = true;
                userSettingsPermissions.AllowRead = true;
                userSettingsPermissions.AllowWrite = true;
                configuratorRole.TypePermissions.Add(userSettingsPermissions);
                SecuritySystemTypePermissionObject userPermissions =
                    ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
                userPermissions.TargetType = typeof(SecuritySystemUser);
                configuratorRole.TypePermissions.Add(userPermissions);
                SecuritySystemMemberPermissionsObject userNamePermission =
                    ObjectSpace.CreateObject<SecuritySystemMemberPermissionsObject>();
                userNamePermission.Members = "UserName";
                userNamePermission.AllowRead = true;
                userPermissions.MemberPermissions.Add(userNamePermission);
                configuratorRole.Save();
            }
            return configuratorRole;

        }


    }
}

