using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
    Renderer rend;

    bool interactable = true;

    Color originalColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        Color c = Random.ColorHSV();

        rend.material.color = c;

        originalColor = c;
    }

    public bool IsInteractable()
    {
        return interactable;
    }

    public void CorrectCube()
    {
        rend.material.color = Color.white;

        interactable = false;
    }

    public IEnumerator FlashRed()
    {
        rend.material.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        rend.material.color = originalColor;
    }
}