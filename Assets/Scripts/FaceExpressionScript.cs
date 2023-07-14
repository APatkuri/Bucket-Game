using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceExpressionScript : MonoBehaviour
{

    public GameObject Happy;
    public GameObject Normal;
    public GameObject Sad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Happyexp(){
        
            Happy.SetActive(true);
            Normal.SetActive(false);
            Sad.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            Happy.SetActive(false);
            Normal.SetActive(true);
            Sad.SetActive(false);
    }

    public IEnumerator SadExp(){
        
            Sad.SetActive(true);
            Normal.SetActive(false);
            Happy.SetActive(false);
            yield return new WaitForSeconds(1.0f);            
            Sad.SetActive(false);
            Normal.SetActive(true);
            Happy.SetActive(false);
    }
}
