using System;
using System.Speech.Recognition;
using System.Threading;

namespace VoiceControlledPong
{
    internal class CommandRecognizer
    {
        private SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();
        private PongGame pongGame;

        public CommandRecognizer(PongGame pongGame)
        {
            this.pongGame = pongGame;
        }

        public void RecognizeCommands()
        {
            Choices commands = new Choices("Up", "Down", "Stop", "Pause", "Quit");
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            speechRecognizer.LoadGrammar(grammar);
            speechRecognizer.SetInputToDefaultAudioDevice();
            speechRecognizer.SpeechRecognized += SpeechRecognizedHandler;
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);

            Console.WriteLine("Voice-controlled Pong is running. Say commands or 'Quit' to exit.");
            Console.ReadLine(); 
        }

        private void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;
            Console.WriteLine($"Recognized: {recognizedText}");

            pongGame.SetCommand(recognizedText);

            if (recognizedText.Equals("Quit", StringComparison.OrdinalIgnoreCase))
            {
                Quit();
            }
        }

        private void Quit()
        {
            speechRecognizer.Dispose();
            Environment.Exit(0); 
        }
    }
}
