using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    // Attributes 
    public Flower flowerClass;
    public BeeHive beeHiveHome;
    public GameObject[] flowerSearch;
    

    // Constructor to initialize the beehive that the bee belongs to in the scene
    public void Init(BeeHive BeeHive)
    {
        beeHiveHome = BeeHive;
    }

    private void MoveToFlower()
    {
        // Code to make the bee move to the flower that currently has nectar to harvest

    }

    private void CheckAnyFlower()
    {
        // Code to make it so the bee check for any flower that may have any nectar
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // (For Tutor)
        // Attempted to search for all flower object in the scene with 
        flowerSearch = GameObject.FindGameObjectsWithTag("Flower");
        
        // But when I use the debug log, the message appeared 8 times even though I had 4 flower in the scene
        foreach(GameObject flower in flowerSearch)
        {
            Debug.Log("There is flower!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
