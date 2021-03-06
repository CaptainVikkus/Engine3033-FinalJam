using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsJumping;
    public bool IsRunning;
    public bool IsFiring;
    public bool IsPaused;

    [SerializeField] Transform FireLocation;
    [SerializeField] GameObject FireFX;
    [SerializeField] GameObject PauseUI;
    [SerializeField] public int CurrentSeason { get; private set; } = 0;

    private new AudioSource audio;
    private Animator animator;
    private PlayerInput input;
    public static readonly int IsFiringHash = Animator.StringToHash("IsFiring");



    private void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        input = GetComponent<PlayerInput>();
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
        //FX
        var particle = Instantiate(FireFX, FireLocation).GetComponent<ParticleController>();
        particle.SetSeason((Season)CurrentSeason);
        audio.Play();

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

    private void OnPause(InputValue pressed)
    {
        PauseToggle();
    }

    public void PauseToggle()
    {
        IsPaused = !IsPaused;

        Time.timeScale = IsPaused ? 0f : 1f;
        PauseUI.SetActive(IsPaused);
        AppEvents.Invoke_OnMouseCursorEnable(IsPaused);
        input.SwitchCurrentActionMap(IsPaused ? "UI" : "Player");
    }
}
