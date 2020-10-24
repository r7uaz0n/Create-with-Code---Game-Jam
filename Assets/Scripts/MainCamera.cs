﻿using System;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Player player = default;

    private Vector3 mapOverviewPosition = new Vector3(5.0f, 52.0f, 0.0f);
    private Vector3 cameraOffsetToPlayer = new Vector3(0.0f, 15.0f, 0.0f);
    private Vector3 cameraOffsetToRoom = new Vector3(0.0f, 17.0f, 0.0f);
    private GameObject roomToFocusOn = default;
    private String zoomInText = "Zoom In";
    private String zoomOutText = "Zoom Out";

    enum Focus
    {
        Map,
        Room,
        Player
    }
    Focus focus = Focus.Player;

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
                // Zoom should not be changed while inside a room.
                break;
        }

        return newButtonText;
    }

    public void PlayerInDoorToRoom(GameObject room)
    {
        if (player.gameObject.GetComponent<MeshRenderer>().bounds.Intersects(room.GetComponent<MeshRenderer>().bounds))
        {
            // Player is inside the room.
            focus = Focus.Room;
            roomToFocusOn = room;
        }
        else
        {
            // Player is outside the room.
            if (Focus.Room == focus)
            {
                focus = Focus.Player;
            }
        }
    }

    void Update()
    {
        switch (focus)
        {
            case Focus.Player:
                transform.position = player.transform.position + cameraOffsetToPlayer;
                break;
            case Focus.Map:
                transform.position = mapOverviewPosition;
                break;
            case Focus.Room:
                if (null != roomToFocusOn)
                {
                    transform.position = roomToFocusOn.transform.position + cameraOffsetToRoom;
                }
                else
                {
                    Debug.LogError("roomToFocusOn must not be null.");
                }
                break;
        }
    }
}
