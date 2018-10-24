//FastGizmos Tool by SVerde
//contact@sverdegd.com
//https://github.com/sverdegd

using UnityEngine;

namespace SVerdeTools.FastGizmos {

    public class FastGizmosExtra{

        public static void DrawLineExtended(Vector3 startPoint, Vector3 endPoint, float thickness)
        {
            Vector3 position = (startPoint + endPoint) / 2;
            Quaternion rotation = Quaternion.LookRotation(endPoint - startPoint, Vector3.forward);

            DrawCubeExtended(position, rotation, Vector3.forward * Vector3.Distance(startPoint, endPoint) + Vector3.one * thickness);
        }

        public static void DrawCubeExtended(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Matrix4x4 cubeTransform = Matrix4x4.TRS(position, rotation, scale);
            Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

            Gizmos.matrix *= cubeTransform;

            Gizmos.DrawCube(Vector3.zero, Vector3.one);

            Gizmos.matrix = oldGizmosMatrix;
        }

        public static void DrawWireCubeExtended(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Matrix4x4 cubeTransform = Matrix4x4.TRS(position, rotation, scale);
            Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

            Gizmos.matrix *= cubeTransform;

            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            Gizmos.matrix = oldGizmosMatrix;
        }

        #region DrawCameraOrthographic
        public static void DrawCameraOrthographic(Camera camera)
        {
            DrawCameraOrthographic(camera, Color.red, false);
        }

        public static void DrawCameraOrthographic(Camera camera, Color gizmoColor)
        {
            DrawCameraOrthographic(camera, gizmoColor, false);
        }

        public static void DrawCameraOrthographic(Camera camera, Color gizmoColor, bool showVertex)
        {
            if (camera == null)
                return;

            Vector3 x0y0 = new Vector3(camera.aspect * -camera.orthographicSize + camera.transform.position.x, camera.orthographicSize + camera.transform.position.y);
            Vector3 x1y0 = new Vector3(camera.aspect * camera.orthographicSize + camera.transform.position.x, camera.orthographicSize + camera.transform.position.y);
            Vector3 x0y1 = new Vector3(camera.aspect * camera.orthographicSize + camera.transform.position.x, -camera.orthographicSize + camera.transform.position.y);
            Vector3 x1y1 = new Vector3(camera.aspect * -camera.orthographicSize + camera.transform.position.x, -camera.orthographicSize + camera.transform.position.y);

            Gizmos.color = gizmoColor;

            Gizmos.DrawLine(x0y0, x1y0);
            Gizmos.DrawLine(x1y0, x0y1);
            Gizmos.DrawLine(x1y1, x0y1);
            Gizmos.DrawLine(x0y0, x1y1);

            if (showVertex)
            {
                Gizmos.DrawSphere(x0y0, 0.1f);
                Gizmos.DrawSphere(x1y0, 0.1f);
                Gizmos.DrawSphere(x0y1, 0.1f);
                Gizmos.DrawSphere(x1y1, 0.1f);
            }

            Gizmos.color = Color.white;
        }
        #endregion
    }
}
