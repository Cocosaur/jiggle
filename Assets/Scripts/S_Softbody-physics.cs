using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SkinnedMeshRenderer))]

public class S_Softbody : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public float softness = 1f;
    
    [Range(0.01f, 1f)]
    public float damping = 0.1f;

    public float stiffness = 1f;

    private void Start()
    {
        CreateSoftBodyPhysics();
    }

    void CreateSoftBodyPhysics()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
        {
            Debug.Log("No Skinned Mesh Renderer Found");
            return;
        }
        
        Cloth cloth = gameObject.AddComponent<Cloth>();
        cloth.damping = damping;
        cloth.bendingStiffness = stiffness;

        cloth.coefficients = GenerateClothCoefficients(skinnedMeshRenderer.sharedMesh.vertices.Length);
    }

    private ClothSkinningCoefficient[] GenerateClothCoefficients(int vertexCount)
    {
        ClothSkinningCoefficient[] coefficients = new ClothSkinningCoefficient[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            coefficients[i].maxDistance = softness;
            coefficients[i].collisionSphereDistance = 0f;
        }

        return coefficients;
    }

}
