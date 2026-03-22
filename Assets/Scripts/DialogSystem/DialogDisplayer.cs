using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogDisplayer : MonoBehaviour
{
    public bool IsInDialog => dialogCanvas.enabled;
    [SerializeField] private Canvas dialogCanvas;

    [SerializeField] private TMP_Text dialogHeader;
    [SerializeField] private TMP_Text dialogContent;

    [SerializeField] private float dialogSpeed;
    private string[] dialogTexts;
    private int curDialogInd;
    private NpcDialog curNPC;
   
    private void Start()
    {
        dialogCanvas.enabled = false;
    }
    public void StartDialog(NpcDialog npc)
    {
        dialogCanvas.enabled = true;
        curDialogInd= 0;

        dialogHeader.text = npc.Dialog.Name;
        dialogTexts = npc.Dialog.Texts;

        dialogContent.text = string.Empty;
        StartCoroutine(DisplayText());
        curNPC= npc;
        curNPC.UpdateDialogStatus(true);
        curNPC.SetAnimaton(curDialogInd);

        Cursor.lockState = CursorLockMode.None;
    }
    IEnumerator DisplayText()
    {
        for (int i = 0; i < dialogTexts[curDialogInd].Length; i++)
        {
            dialogContent.text += dialogTexts[curDialogInd][i];
            yield return  new WaitForSeconds(dialogSpeed);
        }
    }
    public void NextDalog()
    {
        curDialogInd++;

        if(curDialogInd >= dialogTexts.Length)
        {
            CloseDialog();
            return;
        }
        StopAllCoroutines();
        dialogContent.text = string.Empty;
        StartCoroutine(DisplayText());

        curNPC.SetAnimaton(curDialogInd);
    }
    public void CloseDialog()
    { 
        if (curNPC)
            curNPC.UpdateDialogStatus(false);
        StopAllCoroutines();
        dialogCanvas.enabled= false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
