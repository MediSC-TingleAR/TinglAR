using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.Events;

public class PanelControl : MonoBehaviour
{
    public UnityEvent onNext;
    private ControllerHandEnum m_CurrentDebugHand = ControllerHandEnum.Right;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentDebugHand = NRInput.DomainHand;
    }

    // Update is called once per frame
    void Update()
    {
        if (NRInput.GetButtonDown(m_CurrentDebugHand, ControllerButton.TRIGGER))
        {
            NextPanel();
        }
    }

    private void NextPanel()
    {
        gameObject.SetActive(false);
        Debug.Log("Next Panel");
        onNext?.Invoke();
    }
}
