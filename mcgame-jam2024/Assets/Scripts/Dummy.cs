using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public UpgradeCardManager upgradeCardManager;
    // Start is called before the first frame update
    void Start()
    {
        upgradeCardManager.ShowUpgradePanel();
    }
}
