using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace LeagueManager
{
    [Activity(Label = "LeagueManager", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        #region GlobalVariables
        int NoPlayers = 0;
        string[] P_names;
        string L_name;
        int max_fixtures = 0, current_fixture = 0;
        string HomePlayer = "", AwayPlayer = "";
        bool[] played;
        string[] HomeGames;
        string[] AwayGames;
        int[] homeGoals;
        int[] awayGoals;
        #endregion
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Run();
        }
        private void Run()
        {
            // first page elements
            EditText LeagueName = FindViewById<EditText>(Resource.Id.edit_LeagueName);
            EditText NumberOfPlayers = FindViewById<EditText>(Resource.Id.edit_NumberOfPlayers);
            EditText PlayerNames = FindViewById<EditText>(Resource.Id.edit_PlayerNames);
            Button LeagueConfirm = FindViewById<Button>(Resource.Id.btn_LeagueConfirm);
            RadioButton SingleElimination = FindViewById<RadioButton>(Resource.Id.radio_SingleElimination);
            RadioButton DoubleElimination = FindViewById<RadioButton>(Resource.Id.radio_DoubleElimination);

            

            // delegates 
            LeagueConfirm.Click += delegate
            {

                // initialize the global variables
                L_name = LeagueName.Text.ToString();
                NoPlayers = int.Parse(NumberOfPlayers.Text.ToString());
                P_names = PlayerNames.Text.ToString().Split('\n');

                // initialize the second page
                if (SingleElimination.Checked) { max_fixtures = FixtureSize(true); }
                if (DoubleElimination.Checked) { max_fixtures = FixtureSize(false); }


                

                // go to second page (League Layout)
                var activity2 = new  Intent(this, typeof(LeagueActivity));
                activity2.PutExtra("NoPlayers", NoPlayers);
                activity2.PutExtra("P_names", P_names);
                activity2.PutExtra("current_fixture", current_fixture);
                activity2.PutExtra("max_fixtures", max_fixtures);
                activity2.PutExtra("single", SingleElimination.Checked);
                StartActivity(activity2);
                

            };
           
        }



        private int FixtureSize(bool single)
        {
            int size = 0;
            if (single)
            {
                size = Factorial(NoPlayers) / (2 * Factorial(NoPlayers - 2));
            }
            else
            { size = Factorial(NoPlayers) / (Factorial(NoPlayers - 2)); }
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

