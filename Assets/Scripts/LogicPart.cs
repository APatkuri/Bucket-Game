    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LogicPart : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject waterdrop;
        public Rigidbody2D grav;
        public Button[] b1;
        private string lastclickedButton;

        // void Awake(){
        //     PlayerPrefs.DeleteKey("largestButtonValue");
        //     PlayerPrefs.DeleteKey("lastclickedbutton");
        // }
        
        void Start()
        {
            grav = waterdrop.GetComponent<Rigidbody2D>();

            b1 = new Button[10];

            for (int i = 1; i <= 10; i++)
            {
                string buttonnames = i.ToString();
                b1[i - 1] = GameObject.Find(buttonnames).GetComponent<Button>();
                locking(b1[i-1]);
            }

            int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue");
            int lastbuttonclick = PlayerPrefs.GetInt("lastclickedbutton");
        }

        // Update is called once per frame
        void Update()
        {
            levelunlock();
        }

        public void levelunlock(){

            int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue");

            unlocking(b1[0]);

            for(int i=1; i<largestButtonValue; i++){
                unlocking(b1[i]);
            }           
        }

        public void level(Button button){
            
            string buttonName = button.name;
            lastclickedButton = buttonName;
            int buttonValue = int.Parse(buttonName);
            PlayerPrefs.SetInt("lastclickedbutton", buttonValue);
            int largestButtonValue = PlayerPrefs.GetInt("largestButtonValue", 1);
            if (buttonValue > largestButtonValue){
                largestButtonValue = buttonValue;
                PlayerPrefs.SetInt("largestButtonValue", largestButtonValue);
            }

            grav = waterdrop.GetComponent<Rigidbody2D>();

            if(buttonName == "1"){
                leveldetail(1);
            }

            if(buttonName == "2"){
                leveldetail(2);
            }

            if(buttonName == "3"){
                leveldetail(3);
            }

            if(buttonName == "4"){
                leveldetail(4);
            }

            if(buttonName == "5"){
                leveldetail(5);
            }

            if(buttonName == "6"){
                leveldetail(6);
            }

            if(buttonName == "7"){
                leveldetail(7);
            }

            if(buttonName == "8"){
                leveldetail(8);
            }

            if(buttonName == "9"){
                leveldetail(9);
            }

            if(buttonName == "10"){
                leveldetail(10);
            }
        }

        public void locking(Button button1){
            button1.transform.GetChild(1).GetComponent<Image>().enabled = true;
            button1.interactable = false;
            button1.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }

        public void unlocking(Button button1){
            button1.transform.GetChild(1).GetComponent<Image>().enabled = false;
            button1.interactable = true;
            button1.transform.GetChild(0).GetComponent<Text>().enabled = true;
        }

        public void homebutton(){
            SceneManager.LoadScene("HomeScene 1");
        }

        public void leveldetail(int level){

            grav = waterdrop.GetComponent<Rigidbody2D>();

            if(level == 1){
                grav.gravityScale = (float)3;
                TrashSpawnScript.trashspawnrate = 8;
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = 2;
                WaterSpawnScript.waterspawnlevel=1;
                Timer.timeremaining = 45.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 1);
            }

            if(level == 2){
                grav.gravityScale = (float)3;
                TrashSpawnScript.trashspawnrate = 7;
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.50;
                WaterSpawnScript.waterspawnlevel=1;
                Timer.timeremaining = 45.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 2);
            }

            if(level == 3){
                grav.gravityScale = (float)3;
                TrashSpawnScript.trashspawnrate = 7;
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.25;
                WaterSpawnScript.waterspawnlevel=1;
                Timer.timeremaining = 45.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 3);
            }

            if(level == 4){
                grav.gravityScale = (float)4;
                TrashSpawnScript.trashspawnrate = 6; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.50;
                WaterSpawnScript.waterspawnlevel=2;
                Timer.timeremaining = 40.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 4);
            }

            if(level == 5){
                grav.gravityScale = (float)4;
                TrashSpawnScript.trashspawnrate = 6; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.50;
                WaterSpawnScript.waterspawnlevel=2;
                Timer.timeremaining = 40.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 5);
            }

            if(level == 6){
                grav.gravityScale = (float)4;
                TrashSpawnScript.trashspawnrate = 4; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.50;
                WaterSpawnScript.waterspawnlevel=2;
                Timer.timeremaining = 40.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 6);
            }

            if(level == 7){
                grav.gravityScale = (float)4;
                TrashSpawnScript.trashspawnrate = 4; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.25;
                WaterSpawnScript.waterspawnlevel=2;
                Timer.timeremaining = 35.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 7);
            }

            if(level == 8){
                grav.gravityScale = (float)5;
                TrashSpawnScript.trashspawnrate = 4; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = (float)1.25;
                WaterSpawnScript.waterspawnlevel=3;
                Timer.timeremaining = 35.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 8);
            }

            if(level == 9){
                grav.gravityScale = (float)5;
                TrashSpawnScript.trashspawnrate = 3; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = 1;
                WaterSpawnScript.waterspawnlevel=3;
                Timer.timeremaining = 35.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 9);
            }

            if(level == 10){
                grav.gravityScale = (float)5;
                TrashSpawnScript.trashspawnrate = 3; 
                SceneManager.LoadScene("SampleScene");
                BucketScript.levelrate = 1;
                WaterSpawnScript.waterspawnlevel=3;
                Timer.timeremaining = 35.0f;
                PlayerPrefs.SetInt("lastclickedbutton", 10);
            }
        }
    }
