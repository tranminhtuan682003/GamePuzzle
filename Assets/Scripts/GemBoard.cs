using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBoard : MonoBehaviour
{
    public GameObject cellPrefab;
    public Sprite[] cellBackgrounds;
    public static GameObject[,] cellGrid = new GameObject[6, 2];

    void Start()
    {
        GenerateGrid();
        transform.position += new Vector3(0f, -3f, 0f);
    }
    private void Update()
    {
        FillGridWithObjects();
    }
    void GenerateGrid()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                cell.GetComponent<SpriteRenderer>().sprite = cellBackgrounds[Random.Range(0, cellBackgrounds.Length)];
                cell.transform.SetParent(transform);
                cellGrid[i, j] = cell;
            }
        }
    }

    void FillGridWithObjects()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject obj = ObjectPool.instance.GetObject();
                if (obj != null)
                {
                    obj.transform.position = cellGrid[i, j].transform.position;
                }
            }
        }
    }
}
