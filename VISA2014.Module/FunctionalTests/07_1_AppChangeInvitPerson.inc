
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Invitation
 Application Type For Family Member = Application for changing invitation
 Invitation To Be Changed = ASGH-1487
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa
 Address = Çandybil etraby;Görogly 24

*Action Save and Close
*Sleep 100
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 07_1_AppChangeInvitFM.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot PersonInAppChangingInvit.png