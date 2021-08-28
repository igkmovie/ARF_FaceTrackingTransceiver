using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OscServer : MonoBehaviour
{
    public GameObject faceObj;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    Dictionary<string, int> m_FaceArkitBlendShapeIndexMap;

    // Start is called before the first frame update
    public void OnMessage(string value)
    {
        var blendshapeModels = JsonUtility.FromJson<BlendshapeModels>(value);
        var blendshapes = blendshapeModels.shapes;
        blendshapes
            .Where(x => m_FaceArkitBlendShapeIndexMap.TryGetValue(x.Location, out int mappedBlendShapeIndex))
            .Where(x => m_FaceArkitBlendShapeIndexMap[x.Location] >= 0)
            .Select(x =>
            {
                var val = m_FaceArkitBlendShapeIndexMap[x.Location];
                skinnedMeshRenderer.SetBlendShapeWeight(val, x.coefficient * 100);
                return x;
            }).ToList();

    }
    void CreateFeatureBlendMapping()
    {
        if (skinnedMeshRenderer == null || skinnedMeshRenderer.sharedMesh == null)
        {
            return;
        }
        m_FaceArkitBlendShapeIndexMap = new Dictionary<string, int>();
        m_FaceArkitBlendShapeIndexMap["BrowDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "browDown_L");
        m_FaceArkitBlendShapeIndexMap["BrowDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "browDown_R");
        m_FaceArkitBlendShapeIndexMap["BrowInnerUp"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "browInnerUp");
        m_FaceArkitBlendShapeIndexMap["BrowOuterUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "browOuterUp_L");
        m_FaceArkitBlendShapeIndexMap["BrowOuterUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "browOuterUp_R");
        m_FaceArkitBlendShapeIndexMap["CheekPuff"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "cheekPuff");
        m_FaceArkitBlendShapeIndexMap["CheekSquintLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "cheekSquint_L");
        m_FaceArkitBlendShapeIndexMap["CheekSquintRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "cheekSquint_R");
        m_FaceArkitBlendShapeIndexMap["EyeBlinkLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeBlink_L");
        m_FaceArkitBlendShapeIndexMap["EyeBlinkRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeBlink_R");
        m_FaceArkitBlendShapeIndexMap["EyeLookDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookDown_L");
        m_FaceArkitBlendShapeIndexMap["EyeLookDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookDown_R");
        m_FaceArkitBlendShapeIndexMap["EyeLookInLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookIn_L");
        m_FaceArkitBlendShapeIndexMap["EyeLookInRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookIn_R");
        m_FaceArkitBlendShapeIndexMap["EyeLookOutLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookOut_L");
        m_FaceArkitBlendShapeIndexMap["EyeLookOutRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookOut_R");
        m_FaceArkitBlendShapeIndexMap["EyeLookUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookUp_L");
        m_FaceArkitBlendShapeIndexMap["EyeLookUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeLookUp_R");
        m_FaceArkitBlendShapeIndexMap["EyeSquintLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeSquint_L");
        m_FaceArkitBlendShapeIndexMap["EyeSquintRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeSquint_R");
        m_FaceArkitBlendShapeIndexMap["EyeWideLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeWide_L");
        m_FaceArkitBlendShapeIndexMap["EyeWideRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "eyeWide_R");
        m_FaceArkitBlendShapeIndexMap["JawForward"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "jawForward");
        m_FaceArkitBlendShapeIndexMap["JawLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "jawLeft");
        m_FaceArkitBlendShapeIndexMap["JawOpen"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "jawOpen");
        m_FaceArkitBlendShapeIndexMap["JawRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "jawRight");
        m_FaceArkitBlendShapeIndexMap["MouthClose"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthClose");
        m_FaceArkitBlendShapeIndexMap["MouthDimpleLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthDimple_L");
        m_FaceArkitBlendShapeIndexMap["MouthDimpleRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthDimple_R");
        m_FaceArkitBlendShapeIndexMap["MouthFrownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthFrown_L");
        m_FaceArkitBlendShapeIndexMap["MouthFrownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthFrown_R");
        m_FaceArkitBlendShapeIndexMap["MouthFunnel"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthFunnel");
        m_FaceArkitBlendShapeIndexMap["MouthLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthLeft");
        m_FaceArkitBlendShapeIndexMap["MouthLowerDownLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthLowerDown_L");
        m_FaceArkitBlendShapeIndexMap["MouthLowerDownRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthLowerDown_R");
        m_FaceArkitBlendShapeIndexMap["MouthPressLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthPress_L");
        m_FaceArkitBlendShapeIndexMap["MouthPressRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthPress_R");
        m_FaceArkitBlendShapeIndexMap["MouthPucker"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthPucker");
        m_FaceArkitBlendShapeIndexMap["MouthRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthRight");
        m_FaceArkitBlendShapeIndexMap["MouthRollLower"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthRollLower");
        m_FaceArkitBlendShapeIndexMap["MouthRollUpper"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthRollUpper");
        m_FaceArkitBlendShapeIndexMap["MouthShrugLower"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthShrugLower");
        m_FaceArkitBlendShapeIndexMap["MouthShrugUpper"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthShrugUpper");
        m_FaceArkitBlendShapeIndexMap["MouthSmileLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthSmile_L");
        m_FaceArkitBlendShapeIndexMap["MouthSmileRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthSmile_R");
        m_FaceArkitBlendShapeIndexMap["MouthStretchLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthStretch_L");
        m_FaceArkitBlendShapeIndexMap["MouthStretchRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthStretch_R");
        m_FaceArkitBlendShapeIndexMap["MouthUpperUpLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthUpperUp_L");
        m_FaceArkitBlendShapeIndexMap["MouthUpperUpRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "mouthUpperUp_R");
        m_FaceArkitBlendShapeIndexMap["NoseSneerLeft"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "noseSneer_L");
        m_FaceArkitBlendShapeIndexMap["NoseSneerRight"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "noseSneer_R");
        m_FaceArkitBlendShapeIndexMap["TongueOut"] = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("" + "tongueOut");
    }
}
