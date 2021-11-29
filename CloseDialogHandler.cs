using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogHandler : MonoBehaviour
{
    public GameManager GameManager;
    public void CloseDialog()
    {
        GameObject dialogObj = this.transform.parent.gameObject;
        dialogObj.SetActive(false);
        GameManager.WinChecker();
    }
}
