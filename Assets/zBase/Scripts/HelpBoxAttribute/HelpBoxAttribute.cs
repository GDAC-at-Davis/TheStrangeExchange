using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class HelpBoxAttribute : PropertyAttribute
{
    public HelpBoxAttribute(string text, bool hideProperty = true, int space = 1)
    {
        Space = space;
        Text = text;
        HideProperty = hideProperty;
    }

    public string Text { get; }
    public int Space { get; }

    public bool HideProperty { get; }
}