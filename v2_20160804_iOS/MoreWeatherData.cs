using Foundation;
using Newtonsoft.Json.Linq;
using System;

using System.Linq;
using UIKit;

namespace v2_20160804_iOS
{
    public partial class MoreWeatherData : UIPageViewController
    {
        
        public JObject JsonData { get; set; }
        public string index { get; set; }
        public MoreWeatherData(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {

            base.ViewDidLoad();


            HogeDataSource dataSource = new HogeDataSource(this.JsonData, this.index);
            DataSource = dataSource;
            

            SetViewControllers(new[] { dataSource.Pages.ElementAt(0) }, UIPageViewControllerNavigationDirection.Forward, true, null);


        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }
    }
}