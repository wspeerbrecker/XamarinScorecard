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
using SQLite;

namespace XamarinScorecard
{
//    [Activity(Label = "ScorecardListLoader")]
//    class ScorecardListLoader : AsyncTaskLoader {

//        private static String LOG_TAG="ScorecardListLoader";
//    private List<Scorecard> mScorecard;
//    private ContentResolver mContentResolver;
//    private Android.Database.ICursor mCursor;
//        private Context mContext;

//    public ScorecardListLoader(Context context, Uri uri, ContentResolver contentResolver)
//    {
//            //super(context);
//            mContext = context;
//        mContentResolver = contentResolver;
//    }

//    //@Override
//    public List<Scorecard> LoadInBackground()
//    {

//        String[] projection = {BowlingContract.BaseColumns._ID, BowlingContract.ScorecardColumns.SCORECARD_SEASONID, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE,
//                BowlingContract.ScorecardColumns.SCORECARD_GAME1, BowlingContract.ScorecardColumns.SCORECARD_GAME2, BowlingContract.ScorecardColumns.SCORECARD_GAME3,
//                BowlingContract.ScorecardColumns.SCORECARD_TOTAL, BowlingContract.ScorecardColumns.SCORECARD_AVERAGE
//        };
//        List<Scorecard> entries = new List<Scorecard>();

//        mCursor = mContentResolver.Query(BowlingContract.URI_TABLE, projection, null, null, BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE + " DESC");
//        if (mCursor != null)
//        {
//            if (mCursor.MoveToFirst())
//            {
//                do
//                {
//                    int _id = mCursor.GetInt(mCursor.GetColumnIndex(BowlingContract.BaseColumns._ID));
//                    String seasonId = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_SEASONID));
//                    String bowlingDate = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_BOWLING_DATE));
//                    String game1 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME1));
//                    String game2 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME2));
//                    String game3 = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_GAME3));
//                    String seriesTotal = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_TOTAL));
//                    String seriesAverage = mCursor.GetString(mCursor.GetColumnIndex(BowlingContract.ScorecardColumns.SCORECARD_AVERAGE));
//                    //
//                    Scorecard scorecard = new Scorecard(_id, seasonId, bowlingDate, game1, game2, game3, seriesTotal, seriesAverage);
//                    entries.Add(scorecard);
//                } while (mCursor.MoveToNext());

//            }
//        }
//        return entries;

//    }

//    //@Override
//    public void DeliverResult(List<Scorecard> data)
//    {

//        if (IsReset())
//        {
//            if (data != null)
//            {
//                mCursor.Close();
//            }
//        }
//        List<Scorecard> oldScorecard = mScorecard;
//        if (mScorecard == null || mScorecard.Count == 0)
//        {
//            Log.d(LOG_TAG, "*** No Data Returned ***");
//        }
//        mScorecard = data;
//        if (IsStarted())
//        {
//            super.deliverResult(data);
//        }
//        if (oldScorecard != null && oldScorecard != data)
//        {
//            mCursor.Close();
//        }
//    }

//    //@Override
//    protected void onStartLoading()
//    {

//        if (mScorecard != null)
//        {
//            DeliverResult(mScorecard);
//        }

//        if (TakeContentChanged() || mScorecard == null)
//        {
//            forceLoad();
//        }
//    }

//    //@Override
//    protected void onStopLoading()
//    {
//        CancelLoad();
//    }

//    //@Override
//    protected void onReset()
//    {

//        onStartLoading();
//        if (mCursor != null)
//        {
//            mCursor.Close();
//        }
//        mScorecard = null;
//    }

//    //@Override
//    public override void onCanceled(List<Scorecard> data)
//    {
//        Super.onCanceled(data);
//        if (mCursor != null)
//        {
//            mCursor.Close();
//        }
//    }

//    //@Override
//    public void forceLoad()
//    {
//        Super.forceLoad();
//    }
//}
}