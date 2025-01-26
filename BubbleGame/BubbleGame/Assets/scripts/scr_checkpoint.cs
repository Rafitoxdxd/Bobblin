using UnityEngine;

public class scr_checkpoint : MonoBehaviour
{
    public Sprite checkedSprite;
    public bool checkpointReached;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !checkpointReached)
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().sprite = checkedSprite;
            checkpointReached = true;

            other.GetComponent<scr_bubbleController>().checkpoint = other.transform.position;
        }
    }
}
