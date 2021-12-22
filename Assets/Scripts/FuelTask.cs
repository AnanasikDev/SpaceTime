using UnityEngine;
using System.Collections;

public class FuelTask : Task
{
    public static FuelTask instance { get; set; }

    [Header("Cursor")]

    [SerializeField] private Transform Cursor;
    [SerializeField] private float CursorBounds = 164f;
    [SerializeField] public float CursorSpeed = 1f;
    [Tooltip("Debug value")] public bool IsInsideGreenZone = true;
    [SerializeField] private float PassDelay = 1f;
    private void MoveCursor()
    {
        if (!IsPassed)
            Cursor.transform.localPosition = new Vector2(Cursor.transform.localPosition.x, Mathf.Sin(Time.time * CursorSpeed) * CursorBounds);
    }

    private void Detect()
    {
        if (IsOpened && GetInput())
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
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        IsPassed = true;
        StatusImage.color = PassColor;
        
        AudioController.instance.Play(AudioController.instance.CorrectAnswer);

        yield return new WaitForSeconds(PassDelay);

        Close();
    }

    protected override void Fail()
    {
        AudioController.instance.Play(AudioController.instance.WrongAnswer);
        StatusImage.color = FailColor;
        IsPassed = false;
    }

    public override void Open()
    {
        IsOpened = true;
        WindowPanel.SetActive(true);
        PlayerMovement.instance.UseMotor = false;
    }
    public override void Close()
    {
        IsOpened = false;
        WindowPanel.SetActive(false);
        PlayerMovement.instance.UseMotor = true;
    }
}
