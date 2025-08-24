using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "ResourceProductionData", menuName = "DesktopFactory/Resource Production Data")]
public class ResourceProductionData : ScriptableObject
{
    [Header("Production Rules")]
    public List<ProductionRule> productionRules = new List<ProductionRule>();
    
    public ProductionRule GetProductionRule(ResourceType sourceResource)
    {
        return productionRules.Find(rule => rule.sourceResource == sourceResource);
    }
}
