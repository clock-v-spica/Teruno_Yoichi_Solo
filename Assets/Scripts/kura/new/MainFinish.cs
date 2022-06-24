using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainFinish : MonoBehaviour
{
    [SerializeField] private GameObject CenterEyesAnchor;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MainSceneFinish(){
        SceneManager.LoadScene("PhotonSample");
    }
    
}
