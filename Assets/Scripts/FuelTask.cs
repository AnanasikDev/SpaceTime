using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FuelTask : Task
{
    public static FuelTask instance { get; set; }

    [Header("Cursor")]

    [SerializeField] private Transform Cursor;
    [SerializeField] private float CursorBounds = 164f;
    [SerializeField] public float CursorSpeed = 1f;
    [Tooltip("Debug Value")] public bool IsInsideGreenZone = true;
    [SerializeField] private float PassDelay = 1f;

    [Tooltip("Debug Value")] public int PassedAmount = 0;
    [SerializeField] public int PassedAmountNeeded = 3;
    [SerializeField] public Image[] Statuses;
    private void MoveCursor()
    {
        if (IsPassed) return;
        
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

    protected override void Pass(bool playSound = true)
    {
        PassedAmount++;
        Statuses[PassedAmount-1].color = PassColor;
        if (PassedAmount >= PassedAmountNeeded)
        {
            StartCoroutine(Wait(playSound));
        }
        else
            if (playSound) AudioController.instance.Play(AudioController.instance.CorrectAnswer);
    }
    private IEnumerator Wait(bool playSound)
    {
        IsPassed = true;
        StatusImage.color = PassColor;
        
        if (playSound) AudioController.instance.Play(AudioController.instance.CorrectAnswer);

        _TaskPlace.Complete();

        yield return new WaitForSeconds(PassDelay);

        Close();

        DoorController.AddKey(Key);
    }

    protected override void Fail(bool playSound = true)
    {
        PassedAmount = 0;
        foreach (Image image in Statuses)
            image.color = FailColor;
        if (playSound) AudioController.instance.Play(AudioController.instance.WrongAnswer);
        StatusImage.color = FailColor;
        IsPassed = false;
    }

    public override void Open()
    {
        if (!IsPassed) Fail(false);

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
