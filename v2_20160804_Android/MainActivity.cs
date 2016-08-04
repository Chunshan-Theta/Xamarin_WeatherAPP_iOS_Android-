using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using mobileShard;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace v1_20160722
{
    [Activity(Label = "v1_20160722", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {

        public JsonFile Jsondata;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            int dataindex = 0;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            //set Target City
            TextView Lab_SelectCity = FindViewById<TextView>(Resource.Id.Lab_SelectCity);
            Lab_SelectCity.Text = Intent.GetStringExtra("TargetCity")?? Lab_SelectCity.Text;

            //set Target timeww
            //string index = Intent.GetStringExtra("TargetTime") ?? "0";

            //refresh Weatherd Data
            updateWeatherdData(dataindex.ToString());


            Button Btu_selectcity = FindViewById<Button>(Resource.Id.Btu_SelectCity);
            Btu_selectcity.Click += delegate { selectCity(Jsondata.citylist); };

            Button Btu_NextDay = FindViewById<Button>(Resource.Id.NextDay);
            Btu_NextDay.Click += delegate 
            {
                dataindex += 8;
                updateWeatherdData(dataindex.ToString());
            };
            Button But_more = FindViewById<Button>(Resource.Id.But_more);
            But_more.Click += delegate
            {
                MoreData(dataindex.ToString(), Lab_SelectCity.Text);
            };
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }



        private void updateWeatherdData(string index)
        {

            TextView Lab_SelectCity = FindViewById<TextView>(Resource.Id.Lab_SelectCity);
            TextView Lab_CityName = FindViewById<TextView>(Resource.Id.Lab_CityName);
            TextView Lab_maxTempreature = FindViewById<TextView>(Resource.Id.Lab_maxTemperature);
            TextView Lab_minTemperature = FindViewById<TextView>(Resource.Id.Lab_minTemperature);
            TextView Lab_Datetime = FindViewById<TextView>(Resource.Id.Lab_Datetime);
            TextView Lab_description = FindViewById<TextView>(Resource.Id.Lab_description);
            
            Jsondata = new JsonFile(Lab_SelectCity.Text);
            Lab_CityName.Text = Jsondata.cityname;
            Lab_maxTempreature.Text = Jsondata.data[index]["maxTemperature"].ToString();
            Lab_minTemperature.Text = Jsondata.data[index]["minTemperature"].ToString();
            Lab_Datetime.Text = Jsondata.data[index]["date"]+"\n"+ Jsondata.data[index]["time"];
            Lab_description.Text = Jsondata.data[index]["description"].ToString();


            if (Jsondata.data[(Convert.ToInt32(index) + 8).ToString()]==null)
            {
                Button Btu_NextDay = FindViewById<Button>(Resource.Id.NextDay);
                Btu_NextDay.Enabled = false;
                Console.Write("updateWeatherdData null");
            }
        }



        private void selectCity(List<string> citylist) {
            Intent deviceList = new Intent(this, typeof(selectcity));

            Bundle bundle = new Bundle();　　//　　Bundle的底层是一个HashMap<String, Object
            bundle.PutStringArrayList("citylist", citylist);
            deviceList.PutExtra("bundle", bundle);

            StartActivity(deviceList);
        }
        private void MoreData(string index, string SelectCity)
        {
            Intent deviceList = new Intent(this, typeof(Detail));

            Bundle bundle = new Bundle();　　//　　Bundle的底层是一个HashMap<String, Object
            bundle.PutString("index",index);
            bundle.PutString("SelectCity", SelectCity);

            deviceList.PutExtra("bundle", bundle);

            StartActivity(deviceList);
        }


    }
}

