*Action Passports
*Action Passports.New
*FillForm
 Passport Number = 20202020
 Passport Type = Ordinary
 Personal Number = P20202020
*ExecuteEditorAction Citizenship
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Passport Issued Place = Moskwa
 Passport Issued Date = 15.01.2016
 Passport Expiring Date = 15.01.2020
*ExecuteEditorAction Passport Issued Country
*Action Filter by Text()
*ProcessRecord Country
 Name Of Country = RUS
;Save and close second Passport
*Action Save and Close