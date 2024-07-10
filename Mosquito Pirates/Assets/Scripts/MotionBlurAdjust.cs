using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MotionBlurController : MonoBehaviour
{
    public Volume volume; // Referentie naar de Volume component
    private MotionBlur motionBlur;
    private Vignette vignette;
    private Bloom bloom;
    private LensDistortion ld;
    private ChromaticAberration ca;
    private float elapsedTime = 0f; // Variabele om de verstreken tijd bij te houden
    private float blurIncreaseRate = 0.1f; // Hoeveelheid waarmee de motion blur wordt verhoogd per seconde


    void Start()
    {
        if (volume.profile.TryGet<MotionBlur>(out motionBlur))
        {
            print("Yes.");
        }
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            print("Yes.");
        }
        if (volume.profile.TryGet<Bloom>(out bloom))
        {
            print("Yes.");
        }
        if (volume.profile.TryGet<ChromaticAberration>(out ca))
        {
            print("Yes.");
        }
        if (volume.profile.TryGet<LensDistortion>(out ld))
        {
            print("Yes.");
        }
    }
    void Update()
    {
        vignette.intensity.value += blurIncreaseRate * 0.15f * Time.deltaTime;
        bloom.intensity.value += blurIncreaseRate * 0.5f * Time.deltaTime;
        ca.intensity.value += blurIncreaseRate * 0.5f * Time.deltaTime;
        ld.intensity.value -= blurIncreaseRate * 0.5f * Time.deltaTime;
    }
}
