using UnityEngine;
using UnityEngine.UI;

public class ZoomButton : MonoBehaviour
{
    [SerializeField] MainCamera mainCamera = default;

    enum ZoomState
    {
        In,
        Out
    }
    ZoomState zoomState = ZoomState.In;

    public void ZoomButtonClicked()
    {
        switch (zoomState)
        {
            case ZoomState.In:
                zoomState = ZoomState.Out;
                mainCamera.ZoomOut();
                GetComponentInChildren<Text>().text = "Zoom In";
                break;
            case ZoomState.Out:
                zoomState = ZoomState.In;
                mainCamera.ZoomIn();
                GetComponentInChildren<Text>().text = "Zoom Out";
                break;
        }
    }

}
