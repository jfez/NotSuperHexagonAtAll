using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementClick : MonoBehaviour
{
    private PlayerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        if (gameObject.tag == "ColIzq")
        {
            pm.movement = -1;
            
        }

        else if (gameObject.tag == "ColDch")
        {
            pm.movement = 1;
            
        }
    }

    void OnMouseUp()
    {
        pm.movement = 0;
    }

   
}
