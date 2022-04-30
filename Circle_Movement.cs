using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Movement : MonoBehaviour
{
    Transform tf;
    Rigidbody2D rb;
    [SerializeField] float speed;
    public bool rightButton;
    public bool leftButton;
    float turn;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightButton && !leftButton){
            turn = -1;
        }
        else if (!rightButton && leftButton){
            turn = 1;
        }
        else{
            turn = 0;
        }
        rb.AddTorque(speed*turn*-1f, ForceMode2D.Force);
    }
}
