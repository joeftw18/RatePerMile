using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;
using System;
using System.Text;
using Xamarin.Android;

namespace RatePerMile
{
    [Activity(Label = "Rate Per Mile Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // Get the UI controls from the loaded layout:
            EditText loadedMiles = FindViewById<EditText>(Resource.Id.loadedMiles);
            EditText emptyMiles = FindViewById<EditText>(Resource.Id.emptyMiles);
            EditText paidRate = FindViewById<EditText>(Resource.Id.paidRate);

            Button calculateRPM = FindViewById<Button>(Resource.Id.calculateRPM);
            TextView trueRPM = FindViewById<TextView>(Resource.Id.trueRPM);
            TextView tripRevenue = FindViewById<TextView>(Resource.Id.tripRevenue);

            // Disable the "Call" button
                      calculateRPM.Enabled = false;



            void checkText()
            {
                
                if ((loadedMiles.Text.Length > 0) && (emptyMiles.Text.Length > 0) &&
                    (paidRate.Text.Length > 0))
                {
                    calculateRPM.Enabled = true;
                }

            }
                checkText();

            loadedMiles.TextChanged += (object sender1, Android.Text.TextChangedEventArgs e) =>
            {
                checkText();
            };

            emptyMiles.TextChanged += (object sender1, Android.Text.TextChangedEventArgs e) =>
            {
                checkText();
            };

            paidRate.TextChanged += (object sender1, Android.Text.TextChangedEventArgs e) =>
            {
                checkText();
            };

            calculateRPM.Click += (object sender, EventArgs e) =>
                {
                    var loaddmiles = Convert.ToInt32(loadedMiles.Text);
                    var emptymiles = Convert.ToUInt32(emptyMiles.Text);
                    var payrate = Convert.ToDouble(paidRate.Text);
                    var truerate = ((loaddmiles * payrate) / (loaddmiles + emptymiles));
                    trueRPM.Text = "$" + truerate.ToString("0.00");
                    tripRevenue.Text = "$" + (loaddmiles * payrate).ToString();

                };




            }
        }
    }


