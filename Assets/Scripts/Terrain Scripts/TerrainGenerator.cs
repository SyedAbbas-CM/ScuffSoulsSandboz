using UnityEngine;

public class VoxelTerrainGenerator : MonoBehaviour
{
    public GameObject voxelPrefab; // The cube prefab to represent a voxel
    public int terrainWidth = 100; // Width of the terrain in voxels
    public int terrainDepth = 100; // Depth of the terrain in voxels
    public int terrainHeight = 20; // Maximum height of the terrain in voxels
    public float scale = 0.2f; // Scale factor for Perlin noise

    private void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < terrainWidth; x++)
        {
            for (int z = 0; z < terrainDepth; z++)
            {
                // Get the height value from Perlin noise
                float height = Mathf.PerlinNoise(x * scale, z * scale) * terrainHeight;

                for (int y = 0; y < height; y++)
                {
                    // Create a voxel at this position
                    CreateVoxel(x, y, z);
                }
            }
        }
    }

    void CreateVoxel(int x, int y, int z)
    {
        Vector3 position = new Vector3(x, y, z);
        Instantiate(voxelPrefab, position, Quaternion.identity);
    }
}