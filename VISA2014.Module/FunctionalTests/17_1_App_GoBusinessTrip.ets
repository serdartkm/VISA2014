
;#DropDB VISA2014EasyTest
#Application VISA2014Win

*Action Log On
*Action Navigation(Application.SimpleProcessApplication)
*Action New(Simple Process Application)
*Action IApplication
*FillForm
 For Employee = True
 Base Application Type = Others
 Application Type For Employee = Application for go business trip
 Department For Registration = TDMG
*ExecuteEditorAction Business Trip Destination
*Action Filter by Text()
*ProcessRecord Şäher Etrap
 Şäher Etrap L = Ýolöten şäheri
*FillForm
 Date Of Departure = 01.04.2013
 Duration Of Stay = 10
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Andrew Fuller
*ExecuteEditorAction Address On Business Trip
*Action New
*FillForm
 Address On Trip = Çandybil etraby;Address Of Janet Levering
*Action Save and Close
*Action Save and Close
*Action Save
*Action Show in Report
*SelectRecords Person In Application
 Columns = Applied Person
 Row = Andrew Fuller
*Action Person In Application.Show in Report(PersonInApplication)
