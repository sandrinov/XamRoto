using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;

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
            //var mydocuments = System.Environment.SpecialFolder.Personal;

            //NationalParksData.Instance.DataDir =
            //   System.Environment.GetFolderPath(mydocuments);

            NationalParksData.Instance.DataDir = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments);
            NationalParksData.Instance.Load();

            NationalParksData.Instance.Ctx = this;

            _adapter = new NationalParksAdapter(this);

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

