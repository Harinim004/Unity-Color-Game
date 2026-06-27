using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Array of all interactable objects
    public InteractableObject[] interactables;

    // The randomly selected correct object
    public InteractableObject correctObject;

    void Start()
    {
        // Assign a random color to each interactable object
        foreach (InteractableObject obj in interactables)
        {
            obj.SetRandomColor();
        }

        // Randomly select one object as the correct object
        int randomIndex = Random.Range(0, interactables.Length);

        correctObject = interactables[randomIndex];
    }
}