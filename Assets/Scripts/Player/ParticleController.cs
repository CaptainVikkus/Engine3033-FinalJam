using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Color Choices")]
    [SerializeField] Gradient Summer;
    [SerializeField] Gradient SummerMotes;
    [SerializeField] Gradient Fall;
    [SerializeField] Gradient FallMotes;
    [SerializeField] Gradient Winter;
    [SerializeField] Gradient WinterMotes;
    [SerializeField] Gradient Spring;
    [SerializeField] Gradient SpringMotes;

    [Header("Particle Systems")]
    [SerializeField] ParticleSystem particleBody;
    [SerializeField] ParticleSystem particleMote;

    public void SetSeason(Season season)
    {
        var col = particleBody.colorOverLifetime;
        var colMote = particleMote.colorOverLifetime;
        switch (season)
        {
            case Season.Spring:
                col.color = Spring;
                colMote.color = SpringMotes;
                break;
            case Season.Summer:
                col.color = Summer;
                colMote.color = SummerMotes;
                break;
            case Season.Fall:
                col.color = Fall;
                colMote.color = FallMotes;
                break;
            case Season.Winter:
                col.color = Winter;
                colMote.color = WinterMotes;
                break;
            default:
                col.color = Spring;
                colMote.color = SpringMotes;
                break;
        }
    }
}
