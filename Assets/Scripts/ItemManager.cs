using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ItemManager : MonoBehaviour
{
    private TMP_Text scoreText;
    private int itemCount;

    public void Start()
    {
        // scoreText 필드에 scoretext 태그가 지정된 오브젝트의 TMP_Text 컴포넌트를 할당
        GameObject scoreObject = GameObject.FindGameObjectWithTag("scoretext");
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogWarning("No object with 'scoretext' tag found.");
        }
        itemCount = int.Parse(scoreText.text);
    }

    private void OnDisable()
    {
        if (scoreText != null)
        {
            itemCount += 1;
            scoreText.text = itemCount.ToString();
        }
    }
}
