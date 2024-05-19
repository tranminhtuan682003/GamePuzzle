using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject[] prefabs; // Mảng chứa prefab
    private GameObject[,] prefabMatrix;

    void Start()
    {
        prefabMatrix = new GameObject[3, 4]; // Tạo ma trận để lưu trữ các prefab
        CreateGem();
    }

    private void CreateGem()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            int row = i / 4; // Xác định hàng
            int col = i % 4; // Xác định cột
            prefabMatrix[row, col] = Instantiate(prefabs[i], new Vector3(col * 2, 0, row * 2), Quaternion.identity);
        }
    }
}
