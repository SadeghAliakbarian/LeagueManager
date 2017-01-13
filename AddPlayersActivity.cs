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
    [Activity(Label = "AddPlayersActivity")]
    public class AddPlayersActivity : Activity
    {
        string[] playerNames;
        List<string> tempNames;

        int NoPlayers = 0;
        int max_fixtures = 0, current_fixture = 0;
       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Players);

            tempNames = new List<string>();
            CheckBox check_Sadegh = FindViewById<CheckBox>(Resource.Id.check_sadegh);
            CheckBox check_Mohammad = FindViewById<CheckBox>(Resource.Id.check_mohammad);
            CheckBox check_Alireza = FindViewById<CheckBox>(Resource.Id.check_alireza);
            CheckBox check_Abbas = FindViewById<CheckBox>(Resource.Id.check_abbas);
            CheckBox check_Salim = FindViewById<CheckBox>(Resource.Id.check_salim);
            CheckBox check_Mousa = FindViewById<CheckBox>(Resource.Id.check_mousa);
            CheckBox check_Monaj = FindViewById<CheckBox>(Resource.Id.check_monaj);

            Button DoneWithPlayers = FindViewById<Button>(Resource.Id.btn_donePlayers);

            bool single = Intent.GetBooleanExtra("single", false);

            DoneWithPlayers.Click += delegate
                 {
                     if (check_Sadegh.Checked) { tempNames.Add("Sadegh"); }
                     if (check_Mohammad.Checked) { tempNames.Add("Mohammad"); }
                     if (check_Alireza.Checked) { tempNames.Add("Alireza"); }
                     if (check_Abbas.Checked) { tempNames.Add("Abbas"); }
                     if (check_Salim.Checked) { tempNames.Add("Salim"); }
                     if (check_Mousa.Checked) { tempNames.Add("Mousa"); }
                     if (check_Monaj.Checked) { tempNames.Add("Monaj"); }

                     playerNames = new string[tempNames.Count];
                     for (int i = 0; i < tempNames.Count; i++) { playerNames[i] = tempNames[i]; }

                     NoPlayers = tempNames.Count;
                     if (single) { max_fixtures = FixtureSize(true); }
                     if (!single) { max_fixtures = FixtureSize(false); }

                     var activity2 = new Intent(this, typeof(LeagueActivity));
                     activity2.PutExtra("NoPlayers", NoPlayers);
                     activity2.PutExtra("P_names", playerNames);
                     activity2.PutExtra("current_fixture", 0);
                     activity2.PutExtra("max_fixtures", max_fixtures);
                     activity2.PutExtra("single", single);
                     StartActivity(activity2);
                 };
            // Create your application here
        }

        private int FixtureSize(bool single)
        {
            int size = 0;
            if (single)
            {
                size = Factorial(tempNames.Count) / (2 * Factorial(tempNames.Count - 2));
            }
            else
            { size = Factorial(tempNames.Count) / (Factorial(tempNames.Count - 2)); }
            return size;
        }

        private int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}