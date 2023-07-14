using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterlevel;
    public float speed = 10;
    public LogicManager logic;
    public Text perctext;
    public RectTransform perctextrect;
    public FaceExpressionScript face;
    public static float levelrate;
    public static float maxheight;
    public static float minheight;
    public Vector2 initialTouchPosition;
    public Vector2 movedTouchPosition;
    public Vector2 initdistance;
    public float touchjumpheight = 1;
    [SerializeField] private AudioSource dropsplash;
    [SerializeField] private AudioSource trashsound;
    
    void Start()
    {

        maxheight = waterlevel.transform.position.y;
        minheight = transform.position.y;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        face = GameObject.FindGameObjectWithTag("FaceExp").GetComponent<FaceExpressionScript>();
        perctextrect = perctext.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // maxheight = waterlevel.transform.position.y;
        // minheight = transform.position.y;
        keyboardmotion();
        touchmotion();
    }

    public void keyboardmotion(){

        if (Input.GetKey(KeyCode.A) && transform.position.x > -6.5 && !logic.gameovercheck)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
             perctextrect.position = new Vector3(70, 173, 0) + Camera.main.WorldToScreenPoint(transform.position);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 6.5 && !logic.gameovercheck)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
             perctextrect.position =  new Vector3(70, 173, 0) + Camera.main.WorldToScreenPoint(transform.position);
        }
    }

    public void touchmotion(){


        if (!logic.gameovercheck)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float screenWidth = Screen.width;
                float touchPositionX = touch.position.x;

                if (touch.phase == TouchPhase.Began && !logic.isslidertouching)
                {                 
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionX, touch.position.y, 10));
                    float xPos = Mathf.Clamp(touchPosition.x, -6.5f, 6.5f);
                    transform.position = new Vector3(xPos, transform.position.y + touchjumpheight, transform.position.z);
                    perctextrect.position =  new Vector3(70, 173, 0) + Camera.main.WorldToScreenPoint(transform.position);
                    maxheight += touchjumpheight;
                    minheight += touchjumpheight;
                }

                

                if (touch.phase == TouchPhase.Moved && !logic.isslidertouching)
                {                 
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionX, touch.position.y, 10));
                    float xPos = Mathf.Clamp(touchPosition.x, -6.5f, 6.5f);
                    transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                    perctextrect.position =  new Vector3(70, 173, 0) + Camera.main.WorldToScreenPoint(transform.position);

                    // Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    // float distance = touchDeltaPosition.magnitude;
                    // float maxDistanceDelta = distance * 0.001f;
                    // transform.Translate(touchDeltaPosition.x * maxDistanceDelta, 0, 0);
                    // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), transform.position.y, transform.position.z);

                    // transform.position = Vector3.Lerp(transform.position, new Vector3(xPos, transform.position.y, transform.position.z), 75 * Time.deltaTime);
                }

                if (touch.phase == TouchPhase.Ended && !logic.isslidertouching)
                {                 
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionX, touch.position.y, 10));
                    float xPos = Mathf.Clamp(touchPosition.x, -6.5f, 6.5f);
                    transform.position = new Vector3(xPos, transform.position.y-touchjumpheight, transform.position.z);
                    perctextrect.position =  new Vector3(70, 173, 0) + Camera.main.WorldToScreenPoint(transform.position);
                    maxheight -= touchjumpheight;
                    minheight -= touchjumpheight;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Drop")
        {

            if (waterlevel.transform.position.y >= maxheight && waterlevel.transform.position.y <= minheight)
            {   
                waterlevel.transform.position += (Vector3.up * (float)0.02 * levelrate);
                Destroy(GameObject.FindGameObjectWithTag("Drop"));
                int isMuted = PlayerPrefs.GetInt("isMuted"); 
                if(isMuted == 0){
                    dropsplash.Play();
                }
                StartCoroutine(face.Happyexp());
            }
        }

        if (collision.tag == "Trash")
        {
            if (waterlevel.transform.position.y >= maxheight && LogicManager.playerScore < 100)
            {
                waterlevel.transform.position += (Vector3.down * (float)((waterlevel.transform.position.y - maxheight) / 2.0));
                Vibration();
                Destroy(GameObject.FindGameObjectWithTag("Trash"));
                int isMuted = PlayerPrefs.GetInt("isMuted"); 
                if(isMuted == 0){
                    trashsound.Play();
                }
                StartCoroutine(face.SadExp());
            }
        }
    }

    public void Vibration(){
        int isVibrate = PlayerPrefs.GetInt("isVibrate");    
    
        if(isVibrate == 1){
            Handheld.Vibrate();
        }
    }
}
