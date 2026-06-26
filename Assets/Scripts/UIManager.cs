using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    public void ShowMessage(string msg)
    {
        StopAllCoroutines();

        StartCoroutine(
            Display(msg));
    }

    IEnumerator Display(string msg)
    {
        statusText.gameObject.SetActive(true);

        statusText.text = msg;

        yield return new WaitForSeconds(1.5f);

        statusText.gameObject.SetActive(false);
    }
}