using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace IA_BOT
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        RichTextBox rbox = new RichTextBox();
        

        string c1 = "salut";
        string c2 = "comment va tu";
        string c3 = "il est quel heure";
        string c4 = "on est quelle date";
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += Rec_SpeechRecognized; ;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { }
            s.SelectVoiceByHints(VoiceGender.Female);
            InitializeComponent();
        }

        public void say(string h)
        {
            s.Speak(h);
        }
        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;

            if (r == "Salut")
            {
                say("salut");
                
            }
            if (r == "comment va tu")
            {
                say("bien, et vous");
                
            }
            if (r == c3)
            {
                say("il est " + DateTime.Now.ToString("H:m:tt"));
            }
            if (r == c4)
            {
                say("on est le " + DateTime.Now.ToString("dd/MM/yyyy"));
            }
            if (r == "google")
            {
                Process.Start("www.google.com");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            rbox.Location = new Point(236, 97);
            rbox.ForeColor = Color.Black;

            //rbox.Text = "!..Welcome to GeeksforGeeks..!";
            this.Controls.Add(rbox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tr = richTextInput.Text;

            if (tr == c1) { 
                say("salut");
                rbox.Text = "Salut"; 
            }
            
            if (tr == c2) { 
                say("bien, et vous");
                rbox.Text = "Bien et vous?"; 
            }
            if (tr == c3)
            {
                
                say("il est "+ DateTime.Now.ToString("H:m:tt"));
                rbox.Text = "il est " + DateTime.Now.ToString("H:m:tt");
            }
            if (tr == c4)
            {
                say("on est le " + DateTime.Now.ToString("dd/MM/yyyy"));
                rbox.Text = "on est le " + DateTime.Now.ToString("dd/MM/yy");
            }
            if (tr == "google")
            {
                Process.Start("www.google.com");
                //Process.Start("chrome.exe");
            }
            richTextInput.Clear();
        }
    }
}
