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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                var watcher = new FileSystemWatcher("D:\\Matches");

                watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;

                //   watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                // watcher.Deleted += OnDeleted;
                //  watcher.Renamed += OnRenamed;

                watcher.Filter = "*.Json";
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)

            {

                /*ex.Message

                textBox1.AppendText($"ERROR no connection to DB ");

                textBox1.AppendText(Environment.NewLine);*/





                // Log.WriteLog("ERROR no connection to DB");







                return;

            }
            string FutureGamesPathRMA = "D:\\Matches\\FutureGamesRMA.Json";
            string FutureGamesPathManCity = "D:\\Matches\\FutureGamesMANCITY.Json";
            string FutureGamesPathPSG = "D:\\Matches\\FutureGamesPSG.Json";
            string LiveScoresPath = "D:\\Matches\\play.Json";
            string EventsPath = "D:\\Matches\\Event.Json";
            timer = new System.Timers.Timer();
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed1Minute;
            timer.Start();

            timer = new System.Timers.Timer
            {
               Interval = 86400000
              //Interval = 60000

            };
            timer.Elapsed += Timer_Elapsed1Day;
            timer.Start();

            void Timer_Elapsed1Minute(object sender1, System.Timers.ElapsedEventArgs e1)
            {
                timer.Stop();

                Fifa.GetLiveScore(27,1581068);


                timer.Start();
            }
            void Timer_Elapsed1Day(object sender1, System.Timers.ElapsedEventArgs e1)
            {
                timer.Stop();

                Fifa.GetMatchOfTheDay(27);


                timer.Start();
            }


            void LiveScores()
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string data = client.DownloadString("https://livescore-api.com/api-client/scores/live.json?&key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&fixture_id=1538532");

                         StreamWriter writer = new StreamWriter(LiveScoresPath);
                         writer.Write(data);
                        writer.Close();
                       // Log.LoggerWriteLine(data);

                    }
                    catch (WebException ex)
                    {
                        Log.LoggerWriteLine("Web client Error: " + ex.Message);
                    }
                }
            }
            void FutureGamesRMA()
            {

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string data = client.DownloadString("https://livescore-api.com/api-client/fixtures/matches.json?&key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&competition_id=3&date=2023-02-18&team=27");

                        StreamWriter writer = new StreamWriter(FutureGamesPathRMA);
                        writer.Write(data);
                        writer.Close();
                    }
                    catch (WebException ex)
                    {
                        Log.LoggerWriteLine("Web client Error: " + ex.Message);
                    }
                }

            }
            void FutureGamesManCity()
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string data = client.DownloadString("https://livescore-api.com/api-client/fixtures/matches.json?&key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&competition_id=3&date=today&team=???");

                        StreamWriter writer = new StreamWriter(FutureGamesPathManCity);
                        writer.Write(data);
                        writer.Close();
                    }
                    catch (WebException ex)
                    {
                        Log.LoggerWriteLine("Web client Error: " + ex.Message);
                    }
                }
            }
            void FutureGamesPSG()
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string data = client.DownloadString("https://livescore-api.com/api-client/fixtures/matches.json?&key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&competition_id=3&date=today&team=???");

                        StreamWriter writer = new StreamWriter(FutureGamesPathPSG);
                        writer.Write(data);
                        writer.Close();
                    }    
                    catch (WebException ex)
                    {
                        Log.LoggerWriteLine("Web client Error: " + ex.Message);
                    }
                }
            }
            void Events()
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string data = client.DownloadString("https://livescore-api.com/api-client/scores/events.json?key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&id=397324");
                        StreamWriter writer = new StreamWriter(EventsPath);
                        writer.Write(data);
                         writer.Close();
                        //Log.LoggerWriteLine(data);

                    }
                    catch (WebException ex)
                    {
                        Log.LoggerWriteLine("Web client Error: " + ex.Message);
                    }
                }
            }

        }
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                // string DataBaseFilePath = ConfigurationManager.AppSettings["DBFilePath"];
                //SQLiteConnection sqlite_conn = new SQLiteConnection(DataBaseFilePath);
                SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=D:\\sqlite\\Games.db"); 
                try
                {
                    sqlite_conn.Open();
                    Log.LoggerWriteLine(" db open ");
                }
                catch (Exception ex)
                {
                    Log.LoggerWriteLine("got new file " + e.FullPath);
                    Log.LoggerWriteLine($"ERROR no connection to DB " + ex.Message);
                    File.Delete(e.FullPath);
                    return;
                }

                string value = $"Created: {e.FullPath}";
                var Matches = new List<match>();
                var Events = new List<Event>();
                var FutureGames = new List<futureGames>();


                Log.LoggerWriteLine("got new file " + e.FullPath);


                using (StreamReader r = new StreamReader(e.FullPath))

                {
                    if (e.FullPath.Contains("play"))

                    {

                        string json = r.ReadToEnd();

                        Matches = JsonSerializer.Deserialize<List<match>>(json);

                        if (Matches != null && Matches.Count > 0)

                        {

                            foreach (var score in Matches)

                            {


                                SQLiteCommand sqlite_cmd;
                                sqlite_cmd = sqlite_conn.CreateCommand();
                                //  sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time,league_id,status)";
                                sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time, league_id,status) " +
                                    " VALUES(@id,@home_name,@away_name,@score,@time,@league_id,@status)";
                                sqlite_cmd.Parameters.AddWithValue("@id", score.id);
                                sqlite_cmd.Parameters.AddWithValue("@home_name", score.home_name);
                                sqlite_cmd.Parameters.AddWithValue("@away_name", score.away_name);
                                sqlite_cmd.Parameters.AddWithValue("@score", score.score);
                                sqlite_cmd.Parameters.AddWithValue("@time", score.time);
                                sqlite_cmd.Parameters.AddWithValue("@league_id", score.league_id);
                                sqlite_cmd.Parameters.AddWithValue("@status", score.status);
                                sqlite_cmd.ExecuteNonQuery();

                            }


                        }
                    }

                    else if (e.FullPath.Contains("Future"))

                    {

                        string json = r.ReadToEnd();

                        FutureGames = JsonSerializer.Deserialize<List<futureGames>>(json);

                        if (FutureGames != null && FutureGames.Count > 0)

                        {

                            foreach (var score2 in FutureGames)

                            {


                        
                                SQLiteCommand sqlite_cmd;
                                sqlite_cmd = sqlite_conn.CreateCommand();
                                //  sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time,league_id,status)";
                                sqlite_cmd.CommandText = "INSERT INTO FutureGames (name, id, home_id,home_name, id2,location,group_id,date,away_id,league_id,competition_id,time,away_name) " +
                                    " VALUES(@name, @id, @home_id, @home_name, @id2, @location, @group_id, @date, @away_id, @league_id, @competition_id, @time, @away_name)";


                                sqlite_cmd.Parameters.AddWithValue("@name", score2.name);
                                sqlite_cmd.Parameters.AddWithValue("@id", score2.id);
                                sqlite_cmd.Parameters.AddWithValue("@home_id", score2.home_id);
                                sqlite_cmd.Parameters.AddWithValue("@home_name", score2.home_name);
                                sqlite_cmd.Parameters.AddWithValue("@id2", score2.id2);
                                sqlite_cmd.Parameters.AddWithValue("@location", score2.location);
                                sqlite_cmd.Parameters.AddWithValue("@group_id", score2.group_id);
                                sqlite_cmd.Parameters.AddWithValue("@date", score2.date);
                                sqlite_cmd.Parameters.AddWithValue("@away_id", score2.away_id);
                                sqlite_cmd.Parameters.AddWithValue("@league_id", score2.league_id);
                                sqlite_cmd.Parameters.AddWithValue("@competition_id", score2.competition_id);
                                sqlite_cmd.Parameters.AddWithValue("@time", score2.time);
                                sqlite_cmd.Parameters.AddWithValue("@away_name", score2.away_name);


                                sqlite_cmd.ExecuteNonQuery();

                            }


                        }
                    }








                    else if (e.FullPath.Contains("Event"))

                    {

                        string json1 = r.ReadToEnd();

                        Events = JsonSerializer.Deserialize<List<Event>>(json1);

                        if (Events != null && Events.Count > 0)

                        {
                            foreach (var score1 in Events)

                            {




                                SQLiteCommand sqlite_cmd;
                                sqlite_cmd = sqlite_conn.CreateCommand();
                                //  sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time,league_id,status)";
                                sqlite_cmd.CommandText = "INSERT INTO Players (id, match_id, player, time,event1, sort,home_away) " +
                                    " VALUES(@id,@match_id,@player,@time,@event1,@sort,@home_away)";
                                sqlite_cmd.Parameters.AddWithValue("@id", score1.id);
                                sqlite_cmd.Parameters.AddWithValue("@match_id", score1.match_id);
                                sqlite_cmd.Parameters.AddWithValue("@player", score1.player);
                                sqlite_cmd.Parameters.AddWithValue("@time", score1.time);
                                sqlite_cmd.Parameters.AddWithValue("@event1", score1.event1);
                                sqlite_cmd.Parameters.AddWithValue("@sort", score1.sort);
                                sqlite_cmd.Parameters.AddWithValue("@home_away", score1.home_away);
                                sqlite_cmd.ExecuteNonQuery();

                            }
                        }
                    }

                }
                File.Delete(e.FullPath);

            }
            catch (Exception ex)

            {



                Log.LoggerWriteLine($"ERROR ONCREATE " + ex.Message);

                File.Delete(e.FullPath);


                return;

            }
        }
    }

    /*
    public class Logger

    {


        public Logger(string path)

        {


            {



            }



        }

        public void LoggerWriteLine(string createText)

        { 
            //    string loggerFilePath = ConfigurationManager.AppSettings["LoggerFilePath"];
            // string filePath = ConfigurationManager.AppSettings["LoggerFilePath"];
            string filePath = @"C:\sqlite\Logger_File.txt";

            File.AppendAllLines(filePath, new[] { createText });


            return;

        }

    }
    */











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
}
