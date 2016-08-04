using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using CoreGraphics;
using Newtonsoft.Json.Linq;

namespace v2_20160804_iOS
{
    class HogeDataSource : UIPageViewControllerDataSource
    {
        public List<UIViewController> Pages = new List<UIViewController>();
        public HogeDataSource(JObject JsonData, string index)
        {
            var redVC = new UIViewController();
            redVC.View.BackgroundColor = UIColor.Red;
            AddData(redVC, JsonData,(Convert.ToInt32(index)*8+2).ToString());
            Pages.Add(redVC);

            var blueVC = new UIViewController();
            blueVC.View.BackgroundColor = UIColor.Blue;
            AddData(blueVC, JsonData, (Convert.ToInt32(index) * 8 + 4).ToString().ToString());
            Pages.Add(blueVC);

            var yellowVC = new UIViewController();
            yellowVC.View.BackgroundColor = UIColor.Yellow;
            AddData(yellowVC, JsonData, (Convert.ToInt32(index) * 8 + 6).ToString().ToString());
            Pages.Add(yellowVC);



        }

        public override UIViewController GetPreviousViewController(
            UIPageViewController pageViewController, UIViewController referenceViewController)
        {

            var index = Pages.IndexOf(referenceViewController) - 1;
            if (index < 0)
            {
                //index = (Pages.Count - 1);
                return null;
            }

            return Pages.ElementAt(index);

        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = Pages.IndexOf(referenceViewController) + 1;
            if (index >= Pages.Count)
            {
                //index = 0;
                return null;
            }

            return Pages.ElementAt(index);

        }

        public override nint GetPresentationCount(UIPageViewController pageViewController)
        {
            return Pages.Count;
        }

        public override nint GetPresentationIndex(UIPageViewController pageViewController)
        {

            return Pages.IndexOf(Pages.First());
            //return 0;
        }
        public void AddData(UIViewController v, JObject hello, string index)
        {

            nfloat h = 31.0f;
            nfloat w = v.View.Bounds.Width;
            // keep the code the username UITextField
            try
            {
                UILabel usernameField = new UILabel()
                {
                    Text = "日期：" + hello[index]["date"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };
                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "時間：" + hello[index]["time"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);



                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "最高溫：" + hello[index]["maxTemperature"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "最低溫：" + hello[index]["minTemperature"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "濕度：" + hello[index]["humidity"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);


                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "陰天機率：" + hello[index]["chanceOfClouds"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "降雨量：" + hello[index]["volumeOfRain"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "氣候：" + hello[index]["description"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);


            }
            catch (Exception e)
            {

                UILabel usernameField = new UILabel()
                {
                    Text = "日期：" + hello["0"]["date"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };
                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "時間：" + hello["0"]["time"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);



                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "最高溫：" + hello["0"]["maxTemperature"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "最低溫：" + hello["0"]["minTemperature"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "濕度：" + hello["0"]["humidity"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);


                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "陰天機率：" + hello["0"]["chanceOfClouds"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "降雨量：" + hello["0"]["volumeOfRain"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

                h += 100f;
                usernameField = new UILabel()
                {
                    Text = "氣候：" + hello["0"]["description"],
                    Frame = new CGRect(10, 82, w - 20, h)
                };

                v.View.AddSubview(usernameField);

            }


        }
    }
}