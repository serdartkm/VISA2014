
*Action New(Long Process Application)
*Action IApplication
*FillForm
 Base Application Type = Border zone
 Application Type For Employee = Application for border zone permision
 Applied Ministery = TIIM
 Contract = 000001
 Border Zone Period = 6 aý
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Farap = True
 Garabogaz = True
 Sarahs = True
*Action Save and Close
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Serdar Aşyrow

*Action Save and Close
*Sleep 100
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 03_1_AppBorderZonePermitEmp.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Serdar Aşyrow

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot EmpInAppBorderZonePermitEmp.png