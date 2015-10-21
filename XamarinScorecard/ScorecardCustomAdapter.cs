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
    [Activity(Label = "ScorecardCustomAdapter")]

    public class ScorecardCustomAdapter : BaseAdapter
    {
        private static List<Scorecard> mScorecards;
        Activity _activity;

        public ScorecardCustomAdapter(Activity activity)
        {
            _activity = activity;
            LoadSCData();
        }

        private void LoadSCData()
        {
            Android.Net.Uri uri;
            //
            String[] projection = {BowlingContract.BaseColumns._ID, BowlingContract.ScorecardColumns.SCORECARD_SEASONID, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE,
                BowlingContract.ScorecardColumns.SCORECARD_GAME1, BowlingContract.ScorecardColumns.SCORECARD_GAME2, BowlingContract.ScorecardColumns.SCORECARD_GAME3,
                BowlingContract.ScorecardColumns.SCORECARD_TOTAL, BowlingContract.ScorecardColumns.SCORECARD_AVERAGE
                };

            uri = BowlingContract.URI_TABLE;
            // CursorLoader introduced in Honeycomb (3.0, API11)
            var loader = new CursorLoader(_activity, uri, projection, null, null, null);
            var mCursor = (Android.Database.ICursor)loader.LoadInBackground();

            mScorecards = new List<Scorecard>();

            //mCursor = mContentResolver.Query(BowlingContract.URI_TABLE, projection, null, null, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE + " DESC");
            if (mCursor != null)
            {
                if (mCursor.MoveToFirst())
                {
                    do
                    {
                        int _id = mCursor.GetInt(mCursor.GetColumnIndex(BowlingContract.BaseColumns._ID));
                        String seasonId = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_SEASONID));
                        String bowlingDate = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE));
                        String game1 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME1));
                        String game2 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME2));
                        String game3 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME3));
                        String seriesTotal = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_TOTAL));
                        String seriesAverage = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_AVERAGE));
                        //
                        Scorecard scorecard = new Scorecard(_id, seasonId, bowlingDate, game1, game2, game3, seriesTotal, seriesAverage);
                        mScorecards.Add(scorecard);
                    } while (mCursor.MoveToNext());

                }
            }
        }

        //class ScorecardCustomAdapter : ArrayAdapter<Scorecard>
        //{
        //    private LayoutInflater mLayoutInflater;
        //    //private static FragmentManager sFragmentManager;
        //    //private static int _iTotalScores;
        //    //Activity context;
        //    List<Scorecard> mScorecards;

        //    public ScorecardCustomAdapter(Context context, List<Scorecard> scorecard) : base(context, Resource.Id.lvScores)
        //    { //, FragmentManager fragmentManager) {

        //        //Super(context, Android.R.layout.simple_list_item_2);
        //        mLayoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService); // .LAYOUT_INFLATER_SERVICE);
        //        //sFragmentManager = fragmentManager;
        //        mScorecards = scorecard;
        //    }

        public override int Count
        {
            get { return mScorecards.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // could wrap a Contact in a Java.Lang.Object
            // to return it here if needed
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(
                Resource.Layout.Scorecard_List, parent, false);

            Scorecard scorecard = mScorecards[position];
            int _id = scorecard.getid();
            String seasonID = scorecard.getSeasonId();
            String bowlingDate = scorecard.getBowlingDate();
            String game1 = scorecard.getGame1();
            String game2 = scorecard.getGame2();
            String game3 = scorecard.getGame3();
            String seriesTotal = scorecard.getSeriesTotal();
            String seriesAverage = scorecard.getSeriesAverage();
            String seasonAverage = scorecard.getSeasonAverage();
            //
            TextView tvDate = (TextView)view.FindViewById(Resource.Id.tvDate);
            tvDate.Text = bowlingDate;
            //
            TextView tvScore1 = (TextView)view.FindViewById(Resource.Id.tvScore1);
            tvScore1.Text = game1;
            //
            TextView tvScore2 = (TextView)view.FindViewById(Resource.Id.tvScore2);
            tvScore2.Text = game2;
            //
            TextView tvScore3 = (TextView)view.FindViewById(Resource.Id.tvScore3);
            tvScore3.Text = game3;
            //
            TextView tvTotslScores = (TextView)view.FindViewById(Resource.Id.tvTot);
            tvTotslScores.Text = "Total: " + seriesTotal;
            //
            TextView tvAvg = (TextView)view.FindViewById(Resource.Id.tvAvg);
            tvAvg.Text = "Avg: " + seriesAverage;
            //
            TextView tvSeasonAvg = (TextView)view.FindViewById(Resource.Id.tvSeasonAvg);
            tvSeasonAvg.Text = "Season Avg: " + seasonAverage;

            return view;
        }
        //public void SetData(List<Scorecard> scorecards){
        //    Clear();
        //    if (scorecards != null)
        //    {
        //        foreach (Scorecard scorecard in scorecards)
        //        {
        //            Add(scorecard);
        //        }
        //    }
        //}
    }

}