using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace _01_TextToSpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10

            // Synchronous
            synthesizer.Speak("Hello , Microsoft");

            // Asynchronous
            //synthesizer.SpeakAsync("Hello World");


            Console.ReadLine();
        }
    }
}
