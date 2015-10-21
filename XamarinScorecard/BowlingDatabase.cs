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
using Android.Database.Sqlite;
using SQLite;

namespace XamarinScorecard
{
    [Activity(Label = "BowlingDatabase")]
    public class BowlingDatabase : SQLiteOpenHelper  //: Activity
    {

        private static String TAG = "BowlingDatabase";
        private static String DATABASE_NAME = "xamarin_scorecard.db";
        private static int DATABASE_VERSION = 2;
        private Context mContext;

        public static String Table_SCORECARD = "scorecard";

        private static String DATABASE_CREATE_SQL =
            "create table " + Table_SCORECARD
        + " (" + BowlingContract.BaseColumns._ID + " integer primary key autoincrement, "
        + BowlingContract.ScorecardColumns.SCORECARD_SEASONID + " integer not null, "
        + BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE + " text not null, "
        + BowlingContract.ScorecardColumns.SCORECARD_GAME1 + " integer not null, "
        + BowlingContract.ScorecardColumns.SCORECARD_GAME2 + " integer not null, "
        + BowlingContract.ScorecardColumns.SCORECARD_GAME3 + " integer not null,"
        + BowlingContract.ScorecardColumns.SCORECARD_TOTAL + " integer not null,"
        + BowlingContract.ScorecardColumns.SCORECARD_AVERAGE + " integer not null"
        + ");";

        public BowlingDatabase(Context context)
            : base(context, DATABASE_NAME, null, DATABASE_VERSION)
        {
            mContext = context;
            string dbPath = context.GetDatabasePath(DATABASE_NAME).AbsolutePath;
        }
        //public void BowlingDatabase(Context context)
        //{
        //    //super(context, DATABASE_NAME, null, DATABASE_VERSION);
        //    mContext = context;
        //}

        //@Override
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(DATABASE_CREATE_SQL);
        }

        //@Override
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            //Log.w(TAG, "Upgrading application's database from version " + oldVersion
            //        + " to " + newVersion + ", which will destroy all old data!");

            int version = oldVersion;
            if (version == 1)
            {
                version = 2;
            }
            if (version != DATABASE_VERSION)
            {
                // Drop the old tables.
                db.ExecSQL("DROP TABLE IF EXISTS " + Table_SCORECARD);
                // Recreate new database.
                OnCreate(db);
            }
        }
        public static void deleteDatabase(Context context)
        {
            context.DeleteDatabase(DATABASE_NAME);
        }

    }
}