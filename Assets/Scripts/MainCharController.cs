using System.Collections;
using System.Collections.Generic;
//using OpenCVForUnityExample;
using UnityEngine;
using UnityEngine.UI;


public class MainCharController : MonoBehaviour
{
    private float HP;
    private Slider hpBar;
    private Animator anim;

    void Start()
    {
        hpBar = GameObject.Find("ARGameObject/GameObject/Canvas/Slider").GetComponent<Slider>();

        anim = GetComponent<Animator>();
        anim.SetBool("isDie",false);
        anim.SetFloat("isInjured",20);
        anim.SetBool("isDamaged",false);

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
            StartCoroutine(DieAnim());
        }
        
        float damagedHP = HP - 0.6f;
        HP = damagedHP;
        hpBar.value = HP;
        anim.SetFloat("isInjured",HP);
    }

    IEnumerator DieAnim()
    {
        anim.SetBool("isDie",true);
        yield return new WaitForSeconds(3);
        SubGameManager subGameManager = GameObject.Find("subGameManager").GetComponent<SubGameManager>();
        subGameManager.FinSubGame();
    }
}
