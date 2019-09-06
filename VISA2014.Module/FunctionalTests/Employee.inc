
#DropDB VISA2014EasyTest
#Application VISA2014.Win
*Action Log On
*Action Navigation(Employee.Employee)
*Action New(Employee)
*FillForm
 First Name = Serdar
 Last Name = Aşyrow
 Middle Name = Ýazmyradowiç
 Gender = Erkek
 Birth Date = 26.10.1977
*ExecuteEditorAction Birth Country
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Birth Place = Moskwa
*ExecuteEditorAction Foreign Address Country
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Foreign Address = Moskwa, selo şewçenko
 Marital Status = Öýlenen
 Contract = 000001
 Wage = 5000
#IncludeFile Passport.inc
#IncludeFile Education.inc
#IncludeFile WorkHistory.inc
#IncludeFile AddressOfResidence.inc
*Action Save and Close
#IncludeFile WorkPermit.inc
