using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject buttonType;
    public DoorManager Door;
    Material m_material;
    Transform tf;
    public Vector3 PressedPos = new Vector3(0,-0.1f,0);
    bool isPressed = false;
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        m_material = gameObject.GetComponent<Renderer>().material;
        Invoke("MakeButton", 0.5f);
    }

    void MakeButton()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == buttonType.name)
        {
            OnButton();
        }
    }
    void OnButton()
    {
        if (isPressed) {return;}
        m_material.color = Color.black;
        tf.position = tf.position + PressedPos;
        isPressed = true;
        Door.Open();
    }
}
