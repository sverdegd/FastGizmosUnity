//FastGizmos Tool by SVerde
//contact@sverdegd.com
//https://github.com/sverdegd

using UnityEngine;
using UnityEditor;

namespace SVerdeTools.FastGizmos
{
    [CustomEditor(typeof(FastGizmos))]
    public class FastGizmosEditor : Editor
    {
        int typeIndex = 0;
        Color color;
        bool active;

        //Cube
        bool positionIsCenterCube;
        Vector3 cubeCenter;
        Vector3 cubeSize;
        //Frustrum
        bool positionIsCenterFrustum;
        Vector3 frustumCenter;
        float fov;
        float maxRange;
        float minRange;
        float aspect;
        //GUITexture
        Rect screenRect;
        Texture texture;
        Material mat;
        //Icon
        bool positionIsCenterIcon;
        Vector3 iconCenter;
        string iconName;
        bool allowScaling;
        //Line
        bool useTwoTransforms;
        Vector3 fromV;
        Vector3 toV;
        Transform fromTr;
        Transform toTr;
        //Mesh
        Mesh mesh;
        bool transformIsMeshTransform;
        Vector3 meshPosition;
        Vector3 meshRotation;
        Vector3 meshScale;
        int subMeshIndex;
        //Ray
        Vector3 fromR;
        Vector3 directionR;
        //Sphere
        bool positionIsCenterSphere = true;
        Vector3 sphereCenter;
        float radiusS;
        //WireCube
        bool positionIsCenterWireCube = true;
        Vector3 wireCubeCenter = Vector3.zero;
        Vector3 wireCubeSize = Vector3.one;
        //WireMesh
        Mesh wireMesh;
        bool transformIsWireMeshTransform = true;
        Vector3 wireMeshPosition;
        Vector3 wireMeshRotation;
        Vector3 wireMeshScale = Vector3.one;
        int subWireMeshIndex = -1;
        //Sphere
        bool positionIsCenterWireSphere = true;
        Vector3 wireSphereCenter = Vector3.zero;
        float radiusWS = 1f;
        //CameraOrthographic
        Camera cam;
        bool drawVertex = false;
        //LineExtended
        Vector3 startPointLE;
        Vector3 endPointLE;
        Transform fromTrLE;
        Transform toTrLE;
        float thickness;
        bool useTwoTransformsLE;
        //CubeExtended
        Vector3 positionCE;
        Vector3 rotationCE;
        Vector3 scaleCE;
        //WireCubeExtended
        Vector3 positionWCE = Vector3.zero;
        Vector3 rotationWCE = Vector3.zero;
        Vector3 scaleWCE = Vector3.one;

        public override void OnInspectorGUI()
        {
            FastGizmos myTarget = (FastGizmos)target;

            EditorGUILayout.Separator();
            EditorGUI.BeginChangeCheck();
            active = EditorGUILayout.ToggleLeft("Enable", myTarget.active, EditorStyles.largeLabel);
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(myTarget);
                myTarget.active = active;
            }
            EditorGUILayout.Separator();

            if (active)
            {
                EditorGUI.BeginChangeCheck();
                typeIndex = EditorGUILayout.Popup(myTarget.GetTypeIndex(), FastGizmos.Type);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(myTarget);
                    myTarget.type = FastGizmos.Type[typeIndex];
                }

                EditorGUI.BeginChangeCheck();
                color = EditorGUILayout.ColorField(myTarget.color);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(myTarget);
                    myTarget.color = color;
                }

                EditorGUILayout.BeginVertical("box");

                switch (typeIndex)
                {
                    case 0://Cube
                        #region Cube
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterCube = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterCube);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterCube = positionIsCenterCube;
                        }
                        if (!positionIsCenterCube)
                        {
                            EditorGUI.BeginChangeCheck();
                            cubeCenter = EditorGUILayout.Vector3Field("Center", myTarget.cubeCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.cubeCenter = cubeCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        cubeSize = EditorGUILayout.Vector3Field("Size", myTarget.cubeSize);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.cubeSize = cubeSize;
                        }
                        #endregion
                        break;
                    case 1://Frustrum
                        #region Frustrum
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterFrustum = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterFrustum);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterFrustum = positionIsCenterFrustum;
                        }
                        if (!positionIsCenterFrustum)
                        {
                            EditorGUI.BeginChangeCheck();
                            frustumCenter = EditorGUILayout.Vector3Field("Center", myTarget.frustumCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.frustumCenter = frustumCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        fov = EditorGUILayout.FloatField("Fov", myTarget.fov);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.fov = fov;
                        }
                        EditorGUI.BeginChangeCheck();
                        minRange = EditorGUILayout.FloatField("Min Range", myTarget.minRange);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.minRange = minRange;
                        }
                        EditorGUI.BeginChangeCheck();
                        maxRange = EditorGUILayout.FloatField("Max Range", myTarget.maxRange);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.maxRange = maxRange;
                        }
                        EditorGUI.BeginChangeCheck();
                        aspect = EditorGUILayout.FloatField("Aspect", myTarget.aspect);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.aspect = aspect;
                        }
                        #endregion
                        break;
                    case 2://GUITexture
                        #region GUITexture
                        EditorGUI.BeginChangeCheck();
                        screenRect = EditorGUILayout.RectField("Screen Rect", myTarget.screenRect);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.screenRect = screenRect;
                        }
                        EditorGUI.BeginChangeCheck();
                        texture = (Texture)EditorGUILayout.ObjectField("Texture", myTarget.texture, typeof(Texture), false);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.texture = texture;
                        }
                        EditorGUI.BeginChangeCheck();
                        mat = (Material)EditorGUILayout.ObjectField("Material", myTarget.mat, typeof(Material), false);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.mat = mat;
                        }
                        #endregion
                        break;
                    case 3://Icon
                        #region Icon
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterIcon = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterIcon);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterIcon = positionIsCenterIcon;
                        }
                        if (!positionIsCenterIcon)
                        {
                            EditorGUI.BeginChangeCheck();
                            iconCenter = EditorGUILayout.Vector3Field("Center", myTarget.iconCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.iconCenter = iconCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        iconName = EditorGUILayout.TextField("Icon name", myTarget.iconName);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.iconName = iconName;
                        }
                        EditorGUI.BeginChangeCheck();
                        allowScaling = EditorGUILayout.ToggleLeft("Allow scaling", myTarget.allowScaling);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.allowScaling = allowScaling;
                        }
                        #endregion
                        break;
                    case 4://Line
                        #region Line
                        EditorGUI.BeginChangeCheck();
                        useTwoTransforms = EditorGUILayout.ToggleLeft("Use two transforms", myTarget.useTwoTransforms);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.useTwoTransforms = useTwoTransforms;
                        }
                        if (!useTwoTransforms)
                        {
                            EditorGUI.BeginChangeCheck();
                            fromV = EditorGUILayout.Vector3Field("From", myTarget.fromV);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.fromV = fromV;
                            }
                            EditorGUI.BeginChangeCheck();
                            toV = EditorGUILayout.Vector3Field("To", myTarget.toV);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.toV = toV;
                            }
                        }
                        else
                        {
                            EditorGUI.BeginChangeCheck();
                            fromTr = EditorGUILayout.ObjectField("From", myTarget.fromTr, typeof(Transform), true) as Transform;
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.fromTr = fromTr;
                            }
                            EditorGUI.BeginChangeCheck();
                            toTr = EditorGUILayout.ObjectField("To", myTarget.toTr, typeof(Transform), true) as Transform;
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.toTr = toTr;
                            }
                        }
                        #endregion
                        break;
                    case 5://Mesh
                        #region Mesh
                        EditorGUI.BeginChangeCheck();
                        mesh = EditorGUILayout.ObjectField("Mesh", myTarget.mesh, typeof(Mesh), true) as Mesh;
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.mesh = mesh;
                        }
                        EditorGUI.BeginChangeCheck();
                        transformIsMeshTransform = EditorGUILayout.ToggleLeft("Transform is Mesh Transform", myTarget.transformIsMeshTransform);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.transformIsMeshTransform = transformIsMeshTransform;
                        }
                        if (!transformIsMeshTransform)
                        {
                            EditorGUI.BeginChangeCheck();
                            meshPosition = EditorGUILayout.Vector3Field("Position", myTarget.meshPosition);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.meshPosition = meshPosition;
                            }
                            EditorGUI.BeginChangeCheck();
                            meshRotation = EditorGUILayout.Vector3Field("Rotation", myTarget.meshRotation);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.meshRotation = meshRotation;
                            }
                            EditorGUI.BeginChangeCheck();
                            meshScale = EditorGUILayout.Vector3Field("Scale", myTarget.meshScale);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.meshScale = meshScale;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        subMeshIndex = EditorGUILayout.IntField("Sub Mesh index", myTarget.subMeshIndex);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.subMeshIndex = subMeshIndex;
                        }
                        #endregion
                        break;
                    case 6://Ray
                        #region Ray
                        EditorGUI.BeginChangeCheck();
                        fromR = EditorGUILayout.Vector3Field("From", myTarget.fromR);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.fromR = fromR;
                        }
                        EditorGUI.BeginChangeCheck();
                        directionR = EditorGUILayout.Vector3Field("Direction", myTarget.directionR);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.directionR = directionR;
                        }
                        #endregion
                        break;
                    case 7://Sphere
                        #region Sphere
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterSphere = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterSphere);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterSphere = positionIsCenterSphere;
                        }
                        if (!positionIsCenterSphere)
                        {
                            EditorGUI.BeginChangeCheck();
                            sphereCenter = EditorGUILayout.Vector3Field("Center", myTarget.sphereCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.sphereCenter = sphereCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        radiusS = EditorGUILayout.FloatField("Radius", myTarget.radiusS);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.radiusS = radiusS;
                        }
                        #endregion
                        break;
                    case 8://WireCube
                        #region Cube
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterWireCube = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterWireCube);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterWireCube = positionIsCenterWireCube;
                        }
                        if (!positionIsCenterWireCube)
                        {
                            EditorGUI.BeginChangeCheck();
                            wireCubeCenter = EditorGUILayout.Vector3Field("Center", myTarget.wireCubeCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.wireCubeCenter = wireCubeCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        wireCubeSize = EditorGUILayout.Vector3Field("Size", myTarget.wireCubeSize);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.wireCubeSize = wireCubeSize;
                        }
                        #endregion
                        break;
                    case 9://WireMesh
                        #region WireMesh
                        EditorGUI.BeginChangeCheck();
                        wireMesh = EditorGUILayout.ObjectField("Mesh", myTarget.wireMesh, typeof(Mesh), true) as Mesh;
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.wireMesh = wireMesh;
                        }
                        EditorGUI.BeginChangeCheck();
                        transformIsWireMeshTransform = EditorGUILayout.ToggleLeft("Transform is Mesh Transform", myTarget.transformIsWireMeshTransform);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.transformIsWireMeshTransform = transformIsWireMeshTransform;
                        }
                        if (!transformIsWireMeshTransform)
                        {
                            EditorGUI.BeginChangeCheck();
                            wireMeshPosition = EditorGUILayout.Vector3Field("Position", myTarget.wireMeshPosition);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.wireMeshPosition = wireMeshPosition;
                            }
                            EditorGUI.BeginChangeCheck();
                            wireMeshRotation = EditorGUILayout.Vector3Field("Rotation", myTarget.wireMeshRotation);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.wireMeshRotation = wireMeshRotation;
                            }
                            EditorGUI.BeginChangeCheck();
                            wireMeshScale = EditorGUILayout.Vector3Field("Scale", myTarget.wireMeshScale);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.wireMeshScale = wireMeshScale;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        subWireMeshIndex = EditorGUILayout.IntField("Sub Mesh index", myTarget.subWireMeshIndex);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.subWireMeshIndex = subWireMeshIndex;
                        }
                        #endregion
                        break;
                    case 10://WireSphere
                        #region WireSphere
                        EditorGUI.BeginChangeCheck();
                        positionIsCenterWireSphere = EditorGUILayout.ToggleLeft("Position is the center", myTarget.positionIsCenterWireSphere);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionIsCenterWireSphere = positionIsCenterWireSphere;
                        }
                        if (!positionIsCenterWireSphere)
                        {
                            EditorGUI.BeginChangeCheck();
                            wireSphereCenter = EditorGUILayout.Vector3Field("Center", myTarget.wireSphereCenter);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.wireSphereCenter = wireSphereCenter;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        radiusWS = EditorGUILayout.FloatField("Radius", myTarget.radiusWS);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.radiusWS = radiusWS;
                        }
                        #endregion
                        break;
                    case 11://CameraOrthographic
                        #region CameraOrthographic
                        EditorGUI.BeginChangeCheck();
                        cam = EditorGUILayout.ObjectField("Camera", myTarget.cam, typeof(Camera), true) as Camera;
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.cam = cam;
                        }
                        EditorGUI.BeginChangeCheck();
                        drawVertex = EditorGUILayout.ToggleLeft("Draw Vertex", myTarget.drawVertex);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.drawVertex = drawVertex;
                        }
                        #endregion
                        break;
                    case 12://LineExtended
                        #region LineExtended
                        EditorGUI.BeginChangeCheck();
                        useTwoTransformsLE = EditorGUILayout.ToggleLeft("Use two transforms", myTarget.useTwoTransformsLE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.useTwoTransformsLE = useTwoTransformsLE;
                        }
                        if (!useTwoTransformsLE)
                        {
                            EditorGUI.BeginChangeCheck();
                            startPointLE = EditorGUILayout.Vector3Field("From", myTarget.startPointLE);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.startPointLE = startPointLE;
                            }
                            EditorGUI.BeginChangeCheck();
                            endPointLE = EditorGUILayout.Vector3Field("To", myTarget.endPointLE);
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.endPointLE = endPointLE;
                            }
                        }
                        else
                        {
                            EditorGUI.BeginChangeCheck();
                            fromTrLE = EditorGUILayout.ObjectField("From", myTarget.fromTrLE, typeof(Transform), true) as Transform;
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.fromTrLE = fromTrLE;
                            }
                            EditorGUI.BeginChangeCheck();
                            toTrLE = EditorGUILayout.ObjectField("To", myTarget.toTrLE, typeof(Transform), true) as Transform;
                            if (EditorGUI.EndChangeCheck())
                            {
                                EditorUtility.SetDirty(myTarget);
                                myTarget.toTrLE = toTrLE;
                            }
                        }
                        EditorGUI.BeginChangeCheck();
                        thickness = EditorGUILayout.FloatField("Thickness", myTarget.thickness);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.thickness = thickness;
                        }
                        #endregion
                        break;
                    case 13://CubeExtended
                        #region CubeExtended
                        EditorGUI.BeginChangeCheck();
                        positionCE = EditorGUILayout.Vector3Field("Position", myTarget.positionCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionCE = positionCE;
                        }
                        EditorGUI.BeginChangeCheck();
                        rotationCE = EditorGUILayout.Vector3Field("Rotation", myTarget.rotationCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.rotationCE = rotationCE;
                        }
                        EditorGUI.BeginChangeCheck();
                        scaleCE = EditorGUILayout.Vector3Field("Scale", myTarget.scaleCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.scaleCE = scaleCE;
                        }
                        #endregion
                        break;
                    case 14://WireCubeExtended
                        #region WireCubeExtended
                        EditorGUI.BeginChangeCheck();
                        positionWCE = EditorGUILayout.Vector3Field("Position", myTarget.positionWCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.positionWCE = positionWCE;
                        }
                        EditorGUI.BeginChangeCheck();
                        rotationWCE = EditorGUILayout.Vector3Field("Rotation", myTarget.rotationWCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.rotationWCE = rotationWCE;
                        }
                        EditorGUI.BeginChangeCheck();
                        scaleWCE = EditorGUILayout.Vector3Field("Scale", myTarget.scaleWCE);
                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(myTarget);
                            myTarget.scaleWCE = scaleWCE;
                        }
                        #endregion
                        break;
                }

                EditorGUILayout.EndVertical();

            }
            else
            {
                EditorGUILayout.HelpBox("FastGizmos is disabled", MessageType.Info, true);
            }
        }
    }
}
