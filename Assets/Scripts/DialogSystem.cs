using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Player Player;
    public Image dialogPanel;
    public Text dialogText;
    public float Damage;
    public BoxCollider2D bc;

    public string message;

    // Start is called before the first frame update
    void Awake()
    {
        bc.isTrigger = true;
        dialogText.enabled = false;
        dialogPanel.enabled = false;
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You read the sign");
        dialogPanel.enabled = true;
        dialogText.enabled = true;
        dialogText.text = message.ToString();
        Player.TakeDamage(Damage);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogPanel.enabled = false;
        dialogText.enabled = false;
        
    }

    
}
