using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float shrinkSpeed;
    private float initialSize;
    private Light hexLight;
    private float turnOffSpeed;
    private PlayerMovement pm;
    private float[] angles = new float[] {0f, 60f, 120f, 180f, 240f, 300f};
    private int index;

    private LineRenderer hexagonColor;
    

    private float timeLeft;
    private Color targetColor;

    private bool yellow;

    private Timer timer;
    private float extraTime;
    private bool maxDiff;
    private float timeLeftModified;

    // Start is called before the first frame update
    void Start()
    {
        shrinkSpeed = 3f;
        initialSize = 15f;
        rb2d = GetComponent<Rigidbody2D>();
        hexLight = GetComponentInChildren<Light>();
        turnOffSpeed = 15f;
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();


        index = Random.Range(0, 6);
        rb2d.rotation = angles[index];
        transform.localScale = Vector3.one * initialSize;

        hexagonColor = GetComponent<LineRenderer>();
        

        timeLeft = 2f;
        timeLeftModified = timeLeft;


        yellow = false;

        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        extraTime = 5;
        maxDiff = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!pm.dead)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            hexLight.intensity -= turnOffSpeed * Time.deltaTime;


            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                hexagonColor.startColor = targetColor;
                hexagonColor.endColor = targetColor;
                hexLight.color = targetColor;



                // start a new transition
                if (yellow)
                {
                    targetColor = Color.red;
                }

                else
                {
                    targetColor = Color.yellow;
                }
                
                timeLeft = timeLeftModified;
                yellow = !yellow;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                hexagonColor.startColor = Color.Lerp(hexagonColor.startColor, targetColor, Time.deltaTime / timeLeft);
                hexagonColor.endColor = Color.Lerp(hexagonColor.endColor, targetColor, Time.deltaTime / timeLeft);
                hexLight.color = Color.Lerp(hexLight.color, targetColor, Time.deltaTime / timeLeft);



                // update the timer
                timeLeft -= Time.deltaTime;
            }


            if (timer.time > extraTime && !maxDiff)
            {
                shrinkSpeed += 0.5f;
                extraTime += 5;
                timeLeftModified -= 0.15f;
                

                if (shrinkSpeed > 10f)
                {
                    maxDiff = true;
                }
            }

        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Pivot")
        {
            Destroy(gameObject);
        }
    }
}
