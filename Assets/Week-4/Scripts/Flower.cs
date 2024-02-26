using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
     SpriteRenderer m_FlowerSpriteRenderer;
    
    // TextMeshProGUI for debug
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI nectarText;

    // Attributes involving nectars
    private float nectarAmount;
    public float nectarRate = 0.5f;
    public float nectarTimer = 5f;
    public bool hasNectar;

    private void ShowNectarProduction()
    {
        timerText.text = string.Format("Frames: {0}", nectarTimer);
        nectarText.text = string.Format("Nectar Amount: {0}", nectarAmount);
    }

    // Once the timer hits 0, nectar is created and the timer is reset.
    private void NectarProduction()
    {
        nectarTimer -= Time.deltaTime;

        if(nectarTimer <= 0)
        {
            nectarAmount += nectarRate;
            nectarTimer = 5f;
        }

    }


    public bool HasNectarCheck()
    {
        if(nectarAmount >= 1)
        {
            // Once the flower's nectar reaches past 1 it will have nectar and its color is set to normal
            m_FlowerSpriteRenderer.color = Color.white;
            return true;
        }

        else
        {
            // 
            m_FlowerSpriteRenderer.color = Color.gray;
            return false;
        }
    }
    
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_FlowerSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        // The arithmetic for necter being produces after a certain amount of time
        NectarProduction();

        hasNectar = HasNectarCheck();

        ShowNectarProduction();
    }
}
