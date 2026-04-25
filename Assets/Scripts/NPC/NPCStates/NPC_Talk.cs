using UnityEngine;

public class NPC_Talk : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    public Animator interactAnim;
    public DialogueSO dialogueSO;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        anim.Play("Idle");
        interactAnim.Play("Open");
    }


    private void OnDisable()
    {
        interactAnim.Play("Close");
    }


    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (GameManager.Instance == null || GameManager.Instance.dialogueManager == null)
            {
                Debug.LogWarning("DialogueManager missing!");
                return;
            }

            if (GameManager.Instance.dialogueManager.isDialogueActive)
            {
                GameManager.Instance.dialogueManager.AdvanceDialogue();
            }
            else
            {
                GameManager.Instance.dialogueManager.StartDialogue(dialogueSO);
            }
        }
    }
}
