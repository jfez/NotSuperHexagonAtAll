using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePivot : MonoBehaviour
{
    private float shrinkSpeed;
    private bool growing;
    private float maxSize;
    private float minSize;
    private Rigidbody2D rb2d;
    //private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        shrinkSpeed = 0.08f;
        growing = false;

        maxSize = 0.3f;
        minSize = 0.14f;

        rb2d = GetComponent<Rigidbody2D>();

        //rotateSpeed = -50f;

    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
        {
            if(transform.localScale.magnitude < maxSize)
            {
                transform.localScale += Vector3.one * shrinkSpeed * Time.deltaTime;
            }

            else
            {
                growing = false;
            }
            
        }

        else
        {
            if(transform.localScale.magnitude > minSize)
            {
                transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            }

            else
            {
                growing = true;
            }
            
        }

        //rb2d.rotation += rotateSpeed * Time.deltaTime;


    }
}
