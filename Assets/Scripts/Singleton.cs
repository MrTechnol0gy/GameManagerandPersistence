using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton get;

    private void Awake()
    {
        if (get == null)
        {
            get = this;
            DontDestroyOnLoad(this.gameObject); // This will make the object persist between scenes
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
