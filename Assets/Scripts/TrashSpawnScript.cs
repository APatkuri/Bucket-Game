using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject trash;
    private float t = 0;
    public static float trashspawnrate = 10;

    public static TrashSpawnScript Instance;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawntrash();
    }

    public void spawntrash()
    {
        if (t < trashspawnrate)
        {
            t += Time.deltaTime;
        }

        else
        {
            Instantiate(trash, new Vector3(Random.Range((float)-6.5, (float)6.5), (float)5.5), transform.rotation);
            t = 0;
        }
    }
}
