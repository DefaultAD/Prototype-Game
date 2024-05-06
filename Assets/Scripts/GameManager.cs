using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public GameObject gameScreen;
        
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowLoadingScreen()
    {
        //Activate Loading Screen.
        loadingScreen.SetActive(true);

        //Waits for 2 seconds.
        yield return new WaitForSeconds(2);

        //Deactivate Loading Screen.
        loadingScreen.SetActive(false);
    }
}
