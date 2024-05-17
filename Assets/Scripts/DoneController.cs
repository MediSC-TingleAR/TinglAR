using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneController : MonoBehaviour
{
    private GameObject ARObj;
    [SerializeField] private GameObject done1;
    [SerializeField] private GameObject done2;
    void Start()
    {
        ARObj = GameObject.Find("ARGameObject");
        done1.SetActive(false);
        done2.SetActive(false);

        StartCoroutine(DoneControl());
    }

    IEnumerator DoneControl()
    {
        done1.SetActive(true);
        yield return new WaitForSeconds(3);
        done1.SetActive(false);
        ARObj.SetActive(false);
        done2.SetActive(true);
    }


}
