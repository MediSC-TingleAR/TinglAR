using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialBtnHandler : MonoBehaviour
{
    public GameObject[] tutorials;
    private int currentIndex = 0;
    [SerializeField]
    private int tutorialCount = 4;
    public Button undo;
    public Button next;
    public Button go;

    void Start()
    {
        ActivateTutorialPopup(tutorials[0]);
        undo.onClick.AddListener(()=> OnClickUndo());
        next.onClick.AddListener(()=> OnClickNext());
    }

    void ActivateTutorialPopup(GameObject target)
    {   
        foreach (GameObject obj in tutorials)
        {
            obj.SetActive(obj == target);
        }
        if (target == tutorials[3]) {
            next.gameObject.SetActive(false);
            go.gameObject.SetActive(true);
        }
        if (target != tutorials[0]) {
            next.gameObject.SetActive(true);
            undo.gameObject.SetActive(true);
        }
        else
            undo.gameObject.SetActive(false);
    }   

    void OnClickUndo()
    {
        currentIndex = (currentIndex - 1) % tutorialCount;
        if(currentIndex <= tutorialCount){
            ActivateTutorialPopup(tutorials[currentIndex]);
        }
    }

    void OnClickNext()
    {
        currentIndex = (currentIndex - 1) % tutorialCount;
        if(currentIndex <= tutorialCount){
            ActivateTutorialPopup(tutorials[currentIndex]);
        }
    }
}
