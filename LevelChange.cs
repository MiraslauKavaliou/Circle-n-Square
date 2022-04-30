using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    Transform tf;
    Rigidbody2D rb;
    Rigidbody2D rbo;
    bool Switching = false;
    bool Loading = false;
    float scaleAtEnd = 1;
    GameObject LoadVars;
    LoadingVars lv;
    Square_Movment sqm = null;

    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        LoadVars = GameObject.Find("LoaderShape");
        if (gameObject.name == "Circle"){
            rbo = GameObject.Find("Square").GetComponent<Rigidbody2D>();
        }
        else{
            rbo = GameObject.Find("Circle").GetComponent<Rigidbody2D>();
            sqm = gameObject.GetComponent<Square_Movment>();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1){return;}
        if (LoadVars.GetComponent<LoadingVars>().LoadShape != gameObject.name) {return;}
        if (sqm != null) {sqm.Switching = true;}
        scaleAtEnd = LoadVars.GetComponent<LoadingVars>().scaleAtEnd;
        tf = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        tf.localScale = new Vector3(scaleAtEnd,scaleAtEnd,scaleAtEnd);
        tf.position = tf.position + new Vector3 (0, 0, -1f);
        rb.isKinematic = true;
        rbo.isKinematic = true;
        rb.Sleep();
        rbo.Sleep();
        Switching = false;
        Loading = true;
        Invoke("LoadedScene",0.5f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            tf.position = tf.position + new Vector3 (0, 0, -1f);
            rb.isKinematic = true;
            rbo.isKinematic = true;
            rb.Sleep();
            rbo.Sleep();
            Switching = true;
            LoadVars.GetComponent<LoadingVars>().LoadShape = gameObject.name;
            if (sqm != null) {LoadVars.GetComponent<LoadingVars>().jumpCount = sqm.jumpCount; sqm.Switching = true;}
            Invoke("NextScene",1);
        }
    }

    void Update()
    {
        if (Switching) {tf.localScale = tf.localScale*1.1f; LoadVars.GetComponent<LoadingVars>().scaleAtEnd = tf.localScale.x;}
        if (Loading) {tf.localScale = tf.localScale/1.2f;}
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadedScene()
    {
        tf = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        tf.localScale = new Vector3(1,1,1);
        tf.position = tf.position + new Vector3 (0, 0, 0f);
        rb.isKinematic = false;
        rbo.isKinematic = false;
        rb.WakeUp();
        rbo.WakeUp();
        if (sqm != null) {sqm.Switching = false;}
        Loading = false;
    }
}
