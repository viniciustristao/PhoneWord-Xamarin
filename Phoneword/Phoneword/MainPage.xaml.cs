using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;
        
        public MainPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Ligar " + translatedNumber;
            }
            else
            {

                callButton.IsEnabled = false;
                callButton.Text = "Ligar";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if(await this.DisplayAlert("Ligar um numero",
                "Voce gostaria de ligar "+ translatedNumber+ "?",
                "Yes",
                "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if(dialer != null)
                {
                    dialer.Dial(translatedNumber);
                }
            }
        }
    }
}