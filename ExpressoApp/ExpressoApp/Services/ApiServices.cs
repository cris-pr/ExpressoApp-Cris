﻿using ExpressoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpressoApp.Services
{
    public class ApiServices
    {
        public async Task<List<Menu>> GetMenu()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://expressocris.azurewebsites.net/api/Menus");
            return JsonConvert.DeserializeObject<List<Menu>>(response);
        }
        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(json, Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://expressocris.azurewebsites.net/api/reservations", content);
            return response.IsSuccessStatusCode;
        }
    }
}
