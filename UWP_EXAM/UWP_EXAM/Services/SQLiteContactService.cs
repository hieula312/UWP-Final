using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_EXAM.Models;

namespace UWP_EXAM.Services
{
    class SQLiteContactService
    {
        private ContactModel phoneContactModel;

        public SQLiteContactService()
        {
            phoneContactModel = new ContactModel();
        }

        public bool Create(Contact phoneContact)
        {
            return phoneContactModel.Save(phoneContact);
        }

        public Contact Search(string name)
        {
            return phoneContactModel.GetDetail(name);
        }

        public ObservableCollection<Contact> ListContacts()
        {
            return phoneContactModel.GetList();
        }

        public bool Delete(int id)
        {
            return phoneContactModel.Delete(id);
        }

        public Contact Update(Contact newContact)
        {
            return phoneContactModel.Update(newContact);
        }

        public Dictionary<String, String> validateName(String name)
        {
            var errors = new Dictionary<String, String>();
            ObservableCollection<Contact> list = phoneContactModel.GetList();
            foreach (Contact item in list)
            {
                if (item.PhoneNumber.Equals(name))
                {
                    errors.Add("phoneErr", "Phone exist");
                }
            }
            return errors;
        }
    }
}
