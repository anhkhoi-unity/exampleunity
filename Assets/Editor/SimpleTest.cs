using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System;

/// <summary>
/// Simple test to isolate the exact issue
/// </summary>
public class SimpleTest : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        NamedBuildTarget buildTarget = NamedBuildTarget.FromBuildTargetGroup(buildTargetGroup);
        
        Debug.Log("=== SIMPLE TEST START ===");

// Test 1: Enum implicit cast (original fails; fix by explicit ToString to avoid cast bug)
Debug.Log("[akv] Build target group interpolation [" + buildTargetGroup.ToString() + "]");  // Changed from $"" to concat + ToString

// Test 2: String.Format with object property (original fails; fix by concat + explicit ToString)
Debug.Log("[akv] Build target [" + buildTarget.TargetName.ToString() + "]");  // Ditched Format, used concat + ToString

// Test 3: Simple string (already works; no change needed)
Debug.Log("[akv] Simple log message should work");

// Test 4: String concatenation (original flaky; add explicit ToString for safety)
Debug.Log("[akv] Build target concatenation [" + buildTarget.TargetName.ToString() + "]");  // Added ToString to prevent implicit issues

        
        // Test 1: Enum implicit cast (should fail according to user)
        Debug.Log($"Build target group interpolation [{buildTargetGroup}]");
        
        // Test 2: String.Format with object property (should fail according to user)  
        Debug.Log(String.Format("Build target [{0}]", buildTarget.TargetName));
        
        // Test 3: Simple string (should work)
        Debug.Log("Simple log message should work");
        
        // Test 4: String concatenation (should work based on previous evidence)
        Debug.Log("Build target concatenation [" + buildTarget.TargetName + "]");
        
        Debug.Log("=== SIMPLE TEST END ===");
    }
}
