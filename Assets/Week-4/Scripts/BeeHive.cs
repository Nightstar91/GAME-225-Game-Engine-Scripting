using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{
    private float honeyRate = 1f;
    public int nectarAmount = 0;
    public float honeyAmount = 0;
    public int beeWorkerAmount = 2;
    public float honeyTimer = 3f;
    public BeeHive BeeHiveHome;
    public GameObject beePrefab;
    private Bee beeScript;
    
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
                nectarAmount--;
                honeyAmount += honeyRate;

                // Reseting the timer
                honeyTimer = 3f;
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
        //Instantiate bee object from the bee prefab (called init method)
        beeScript = beePrefab.GetComponent<Bee>();
        // beeScript.Init(BeeHiveHome);


        while(beeWorkerAmount > 0)
        {
            beeScript.Init(BeeHiveHome);
            Instantiate(beePrefab);

            beeWorkerAmount--;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
