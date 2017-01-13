using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LeagueManager
{
    [Activity(Label = "LeagueActivity")]
    public class LeagueActivity : Activity
    {
        public struct LeagueTableComponent
        {
            public string name;
            public int GA, win, draw, lose, point;
        }
        string HomePlayer = "", AwayPlayer = "";
        bool[] played;
        string[] HomeGames;
        string[] AwayGames;
        int[] homeGoals;
        int[] awayGoals;
        bool start = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.League);

            // second page elements
            //TextView LeagueTable = FindViewById<TextView>(Resource.Id.txt_table);
            TextView Fixture = FindViewById<TextView>(Resource.Id.txt_Fixture);
            TextView Home = FindViewById<TextView>(Resource.Id.txt_HomeName);
            TextView Away = FindViewById<TextView>(Resource.Id.txt_AwayName);
            EditText HomeScore = FindViewById<EditText>(Resource.Id.edit_HomeScore);
            EditText AwayScore = FindViewById<EditText>(Resource.Id.edit_AwayScore);
            Button ResultConfirm = FindViewById<Button>(Resource.Id.btn_ResultConfirm);
            // reading passed data
            int current_fixture = Intent.GetIntExtra("current_fixture", 0);
            int max_fixtures = Intent.GetIntExtra("max_fixtures", 0);
            bool single = Intent.GetBooleanExtra("single", false);
            int NoPlayers = Intent.GetIntExtra("NoPlayers", 0);
            string[] P_names = Intent.GetStringArrayExtra("P_names");


            played = new bool[max_fixtures]; for (int i = 0; i < max_fixtures; i++) played[i] = false;
            HomeGames = new string[max_fixtures]; homeGoals = new int[max_fixtures];
            AwayGames = new string[max_fixtures]; awayGoals = new int[max_fixtures];

            if (single)
            {
                int k = 0;
                for (int i = 0; i < NoPlayers - 1; i++)
                {
                    for (int j = i + 1; j < NoPlayers; j++)
                    {
                        HomeGames[k] = P_names[i];
                        AwayGames[k] = P_names[j];
                        k++;
                    }
                }
            }

            if (!single)
            {
                int k = 0;
                for (int i = 0; i < NoPlayers - 1; i++)
                {
                    for (int j = i + 1; j < NoPlayers; j++)
                    {
                        HomeGames[k] = P_names[i];
                        AwayGames[k] = P_names[j];
                        k++;
                    }
                }
                for (int i = 0; i < NoPlayers - 1; i++)
                {
                    for (int j = i + 1; j < NoPlayers; j++)
                    {
                        AwayGames[k] = P_names[i];
                        HomeGames[k] = P_names[j];
                        k++;
                    }
                }

            }
            HomeScore.Enabled = false;
            AwayScore.Enabled = false;
            //current_fixture = 0;
            //Fixture.Text = "Games In Order (" + (current_fixture + 1).ToString() + "/" + max_fixtures.ToString() + ")";
            //Home.Text = "Home: " + HomeGames[current_fixture];
            //Away.Text = "Away: " + AwayGames[current_fixture];
            //if (played[0]) { HomeScore.Text = homeGoals[0].ToString(); AwayScore.Text = awayGoals[0].ToString(); }
            //else { HomeScore.Text = ""; AwayScore.Text = ""; }
            

              ResultConfirm.Click += delegate
              {
                  if (true)
                  {
                      if (start == false)
                      {
                          ResultConfirm.Text = "Confirm & Next"; start = true;
                          HomeScore.Enabled = true;
                          AwayScore.Enabled = true;
                          HomePlayer = HomeGames[current_fixture]; AwayPlayer = AwayGames[current_fixture];
                          Fixture.Text = "Games In Order (" + (current_fixture + 1).ToString() + "/" + max_fixtures.ToString() + ")";
                          Home.Text = "Home: " + HomeGames[current_fixture];
                          Away.Text = "Away: " + AwayGames[current_fixture];
                          return;
                      }

                      if (HomeScore.Text.ToString() != "" && AwayScore.Text.ToString() != "")
                      {
                          if (played[current_fixture] == false)
                          {
                              HomeScore.Enabled = true;
                              AwayScore.Enabled = true;
                              played[current_fixture] = true;
                              homeGoals[current_fixture] = int.Parse(HomeScore.Text.ToString());
                              awayGoals[current_fixture] = int.Parse(AwayScore.Text.ToString());
                              HomeScore.Text = ""; AwayScore.Text = "";
                          }
                          else
                          {
                              HomeScore.Enabled = false;
                              AwayScore.Enabled = false;

                              HomeScore.Text = homeGoals[current_fixture].ToString(); AwayScore.Text = awayGoals[current_fixture].ToString();
                              
                          }
                      }
                      current_fixture++;
                      if (current_fixture >= max_fixtures) { current_fixture = 0; }
                      Fixture.Text = "Games In Order (" + (current_fixture + 1).ToString() + "/" + max_fixtures.ToString() + ")";
                      Home.Text = "Home: " + HomeGames[current_fixture];
                      Away.Text = "Away: " + AwayGames[current_fixture];
                      if (played[current_fixture])
                      {
                          HomeScore.Enabled = false;
                          AwayScore.Enabled = false;

                          HomeScore.Text = homeGoals[current_fixture].ToString(); AwayScore.Text = awayGoals[current_fixture].ToString();
                      }

                      //update the table
                      //if (!played.Contains(false))
                      if(true)
                      {
                          LeagueTableComponent[] currentTable = new LeagueManager.LeagueActivity.LeagueTableComponent[NoPlayers];
                          for (int i = 0; i < NoPlayers; i++)
                          {
                              currentTable[i].name = P_names[i];
                              currentTable[i].point = currentTable[i].GA = currentTable[i].win = currentTable[i].draw = currentTable[i].lose = 0;
                          }
                          for(int fixt = 0; fixt<max_fixtures;fixt++)
                          {
                              if(played[fixt])
                              for (int i = 0; i < NoPlayers; i++)
                              {
                                  // update home
                                  if (HomeGames[fixt] == currentTable[i].name)
                                  {
                                      if (homeGoals[fixt] > awayGoals[fixt])
                                      {
                                          currentTable[i].win++;
                                          currentTable[i].point += 3;
                                      }
                                      if (homeGoals[fixt] < awayGoals[fixt])
                                      {
                                          currentTable[i].lose++;
                                      }
                                      if (homeGoals[fixt] == awayGoals[fixt])
                                      {
                                          currentTable[i].draw++;
                                          currentTable[i].point++;
                                      }
                                      currentTable[i].GA += (homeGoals[fixt]-awayGoals[fixt]);
                                  }
                                  // update away
                                  if (AwayGames[fixt] == currentTable[i].name)
                                  {
                                      if (awayGoals[fixt] > homeGoals[fixt])
                                      {
                                          currentTable[i].win++;
                                          currentTable[i].point += 3;
                                      }
                                      if (awayGoals[fixt] < homeGoals[fixt])
                                      {
                                          currentTable[i].lose++;
                                      }
                                      if (awayGoals[fixt] == homeGoals[fixt])
                                      {
                                          currentTable[i].draw++;
                                          currentTable[i].point++;
                                      }
                                      currentTable[i].GA += (awayGoals[fixt] - homeGoals[fixt]);
                                  }
                              }

                              // sort the table
                              Array.Sort<LeagueTableComponent>(currentTable, (x, y) => y.point.CompareTo(x.point));
                              //LeagueTable.Text = "";
                              List<PlayerStats> RankingTable = new List<PlayerStats>();
                              PlayerStats temp = new PlayerStats();
                              temp.name = "Team";
                              temp.win = "Win";
                              temp.draw = "Draw";
                              temp.lose = "Lose";
                              temp.point = "Points";
                              temp.GA = "GA";

                              RankingTable.Add(temp);
                              for (int i = 0; i < NoPlayers; i++)
                              {
                                   temp = new PlayerStats();
                                  temp.name = currentTable[i].name;
                                  temp.win = currentTable[i].win.ToString();
                                  temp.draw = currentTable[i].draw.ToString();
                                  temp.lose = currentTable[i].lose.ToString();
                                  temp.point = currentTable[i].point.ToString();
                                  temp.GA = currentTable[i].GA.ToString();

                                  RankingTable.Add(temp);
                              }
                              ListView rankingList = FindViewById<ListView>(Resource.Id.listRanking);
                              RankingListView adapter = new RankingListView(this, RankingTable) ;
                              //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, alaki);
                              rankingList.Adapter = adapter;
                              

                          }
                      }
                  }
                  
              };
        }

        

    }
}