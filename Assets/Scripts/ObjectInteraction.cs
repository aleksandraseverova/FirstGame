using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{

   // public GameObject canvas;
   [SerializeField] string location;
   [SerializeField] float positionX;
   [SerializeField] float positionY;
   [SerializeField] float positionZ;

   //[SerializeField] GameObject  player;

  

    private void Update()
    {
       
    }

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(location);
    }

}