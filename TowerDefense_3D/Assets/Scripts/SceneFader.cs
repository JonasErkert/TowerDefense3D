using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image image;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));

    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime; // * 1 = in 1 sek. faden, * 2 = in halber sek. faden, * 0.5 = in 2 sek. faden.
            float alpha = fadeCurve.Evaluate(time);

            image.color = new Color(0f, 0f, 0f, alpha); 
            yield return 0; // Spring zu dem nächsten Frame (1 Frame warten, dann weitermachen).
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime; // * 1 = in 1 sek. faden, * 2 = in halber sek. faden, * 0.5 = in 2 sek. faden.
            float alpha = fadeCurve.Evaluate(time);

            image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0; // Spring zu dem nächsten Frame (1 Frame warten, dann weitermachen).
        }

        SceneManager.LoadScene(scene);

    }

}
