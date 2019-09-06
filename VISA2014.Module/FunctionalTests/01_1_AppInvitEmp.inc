*Action Navigation(Application.LongProcessApplication)
*Action New(Long Process Application)
*Action IApplication
*FillForm
 Base Application Type = Invitation
 Application Type For Employee = Application for invitation
 Applied Ministery = TDIM
 Contract = 000002
 Visa Period = 6 aý
 Visa Category = Köp gezeklik
 Is Invitation With Work Permit = Invitation and work permit
 Choose Border Zone Type = Border zone for application
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Daşoguz = True
 Tagtabazar = True
 Serhetabat = True
 Ýolöten = True
*Action Save and Close
*Sleep 200
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Serdar Aşyrow
 Address = Çandybil etraby;Görogly 24
*Action Save and Close
*Sleep 200
*Action Save
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Serdar Aşyrow

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot EmpInAppInvit.png
*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x1200
*CompareScreenshot 01_1_AppInvitEmp.png
*Action Save and Close



