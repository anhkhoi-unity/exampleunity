using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// Pre-Build Debug Test - This script can be called via Unity Cloud Build's pre-build script configuration
/// In Unity 6+, formatted Debug.Log calls should appear as empty lines in Unity Cloud Build logs
/// 
/// To use this in Unity Cloud Build:
/// 1. Set Pre-Build Script to: PreBuildDebugTest.RunPreBuildTest
/// 2. This will execute during the pre-build phase
/// </summary>
public class PreBuildDebugTest
{
    /// <summary>
    /// Static method that can be called from Unity Cloud Build pre-build script configuration
    /// </summary>
    public static void RunPreBuildTest()
    {
        Debug.Log("=== PRE-BUILD DEBUG TEST START ===");
        Debug.Log("Unity Version: " + Application.unityVersion);
        Debug.Log("Current Build Target: " + EditorUserBuildSettings.activeBuildTarget);
        
        // Test 1: Simple Debug.Log (should work)
        Debug.Log("Test 1: Simple log message - this should work");
        
        // Test 2: String concatenation (should show as empty line in Unity 6+)
        string testString = "PreBuildValue";
        Debug.Log("Test 2: String concatenation [" + testString + "] - this should be empty");
        
        // Test 3: String interpolation (should show as empty line in Unity 6+)
        int testNumber = 123;
        Debug.Log($"Test 3: String interpolation [{testNumber}] - this should be empty");
        
        // Test 4: String.Format (should show as empty line in Unity 6+)
        Debug.Log(String.Format("Test 4: String.Format [{0}] - this should be empty", testString));
        
        // Test 5: BuildTargetGroup enum (the original issue)
        BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("Test 5a: BuildTargetGroup enum concatenation [" + buildTargetGroup + "] - this should be empty");
        Debug.Log($"Test 5b: BuildTargetGroup enum interpolation [{buildTargetGroup}]");
        Debug.Log(String.Format("Test 5c: BuildTargetGroup enum String.Format [{0}]", buildTargetGroup));
        
        // Test 6: Project settings
        Debug.Log("Test 6a: Product name concat [" + PlayerSettings.productName + "]");
        Debug.Log($"Test 6b: Product name interpolation [{PlayerSettings.productName}]");
        Debug.Log(String.Format("Test 6c: Product name format [{0}]", PlayerSettings.productName));
        
        // Test 7: Editor preferences
        Debug.Log("Test 7a: Editor skin concat [" + EditorGUIUtility.isProSkin + "]");
        Debug.Log($"Test 7b: Editor skin interpolation [{EditorGUIUtility.isProSkin}]");
        Debug.Log(String.Format("Test 7c: Editor skin format [{0}]", EditorGUIUtility.isProSkin));
        
        // Test 8: System information
        Debug.Log("Test 8a: System info concat [" + SystemInfo.operatingSystem + "]");
        Debug.Log($"Test 8b: System info interpolation [{SystemInfo.operatingSystem}]");
        Debug.Log(String.Format("Test 8c: System info format [{0}]", SystemInfo.operatingSystem));
        
        Debug.Log("=== PRE-BUILD DEBUG TEST END ===");
    }
    
    /// <summary>
    /// Alternative method that can be called if the above doesn't work
    /// </summary>
    public static void TestPreBuildLogging()
    {
        RunPreBuildTest();
    }
}