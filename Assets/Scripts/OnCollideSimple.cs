using UnityEngine;
using UnityEngine.Events;
using System;

public class OnCollideSimple : MonoBehaviour
{
    [SerializeField] protected UnityEvent TriggerEvent;
    [SerializeField] protected UnityEvent ExitTrigger;
    [SerializeField] protected string CollideTag;
    public static Action OnFailed;
    public static Action OnAccept;
    public void SubEvent(UnityAction action)
    {
        TriggerEvent.AddListener(action);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEvent?.Invoke();


        if (LevelManager.IsActiveCart1 && collision.gameObject.CompareTag("Fruits"))
        {
            collision.gameObject.SetActive(false);
            OnAccept();
        }
        else if (LevelManager.IsActiveCart2 && collision.gameObject.CompareTag("Fruits2"))
        {
            collision.gameObject.SetActive(false);
            OnAccept();
        }
        else if (LevelManager.IsActiveCart3 && collision.gameObject.CompareTag("Fruits3"))
        {
            collision.gameObject.SetActive(false);
            OnAccept();
        }
        else if (collision.gameObject.CompareTag("BG"))
        {

        }
        else
        {
            OnFailed();
        }



    }

    public void DisableComponentAndCollider()
    {
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }

    public void DelComponent()
    {
        Destroy(this);
    }
}
