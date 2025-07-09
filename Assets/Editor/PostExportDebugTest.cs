using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System;

/// <summary>
/// Post-Export Debug Test - This script runs AFTER Unity builds the player
/// According to the forum post, this should work correctly and show formatted Debug.Log calls
/// This serves as a control test to verify the bug is specific to pre-build/pre-export scripts
/// </summary>
public class PostExportDebugTest : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log("=== POST-EXPORT DEBUG TEST START ===");
        Debug.Log("Unity Version: " + Application.unityVersion);
        Debug.Log("Build Target: " + report.summary.platform);
        Debug.Log("Build Result: " + report.summary.result);
        
        // Test 1: Simple Debug.Log (should work)
        Debug.Log("Test 1: Simple log message - this should work");
        
        // Test 2: String concatenation (should work in post-export)
        string testString = "PostExportValue";
        Debug.Log("Test 2: String concatenation [" + testString + "] - this should work");
        
        // Test 3: String interpolation (should work in post-export)
        int testNumber = 456;
        Debug.Log($"Test 3: String interpolation [{testNumber}] - this should work");
        
        // Test 4: String.Format (should work in post-export)
        Debug.Log(String.Format("Test 4: String.Format [{0}] - this should work", testString));
        
        // Test 5: BuildTargetGroup enum (should work in post-export)
        BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("Test 5a: BuildTargetGroup enum concatenation [" + buildTargetGroup + "] - this should work");
        Debug.Log($"Test 5b: BuildTargetGroup enum interpolation [{buildTargetGroup}] - this should work");
        Debug.Log(String.Format("Test 5c: BuildTargetGroup enum String.Format [{0}] - this should work", buildTargetGroup));
        
        // Test 6: Build report information
        Debug.Log("Test 6a: Build size concat [" + report.summary.totalSize + " bytes]");
        Debug.Log($"Test 6b: Build size interpolation [{report.summary.totalSize} bytes]");
        Debug.Log(String.Format("Test 6c: Build size format [{0} bytes]", report.summary.totalSize));
        
        // Test 7: Build time information
        Debug.Log("Test 7a: Build time concat [" + report.summary.buildStartedAt + "]");
        Debug.Log($"Test 7b: Build time interpolation [{report.summary.buildStartedAt}]");
        Debug.Log(String.Format("Test 7c: Build time format [{0}]", report.summary.buildStartedAt));
        
        // Test 8: Output path information
        Debug.Log("Test 8a: Output path concat [" + report.summary.outputPath + "]");
        Debug.Log($"Test 8b: Output path interpolation [{report.summary.outputPath}]");
        Debug.Log(String.Format("Test 8c: Output path format [{0}]", report.summary.outputPath));
        
        // Test 9: Complex build report data
        Debug.Log("Test 9a: Total warnings concat [" + report.summary.totalWarnings + "]");
        Debug.Log($"Test 9b: Total warnings interpolation [{report.summary.totalWarnings}]");
        Debug.Log(String.Format("Test 9c: Total warnings format [{0}]", report.summary.totalWarnings));
        
        Debug.Log("=== POST-EXPORT DEBUG TEST END ===");
    }
}