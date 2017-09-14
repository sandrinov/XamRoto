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
//using NationalPark.Standard;

namespace NationalPark.Droid
{
    public class NationalParksAdapter : BaseAdapter<NationalParkPortable.NationalPark>
    {
        private Activity _context;

        public NationalParksAdapter(Activity context)
        {
            _context = context;
        }

        public override int Count
        {
            get { return NationalParkPortable.NationalParksData.Instance.Parks.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override NationalParkPortable.NationalPark this[int position]
        {
            get { return NationalParkPortable.NationalParksData.Instance.Parks[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = NationalParkPortable.NationalParksData.Instance.Parks[position].Name;

            return view;
        }
    }
}