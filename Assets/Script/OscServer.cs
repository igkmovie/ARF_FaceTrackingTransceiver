using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OscServer : MonoBehaviour
{
    public GameObject faceObj;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    Dictionary<string, int> m_FaceArkitBlendShapeIndexMap;
    public GameObject headbone;　//モデルの頭ボーンをアタッチする。
    public GameObject neck;　//モデルの首ボーンをアタッチする

    // Start is called before the first frame update
    public void OnMess(string value)
    {

        var blendshapeModels = JsonUtility.FromJson<BlendshapeModels>(value);
        Debug.Log(blendshapeModels.headPosRot.rot);
        var blendshapes = blendshapeModels.shapes;
        blendshapes
            .Where(x => m_FaceArkitBlendShapeIndexMap.TryGetValue(x.Location, out int mappedBlendShapeIndex))
            .Where(x => m_FaceArkitBlendShapeIndexMap[x.Location] >= 0)
            .Select(x =>
            {
                var val = m_FaceArkitBlendShapeIndexMap[x.Location];
                //Debug.Log(val);
                skinnedMeshRenderer.SetBlendShapeWeight(val, x.coefficient * 100);
                var rot = blendshapeModels.headPosRot.rot.eulerAngles;
                // モデルの首ボーンを回転させてるが自作モデルようなのでうまく行かない場合はそれぞれでやって下さい
                if(neck != null)
                {
                    neck.transform.localRotation = Quaternion.Euler(-rot.y, -rot.z, rot.x);
                }
                
                return x;
            }).ToList();

    }
    private void Awake()
    {
        CreateFeatureBlendMapping();
    }
    void CreateFeatureBlendMapping()
    {

        if (skinnedMeshRenderer == null || skinnedMeshRenderer.sharedMesh == null)
        {
            return;
        }
        const string strPrefix = "";
        //BlenderのAddon、FaceItで自動作成されるブレンドシャイプ名になってます。自作モデルとブレンドシャイプ名が違う場合は修正の必要があります。
        m_FaceArkitBlendShapeIndexMap = new Dictionary<string, int>();
        m_FaceArkitBlendShapeIndexMap["BrowDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "browDownLeft");
        m_FaceArkitBlendShapeIndexMap["BrowDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "browDownRight");
        m_FaceArkitBlendShapeIndexMap["BrowInnerUp"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "browInnerUp");
        m_FaceArkitBlendShapeIndexMap["BrowOuterUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "browOuterUpLeft");
        m_FaceArkitBlendShapeIndexMap["BrowOuterUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "rowOuterUpRight");
        m_FaceArkitBlendShapeIndexMap["CheekPuff"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "cheekPuff");
        m_FaceArkitBlendShapeIndexMap["CheekSquintLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "cheekSquint_L");
        m_FaceArkitBlendShapeIndexMap["CheekSquintRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "cheekSquintLeft");
        m_FaceArkitBlendShapeIndexMap["EyeBlinkLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeBlinkLeft");
        m_FaceArkitBlendShapeIndexMap["EyeBlinkRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeBlinkRight");
        m_FaceArkitBlendShapeIndexMap["EyeLookDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookDownLeft");
        m_FaceArkitBlendShapeIndexMap["EyeLookDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookDownRight");
        m_FaceArkitBlendShapeIndexMap["EyeLookInLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookInLeft");
        m_FaceArkitBlendShapeIndexMap["EyeLookInRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookInRight");
        m_FaceArkitBlendShapeIndexMap["EyeLookOutLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookOutLeft");
        m_FaceArkitBlendShapeIndexMap["EyeLookOutRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookOutRight");
        m_FaceArkitBlendShapeIndexMap["EyeLookUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookUpLeft");
        m_FaceArkitBlendShapeIndexMap["EyeLookUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeLookUpRight");
        m_FaceArkitBlendShapeIndexMap["EyeSquintLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeSquintLeft");
        m_FaceArkitBlendShapeIndexMap["EyeSquintRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeSquintRight");
        m_FaceArkitBlendShapeIndexMap["EyeWideLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeWideLeft");
        m_FaceArkitBlendShapeIndexMap["EyeWideRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "eyeWideRight");
        m_FaceArkitBlendShapeIndexMap["JawForward"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "jawForward");
        m_FaceArkitBlendShapeIndexMap["JawLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "jawLeft");
        m_FaceArkitBlendShapeIndexMap["JawOpen"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "jawOpen");
        m_FaceArkitBlendShapeIndexMap["JawRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "jawRight");
        m_FaceArkitBlendShapeIndexMap["MouthClose"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthClose");
        m_FaceArkitBlendShapeIndexMap["MouthDimpleLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthDimpleLeft");
        m_FaceArkitBlendShapeIndexMap["MouthDimpleRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthDimpleRight");
        m_FaceArkitBlendShapeIndexMap["MouthFrownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthFrownLeft");
        m_FaceArkitBlendShapeIndexMap["MouthFrownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthFrownRight");
        m_FaceArkitBlendShapeIndexMap["MouthFunnel"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthFunnel");
        m_FaceArkitBlendShapeIndexMap["MouthLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthLeft");
        m_FaceArkitBlendShapeIndexMap["MouthLowerDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthLowerDownLeft");
        m_FaceArkitBlendShapeIndexMap["MouthLowerDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthLowerDownRight");
        m_FaceArkitBlendShapeIndexMap["MouthPressLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthPressLeft");
        m_FaceArkitBlendShapeIndexMap["MouthPressRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthPressRight");
        m_FaceArkitBlendShapeIndexMap["MouthPucker"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthPucker");
        m_FaceArkitBlendShapeIndexMap["MouthRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthRight");
        m_FaceArkitBlendShapeIndexMap["MouthRollLower"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthRollLower");
        m_FaceArkitBlendShapeIndexMap["MouthRollUpper"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthRollUpper");
        m_FaceArkitBlendShapeIndexMap["MouthShrugLower"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthShrugLower");
        m_FaceArkitBlendShapeIndexMap["MouthShrugUpper"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthShrugUpper");
        m_FaceArkitBlendShapeIndexMap["MouthSmileLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthSmileLeft");
        m_FaceArkitBlendShapeIndexMap["MouthSmileRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthSmileRight");
        m_FaceArkitBlendShapeIndexMap["MouthStretchLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthStretchLeft");
        m_FaceArkitBlendShapeIndexMap["MouthStretchRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthStretchRight");
        m_FaceArkitBlendShapeIndexMap["MouthUpperUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthUpperUpLeft");
        m_FaceArkitBlendShapeIndexMap["MouthUpperUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "mouthUpperUpRight");
        m_FaceArkitBlendShapeIndexMap["NoseSneerLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "noseSneerLeft");
        m_FaceArkitBlendShapeIndexMap["NoseSneerRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "noseSneerRight");
        m_FaceArkitBlendShapeIndexMap["TongueOut"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(strPrefix + "tongueOut");
    }
}
