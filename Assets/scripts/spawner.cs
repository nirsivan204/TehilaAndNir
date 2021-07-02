using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool canCreate = false;
    public GameObject[] upObstacles;
    public GameObject cloneBucket;
    // Start is called before the first frame update


    private void CreateObstacle()
    {
        if (canCreate)
        {
            GameObject obstacle; 
            if (Random.Range(0, 2) == 0)
            {
                obstacle = obstacles[Random.Range(0, obstacles.Length)];
            }
            else
            {
                obstacle = upObstacles[Random.Range(0, upObstacles.Length)];
            }
            GameObject clone = Instantiate(obstacle, cloneBucket.transform);
            clone.SetActive(true);
            Invoke("CreateObstacle", 4.5f);
        }

    }

    public void stop()
    {
        canCreate = false;
        foreach (Transform child in cloneBucket.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void startSpawn()
    {
        canCreate = true;
        CreateObstacle();
    }
}
