using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    
    [SerializeField] private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    
    public event Action<ResourceType, int> OnResourceChanged;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeResources();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializeResources()
    {
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            if (resourceType != ResourceType.None)
            {
                resources[resourceType] = 0; 
            }
        }
    }
    
    public int GetResourceAmount(ResourceType resourceType)
    {
        return resources.ContainsKey(resourceType) ? resources[resourceType] : 0;
    }
    
    public bool HasEnoughResource(ResourceType resourceType, int amount)
    {
        return GetResourceAmount(resourceType) >= amount;
    }
    
    public bool ConsumeResource(ResourceType resourceType, int amount)
    {
        if (HasEnoughResource(resourceType, amount))
        {
            resources[resourceType] -= amount;
            OnResourceChanged?.Invoke(resourceType, resources[resourceType]);
            return true;
        }
        return false;
    }
    
    public void AddResource(ResourceType resourceType, int amount)
    {
        if (resources.ContainsKey(resourceType))
        {
            resources[resourceType] += amount;
        }
        else
        {
            resources[resourceType] = amount;
        }
        OnResourceChanged?.Invoke(resourceType, resources[resourceType]);
    }
    
    public Dictionary<ResourceType, int> GetAllResources()
    {
        return new Dictionary<ResourceType, int>(resources);
    }
}
