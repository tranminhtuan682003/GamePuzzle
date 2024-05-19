using UnityEngine;

public class GemFactory : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform GemParent;
    public static GemFactory instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public GameObject CreateGemPrefab(string name)
    {
        GameObject obj = null;
        switch (name)
        {
            case "Red":
                obj = InstantiateObject(0);
                break;
            case "Blue":
                obj = InstantiateObject(1);
                break;
            case "Purple":
                obj = InstantiateObject(2);
                break;
            case "Yellow":
                obj = InstantiateObject(3);
                break;
            case "White":
                obj = InstantiateObject(4);
                break;
            case "Green":
                obj = InstantiateObject(5);
                break;
        }
        return obj;
    }

    private GameObject InstantiateObject(int index)
    {
        GameObject obj = Instantiate(prefabs[index], GemParent);
        obj.transform.position = Vector3.zero;
        ObjectPool.instance.AddObject(obj);
        return obj;
    }
}
