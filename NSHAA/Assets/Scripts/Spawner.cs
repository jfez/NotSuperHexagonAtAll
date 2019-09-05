using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hexagonPrefab;
    public GameObject hexagonModifiedPrefab;

    private float spawnRate;
    private float currentTime;
    private PlayerMovement pm;
    private int random;
    private Timer timer;

    private float extraTime;
    private bool maxDiff;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 2f;
        currentTime = spawnRate;

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();

        extraTime = 5;

        maxDiff = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > spawnRate)
        {
            if (!pm.dead)
            {

                random = Random.Range(0, 101);

                if (random < 50)
                {
                    Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
                }

                else
                {
                    Instantiate(hexagonModifiedPrefab, Vector3.zero, Quaternion.identity);
                }
                
                currentTime = 0f;
            }
            
        }

        if (timer.time > extraTime && !maxDiff)
        {
            spawnRate -= 0.1f;
            extraTime += 5;

            if (spawnRate < 0.2f)
            {
                maxDiff = true;
            }
        }

    }
}
