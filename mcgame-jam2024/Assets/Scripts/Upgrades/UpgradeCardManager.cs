using UnityEngine;

public class UpgradeCardManager : MonoBehaviour
{
    public UpgradeCard[] upgradeCards;
    public PlayerStats playerStats;
    public GameObject upgradePanel; // Reference to the panel containing the upgrade cards
    public TextAsset jsonFile;

    public ScriptCameraFPS scriptCameraFPS;
    public GameObject player;

    // Call this method to show the upgrade panel and randomize upgrades
    public void ShowUpgradePanel()
    {
        Cursor.visible = true;
        // Show the upgrade panel
        upgradePanel.SetActive(true);

        // Randomly select upgrades for each card
        for (int i = 0; i < upgradeCards.Length; i++)
        {
            Upgrade randomUpgrade = GetRandomUpgrade();
            upgradeCards[i].ShowUpgrade(randomUpgrade);
        }
    }

    // Call this method when a card is clicked
    public void OnCardClicked(Upgrade upgrade)
    {
        ApplyStatUpgrade(upgrade);
        upgradePanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        scriptCameraFPS.enabled = true;
        player.SetActive(true);
    }

    private void ApplyStatUpgrade(Upgrade upgrade)
    {
        switch (upgrade.effect.statName)
        {
            case "health":
                if (upgrade.effect.type == "custom")
                {

                }
                else
                {
                    playerStats.IncreaseMaxHealth(upgrade.effect.value);
                }
                break;
            case "speed":
                playerStats.IncreaseSpeed(upgrade.effect.value);
                break;
            case "damage":
                playerStats.IncreaseDamage(upgrade.effect.value);
                break;
        }
    }

    private Upgrade GetRandomUpgrade()
    {
        Upgrade[] upgrades = LoadUpgradesFromJson(); // Implement this method to load upgrades from the JSON file
        return upgrades[Random.Range(0, upgrades.Length)];
    }

    private Upgrade[] LoadUpgradesFromJson()
    {
        UpgradeList upgradeInJson = JsonUtility.FromJson<UpgradeList>(jsonFile.text);
        return upgradeInJson.upgrades;
    }
}
