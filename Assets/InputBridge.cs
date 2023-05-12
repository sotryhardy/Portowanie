using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    public static IInput input;
    internal static Vector2 mouseScrollDelta => UnityEngine.Input.mouseScrollDelta;

    private void Awake()
    {
        input = new BaseInput();
    }

    internal static bool GetKey(KeyCode w)
    {
        return input.Getkey(w);
    }

    internal static float GetAxis(string v)
    {
        return input.GetAxis(v);
    }

    internal static bool GetKeyDown(KeyCode space)
    {
        return input.GetKeyDown(space);
    }

    internal static bool GetMouseButton(int v)
    {
        return input.GetMouseButton(v);
    }

    internal static bool GetMouseButtonDown(int v)
    {
        return input.GetMouseButtonDown(v);
    }

    internal static bool GetMouseButtonUp(int v)
    {
        return input.GetMouseButtonUp(v);
    }
}

public interface IInput
{
    public Vector2 GetMouseScrollDelta();
    public float GetAxis(string v);
    public bool GetMouseButton(int v);
    public bool Getkey(KeyCode e);
    public bool GetMouseButtonDown(int v);
    public bool GetMouseButtonUp(int v);
    public bool GetKeyDown(KeyCode space);
}

public class BaseInput : IInput
{
    Vector2 IInput.GetMouseScrollDelta() => UnityEngine.Input.mouseScrollDelta;
    float IInput.GetAxis(string v)
    {
        return UnityEngine.Input.GetAxis(v);
    }

    bool IInput.GetMouseButton(int v)
    {
        return UnityEngine.Input.GetMouseButton(v);
    }

    bool IInput.Getkey(KeyCode e)
    {
        return UnityEngine.Input.GetKey(e);
    }

    bool IInput.GetMouseButtonDown(int v)
    {
        return UnityEngine.Input.GetMouseButtonDown(v);
    }

    public bool GetMouseButtonUp(int v)
    {
        return UnityEngine.Input.GetMouseButtonUp(v);
    }

    bool IInput.GetKeyDown(KeyCode space)
    {
        return UnityEngine.Input.GetKeyDown(space);
    }
}
