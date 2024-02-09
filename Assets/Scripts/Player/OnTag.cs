using UnityEngine;
using UnityEngine.Events;

public class OnTag : MonoBehaviour
{
    [SerializeField] protected UnityEvent TriggerEvent;
    [SerializeField] protected UnityEvent ExitTrigger;
    [SerializeField] private AudioClip clip;
    [SerializeField] protected string CollideName;
    [SerializeField] protected bool disableCollide = false;

    public void SubEvent(UnityAction action)
    {
        TriggerEvent.AddListener(action);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!string.IsNullOrEmpty(CollideName) && collision.gameObject.CompareTag(CollideName))
        {

            TriggerEvent?.Invoke();

            if (disableCollide)
            {
                collision.gameObject.SetActive(false);
            }
        }
        else if (string.IsNullOrEmpty(CollideName))
        {

            TriggerEvent?.Invoke();

            if (disableCollide)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!string.IsNullOrEmpty(CollideName) && collision.gameObject.CompareTag(CollideName))
        {

            ExitTrigger?.Invoke();

            if (disableCollide)
            {
                collision.gameObject.SetActive(false);
            }
        }
        else if (string.IsNullOrEmpty(CollideName))
        {

            ExitTrigger?.Invoke();

            if (disableCollide)
            {
                collision.gameObject.SetActive(false);
            }
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
