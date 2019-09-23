using application.API.Dto;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace application.API.DataAccess
{
    public static class Seed
    {

        public static async Task Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            return;
        }


        // private static async Task InitClientDataAsync(DataContext context)
        // {

        //     string apiUrl = "http://www.mocky.io/v2/5808862710000087232b75ac";
        //     using (HttpClient httpClient = new HttpClient())
        //     {
        //         try
        //         {
        //             httpClient.DefaultRequestHeaders.Accept.Clear();
        //             httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //             var responseMessage = await httpClient.GetAsync(apiUrl);
        //             if (responseMessage.IsSuccessStatusCode)
        //             {
        //                 var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
        //                 ClientsResponseDto clientsList = JsonConvert.DeserializeObject<ClientsResponseDto>(jsonResponse);
        //                 foreach(var client in clientsList.Clients)
        //                 {
        //                     context.Clients.Add(client);
        //                 }
        //                 context.SaveChanges();

        //             }
        //         }
        //         catch (Exception e)
        //         {
        //         }
        //     }
        // }

        // private static async Task InitPoliciesDataAsync(DataContext context)
        // {

        //     string apiUrl = "http://www.mocky.io/v2/580891a4100000e8242b75c5";
        //     using (HttpClient httpClient = new HttpClient())
        //     {
        //         try
        //         {
        //             httpClient.DefaultRequestHeaders.Accept.Clear();
        //             httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //             var responseMessage = await httpClient.GetAsync(apiUrl);
        //             if (responseMessage.IsSuccessStatusCode)
        //             {
        //                 var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
        //                 PoliciesResponseDto policiesList = JsonConvert.DeserializeObject<PoliciesResponseDto>(jsonResponse);
        //                 foreach (var policy in policiesList.Policies)
        //                 {
        //                     context.Policies.Add(policy);
        //                 }
        //                 context.SaveChanges();

        //             }
        //         }
        //         catch (Exception e)
        //         {
        //         }
        //     }
        // }
    }
}
