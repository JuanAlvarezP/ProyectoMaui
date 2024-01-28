using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ProyectoP2.Models;
using ProyectoP2.ViewModels;
using static ProyectoP2.Models.RazaPerro;

namespace ProyectoP2
{
    public class RazasPerrosViewModel: BaseViewModel
    {
        private readonly HttpClient _httpClient;

        public RazasPerrosViewModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<DogApiResponse> GetHoundImages()
        {
            var response = await _httpClient.GetStringAsync("https://dog.ceo/api/breed/hound/images");
            return JsonConvert.DeserializeObject<DogApiResponse>(response);
        }

        public async Task<BreedListApiResponse> GetBreedList()
        {
            var response = await _httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");
            return JsonConvert.DeserializeObject<BreedListApiResponse>(response);
        }

        public async Task<DogImagesApiResponse> GetRandomDogImage()
        {
            var response = await _httpClient.GetStringAsync("https://dog.ceo/api/breeds/image/random");
            return JsonConvert.DeserializeObject<DogImagesApiResponse>(response);
        }
    }
}

