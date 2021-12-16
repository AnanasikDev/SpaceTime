using UnityEngine;

public class FuelTaskCursor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FuelTaskGreenZone"))
        {
            FuelTask.instance.IsInsideGreenZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FuelTaskGreenZone"))
        {
            FuelTask.instance.IsInsideGreenZone = false;
        }
    }
}
