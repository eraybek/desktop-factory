using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class ResourceUI : MonoBehaviour
{
    [Header("Resource Items")]
    [SerializeField] private List<ResourceItemUI> resourceItemsList = new List<ResourceItemUI>();
    
    private Dictionary<ResourceType, ResourceItemUI> resourceItems = new Dictionary<ResourceType, ResourceItemUI>();
    
    private void Start()
    {
        InitializeResourceItems();
        SubscribeToEvents();
        UpdateAllDisplays();
    }
    
    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    
    private void InitializeResourceItems()
    {
        resourceItems.Clear();
        
        foreach (var item in resourceItemsList)
        {
            if (item != null && item.resourceType != ResourceType.None)
            {
                resourceItems[item.resourceType] = item;
            }
        }
    }
    
    private void SubscribeToEvents()
    {
        if (ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnResourceChanged += UpdateResourceDisplay;
        }
    }
    
    private void UnsubscribeFromEvents()
    {
        if (ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnResourceChanged -= UpdateResourceDisplay;
        }
    }
    
    private void UpdateResourceDisplay(ResourceType resourceType, int amount)
    {        
        if (resourceItems.ContainsKey(resourceType))
        {
            var item = resourceItems[resourceType];
            if (item.amountText != null)
            {
                item.amountText.text = amount.ToString();
            }
        }
    }
    
    private void UpdateAllDisplays()
    {
        if (ResourceManager.Instance != null)
        {
            var allResources = ResourceManager.Instance.GetAllResources();
            foreach (var kvp in allResources)
            {
                UpdateResourceDisplay(kvp.Key, kvp.Value);
            }
        }
    }
}
