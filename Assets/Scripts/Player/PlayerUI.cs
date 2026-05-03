using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    public bool IsInInventory => invCanvas.enabled;
    [SerializeField] private Canvas invCanvas;
    [SerializeField] private DialogDisplayer dialogDisplayer;
    [SerializeField] private MerchantDisplayer merchantDisplayer;
    [SerializeField] GameObject invGroup;
    [SerializeField] GameObject craftGroup;
    void Start()
    {
        craftGroup.SetActive(false);
        invCanvas.enabled = false;
    }

    public void ChoseFirstCategory(bool isFirst)
    {
        invGroup.SetActive(isFirst);
    }
    public void ChoseSecondCategory(bool isSecond)
    {
        craftGroup.SetActive(isSecond);
    }


     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& !dialogDisplayer.IsInDialog && !merchantDisplayer.IsWithMerchant)
        {
            invCanvas.enabled = !invCanvas.enabled;

            if (invCanvas.enabled)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
