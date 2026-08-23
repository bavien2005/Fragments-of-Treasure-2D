using UnityEngine;

public class MapEnable : MonoBehaviour
{
    [SerializeField] private GameObject MapUI;
    private bool isActive = false;
    void Update()
    {
        EnableMap();
    }
    void EnableMap() {
        {
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (!isActive)
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }
                MapUI.SetActive(isActive);
            }

        } 
    }
}
