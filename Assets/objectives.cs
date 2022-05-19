using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectives : MonoBehaviour
{

    public Slider slider;
    public GameObject player;
    public GameObject congrats;
    Player playerData;

    private void Start() 
    {
        playerData = player.GetComponent<Player>();
    }
    void Update()
    {
        SetHealth(playerData.money);
        if(playerData.money >= 10000){
            congrats.SetActive(true);
        }
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    
}