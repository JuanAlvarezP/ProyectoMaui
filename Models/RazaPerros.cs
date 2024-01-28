namespace ProyectoP2.Models
{
    public class RazaPerro
    {
        public class DogApiResponse
        {
            public List<string> Message { get; set; }
            public string Status { get; set; }
        }
        public class BreedListApiResponse
        {
            public Dictionary<string, List<string>> Message { get; set; }
            public string Status { get; set; }
        }

        public class DogImagesApiResponse
        {
            public string Message { get; set; }
            public string Status { get; set; }
        }

    }

}