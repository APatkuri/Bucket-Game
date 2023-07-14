using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LogicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static float playerScore;
    public GameObject waterlevel;
    public GameObject gameoverscreen;
    public GameObject gameoverscreen2;
    public GameObject waterspawn;
    public GameObject trashspawn;
    public Slider slider;
    public bool isslidertouching = false;
    public bool gameovercheck = false;
    public Text scoretext;
    public Text percentagetext;
    public GameObject logicpart;
    public LogicPart lp;
    public Button restartlevelbutton;


    public float timeScale = 1f;
    
    void Start()
    {
        lp = logicpart.GetComponent<LogicPart>();
        restartlevelbutton.onClick.AddListener(restartgame);

        slider.value = slider.maxValue;
        Time.timeScale = 1f;
        slider.onValueChanged.AddListener(timespeed);

        int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue", 1);
        int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton", 1);

        Debug.Log(largestButtonValue + " " +  lastbuttonclick);
    }

    // Update is called once per frame
    void Update()
    {
        int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue");
        int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton", 1);
        updatescore();

        if (playerScore == 100 && !gameovercheck) {
            gameover();
            if(largestButtonValue < lastbuttonclick+1){
                largestButtonValue = lastbuttonclick + 1;;
                PlayerPrefs.SetInt("largestButtonValue", largestButtonValue);
            }
            Debug.Log(largestButtonValue + " " +  lastbuttonclick);
        }

    }

    public void updatescore(){
        // Debug.Log(waterlevel.transform.position.y + " " + BucketScript.maxheight + " " + BucketScript.minheight);

        playerScore = Mathf.Ceil((((waterlevel.transform.position.y - (float)BucketScript.maxheight)/((float)(BucketScript.minheight) - (float)BucketScript.maxheight))* 100));
        // playerScore = 50;
        if(playerScore >= 100){
            playerScore = 100;
        }
        
        scoretext.text = (playerScore*25).ToString();
        percentagetext.text = playerScore.ToString() + "%";        
    }

    public void restartgame(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton", 1);

        lp.leveldetail(lastbuttonclick);
    }

    public void gamestart(){
        waterspawn.SetActive(true);
        trashspawn.SetActive(true);
    }

    public void levelscreen(){
        SceneManager.LoadScene("LevelScene");
    }

    public void gameover(){
        gameoverscreen.SetActive(true);
        if(playerScore == 100){
            gameoverscreen.SetActive(false);
            gameoverscreen2.SetActive(true);
        }
        waterspawn.SetActive(false);
        trashspawn.SetActive(false);
        gameovercheck = true;
    }

    public void timespeed(float value){
        Time.timeScale =  value * timeScale;
    }

    public void OnPointerDown(){
        isslidertouching = true;
    }

    public void OnPointerUp(){
        isslidertouching = false;
    }
}
