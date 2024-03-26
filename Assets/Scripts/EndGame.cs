using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private GameObject mainLogo;
    private GameObject end;
    private GameObject grabbable;
    private int itemCount = 0;
    private TMP_Text scoreText;

    public void Start()
    {
        mainLogo = GameObject.FindGameObjectWithTag("Logo"); //mainUI
        end = GameObject.FindGameObjectWithTag("end");  //endUI
        grabbable = GameObject.FindGameObjectWithTag("bubbles"); // bubbles 오브젝트
        GameObject scoreObject = GameObject.FindGameObjectWithTag("scoretext"); //스코어를 표시해주는 TEXT 오브젝트

        end.SetActive(false);
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogWarning("No object with 'scoretext' tag found.");
        }
    }
    public void endGame()
    {
        mainLogo.SetActive(false);
        grabbable.SetActive(false);
        end.SetActive(true);
    }
    public void countScore()
    {
        itemCount += 1;
        Debug.Log($"itemCount : {itemCount}" );
        if (scoreText != null)
        {
            scoreText.text = itemCount.ToString();
        }
        else
        {
            Debug.LogWarning("scoreText is not assigned.");
        }
    }
    public int getItemCount()
    {
        return itemCount;
    }
}
