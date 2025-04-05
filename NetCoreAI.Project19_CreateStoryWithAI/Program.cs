using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

class Program
{
    private static readonly string apiKey= "";
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hikaye türünü seçiniz(Macera, Korku, Bilim Kurgu, Fantastik, Komedi): ");
        string genre = Console.ReadLine();
        Console.Write("Ana karakterin adını giriniz: ");
        string character = Console.ReadLine();

        Console.Write("Hikaye nerede geçiyor? ");
        string setting = Console.ReadLine();

        Console.Write("Hikayenin uzunluğu (Kısa/Orta/Uzun): ");
        string length = Console.ReadLine();

        string prompt = $"Hikaye türü: {genre}, Ana karakter: {character}, Mekan: {setting}, Uzunluk: {length}. Bu bilgileri kullanarak bir hikaye oluştur. Giriş, gelişme ve sonuç içermelidir.";

        string story = await GenerateStory(prompt);
        Console.WriteLine();
        Console.WriteLine("----AI tarafından oluşturulan hikaye---/n");
        Console.WriteLine(story);


        static async Task<string> GenerateStory(string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
                var requestBody = new
                {
                    model = "gpt-4-turbo",
                    messages = new[]
                    {
                        new
                        {
                            role = "system",
                            content = "Sen bir hikaye yazarı asistanısın. Kullanıcının verdiği bilgilerle bir hikaye oluşturursun."
                        },
                        new
                        {
                            role = "user",
                            content = prompt
                        }
                    },
                    max_tokens=1000
                };
                var jsonContent = JsonConvert.SerializeObject(requestBody);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                string responseContent = await response.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(responseContent);
                return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
              
            }
        }


    }
}