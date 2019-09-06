*Action Navigation(FamilyMember.FamilyMember)
*Action New
*FillForm
 First Name = Jeren
 Last Name = Meredowa
 Gender = Aýal
 Birth Date = 17.01.1989
 Marital Status = Durmuşa çykan
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
 Foreign Address = Moskwa
 Employee = Andrew Fuller
 Family Member Relation = Aýaly

*Action Address Of Residences
*Action Address Of Residences.New
*FillForm
 Address = Çandybil etraby;Görogly 24
 Start Date Of Residence = 17.01.2013
*Action Save and Close

*Action Passports
*Action Passports.New
*FillForm
 Passport Number = JFM000012P
 Passport Type = Ordinary
 Personal Number = J0000001
*ExecuteEditorAction Citizenship
*Action Filter by Text(RUS)
*ProcessRecord Country
 Name Of Country = RUS
*FillForm
 Passport Issued Place = Moskwa
 Passport Issued Date = 17.04.2015
 Passport Expiring Date = 17.04.2020
*ExecuteEditorAction Passport Issued Country
*Action Filter by Text()
*ProcessRecord Country
 Name Of Country = RUS
*Action Visas.New
*FillForm
 Visa Number = JFMV0000001
 Visa Type = BS
 Visa Category = Köp gezeklik
 Visa Issued Place = Aşgabat şäher howa menzilindäki MGP
 Visa Issued Date = 17.01.2012
 Visa Start Date = 17.01.2012
 Visa End Date = 17.06.2012
 ASNumber = AS-145877
*Action Save and Close
*Action Save and Close
*Action Save and Close
#IncludeFile FMNewPassport.inc
#IncludeFile FMTravel.inc