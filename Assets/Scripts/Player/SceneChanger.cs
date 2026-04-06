using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
   public string sceneToLoad;
   public Animator fadeAnimator;
   public float fadeDuration = .5f;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      Debug.Log("Something has entered the trigger");
      if (collision.gameObject.tag == "Player")
      {
         Debug.Log("Player entered the trigger, starting fade and scene change.");
         fadeAnimator.Play("FadeToBlack");
         StartCoroutine(DelayFade());
      }
   }

   IEnumerator DelayFade()
   {
      yield return new WaitForSeconds(fadeDuration);
      SceneManager.LoadScene(sceneToLoad);
   }
}
