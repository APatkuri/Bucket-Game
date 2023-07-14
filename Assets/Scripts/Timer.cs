using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicManager logic;
    public Text times;
    public Text coundowntext;
    public Text levelno;
    public static float timeremaining = 45.0f;
    public float countdowntime = 4.0f;
    public bool levelshown = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        coundowntext.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdowntime > 1){
            countdowntime -= Time.deltaTime;
            int seconds = Mathf.FloorToInt(countdowntime % 60);
            coundowntext.text = seconds.ToString();
        }

        else{
            if(levelshown){
                StartCoroutine(Showlevel());
            }
            coundowntext.enabled = false;



            if(timeremaining > 1 && !logic.gameovercheck){
                logic.gamestart();
                timeremaining -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(timeremaining % 60);
                times.text = seconds.ToString();
            }

            else{
                logic.gameover();
            }
        } 
    }

    IEnumerator Showlevel(){
        int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton", 1);
        levelno.enabled = true;
        levelno.text = "LEVEL " + lastbuttonclick;
        yield return new WaitForSeconds(0.5f);
        levelno.enabled = false;
        levelshown = false;
    }
}
