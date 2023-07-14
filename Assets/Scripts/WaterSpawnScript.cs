using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterdrop;
    public GameObject[] h;
    public int i;
    public int j;
    private float t1 = 0;
    private float t2 = 0;
    private float t3 = 0;
    private float t4 = 0;
    public float finalGravityScale = 2.0f;
    public float gravityScaleIncrement = 0.1f;
    [SerializeField] private AudioSource drop;
    public static int waterspawnlevel;

    void Start()
    {
        h = GameObject.FindGameObjectsWithTag("outlet");
    }

    // Update is called once per frame
    void Update()
    {
        // i = Random.Range(0, h.Length);
        // h1spawn(h[i]);
        // h2spawn(h[i]);
        // h3spawn(h[i]);
        // h4spawn(h[i]);
        spawnlevels(waterspawnlevel);
    }

    void spawnlevels(int k){
        if(k==3){
            i = Random.Range(0, h.Length);
            h1spawn(h[i]);
            h2spawn(h[i]);
            h3spawn(h[i]);
            h4spawn(h[i]);
        }

        if(k==1){
            h1spawn(h[1]);
            h2spawn(h[3]);
            h3spawn(h[2]);
            h4spawn(h[0]);
        }

        if(k==2){
            j = Random.Range(0, 2);
            h1spawn(h[j]);
            h2spawn(h[j]);
            h3spawn(h[j+2]);
            h4spawn(h[j+2]);
        }

    }

    void h1spawn(GameObject a){
        
        if(t1 < Random.Range(1,2)){
            t1 += Time.deltaTime;
        }

        else{
            for(int i=0; i<1; i++){
                Instantiate(waterdrop, new Vector3(a.transform.position.x, a.transform.position.y), transform.rotation);
                int isMuted = PlayerPrefs.GetInt("isMuted");
                if(isMuted == 0){
                    drop.Play();
                }           
            }
            t1 = 0;
        }
    }

    void h2spawn(GameObject a){
        
        if(t2 < Random.Range(3,6)){
            t2 += Time.deltaTime;
        }

        else{
            for(int i=0; i<4; i++){
                Instantiate(waterdrop, new Vector3(a.transform.position.x + Random.Range((float)-0.0001, (float)0.0001), a.transform.position.y + Random.Range((float)-0.0001, (float)0.0001)), transform.rotation);
                int isMuted = PlayerPrefs.GetInt("isMuted");
                if(isMuted == 0){
                    drop.Play();
                }
            }
            t2 = 0;
        }
    }

    void h3spawn(GameObject a){
        
        if(t3 < Random.Range(7,12)){
            t3 += Time.deltaTime;
        }

        else{
            for(int i=0; i<10; i++){
                Instantiate(waterdrop, new Vector3(a.transform.position.x + Random.Range(0, (float)0.00001), a.transform.position.y + Random.Range((float)-0.00001, (float)0.00001)), transform.rotation);
                int isMuted = PlayerPrefs.GetInt("isMuted");
                if(isMuted == 0){
                    drop.Play();
                }
            }
            t3 = 0;
        }
    }

    void h4spawn(GameObject a){
        
        if(t4 < Random.Range(30,50)){
            t4 += Time.deltaTime;
        }

        else{
            for(int i=0; i<50; i++){
                Instantiate(waterdrop, new Vector3(a.transform.position.x + Random.Range((float)-0.0001, (float)0.0001), a.transform.position.y + Random.Range((float)-0.0001, (float)0.0001)), transform.rotation);
                int isMuted = PlayerPrefs.GetInt("isMuted");
                if(isMuted == 0){
                    drop.Play();
                }
            }
            t4 = 0;
        }
    }
}
