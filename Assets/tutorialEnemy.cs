using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using NRKernal;

public class tutorialEnemy : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    public GameObject hoverObject;
    private TutorialBtnHandler tutohandler;

    private Animator anim;
    void Start()
    {
        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
		{
			var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
			poseTracker.ResetWorldMatrix();
		});
        
        hoverObject.SetActive(false);
        tutohandler = GameObject.Find("Canvas/Tutorials").GetComponent<TutorialBtnHandler>();

        anim = GetComponent<Animator>();
        anim.SetBool("isDead",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverObject.SetActive(true);
        tutohandler.tutorials[5].SetActive(true);
        tutohandler.tutorials[4].SetActive(false);
        
    }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     hoverObject.SetActive(false);
    //     tutohandler.tutorials[4].SetActive(true);
    //     tutohandler.tutorials[5].SetActive(false);
    // }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(DieAnim());

    }

    IEnumerator DieAnim()
    {
        anim.SetBool("isDead",true);
        hoverObject.SetActive(false);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        
        tutohandler.currentIndex = 5;
        tutohandler.NextPanel();
    }


}
