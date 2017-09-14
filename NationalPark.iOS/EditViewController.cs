using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;

namespace NationalPark.iOS
{
    public partial class EditViewController : UIViewController
    {
        IList<NationalPark> _parks;
        NationalPark _park;
        public EditViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DoneButton.Clicked += DoneClicked;

            ToUI();
        }
        public void SetNavData(IList<NationalPark> parks, NationalPark park)
        {
            _parks = parks;
            _park = park;

            ToUI();
        }
        private void ToUI()
        {
            // Update the user interface for the detail item
            if (IsViewLoaded && _park != null)
            {
                editDescriptionLabel.Text = _park.Name;
            }
        }
        private void SaveParks()
        {
            string dataFolder = Environment.CurrentDirectory;
            string seraializedParks = JsonConvert.SerializeObject(_parks);
            File.WriteAllText(Path.Combine(dataFolder, "NationalParks.json"), seraializedParks);
        }
        private void DoneClicked(object sender, EventArgs e)
        {
            if (!_parks.Contains(_park))
                _parks.Add(_park);

            SaveParks();

            NavigationController.PopViewController(true);
        }
        partial void DeleteClicked(UIButton sender)
        {
            if (_parks.Contains(_park))
                _parks.Remove(_park);

            SaveParks();

            NavigationController.PopToRootViewController(true);
        }
    }
}