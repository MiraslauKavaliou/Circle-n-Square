using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerText : MonoBehaviour
{
    float TextTimer;
    // Start is called before the first frame update
    void Start()
    {
        TextTimer = Mathf.RoundToInt(Time.realtimeSinceStartup - GameObject.Find("LoaderShape").GetComponent<LoadingVars>().gameStartTime);
        float minutes = Mathf.Floor(TextTimer / 60);
        float seconds = Mathf.RoundToInt(TextTimer%60);
        gameObject.GetComponent<Text>().text = (minutes.ToString() + ":" + seconds.ToString());
    }

    // Update is called once per frame
    public void OnRetry()
    {
        GameObject.Find("LoaderShape").GetComponent<LoadingVars>().gameStartTime = 0;
        SceneManager.LoadScene(0);
    }
}
