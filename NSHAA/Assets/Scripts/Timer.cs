using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;

    [HideInInspector] public float time;

    private PlayerMovement pm;
    private bool growing;
    private float maxSize;
    private float minSize;
    private float growingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        growing = true;
        maxSize = 1.3f;
        minSize = 0.7f;
        growingSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pm.dead)
        {
            time += Time.deltaTime;
            timeText.text = "" + time.ToString("f2");
        }

        else
        {
            if (growing)
            {
                if (timeText.transform.localScale.x < maxSize)
                {
                    timeText.transform.localScale += Vector3.one * growingSpeed;
                }

                else
                {
                    growing = false;
                }

            }

            else
            {
                if (timeText.transform.localScale.x > minSize)
                {
                    timeText.transform.localScale -= Vector3.one * growingSpeed;
                }

                else
                {
                    growing = true;
                }

            }



            
            
        }
        
    }
}
