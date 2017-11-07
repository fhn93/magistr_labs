using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Xamarin.Android;

namespace Android_lab1
{
    [Activity(Label = "lab1", MainLauncher = true)]
    public class MainActivity : Activity
    {                                        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
           
            

            Button but = FindViewById<Button>(Resource.Id.Button);
            but.Click += Calculate;
        }
                                                   
        private void Calculate(object sender, EventArgs e)
        {
            double a, b, c, d;

            a = double.Parse(FindViewById<TextView>(Resource.Id.A).Text);
            b = double.Parse(FindViewById<TextView>(Resource.Id.B).Text);
            c = double.Parse(FindViewById<TextView>(Resource.Id.C).Text);

            d = Math.Pow(b, 2) - 4 * a * c;
            TextView X1 = FindViewById<TextView>(Resource.Id.TextX1);
            TextView X2 = FindViewById<TextView>(Resource.Id.TextX2);

            switch (Math.Sign(d))
            {
                case -1:
                    X1.Text = "Дискриминан меньше нуля. не корней";
                    X2.Text = "";
                    break;

                case 0:
                    X1.Text = "X1: " + (-b / (2 * a)).ToString();
                    X2.Text = "Дискриминан";
                    break;
                
                case 1:
                    X1.Text = "X1: " + ((-b + Math.Sqrt(d)) / (2 * a)).ToString();
                    X2.Text = "X1: " + ((-b - Math.Sqrt(d)) / (2 * a)).ToString();
                    break;          
            }
        }
    }
}

