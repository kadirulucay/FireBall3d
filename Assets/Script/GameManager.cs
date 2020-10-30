using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Spawnobject;
    public Transform SpawnLoc;
    public int width = 1;
    public int height = 10;

    void Start()
    {
        for (int i = 0; i <= height; i++)
        {
            for (int y = 0; y < width; y++)
            {
                Instantiate(Spawnobject, new Vector3(0.027f, 1.003f, 1.039f), Quaternion.identity);
            }
        }


    }
}
