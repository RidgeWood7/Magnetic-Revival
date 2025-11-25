using UnityEngine;

public static class globalHelper
{
    public static string GenarateUniqueID(GameObject obj)
    {
        return $"{obj.scene.name}_{obj.transform.position.x}_{obj.transform.position.y}";
    }
}
