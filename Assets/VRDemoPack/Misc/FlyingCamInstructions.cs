using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingCamInstructions : MonoBehaviour
{
    public CanvasGroup grp;
    public Text headerText;
    public float fadeTime = 2;
    public float fadeDelay = 3;

    void OnValidate()
    {
        CamToggle camToggle = GetComponent<CamToggle>();
        headerText.text = string.Format("Press <b>{0}</b> to toggle the flying camera", camToggle.toggleKey);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        BeginFadeOutRoutine();
    }

    public void BeginFadeOutRoutine()
    {
        StopAllCoroutines();
        grp.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    public void EndFadeOutRoutine()
    {
        StopAllCoroutines();
        grp.alpha = 0f;
        grp.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        grp.alpha = 1f;
        yield return new WaitForSeconds(fadeDelay);
        float endTime = Time.time + fadeTime;
        while (Time.time < endTime)
        {
            grp.alpha = (endTime - Time.time) / fadeTime;
            yield return null;
        }
        grp.alpha = 0f;
        grp.gameObject.SetActive(false);
    }
}
