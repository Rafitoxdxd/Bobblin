using UnityEngine;

public class scr_bubbleController : MonoBehaviour
{
    public Vector3 checkpoint;
    public bool isDead;

    void Start()
    {
        checkpoint = transform.position;
    }

    /*void Update()
    {
        if (isDead)
        {
            if (deathTimer >= 1)
            {
                isDead = false;
                gameObject.SetActive(true);
                deathTimer = 0;
                transform.position = checkpoint;
            }
            else
            { deathTimer += Time.deltaTime; }
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
            isDead = true;
        }
        //Debug.Log("ASWd");
    }
}
