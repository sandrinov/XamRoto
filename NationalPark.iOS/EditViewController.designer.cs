// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NationalPark.iOS
{
    [Register ("EditViewController")]
    partial class EditViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem DoneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel editDescriptionLabel { get; set; }

        [Action ("DeleteClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeleteClicked (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DoneButton != null) {
                DoneButton.Dispose ();
                DoneButton = null;
            }

            if (editDescriptionLabel != null) {
                editDescriptionLabel.Dispose ();
                editDescriptionLabel = null;
            }
        }
    }
}