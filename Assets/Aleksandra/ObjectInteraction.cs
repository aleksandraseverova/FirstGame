using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
   // public GameObject canvas;
    public string locaci;

    private void Update()
    {
       
    }

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(locaci);
    }

}