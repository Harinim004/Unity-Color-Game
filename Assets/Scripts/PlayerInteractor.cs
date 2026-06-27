using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float interactionDistance = 10f;

    [Header("Managers")]
    public GameManager gameManager;
    public UIManager uiManager;
    public AudioManager audioManager;

    // Keeps track of the last object looked at
    private InteractableObject lastObject;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            InteractableObject obj = hit.collider.GetComponent<InteractableObject>();

            // Not an interactable object
            if (obj == null)
                return;

            // Prevent triggering repeatedly while looking at the same object
            if (obj == lastObject)
                return;

            lastObject = obj;

            CheckObject(obj);
        }
        else
        {
            // Reset when looking away
            lastObject = null;
        }
    }

    void CheckObject(InteractableObject obj)
    {
        // Don't interact if already completed
        if (!obj.IsInteractable())
            return;

        if (obj == gameManager.correctObject)
        {
            obj.MarkCorrect();

            audioManager.PlaySuccess();

            uiManager.ShowMessage("Correct");
        }
        else
        {
            StartCoroutine(obj.FlashRed());

            uiManager.ShowMessage("Try Again");
        }
    }
}