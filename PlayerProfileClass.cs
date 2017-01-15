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
    class PlayerProfileClass
    {
        public string PlayerName { get; set; }
        public int PlayerID { get; set; }
        public string PhotoLocation { get; set; }

        public int GamePlayed { get; set; }
        public int PointPerGame { get; set; }
        public int Ranking { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
    }
}