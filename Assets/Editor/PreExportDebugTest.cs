using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System;

/// <summary>
/// Pre-Export Debug Test - This script runs BEFORE Unity builds the player
/// In Unity 6+, formatted Debug.Log calls should appear as empty lines in Unity Cloud Build logs
/// </summary>
public class PreExportDebugTest : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("=== PRE-EXPORT DEBUG TEST START ===");
        Debug.Log("Unity Version: " + Application.unityVersion);
        Debug.Log("Build Target: " + report.summary.platform);
        
        // Test 1: Simple Debug.Log (should work)
        Debug.Log("Test 1: Simple log message - this should work");
        
        // Test 2: String concatenation (should show as empty line in Unity 6+)
        string testString = "TestValue";
        Debug.Log("Test 2: String concatenation [" + testString + "] - this should be empty");
        
        // Test 3: String interpolation (should show as empty line in Unity 6+)
        int testNumber = 42;
        Debug.Log($"Test 3: String interpolation [{testNumber}] - this should be empty");
        
        // Test 4: String.Format (should show as empty line in Unity 6+)
        Debug.Log(String.Format("Test 4: String.Format [{0}] - this should be empty", testString));
        
        // Test 5: BuildTargetGroup enum (the original issue)
        BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("Test 5a: BuildTargetGroup enum concatenation [" + buildTargetGroup + "] - this should be empty");
        Debug.Log($"Test 5b: BuildTargetGroup enum interpolation [{buildTargetGroup}]");
        Debug.Log(String.Format("Test 5c: BuildTargetGroup enum String.Format [{0}]", buildTargetGroup));
        
        // Test 6: NamedBuildTarget (the other part of the original issue)
        NamedBuildTarget namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(buildTargetGroup);
        Debug.Log("Test 6a: NamedBuildTarget concatenation [" + namedBuildTarget.TargetName + "] - this should be empty");
        Debug.Log($"Test 6b: NamedBuildTarget interpolation [{namedBuildTarget.TargetName}]");
        Debug.Log(String.Format("Test 6c: NamedBuildTarget String.Format [{0}]", namedBuildTarget.TargetName));
        
        // Test 7: Complex formatting
        Debug.Log("Test 7a: Multiple values - " + testString + " and " + testNumber);
        Debug.Log($"Test 7b: Multiple values - {testString} and {testNumber}");
        Debug.Log(String.Format("Test 7c: Multiple values - {0} and {1}", testString, testNumber));
        
        // Test 8: Edge cases
        Debug.Log("Test 8a: Empty string concat [" + "" + "]");
        Debug.Log($"Test 8b: Empty string interpolation [{""}]");
        Debug.Log(String.Format("Test 8c: Empty string format [{0}]", ""));
        
        // Test 9: Null handling
        string nullString = null;
        Debug.Log("Test 9a: Null concat [" + nullString + "]");
        Debug.Log($"Test 9b: Null interpolation [{nullString}]");
        Debug.Log(String.Format("Test 9c: Null format [{0}]", nullString));
        
        Debug.Log("=== PRE-EXPORT DEBUG TEST END ===");
    }
}