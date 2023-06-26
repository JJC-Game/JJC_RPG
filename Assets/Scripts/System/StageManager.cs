using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class StageManager : MonoBehaviour
{
    List<GameObject> m_cubePrefabList;
    const int WORLD_X = 100, WORLD_Z = 100;

    enum CUBE_TYPE{
        GroundGrass,
        Ground,
        Wood,
        WoodTop,
    }
    void Awake(){
        m_cubePrefabList = new List<GameObject>();
        m_cubePrefabList.Add(Resources.Load<GameObject>("Prefabs/Cube/ground_cube_grass"));
        m_cubePrefabList.Add(Resources.Load<GameObject>("Prefabs/Cube/ground_cube"));
        m_cubePrefabList.Add(Resources.Load<GameObject>("Prefabs/Cube/wood_cube_1"));
        m_cubePrefabList.Add(Resources.Load<GameObject>("Prefabs/Cube/wood_cube_light_3"));

        CreateInitWorld();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateInitWorld(){

        // 真ん中の部分.
        CreateWall(CUBE_TYPE.GroundGrass, 0, WORLD_X - 1, 0, 0, 0, WORLD_Z - 1);

        // 壁の部分.
        int wall_height = 10;

        CreateWall(CUBE_TYPE.Ground, 0, 0,  0, wall_height - 1, 0, WORLD_Z-1);
        CreateWall(CUBE_TYPE.GroundGrass, 0, 0, wall_height, wall_height, 0, WORLD_Z - 1);
        CreateWall(CUBE_TYPE.Ground, WORLD_X - 1, WORLD_X -1, 0, wall_height - 1, 0, WORLD_Z-1);
        CreateWall(CUBE_TYPE.GroundGrass, WORLD_X - 1, WORLD_X - 1, wall_height, wall_height, 0, WORLD_Z - 1);

        CreateWall(CUBE_TYPE.Ground, 0, WORLD_X - 1, 0, wall_height - 1, 0, 0);
        CreateWall(CUBE_TYPE.GroundGrass, 0, WORLD_X - 1, wall_height, wall_height, 0, 0);
        CreateWall(CUBE_TYPE.Ground, 0, WORLD_X - 1, 0, wall_height - 1, WORLD_Z - 1, WORLD_Z - 1);
        CreateWall(CUBE_TYPE.GroundGrass, 0, WORLD_X - 1, wall_height, wall_height, WORLD_Z - 1, WORLD_Z - 1);

/*
        // 家の部分.
        int house_wall_height = 3;
        CreateHouse(CUBE_TYPE.Wood, WORLD_X / 2 - 3, WORLD_X / 2 - 3, 0, house_wall_height, WORLD_Z / 2 - 3, WORLD_Z / 2 + 3);
        CreateHouse(CUBE_TYPE.Wood, WORLD_X / 2 + 3, WORLD_X / 2 + 3, 0, house_wall_height, WORLD_Z / 2 - 3, WORLD_Z / 2 + 3);

        CreateHouse(CUBE_TYPE.Wood, WORLD_X / 2 - 2, WORLD_X / 2 + 2, 0, house_wall_height, WORLD_Z / 2 - 3, WORLD_Z / 2 - 3);
//        CreateHouse(CUBE_TYPE.Wood, WORLD_X / 2 - 2, WORLD_X / 2 + 2, 0, house_wall_height, WORLD_Z / 2 + 3, WORLD_Z / 2 + 3);
*/
    }

    void CreateCube(CUBE_TYPE cubeType, int cube_x, int cube_y, int cube_z, Transform parent, bool isNoCollider = false)
    {
        // 開始座標を指定.
        Vector3 startPos = new Vector3(-WORLD_X / 2, 0, -WORLD_Z / 2);

        GameObject instance = Instantiate(m_cubePrefabList[(int)cubeType]);
        instance.transform.SetParent(parent);
        instance.transform.position = new Vector3(startPos.x + cube_x, startPos.y + cube_y, startPos.z + cube_z);

        if (isNoCollider)
        {
            GameObject.Destroy(instance.GetComponent<BoxCollider>());
        }
    }

    void CreateWall(CUBE_TYPE cubeType, int start_x, int end_x, int start_y, int end_y, int start_z, int end_z)
    {
        CreateWallCore(cubeType, start_x, end_x, start_y, end_y, start_z, end_z, this.gameObject.transform);
    }
    void CreateHouse(CUBE_TYPE cubeType, int start_x, int end_x, int start_y, int end_y, int start_z, int end_z)
    {
        Transform parent = GameObject.Find("House").transform;
        CreateWallCore(cubeType, start_x, end_x, start_y, end_y, start_z, end_z, parent);
    }

    void CreateWallCore(CUBE_TYPE cubeType, int start_x, int end_x, int start_y, int end_y, int start_z, int end_z, Transform parent)
    {
        int cube_x = 0;
        int cube_y = 0;
        int cube_z = 0;
        for (cube_x = start_x; cube_x <= end_x; cube_x++)
        {
            for (cube_y = start_y; cube_y <= end_y; cube_y++)
            {
                for (cube_z = start_z; cube_z <= end_z; cube_z++)
                {
                    CreateCube(cubeType, cube_x, cube_y, cube_z, parent);
                }
            }
        }
    }

}
