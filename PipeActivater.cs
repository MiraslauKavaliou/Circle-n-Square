using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeActivater : MonoBehaviour
{
    public float activationTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivatePipeBox", activationTime);
    }

    void ActivatePipeBox()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
