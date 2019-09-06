
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Visa
 Application Type For Family Member = Application for changing visa category
 Preffered Visa Category = Multy to once
*Action LayoutTab.Person In Application
*Sleep 100
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa

*Action Save and Close
*Sleep 100
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 08_1_AppVisaCatChange_Person.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot FMInAppVisaCatChange_Person.png
*Action Close
