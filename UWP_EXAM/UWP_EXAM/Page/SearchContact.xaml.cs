using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_EXAM.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_EXAM.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchContact : Windows.UI.Xaml.Controls.Page
    {
        private SQLiteContactService _service;
        public SearchContact()
        {
            this.InitializeComponent();
            _service = new SQLiteContactService();
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            namelErr.Text = "";
            String name = this.name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                namelErr.Text = "Name must be filled";
            }
            else
            {
                this.phone.Text = _service.Search(name).PhoneNumber;
            }
        }
    }
}
