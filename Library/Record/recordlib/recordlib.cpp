// recordlib.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "recordlib.h"

int __stdcall start(int a, int b) {
	return a + b;
}