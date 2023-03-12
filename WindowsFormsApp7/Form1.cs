using Microsoft.Data.Sqlite;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static WindowsFormsApp7.Form1;
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {

        private System.Timers.Timer timer;

        //Logger Log = new Logger(ConfigurationManager.AppSettings["LoggerFilePath"]);
        Logger Log = new Logger("C:\\sqlite\\Logger_File.txt");
        FIFA_API Fifa = new FIFA_API();
        //Yaniv
        public Form1()
        {

            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {/*
            timer = new System.Timers.Timer();
            timer.Interval = 60000;
          //  timer.Elapsed += Timer_Elapsed1Day;
            timer.Start();
            */
            Fifa.EventsHistory();
           

            //  Fifa.GetMatchHistory(59, "2023-02-14", "2023-11-15");

            // Fifa.GetEvents(398130);





            /*

            void Timer_Elapsed1Day(object sender1, System.Timers.ElapsedEventArgs e1)
            {
                timer.Stop();
                if (cbRMA.Checked == true)
                {
                    //Thread t = new Thread(() => 
                    Fifa.GetMatchOfTheDay(27);
                    Log.LoggerWriteLine("in Real Madrid");

                    //  t.Start();
                    // timer.Start();
                }
                if (cbManCity.Checked == true)
                {
                  //  Thread t = new Thread(() =>
                    Fifa.GetMatchOfTheDay(12);
                    Log.LoggerWriteLine("in Man City");

                    //  t.Start();
                }
                if (cbPSG.Checked == true)
                {
                   // Thread t = new Thread(() =>
                    Fifa.GetMatchOfTheDay(59);
                    Log.LoggerWriteLine("in PSG");

                    //  t.Start();
                }
                timer.Start();

            }

            while (true)
            {
                Thread threaMatchTime = new Thread(Fifa.MatchTime);
                threaMatchTime.Start();
              //  Thread.Sleep(TimeSpan.FromHours(1));
                Thread.Sleep(120000);
                Log.LoggerWriteLine("in MatchTime");



            }

            /*
            if (cbRMA.Checked == true)
                {
                    Thread t = new Thread(() => Fifa.GetMatchOfTheDay(27));
                    t.Start();
               //  Thread.Sleep(TimeSpan.FromDays(1));
                Thread.Sleep(90000);



            }

            if (cbManCity.Checked == true)
                {
                    Thread t = new Thread(() => Fifa.GetMatchOfTheDay(12));
                    t.Start();
                 // Thread.Sleep(TimeSpan.FromDays(1));
                Thread.Sleep(90000);



            }
            if (cbPSG.Checked == true)
                {
                    Thread t = new Thread(() => Fifa.GetMatchOfTheDay(59));
                    t.Start();
                 // Thread.Sleep(TimeSpan.FromDays(1));
                Thread.Sleep(90000);



            }
            // Thread.Sleep(TimeSpan.FromHours(1));
           // Thread.Sleep(40000);
                //  Thread.Sleep(TimeSpan.FromDays(1));
               // Thread.Sleep(90000);
            */



        }
    }
    public class match
    {
        public string id { get; set; }
        public string home_name { get; set; }
        public string away_name { get; set; }
        public string score { get; set; }
        public string time { get; set; }
        public string league_id { get; set; }
        public string status { get; set; }
    }
    public class matchhistory
    {
        public int id { get; set; }
        public string date { get; set; }
        public string home_name { get; set; }
        public string away_name { get; set; }
        public string score { get; set; }
        public string ht_score { get; set; }
        public string ft_score { get; set; }
        public string et_score { get; set; }
        public string time { get; set; }
        public int league_id { get; set; }
        public string status { get; set; }
        public string added { get; set; }
        public string last_changed { get; set; }
        public int home_id { get; set; }
        public int away_id { get; set; }
        public int competition_id { get; set; }
        public string competition_name { get; set; }
        public int fixture_id { get; set; }
        public string scheduled { get; set; }
        public string location { get; set; }











    }

    public class Event

    {

        public string id { get; set; }

        public string match_id { get; set; }
        public string player { get; set; }
        public string time { get; set; }
        [JsonPropertyName("event")]
        public string event1 { get; set; }
        public string sort { get; set; }
        public string home_away { get; set; }



    }
    public class futureGames
    {
        //     public string name { get; set; }
        public int id { get; set; }
        //    public int home_id { get; set; }
        public string home_name { get; set; }
        //     public int id2 { get; set; }
        //      public string location { get; set; }
        //      public int group_id { get; set; }
        //      public string date { get; set; }
        //      public int away_id { get; set; }
        //       public int league_id { get; set; }
        //        public int competition_id { get; set; }
        public string time { get; set; }
        public string away_name { get; set; }




    }
}

    


