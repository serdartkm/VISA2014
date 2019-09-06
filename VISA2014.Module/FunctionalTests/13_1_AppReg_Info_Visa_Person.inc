
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Registration
 Application Type For Family Member = Application for chaging information
 Department For Registration = TDMGAH
 Change Information = Visa category
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa
*Action Save and Close

*Action Save
*Sleep 300

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot 13_1_AppReg_Info_Visa_Person.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot FMInAppReg_Info_Passport_Person.png
*Action Save and Close
