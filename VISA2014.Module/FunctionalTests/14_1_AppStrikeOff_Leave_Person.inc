
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Registration
 Application Type For Family Member = Application for strike off register
 Department For Registration = TDMG
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa

*Action Save and Close
*Sleep 300
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot 14_1_AppStrikeOff_Leave_Person.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot FMInAppStrikeOff_Leave_Person.png
*Action Save and Close
