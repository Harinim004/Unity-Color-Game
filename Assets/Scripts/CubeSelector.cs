using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    public float distance = 10f;

    public GameManager gameManager;

    public UIManager uiManager;

    public AudioManager audioManager;

    CubeBehaviour lastCube;

    void Update()
    {
        Ray ray =
            new Ray(
                transform.position,
                transform.forward);

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            distance))
        {
            CubeBehaviour cube =
                hit.collider
                .GetComponent<CubeBehaviour>();

            if (cube == null)
                return;

            if (cube == lastCube)
                return;

            lastCube = cube;

            CheckCube(cube);
        }
        else
        {
            lastCube = null;
        }
    }

    void CheckCube(CubeBehaviour cube)
    {
        if (!cube.IsInteractable())
            return;

        if (cube ==
           gameManager.correctCube)
        {
            cube.CorrectCube();

            audioManager.PlaySuccess();

            uiManager.ShowMessage(
                "Correct");
        }
        else
        {
            StartCoroutine(
                cube.FlashRed());

            uiManager.ShowMessage(
                "Try Again");
        }
    }
}