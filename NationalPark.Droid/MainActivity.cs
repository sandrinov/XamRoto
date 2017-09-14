using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using NationalParks.IO;
using NationalParkPortable;
//using NationalPark.Standard;

namespace NationalPark.Droid
{
    [Activity(Label = "NationalPark.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        NationalParksAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            #region Droid only
            //var mydocuments = System.Environment.SpecialFolder.Personal;

            //NationalParksData.Instance.DataDir =
            //   System.Environment.GetFolderPath(mydocuments);
            #endregion

            #region Standard Library
            //NationalParksData.Instance.DataDir = System.Environment.GetFolderPath(
            //    System.Environment.SpecialFolder.MyDocuments);
            //NationalParksData.Instance.Load();
            #endregion

            // use only with assets resources (Not writable!!)
            //NationalParksData.Instance.Ctx = this;

            _adapter = new NationalParksAdapter(this);
            #region PCL
            NationalParksData.Instance.FileHandler = new FileHandler();
            NationalParksData.Instance.DataDir = System.Environment.GetFolderPath(
                                    System.Environment.SpecialFolder.MyDocuments);
            NationalParksData.Instance.Load();
            #endregion

            


            FindViewById<ListView>(Resource.Id.parksListView).Adapter = _adapter;
            FindViewById<ListView>(Resource.Id.parksListView).ItemClick += ParkClicked;
        }

        private void ParkClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("parkid", _adapter[e.Position].Id);
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionNew:
                    StartActivity(typeof(EditActivity));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _adapter.NotifyDataSetChanged();
        }

    }
}

