
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static readonly string apiKey= "";
    static async Task Main(string[] args)
    {
       
        Console.Write("Uzun metninizi veya makalenizi giriniz: ");
        string input = Console.ReadLine();

        if(!string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Metin özetleniyor");
            Console.WriteLine();

            string shortSummary = await SummarizeText(input, "short");
            string mediumSummary = await SummarizeText(input, "medium");
            string longSummary = await SummarizeText(input, "detailed");

            Console.WriteLine("Özetler");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Kısa Özet: " + shortSummary);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Orta Özet: " + mediumSummary);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Uzun Özet: " + longSummary);
        }
        async Task<string> SummarizeText(string text, string level)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                string instruction = level switch
                {
                    "short" => "Summarize the following text in 1-2 sentence",
                    "medium" => "Summarize the following text in 3-5 sentences",
                    "detailed" => "Summarize the following text in a detailed but concise manner",
                    _ => "Summarize the following text."
                };

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                    new { role = "system", content = "You are an AI that summarize text infto different levels: short, medium and detailed." },
                    new { role = "user", content = $"{instruction}Summarize the following text: \"{text}\""}
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
     
}