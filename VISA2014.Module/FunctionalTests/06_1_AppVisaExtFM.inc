*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Family Member = True
 Base Application Type = Visa
 Application Type For Family Member = Application for visa extention
 Visa Category = Köp gezeklik
 Visa Period = 6 aý
 Choose Border Zone Type = Border zone for application
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Garabogaz = True
 Ýolöten = True

*Action Save and Close
*Sleep 100
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Family Member = Jeren Meredowa
*Sleep 100
*Action Save and Close
*Sleep 100
*Action Save

*Action Show in Report
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot 06_1_AppVisaExtFM.png
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Jeren Meredowa

*Action Person In Application.Show in Report(PersonInApplication)
*Sleep 100
*SetActiveWindowSize 1200x900
*CompareScreenshot FMInAppVisaExt.png
*Action Navigation(Application.SimpleProcessApplication)
*ProcessRecord 
 Registration Number = 4/-8
*Action State
*FillForm
 Process Date = 18.04.2013
 Process Number = AS-000001
*Action Save and Close