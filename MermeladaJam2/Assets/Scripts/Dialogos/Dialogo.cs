using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Cinemachine;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool animacion = false;
    public Animator animator;
    public bool sinEntrada = false;
    public bool animacionSalir = false;
    public bool fundidoNegro = false;
    public Animator fundido;
    public GameObject muerte;
    public AudioSource aud;

    private Image sr;
    private int index;
    private bool start;
    private bool end = false;
    private CinemachineVirtualCamera virtualCamera;
    private Transform originCamera;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        sr = GetComponentInChildren<Image>();
        virtualCamera = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        originCamera = virtualCamera.Follow;
    }

    // Update is called once per frame
    void Update()
    {
        if (start==false|| end==true)
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
        if (end == true)
        {
            return;
        }
        if (sinEntrada==true&& start==false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.45f);
            StartDialogue();
            start = true;
        }

        if (sr.color.a < 0.5f)
        {
            GameManager.instance.stop = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a+0.5f*Time.fixedDeltaTime);
        }

        if (sr.color.a >= 0.45f&&start==false&& end == false)
        {
            StartDialogue();
            start = true;
        }
    }

    public void StartDialogue()
    {
        muerte.SetActive(true);
        GameManager.instance.stop = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            aud.Play();
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
            muerte.SetActive(false);
            if (animacion==true)
            {
                StartCoroutine(AnimationDialog());
            }
            else
            {
                GameManager.instance.stop = false;
                if (animacionSalir==true)
                {
                    GameManager.instance.final = true;
                }
                if (fundidoNegro==true)
                {
                    fundido.SetTrigger("Inicio");
                }
                gameObject.SetActive(false);
                GameManager.instance.eventosRealizados++;
            }
        }
    }

    IEnumerator AnimationDialog()
    {
        end = true;
        virtualCamera.Follow = animator.transform;
        
        textComponent.text = string.Empty;
        muerte.SetActive(false);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

        yield return new WaitForSeconds(0.1f);

        animator.SetTrigger("Inicio");

        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        GameManager.instance.eventosRealizados++;
        GameManager.instance.stop = false;
        virtualCamera.Follow = originCamera;
        gameObject.SetActive(false);
    }
}