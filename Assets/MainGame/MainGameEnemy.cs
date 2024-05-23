using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;

public class MainGameEnemy : MonoBehaviour
{

    public GameObject hoverObject;
    [SerializeField] Collider _collider;

    private Animator anim;
    private bool _isDead = false;
    int a = 1; //moving 방향


    void Start()
    {
        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
        {
            // var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
            // poseTracker.ResetWorldMatrix();
        });

        hoverObject.SetActive(false);

        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
    }

    void Update()
    {
        if (_isDead)
            return;

        if (gameObject.transform.position.x < -0.3f)
            a = 1;
        else if (gameObject.transform.position.x > 0.3f)
            a = -1;

        gameObject.transform.Translate(Vector3.left * Time.deltaTime * a * 0.1f);
    }


    public void SetTargetted(bool b)
    {
        hoverObject.SetActive(b);
    }

    public void Kill()
    {
        StartCoroutine(DieAnim());

    }

    IEnumerator DieAnim()
    {
        _isDead = true;
        _collider.enabled = false;
        anim.SetBool("isDead", true);
        hoverObject.SetActive(false);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
