using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_EXAM.Models;
using UWP_EXAM.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_EXAM.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Windows.UI.Xaml.Controls.Page
    {
        private SQLiteContactService _service;
        public AddContact()
        {
            this.InitializeComponent();
            this._service = new SQLiteContactService();
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            Sanitize_ErrBlock();
            var contact = new Contact()
            {
                Name = name.Text,
                PhoneNumber = phone.Text
            };
            var errors = contact.ValidateContact();
            if (errors.Count > 0)
            {
                showErrors(errors);
            }
            else
            {
                var error2 = _service.validateName(Name);
                if (error2.Count > 0)
                {
                    showErrors(error2);
                }
                else
                {
                    _service.Create(contact);
                    this.Frame.Navigate(typeof(SearchContact));
                }
            }
        }

        private void Sanitize_ErrBlock()
        {
            namelErr.Text = "";
            phoneErr.Text = "";
        }

        private void showErrors(Dictionary<String, String> errorsVal)
        {
            foreach (KeyValuePair<String, String> item in errorsVal)
            {
                var block = (TextBlock)this.FindName(item.Key);
                if (block != null)
                {
                    block.Text = item.Value;
                }
            }
        }
    }
}
