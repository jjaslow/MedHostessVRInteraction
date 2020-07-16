using UnityEngine;
using UnityEngine.UI;
using static OVRInput;

public class PhysicsPointer : MonoBehaviour
{

    public float defaultLength = 5f;
    private LineRenderer lineRenderer = null;
    //bool startedTalking = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if(hit.collider)
        {
            endPosition = hit.point;
        }

        IInteractable other = hit.collider.gameObject.GetComponent<IInteractable>();
        if (other != null)
            TakeAction(other);

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }


    private void TakeAction(IInteractable other)
    {
        other.OnHover();

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .5f)
            other.OnClick();
    }

}



/*
 *             Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.GetComponent<Image>() != null)
            {
                hit.collider.gameObject.GetComponent<Image>().color = Color.red;

                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .5f)
                    hit.collider.gameObject.GetComponent<PointerEvents>().OnPointerClick();
            }
            else if (!startedTalking && hit.collider.gameObject.GetComponent<Hostess>() != null)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .5f)
                {
                    startedTalking = true;
                    hit.collider.gameObject.GetComponent<Hostess>().StartTalking();
                }
            }
 * 
 */
