using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;


namespace AI.Speech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Go();
        }

        private void Go()
        {
            var ss = new SpeechSynthesizer();
            var pb = new PromptBuilder();
            var src = new SpeechRecognitionEngine();
            Choices list = new Choices(new[] { "hello", "browser", "visual studio"});
            Grammar gm = new Grammar(new GrammarBuilder(list));
            try
            {
                src.RequestRecognizerUpdate();
                src.LoadGrammar(gm);
                src.SpeechRecognized += (s, e) =>
                {
                    var txt = e.Result.Text;
                    switch (txt)
                    {
                        case "hello":
                            Process.Start("Notepad", "");
                            break;
                        case "browser":
                            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "--incognito");
                            break;
                        case "visual studio":
                            Process.Start("devenv.exe","");
                            break;
                            //// more
                    }
                };
                src.SetInputToDefaultAudioDevice();
                src.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
