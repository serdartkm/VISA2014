;**********************************
;********** Log On ****************
#IncludeFile Login.inc
;**********************************

;**********************************
;****** Insert Employee Data*******
;**********************************
#IncludeFile EmployeeInState.inc


;**********************************
;***Insert Employee Passport ******
;**********************************
#IncludeFile Passport_1.inc

;**********************************
;***Insert Employee Education ******
;**********************************
#IncludeFile Education_1.inc

;**********************************
;** Insert Employee Work History **
;**********************************
#IncludeFile WorkHistory_1.inc

;Save and Close Employee
*Action Save and Close
;**********************************
;*** insert App For invitation*****
;**********************************
#IncludeFile ProcessForApplicationForInvitation.inc
#IncludeFile ProcessEmployeeInApplicationForInvitation.inc

;------------------------------------------------
;-------Check Invitation State In View Variant---
;------------------------------------------------
;Close Application for invitation
*Action Close
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application Type , Person State
 Row = Serdar Aşyrow , Application for invitation , Office

;----------------------------------------------
;--- Set And Check Date Forwarded To Ministery-
;----------------------------------------------
*Action Navigation(Application.LongProcessApplication)
*ProcessRecord
 Registration Number = 120
*Action State
*FillForm
 Date Forwarded To Monistery = 02.01.2013
;Save and Close Application
*Action Save and Close
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Person State
 Row = Serdar Aşyrow , To ministery

;----------------------------------------------
;--- Set And Check Date From Ministery-
;----------------------------------------------
*Action Navigation(Application.LongProcessApplication)
*ProcessRecord
 Registration Number = 120
*Action State
*FillForm
 Ministeries Document Number = 15
 Ministeries Document Date = 03.01.2013
;Save and Close Application
*Action Save and Close
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Person State
 Row = Serdar Aşyrow , From ministery

;----------------------------------------------
;--- Set And Check Process Data-----------------
;----------------------------------------------
*Action Navigation(Application.LongProcessApplication)
*ProcessRecord
 Registration Number = 120
*Action State
*FillForm
 Process Number = AS-01
 Process Date = 04.01.2013
;Save and Close Application
*Action Save and Close
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Person State
 Row = Serdar Aşyrow , On process

;*********************************************
;*****Insert New invitation ******************
;*********************************************
#IncludeFile ProcessInvitForEmployee.inc
;Save and Close Application
*Action Save and Close
;---------------------------------------------
;---Check Invitation in Variable-------------
;--------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords

 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation Remaining Days , Invitation State , New Visa 
 Row = Serdar Aşyrow , 120;AS-01 , Invitation issued work permit not , Application for invitation , ASGH1 , 0 , Expired , ''


;----------------------------------------------------------------------
;----Reset Invitation date of expire and check state in variant -------
;----------------------------------------------------------------------
*Action Navigation(Application.LongProcessApplication)
*ProcessRecord
  Registration Number = 120
*Action Application Result
*ProcessRecord
 Number = ASGH1
*FillForm
 Date Of Expire = 10.06.2013
;Save and Close Application Result
*Action Save and Close
;Save and Close Application
*Action Save and Close
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation State , New Visa 
 Row = Serdar Aşyrow , 120;AS-01 , Invitation issued work permit not , Application for invitation , ASGH1 , Valid , ''

;**********************************
;***Insert Employee Passport_2 ******
;**********************************
*Action Navigation(Employee.Employee)
*ProcessRecord
 Full Name = Serdar Aşyrow
#IncludeFile Passport_2.inc
;Save and Close Employee
*Action Save and Close
;********************************************************
;***** Insert Application For Changing Invitation********
;********************************************************
#IncludeFile ProcessAppForChangingInvitation.inc

;-------------------------------------------------------
;------Check Application State In View Variant----------
;-------------------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation State , New Visa 
 Row = Serdar Aşyrow , 121; , Office , Application for changing invitation , '' , 'None' , ''
 

;--------------------------------------------------------
;--------Set Application State---------------------------
;--------------------------------------------------------
*Action Navigation(Application.SimpleProcessApplication)
*ProcessRecord 
 Registration Number = 121
*Action State
*FillForm
 Process Date = 20.01.2013
*Action Save and Close
;-------------------------------------------------------
;------Check Invitation State---------------------------
;-------------------------------------------------------
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation State , New Visa 
 Row = Serdar Aşyrow , 121; , On process , Application for changing invitation , '' , 'None' , ''

;-------------------------------------------------------
;----Insert Invitation----------------------------------
;-------------------------------------------------------

*Action Navigation(Application.SimpleProcessApplication)
*ProcessRecord 
 Registration Number = 121
*Action Application Result
*Action Application Result.New
*Action Application Result
*FillForm
 Number = ASGH2
 Issued Date = 22.01.2013
 Visa Category = Köp gezeklik
 Visa Period = 6 aý
 Date Of Expire = 22.03.2013
*Action Person In Result Letter
*Action Person In Result Letter.New
*FillForm
 Employee = Serdar Aşyrow
*Action Save and Close
*Action Save and Close
*Action Save and Close
;--------------------------------------------------------
;------Check View Variant For invitation-----------------
;--------------------------------------------------------

*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation State , New Visa 
 Row = Serdar Aşyrow , 121; , Processed , Application for changing invitation , ASGH2 , Expired , ''


;*********************************************************
;**********Insert Visa By Invitation**********************
;*********************************************************
*Action Navigation(Employee.Employee)
*ProcessRecord 
 Full Name = Serdar Aşyrow
*Action Passports
*ProcessRecord Passports
 Passport Number = 10101010
*Action Visas
*Action Visas.New
*Action IVisa
*FillForm
 ASNumber = AS-01
 Visa Number = A1
 Visa Type = BS
 Visa Category = Köp gezeklik
 Visa Issued Place = Aşgabat şäher howa menzilindäki MGP
 Visa Issued Date = 15.05.2013
 Visa Start Date = 15.05.2013
 Visa End Date = 15.11.2013
*CheckFieldValues
 Process Number = 120;AS-01
;Save and Close Visa
*Action Save and Close
;Save and Close Passport
*Action Save and Close
;Save and Close Employee
*Action Save
*Action Close
;------------------------------------------------------
;------ Check invitation State In View Variant---------
;------------------------------------------------------
*Action Navigation(Employee.Employee.View Variants.Invitation)
*SelectRecords
 Columns = Full Name , Application , Person State , Application Type , Invitation Number , Invitation State , New Visa 
 Row = Serdar Aşyrow , 121; , Processed , Application for changing invitation , ASGH2 , Expired , ''









