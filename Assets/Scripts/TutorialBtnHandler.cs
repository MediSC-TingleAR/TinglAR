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
    private int tutorialCount;
    public Button undo;
    public Button next;
    public Button go;

    void Start()
    {
        tutorialCount = tutorials.Length;
        ActivateTutorialPopup(tutorials[0]);
        go.gameObject.GetComponent<Button>().interactable = false;

    }

    void ActivateTutorialPopup(GameObject target)
    {   
        foreach (GameObject obj in tutorials)
        {
            obj.SetActive(obj == target);
        }
        if (target == tutorials[tutorialCount-1]) //만약 마지막 페이지라면
        { 
            next.gameObject.GetComponent<Button>().interactable = false;
            go.gameObject.GetComponent<Button>().interactable = true;
        }
        else if (target == tutorials[0]) //만약 첫번째 페이지라면
        {
            undo.gameObject.GetComponent<Button>().interactable = false;
            go.gameObject.GetComponent<Button>().interactable = false;

        }
        else
        {
            undo.gameObject.GetComponent<Button>().interactable = true;
            next.gameObject.GetComponent<Button>().interactable = true;
        }
    }   

     public void OnClickUndo()
    {
        currentIndex = (currentIndex - 1 + tutorialCount) % tutorialCount;
        Debug.Log("Current Index: " + currentIndex);
        ActivateTutorialPopup(tutorials[currentIndex]);
    }

    public void OnClickNext()
    {
        currentIndex = (currentIndex + 1) % tutorialCount;
        Debug.Log("Current Index: " + currentIndex);
        ActivateTutorialPopup(tutorials[currentIndex]);
    }
}
