using System;
using System.Collections.Generic;

using System.Net;
using System.IO;

using Newtonsoft.Json;
using Org.Apache.Http.Conn.Schemes;
using Newtonsoft.Json.Linq;

namespace mobileShard
{
    public class JsonFile
    {
        public string result;        
        public JObject data;
        public string cityname;
        public List<string> citylist;
        public List<string> DataTimelist;
        public JObject futureData;

        public JsonTextReader reader;
        public JsonFile(string TargetCity)
        {

            //this.result = FetchWeatherAsync("URL of Json: http://.........");
            /*
            this.result = @"{              
             {
                '0':{'weather_id':'1024','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'866','humidity':'96','volumeOfRain':'1','chanceOfClouds':'92','time':'00:00:00','date':'2016-08-04','description':'light rain'},
                '1':{'weather_id':'1025','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'866','humidity':'98','volumeOfRain':'8','chanceOfClouds':'92','time':'03:00:00','date':'2016-08-04','description':'moderate rain'},
                '2':{'weather_id':'1367','location_id':'3','maxTemperature':'24','minTemperature':'24','pressure':'867','humidity':'84','volumeOfRain':'5','chanceOfClouds':'64','time':'06:00:00','date':'2016-08-04','description':'moderate rain'},
                '3':{'weather_id':'1368','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'867','humidity':'94','volumeOfRain':'7','chanceOfClouds':'56','time':'09:00:00','date':'2016-08-04','description':'moderate rain'},
                '4':{'weather_id':'1369','location_id':'3','maxTemperature':'20','minTemperature':'20','pressure':'868','humidity':'95','volumeOfRain':'0','chanceOfClouds':'32','time':'12:00:00','date':'2016-08-04','description':'light rain'},
                '5':{'weather_id':'1370','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'868','humidity':'95','volumeOfRain':'0','chanceOfClouds':'0','time':'15:00:00','date':'2016-08-04','description':'clear sky'},
                '6':{'weather_id':'1371','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'867','humidity':'95','volumeOfRain':'0','chanceOfClouds':'12','time':'18:00:00','date':'2016-08-04','description':'few clouds'},
                '7':{'weather_id':'1372','location_id':'3','maxTemperature':'17','minTemperature':'17','pressure':'867','humidity':'96','volumeOfRain':'0','chanceOfClouds':'0','time':'21:00:00','date':'2016-08-04','description':'light rain'},
                '8':{'weather_id':'1373','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'867','humidity':'85','volumeOfRain':'0','chanceOfClouds':'0','time':'00:00:00','date':'2016-08-05','description':'clear sky'},
                '9':{'weather_id':'1374','location_id':'3','maxTemperature':'26','minTemperature':'26','pressure':'867','humidity':'67','volumeOfRain':'0','chanceOfClouds':'0','time':'03:00:00','date':'2016-08-05','description':'light rain'},'10':{'weather_id':'1375','location_id':'3','maxTemperature':'23','minTemperature':'23','pressure':'866','humidity':'83','volumeOfRain':'4','chanceOfClouds':'56','time':'06:00:00','date':'2016-08-05','description':'moderate rain'},'11':{'weather_id':'1376','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'865','humidity':'85','volumeOfRain':'2','chanceOfClouds':'64','time':'09:00:00','date':'2016-08-05','description':'light rain'},'12':{'weather_id':'1377','location_id':'3','maxTemperature':'20','minTemperature':'20','pressure':'866','humidity':'94','volumeOfRain':'0','chanceOfClouds':'44','time':'12:00:00','date':'2016-08-05','description':'light rain'},'13':{'weather_id':'1378','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'866','humidity':'97','volumeOfRain':'0','chanceOfClouds':'56','time':'15:00:00','date':'2016-08-05','description':'light rain'},'14':{'weather_id':'1379','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'865','humidity':'98','volumeOfRain':'0','chanceOfClouds':'56','time':'18:00:00','date':'2016-08-05','description':'light rain'},'15':{'weather_id':'1380','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'865','humidity':'98','volumeOfRain':'0','chanceOfClouds':'32','time':'21:00:00','date':'2016-08-05','description':'light rain'},'16':{'weather_id':'1381','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'865','humidity':'82','volumeOfRain':'0','chanceOfClouds':'0','time':'00:00:00','date':'2016-08-06','description':'light rain'},'17':{'weather_id':'1382','location_id':'3','maxTemperature':'26','minTemperature':'26','pressure':'864','humidity':'59','volumeOfRain':'0','chanceOfClouds':'20','time':'03:00:00','date':'2016-08-06','description':'few clouds'},'18':{'weather_id':'1383','location_id':'3','maxTemperature':'28','minTemperature':'28','pressure':'863','humidity':'52','volumeOfRain':'0','chanceOfClouds':'20','time':'06:00:00','date':'2016-08-06','description':'light rain'},'19':{'weather_id':'1588','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'863','humidity':'89','volumeOfRain':'3','chanceOfClouds':'64','time':'09:00:00','date':'2016-08-06','description':'moderate rain'},'20':{'weather_id':'1589','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'863','humidity':'95','volumeOfRain':'0','chanceOfClouds':'44','time':'12:00:00','date':'2016-08-06','description':'light rain'},'21':{'weather_id':'1590','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'863','humidity':'97','volumeOfRain':'0','chanceOfClouds':'64','time':'15:00:00','date':'2016-08-06','description':'light rain'},'22':{'weather_id':'1591','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'862','humidity':'96','volumeOfRain':'0','chanceOfClouds':'44','time':'18:00:00','date':'2016-08-06','description':'light rain'},'23':{'weather_id':'1592','location_id':'3','maxTemperature':'17','minTemperature':'17','pressure':'862','humidity':'97','volumeOfRain':'0','chanceOfClouds':'0','time':'21:00:00','date':'2016-08-06','description':'light rain'},'24':{'weather_id':'1593','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'862','humidity':'83','volumeOfRain':'0','chanceOfClouds':'8','time':'00:00:00','date':'2016-08-07','description':'clear sky'},'25':{'weather_id':'1594','location_id':'3','maxTemperature':'25','minTemperature':'25','pressure':'862','humidity':'70','volumeOfRain':'0','chanceOfClouds':'20','time':'03:00:00','date':'2016-08-07','description':'light rain'},'26':{'weather_id':'1595','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'861','humidity':'91','volumeOfRain':'3','chanceOfClouds':'92','time':'06:00:00','date':'2016-08-07','description':'moderate rain'},'27':{'weather_id':'1596','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'861','humidity':'83','volumeOfRain':'0','chanceOfClouds':'88','time':'09:00:00','date':'2016-08-07','description':'light rain'}}
            }";
            */
            this.result = @"{'0':{'weather_id':'1024','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'866','humidity':'96','volumeOfRain':'1','chanceOfClouds':'92','time':'00:00:00','date':'2016-08-04','description':'light rain'},'1':{'weather_id':'1025','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'866','humidity':'98','volumeOfRain':'8','chanceOfClouds':'92','time':'03:00:00','date':'2016-08-04','description':'moderate rain'},'2':{'weather_id':'1367','location_id':'3','maxTemperature':'24','minTemperature':'24','pressure':'867','humidity':'84','volumeOfRain':'5','chanceOfClouds':'64','time':'06:00:00','date':'2016-08-04','description':'moderate rain'},'3':{'weather_id':'1368','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'867','humidity':'94','volumeOfRain':'7','chanceOfClouds':'56','time':'09:00:00','date':'2016-08-04','description':'moderate rain'},'4':{'weather_id':'1369','location_id':'3','maxTemperature':'20','minTemperature':'20','pressure':'868','humidity':'95','volumeOfRain':'0','chanceOfClouds':'32','time':'12:00:00','date':'2016-08-04','description':'light rain'},'5':{'weather_id':'1370','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'868','humidity':'95','volumeOfRain':'0','chanceOfClouds':'0','time':'15:00:00','date':'2016-08-04','description':'clear sky'},'6':{'weather_id':'1371','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'867','humidity':'95','volumeOfRain':'0','chanceOfClouds':'12','time':'18:00:00','date':'2016-08-04','description':'few clouds'},'7':{'weather_id':'1372','location_id':'3','maxTemperature':'17','minTemperature':'17','pressure':'867','humidity':'96','volumeOfRain':'0','chanceOfClouds':'0','time':'21:00:00','date':'2016-08-04','description':'light rain'},'8':{'weather_id':'1373','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'867','humidity':'85','volumeOfRain':'0','chanceOfClouds':'0','time':'00:00:00','date':'2016-08-05','description':'clear sky'},'9':{'weather_id':'1374','location_id':'3','maxTemperature':'26','minTemperature':'26','pressure':'867','humidity':'67','volumeOfRain':'0','chanceOfClouds':'0','time':'03:00:00','date':'2016-08-05','description':'light rain'},'10':{'weather_id':'1375','location_id':'3','maxTemperature':'23','minTemperature':'23','pressure':'866','humidity':'83','volumeOfRain':'4','chanceOfClouds':'56','time':'06:00:00','date':'2016-08-05','description':'moderate rain'},'11':{'weather_id':'1376','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'865','humidity':'85','volumeOfRain':'2','chanceOfClouds':'64','time':'09:00:00','date':'2016-08-05','description':'light rain'},'12':{'weather_id':'1377','location_id':'3','maxTemperature':'20','minTemperature':'20','pressure':'866','humidity':'94','volumeOfRain':'0','chanceOfClouds':'44','time':'12:00:00','date':'2016-08-05','description':'light rain'},'13':{'weather_id':'1378','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'866','humidity':'97','volumeOfRain':'0','chanceOfClouds':'56','time':'15:00:00','date':'2016-08-05','description':'light rain'},'14':{'weather_id':'1379','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'865','humidity':'98','volumeOfRain':'0','chanceOfClouds':'56','time':'18:00:00','date':'2016-08-05','description':'light rain'},'15':{'weather_id':'1380','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'865','humidity':'98','volumeOfRain':'0','chanceOfClouds':'32','time':'21:00:00','date':'2016-08-05','description':'light rain'},'16':{'weather_id':'1381','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'865','humidity':'82','volumeOfRain':'0','chanceOfClouds':'0','time':'00:00:00','date':'2016-08-06','description':'light rain'},'17':{'weather_id':'1382','location_id':'3','maxTemperature':'26','minTemperature':'26','pressure':'864','humidity':'59','volumeOfRain':'0','chanceOfClouds':'20','time':'03:00:00','date':'2016-08-06','description':'few clouds'},'18':{'weather_id':'1383','location_id':'3','maxTemperature':'28','minTemperature':'28','pressure':'863','humidity':'52','volumeOfRain':'0','chanceOfClouds':'20','time':'06:00:00','date':'2016-08-06','description':'light rain'},'19':{'weather_id':'1588','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'863','humidity':'89','volumeOfRain':'3','chanceOfClouds':'64','time':'09:00:00','date':'2016-08-06','description':'moderate rain'},'20':{'weather_id':'1589','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'863','humidity':'95','volumeOfRain':'0','chanceOfClouds':'44','time':'12:00:00','date':'2016-08-06','description':'light rain'},'21':{'weather_id':'1590','location_id':'3','maxTemperature':'19','minTemperature':'19','pressure':'863','humidity':'97','volumeOfRain':'0','chanceOfClouds':'64','time':'15:00:00','date':'2016-08-06','description':'light rain'},'22':{'weather_id':'1591','location_id':'3','maxTemperature':'18','minTemperature':'18','pressure':'862','humidity':'96','volumeOfRain':'0','chanceOfClouds':'44','time':'18:00:00','date':'2016-08-06','description':'light rain'},'23':{'weather_id':'1592','location_id':'3','maxTemperature':'17','minTemperature':'17','pressure':'862','humidity':'97','volumeOfRain':'0','chanceOfClouds':'0','time':'21:00:00','date':'2016-08-06','description':'light rain'},'24':{'weather_id':'1593','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'862','humidity':'83','volumeOfRain':'0','chanceOfClouds':'8','time':'00:00:00','date':'2016-08-07','description':'clear sky'},'25':{'weather_id':'1594','location_id':'3','maxTemperature':'25','minTemperature':'25','pressure':'862','humidity':'70','volumeOfRain':'0','chanceOfClouds':'20','time':'03:00:00','date':'2016-08-07','description':'light rain'},'26':{'weather_id':'1595','location_id':'3','maxTemperature':'21','minTemperature':'21','pressure':'861','humidity':'91','volumeOfRain':'3','chanceOfClouds':'92','time':'06:00:00','date':'2016-08-07','description':'moderate rain'},'27':{'weather_id':'1596','location_id':'3','maxTemperature':'22','minTemperature':'22','pressure':'861','humidity':'83','volumeOfRain':'0','chanceOfClouds':'88','time':'09:00:00','date':'2016-08-07','description':'light rain'}}";
            this.data = JObject.Parse(this.result.ToString());
            this.cityname = searchCityname(this.data["0"]["location_id"].ToString());
            listtime(this.data["0"]["location_id"].ToString());

            
            
            Console.WriteLine(this.result);
            

            //Console.WriteLine("(╯°□°）╯︵ ┻━┻ノ( ゜-゜ノ)");


        }





        public string searchCityname(string cityid)
        {
            List<string> list = new List<string>();
            

            String JsonString = @"{'0':{'location_id':'1','latitude':'25','longitude':'121','city':'Taipei','country':'TW'},'1':{'location_id':'2','latitude':'35','longitude':'137','city':'Osaka','country':'JP'},'2':{'location_id':'3','latitude':'24','longitude':'121','city':'Taiwan','country':'TW'},'3':{'location_id':'4','latitude':'25','longitude':'121','city':'Xianeibu','country':'TW'},'4':{'location_id':'5','latitude':'22','longitude':'120','city':'Tainan','country':'TW'},'5':{'location_id':'6','latitude':'35','longitude':'139','city':'Marunouchi','country':'JP'},'6':{'location_id':'7','latitude':'35','longitude':'139','city':'Japan','country':'JP'},'7':{'location_id':'8','latitude':'33','longitude':'130','city':'Fukuoka-shi','country':'JP'},'8':{'location_id':'9','latitude':'30','longitude':'75','city':'Maler Kotla','country':'IN'},'9':{'location_id':'10','latitude':'60','longitude':'24','city':'Kallio','country':'FI'},'10':{'location_id':'11','latitude':'52','longitude':'13','city':'Tiergarten','country':'DE'},'11':{'location_id':'12','latitude':'49','longitude':'140','city':'Us\u2019ka-Orochskaya','country':'RU'},'12':{'location_id':'13','latitude':'36','longitude':'138','city':'Suzaka','country':'JP'},'13':{'location_id':'14','latitude':'35','longitude':'139','city':'Tokyo','country':'JP'},'14':{'location_id':'15','latitude':'28','longitude':'84','city':'Thonje','country':'NP'},'15':{'location_id':'16','latitude':'35','longitude':'135','city':'Kyoto','country':'JP'},'16':{'location_id':'17','latitude':'34','longitude':'133','city':'Hakata','country':'JP'},'17':{'location_id':'19','latitude':'60','longitude':'25','city':'Vantaa','country':'FI'},'18':{'location_id':'20','latitude':'30','longitude':'75','city':'M\u0101ler Kotla','country':'IN'},'19':{'location_id':'21','latitude':'51','longitude':'-1','city':'Slough','country':'GB'}}";
            JObject Jsondata = JObject.Parse(JsonString);
            string result = "not found";
            for (int i = 0; i < Jsondata.Count; i++)
            {
                if (Jsondata[i.ToString()]["location_id"].ToString() == cityid)
                {
                    result = Jsondata[i.ToString()]["city"].ToString();
                }

                list.Add((Jsondata[i.ToString()]["city"]).ToString());
            }
            citylist =  list;
            Console.WriteLine("(╯°□°）╯︵ ┻━┻ノ( ゜-゜ノ)");
            Console.WriteLine(Jsondata.ToString());
            return result;


        }

        public void listtime(string cityid)
        {
            List<string> Datalist = new List<string>();
            JObject Jsondata = data;
            for (int i = 0; i < Jsondata.Count; i++)
            {
                string date = (Jsondata[i.ToString()]["date"]).ToString();
                string index = (Jsondata[i.ToString()]["weather_id"]).ToString();
                if (!Datalist.Contains(date)) {
                    Datalist.Add(date);
                }
                
            }
            DataTimelist = Datalist;
            


        }



        public string FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));

            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    StreamReader streamreader = new StreamReader(stream);
                    string content = streamreader.ReadToEnd();
                    //Console.Out.WriteLine("Response: {0}", content.ToString());
                    streamreader.Close();
                    stream.Close();
                    // Return the JSON document:
                    return content;
                }
            }
        }





    }
    



   


}
