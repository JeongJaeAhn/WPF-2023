using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;

namespace openApi.Logics
{
    public class Festival
    {
        public int numOfRows {  get; set; }
        public int pageNo { get; set; }
        public int totalCount {get; set; }
        public int uc_seq {  get; set; }
        public string main_title { get; set; }
        public string gugun_nm { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string place { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string addr1 { get; set; }
        public string cntct_tel { get; set; }
        public string homepage_url { get; set; }
        public string trfc_info { get; set; }
        public string usage_day { get; set; }
        public string hldy_info { get; set; }
        public string usage_day_week_and_time { get; set; }
        public string usage_amount { get; set; }
        public string middle_size_rm1 { get; set; }
        public string main_img_normal { get; set; }
        public BitmapImage main_img_thumb { get; set; }
        public string itemcntnts { get; set; }
    }
}
