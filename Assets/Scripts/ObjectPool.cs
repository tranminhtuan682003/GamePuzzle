using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance { get; private set; }

    public List<GameObject> pool = new List<GameObject>();
    private bool allInactive = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        CheckAllInactive();
    }

    public void AddObject(GameObject obj)
    {
        pool.Add(obj);
        obj.SetActive(false);
    }

    private void CheckAllInactive()
    {
        foreach (var item in pool)
        {
            if (item.activeInHierarchy)
            {
                allInactive = false;
                return;
            }
        }
        allInactive = true;
    }

    public GameObject GetObject()
    {
        Debug.Log(allInactive);
        if (allInactive)
        {
            RandomizeList();
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        return null;
    }

    private void RandomizeList()
    {
        // Sử dụng thuật toán Fisher-Yates để đảo ngẫu nhiên vị trí của các phần tử trong danh sách
        for (int i = pool.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = pool[i];
            pool[i] = pool[randomIndex];
            pool[randomIndex] = temp;
        }
    }
}
