using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TreasureMapUI : MonoBehaviour
{
    [Header("UI Root")]
    [SerializeField] private GameObject uiRoot;
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Map Pieces")]
    [SerializeField] private Image[] mapPieces;

    [Header("Animation")]
    [SerializeField] private float fadeTime = 0.35f;

    private Coroutine animCoroutine;

    private void Awake()
    {
        if (canvasGroup == null)
            canvasGroup = uiRoot.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = uiRoot.AddComponent<CanvasGroup>();

        uiRoot.SetActive(false);
    }

    public void ShowMap(int unlockedPieces)
    {
        uiRoot.SetActive(true);

        unlockedPieces = Mathf.Clamp(unlockedPieces, 0, mapPieces.Length);

        int newestPieceIndex = unlockedPieces - 1;

        for (int i = 0; i < mapPieces.Length; i++)
        {
            bool isUnlocked = i < unlockedPieces;

            mapPieces[i].gameObject.SetActive(isUnlocked);

            if (isUnlocked)
            {
                if (i == newestPieceIndex)
                    SetAlpha(mapPieces[i], 0f);
                else
                    SetAlpha(mapPieces[i], 1f);
            }
        }

        if (animCoroutine != null)
            StopCoroutine(animCoroutine);

        animCoroutine = StartCoroutine(FadeInUI(newestPieceIndex));
    }

    private IEnumerator FadeInUI(int newestPieceIndex)
    {
        canvasGroup.alpha = 0f;

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.unscaledDeltaTime;
            float t = timer / fadeTime;

            canvasGroup.alpha = t;

            yield return null;
        }

        canvasGroup.alpha = 1f;

        if (newestPieceIndex >= 0 && newestPieceIndex < mapPieces.Length)
        {
            yield return StartCoroutine(FadeInPiece(newestPieceIndex));
        }
    }

    private IEnumerator FadeInPiece(int index)
    {
        Image piece = mapPieces[index];

        piece.gameObject.SetActive(true);
        SetAlpha(piece, 0f);

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.unscaledDeltaTime;
            float t = timer / fadeTime;

            SetAlpha(piece, t);

            yield return null;
        }

        SetAlpha(piece, 1f);
    }

    private void SetAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

    public void CloseMap()
    {
        uiRoot.SetActive(false);
    }
}