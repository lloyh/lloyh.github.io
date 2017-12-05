using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework8.Models
{
    public class ValidateDate : ValidationAttribute
    {
        public override bool IsValid(object theDate)
        {
            DateTime tempDate = (DateTime)theDate; //cast theDate object to DateTime type and save as variable tempDate
            return tempDate < DateTime.Now; //return boolean value 
                                            //true if tempDate is in the past
                                            //false if tempDate is in the future
        }
    }
}