*Action Passports
*Action Passports.New
*FillForm
 Passport Number = 10101010
 Passport Type = Ordinary
 Personal Number = P01010101
*ExecuteEditorAction Citizenship
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Passport Issued Place = Moskwa
 Passport Issued Date = 15.01.2010
 Passport Expiring Date = 15.01.2016
*ExecuteEditorAction Passport Issued Country
*Action Filter by Text()
*ProcessRecord Country
 Name Of Country = RUS
;Save and close First Passport
*Action Save
*Action Close
