using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mobileShard;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using ActionBarViewPage;
using Android.Support.V4.App;

namespace v1_20160722
{
    [Activity(Label = "Detail")]
    public class Detail : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //get Data
            //    得到跳转到该Activity的Intent对象
            Bundle bundle = Intent.GetBundleExtra("bundle");
            string index = bundle.GetString("index");
            //string SelectCity = bundle.GetString("SelectCity");
            string SelectCity = bundle.GetString("Taiwan");

            JsonFile Jsondata = new JsonFile(SelectCity);       
            
            
            
            
            
            
            
            
            
            
            
            
            // Create your application here
            SetContentView(Resource.Layout.Detail);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            var adaptor = new GenericFragmentPagerAdaptor(SupportFragmentManager);

            adaptor.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.tab, v, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                sampleTextView.Text = "日期: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["date"] + "\n" +
                                      "時間: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["time"] + "\n" +
                                      "最高溫: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["maxTemperature"] + "\n" +
                                      "最低溫: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["minTemperature"] + "\n" +
                                      "humidity: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["humidity"] + "\n" +
                                      "chanceOfClouds: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["chanceOfClouds"] + "\n" +
                                      "降雨量: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["volumeOfRain"] + "\n" +
                                      "氣候: " + Jsondata.data[(Convert.ToInt32(index) + 2).ToString()]["description"] + "\n" ;

                return view;
            }
            );

            adaptor.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.tab, v, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                sampleTextView.Text = "日期: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["date"] + "\n" +
                                      "時間: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["time"] + "\n" +
                                      "最高溫: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["maxTemperature"] + "\n" +
                                      "最低溫: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["minTemperature"] + "\n" +
                                      "humidity: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["humidity"] + "\n" +
                                      "chanceOfClouds: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["chanceOfClouds"] + "\n" +
                                      "降雨量: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["volumeOfRain"] + "\n" +
                                      "氣候: " + Jsondata.data[(Convert.ToInt32(index) + 4).ToString()]["description"] + "\n";
                return view;
            }
            );

            adaptor.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.tab, v, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                sampleTextView.Text = "日期: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["date"] + "\n" +
                                      "時間: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["time"] + "\n" +
                                      "最高溫: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["maxTemperature"] + "\n" +
                                      "最低溫: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["minTemperature"] + "\n" +
                                      "humidity: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["humidity"] + "\n" +
                                      "chanceOfClouds: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["chanceOfClouds"] + "\n" +
                                      "降雨量: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["volumeOfRain"] + "\n" +
                                      "氣候: " + Jsondata.data[(Convert.ToInt32(index) + 6).ToString()]["description"] + "\n";
                return view;
            }
            );





            pager.Adapter = adaptor;
            //pager.SetOnPageChangeListener(new ViewPageListenerForActionBar(ActionBar));
            pager.AddOnPageChangeListener(new ViewPageListenerForActionBar(ActionBar));



            ActionBar.AddTab(pager.GetViewPageTab(ActionBar, "早上"));
            ActionBar.AddTab(pager.GetViewPageTab(ActionBar, "中午"));
            ActionBar.AddTab(pager.GetViewPageTab(ActionBar, "晚上"));
        }
    }
}