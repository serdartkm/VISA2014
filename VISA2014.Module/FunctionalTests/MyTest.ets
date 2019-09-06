;#DropDB VISA2014EasyTest
#Application VISA2014.Win
*Action Log On
*Action Navigation(Applications.Long Process Application)
*Action New(Long Process Application) 
*Action IApplication
*FillForm
 Base Application Type = Invitation
 Application Type For Employee = Application for invitation
 Applied Ministery = TIIM
 Contract = 000001
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
;Save And Close Border Zone For Visa
*Action Save and Close
*Action LayoutTab.Person In Application
*Action Person In Application.New
*Action IPerson In Application
*FillForm
 Employee = Andrew Fuller
 Address = Çandybil etraby;Türkmenbaşy Şaýoly 145 AF
;Save And Close Person In Application
*Action Save and Close
;Save And Close Application
*Action Save And Close




;----Preprocessor Directives
;Application
;DropDB
;IncludeFile
;RestoreDB
;Timeout

;---Common Commands
;ActionAvailable
;ActionVisible
;CheckActionValue
;CheckFieldValues
;CheckValidationResult
;ComareScreenShot
;FieldVisible
;FillForm
;ReopenApplication
;SetActiveWindowSize

;-----Table Command
;CheckTableSelection
;ClearSelection
;ProcessRecord
;SelectRecords
;UnselectRecords
