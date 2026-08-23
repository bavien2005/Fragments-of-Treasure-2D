using UnityEngine;

public class MapPieceTrigger : MonoBehaviour
{
    [SerializeField] private TreasureMapUI treasureMapUI;

    [SerializeField, Range(1, 4)]
    private int pieceIndex = 1;

    [SerializeField] private GameObject obj;

    private bool collected = false;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (collected) return;
        if (!other.CompareTag("Player")) return;
        obj?.SetActive(true);
        collected = true;

        if (obj != null)
            obj.SetActive(true);

        gameObject.SetActive(false);

        treasureMapUI.ShowMap(pieceIndex);

        Invoke(nameof(CloseMap), 2f);
    }

    private void CloseMap()
    {
        treasureMapUI.CloseMap();
        obj?.SetActive(false);
    }
}