using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Flower : MonoBehaviour
{
    // Variable to hold the sprite render which change the color of the flower
     SpriteRenderer flowerSpriteRenderer;
    

    // Attributes involving nectars
    public float nectarRate = 0.5f;
    private float nectarTimer = 5f;
    public bool hasNectar;


    // Once the timer hits 0, nectar is created and the timer is reset.
    private void NectarProduction()
    {
        // Counting down the seconds
        nectarTimer -= Time.deltaTime; 

        // Once the timer reaches 0
        if(nectarTimer <= 0)
        {
            // Set nectar to true and reset the timer
            hasNectar = true;
            nectarTimer = 5f;
        }

    }


    public bool HasNectarCheck()
    {
        if(hasNectar)
        {
            // Once the flower's nectar reaches at least 1 it will have nectar and its color is set to normal
            flowerSpriteRenderer.color = Color.white;
            return true;
        }

        else
        {
            // Otherwise the hive has no nectar and it's color is set to gray
            flowerSpriteRenderer.color = Color.gray;
            return false;
        }
    }
    
    // Call for one frame once the game starts
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
       flowerSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        NectarProduction();

        // Checking to see if the flower has nectar
        hasNectar = HasNectarCheck();

    }
}
