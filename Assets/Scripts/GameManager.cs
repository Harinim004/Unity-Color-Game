using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CubeBehaviour[] cubes;

    public CubeBehaviour correctCube;

    void Start()
    {
        foreach (CubeBehaviour cube in cubes)
        {
            cube.SetRandomColor();
        }

        int index =
            Random.Range(0, cubes.Length);

        correctCube = cubes[index];
    }
}