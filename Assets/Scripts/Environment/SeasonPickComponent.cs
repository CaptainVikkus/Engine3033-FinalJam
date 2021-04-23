using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonPickComponent : MonoBehaviour
{
    [SerializeField] GameObject Summer;
    [SerializeField] GameObject Fall;
    [SerializeField] GameObject Winter;
    [SerializeField] GameObject Spring;

    private void OnSeasonChange(int season)
    {
        switch ((Season)season)
        {
            case Season.Summer:
                Fall.SetActive(false);
                Winter.SetActive(false);
                Spring.SetActive(false);
                Summer.SetActive(true);
                break;
            case Season.Spring:
                Fall.SetActive(false);
                Winter.SetActive(false);
                Summer.SetActive(false);
                Spring.SetActive(true);
                break;
            case Season.Fall:
                Summer.SetActive(false);
                Winter.SetActive(false);
                Spring.SetActive(false);
                Fall.SetActive(true);
                break;
            case Season.Winter:
                Fall.SetActive(false);
                Summer.SetActive(false);
                Spring.SetActive(false);
                Winter.SetActive(true);
                break;
            default:
                Fall.SetActive(false);
                Winter.SetActive(false);
                Spring.SetActive(false);
                Summer.SetActive(false);
                break;
        }
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
