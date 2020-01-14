using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using UWP_EXAM.Services;

namespace UWP_EXAM.Models
{
    class ContactModel
    {
        public bool Save(Contact phoneContact)
        {
            var sqlConnection = SQLLiteHelperF.CreateInstance().SQLiteConnection;
            var sqlCommandString = "insert into Contacts (Name, PhoneNumber) values (?,?)";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                stt.Bind(1, phoneContact.Name);
                stt.Bind(2, phoneContact.PhoneNumber);
                var result = stt.Step();
                // Debug.WriteLine("create " + result);
                return result == SQLiteResult.DONE;
            }
        }

        public ObservableCollection<Contact> GetList()
        {
            ObservableCollection<Contact> list = new ObservableCollection<Contact>();
            var sqlConnection = SQLLiteHelperF.CreateInstance().SQLiteConnection;
            var sqlCommandString = "select * from Contacts";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                while (SQLiteResult.ROW == stt.Step())
                {
                    var id = stt[0].ToString();
                    var _name = (string)stt["Name"];
                    var _phoneNumber = (string)stt["PhoneNumber"];
                    var contact = new Contact()
                    {
                        Id = Int32.Parse(id),
                        Name = _name,
                        PhoneNumber = _phoneNumber
                    };
                    list.Add(contact);
                }
            }
            return list;
        }

        public Contact GetDetail(string name)
        {
            var sqlConnection = SQLLiteHelperF.CreateInstance().SQLiteConnection;
            var sqlCommandString = "SELECT * FROM Contacts WHERE Name LIKE '%" + name + "%' LIMIT 1";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                if (SQLiteResult.ROW == stt.Step())
                {
                    var id = stt[0].ToString();
                    var _name = (string)stt["Name"];
                    var _phoneNumber = (string)stt["PhoneNumber"];
                    var contact = new Contact()
                    {
                        Id = Int32.Parse(id),
                        Name = _name,
                        PhoneNumber = _phoneNumber
                    };
                    return contact;
                }
                return null;
            }
        }

        public Contact Update(Contact phoneContact)
        {
            var sqlConnection = SQLLiteHelperF.CreateInstance().SQLiteConnection;
            var sqlCommandString = "UPDATE Contacts SET Name = '" + phoneContact.Name + "', PhoneNumber = '" + phoneContact.PhoneNumber + "' WHERE Id = '" + phoneContact.Id + "'";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                if (SQLiteResult.ROW == stt.Step())
                {
                    var id = stt[0].ToString();
                    var _name = (string)stt["Name"];
                    var _phoneNumber = (string)stt["PhoneNumber"];
                    var contact = new Contact()
                    {
                        Id = Int32.Parse(id),
                        Name = _name,
                        PhoneNumber = _phoneNumber
                    };
                    return contact;
                }

                return null;
            }
        }

        public bool Delete(int id)
        {
            var sqlConnection = SQLLiteHelperF.CreateInstance().SQLiteConnection;
            var sqlCommandString = "DELETE FROM Contacts WHERE Id = '" + id + "'";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                if (SQLiteResult.DONE == stt.Step())
                {
                    return true;
                }
                return false;
            }
        }
    }
}
