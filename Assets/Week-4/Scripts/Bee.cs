using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour
{
    // Attributes 
    private float beeTimer = 2f;
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
        beeTimer -= Time.deltaTime;

        if(beeTimer <= 0)
        {
            Flower randomFlower = PickFlower();
            CheckAnyFlower(randomFlower);

            beeTimer = 2f;
        }
    }


    private Flower PickFlower()
    {
        // Picking a random flower that
        int randomNumber = Random.Range(0, flowerSearch.Length); 
        Debug.Log($"This is flower number {randomNumber}");

        return flowerSearch[randomNumber];
    }

    private void CheckAnyFlower(Flower element)
    {
        // Code to make it so the bee check for any flower that may have any nectar (For Tutor)
        Flower target = element;
        Vector3 originalPosition = transform.position;

        transform.DOMove(target.transform.position, 0.25f).OnComplete( ()=> 
        {
            //Take nectar from flower
            //If flower returned nectar then go back to the hive and give hive nectar
            //If flower did not return nectar then go check another flower

        });

    }

    void Awake()
    {
        flowerSearch = GameObject.FindObjectsByType<Flower>(FindObjectsSortMode.None);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeeMovementCooldown();
    }
}
