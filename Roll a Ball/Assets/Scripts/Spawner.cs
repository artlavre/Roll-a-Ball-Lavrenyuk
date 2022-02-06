using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer = 0f;
    [SerializeField]
    float toSpawn = 7f;
    public GameObject rock;
    void Update()
    {
        if (timer <= toSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            GameObject stone = Instantiate(rock, transform.position, transform.rotation);
            Destroy(stone, 5f);
        }
        
    }
}
