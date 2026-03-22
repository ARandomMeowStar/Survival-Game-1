using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
   [SerializeField] private DialogDisplayer dialogDisplayer;
   private PlayerUI playerUI;
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(!playerUI.IsInInventory && !dialogDisplayer.IsInDialog &&
        other.TryGetComponent(out NpcDialog npc) && Input.GetKey(KeyCode.Q))
        {
            dialogDisplayer.StartDialog(npc);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialogDisplayer.CloseDialog();
    }
}
