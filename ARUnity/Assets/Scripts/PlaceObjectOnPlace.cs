using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceObjectOnPlace : MonoBehaviour
{
    [SerializeField]
    public ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    [SerializeField]
    public GameObject m_ObjectToPlace;

    void Update()
    {
       if(Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(index: 0);
            if(touch.phase == TouchPhase.Began)
            {
                if(m_RaycastManager.Raycast(touch.position,s_Hits,trackableTypes: TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;
                    Instantiate(m_ObjectToPlace, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
