using UnityEngine;
using UnityEngine.UI;

public class SwitchTask : Task
{
    [SerializeField] private Button[] Switches;
    [SerializeField] private string[] Settings; // Параметры переключения каждого свитча
    [SerializeField, Tooltip("Debug Value")] private int[] State;
    [SerializeField] private Color ColorEnabled;
    [SerializeField] private Color ColorDisabled;

    public void Switch(int i)
    {
        for(int _ = 0; _ < Switches.Length; _++)
        {
            if (Settings[i][_] == '1')
                Invert(_);
        }

        int sum = 0;
        foreach (int a in State) sum += a;
        if (sum == 6) Pass();
    }
    private void Invert(int index)
    {
        State[index] = 1 - State[index];
        Switches[index].image.color = State[index] == 1 ? ColorEnabled : ColorDisabled;
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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public override void Close()
    {
        WindowPanel.SetActive(false);
        PlayerMovement.instance.UseMotor = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
