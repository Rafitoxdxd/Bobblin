using UnityEngine;

public class scr_fanController : MonoBehaviour
{
    // Update is called once per frame
    public GameObject bubble;
    public scr_bubbleController BubbleController;
    public ParticleSystem particles;
    public Animator animCont;

    private float deathTimer = 0;
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, mousePos.y);

        Vector2 target = transform.position;
        target.x = target.x - bubble.transform.position.x;
        target.y = target.y - bubble.transform.position.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        //bubble movement
        //power over distance
        float fanForce = 5f;
        float dist = Vector3.Distance(transform.position, bubble.transform.position);

        var force = fanForce / (dist * dist);

        //physics
        var rigidBody = bubble.GetComponent<Rigidbody2D>();

        if (Input.GetMouseButton(0) && dist < 10)
        {
            rigidBody.AddForce((-transform.position + bubble.transform.position) * force, ForceMode2D.Force);
            if (!particles.isPlaying)
            { particles.Play(); }

            animCont.SetBool("Fanning", true);
        }
        else
        {
            if (particles.isPlaying)
            { particles.Stop(); }

            animCont.SetBool("Fanning", false);
        }

        if (Input.GetMouseButtonDown(1) && dist > 0.2f && dist < 2.5)
        {
            rigidBody.AddForce((-transform.position + bubble.transform.position) * force, ForceMode2D.Impulse);
        }

        /*if (rigidBody.)
        { Debug.Log("OVERSPEED!!!!") }*/
    }

    void Update()
    {
        if (BubbleController.isDead)
        {
            if (deathTimer >= 1)
            {
                BubbleController.isDead = false;
                bubble.gameObject.SetActive(true);
                deathTimer = 0;
                bubble.transform.position = BubbleController.checkpoint;
            }
            else
            { deathTimer += Time.deltaTime; }
        }
    }
}
