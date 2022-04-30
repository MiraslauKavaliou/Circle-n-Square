using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    Transform tf;
    public Vector3 OpenPos;
    Vector3 OpentfPos;
    public int framesToOpen;
    int framesSinceOpen;
    public int NeededOpenNum = 1;
    int OpenNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenNum >= NeededOpenNum && framesSinceOpen < framesToOpen)
        {
            tf.position = OpentfPos + (OpenPos/framesToOpen)*framesSinceOpen;
            framesSinceOpen++;
        }
    }

    public void Open()
    {
        if (OpenNum >= NeededOpenNum) {return;}
        OpenNum++;
        if (OpenNum >= NeededOpenNum) {OpentfPos = tf.position;}
    }
}
