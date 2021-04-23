using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SeasonController : MonoBehaviour
{
    [SerializeField] public int CurrentSeason { get; private set; } = 1;

    public void OnChangeSeason(InputValue value)
    {
        CurrentSeason += (int)value.Get<float>();
        if (CurrentSeason > 3) //Greater than Winter
            CurrentSeason = 0;
        else if (CurrentSeason < 0) //Less than Summer
            CurrentSeason = 3;

        Debug.Log($"Season Changed to: {(Season)CurrentSeason}");
        PlayerEvents.Invoke_SeasonChange(CurrentSeason);
    }
}
