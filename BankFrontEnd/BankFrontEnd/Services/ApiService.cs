namespace BankFrontEnd.Services
{
    using BankFrontEnd.EditForm;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Net.Http;
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetApiData(string url)
        {
            var response = await _httpClient.GetStringAsync(url);

            return response;
        }

        public async Task Signin(string url, LoginEdit data)
        {
            var json = new StringContent(JsonConvert.SerializeObject(data));
            var response = await _httpClient.PostAsync(url, json);

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }
               

        }
    }
}
