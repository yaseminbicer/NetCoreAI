using Newtonsoft.Json;
using System.Text;

class Program
{
    private static readonly string googleApiKey = "";
    private static readonly string imagePath = "C:\\Users\\y.bicer\\Downloads\\indir.jpg";
    static void Main(string[] args)
    {
        Console.WriteLine("Google Vision Api ile görsel nesne tespiti yapılıyor...");
        string response = DetectObjects(imagePath).Result;

        Console.WriteLine("Tespit edilen nesneler \n");
        Console.WriteLine(response);

        static async Task<string> DetectObjects(string path)
        {
            using var client = new HttpClient();
            string apiUrl = $"https://vision.googleapis.com/v1/images:annotate?key={googleApiKey}";

            byte[] imageBytes = File.ReadAllBytes(path);
            string base64Image = Convert.ToBase64String(imageBytes);

            var requestBody= new
            {
                requests = new[]
                {
                    new
                    {
                        image = new
                        {
                            content = base64Image
                        },
                        features = new[]
                        {
                            new
                            {
                                type = "LABEL_DETECTION",
                                maxResults = 10
                            }
                        }
                    }
                }
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, jsonContent);
            string responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;

        }
    }
}