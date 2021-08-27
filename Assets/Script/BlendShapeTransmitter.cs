using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UniRx;
using UniRx.Triggers;
using System.Linq;
using Cysharp.Threading.Tasks;
#if (UNITY_IOS || UNITY_EDITOR) && ARFOUNDATION_REMOTE_ENABLE_IOS_BLENDSHAPES
using UnityEngine.XR.ARKit;
#endif
#if UNITY_EDITOR
using ARKitFaceSubsystem = ARFoundationRemote.Runtime.FaceSubsystem;
#endif

public class BlendShapeTransmitter : MonoBehaviour
{
    // Start is called before the first frame update
    ARFaceManager _aRFaceManager;
    [SerializeField]
    SkinnedMeshRenderer m_SkinnedMeshRenderer;
    async void Start()
    {
        //await UniTask.WaitUntil(() => FindObjectOfType<ARFaceManager>() !=null);
        //var faceManager = FindObjectOfType<ARFaceManager>();
        //Debug.Log("facemanager: " + faceManager);
        //GameObject facePrefab = faceManager.facePrefab;
        //SkinnedMeshRenderer skinnedMeshRenderer = facePrefab.transform.Find("Sloth_Head2").GetComponent<SkinnedMeshRenderer>();
        //await UniTask.WaitUntil(() => (ARKitFaceSubsystem)faceManager.subsystem !=null);
        //var m_ARKitFaceSubsystem = (ARKitFaceSubsystem)faceManager.subsystem;
        //var m_Face = facePrefab.GetComponent<ARFace>();
        //Debug.Log("m_Face.trackableId"+m_Face.trackableId);
        //using (var blendShapes = m_ARKitFaceSubsystem.GetBlendShapeCoefficients(m_Face.trackableId, Allocator.Temp))
        //{
        //    if (skinnedMeshRenderer == null || !skinnedMeshRenderer.enabled || skinnedMeshRenderer.sharedMesh == null)
        //    {
        //        return;
        //    }
        //    m_ARKitFaceSubsystem.ObserveEveryValueChanged(x => blendShapes)
        //         .Subscribe(x =>
        //         {
        //             var list = blendShapes.Select(featureCoefficient =>
        //             {
        //                 Debug.Log(featureCoefficient.blendShapeLocation);
        //                 return featureCoefficient;
        //             }).ToList();
        //         });
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
