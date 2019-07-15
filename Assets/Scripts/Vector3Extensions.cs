using UnityEngine;

public static class Vector3Extensions {

	public static Vector2 xz(this Vector3 v) {
		return new Vector2(v.x, v.z);
	}

	public static Vector3 flatY(this Vector3 v) {
		return new Vector3(v.x, 0 , v.z);
	}

	public static Vector3 expandTo3D(this Vector2 v) {
		return new Vector3(v.x, 0 , v.y);
	}
}
