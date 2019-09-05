using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //private float rotationSpeed;

    

    private Quaternion target;
    private float smooth;
    private float rotation;
    private float time;
    private float addRotation;
    private float changeTime;
    private PlayerMovement pm;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //rotationSpeed = 50f;
        
        smooth = 6f;
        changeTime = 3f;
        time = changeTime;

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        

        if (time > changeTime && !pm.dead)
        {
            addRotation = Random.Range(-1.5f, 1.5f);

            time = 0f;

            
        }

        rotation += addRotation;

        target = Quaternion.Euler(0, 0, rotation);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
