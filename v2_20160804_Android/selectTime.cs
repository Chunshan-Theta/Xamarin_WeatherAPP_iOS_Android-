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

namespace v1_20160722
{
    [Activity(Label = "selectTime")]
    public class selectTime : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set view
            SetContentView(Resource.Layout.SelectView);
            TextView Lab_RowTitle = FindViewById<TextView>(Resource.Id.Lab_RowTitle);
            Lab_RowTitle.Text = "時間";
            //get Data
            //    得到跳转到该Activity的Intent对象
            Bundle bundle = Intent.GetBundleExtra("bundle");
            List<string> timelist = bundle.GetStringArrayList("timelist").ToList();


            //Create your application here
            TableLayout MainTable = FindViewById<TableLayout>(Resource.Id.table_city);
            Button b;
            TableRow tr;
            for (int i = 0; i < timelist.Count; i++)
            {
                tr = new TableRow(this);
                
                b = new Button(this);
                string time = timelist[i].Substring(1, timelist[i].Length - 2);
                b.Text = time;
                b.Click+= delegate { CreatNewSelect("4"); };
                tr.AddView(b);

                MainTable.AddView(tr);
            }

             





        }


        private void CreatNewSelect(string time) {
            Intent deviceList = new Intent(this, typeof(MainActivity));

            deviceList.PutExtra("TargetTime", time);

            StartActivity(deviceList);
        }

    }
}