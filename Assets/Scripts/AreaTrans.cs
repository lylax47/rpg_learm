using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTrans : MonoBehaviour
{

    public string sceneToLoad;

    public string endNodeName;

    public float waitToLoad = 1f;
    public bool shouldLoadAfterFade;

    private GameObject endNodeObject;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance.recentTrans == true)
        {
            endNodeObject = GameObject.Find(PlayerController.instance.transEndNode);
            if (endNodeObject != null)
            {
                PlayerController.instance.transform.position = endNodeObject.transform.position;
            }
            UIFade.instance.FadeFromBlack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0f)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if recentTrans is null or false.
        //Should only be the case at start and after player leave transition box.
        if (other.tag == "Player" & PlayerController.instance.recentTrans == false)
        {
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();

            PlayerController.instance.recentTrans = true;
            PlayerController.instance.transEndNode = endNodeName;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // will set to false once player leaves transition area.
            PlayerController.instance.recentTrans = false;
            PlayerController.instance.transEndNode = null;
        }
    }
}
