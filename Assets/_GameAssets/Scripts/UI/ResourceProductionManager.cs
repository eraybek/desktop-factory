using UnityEngine;

public class ResourceProductionManager : MonoBehaviour
{
    public static ResourceProductionManager Instance { get; private set; }
    
    [Header("Production Settings")]
    [SerializeField] private ResourceProductionData productionData;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ProcessResourceProduction(ResourceType sourceResource)
    {
        if (productionData == null) return;
        
        var rule = productionData.GetProductionRule(sourceResource);
        if (rule == null) return;
        
        ResourceManager.Instance?.AddResource(sourceResource, rule.sourceAmount);
        
        rule.currentClicks++;
        
        if (rule.currentClicks >= rule.clicksRequired)
        {
            ProduceOutputResources(rule);
            rule.currentClicks = 0;
        }
    }
    
    private void ProduceOutputResources(ProductionRule rule)
    {
        foreach (var output in rule.outputs)
        {
            if (Random.Range(0f, 1f) <= output.chance)
            {
                ResourceManager.Instance?.AddResource(output.resourceType, output.amount);
                Debug.Log($"Produced {output.amount} {output.resourceType} from {rule.sourceResource}");
            }
        }
    }
    
    public void SetProductionData(ResourceProductionData data)
    {
        productionData = data;
    }
}
