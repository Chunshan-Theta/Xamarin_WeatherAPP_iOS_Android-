using Foundation;
using mobileShard;
using System;
using UIKit;

namespace v2_20160804_iOS
{
    public partial class MainView : UIViewController
    {
        public JsonFile weather;
        public string postid="0";
        public MainView (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.Btn_selectCity.TouchUpInside += Btn_selectCity_TouchUpInside;
            this.Btn_picktime.TouchUpInside += Btu_picktime_TouchUpInside;
            this.Btn_more.TouchUpInside += Btu_More_TouchUpInside;


            updateWeatherData("taiwan");




        }

        private void Btn_selectCity_TouchUpInside(object sender, EventArgs e)
        {

            // Create a new Alert Controller
            UIAlertController actionSheetAlert = UIAlertController.Create("Action Sheet", "Select an item from below", UIAlertControllerStyle.ActionSheet);

            // Add Actions
            foreach (string cityname in weather.citylist)
            {
                //string cityname_ = cityname.Substring(1, cityname.Length - 2);
                string cityname_ = cityname;

                //actionSheetAlert.AddAction(UIAlertAction.Create(cityname_, UIAlertActionStyle.Default, (action) => updateWeatherData(cityname_)));
                actionSheetAlert.AddAction(UIAlertAction.Create(cityname_, UIAlertActionStyle.Default, (action) => updateWeatherData("Taiwan")));
            }


            actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

            // Required for iPad - You must specify a source for the Action Sheet since it is
            // displayed as a popover
            UIPopoverPresentationController presentationPopover = actionSheetAlert.PopoverPresentationController;
            if (presentationPopover != null)
            {
                presentationPopover.SourceView = this.View;
                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
            }

            // Display the alert 
            this.PresentViewController(actionSheetAlert, true, null);
        }

        private void updateWeatherData(string cityname)
        {

            this.input_cityname.Text = cityname;
            weather = new JsonFile(this.input_cityname.Text);

            Lab_city.Text = "city: " + weather.cityname;
            Lab_date.Text = "date: " + weather.data["0"]["date"];
            Lab_time.Text = "time: " + weather.data["0"]["time"];
            Lab_MaxTemperature.Text = "maxTemperature: " + weather.data["0"]["maxTemperature"];
            Lab_MinTemperature.Text = "minTemperature: " + weather.data["0"]["minTemperature"];
            
            
            Console.WriteLine("Response 11111");

        }
        private void PickTime(string index)
        {
            postid = index;
            try
            {
               
                Lab_city.Text = "city: " + weather.cityname;
                Lab_date.Text = "date: " + weather.data[index.ToString()]["date"];
                Lab_time.Text = "time: " + weather.data[index.ToString()]["time"];
                Lab_MaxTemperature.Text = "maxTemperature: " + weather.data[index.ToString()]["maxTemperature"];
                Lab_MinTemperature.Text = "minTemperature: " + weather.data[index.ToString()]["minTemperature"];
                Console.WriteLine("Response 11111");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);


                UIAlertController actionSheetAlertdate = UIAlertController.Create("error", "沒發現該時段資料", UIAlertControllerStyle.ActionSheet);
                UIPopoverPresentationController presentationPopover2 = actionSheetAlertdate.PopoverPresentationController;
                if (presentationPopover2 != null)
                {
                    presentationPopover2.SourceView = this.View;
                    presentationPopover2.PermittedArrowDirections = UIPopoverArrowDirection.Up;
                }

                this.PresentViewController(actionSheetAlertdate, true, null);


                Lab_city.Text = "city: " + weather.cityname;
                Lab_date.Text = "date: " + weather.data["0"]["date"];
                Lab_time.Text = "time: " + weather.data["0"]["time"];
                Lab_MaxTemperature.Text = "maxTemperature: " + weather.data["0"]["maxTemperature"];
                Lab_MinTemperature.Text = "minTemperature: " + weather.data["0"]["minTemperature"];
                Console.WriteLine("Response 11111");
            }


        }



        private void Btu_picktime_TouchUpInside(object sender, EventArgs e)
        {
            UIAlertController actionSheetAlertdate = UIAlertController.Create("選擇時間", "請問是要哪天資料呢？", UIAlertControllerStyle.ActionSheet);

            // Add Actions
            actionSheetAlertdate.AddAction(UIAlertAction.Create("今天", UIAlertActionStyle.Default, (action) => selectTime(0)));
            actionSheetAlertdate.AddAction(UIAlertAction.Create("明天", UIAlertActionStyle.Default, (action) => selectTime(8)));
            actionSheetAlertdate.AddAction(UIAlertAction.Create("後天", UIAlertActionStyle.Default, (action) => selectTime(16)));
            actionSheetAlertdate.AddAction(UIAlertAction.Create("大後天", UIAlertActionStyle.Default, (action) => selectTime(24)));

            actionSheetAlertdate.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

            UIPopoverPresentationController presentationPopover2 = actionSheetAlertdate.PopoverPresentationController;
            if (presentationPopover2 != null)
            {
                presentationPopover2.SourceView = this.View;
                presentationPopover2.PermittedArrowDirections = UIPopoverArrowDirection.Up;
            }

            // Display the alert
            this.PresentViewController(actionSheetAlertdate, true, null);

        }

        private void selectTime(int index)
        {
            // Create a new Alert Controller
            UIAlertController actionSheetAlertTime = UIAlertController.Create("選擇時間", "是要哪個時段呢？", UIAlertControllerStyle.ActionSheet);

            // Add Actions

            actionSheetAlertTime.AddAction(UIAlertAction.Create("早上", UIAlertActionStyle.Default, (action) => PickTime((index + 2).ToString())));
            actionSheetAlertTime.AddAction(UIAlertAction.Create("中午", UIAlertActionStyle.Default, (action) => PickTime((index + 4).ToString())));
            actionSheetAlertTime.AddAction(UIAlertAction.Create("晚上", UIAlertActionStyle.Default, (action) => PickTime((index + 6).ToString())));

            actionSheetAlertTime.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

            UIPopoverPresentationController presentationPopover = actionSheetAlertTime.PopoverPresentationController;
            if (presentationPopover != null)
            {
                presentationPopover.SourceView = this.View;
                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
            }

            // Display the alert
            this.PresentViewController(actionSheetAlertTime, true, null);
        }


        private void Btu_More_TouchUpInside(object sender, EventArgs e)
        {
            MoreWeatherData secendpage = AppDelegate.MainStoryboard.InstantiateViewController("MoreWeatherData") as MoreWeatherData;
            secendpage.JsonData = weather.data;
            string index = Math.Floor(Convert.ToDouble(this.postid) / 8) != 0 ? Math.Floor(Convert.ToDouble(this.postid) / 8).ToString():"0";
            secendpage.index = index  ;
            AppDelegate.RootNavigationController.PushViewController(secendpage, true);

        }

    }










}
