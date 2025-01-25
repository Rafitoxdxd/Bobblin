using UnityEngine;

public class scr_bubbleController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        { gameObject.SetActive(false); }
        //Debug.Log("ASWd");
    }
}
