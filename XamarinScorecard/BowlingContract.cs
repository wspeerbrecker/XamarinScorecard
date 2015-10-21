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

namespace XamarinScorecard
{
   
    class BowlingContract
    {
        public const String CONTENT_AUTHORITY = "XamarinScorecard.XamarinScorecard.provider";
        public static Android.Net.Uri BASE_CONTENT_URI = Android.Net.Uri.Parse("content://" + CONTENT_AUTHORITY); 

        private static String PATH_SCORECARD = "Scorecard";
        public static Android.Net.Uri URI_TABLE = Android.Net.Uri.Parse(BASE_CONTENT_URI.ToString() + "/" + PATH_SCORECARD);

        public static String[] TOP_LEVEL_PATHS = {
            PATH_SCORECARD
        };
        public class BaseColumns
        {
            public const String _ID = "Id";
        }
        public class ScorecardColumns
        {
            public const String SCORECARD_ID = "_ID";
            public const String SCORECARD_SEASONID = "SeasonID";
            public const String SCORECARD_BOWLING_DATE = "BowlingDate";
            public const String SCORECARD_GAME1 = "Game1";
            public const String SCORECARD_GAME2 = "Game2";
            public const String SCORECARD_GAME3 = "Game3";
            public const String SCORECARD_TOTAL = "Total";
            public const String SCORECARD_AVERAGE = "Average";
        }
        public class BCScorecard
        { // implements ScorecardColumns, BaseColumns{

            public static Android.Net.Uri CONTENT_URI = BASE_CONTENT_URI .BuildUpon().AppendEncodedPath(PATH_SCORECARD).Build();

            public static String CONTENT_TYPE = "vnd.android.cursor.dir/vnd." + CONTENT_AUTHORITY + ".Scorecard";
            public static String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd." + CONTENT_AUTHORITY + ".Scorecard";

            public static Android.Net.Uri buildScorecardUri(String ScorecardId)
            {
                return CONTENT_URI.BuildUpon().AppendEncodedPath(ScorecardId).Build();
            }
            public static String getScorecardId(Android.Net.Uri uri)
            {
                return uri.LastPathSegment; //uri.getPathSegments().get(1);
            }
        }
    }
}