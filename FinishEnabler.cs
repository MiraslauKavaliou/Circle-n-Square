using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MakeFinish", 0.5f);
    }

    void MakeFinish()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
