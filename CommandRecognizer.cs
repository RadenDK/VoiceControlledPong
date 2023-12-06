using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;


namespace VoiceControlledPong
{

    internal class CommandRecognizer
    {
        private SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();

        public void recognizeCommands()
        {
            Choices commands = new Choices("Up", "Down", "Stop", "Pause", "Quit");
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            speechRecognizer.LoadGrammar(grammar);
            speechRecognizer.SetInputToDefaultAudioDevice();
            speechRecognizer.SpeechRecognized += SpeechRecognizedHandler;
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);

            Console.WriteLine("Voice-controlled Pong is running. Say commands or 'Quit' to exit.");
            Console.ReadLine(); // Keep the application running
        }

        private void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;
            Console.WriteLine($"Recognized: {recognizedText}");

            if (recognizedText.Equals("Quit", StringComparison.OrdinalIgnoreCase))
            {
                Quit();
            }
        }

        private void Quit()
        {
            speechRecognizer.Dispose(); // Close and release resources
            Environment.Exit(0); // Exit the application
        }
    }
}
