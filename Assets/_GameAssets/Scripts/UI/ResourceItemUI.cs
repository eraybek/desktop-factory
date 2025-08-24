using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class ResourceItemUI
{
    [Header("Resource Settings")]
    public ResourceType resourceType;
    
    [Header("UI Components")]
    public Image icon;
    public TextMeshProUGUI amountText;
}
