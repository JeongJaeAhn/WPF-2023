using MahApps.Metro.Controls;
using Newtonsoft.Json.Linq;
using openApi.Logics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace openApi
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnReq_Click(object sender, RoutedEventArgs e)
        {
            string ServiceKey= "AWwhSz9OBMFFTH5%2FYfKcpY0u3J2wQIVObIhlvO36GgRAmJVOkFGqBLNwYFBXKjuMnxEhOvKM3Tv%2B%2Bo%2B4u9nZZw%3D%3D";
            string openApiUri = $"https://apis.data.go.kr/6260000/AttractionService/getAttractionKr?serviceKey={ServiceKey}&pageNo=1&numOfRows=100&resultType=json";
            string result = string.Empty;            

            // WebRequest, WebResponse 객체
            WebRequest req = null;
            WebResponse res = null;
            StreamReader reader = null;

            try
            {
                req = WebRequest.Create(openApiUri);
                res = await req.GetResponseAsync();
                reader = new StreamReader(res.GetResponseStream());
                result = reader.ReadToEnd();

                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"OpenAPI 조회오류 {ex.Message}");
            }

            var jsonResult = JObject.Parse(result);
            var code = Convert.ToString(jsonResult["getAttractionKr"]["header"]["code"]);


            try
            {
                if (code == "00")
                {
                    var data = jsonResult["getAttractionKr"]["item"];
                    var json_array = data as JArray;

                    var festivals = new List<Festival>();
                    foreach (var festival in json_array)
                    {
                        festivals.Add(new Festival
                        {
                            uc_seq = Convert.ToInt32(festival["UC_SEQ"]),
                            main_title = Convert.ToString(festival["MAIN_TITLE"]),
                            gugun_nm = Convert.ToString(festival["GUGUN_NM"]),
                            lat = Convert.ToDouble(festival["LAT"]),
                            lng = Convert.ToDouble(festival["LNG"]),
                            place = Convert.ToString(festival["PLACE"]),
                            title = Convert.ToString(festival["TITLE"]),
                            subtitle = Convert.ToString(festival["SUBTITLE"]),
                            addr1 = Convert.ToString(festival["ADDR1"]),
                            cntct_tel = Convert.ToString(festival["CNTCT_TEL"]),
                            homepage_url = Convert.ToString(festival["HOMEPAGE_URL"]),
                            trfc_info = Convert.ToString(festival["TRFC_INFO"]),
                            usage_day = Convert.ToString(festival["USAGE_DAY"]),
                            hldy_info = Convert.ToString(festival["HLDY_INFO"]),
                            usage_day_week_and_time = Convert.ToString(festival["USAGE_DAY_WEEK_AND_TIME"]),
                            usage_amount = Convert.ToString(festival["USAGE_AMOUNT"]),
                            middle_size_rm1 = Convert.ToString(festival["MIDDLE_SIZE_RM1"]),
                            main_img_normal = Convert.ToString(festival["MAIN_IMG_NORMAL"]),
                            //main_img_thumb = Convert.ToString(festival["MAIN_IMG_THUMB"]),
                            itemcntnts = Convert.ToString(festival["ITEMCNTNTS"])                            
                        });
                    }
                    this.DataContext = festivals;
                }
            }
            catch (Exception)
            {

                throw;
            }          
        }        
    }
}