using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public BeeHive beeHiveHome;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
