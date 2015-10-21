using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Database.Sqlite;
using SQLite;
using System.Collections.Generic;

namespace XamarinScorecard
{
    [Activity(Label = "XamarinScorecard", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private ContentResolver mContentResolver;
        private Android.Database.ICursor mCursor;
        private List<Scorecard> mSCList;
        private ScorecardCustomAdapter mAdapter;
        private SimpleCursorAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //BowlingDatabase bowlingDB = new BowlingDatabase(this.ApplicationContext);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            mContentResolver = this.ContentResolver;

            InsertScorecard();

            // Create an use a custom adapter
            ScorecardCustomAdapter SCAdapter = new ScorecardCustomAdapter(this);
            //SCAdapter.SetData(mSCList);
            var SCListView = FindViewById<ListView>(Resource.Id.lvScores);
            SCListView.Adapter = SCAdapter;

            button.Click += delegate {
                InsertScorecard();
                //LoadSCData();
            };
        }

        private void InsertScorecard()
        {
            //
            ContentValues values = new ContentValues();
            Android.Net.Uri returnedUri;
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_SEASONID, 1);
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE, "2015-10-07");
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_GAME1, 160);
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_GAME2, 180);
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_GAME3, 200);
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_TOTAL, 540);
            values.Put(BowlingContract.ScorecardColumns.SCORECARD_AVERAGE, 180);
            //
            returnedUri = mContentResolver.Insert(BowlingContract.URI_TABLE, values);
            //
//                uri = BowlingContract.Scorecard.buildScorecardUri(String.valueOf(lRowID));
//                int updatedCnt = mContentResolver.update(uri, values, null, null);
        }

        //private void LoadSCData()
        //{

        //    Android.Net.Uri uri;
        //    //
        //    String[] projection = {BowlingContract.BaseColumns._ID, BowlingContract.ScorecardColumns.SCORECARD_SEASONID, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE,
        //        BowlingContract.ScorecardColumns.SCORECARD_GAME1, BowlingContract.ScorecardColumns.SCORECARD_GAME2, BowlingContract.ScorecardColumns.SCORECARD_GAME3,
        //        BowlingContract.ScorecardColumns.SCORECARD_TOTAL, BowlingContract.ScorecardColumns.SCORECARD_AVERAGE
        //        };
        //    mSCList = new List<Scorecard>();

        //    uri = BowlingContract.URI_TABLE;
        //    // CursorLoader introduced in Honeycomb (3.0, API11)
        //    var loader = new CursorLoader(this, uri, projection, null, null, null);
        //    var mCursor = (Android.Database.ICursor)loader.LoadInBackground();

        //    //mCursor = mContentResolver.Query(BowlingContract.URI_TABLE, projection, null, null, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE + " DESC");
        //    if (mCursor != null)
        //    {
        //        if (mCursor.MoveToFirst())
        //        {
        //            do
        //            {
        //                int _id = mCursor.GetInt(mCursor.GetColumnIndex(BowlingContract.BaseColumns._ID));
        //                String seasonId = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_SEASONID));
        //                String bowlingDate = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE));
        //                String game1 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME1));
        //                String game2 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME2));
        //                String game3 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME3));
        //                String seriesTotal = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_TOTAL));
        //                String seriesAverage = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_AVERAGE));
        //                //
        //                Scorecard scorecard = new Scorecard(_id, seasonId, bowlingDate, game1, game2, game3, seriesTotal, seriesAverage);
        //                mSCList.Add(scorecard);
        //            } while (mCursor.MoveToNext());

        //        }
        //    }
        //}
    }
}

