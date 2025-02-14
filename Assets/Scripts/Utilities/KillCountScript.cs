using TMPro;
using UnityEngine;

public class KillCountScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text killCountText;
    private int killCount;
    public int KillCount
    {
        get
        {
            return killCount;
        }
        set
        {
            killCount = value;
            UpdateKillCountUi();
        }
    }

    void Start()
    {
        KillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateKillCountUi()
    {
        killCountText.text = killCount.ToString();  
    }
}
