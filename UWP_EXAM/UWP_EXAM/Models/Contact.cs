using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UWP_EXAM.Models
{
    class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Dictionary<String, String> ValidateContact()
        {
            var errors = new Dictionary<String, String>();
            if (string.IsNullOrEmpty(this.Name))
            {
                errors.Add("nameErr", "Name mush be filled");
            }

            if (string.IsNullOrEmpty(this.PhoneNumber))
            {
                errors.Add("phoneErr", "Phone must be filled");
            }
            else
            {
                if (!Regex.IsMatch(this.PhoneNumber, "(09|01|03[2|6|8|9])+([0-9]{8})\\b"))
                {
                    errors.Add("phoneErr", "Phone format is incorrect");
                }
            }
            return errors;
        }
    }
}
