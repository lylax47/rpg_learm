using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{


    public GameObject player;
    public GameObject UIImage;
    // Start is called before the first frame update
    void Awake()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIImage);
        }
        
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
