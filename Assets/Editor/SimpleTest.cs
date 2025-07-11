using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

/// <summary>
/// Simple test to isolate the exact issue
/// </summary>
public class SimpleTest : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        
        Debug.Log("=== SIMPLE TEST START ===");
        
        // Test the exact pattern you mentioned
        Debug.Log($"Test 5b: BuildTargetGroup enum interpolation [{buildTargetGroup}] - this should work");
        Debug.Log($"Test 5b: BuildTargetGroup enum interpolation [{buildTargetGroup}]");
        
        Debug.Log("=== SIMPLE TEST END ===");
    }
}