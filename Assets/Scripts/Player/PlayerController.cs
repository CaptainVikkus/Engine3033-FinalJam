using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsJumping;
    public bool IsRunning;
    public bool IsFiring;
    [SerializeField] public int CurrentSeason { get; private set; } = 1;

    private Animator animator;
    public static readonly int IsFiringHash = Animator.StringToHash("IsFiring");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnChangeSeason(InputValue value)
    {
        if (IsFiring) return; //Already casting

        CurrentSeason += (int)value.Get<float>();
        if (CurrentSeason > 3) //Greater than Winter
            CurrentSeason = 0;
        else if (CurrentSeason < 0) //Less than Summer
            CurrentSeason = 3;

        StartChangeSeason();
    }

    private void StartChangeSeason()
    {
        IsFiring = true;
        animator.SetBool(IsFiringHash, true);
        //TODO:: Particles

        InvokeRepeating(nameof(StopChangeSeason), 0, 0.1f);
    }
    private void StopChangeSeason()
    {
        if (animator.GetBool(IsFiringHash)) return; //still casting

        Debug.Log($"Season Changed to: {(Season)CurrentSeason}");
        PlayerEvents.Invoke_SeasonChange(CurrentSeason);
        IsFiring = false;
        CancelInvoke(nameof(StopChangeSeason));
    }
}
