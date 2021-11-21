using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    public void SetMaterial(Material material)
    {
        gameObject.GetComponent<Renderer>().material = material;
    }
}
