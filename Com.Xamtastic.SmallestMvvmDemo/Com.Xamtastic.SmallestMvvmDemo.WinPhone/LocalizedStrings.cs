using Com.Xamtastic.SmallestMvvmDemo.WinPhone.Resources;

namespace Com.Xamtastic.SmallestMvvmDemo.WinPhone
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
