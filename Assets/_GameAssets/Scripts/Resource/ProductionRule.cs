using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ProductionRule
{
    [Header("Source Resource")]
    public ResourceType sourceResource;
    public int sourceAmount = 1;
    
    [Header("Output Resources")]
    public List<ResourceOutput> outputs = new List<ResourceOutput>();
    
    [Header("Settings")]
    public int clicksRequired = 1; 
    
    [System.NonSerialized]
    public int currentClicks = 0; 
}