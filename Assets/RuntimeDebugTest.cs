using UnityEngine;
using System;

/// <summary>
/// Runtime Debug Test - This script tests Debug.Log formatting during runtime
/// This should work correctly as it's not affected by the Unity Cloud Build log filtering
/// This serves as a control test to verify the bug is specific to build-time execution
/// </summary>
public class RuntimeDebugTest : MonoBehaviour
{
    [Header("Test Configuration")]
    [Tooltip("Run tests automatically on Start")]
    public bool runOnStart = true;
    
    [Tooltip("Run tests when space key is pressed")]
    public bool runOnKeyPress = true;
    
    [Tooltip("Interval between automatic test runs (0 = run once)")]
    public float testInterval = 0f;
    
    private float lastTestTime;
    
    void Start()
    {
        if (runOnStart)
        {
            RunRuntimeDebugTest();
        }
    }
    
    void Update()
    {
        // Run on key press
        if (runOnKeyPress && Input.GetKeyDown(KeyCode.Space))
        {
            RunRuntimeDebugTest();
        }
        
        // Run on interval
        if (testInterval > 0 && Time.time - lastTestTime >= testInterval)
        {
            RunRuntimeDebugTest();
            lastTestTime = Time.time;
        }
    }
    
    /// <summary>
    /// Run the runtime debug test - this should work correctly
    /// </summary>
    public void RunRuntimeDebugTest()
    {
        Debug.Log("=== RUNTIME DEBUG TEST START ===");
        Debug.Log("Unity Version: " + Application.unityVersion);
        Debug.Log("Platform: " + Application.platform);
        Debug.Log("Time: " + Time.time);
        
        // Test 1: Simple Debug.Log (should work)
        Debug.Log("Test 1: Simple log message - this should work");
        
        // Test 2: String concatenation (should work at runtime)
        string testString = "RuntimeValue";
        Debug.Log("Test 2: String concatenation [" + testString + "] - this should work");
        
        // Test 3: String interpolation (should work at runtime)
        int testNumber = 789;
        Debug.Log($"Test 3: String interpolation [{testNumber}] - this should work");
        
        // Test 4: String.Format (should work at runtime)
        Debug.Log(String.Format("Test 4: String.Format [{0}] - this should work", testString));
        
        // Test 5: GameObject information
        Debug.Log("Test 5a: GameObject name concat [" + gameObject.name + "]");
        Debug.Log($"Test 5b: GameObject name interpolation [{gameObject.name}]");
        Debug.Log(String.Format("Test 5c: GameObject name format [{0}]", gameObject.name));
        
        // Test 6: Transform information
        Debug.Log("Test 6a: Position concat [" + transform.position + "]");
        Debug.Log($"Test 6b: Position interpolation [{transform.position}]");
        Debug.Log(String.Format("Test 6c: Position format [{0}]", transform.position));
        
        // Test 7: System information
        Debug.Log("Test 7a: System memory concat [" + SystemInfo.systemMemorySize + " MB]");
        Debug.Log($"Test 7b: System memory interpolation [{SystemInfo.systemMemorySize} MB]");
        Debug.Log(String.Format("Test 7c: System memory format [{0} MB]", SystemInfo.systemMemorySize));
        
        // Test 8: Time information
        Debug.Log("Test 8a: Frame count concat [" + Time.frameCount + "]");
        Debug.Log($"Test 8b: Frame count interpolation [{Time.frameCount}]");
        Debug.Log(String.Format("Test 8c: Frame count format [{0}]", Time.frameCount));
        
        // Test 9: Screen information
        Debug.Log("Test 9a: Screen resolution concat [" + Screen.width + "x" + Screen.height + "]");
        Debug.Log($"Test 9b: Screen resolution interpolation [{Screen.width}x{Screen.height}]");
        Debug.Log(String.Format("Test 9c: Screen resolution format [{0}x{1}]", Screen.width, Screen.height));
        
        // Test 10: Complex formatting
        Debug.Log("Test 10a: Multiple values - " + testString + " and " + testNumber + " at " + Time.time);
        Debug.Log($"Test 10b: Multiple values - {testString} and {testNumber} at {Time.time}");
        Debug.Log(String.Format("Test 10c: Multiple values - {0} and {1} at {2}", testString, testNumber, Time.time));
        
        Debug.Log("=== RUNTIME DEBUG TEST END ===");
    }
    
    /// <summary>
    /// Public method that can be called from UI or other scripts
    /// </summary>
    public void TriggerTest()
    {
        RunRuntimeDebugTest();
    }
}