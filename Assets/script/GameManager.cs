using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    private float size;
    private float sizeZ;
   
 
    ScoreManager scoreManager;

    [SerializeField]
    GameObject platform;
    Vector3 LastPos;
    


    [SerializeField]
    GameObject gems;
	void Start () {

        size = platform.transform.localScale.x;
        sizeZ = platform.transform.localScale.z;
       
        LastPos = platform.transform.position;

        for(int x=0;x<4;x++)
        {
            SpawnZ();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
	}
	
	
	void Update () {
		
	}


    //Spawn Platform
    private void SpawnPlatform()
    {

        int random = Random.Range(0, 6);
        int gemsRandom = Random.Range(0, 7);

        if(random<3)
         SpawnX();

        if(random>=3)
        SpawnZ();

        if (gemsRandom < 2)
            SpawnGems();
        
    }

    //Platform Set
    private void SpawnGems()
    {
        Instantiate(gems, LastPos + new Vector3 (0f,0.7f,0f),gems.transform.rotation);
    }

    private void SpawnX()
    {

      
            GameObject _platform = Instantiate(platform) as GameObject;
            _platform.transform.position = LastPos + new Vector3(size, 0f, 0f);
            LastPos = _platform.transform.position;
        

     
               
            
        
    }

    private void SpawnZ()
    {

        GameObject _platform = Instantiate(platform) as GameObject;
        _platform.transform.position = LastPos + new Vector3(0f, 0f,sizeZ);
        LastPos = _platform.transform.position;
    }
}
