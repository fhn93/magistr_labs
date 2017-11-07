using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System;

namespace Lab2
{
    [Activity(Label = "Lab2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button load, save, clear;
        EditText editText;
        string f1 = "res1.txt";
        string Path;
        string f2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            load = FindViewById<Button>(Resource.Id.Load);
            save = FindViewById<Button>(Resource.Id.Save);
            clear = FindViewById<Button>(Resource.Id.Clear);
            editText = FindViewById<EditText>(Resource.Id.editText);

            Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            f2 =Path+f1;

           // editText.Text = f2;

            if (!File.Exists(f2))
            {
                using (var streamWriter = new StreamWriter(f2, true))
                {
                    streamWriter.WriteLine("Hi, world!");
                }
            }
            load.Click += LoadClick;
            save.Click += SaveClick;
            clear.Click += ClearClick;

            Load();
        }

        private void Load()
        {
            using (var streamReader = new StreamReader(f2))

            {
                string content = streamReader.ReadToEnd();
                editText.Text = content;
            }
        }

        private void LoadClick(object seder, EventArgs e)
        {
            Load();                  
        }

        private void SaveClick(object seder, EventArgs e)
        {
            editText.Text += "\n последнее изменение: "+DateTime.Now.ToString();
            using (var streamWrirer = new StreamWriter(f2))
                streamWrirer.Write(editText.Text.ToCharArray());
        }

        private void ClearClick(object sender,EventArgs e)
        {
            editText.Text = "";  
        }
    }
}

