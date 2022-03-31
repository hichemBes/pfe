
using Domain.Foriegn_Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Data.Repositry
{
 public class UserRepository
    {
        HttpClient _httpClient = new HttpClient();
       public UserDto GetuserById(Guid iduser)
        {
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44353/api/User/getById?id="+ iduser).Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<UserDto>(responseBody);
        }
    }
}
