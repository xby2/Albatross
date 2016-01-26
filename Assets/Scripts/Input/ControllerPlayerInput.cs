using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Returns the player input for someone using a controller
/// 
/// ASSUMES: XboxCtrlrInput package is imported (https://github.com/JISyed/Unity-XboxCtrlrInput)
/// </summary>
[System.Serializable]
public class ControllerPlayerInput : PlayerInput
{
    public int controllerNumber;

    /// <summary>
    /// Register the controller as player input
    /// </summary>
    /// <param name="_controllerNumber">Number of the controller to recieve input from</param>
    public ControllerPlayerInput(int _controllerNumber)
    {
        controllerNumber = _controllerNumber;
    }

    public string getName()
    {
        return "Controller Player " + controllerNumber;
    }

    public bool getActionHold()
    {
        throw new NotImplementedException();
    }

    public bool getActionPressDown()
    {
        throw new NotImplementedException();
    }

    public float getHorizontalAxis()
    {
        throw new NotImplementedException();
    }

    public float getVerticalAxis()
    {
        throw new NotImplementedException();
    }
}
