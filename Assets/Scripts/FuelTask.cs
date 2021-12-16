using UnityEngine;

public class FuelTask : Task
{
    public static FuelTask instance { get; set; }

    [Header("Cursor")]

    [SerializeField] private Transform Cursor;
    [SerializeField] private float CursorBounds = 164f;
    [SerializeField] private float CursorSpeed = 1f;
    [Tooltip("Debug value")] public bool IsInsideGreenZone = true;
    private void MoveCursor()
    {
        if (!IsPassed)
            Cursor.transform.localPosition = new Vector2(Cursor.transform.localPosition.x, Mathf.Sin(Time.time * CursorSpeed) * CursorBounds);
    }

    private void Detect()
    {
        if (GetInput())
        {
            if (IsInsideGreenZone)
            {
                Pass();
            }
            else
            {
                Fail();
            }
        }
    }
    private bool GetInput()
    {
        return Input.GetKeyDown(KeyCode.Space) ||
               Input.GetKeyDown(KeyCode.Return) ||
               Input.GetMouseButtonDown(0) ||
               Input.GetMouseButtonDown(1);
    }
    private void GetExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPassed = false;
            Close();
        }
    }

    private void Update()
    {
        GetExit();
        MoveCursor();
        Detect();
    }

    protected override void Pass()
    {
        StatusImage.color = PassColor;
        IsPassed = true;
        Close();
    }

    protected override void Fail()
    {
        StatusImage.color = FailColor;
        IsPassed = false;
    }

    public override void Open()
    {
        WindowPanel.SetActive(true);
        PlayerMovement.instance.UseMotor = false;
    }
    public override void Close()
    {
        WindowPanel.SetActive(false);
        PlayerMovement.instance.UseMotor = true;
    }
}
