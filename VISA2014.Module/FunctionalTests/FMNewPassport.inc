*Action Navigation(FamilyMember.FamilyMember)
*ProcessRecord 
 Full Name = Jeren Meredowa
*Action Passports
*Action Passports.New
*FillForm
 Passport Number = NEWFM000001
 Passport Type = Ordinary
 Personal Number = 000001
*ExecuteEditorAction Citizenship
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Passport Issued Place = Moskwa
 Passport Issued Date = 18.01.2014
 Passport Expiring Date = 18.01.2025
*ExecuteEditorAction Passport Issued Country
*Action Filter by Text()
*ProcessRecord Country
 Name Of Country = RUS
*Action Save and Close
#IncludeFile NewFMVisa.inc
*Action Save and Close
