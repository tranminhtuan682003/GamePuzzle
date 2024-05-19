using UnityEngine;

public class GemController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private GameObject closestCell;
    private string gemTag;
    private static int score = 0;
    private GameObject coin;

    void Start()
    {
        gemTag = gameObject.tag;
        coin = GameObject.FindGameObjectWithTag("Coin");
        if(coin == null)
        {
            Debug.Log("khong tim thay coin");
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
    void OnMouseUp()
    {
        isDragging = false;
        SnapToClosestCell();
        CheckAndDestroyAdjacentGems();
    }

    void SnapToClosestCell()
    {
        float minDistance = float.MaxValue;
        Vector3 targetPosition = startPosition;

        foreach (GameObject cell in CellBackground.cellGrid)
        {
            float distance = Vector3.Distance(transform.position, cell.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestCell = cell;
                targetPosition = closestCell.transform.position;
            }
        }

        // Kiểm tra nếu vị trí mới trùng với vị trí của ngọc khác
        bool positionOccupied = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject && collider.GetComponent<GemController>() != null)
            {
                positionOccupied = true;
                break;
            }
        }

        // Nếu không trùng vị trí hoặc khoảng cách đủ nhỏ thì đặt lại vị trí ngọc
        if (!positionOccupied && minDistance < 0.5f)
        {
            transform.position = targetPosition;
        }
        else
        {
            transform.position = startPosition;
        }
    }

    void CheckAndDestroyAdjacentGems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        foreach (Collider2D collider in colliders)
        {
            GemController gemController = collider.GetComponent<GemController>();
            if (gemController != null && gemController != this && gemController.gemTag == gemTag && gemController.gameObject.activeSelf)
            {
                //xuat hien coin
                ActiveCoin(gemController);

                gameObject.SetActive(false);
                gemController.gameObject.SetActive(false);

                Score();
                return;
            }
        }
    }
    private void ActiveCoin(GemController gemController)
    {
        Vector3 middlePosition = Vector3.Lerp(transform.position, gemController.transform.position, 0.5f);
        coin.transform.position = middlePosition;
        coin.SetActive(true);
    }
    private void Score()
    {
        score += 20;
        Debug.Log("Score: " + score);
    }
}
