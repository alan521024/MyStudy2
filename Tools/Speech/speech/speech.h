#pragma once

typedef  int(*startFun)(int, char*);

extern "C" _declspec(dllexport) int __stdcall startupTask(char* login_params, char* session_begin_params, startFun startCall);