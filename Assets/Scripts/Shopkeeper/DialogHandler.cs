using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] string[] welcomeDialogs;
    [SerializeField] string[] dialogs;
    [SerializeField] GameObject dialogFrameObj;
    [SerializeField] TextMeshProUGUI dialogText;

    public void InitiateDialog()
    {
        dialogFrameObj.gameObject.SetActive(true);
        OpenWelcomeDialogFrame();
    }

    public void OpenWelcomeDialogFrame()
    {
        var randIndex = Random.Range(0, welcomeDialogs.Length);

        dialogText.text = welcomeDialogs[randIndex];
    }

    public void OpenRandomDialogFrame()
    {
        var randIndex = Random.Range(0, dialogs.Length);

        dialogText.text = dialogs[randIndex];
    }
}
