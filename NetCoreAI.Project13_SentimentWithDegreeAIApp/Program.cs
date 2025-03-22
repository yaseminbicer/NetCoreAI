using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static readonly string apiKey = "";
    static async Task Main(string[] args)
    {
        Console.WriteLine("Bir metni giriniz: ");
        string input;
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine();
            Console.Write("Duygu analizi yapılıyor..");
            Console.WriteLine();
            string sentiment = await AnalyzeSentiment(input);
            Console.WriteLine($"Duygu analizi sonucu: {sentiment}");
        }
    }
    static async Task<string> AnalyzeSentiment(string text)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are an advanced AI that analyzes emotions in text. Your response must be in JSON format. Identify the sentiment scores (0-100) for the following emotions: Joy, Sadness, Anger, Fear, Suprise and Neutral" },
                    new { role = "user", content = $"Analyze the sentiment of this text: \"{text}\" and return only a JSON object with percetages for each emotions"}
                }
            };
            string json = JsonConvert.SerializeObject(requestBody);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<dynamic>(responseJson);
                return result.choices[0].message.content.ToString();
            }
            else
            {
                Console.WriteLine($"Hata oluştu." + responseJson);
                return "Hata oluştu.";
            }
        }
    }
}