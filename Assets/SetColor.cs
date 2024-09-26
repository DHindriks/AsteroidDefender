using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    [SerializeField] Material Fresnel;
    [SerializeField] ParticleSystem Swirl;
    [SerializeField] ParticleSystem Glow;


    float Transparency = 128;

    GradientColorKey[] SwirlColors = new GradientColorKey[2];
    GradientAlphaKey[] SwirlAlphas = new GradientAlphaKey[2];

    Gradient SwirlGradient = new Gradient();

    public void SetCoreColor(Color color)
    {
        var CMain = Glow.main;
        CMain.startColor = color;
        Fresnel.SetColor("_Color", color * 4);
    }

    public void SetSwirlPrimaryColor(Color color)
    {
        SwirlColors[0] = new GradientColorKey(color, 0);
        SwirlGradient.colorKeys = SwirlColors;
        RefreshSwirl();
    }

    public void SetSwirlSecondaryColor(Color color)
    {
        SwirlColors[1] = new GradientColorKey(color, 1);
        SwirlGradient.colorKeys = SwirlColors;
        RefreshSwirl();
    }

    public void SwirlPrimaryAlpha(float a)
    {
        SwirlAlphas[0] = new GradientAlphaKey(a, 0);
        RefreshSwirl();
    }
    public void SwirlSecondaryAlpha(float a)
    {
        SwirlAlphas[1] = new GradientAlphaKey(a, 1);
        RefreshSwirl();
    }

    void RefreshSwirl()
    {
        SwirlGradient.colorKeys = SwirlColors;
        SwirlGradient.alphaKeys = SwirlAlphas;
        var Smain = Swirl.main;
        Smain.startColor = SwirlGradient;
        Debug.Log(SwirlColors[1].color);
    }
}
