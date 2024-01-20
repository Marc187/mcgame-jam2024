using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private Upgrade currentUpgrade;
    public UnityEvent<Upgrade> onCardClicked;

    // Attach this method to the button click event in the Unity Editor
    public void OnButtonClick()
    {
        if (currentUpgrade != null)
        {
            onCardClicked.Invoke(currentUpgrade);
        }
    }

    public void ShowUpgrade(Upgrade upgrade)
    {
        currentUpgrade = upgrade;
        titleText.text = upgrade.title;
        descriptionText.text = upgrade.description;
    }
}
