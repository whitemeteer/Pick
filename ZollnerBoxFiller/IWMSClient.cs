using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZollnerBoxFiller;
using ZollnerBoxFiller.Properties;

namespace Passion
{
    public class IWMSClient
    {
        public HttpClient _client;

        Settings resourceSetting = ZollnerBoxFiller.Properties.Settings.Default;

        public ResponseContent MesLogin(string username, string password)
        {
            ResponseContent response = new ResponseContent();

            _client = new HttpClient();

            string postUrl = $"{resourceSetting.IWMSAddress}api/";
            HttpContent content = new StringContent("", Encoding.UTF8);

            _client.PostAsync(postUrl, content);


            response = response.OK();

            return response;
        }
    }
}
