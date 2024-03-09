using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private Image sr;
    private int index;
    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        sr = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start==false)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void FixedUpdate()
    {
        if (sr.color.a < 0.5f)
        {
            GameManager.instance.stop = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a+0.5f*Time.fixedDeltaTime);
        }
        if (sr.color.a >= 0.45f&&start==false)
        {
            StartDialogue();
            start = true;
        }
    }

    public void StartDialogue()
    {
        GameManager.instance.stop = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            GameManager.instance.stop = false;
            gameObject.SetActive(false);
        }
    }
}