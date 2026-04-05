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
      if (collision.gameObject.tag == "Player")
      {
        fadeAnimator.Play("FadeToBlack");
        StartCoroutine(LoadSceneAfterFade());
      }
   }

   IEnumerator LoadSceneAfterFade()
   {
      yield return new WaitForSeconds(fadeDuration);
      SceneManager.LoadScene(sceneToLoad);
   }
}
