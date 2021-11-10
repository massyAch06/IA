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
        string c8 = "coucou"; 
        string c9 = "Bonjour"; 
        string c10 = "Bonsoir"; 
        string c11 = "cc";
        string c2 = "comment va tu"; 
        string c12 = "bien"; 
        string c13 = "merci";
        string c3 = "il est quel heure";
        string c4 = "on est quelle date";
        string c5 = "recherche google";
        string c6 = "ouvre google chrome";
        string c7 = "ouvre chrome";
        string c14 = "ouvre youtube";
        string c15 = "ouvre gmail";
        string c16 = "ouvre facebook";
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);
            list.Add(c6); 
            list.Add(c7);
            list.Add(c8);
            list.Add(c9);
            list.Add(c10);
            list.Add(c11);
            list.Add(c12);
            list.Add(c13);
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

            if (r == c1 || r == c8 || r == c9 || r == c10 || r == c11)
            {
                say("salut");
                
            }
            if (r == "comment va tu")
            {
                say("bien, et vous?");
                
            }
            if (r == c12)
            {
                say("content de l'entendre");
            }
            if (r == c13)
            {
                say("de rien");
            }

            if (r == c3)
            {
                say("il est " + DateTime.Now.ToString("H:m:tt"));
            }
            if (r == c4)
            {
                say("on est le " + DateTime.Now.ToString("dd/MM/yyyy"));
            }
            if (r == c5)
            {
                Process.Start("www.google.com");
            }
            if (r == c6 || r == c7)
            {
                Process.Start("chrome.exe");
            }
            if (r == c14)
            {
                Process.Start("www.youtube.com");
            }
            if (r == c15)
            {
                Process.Start("www.gmail.com");
            }
            if (r == c16)
            {
                Process.Start("www.facebook.com");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            rbox.Location = new Point(236, 97);
            rbox.ForeColor = Color.DarkGray;
            
            rbox.ReadOnly = true;
            rbox.BorderStyle = BorderStyle.None;
            rbox.Size = new Size(278, 115);
            //rbox.Text = "!..Welcome to GeeksforGeeks..!";
            this.Controls.Add(rbox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tr = richTextInput.Text;

            if (tr == c1 || tr == c8 || tr == c9 || tr == c10 || tr == c11) { 
                say(c1);
                rbox.Text = c1; 
            }
            
            if (tr == c2) { 
                say("bien, et vous");
                rbox.Text = "Bien et vous?"; 
            }
            if (tr == c12)
            {
                say("content de l'entendre");
            }
            if (tr == c13)
            {
                say("de rien");
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
            if (tr == c5)
            {
                Process.Start("www.google.com");
                
            }
            if (tr == c6 || tr == c7)
            {
                Process.Start("chrome.exe");
            }
            if (tr == c14)
            {
                Process.Start("www.youtube.com");
            }
            if (tr == c15)
            {
                Process.Start("www.gmail.com");
            }
            if (tr == c16)
            {
                Process.Start("www.facebook.com");
            }
            richTextInput.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/massyAch06/IA");
        }
    }
}
