using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Season
{
    Spring, 
    Summer,
    Fall,
    Winter
}
public class SeasonComponent : MonoBehaviour
{
    [SerializeField] Material Summer;
    [SerializeField] Material Spring;
    [SerializeField] Material Fall;
    [SerializeField] Material Winter;

    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();        
    }

    protected virtual void OnSeasonChange(int season)
    {

        switch ((Season)season)
        {
            case Season.Summer:
                mesh.material = Summer;
                break;
            case Season.Spring:
                mesh.material = Spring; 
                break;
            case Season.Fall:
                mesh.material = Fall;
                break;
            case Season.Winter:
                mesh.material = Winter;
                break;
            default:
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
