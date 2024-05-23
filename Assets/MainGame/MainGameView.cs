using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] _dialogPanels;

    public void NextDialogPanel(int index = -1)
    {
        if (index >= _dialogPanels.Length)
        {
            Debug.LogError("Index Overflow");
            return;
        }

        for (int i = 0; i < _dialogPanels.Length; i++)
        {
            if (i == index)
                _dialogPanels[i].gameObject.SetActive(false);
            else
                _dialogPanels[i].gameObject.SetActive(true);
        }
    }
}
