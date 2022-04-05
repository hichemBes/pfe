
using Domain.Foriegn_Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Data.Repositry
{
    public  class fillialerepository
    {
        HttpClient _httpclient = new HttpClient();
        public FillialeDto getsubsidiarybyid(Guid fillialeid)
        {
            HttpResponseMessage response = _httpclient.GetAsync("http://localhost:44349/"+ fillialeid).Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responsebody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<FillialeDto>(responsebody);

        }
    }
   
}

