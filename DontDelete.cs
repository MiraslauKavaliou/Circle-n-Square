using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDelete : MonoBehaviour
{
    private static DontDelete playerInstance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null) 
        {
            playerInstance = this;
        } 
        else 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
