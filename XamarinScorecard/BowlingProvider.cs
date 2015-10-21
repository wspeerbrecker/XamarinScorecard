using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace XamarinScorecard
{
    [ContentProvider(new string[] { XamarinScorecard.BowlingContract.CONTENT_AUTHORITY })]
    public class BowlingProvider : ContentProvider
    {

        private BowlingDatabase mDBHelper;

        private static String TAG = "BowlingProvider";
        private static UriMatcher sUriMatcher = buildUriMatcher();

        private const int SCORECARD = 100;
        private const int SCORECARD_ID = 101;

        private static UriMatcher buildUriMatcher()
        {
            UriMatcher matcher = new UriMatcher(UriMatcher.NoMatch); // .NO_MATCH);
            String authority = BowlingContract.CONTENT_AUTHORITY;
            matcher.AddURI(authority, "Scorecard", SCORECARD); //.addURI(authority, "Scorecard", SCORECARD);
            matcher.AddURI(authority, "Scorecard/*", SCORECARD_ID);

            return matcher;
        }
        public override bool OnCreate()
        {
            mDBHelper = new BowlingDatabase(Context); //getContext());
            string sDBPath = mDBHelper.ReadableDatabase.Path;
            return true;
        }
        private void deleteDatabase()
        {
            mDBHelper.Close(); // .close();
            BowlingDatabase.deleteDatabase(Context); //getContext());
            mDBHelper = new BowlingDatabase(Context); //getContext());
        }
        public override String GetType(Android.Net.Uri uri)
        {
            int match = sUriMatcher.Match(uri);// .match(uri);
            switch (match)
            {
                case SCORECARD:
                    return BowlingContract.BCScorecard.CONTENT_TYPE;
                case SCORECARD_ID:
                    return BowlingContract.BCScorecard.CONTENT_ITEM_TYPE;
                default:
                    throw new Exception("Unknown Uri: " + uri);
            }
        }
        //@Override
        //public override Cursor query(Android.Net.Uri uri, String[] projection, String selection, String[] selectionArgs, String sortOrder)
        //{
        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            SQLiteDatabase db = mDBHelper.ReadableDatabase; // .GetReadableDatabase();
            int match = sUriMatcher.Match(uri);
            //
            SQLiteQueryBuilder queryBuilder = new SQLiteQueryBuilder();
            //**WES**            queryBuilder. .SetTables(BowlingDatabase.Table_SCORECARD);
            queryBuilder.Tables = BowlingDatabase.Table_SCORECARD;
            //
            switch (match)
            {
                case SCORECARD:
                    break;
                case SCORECARD_ID:
                    String id = BowlingContract.BCScorecard.getScorecardId(uri);
                    queryBuilder.AppendWhere(BowlingContract.BaseColumns._ID + "=" + id);
                    break;
                default:
                    throw new Exception("Unknown uri: " + uri);
            }
            ICursor cursor = queryBuilder.Query(db, projection, selection, selectionArgs, null, null, sortOrder);
            return cursor;
        }

        //@Override
        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {

            //Log.v(TAG, "Insert(uri=" + uri + ", values=" + values.toString());
            SQLiteDatabase db = mDBHelper.WritableDatabase;
            int match = sUriMatcher.Match(uri);
            //
            switch (match)
            {
                case SCORECARD:
                    long recordid = db.InsertOrThrow(BowlingDatabase.Table_SCORECARD, null, values);
                    return BowlingContract.BCScorecard.buildScorecardUri(recordid.ToString());
                default:
                    throw new Exception("Unknown uri: " + uri);
            }
        }

        //@Override
        public override int Update(Android.Net.Uri uri, ContentValues values, String selection, String[] selectionArgs)
        {

            //Log.v(TAG, "Update(uri=" + uri + ", values=" + values.toString());
            SQLiteDatabase db = mDBHelper.WritableDatabase;
            int match = sUriMatcher.Match(uri);
            //
            String selectionCriteria = selection;
            switch (match)
            {
                case SCORECARD:
                    // do nothing
                    break;
                case SCORECARD_ID:
                    String id = BowlingContract.BCScorecard.getScorecardId(uri);
                    // not used but sample.
                    selectionCriteria = BowlingContract.BaseColumns._ID + "=" + id;
//                            + (!TextUtils.isEmpty(selection) ? " AND (" + selection + ")" : "");
                    break;
                default:
                    throw new Exception("Unknown uri: " + uri);
            }
            return db.Update(BowlingDatabase.Table_SCORECARD, values, selectionCriteria, selectionArgs);
        }

        //@Override
        public override int Delete(Android.Net.Uri uri, String selection, String[] selectionArgs)
        {

            // Log.v(TAG, "Delete(uri=" + uri + ", selection=" + selection + ", Args=" + selectionArgs);
            if (uri.Equals(BowlingContract.BCScorecard.CONTENT_URI))
            {
                deleteDatabase();
                return 0;
            }

            SQLiteDatabase db = mDBHelper.WritableDatabase;
            int match = sUriMatcher.Match(uri);
            //
            String selectionCriteria = selection;
            switch (match)
            {
                case SCORECARD_ID:
                    String id = BowlingContract.BCScorecard.getScorecardId(uri);
                    // not used but sample.
                    selectionCriteria = BowlingContract.BaseColumns._ID + "=" + id;
                    //                       + (!TextUtils.isEmpty(selection) ? " AND (" + selection + ")" : "");
                    return db.Delete(BowlingDatabase.Table_SCORECARD, selectionCriteria, selectionArgs);
                default:
                    throw new Exception("Unknown uri: " + uri);
            }
        }

    }
}