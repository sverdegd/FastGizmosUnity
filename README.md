# FastGizmosUnity
## FastGizmos Example
![Example](https://github.com/sverdegd/FastGizmosUnity/blob/master/ReadmeImages/FastGizmosExample.gif)
## FastGizmos HandleText Example
![Example](https://github.com/sverdegd/FastGizmosUnity/blob/master/ReadmeImages/FastGizmoHandleTextExample.gif)
## FastGizmos Extras
Add the next using directive:

`using SVerdeTools.FastGizmos;`

* To draw ExtendedLine:

`FastGizmosExtra.DrawLineExtended(Vector3 startPoint, Vector3 endPoint, float thickness);`

* To draw CubeExtended:

`FastGizmosExtra.DrawCubeExtended(Vector3 position, Quaternion rotation, Vector3 scale);`

* To draw WireCubeExtended:

`FastGizmosExtra.DrawWireCubeExtended(Vector3 position, Quaternion rotation, Vector3 scale);`

* To draw CameraOrthographic you can use this options:

`FastGizmosExtra.DrawCameraOrthographic(Camera camera);`

`FastGizmosExtra.DrawCameraOrthographic(Camera camera, Color gizmoColor);`

`FastGizmosExtra.DrawCameraOrthographic(Camera camera, Color gizmoColor, bool showVertex);`

