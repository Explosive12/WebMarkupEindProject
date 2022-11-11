#include <Windows.h>
#include <cstdio>
#include <TlHelp32.h>

DWORD GetProcessId(const char* processName)
{
	DWORD processId = 0;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

	if (hSnapshot && hSnapshot != INVALID_HANDLE_VALUE)
	{
		PROCESSENTRY32 processEntry32{};
		processEntry32.dwSize = sizeof(PROCESSENTRY32);

		if (Process32First(hSnapshot, &processEntry32))
		{
			do
			{
				if (!_stricmp(processEntry32.szExeFile, processName))
				{
					processId = processEntry32.th32ProcessID;
					break;
				}
			}
			while (Process32Next(hSnapshot, &processEntry32));
		}
	}

	return processId;
}

int main()
{
	char dllLibFullPath[256];

	auto processName = "Phasmophobia.exe";
	auto dllPath = "cheat.dll";
	DWORD processId = 0;

	while (!processId)
	{
		processId = GetProcessId(processName);
		Sleep(30);
	}

	if (!GetFullPathName(dllPath, sizeof(dllLibFullPath), dllLibFullPath, nullptr))
	{
		printf("[x] Cannot get full path to %s\n", dllPath);
		return 1;
	}

	HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, 0, processId);
	if (hProcess && hProcess != INVALID_HANDLE_VALUE)
	{
		LPVOID lpBaseAddress = VirtualAllocEx(hProcess, nullptr, MAX_PATH, MEM_COMMIT | MEM_RESERVE,
		                                      PAGE_READWRITE);

		if (lpBaseAddress)
		{
			WriteProcessMemory(hProcess, lpBaseAddress, dllLibFullPath, strlen(dllLibFullPath) + 1, nullptr);

			HANDLE hThread = CreateRemoteThread(hProcess, nullptr, 0,
			                                    reinterpret_cast<LPTHREAD_START_ROUTINE>(LoadLibraryA),
			                                    lpBaseAddress, 0, nullptr);

			if (hThread)
			{
				CloseHandle(hThread);
			}
		}
	}


	if (hProcess)
	{
		CloseHandle(hProcess);
	}

	return 0;
}
