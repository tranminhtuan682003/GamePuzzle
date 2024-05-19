using UnityEngine;

public class CellBackground : MonoBehaviour
{
    public GameObject cellPrefab;
    public Sprite[] cellBackgrounds;
    public static GameObject[,] cellGrid = new GameObject[6, 6];

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                SpriteRenderer spriteRenderer = cell.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = cellBackgrounds[Random.Range(0, cellBackgrounds.Length)];
                cellGrid[i, j] = cell;
            }
        }
    }
}
