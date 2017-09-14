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

namespace NationalPark.Droid
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        NationalPark _park;

        EditText _nameEditText;
        EditText _descrEditText;
        EditText _stateEditText;
        EditText _countryEditText;
        EditText _latEditText;
        EditText _longEditText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Edit);

            if (Intent.HasExtra("parkid"))
            {
                string parkId = Intent.GetStringExtra("parkid");
                _park = NationalParksData.Instance.Parks.FirstOrDefault(x => x.Id == parkId);
            }
            else
                _park = new NationalPark();

            _nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            _descrEditText = FindViewById<EditText>(Resource.Id.descrEditText);
            _stateEditText = FindViewById<EditText>(Resource.Id.stateEditText);
            _countryEditText = FindViewById<EditText>(Resource.Id.countryEditText);
            _latEditText = FindViewById<EditText>(Resource.Id.latEditText);
            _longEditText = FindViewById<EditText>(Resource.Id.longEditText);
        }

        protected override void OnResume()
        {
            base.OnResume();

            ParkToUI();
        }
        protected void ParkToUI()
        {
            _nameEditText.Text = _park.Name;
            _descrEditText.Text = _park.Description;
            _stateEditText.Text = _park.State;
            _countryEditText.Text = _park.Country;
            _latEditText.Text = _park.Latitude.ToString();
            _longEditText.Text = _park.Longitude.ToString();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.EditMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionSave:
                    SavePark();
                    return true;

                case Resource.Id.actionDelete:
                    DeletePark();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected void SavePark()
        {
            UIToPark();
            NationalParksData.Instance.Save(_park);

            Intent returnIntent = new Intent();
            returnIntent.PutExtra("parkdeleted", false);
            SetResult(Result.Ok, returnIntent);

            Finish();
        }
        protected void DeletePark()
        {
            NationalParksData.Instance.Delete(_park);

            Intent returnIntent = new Intent();
            returnIntent.PutExtra("parkdeleted", true);
            SetResult(Result.Ok, returnIntent);

            Finish();
        }
        protected void UIToPark()
        {
            _park.Name = _nameEditText.Text;
            _park.Description = _descrEditText.Text;
            _park.State = _stateEditText.Text;
            _park.Country = _countryEditText.Text;

            if (!String.IsNullOrEmpty(_latEditText.Text))
                _park.Latitude = Double.Parse(_latEditText.Text);
            else
                _park.Latitude = null;

            if (!String.IsNullOrEmpty(_longEditText.Text))
                _park.Longitude = Double.Parse(_longEditText.Text);
            else
                _park.Longitude = null;
        }
    }
}
