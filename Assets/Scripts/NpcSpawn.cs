using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NpcSpawn : MonoBehaviour
{
    [SerializeField] GameObject goodBoy;
    [SerializeField] GameObject badGuy;
    private Random rand;

    private void Start()
    {
        rand = new Random();
    }

    public void Spawn()
    {
        switch (rand.Next(2))
        {
            case 0:
                Instantiate(goodBoy, new Vector3(rand.Next(-11, 10), rand.Next(-11, 10), rand.Next(-11, 10)), Quaternion.identity);
                break;
            case 1:
                Instantiate(badGuy, new Vector3(rand.Next(-11, 10), rand.Next(-11, 10), rand.Next(-11, 10)), Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
