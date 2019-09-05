using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewRecord : MonoBehaviour
{
    //public Text recordText;

    private bool growing;
    private float maxSize;
    private float minSize;
    private float growingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        growing = true;

        maxSize = 1.3f;
        minSize = 0.7f;
        growingSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
        {
            if (transform.localScale.x < maxSize)
            {
                transform.localScale += Vector3.one * growingSpeed;
            }

            else
            {
                growing = false;
            }

        }

        else
        {
            if (transform.localScale.x > minSize)
            {
                transform.localScale -= Vector3.one * growingSpeed;
            }

            else
            {
                growing = true;
            }

        }
    }
}
