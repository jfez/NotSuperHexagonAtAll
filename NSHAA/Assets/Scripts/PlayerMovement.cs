using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject textRestart;
    [HideInInspector]
    public bool dead;
    public AudioSource music;
    public AudioSource effectsSounds;
    public AudioClip deathSound;
    public AudioSource effectsSounds2;
    public AudioClip gameOverSound;
    public Transform effect;

    public GameObject textRecord;
    

    private float movementSpeed;
    [HideInInspector] public float movement;
    
    
    private float turnOffSpeed;
    private bool turnOff;
    private List<Light> lights;

    private Timer timer;



    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1.0f;

        movementSpeed = 600f;
        movement = 0f;

        textRestart.SetActive(false);
        dead = false;

        
        turnOffSpeed = 30;
        turnOff = false;

        lights = new List<Light>();

        textRecord.SetActive(false);

        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            //if you want keyboard input
            //else, click/tap input
            //movement = Input.GetAxisRaw("Horizontal");
    
        }


        else
        {
            if (movement != 0)
            {
                movement = 0;
            }

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }

        if (turnOff)
        {
            foreach(Light l in lights)
            {
                if (l!= null)
                {
                    l.intensity -= turnOffSpeed * Time.deltaTime;
                }
                
            }

            
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -movementSpeed * movement * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hexagon" && !dead)
        {

            Death();
            TurnOffLights();

        }
    }

    void Death()
    {
        textRestart.SetActive(true);
        //Time.timeScale = 0f;
        dead = true;
        music.Stop();
        effectsSounds.clip = deathSound;
        effectsSounds.Play();
        effectsSounds2.clip = gameOverSound;
        effectsSounds2.Play();

        Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);

        if (timer.time > PlayerPrefs.GetFloat("record", 0))
        {
            PlayerPrefs.SetFloat("record", timer.time);
            textRecord.SetActive(true);
        }

        

    }

    void TurnOffLights()
    {

        foreach (GameObject lightHex in GameObject.FindGameObjectsWithTag("LightHex"))
        {
            Light l = lightHex.gameObject.GetComponent<Light>();

            if(l != null)
            {
                lights.Add(l);
            }
            
        }

        turnOff = true;
        
    }
}
