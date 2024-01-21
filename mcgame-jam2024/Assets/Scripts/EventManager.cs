using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public UpgradeCardManager upgradeCardManager;
    public ScriptCameraFPS scriptCameraFPS;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        upgradeCardManager.ShowUpgradePanel();
        Time.timeScale = 0;
        scriptCameraFPS.enabled = false;
        player.SetActive(false);
    }
}
