using System;
using UnityEngine;

public class LearnGizmos : MonoBehaviour
{
    public Texture gizmosTexture;
    public Mesh mesh;

    // 始终绘制Gizmos
    private void OnDrawGizmos()
    {
    }

    // 选择才绘制Gizmos
    private void OnDrawGizmosSelected()
    {
        // 颜色
        Gizmos.color = Color.red;

        // 绘制矩阵
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one * 2); // 设置矩阵 Matrix4x4.TRS(位置, 角度, 缩放);
        Gizmos.matrix = Matrix4x4.identity; // 恢复默认矩阵

        // 立方体
        Gizmos.DrawCube(transform.position, Vector3.one);
        Gizmos.DrawWireCube(transform.position + new Vector3(3, 0, 0), Vector3.one);

        // 视锥
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, 60f, 10, 0, 1.77f);
        Gizmos.matrix = Matrix4x4.identity;

        // 绘制图片
        Gizmos.DrawGUITexture(new Rect(transform.position.x, transform.position.y, 50, 50), gizmosTexture);

        // 绘制icon
        Gizmos.DrawIcon(transform.position, "icon.png", true);

        // 绘制线段
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 1, 0));

        // 绘制射线
        Gizmos.DrawRay(transform.position, Vector3.forward);

        // 绘制网格
        Gizmos.color = Color.green;
        Gizmos.DrawMesh(mesh, transform.position, transform.rotation, Vector3.one); // 填充
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireMesh(mesh, transform.position + new Vector3(0, 3, 0), transform.rotation, Vector3.one); // 非填充(网格)

        // 绘制球
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + new Vector3(5, 0, 0), 1); // 填充
        Gizmos.DrawWireSphere(transform.position + new Vector3(-5, 0, 0), 1); // 非填充
    }
}