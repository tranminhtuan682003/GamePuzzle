using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public string[] nameGemPrefab;
    public GameObject coinPrefab;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
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
