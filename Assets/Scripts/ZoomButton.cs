using UnityEngine;
using UnityEngine.UI;

public class ZoomButton : MonoBehaviour
{
    [SerializeField] MainCamera mainCamera = default;

    public void ZoomButtonClicked()
    {
        string newText = mainCamera.ToggleZoom();
        GetComponentInChildren<Text>().text = newText;
    }

}
