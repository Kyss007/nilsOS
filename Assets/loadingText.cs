using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class loadingText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> tips;

    public float waitTime = 0.5f;
    public float maxRandomAditionalWait = 3f;

    private int index = 0;

    public void begin()
    {
        StartCoroutine(doText());
    }

    public IEnumerator doText()
    {
        yield return new WaitForSeconds(waitTime + Random.Range(0, maxRandomAditionalWait));

        text.text = tips[index];
        index++;

        if(index < tips.Count)
        {
            StartCoroutine(doText());
        }
        else
        {
            SceneManager.LoadScene("win");
        }
    }
}
