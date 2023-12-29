using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BresenhamLineDrawer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Color lineColor = Color.white;

    private bool isDrawing = false;
    private GameObject lineObject;
    private LineRenderer lineRenderer;

    void Update()
    {
        // Khi nhấn phím L, bắt đầu hoặc kết thúc quá trình vẽ
        if (Input.GetKeyDown(KeyCode.L))
        {
            isDrawing = !isDrawing;

            // Nếu đang vẽ, thì gọi hàm bắt đầu vẽ đường thẳng
            if (isDrawing)
            {
                StartDrawing();
            }
            else
            {
                StopDrawing();
            }
        }

        // Nếu đang vẽ, cập nhật đối tượng đường thẳng
        if (isDrawing)
        {
            UpdateLine();
        }
    }

    void StartDrawing()
    {
        // Kiểm tra xem đã có đối tượng đường thẳng trước đó hay chưa
        if (lineObject != null)
        {
            StopDrawing();
        }

        lineObject = new GameObject("Line");
        
        // Thêm LineRenderer vào đối tượng mới tạo
        lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 0;
    }

    void StopDrawing()
    {
        // Kiểm tra xem đối tượng đường thẳng có tồn tại hay không
        if (lineObject != null)
        {
            // Khi kết thúc vẽ, xóa đối tượng đường thẳng
            Destroy(lineObject);
        }
    }

    void UpdateLine()
    {
        // Kiểm tra xem lineObject đã được tạo chưa
        if (lineObject == null)
        {
            return;
        }

        // Vẽ đường thẳng giữa pointA và pointB
        DrawBresenhamLine(pointA.position, pointB.position);
    }

    void DrawBresenhamLine(Vector2 point1, Vector2 point2)
    {
        int x1 = Mathf.RoundToInt(point1.x);
        int y1 = Mathf.RoundToInt(point1.y);
        int x2 = Mathf.RoundToInt(point2.x);
        int y2 = Mathf.RoundToInt(point2.y);

        int dx = Mathf.Abs(x2 - x1);
        int dy = Mathf.Abs(y2 - y1);
        int sx = (x1 < x2) ? 1 : -1;
        int sy = (y1 < y2) ? 1 : -1;
        int err = dx - dy;

        int maxLength = Mathf.Max(dx, dy); // Độ dài tối đa của đường thẳng

        // Đặt số lượng đỉnh của LineRenderer theo độ dài của đường thẳng
        lineRenderer.positionCount = maxLength + 1;

        int count = 0;
        while (true)
        {
            // Đặt vị trí của từng điểm vào LineRenderer
            lineRenderer.SetPosition(count, new Vector3(x1, y1, 0));
            count++;

            if (x1 == x2 && y1 == y2) break;
            int d = 2 * err;
            if (d > -dy)
            {
                err -= dy;
                x1 += sx;
            }
            if (d < dx)
            {
                err += dx;
                y1 += sy;
            }
        }
    }
}
