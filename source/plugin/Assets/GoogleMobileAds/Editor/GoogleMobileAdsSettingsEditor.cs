using UnityEditor;
using UnityEngine;

namespace GoogleMobileAds.Editor
{

    [InitializeOnLoad]
    [CustomEditor(typeof(GoogleMobileAdsSettings))]
    public class GoogleMobileAdsSettingsEditor : UnityEditor.Editor
    {
        private const string MobileAdsSettingsResDir = "Assets/GoogleMobileAds/Resources";

        private const string MobileAdsSettingsFile = "GoogleMobileAdsSettings.asset";

        [MenuItem("Assets/Google Mobile Ads/Settings...")]
        public static void OpenInspector()
        {
            Selection.activeObject = GetInstance();
        }

        internal static GoogleMobileAdsSettings GetInstance()
        {
            // load a settings instance from disk
            var instance = Resources.Load<GoogleMobileAdsSettings>(MobileAdsSettingsFile);

            //create a settings instance if null
            if (instance == null)
            {
                Directory.CreateDirectory(MobileAdsSettingsResDir);
                instance = ScriptableObject.CreateInstance<GoogleMobileAdsSettings>();
                string assetPath = Path.Combine(MobileAdsSettingsResDir, MobileAdsSettingsFile);
                AssetDatabase.CreateAsset(instance, assetPath);
                AssetDatabase.SaveAssets();
            }

            return instance;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var settings = target as GoogleMobileAdsSettings;

            EditorGUILayout.LabelField("Google Mobile Ads App ID", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(
                serializedObject.FindProperty("adMobAndroidAppId"),
                new GUIContent("Android"));

            EditorGUILayout.PropertyField(
                serializedObject.FindProperty("adMobIOSAppId"),
                new GUIContent("iOS"));

            EditorGUILayout.HelpBox(
                    "Google Mobile  Ads App ID will look similar to this sample ID: ca-app-pub-3940256099942544~3347511713",
                    MessageType.Info);

            EditorGUI.indentLevel--;
            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("AdMob-specific settings", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(
                serializedObject.FindProperty("delayAppMeasurementInit"),
                new GUIContent("Delay app measurement"));

            if (settings.DelayAppMeasurementInit) {
                EditorGUILayout.HelpBox(
                        "Delays app measurement until you explicitly initialize the Mobile Ads SDK or load an ad.",
                        MessageType.Info);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Separator();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
