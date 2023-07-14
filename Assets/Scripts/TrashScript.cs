using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTrash();
    }

    public void DestroyTrash(){
        if(transform.position.y < -7){
            Destroy(GameObject.FindGameObjectWithTag("Trash"));
        }
    }
}
