using System.Speech.Synthesis;

class Program
{

    static void Main(string[] args)
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            
        speechSynthesizer.Volume = 100;
        speechSynthesizer.Rate = -1;

        Console.Write("Metni girin:");
        string input;
        input = Console.ReadLine();

        if(!string.IsNullOrEmpty(input))
        {
            speechSynthesizer.Speak(input);
        }
        else
        {
            Console.WriteLine("Boş metin girdiniz.");
        }
    }
}