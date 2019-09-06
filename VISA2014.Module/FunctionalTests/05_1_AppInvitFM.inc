
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Invitation
 Application Type For Family Member = Application for invitation
 Visa Category = Köp gezeklik
 Visa Period = 6 aý
 Choose Border Zone Type = Border zone for application
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Farap = True
 Garabogaz = True

*Action Save and Close
*Sleep 300
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa
 Address = Çandybil etraby;Görogly 24
*Sleep 100
*Action Save and Close
*Action Save
*Sleep 100

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x1900
*CompareScreenshot 05_1_AppInvitFM.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x1900

*Action Navigation(Application.SimpleProcessApplication)
*ProcessRecord 
 Registration Number = 4/-7
*Action State
*FillForm
 Process Date = 01.04.2013
 Process Number = AS-001
*Action Save and Close
*CompareScreenshot FMInAppInvit.png