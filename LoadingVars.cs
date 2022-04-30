using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingVars : MonoBehaviour
{
    public string LoadShape = "";
    public float scaleAtEnd = 1;
    public int jumpCount = 0;
    public float gameStartTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameStartTime = Time.realtimeSinceStartup;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
