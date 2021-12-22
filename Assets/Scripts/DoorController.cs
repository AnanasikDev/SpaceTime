using UnityEngine;
using System.Collections.Generic;
public class DoorController : MonoBehaviour
{
    public static List<int> Keys;

    private void Start()
    {
        Keys = new List<int>();
    }
    public static void AddKey(int key)
    {
        if (Keys.Contains(key)) return;

        Door[] doors = FindObjectsOfType<Door>();

        Keys.Add(key);

        foreach (Door door in doors)
            door.SetImage();
    }
    public static bool ContainsKey(int key) => Keys.Contains(key);
}
