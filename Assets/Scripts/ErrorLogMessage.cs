using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorLogMessage : MonoBehaviour
{
    public TextMeshProUGUI errorText; // 에러 메시지를 표시할 UI 텍스트

    void OnEnable()
    {
        // 로그 메시지 이벤트에 메서드 등록
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        // 로그 메시지 이벤트에서 메서드 해제
        Application.logMessageReceived -= HandleLog;
    }

    // 로그 메시지를 처리하는 메서드
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            errorText.text = logString + "\n" + stackTrace;
        }
    }

    public void Test()
    {
        errorText.text = "is Working";
    }
}