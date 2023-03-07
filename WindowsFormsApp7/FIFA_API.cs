using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{

    public class FIFA_API
    {
        Logger Log = new Logger("C:\\sqlite\\Logger_File.txt");
        
        public void EventsHistory()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=D:\\sqlite\\Games.db");
            sqlite_conn.Open();

            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT id FROM GamesHistory WHERE home_name = 'Manchester City' OR away_name = 'Manchester City';";

            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();


            while (reader.Read())
                try
                {

                    lock (sqlite_conn)


                    {
                        int match_Id = Convert.ToInt32(reader["id"]);

                        Thread t = new Thread(() => GetEvents(match_Id));
                        t.Start();

                    }
                   
                }
                catch (Exception ex)
                {

                }
            reader.Close();
            sqlite_conn.Close();
        }
        
     

        public void GetEvents (int match_id)
        {
            var Events = new List<Event>();
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=D:\\sqlite\\Games.db");
            string data = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    lock (sqlite_conn)

                    {

                        string Query = "https://livescore-api.com/api-client/scores/events.json?&key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&id=";
                        Query += match_id;
                        data = client.DownloadString(Query);

                        ///////////////////////////////////////////////////////////////////////////////////////
                        bool TimeExist = data.Contains("time");
                        if (TimeExist == true)
                        {
                            int location3 = data.IndexOf("[");
                            int locationOfQoute1 = data.IndexOf("]");
                            string data1 = data.Substring(location3, locationOfQoute1 - location3 + 1);

                            // string ATeamOfEvent = data.Substring(location3 + 12, locationOfQoute1 - (location3 + 12));







                            Events = JsonSerializer.Deserialize<List<Event>>(data1);

                            if (Events != null && Events.Count > 0)

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
                                }
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
                }

                catch (Exception ex)
                {
                    Log.LoggerWriteLine("Web client Error: " + ex.Message);
                }
            }
        }

        public void GetMatchHistory(int team_id, string fromH, string toH)
        {
            var MatchH = new List<matchhistory>();
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=D:\\sqlite\\Games.db");
            string data = "";
            using (WebClient client = new WebClient())
            {
                try
                {

                    string Query = "http://livescore-api.com/api-client/scores/history.json?key=giaWgvAYttMkd87a&secret=lBPDU7wsSB0z0kLgCVcTqNSUgEeuMmE8&from=";
                    Query += fromH;
                    Query += "&to=";
                    Query += toH;
                    Query += "&team=";
                    Query += team_id;
                    data = client.DownloadString(Query);

                    ///////////////////////////////////////////////////////////////////////////////////////
                    bool TimeExist = data.Contains("time");
                    if (TimeExist == true)
                    {
                        int location3 = data.IndexOf("[");
                        int locationOfQoute1 = data.IndexOf("]");
                        string data1 = data.Substring(location3, locationOfQoute1 - location3 + 1);

                        // string ATeamOfEvent = data.Substring(location3 + 12, locationOfQoute1 - (location3 + 12));







                        MatchH = JsonSerializer.Deserialize<List<matchhistory>>(data1);

                        if (MatchH != null && MatchH.Count > 0)

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
                            }
                            foreach (var score1 in MatchH)

                            {




                                SQLiteCommand sqlite_cmd;
                                sqlite_cmd = sqlite_conn.CreateCommand();
                                //  sqlite_cmd.CommandText = "INSERT INTO Games (id, home_name, away_name, score,time,league_id,status)";
                              sqlite_cmd.CommandText = "INSERT INTO GamesHistory (id, date, home_name, away_name,score,ht_score,ft_score,et_score,time,league_id,status,added,last_changed,home_id,away_id,competition_id,competition_name,fixture_id,scheduled,location) " +
                                 " VALUES(@id,@date,@home_name,@away_name,@score,@ht_score,@ft_score,@et_score,@time,@league_id,@status,@added,@last_changed,@home_id,@away_id,@competition_id,@competition_name,@fixture_id,@scheduled,@location)";
                                sqlite_cmd.Parameters.AddWithValue("@id", score1.id);
                                sqlite_cmd.Parameters.AddWithValue("@date", score1.date);
                                sqlite_cmd.Parameters.AddWithValue("@home_name", score1.home_name);
                                sqlite_cmd.Parameters.AddWithValue("@away_name", score1.away_name);
                                sqlite_cmd.Parameters.AddWithValue("@score", score1.score);
                                sqlite_cmd.Parameters.AddWithValue("@ht_score", score1.ht_score);
                                sqlite_cmd.Parameters.AddWithValue("@ft_score", score1.ft_score);
                                sqlite_cmd.Parameters.AddWithValue("@et_score", score1.et_score);
                                sqlite_cmd.Parameters.AddWithValue("@time", score1.time);
                                sqlite_cmd.Parameters.AddWithValue("@league_id", score1.league_id);
                                sqlite_cmd.Parameters.AddWithValue("@status", score1.status);
                                sqlite_cmd.Parameters.AddWithValue("@added", score1.added);
                                sqlite_cmd.Parameters.AddWithValue("@last_changed", score1.last_changed);
                                sqlite_cmd.Parameters.AddWithValue("@home_id", score1.home_id);
                                sqlite_cmd.Parameters.AddWithValue("@away_id", score1.away_id);
                                sqlite_cmd.Parameters.AddWithValue("@competition_id", score1.competition_id);
                                sqlite_cmd.Parameters.AddWithValue("@competition_name", score1.competition_name);
                                sqlite_cmd.Parameters.AddWithValue("@fixture_id", score1.fixture_id);
                                sqlite_cmd.Parameters.AddWithValue("@scheduled", score1.scheduled);
                                sqlite_cmd.Parameters.AddWithValue("@location", score1.location);
                                


                                sqlite_cmd.ExecuteNonQuery();
                               



    }
}
                    }
                }

                catch (Exception ex)
                {
                    Log.LoggerWriteLine("Web client Error: " + ex.Message);
                }
            }
        }
    }
}