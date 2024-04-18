using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class CountScore : MonoBehaviour, IPointerClickHandler
{
    private SpawnEnemies spawnEnemies;
    private SubGameManager subGameManager;
    private Animator anim;
    

    void Start()
    {
        spawnEnemies = GameObject.Find("Enemies").GetComponent<SpawnEnemies>();
        anim = GetComponent<Animator>();
        subGameManager = GameObject.Find("subGameManager").GetComponent<SubGameManager>();

        anim.SetBool("isDead",false);

        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        subGameManager.FreezeScore(); //스코어 올라가게
        StartCoroutine(DieAnim());
        spawnEnemies.spawnCount -= 1;

        // StartCoroutine(RestartAnim());
    }

    IEnumerator DieAnim()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
