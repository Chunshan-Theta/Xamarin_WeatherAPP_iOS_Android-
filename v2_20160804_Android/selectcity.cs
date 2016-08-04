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
    [Activity(Label = "selectcity")]
    public class selectcity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set view
            SetContentView(Resource.Layout.SelectView);
            TextView Lab_RowTitle = FindViewById<TextView>(Resource.Id.Lab_RowTitle);
            Lab_RowTitle.Text = "城市";
            //get Data
            //    得到跳转到该Activity的Intent对象
            Bundle bundle = Intent.GetBundleExtra("bundle");
            List<string> citylist = bundle.GetStringArrayList("citylist").ToList();


            //Create your application here
            TableLayout MainTable = FindViewById<TableLayout>(Resource.Id.table_city);
            Button b;
            TableRow tr;
            for (int i = 0; i < citylist.Count; i++)
            {
                tr = new TableRow(this);
                
                b = new Button(this);
                //string cityname = citylist[i].Substring(1, citylist[i].Length - 2);
                string cityname = citylist[i];
                b.Text = cityname;
                b.Click+= delegate { CreatNewSelect(cityname); };
                tr.AddView(b);

                MainTable.AddView(tr);
            }

             





        }


        private void CreatNewSelect(string city) {
            Intent deviceList = new Intent(this, typeof(MainActivity));

            deviceList.PutExtra("TargetCity",city);

            StartActivity(deviceList);
        }

    }
}