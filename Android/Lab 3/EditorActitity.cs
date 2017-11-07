using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;   
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;      
using System.IO;


namespace lab3
{
    [Activity(Label = "Редактор")]
    public class EditActivity : Activity
    {
        EditText text;
        Button Save, Back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Editor);

            Back = FindViewById<Button>(Resource.Id.TosMain);
            Save = FindViewById<Button>(Resource.Id.save);
            text = FindViewById<EditText>(Resource.Id.text);


            Back.Click += delegate { StartActivity(typeof(FileActivity)); };
            Save.Click += SaveClick;

            using (var s = new StreamReader(Intermediate.fileName))
            {
                string SS = s.ReadToEnd();
                text.Text = SS;
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            text.Text += "\n последнее изменение: " + DateTime.Now.ToString();
            using (var streamWrirer = new StreamWriter(Intermediate.fileName) )
                streamWrirer.Write(text.Text.ToCharArray());
            Toast.MakeText(this, "Изменения сохранены", ToastLength.Long).Show();
        }
    }
}