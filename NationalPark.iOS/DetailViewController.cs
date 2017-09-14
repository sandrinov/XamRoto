using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace NationalPark.iOS
{
	public partial class DetailViewController : UIViewController
	{
        IList<NationalPark> _parks;
        NationalPark _park;

        public DetailViewController (IntPtr handle) : base (handle)
		{
		}

        public void SetNavData(IList<NationalPark> parks, NationalPark park)
        {
            _parks = parks;
            _park = park;
        }
        protected void ToUI()
        {
            // Update the user interface for the detail item
            if (_park != null)
            {
                nameLabel.Text = _park.Name;
                descriptionLabel.Text = _park.Description.Substring(0,20) + "...";
                stateLabel.Text = _park.State;
                countryLabel.Text = _park.Country;
                latitudeLabel.Text = _park.Latitude.ToString();
                longitudeLabel.Text = _park.Longitude.ToString();
            }
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
        public override void ViewWillAppear(bool animated)
        {
            ToUI();
        }
        partial void PhotoClicked(UIButton sender)
        {
            string encodedUriString = Uri.EscapeUriString(String.Format("http://www.bing.com/images/search?q={0}", _park.Name));
            NSUrl url = new NSUrl(encodedUriString);
            UIApplication.SharedApplication.OpenUrl(url);
        }
        partial void DirectionsClicked(UIButton sender)
        {
            if ((_park.Latitude.HasValue) && (_park.Longitude.HasValue))
            {
                NSUrl url = new NSUrl(
                    String.Format("http://maps.apple.com/maps?daddr={0},{1}", _park.Latitude, _park.Longitude));

                UIApplication.SharedApplication.OpenUrl(url);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "editFromDetail")
            {
                var controller = (EditViewController)segue.DestinationViewController;
                controller.SetNavData(_parks, _park);
            }
        }
    }
}


