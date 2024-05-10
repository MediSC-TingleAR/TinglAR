using System.Collections;
using NRKernal;
//using OpenCVForUnityExample;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour, IPointerClickHandler
{
    private SpawnEnemies spawnEnemies;
    private SubGameManager subGameManager;
    private Animator anim;
    int a = 1; //moving 방향
    bool isKilled = false;

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



    void Update()
    {
        if(gameObject.transform.position.x < -0.3f)
        {
            a = 1;
        }
        else if(gameObject.transform.position.x > 0.3f) 
        {
            a= -1;
        }

        gameObject.transform.Translate(Vector3.left * Time.deltaTime * a * 0.35f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isKilled)
        {
        subGameManager.FreezeScore(); //스코어 올라가게
        StartCoroutine(DieAnim());
        spawnEnemies.spawnCount -= 1;
        isKilled = true;
        }
    }

    IEnumerator DieAnim()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
