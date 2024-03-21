using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    private EndGame endGameInstance;

    public void Start()
    {
        endGameInstance = GameObject.FindGameObjectWithTag("endgame").GetComponent<EndGame>();
    }

    public void Update()
    {
        if(endGameInstance.getItemCount() == 4)
        {
            endGameInstance.endGame();
        }
    }

    private void OnDisable()
    {
            endGameInstance.countScore();
    }
}
