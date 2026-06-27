using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour
{
    // Reference to this object's Renderer
    private Renderer objectRenderer;

    // Stores the object's original random color
    private Color originalColor;

    // Determines whether the object can still be interacted with
    private bool interactable = true;

    // Called when the object is created
    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Assigns a random color to the object
    public void SetRandomColor()
    {
        Color randomColor = Random.ColorHSV();

        objectRenderer.material.color = randomColor;

        // Save the color so we can restore it after flashing red
        originalColor = randomColor;
    }

    // Returns whether the object can still be interacted with
    public bool IsInteractable()
    {
        return interactable;
    }

    // Called when this is the correct object
    public void MarkCorrect()
    {
        // Prevent interacting with this object again
        if (!interactable)
            return;

        objectRenderer.material.color = Color.white;

        interactable = false;
    }

    // Flash the object red briefly when it is incorrect
    public IEnumerator FlashRed()
    {
        // If interaction has already been disabled, do nothing
        if (!interactable)
            yield break;

        objectRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        objectRenderer.material.color = originalColor;
    }

    // Optional: Re-enable interaction if needed in the future
    public void EnableInteraction()
    {
        interactable = true;
    }

    // Optional: Disable interaction manually if needed
    public void DisableInteraction()
    {
        interactable = false;
    }

    // Returns the object's current color (useful for debugging)
    public Color GetCurrentColor()
    {
        return objectRenderer.material.color;
    }
}