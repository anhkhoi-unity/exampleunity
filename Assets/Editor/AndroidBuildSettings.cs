using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;

public class AndroidBuildSettings : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        if (report.summary.platform == BuildTarget.Android)
        {
            bool previousValue = PlayerSettings.Android.splitApplicationBinary;
            PlayerSettings.Android.splitApplicationBinary = true;
            
            // Use both Debug.Log and File.WriteAllText for Cloud Build visibility
            string message = $"Android splitApplicationBinary changed from {previousValue} to {PlayerSettings.Android.splitApplicationBinary}";
            Debug.Log($"[Build Settings] {message}");
            
            // Write to a file that Cloud Build will include in logs
            string logPath = Path.Combine(Application.dataPath, "..", "CloudBuildLog.txt");
            File.WriteAllText(logPath, message);
            
            AssetDatabase.SaveAssets();
        }
    }

    // Keep the menu item for manual configuration
    [MenuItem("Build/Configure Android Settings")]
    public static void ConfigureAndroidSettings()
    {
        bool previousValue = PlayerSettings.Android.splitApplicationBinary;
        PlayerSettings.Android.splitApplicationBinary = true;
        Debug.Log($"Manual Configuration: splitApplicationBinary setting changed from {previousValue} to {PlayerSettings.Android.splitApplicationBinary}");
        AssetDatabase.SaveAssets();
    }

    public static void PreExport(UnityEngine.CloudBuild.BuildManifestObject manifest)
    {
        bool previousValue = PlayerSettings.Android.splitApplicationBinary;
        PlayerSettings.Android.splitApplicationBinary = true;
        Debug.Log($"[Cloud Build PreExport] Android splitApplicationBinary changed from {previousValue} to {PlayerSettings.Android.splitApplicationBinary}");
    }
} 