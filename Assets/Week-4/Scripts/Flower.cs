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
    public float nectarAmount;
    public float nectarRate = 0.5f;
    private float nectarTimer = 2f;

    // Variable to store the initial timer set by the user to be reset the timer
    public bool hasNectar;


    // Once the timer hits 0, nectar is created and the timer is reset.
    private void NectarProduction()
    {
        nectarTimer -= Time.deltaTime;

        if(nectarTimer <= 0)
        {
            nectarAmount += nectarRate;
            nectarTimer = 2f;
        }

    }


    public bool HasNectarCheck()
    {
        if(nectarAmount >= 1)
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
        // The arithmetic for necter being produces after a certain amount of time
        NectarProduction();

        // Checking to see if the flower has nectar
        hasNectar = HasNectarCheck();

    }
}
