using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance {  get; private set; }
    private Animator animator;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        animator = GetComponent<Animator>();
    }
    public void CoinRotate()
    {
        StartCoroutine(RotateDelay(0.5f));
        animator.SetBool("Rotation", true);
    }
    public void DestroyCoin()
    {
        CoinRotate();
        StartCoroutine(TimeDestroy());
    }
    private IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator RotateDelay(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
