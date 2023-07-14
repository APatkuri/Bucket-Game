using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyDrop();
    }

    public void DestroyDrop(){
        if(transform.position.y < -7){
            Destroy(GameObject.FindGameObjectWithTag("Drop"));
        }
    }
}
