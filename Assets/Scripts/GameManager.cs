using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] nameGemPrefab;

    void Start()
    {
        SpawnObject();
    }
    public void SpawnObject()
    {
        foreach (string namePrefab in nameGemPrefab)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject obj = GemFactory.instance.CreateGemPrefab(namePrefab);
            }
        }
    }
}
