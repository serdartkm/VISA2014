*Action New(Long Process Application)
*Action IApplication
*FillForm
 Base Application Type = Visa
 Application Type For Employee = Application for visa extention
 Applied Ministery = TDIM
 Contract = 000002
 Visa Period = 6 aý
 Visa Category = Köp gezeklik
 Is Wiza With Work Permit = Wiza and work permit
*Sleep 300
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Serdar Aşyrow

*Action Save and Close
*Sleep 300
*Action Save


*Action Show in Report
*Sleep 1000
*SetActiveWindowSize 1200x900
*CompareScreenshot 02_1_AppVisaExtentionEmp.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Serdar Aşyrow
*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot EmpInAppVisaExtention.png
