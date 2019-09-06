*Action New(Long Process Application)
*Action IApplication
*FillForm
 Base Application Type = Invitation
 Application Type For Employee = Application for sevice pasport
 Applied Ministery = TDSSGM
 Contract = 000003
 Choose Border Zone Type = Border zone for application
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Farap = True
 Garabogaz = True
 Ýolöten = True

*Action Save and Close
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Serdar Aşyrow
 Address = Çandybil etraby;Tegeran 10
*Sleep 100
*Action Save and Close
*Sleep 100
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 04_1_AppInvit_SP_Emp.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Serdar Aşyrow

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot EmpInAppInvit_SP_Emp.png