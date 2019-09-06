using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VISA2014.Module.BusinessObjects;

namespace VISA2014.Module.DC
{
    class VisaStateHelper
    {
        public static VisaState GetVisaState(IPersonInApplication personInApp, IVisa visa, VisaState unknown)
        {

            //REJECTED
            if (personInApp.Rejected | personInApp.Application.Rejected | personInApp.Application.ApplicationState== ApplicationStateEnum.Rejected)
            {

                return VisaState.VISA_EXT_REJECTED;
            }

            if (personInApp.Cancelled)
            {

                return VisaState.VISA_VALID;

            }

            //EXTENTION ON OFFICE
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention
                && personInApp.Application.ApplicationState == ApplicationStateEnum.Office
                && !personInApp.IsComplete
                && !personInApp.Rejected
                && !personInApp.Cancelled)
            {

                return VisaState.VISA_EXT_OFFICE;
            }
            // TO MINISTERY
            if (personInApp.Application.ApplicationState == ApplicationStateEnum.ToMinistery
                && !personInApp.Cancelled
                && !personInApp.Rejected
                && !personInApp.IsComplete)
            {

                return VisaState.VISA_EXT_TO_MINISTERY;
            }

            // FROM MINISTERY
            if (personInApp.Application.ApplicationState == ApplicationStateEnum.FromMinistery
                && !personInApp.Cancelled
                && !personInApp.Rejected
                && !personInApp.IsComplete)
            {

                return VisaState.VISA_EXT_FROM_MINISTERY;
            }
 
            //EXTENTION ON PROCESS
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention
                && personInApp.Application.ApplicationState == ApplicationStateEnum.OnProcess
                && !personInApp.IsComplete
                && !personInApp.Rejected
                && !personInApp.Cancelled)
            {

                return VisaState.VISA_EXT_ONPROCESS;
            }
            //EXTENDED BY PERSON IN APP
            if ((personInApp.IsComplete | personInApp.Application.ApplicationState == ApplicationStateEnum.Processed) && personInApp.Application.SubType == SubType.ApplicationForVisaExtention)
            {
                return VisaState.VISA_EXTENDED;

            }

            //EXTENDED BY APPICATION
            if (personInApp.Application.SubType == SubType.ApplicationForVisaExtention
                && (personInApp.Application.ApplicationState == ApplicationStateEnum.Processed
                | personInApp.Application.IsComplete))
            {
                return VisaState.VISA_EXTENDED;

            }
       
            //CANCELLED BY PERSON IN APP
            if ((personInApp.IsComplete | personInApp.Application.ApplicationState== ApplicationStateEnum.Processed)
                && personInApp.Application.BaseApplicationType.TypeOfBaseApplication == AppType.Cancelling)
            {

                return VisaState.VISA_CANCELLED;
            
            }
         


            //CANCELLED office
            if ((personInApp.Application.BaseApplicationType.TypeOfBaseApplication== AppType.Cancelling)
                 && (personInApp.Application.ApplicationState == ApplicationStateEnum.Office 
                 && !personInApp.IsComplete 
                 && !personInApp.Rejected 
                 && !personInApp.Cancelled))
            {

                return VisaState.VISA_CAN_OFFICE;
            }

            //CANCELLED CANCELLED
            if ((personInApp.Application.BaseApplicationType.TypeOfBaseApplication == AppType.Cancelling) 
                && (personInApp.Application.ApplicationState == ApplicationStateEnum.Processed 
                | personInApp.IsComplete))
            {

                return VisaState.VISA_CANCELLED;
            }

      
            
            if (visa.RemainingDays <= 0)
            {

                return VisaState.VISA_EXPIRED;
            }

            if (visa.RemainingDays >= 1)
            {
                return VisaState.VISA_VALID;
            }
        
     
           

            else return unknown;
        }
    }
}
