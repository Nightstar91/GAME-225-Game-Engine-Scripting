using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{
    // Attributes for honey, nectar and bee
    private float honeyRate = 0.5f;
    public int nectarAmount = 0;
    public float honeyAmount = 0;
    private int beeWorkerAmount = 2;
    public float honeyTimer = 1.5f;

    // Attribute for class and gameobject
    public GameObject beePrefab;
    
    //The hive needs to count down to try and produce honey if it has any nectar stored
    private void HoneyProduction()
    {
        // The method will only function if there are nectar in the beehive
        if(nectarAmount > 0)
        {
            // Starting the countdown
            honeyTimer -= Time.deltaTime;

            // When the count down is finished it should remove 1 nectar and add 1 honey
            if(honeyTimer <= 0)
            {
                // Decrementing nectar and add onto honey based on honeyRate
                nectarAmount--;
                honeyAmount += honeyRate;

                // Reseting the timer
                honeyTimer = 1.5f;
            }
        }
    }


    // The hive needs a way for Bees to give the hive nectar.
    public void GiveNectar(int nectar)
    {
        nectarAmount += nectar;
    }


    // Start is called before the first frame update
    void Start()
    {

        // At the start of the game the beehive will make as many bee as needed per instruction by the user
        while(beeWorkerAmount > 0)
        {
            GameObject beeWorker = Instantiate(beePrefab, transform.position, transform.rotation);
            beeWorker.GetComponent<Bee>().Init(this);

            beeWorkerAmount--;
        }
    }


    // Update is called once per frame
    void Update()
    {
        HoneyProduction();
    }
}
