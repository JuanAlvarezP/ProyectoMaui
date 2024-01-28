using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoP2.Services
{
    public class RazasPerrosApiService
    {
        private const string ApiUrl = "https://razas-de-perros.p.rapidapi.com/TypeOfBreeds";
        private const string ApiKey = "59c428306emsh53127c30291058fp1afc78jsne176300a63b5";

        public async Task<List<RazaPerro>> ObtenerRazasPerros()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(ApiUrl),
                        Headers =
                        {
                            { "X-RapidAPI-Key", ApiKey },
                            { "X-RapidAPI-Host", "razas-de-perros.p.rapidapi.com" },
                        },
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(body);

                        return new List<RazaPerro>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener razas de perros: {ex.Message}");
                return new List<RazaPerro>();
            }
        }
    }
}