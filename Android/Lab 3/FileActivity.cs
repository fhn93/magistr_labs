using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.IO;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Runtime;


namespace lab3
{
    public static class Intermediate
    {
        public static string fileName;
    }

    [Activity(Label = "Файлы", MainLauncher = true)]
    public class FileActivity : Activity
    {
        string path;
        private ListView fileList;
        private List<string> filenames = new List<string>();
        Button Edit, Add, Chage;
        EditText _File;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); 
            SetContentView(Resource.Layout.Files);


            Edit = FindViewById<Button>(Resource.Id.Edit);
            Add = FindViewById<Button>(Resource.Id.New);
            Chage = FindViewById<Button>(Resource.Id.Change);
            fileList = FindViewById<ListView>(Resource.Id.fileList);
            _File = FindViewById<EditText>(Resource.Id.FileName);

            path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            LoadFileList();

            Edit.Click += EditClick;
            fileList.ItemClick += FileList_ItemClick;
            Add.Click += AddClick;
            Chage.Click += ChageClick;
        }

        private void ChageClick(object sender, EventArgs e)
        {

            using ( var ss=new StreamReader(Intermediate.fileName))
            {
                string s = ss.ReadToEnd();
                Create_file(path, _File.Text, s);
            }
            System.IO.File.Delete(Intermediate.fileName);
            LoadFileList();
        }

        private void AddClick(object sender, EventArgs e)
        {
            if(_File.Text!=null)
            {
                Create_file(path, _File.Text, "");
                LoadFileList();
            }
            else Toast.MakeText(this, "Имя не задано", ToastLength.Long).Show();

        }

        private void EditClick(object sender, EventArgs e)
        {
            if (Intermediate.fileName != null)
                StartActivity(typeof(EditActivity));
            else NotSelect();
        }

        private void FileList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {  
            Intermediate.fileName =Path.Combine( path , filenames[e.Position]);
            Toast.MakeText(this, Intermediate.fileName, ToastLength.Long).Show();
        }

        private void Create_file(string p, string f, string s)
        {
            File.WriteAllText(Path.Combine(p, f), s);
        }
        
        private void NotSelect()
        {
            Toast.MakeText(this, "файл не выбран", ToastLength.Long).Show();
        }     
        
        private void LoadFileList()
        {                                  

            
            var files = System.IO.Directory.GetFiles(path);
            if (files.Length <= 0)
            {
                Create_file(path, "file1", "text1");
                Create_file(path, "file2", "text2");
                Create_file(path, "file3", "text3");
            }

            foreach (string f in files)
            {
                filenames.Add(Path.GetFileName(f));
            }

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, filenames);
            adapter.NotifyDataSetChanged();
            fileList.Adapter = adapter;
        }
    }
}

