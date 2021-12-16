using UnityEngine;

public class Init : MonoBehaviour
{
    private void InitControllers()
    {
        FuelTask.instance = FindObjectOfType<FuelTask>();
    }
    private void InitPlaces()
    {
        foreach (TaskPlace place in FindObjectsOfType<TaskPlace>())
            place.Init();
    }
    private void Start()
    {
        InitControllers();

        InitPlaces();
    }
}
