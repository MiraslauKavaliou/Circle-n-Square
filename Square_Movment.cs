using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Movment : MonoBehaviour
{
    Transform tf;
    Rigidbody2D rb;
    [SerializeField] float thrust;
    public LayerMask jumpableLayer;
    Material m_Material;
    GameObject LoadVars;
    int LastGround = 0;
    public int jumpCount;
    public bool Switching;
    public bool jumpButton = false;
    // Start is called before the first frame update
    void Start()
    {
        LoadVars = GameObject.Find("LoaderShape");
        tf = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        m_Material = GetComponent<Renderer>().material;
        jumpCount = LoadVars.GetComponent<LoadingVars>().jumpCount;
        m_Material.color = Color.white;
        if (jumpCount == 1)
        {
            m_Material.color = Color.grey;
        }
        if (jumpCount == 2)
        {
            m_Material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Switching) {return;}
        if (jumpCount != 0 && LastGround <= 0 && IsGrounded())
        {
            jumpCount = 0;
            m_Material.color = Color.white;
        }

        if (jumpButton && jumpCount < 2)
        {
            jumpButton = false;
            rb.velocity = new Vector2(rb.velocity.x,thrust);
            jumpCount++;
            if (jumpCount == 1)
            {
                LastGround = 5;
            }
        }
        if (jumpCount == 1)
        {
            m_Material.color = Color.grey;
        }
        if (jumpCount == 2)
        {
            m_Material.color = Color.black;
        }
        if (LastGround > 0)
        {
            LastGround--;
        }
    }
    bool IsGrounded() 
    {  
        Collider2D BottomCol = Physics2D.OverlapBox(gameObject.GetComponent<BoxCollider2D>().bounds.center + new Vector3(0f,-0.15f,0f), gameObject.GetComponent<BoxCollider2D>().bounds.size - new Vector3(0.2f,0.1f,0f), 0f, jumpableLayer);
        if (BottomCol == null){return false;}
        if (jumpableLayer == (jumpableLayer | (1 << BottomCol.gameObject.layer)))
        {
            return true;
        }
        return false;
    }
}
