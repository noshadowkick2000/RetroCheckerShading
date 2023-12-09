using System;
using System.Collections;
using System.Collections.Generic;
using BBQ.Cooking;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public float strength;

    private List<Material> grilledMaterials = new List<Material>();
    [SerializeField] private Shader cookableShader;

    [SerializeField] private Pooler smokePooler;

    private Dictionary<Collider, Transform> colliderToSmokeDictionary = new Dictionary<Collider, Transform>();

    private void OnTriggerEnter(Collider other)
    {
        grilledMaterials.Add(other.GetComponent<Renderer>().material);
        
        Transform smoke = smokePooler.ActivateNewObject();
        smoke.SetParent(other.transform);
        smoke.transform.localPosition = Vector3.zero;
        colliderToSmokeDictionary.Add(other, smoke);

        if (other.gameObject.layer == 3) //cookable
        {
            other.GetComponent<Draggable>().HookGrill(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grilledMaterials.Remove(other.GetComponent<Renderer>().material);
        smokePooler.DeactivateObject(colliderToSmokeDictionary[other]);
        colliderToSmokeDictionary.Remove(other);
        
        if (other.gameObject.layer == 3) //cookable
        {
            other.GetComponent<Draggable>().UnHookGrill();
        }
    }

    public void SimulateOnTriggerExit(Collider other)
    {
        OnTriggerExit(other);
    }

    private void Awake()
    {
        InvokeRepeating(nameof(Cook), 0, 1);
    }

    private void Cook()
    {
        foreach (var material in grilledMaterials)
        {
            SetCookedness(material);
        }
    }

    private void SetCookedness(Material material)
    {
        if (material.shader == cookableShader)
            material.SetFloat("_Cookedness", material.GetFloat("_Cookedness") + strength);
    }
    
    
}
