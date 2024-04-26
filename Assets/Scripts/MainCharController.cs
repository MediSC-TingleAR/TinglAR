using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainCharController : MonoBehaviour
{
    private float HP;
    private Slider hpBar;

    void Start()
    {
        hpBar = GameObject.Find("ARGameObject/GameObject/Canvas/Slider").GetComponent<Slider>();
        SetHP();
    }
    void SetHP()
    {
        hpBar.value = hpBar.maxValue;
        HP = hpBar.value;
        
    }

    public void GetDamage()
    {
        if(HP < 1)
        {
            SubGameManager subGameManager = GameObject.Find("subGameManager").GetComponent<SubGameManager>();
            subGameManager.FinSubGame();
        }
        float damagedHP = HP - 0.7f;
        HP = damagedHP;
        hpBar.value = HP;
    }
}
