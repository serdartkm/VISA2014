;***************************************
; Register Application
;***************************************
*Action Navigation(Application.LongProcessApplication)
*Action New(Long Process Application)
*Action IApplication
*FillForm
 Base Application Type = Invitation
 Application Type For Employee = Application for invitation
 Auto Registration = False
 Manual Application Number = 120
 Manual Application Date = 01.01.2013
 Applied Ministery = TDIM
 Contract = 000002
 Visa Period = 6 aý
 Visa Category = Köp gezeklik
 Is Invitation With Work Permit = Invitation and work permit
 Choose Border Zone Type = Border zone for application
*ExecuteEditorAction Border Zone For Visa
*Action New
*FillForm
 Daşoguz = True
 Tagtabazar = True
 Serhetabat = True
 Ýolöten = True
*Action Save and Close
*Action Save
;***************************************
;**** Forward app to ministery *********
;***************************************

