using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialog : MonoBehaviour
{
  public DialogSO Dialog=> dialog;
  [SerializeField] private DialogSO dialog;

  private Animator animator;
    void Start()
    {
        animator=GetComponentInParent<Animator>();
    }


    // Update is called once per frame
    public void UpdateDialogStatus(bool isInDialog)
    {
        animator.SetBool("IsInDialog", isInDialog);
    }
    public void SetAnimaton(int ind)
    {
        animator.SetFloat("DialogInd", dialog.AnimInd[ind]);
    }
}
