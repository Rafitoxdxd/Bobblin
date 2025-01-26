using UnityEngine;

public class scr_stomper : MonoBehaviour
{
    public bool m_up, m_down, m_left, m_right, inverted;
    public float maxSpeed, changeSpeedSpd;
    public float dirCooldown, dirCooldCounter;

    private float speed = 0;
    private bool changing = false;

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            if (dirCooldCounter >= dirCooldown)
            { changing = false; changeDirection(); speed = 0; dirCooldCounter = 0; }
            else
            { dirCooldCounter += Time.deltaTime; }
        }
        else
        {
            if (speed != maxSpeed) { speed = Mathf.Lerp(speed, maxSpeed, changeSpeedSpd * Time.deltaTime); }

            if (m_up) { transform.Translate(0, speed * Time.deltaTime, 0); }
            if (m_down) { transform.Translate(0, -speed * Time.deltaTime, 0); }
            if (m_left) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
            if (m_right) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        }
    }

    public void changeDirection()
    {
        if (!inverted)
        {
            if (m_up) { m_up = false; m_right = true; }
            else if (m_right) { m_right = false; m_down = true; }
            else if (m_down) { m_down = false; m_left = true; }
            else if (m_left) { m_left = false; m_up = true; }
        }
        else
        {
            if (m_up) { m_up = false; m_left = true; }
            else if (m_left) { m_left = false; m_down = true; }
            else if (m_down) { m_down = false; m_right = true; }
            else if (m_right) { m_right = false; m_up = true; }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Level"))
        {
            changing = true;
        }
        //Debug.Log("ASWd");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Level"))
        {
            if (m_up) { transform.Translate(0, -1.5f * Time.deltaTime, 0); }
            if (m_down) { transform.Translate(0, 1.5f * Time.deltaTime, 0); }
            if (m_left) { transform.Translate(1.5f * Time.deltaTime, 0, 0); }
            if (m_right) { transform.Translate(-1.5f * Time.deltaTime, 0, 0); }
        }
    }
}
