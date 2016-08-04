// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace v2_20160804_iOS
{
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Btn_more { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Btn_picktime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Btn_selectCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField input_cityname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lab_city { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lab_date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lab_MaxTemperature { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lab_MinTemperature { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lab_time { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Btn_more != null) {
                Btn_more.Dispose ();
                Btn_more = null;
            }

            if (Btn_picktime != null) {
                Btn_picktime.Dispose ();
                Btn_picktime = null;
            }

            if (Btn_selectCity != null) {
                Btn_selectCity.Dispose ();
                Btn_selectCity = null;
            }

            if (input_cityname != null) {
                input_cityname.Dispose ();
                input_cityname = null;
            }

            if (Lab_city != null) {
                Lab_city.Dispose ();
                Lab_city = null;
            }

            if (Lab_date != null) {
                Lab_date.Dispose ();
                Lab_date = null;
            }

            if (Lab_MaxTemperature != null) {
                Lab_MaxTemperature.Dispose ();
                Lab_MaxTemperature = null;
            }

            if (Lab_MinTemperature != null) {
                Lab_MinTemperature.Dispose ();
                Lab_MinTemperature = null;
            }

            if (Lab_time != null) {
                Lab_time.Dispose ();
                Lab_time = null;
            }
        }
    }
}