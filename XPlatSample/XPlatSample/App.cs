#if __ANDROID__
using XPlatSample.Droid;
#elif __IOS__
using XPlatSample.iOS.Helpers;
#elif WINDOWS_UWP
using XPlatSample.UWP.Helpers;
#endif
using XPlatSample.Helpers;
using XPlatSample.Interfaces;
using XPlatSample.Services;
using XPlatSample.Model;

namespace XPlatSample
{
    public partial class App 
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            ServiceLocator.Instance.Register<IMessageDialog, MessageDialog>();
            //ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}