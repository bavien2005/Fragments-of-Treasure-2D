using System.Collections;
using UnityEngine;

/// <summary>
/// Scene-owned hit feedback for the LastWar boss. It is called by Treasure
/// Resonance only, so ordinary boss damage keeps its original presentation.
/// </summary>
public class BossResonanceImpact : MonoBehaviour
{
    [Header("Treasure Resonance Impact")]
    [SerializeField] private float pulseSoundVolume = 0.42f;
    [SerializeField] private float detonationSoundVolume = 0.9f;
    [SerializeField] private float flashDuration = 0.2f;
    [SerializeField] private Color flashColor = new Color(1f, 0.67f, 0.18f, 1f);

    private SpriteRenderer[] renderers;
    private Color[] originalColors;
    private Coroutine flashRoutine;

    private void Awake()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
        originalColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++) originalColors[i] = renderers[i].color;
    }

    public void PlayPulseImpact(int pulseIndex)
    {
        PlayFlash(false);
        TreasureResonanceVfx.SpawnBossImpact(transform.position, false, pulseIndex);
        if (AudioManagerr.Instance != null)
            AudioManagerr.Instance.PlaySFX("SwordBlood", pulseSoundVolume);
    }

    public void PlayDetonation()
    {
        PlayFlash(true);
        TreasureResonanceVfx.SpawnBossImpact(transform.position, true, 2);
        if (AudioManagerr.Instance != null)
            AudioManagerr.Instance.PlaySFX("SwordBlood", detonationSoundVolume);
    }

    private void PlayFlash(bool detonation)
    {
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(FlashRoutine(detonation));
    }

    private IEnumerator FlashRoutine(bool detonation)
    {
        float duration = detonation ? flashDuration * 1.8f : flashDuration;
        for (float elapsed = 0f; elapsed < duration; elapsed += Time.deltaTime)
        {
            float progress = elapsed / duration;
            float strength = Mathf.Sin(progress * Mathf.PI);
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i] == null) continue;
                renderers[i].color = Color.Lerp(originalColors[i], flashColor, strength * (detonation ? 0.92f : 0.62f));
            }
            yield return null;
        }

        RestoreColors();
        flashRoutine = null;
    }

    private void OnDisable()
    {
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        RestoreColors();
    }

    private void RestoreColors()
    {
        if (renderers == null || originalColors == null) return;
        for (int i = 0; i < renderers.Length; i++)
            if (renderers[i] != null) renderers[i].color = originalColors[i];
    }
}
