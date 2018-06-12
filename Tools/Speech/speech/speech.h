#pragma once

typedef int(*startFun)();
typedef int(*stopFun)(int);
typedef int(*resultFun)(char*, char);
typedef int(*errorFun)(int, char*);

extern "C" _declspec(dllexport) int __stdcall startupTask(char* login_params,
	char* session_begin_params,
	startFun startCall,
	stopFun stopCall,
	resultFun resultCall,
	errorFun errorCall);