using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using VISA2014.Module.BusinessObjects;
using System.Linq;

namespace VISA2014.Module.DC
{


         [RuleCriteria("EmployeeWithout Position", DefaultContexts.Save, " WorkHistories.Count > 0", "Position must not be empty", SkipNullOrEmptyValues = false)]
         [RuleCriteria("ForiegnAddress", DefaultContexts.Save, "Not IsNullOrEmpty(ForeignAddress)", "Daєary эurtdaky salgysyny эazmaly", SkipNullOrEmptyValues = false)]
         [RuleCriteria("ForiegnAddressЗountry", DefaultContexts.Save, "Not IsNullOrEmpty(ForeignAddressCountry)", "Daєary эurtdaky salgysyny эazmaly", SkipNullOrEmptyValues = false)]
         [RuleCriteria("EducationValidation", DefaultContexts.Save, "Educations Is Not Null", "Bilimini эazmaly", SkipNullOrEmptyValues = false)]
     

         [RuleCriteria("PersonЗontraзt", DefaultContexts.Save, "(IsEmployee And Contract Is Not Null)", "Єertnamany saэlamaly", SkipNullOrEmptyValues = false)]
    [DomainComponent]
  
    [VisibleInReports]
    public interface IEmployee :IPersonn
    {
     
            
             Taşaron Taşaron { get; set; }


             Salary Salary { get; set; }
       
         
                [FieldSize(200)]
                string Bellik { get; set; }
           
    }

    [DomainLogic(typeof(IEmployee))]
    public class EmployeeLogic {


        public static void AfterConstruction(IEmployee emp)
        {

            emp.IsEmployee = true;
        



        }

        public static void AfterChange_Contract(IEmployee emp, IObjectSpace os)

        {
          
        }



    


    }


}
