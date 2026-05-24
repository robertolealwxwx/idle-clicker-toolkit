```csharp
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class ProcessMemory
{
    private Process _process;
    private IntPtr _processHandle;

    public bool AttachToProcess(string processName)
    {
        _process = Process.GetProcessesByName(processName)[0];
        if (_process == null) return false;

        _processHandle = OpenProcess(ProcessAccessFlags.All, false, _process.Id);
        return _processHandle != IntPtr.Zero;
    }

    public void Detach()
    {
        if (_processHandle != IntPtr.Zero)
        {
            CloseHandle(_processHandle);
            _processHandle = IntPtr.Zero;
        }
    }

    public float ReadFloat(IntPtr address)
    {
        float value = 0;
        ReadProcessMemory(_processHandle, address, ref value, sizeof(float), out _);
        return value;
    }

    public void WriteFloat(IntPtr address, float value)
    {
        WriteProcessMemory(_processHandle, address, ref value, sizeof(float), out _);
    }

    public int ReadInt(IntPtr address)
    {
        int value = 0;
        ReadProcessMemory(_processHandle, address, ref value, sizeof(int), out _);
        return value;
    }

    public void WriteInt(IntPtr address, int value)
    {
        WriteProcessMemory(_processHandle, address, ref value, sizeof(int), out _);
    }

    public bool IsGameRunning(string processName)
    {
        return Process.GetProcessesByName(processName).Length > 0;
    }

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

    [DllImport("kernel32.dll")]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref float lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref int lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref float lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref int lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    private static extern bool CloseHandle(IntPtr hObject);
}

public static class TrainerCore
{
    private static ProcessMemory _processMemory = new ProcessMemory();
    private const string ProcessName = "CookieClicker";

    // Static addresses for