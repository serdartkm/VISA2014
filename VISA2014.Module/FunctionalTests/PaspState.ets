
;***************************************************
;Log on
;***************************************************
#IncludeFile Login.inc


;***************************************************
; Insert Employee
;***************************************************
#IncludeFile EmployeeInState.inc

;***************************************************
;Insert education
;***************************************************
#IncludeFile Education_1.inc

;***************************************************
;Insert Work History
;***************************************************
#IncludeFile WorkHistory_1.inc

;**************************************************
;insert First Passport
;**************************************************
#IncludeFile Passport_1.inc

;Save Employee
*Action Save

;-------------------------------------------------
;Check first Passport State
;--------------------------------------------------
*Action Passports
*SelectRecords
 Columns = Passport Number, Passport State
 Row = 10101010 , Valid

;-------------------------------------------------
;--------Check employees last pasport-------------
;-------------------------------------------------
*Action AddInfo
*CheckFieldValues
 Last Passport = 10101010

;-----------------------------------------------
;-----Check Last Passport In View Variant-------
;-----------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Passport)
*SelectRecords
 Columns = Passport Number
 Row = 10101010

;***********************************************
;******* Enter Second Passport******************
;***********************************************
*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
#IncludeFile Passport_2.inc
;Save employee
*Action Save
;----------------------------------------------
;----------Check second passport State---------
;----------------------------------------------

*Action Passports
*SelectRecords
 Columns = Passport Number, Passport State
 Row = 20202020 , Valid
;-----------------------------------------------
;--------Check First Passport State------------
;-----------------------------------------------
*SelectRecords
 Columns = Passport Number , Passport State
 Row = 10101010 , Previous

;-----------------------------------------------
;---Check Last Passport In View Variant---------
;-----------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Passport)
*SelectRecords
 Columns = Passport Number
 Row = 20202020

;***********************************************
;************Enter  Third Passport**************
;***********************************************

*Action Navigation (Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
#IncludeFile Passport_3.inc
;Save Employee
*Action Save
;------------------------------------------------
;--------Check Third Passport State--------------
;------------------------------------------------

*Action Passports
*SelectRecords
 Columns = Passport Number , Passport State
 Row = 30303030 , Valid

;------------------------------------------------
;--------Check Second Passport State-------------
;------------------------------------------------


*SelectRecords
 Columns = Passport Number , Passport State
 Row = 20202020 , Previous


;------------------------------------------------
;--------Check First Passport State--------------
;------------------------------------------------

*SelectRecords
 Columns = Passport Number , Passport State
 Row = 10101010 , Previous

;-----------------------------------------------
;-----Check Last Passport Of Employee-----------
;-----------------------------------------------

*Action AddInfo
*CheckFieldValues
 Last Passport = 30303030
;-----------------------------------------------
;---Check Last Passport In View Variant---------
;-----------------------------------------------
*Action Navigation(Employee.Employee.View Variants.Passport)
*SelectRecords
 Columns = Passport Number
 Row = 30303030

;***********************************************
;***********Delete Last Passport****************
;***********************************************
*Action Navigation(Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
*ProcessRecord Passports
 Passport Number = 30303030
*Action Delete
*HandleDialog
 Respond = Yes
;Save employee
*Action Save
 
;-----------------------------------------------
;-----Check Second Passport State---------------
;-----------------------------------------------
*Action Passports
*SelectRecords
 Columns = Passport Number , Passport State
 Row = 20202020 , Valid

;----------------------------------------------
;-------Check Last Passport Of Employee--------
;----------------------------------------------
*Action AddInfo
*CheckFieldValues
 Last Passport = 20202020

;----------------------------------------------
;-------Check Last Passport In View Variant----
;----------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Passport)
*SelectRecords
 Columns = Passport Number , Passport State
 Row = 20202020 , Valid

