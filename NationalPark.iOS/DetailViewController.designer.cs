// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NationalPark.iOS
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel countryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Edit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel latitudeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel longitudeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel stateLabel { get; set; }

        [Action ("DirectionsClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DirectionsClicked (UIKit.UIButton sender);

        [Action ("PhotoClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhotoClicked (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (countryLabel != null) {
                countryLabel.Dispose ();
                countryLabel = null;
            }

            if (descriptionLabel != null) {
                descriptionLabel.Dispose ();
                descriptionLabel = null;
            }

            if (Edit != null) {
                Edit.Dispose ();
                Edit = null;
            }

            if (latitudeLabel != null) {
                latitudeLabel.Dispose ();
                latitudeLabel = null;
            }

            if (longitudeLabel != null) {
                longitudeLabel.Dispose ();
                longitudeLabel = null;
            }

            if (nameLabel != null) {
                nameLabel.Dispose ();
                nameLabel = null;
            }

            if (stateLabel != null) {
                stateLabel.Dispose ();
                stateLabel = null;
            }
        }
    }
}