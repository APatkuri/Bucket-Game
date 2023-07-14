using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreenScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject presstoplay;
    public Button Settingsbutton;
    public Button Playbutton;
    public Button levelbutton;
    public float timer;
    public GameObject logicpart;
    public LogicPart lp;
    void Start()
    {
        lp = logicpart.GetComponent<LogicPart>();

        Settingsbutton.onClick.AddListener(settingsclick);
        Playbutton.onClick.AddListener(playclick);
        levelbutton.onClick.AddListener(levelclick);
    }

    // Update is called once per frame
    void Update()
    {

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     StartCoroutine(SwitchScene());
        // }

        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
        //     StartCoroutine(SwitchScene());
        // }

        flashingtext();        
    }

    // IEnumerator SwitchScene()
    // {
    //     yield return new WaitForSeconds(0.25f);
    //     Debug.Log("LevelScreen");
    //     SceneManager.LoadScene("LevelScene");
    // }

    public void settingsclick(){
        SceneManager.LoadScene("SettingScreen");
    }

    public void levelclick(){
        SceneManager.LoadScene("LevelScene");
    }

    public void playclick(){
        int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue", 1);
        int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton");

        lp.leveldetail(largestButtonValue);
    }

    public void flashingtext(){
        timer = timer + Time.deltaTime;
        if(timer >= 0.5){
            presstoplay.SetActive(true);
        }
        if(timer >= 1){
            presstoplay.SetActive(false);
            timer=0;
        }
    }

    

}
