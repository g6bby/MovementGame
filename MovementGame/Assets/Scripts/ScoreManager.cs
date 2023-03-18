using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI fishText;

    void Start()
    {
        fishText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFishText(PlayerInventory playerInventory)
    {
        fishText.text = playerInventory.NumberOfFish.ToString();
    }

}
