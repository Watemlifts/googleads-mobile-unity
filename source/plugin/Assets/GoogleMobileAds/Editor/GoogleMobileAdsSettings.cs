using System.IO;
using UnityEditor;
using UnityEngine;

namespace GoogleMobileAds.Editor
{
    internal class GoogleMobileAdsSettings : ScriptableObject
    {
        private static GoogleMobileAdsSettings instance;

        [SerializeField]
        private string adMobAndroidAppId = string.Empty;

        [SerializeField]
        private string adMobIOSAppId = string.Empty;

        [SerializeField]
        private bool delayAppMeasurementInit;

        public string GoogleMobileAdsAndroidAppId
        {
            get { return adMobAndroidAppId; }

            set { adMobAndroidAppId = value; }
        }

        public string GoogleMobileAdsIOSAppId
        {
            get { return adMobIOSAppId; }

            set { adMobIOSAppId = value; }
        }

        public bool DelayAppMeasurementInit
        {
            get { return delayAppMeasurementInit; }

            set { delayAppMeasurementInit = value; }
        }
    }
}
