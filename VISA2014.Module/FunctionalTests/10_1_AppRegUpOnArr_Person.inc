
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Registration
 Application Type For Family Member = Application for registration up on arrival
 Department For Registration = TDMG
*Sleep 300
*Action LayoutTab.Person In Application

*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa

*Action Save and Close
*Action Save
*Sleep 100

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 10_1_AppRegUpOnArr_Person.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot FMInAppRegUpOnArr_Person.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(Form16)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot Form16_FM.png
*Action Save and Close
