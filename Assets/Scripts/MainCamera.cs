using System;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Player player;

    private Vector3 mapOverviewPosition = new Vector3(5.0f, 52.0f, 0.0f);
    private Vector3 playerOffset = new Vector3(0.0f, 15.0f, 0.0f);
    private String zoomInText = "Zoom In";
    private String zoomOutText = "Zoom Out";

    enum Focus
    {
        Map,
        Room,
        Player
    }
    private Focus focus = Focus.Player;

    // Gets called when the zoom button is pressed.
    // Returns the text that the zoom button should show next.
    public String ToggleZoom()
    {
        String newButtonText = String.Empty;

        switch (focus)
        {
            case Focus.Player:
                focus = Focus.Map;
                newButtonText = zoomInText;
                break;
            case Focus.Map:
                focus = Focus.Player;
                newButtonText = zoomOutText;
                break;
            case Focus.Room:
                break;
        }

        return newButtonText;
    }

    private void Update()
    {
        switch (focus)
        {
            case Focus.Player:
                transform.position = player.transform.position + playerOffset;
                break;
            case Focus.Map:
                transform.position = mapOverviewPosition;
                break;
            case Focus.Room:
                break;
        }
    }
}
