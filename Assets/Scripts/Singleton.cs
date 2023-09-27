using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton get;
    private static int instanceCount = 0;

    private void Awake()
    {
        if (get == null)
        {
            get = this;
            DontDestroyOnLoad(this.gameObject);
            instanceCount++;
        }
        else if (instanceCount > 1)
        {
            Destroy(this.gameObject);
            instanceCount--;
            Debug.LogError("Multiple instances of Singleton detected!");
            Debug.LogError("Instance Count: " + instanceCount);
            return;
        }
    }
}
