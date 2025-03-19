using Google.Cloud.Vision.V1;

class Program
{
    static void Main(string[] args) 
    {
        Console.WriteLine("Resim yolunu giriniz:");
        Console.WriteLine();

        string imagePath = Console.ReadLine();
        string credentialPath = @"C:\Users\y.bicer\Downloads\beaming-theorem-454323-c0-f5ca72b9f612.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

        try 
        {
            var client = ImageAnnotatorClient.Create();

            var image = Image.FromFile(imagePath);
            var response = client.DetectText(image);
            Console.WriteLine("Resimdeki metin:");
            Console.WriteLine();
            foreach (var annotation in response)
            {
                if (!string.IsNullOrEmpty(annotation.Description))
                {
                    Console.WriteLine(annotation.Description);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu {ex.Message}");
        }
    }
}
