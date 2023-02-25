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
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
        {
            timer = new System.Timers.Timer();
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed1Minute;
            timer.Start();

            timer = new System.Timers.Timer
            {
            //    Interval = 86400000
               Interval = 30000

            };
            timer.Elapsed += Timer_Elapsed1Day;
            timer.Start();

            void Timer_Elapsed1Minute(object sender1, System.Timers.ElapsedEventArgs e1)
            {
                timer.Stop();

                Fifa.GetLiveScore(27, 1581068);
                Fifa.GetEvents(398130);

                timer.Start();
            }
            void Timer_Elapsed1Day(object sender1, System.Timers.ElapsedEventArgs e1)
            {
                timer.Stop();

                if (cbRMA.Checked == true)
                {
                    Fifa.GetMatchOfTheDay(27);
                }


                if (cbManCity.Checked == true)
                {
                    Fifa.GetMatchOfTheDay(12);
                }
               
                    if (cbPSG.Checked == true)
                    {
                        Fifa.GetMatchOfTheDay(59);
                    }
                    timer.Start();
            }

        }
        
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

        public class Event

        {

            public string id { get; set; }

            public string match_id { get; set; }
            public string player { get; set; }
            public string time { get; set; }
            public string event1 { get; set; }
            public string sort { get; set; }
            public string home_away { get; set; }



        }
        public class futureGames
        {
            public string name { get; set; }
            public int id { get; set; }
            public int home_id { get; set; }
            public string home_name { get; set; }
            public int id2 { get; set; }
            public string location { get; set; }
            public int group_id { get; set; }
            public string date { get; set; }
            public int away_id { get; set; }
            public int league_id { get; set; }
            public int competition_id { get; set; }
            public string time { get; set; }
            public string away_name { get; set; }




        }

    


