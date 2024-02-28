using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// Special thanks to Sally Juettner for helping with some of the logic with CheckAnyFlower function

public class Bee : MonoBehaviour
{
    // Attributes 
    public float beeTimer = 3.5f;
    public BeeHive beeHiveHome;
    public Flower[] flowerSearch;
    

    // Constructor to initialize the beehive that the bee belongs to in the scene
    public void Init(BeeHive BeeHive)
    {
        beeHiveHome = BeeHive;
    }

    // A simple timer to control the bee's movement
    private void BeeMovementCooldown()
    {
        // Starting countdown
        beeTimer -= Time.deltaTime;

        // Once timer reach 0
        if(beeTimer <= 0)
        {
            // Pick a random flower and fly to it to check for nectar
            Flower randomFlower = PickFlower();
            CheckAnyFlower(randomFlower);

            // Reseting timer
            beeTimer = 3.5f;
        }
    }

    private Flower PickFlower()
    {
        // Using random class to pick a random flower from the array
        int randomNumber = Random.Range(0, flowerSearch.Length); 
        //Debug.Log($"This is flower number {randomNumber}"); // FOR DEBUGGING

        return flowerSearch[randomNumber];
    }


    // Method to let the bee fly to flower to check if it has nectar
    private void CheckAnyFlower(Flower element)
    {
        // Target being the flower that the bee will fly to
        Flower target = element;

        // Flying to the flower...
        transform.DOMove(target.transform.position, 0.8f).OnComplete( ()=> 
        {
            // If the bee find nectar inside the flower...
            if(target.HasNectarCheck() == true)
            {
            //Take nectar from flower
            target.hasNectar = false;

            // Return back to the hive
            transform.DOMove(beeHiveHome.transform.position, 1f);

            // Giving one nectar to the beehive to be turn into honey
            beeHiveHome.GiveNectar(1);
            }
            
            // Otherwise...
            else
            {
                // Repick another flower 
                Flower randomFlower = PickFlower();

                // Go to that flower and try again
                CheckAnyFlower(randomFlower);
            }

        }).SetEase(Ease.Linear); // I love easing function

    }

    // Initializing flower class array
    void Awake()
    {
        flowerSearch = GameObject.FindObjectsByType<Flower>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        BeeMovementCooldown();
    }
}
