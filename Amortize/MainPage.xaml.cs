using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Amortize.Resources;
using System.Globalization;

namespace Amortize
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            long term = Convert.ToInt32(Term.Text);
            double numberOfPayments = term * 12;
            double ratePerPeriod = Convert.ToDouble(InterestRate.Text) / 12 / 100;
            double amount = Convert.ToDouble(Amount.Text) - Convert.ToDouble(DownPayment.Text);
            double q = Math.Pow(1 + ratePerPeriod, numberOfPayments);
            double futureValue = 0;
            double type = 0;
            double paymentAmount = (ratePerPeriod * (futureValue + (q * amount))) / ((-1 + q) * (1 + ratePerPeriod * (type)));
            // (ratePerPeriod * (futureValue + (q * loanAmount))) / ((-1 + q) * (1 + ratePerPeriod * (type)));
            PaymentAmount.Text = String.Format(CultureInfo.InvariantCulture, "${0:0.00}", paymentAmount);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}