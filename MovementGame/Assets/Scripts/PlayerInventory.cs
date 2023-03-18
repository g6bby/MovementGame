using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfFish { get; private set; }

    public UnityEvent<PlayerInventory> OnFishCollected;

    public void FishCollected()
    {
        NumberOfFish++;
        OnFishCollected.Invoke(this);
    }
}
