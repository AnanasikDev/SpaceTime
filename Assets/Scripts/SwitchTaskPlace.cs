using UnityEngine;
using UnityEngine.UI;
public class SwitchTaskPlace : TaskPlace
{
    [SerializeField] private GameObject SwitchesPanel;
    [SerializeField] private Button[] Switches;
    [SerializeField] private string[] Settings; // Параметры переключения каждого свитча
    [SerializeField, Tooltip("Debug Value")] private int[] State;

    private void Start()
    {
        OnOpened += SetParams;
        State = new int[Switches.Length];
    }
    private void SetParams()
    {
        SwitchTask.instance.EnableSwitches(false);

        SwitchTask.instance.SwitchesPanel = SwitchesPanel;
        SwitchTask.instance.Switches = Switches;
        SwitchTask.instance.Settings = Settings;
        SwitchTask.instance.State = State;

        SwitchTask.instance.EnableSwitches(true);
    }
}
