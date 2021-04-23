using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTreeBehaviour : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] GameObject seedling;
    [SerializeField] GameObject sapling;
    [SerializeField] GameObject mature;
    [SerializeField] GameObject fruiting;
    [SerializeField] GameObject exit;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SetStage(stage);
    }

    void SetStage(int set)
    {
        if (stage > 3) { stage = 3; return; } //never go past fruiting

        seedling.SetActive(set == 0);
        sapling.SetActive(set == 1);
        mature.SetActive(set == 2);
        fruiting.SetActive(set == 3);

        if (stage == 3) //WINNER
            exit.SetActive(true);
    }
    private void OnSeasonChange(int season)
    {
        if ((Season)season == Season.Summer)
            SetStage(++stage);
    }

    private void OnEnable()
    {
        PlayerEvents.SeasonChanged += OnSeasonChange;
    }

    private void OnDisable()
    {
        PlayerEvents.SeasonChanged -= OnSeasonChange;
    }

}
