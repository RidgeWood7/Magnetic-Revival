using System.Xml;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public interface Interactable 
{
    void interact();
    bool caninteract();
    void OpenChest();
    
} 