using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    internal class LiveGames
    {/*
        public void GetMatchOfTheDay(int team_id)
        {
            string data = "";

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=D:\\sqlite\\Games.db");
            var FutureGames = new List<futureGames>();
            var Matches = new List<match>();
            var Events = new List<Event>();


            using (WebClient client = new WebClient())
            {
                try
                {
                    string Query = "https://livescore-api.com/api-client/fixtures/matches.json?&key=IekFVXyGB1mAEcYu&secret=MG2LJNxkISo9E2Nng82c6BSICfihshLe";

                    Query += "&date=2023-03-11&team=";
                    Query += team_id;

                    data = client.DownloadString(Query);

                    Log.LoggerWriteLine(data);
                    ///////////////////////////////////////////////////////////////////////////////////////
                    bool TimeExist = data.Contains("time");
                    if (TimeExist == true)
                    {
                        int location = data.IndexOf("time");
                        string TimeOfEvent = data.Substring(location + 7, 8);


                        int location1 = data.IndexOf("home_name");
                        int locationOfQoute = data.IndexOf("\"", location1 + 15);
                        string HTeamOfEvent = data.Substring(location1 + 12, locationOfQoute - (location1 + 12));

                        int location2 = data.IndexOf("id", location1);
                        string IDOfEvent = data.Substring(location2 + 9, 7);

                        int location3 = data.IndexOf("away_name");
                        int locationOfQoute1 = data.IndexOf("\"", location3 + 13);
                        string ATeamOfEvent = data.Substring(location3 + 12, locationOfQoute1 - (location3 + 12));

                        ///////////////////////////////////////////////////////////////////////////////////////////////
                        ///
                        // FutureGames = JsonSerializer.Deserialize<List<futureGames>>(data);

                        // if (FutureGames != null && FutureGames.Count > 0)

                        try
                        {
                            sqlite_conn.Open();
                            Log.LoggerWriteLine(" db open ");
                            if (sqlite_conn == null)
                            {
                                Log.LoggerWriteLine($"ERROR no connection to DB ");
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.LoggerWriteLine($"ERROR no connection to DB " + ex.Message);
                        }



                        //foreach (var score2 in FutureGames)
                        try
                        {


                            SQLiteCommand sqlite_cmd;
                            sqlite_cmd = sqlite_conn.CreateCommand();
                            //  sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time,league_id,status)";
                            sqlite_cmd.CommandText = "INSERT INTO FutureGames (id, home_name, away_name, time) " +
                               "VALUES(@id, @home_team, @away_team, @time)";
                            sqlite_cmd.Parameters.AddWithValue("@id", IDOfEvent);
                            sqlite_cmd.Parameters.AddWithValue("@home_team", HTeamOfEvent);
                            sqlite_cmd.Parameters.AddWithValue("@away_team", ATeamOfEvent);
                            sqlite_cmd.Parameters.AddWithValue("@time", TimeOfEvent);
                            /*
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

                        catch (Exception ex)
                        {
                            Log.LoggerWriteLine("INSERT DATA ERROR" + ex.Message);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Log.LoggerWriteLine("Web client Error: " + ex.Message);
                }


            }

        }

        public string GetLiveScore(int team_id, int fixture_id)
        {
            var Matches = new List<match>();
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=C:\\sqlite\\db\\Games.db");
            string data = "";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string Query = "https://livescore-api.com/api-client/scores/live.json?&key=IekFVXyGB1mAEcYu&secret=MG2LJNxkISo9E2Nng82c6BSICfihshLe";
                    Query += "&team=";
                    Query += team_id;
                    Query += "&fixture_id=";
                    Query += fixture_id;


                    data = client.DownloadString(Query);

                    Matches = JsonSerializer.Deserialize<List<match>>(data);



                    if (Matches != null && Matches.Count > 0)
                    {

                        try
                        {
                            sqlite_conn.Open();
                            Log.LoggerWriteLine(" db open ");
                            if (sqlite_conn == null)
                            {
                                Log.LoggerWriteLine($"ERROR no connection to DB ");
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.LoggerWriteLine($"ERROR no connection to DB " + ex.Message);
                            return "ERROR";
                        }

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
                catch (Exception ex)
                {
                    Log.LoggerWriteLine("Web client Error: " + ex.Message);
                }

            }
            return data;
          public void MatchTime()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=C:\\sqlite\\db\\Games.db");
            sqlite_conn.Open();

            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT time FROM FutureGames";

            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();

            while (reader.Read())
            {
                int currentHour = DateTime.Now.Hour;

                int dbHour = Convert.ToDateTime(reader["time"]).Hour;


              //  if (dbHour == currentHour || dbHour == currentHour + 1 || dbHour == currentHour + 2)
                   if (dbHour == 20)
                    {
                    // while (dbHour == currentHour || dbHour == currentHour + 1 || dbHour == currentHour + 2)
                    while (dbHour == 20)
                    {
                        Thread t = new Thread(() => GetEvents(400695));
                        t.Start();
                        Thread.Sleep(TimeSpan.FromMinutes(1));
                        Log.LoggerWriteLine("in Events");

                       Thread t1 = new Thread(() => GetLiveScore(27, 1538564));
                       t1.Start();
                       Thread.Sleep(TimeSpan.FromHours(3));

                        



                    }

                }


            }
            reader.Close();
            sqlite_conn.Close();
        }
    */
    }
    }

