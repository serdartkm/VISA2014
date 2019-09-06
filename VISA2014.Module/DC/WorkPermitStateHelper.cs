using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{
    class WorkPermitStateHelper
    {
        public static WorkPermitStateEnum GetWorkPermitState(IPersonInApplication personInApp,IWorkPermit workPermit, WorkPermitStateEnum unknown) {

            //REJECTED
            if (personInApp.Rejected 
                | personInApp.Application.Rejected 
                | personInApp.Application.ApplicationState== ApplicationStateEnum.Rejected)
            {

                return WorkPermitStateEnum.VE_REJECTED;
            }
         

      


            if (workPermit.RemainingDays>=1 && personInApp.Cancelled | personInApp.Application.Cancelled)
            {

                return WorkPermitStateEnum.VALID;

            }
            //CANCELLED BY PERSON IN APP
            if ((personInApp.IsComplete
                || personInApp.Application.ApplicationState== ApplicationStateEnum.Processed)
                && personInApp.Application.BaseApplicationType.TypeOfBaseApplication == AppType.Cancelling)
            {

                return WorkPermitStateEnum.CANCELLED;
            
            }
         
            //EXTENDED BY PERSON IN APP
            if (workPermit.RemainingDays>=1 && (personInApp.IsComplete|personInApp.Application.ApplicationState== ApplicationStateEnum.Processed) && personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
            {
                return WorkPermitStateEnum.Extended;

            }
            //EXTENDED BY APPICATION
            if (workPermit.RemainingDays>=1 &&  personInApp.Application.SubType == SubType.ApplicationForVisaExtention
                && (personInApp.Application.ApplicationState== ApplicationStateEnum.Processed 
                | personInApp.Application.IsComplete))
            {
                return WorkPermitStateEnum.Extended;

            }

            if(personInApp.Application.SubType == SubType.ApplicationForVisaExtention
                && !personInApp.IsComplete
                && !personInApp.Cancelled 
                && !personInApp.Rejected 
                && personInApp.Application.ApplicationState == ApplicationStateEnum.OnProcess)
            //EXTENTION VE_ONPROCESS
            {

                return WorkPermitStateEnum.VE_ONPROCESS;
            }
           
      
            // FROM MINISTERY
            if (personInApp.Application.ApplicationState == ApplicationStateEnum.FromMinistery 
                && !personInApp.Cancelled 
                && !personInApp.Rejected 
                && !personInApp.IsComplete)
            {

                return WorkPermitStateEnum.FROM_MINISTERY;
            }

            // TO MINISTERY
            if (personInApp.Application.ApplicationState == ApplicationStateEnum.ToMinistery
                && !personInApp.Cancelled
                && !personInApp.Rejected 
                && !personInApp.IsComplete)
            {

                return WorkPermitStateEnum.TO_MINISTERY;
            }
            //ADD PLACE TO WP ON PROCESS
            if (workPermit.RemainingDays>=1 && (personInApp.Application.ApplicationState == ApplicationStateEnum.Processed
                || personInApp.IsComplete)
                && personInApp.Application.SubType == SubType.ApplicationForExtendingWorkPermitLocation)
            {

                return WorkPermitStateEnum.AP_COMPLETE;
            }
            //ADD PLACE TO WP ON PROCESS
            if (personInApp.Application.SubType == SubType.ApplicationForExtendingWorkPermitLocation
                && (personInApp.Application.ApplicationState == ApplicationStateEnum.Office 
                && !personInApp.Cancelled 
                && !personInApp.Rejected) 
                && !personInApp.IsComplete)
            {

                return WorkPermitStateEnum.AP_OFFICE;

            }
            //ADD PLACE TO WP COMPLETE
            if (personInApp.Application.SubType == SubType.ApplicationForExtendingWorkPermitLocation
                && (personInApp.Application.ApplicationState == ApplicationStateEnum.OnProcess
                && !personInApp.Rejected 
                && !personInApp.Cancelled
                && !personInApp.IsComplete) 
               )
            {

                return WorkPermitStateEnum.AP_ONPROCESS;
            }


            //CANCELLED office
            if ((personInApp.Application.BaseApplicationType.TypeOfBaseApplication== AppType.Cancelling)
                 && (personInApp.Application.ApplicationState == ApplicationStateEnum.Office 
                 && !personInApp.IsComplete 
                 && !personInApp.Rejected 
                 && !personInApp.Cancelled))
            {

                return WorkPermitStateEnum.VC_OFFICE;
            }

            //CANCELLED CANCELLED
            if ((personInApp.Application.BaseApplicationType.TypeOfBaseApplication == AppType.Cancelling) 
                && (personInApp.Application.ApplicationState == ApplicationStateEnum.Processed 
                || personInApp.IsComplete))
            {

                return WorkPermitStateEnum.CANCELLED;
            }

            //EXTENTION ON OFFICE
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention 
                &&  personInApp.Application.ApplicationState == ApplicationStateEnum.Office 
                && !personInApp.IsComplete && !personInApp.Rejected && !personInApp.Cancelled)
            {

                return WorkPermitStateEnum.VE_OFFICE;
            }

            if (workPermit.RemainingDays <= 0)
            {

                return WorkPermitStateEnum.EXPIRED;
            }
        
     
           

            else return unknown;
        }
    }
}
