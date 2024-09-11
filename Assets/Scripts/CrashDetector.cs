using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground" && !hasCrashed){
            crashEffect.Play();
            //Have to find the object to access the method
            FindObjectOfType<PlayerController>().DisableControl();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",reloadDelay);            
            Debug.Log("Ouch!");
            hasCrashed = true;
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }

}
