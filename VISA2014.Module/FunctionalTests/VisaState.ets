;************************************************
;******** Log on ********************************
;************************************************
#IncludeFile Login.inc
;************************************************
;******** Insert Employee ***********************
;************************************************
#IncludeFile EmployeeInState.inc

;************************************************
;********Insert Work History*********************
;************************************************
#IncludeFile WorkHistory_1.inc
;************************************************
;****** Insert Education ************************
;************************************************
#IncludeFile Education_1.inc
;************************************************
;****** Insert first passport *******************
;************************************************
#IncludeFile Passport_1.inc
;Save employee
*Action Save

;************************************************
;******* Insert first visa into first passport *
;***********************************************
*Action Passports
*ProcessRecord
 Passport Number = 10101010
#IncludeFile Visa_1.inc

;Save passport
*Action Save

;-----------------------------------------------
;------Check first visa-------------------------
;-----------------------------------------------

;........Visa state is Valid--------------------
*Action Visas
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A01 , Valid

;....... is equal to Last Visa of employee......
;Close Save  Passport
*Action Close
*Action AddInfo
*CheckFieldValues 
 Last Visa = A01

;........ exists in View Variant................
;Save and Close Employee
*Action Save and Close

*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A01 , Valid


;************************************************
;****** Insert second visa into first passport *
;***********************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 10101010
#IncludeFile Visa_2.inc
;Save passport
*Action Save

;-----------------------------------------------
;------Check second and first visa--------------
;-----------------------------------------------
*Action Visas
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A01 , None
 Row = A02 , Valid
;....... 2 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
*Action AddInfo
*CheckFieldValues
 Last Visa = A02

;........2 visa exists in View Variant..........
; Save and Close Employee
*Action Save and Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A02 , Valid


;************************************************
;****** Insert third visa into first passport *
;***********************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 10101010
#IncludeFile Visa_3.inc
;Save passport
*Action Save
;-----------------------------------------------
;------Check tird, second and first visa--------
;-----------------------------------------------
*Action Visas
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A01 , None
 Row = A02 ,  None
 Row = A03 , Valid
;....... 3 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
;Save Employee
*Action Save
*Action AddInfo
*CheckFieldValues
 Last Visa = A03
;........3 visa exists in View Variant..........
;Close Employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A03 , Valid

;************************************************
;****** Delete third visa ***********************
;************************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 10101010
*Action Visas
*ProcessRecord
 Visa Number = A03
*Action Delete
*HandleDialog
 Respond = Yes
;Save passport
*Action Save

;-----------------------------------------------
;------Check second and first visa--------------
;-----------------------------------------------

;........2 Visa state is Valid------------------
*Action Visas
*SelectRecords
 Columns =  Visa Number , Visa State
 Row = A02 , Valid

;.... 2 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
;Save Employee
*Action Save
*Action AddInfo
*CheckFieldValues
 Last Visa = A02

;........2 visa exists in View Variant..........
;Close Employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords

 Columns = Full Name , Visa Number , Visa State

 Row = Serdar Aşyrow , A02 , Valid

;&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

;************************************************
;****** Insert second passport ******************
;************************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
#IncludeFile Passport_2.inc
;Save Employee
*Action Save
;************************************************
;******* Insert forth visa into second passport *
;***********************************************
*Action Passports
*ProcessRecord
 Passport Number = 20202020
#IncludeFile Visa_4.inc
;Save passport
*Action Save
;-----------------------------------------------
;------Check forth visa-------------------------
;-----------------------------------------------

;........Visa state is Valid--------------------
*Action Visas
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A04 , Valid
;....... is equal to Last Visa of employee......
;Close Passport
*Action Close
; Save employee
*Action Save
;Close employee
*Action Close
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action AddInfo
*CheckFieldValues
 Last Visa = A04
 Last Passport = 20202020

;........ exists in View Variant................
; Close Employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Full Name , Visa Number , Visa State
 Row = Serdar Aşyrow , A04 , Valid

;************************************************
;****** Insert fifth visa into second passport *
;***********************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 20202020
#IncludeFile Visa_5.inc
;Save passport
*Action Save
;-----------------------------------------------
;------Check forth and fifth visa--------------
;-----------------------------------------------
;........Visa state------------------
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A04 , None
 Row = A05 , Valid
;....... 5 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
;Save Employee
*Action Save
*Action AddInfo
*CheckFieldValues
 Last Visa = A05
 Last Passport = 20202020
;........5 visa exists in View Variant..........
;Close employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Full Name , Visa Number , Visa State
 Row = Serdar Aşyrow , A05 , Valid

;************************************************
;****** Insert sixth visa into second passport *
;***********************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 20202020
#IncludeFile Visa_6.inc
;Save passport
*Action Save
;-----------------------------------------------
;------Check forth, fifth and sixth visa--------
;-----------------------------------------------

;........ Visa state ------------------
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A06 , Valid
 Row = A05 , None
 Row = A04 , None

;....... 6 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
;Save Employee
*Action Save
*Action AddInfo
*CheckFieldValues
 Last Visa = A06
 Last Passport = 20202020
;........6 visa exists in View Variant..........
;Close Employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Full Name , Visa Number , Visa State
 Row = Serdar Aşyrow , A06 , Valid

;************************************************
;****** Delete sixth visa ***********************
;************************************************
*Action Navigation(Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord
 Passport Number = 20202020
*Action Visas
*ProcessRecord
 Visa Number = A06
*Action Delete
*HandleDialog
 Respond = Yes
;Save passport
*Action Save
;-----------------------------------------------
;------Check fifth and fourth visa--------------
;-----------------------------------------------
;..................Visa state ------------------
*SelectRecords
 Columns = Visa Number , Visa State
 Row = A05 , Valid
 Row = A04 , None
;.... 5 visa is equal to Last Visa of employee..
;Close Passport
*Action Close
;Save Employee
*Action Save
*Action AddInfo
*CheckFieldValues
 Last Visa = A05
 Last Passport = 20202020

;........4 visa exists in View Variant..........
;Close Employee
*Action Close
*Action Navigation (Employee.Employee.View Variants.Visa)
*SelectRecords
 Columns = Full Name , Visa Number , Visa State
 Row = Serdar Aşyrow , A05 , Valid
