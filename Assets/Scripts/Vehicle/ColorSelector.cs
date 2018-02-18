using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Color Color;
    public bool RandomColor;

    private IEnumerable<Material> Materials;
    // Use this for initialization
    void Start()
    {
        Materials = GetComponentsInChildren<Renderer>().Select(x => x.material);
    }

    void Awake()
    {
      if(RandomColor) Color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var mat in Materials) mat.color = Color;
    }
}
