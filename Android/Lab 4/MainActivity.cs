using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.IO;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Runtime;
using Android.Hardware;
using Android.Media;

namespace lab4
{
    [Activity(Label = "lab4", MainLauncher = true)]
    public class MainActivity : Activity, ISensorEventListener
    {
        SensorManager SM;
        Android.Media.MediaPlayer MP;
        bool play = false;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            
        }

        public void OnSensorChanged(SensorEvent e)
        {
            Toast.MakeText(this, "CHANGE", ToastLength.Long).Show();
            play = !play;
            if (play)
            {
                if (!MP.IsPlaying)
                {
                    MP.Start();
                }
                Toast.MakeText(this, "START", ToastLength.Long).Show();
                MP.SetVolume(0.0f, 1.0f);
            }
            else
            {
                MP.Pause();
                Toast.MakeText(this, "STOP", ToastLength.Long).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
                                                             
            SetContentView(Resource.Layout.Main);
            SM = (SensorManager)GetSystemService(SensorService);
            MP = MediaPlayer.Create(this, Resource.Raw.A);
            Toast.MakeText(this, "LOAD", ToastLength.Long).Show();
        }

        protected override void OnResume()
        {
            base.OnResume();
            SM.RegisterListener(this, SM.GetDefaultSensor(SensorType.StepDetector), SensorDelay.Ui);
            Toast.MakeText(this, "REGISTER", ToastLength.Long).Show();
        }

        protected override void OnPause()
        {
            base.OnPause();
            SM.UnregisterListener(this);
            Toast.MakeText(this, "UNREGISTER", ToastLength.Long).Show();
        }                 
    }
}

