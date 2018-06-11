// speech.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "msp_cmn.h"
#include "msp_errors.h"
#include "recognizer.h"
#include "speech.h"

#ifdef _WIN64 
#pragma comment(lib,"../library/msc_x64.lib")
#else 
#pragma comment(lib, "../library/msc.lib")
#endif 

#define FRAME_LEN	640 
#define	BUFFER_SIZE	4096

/*
const char* login_params = "appid = 5b0dfbb4, work_dir = ."; // 登录参数，appid与msc库绑定,请勿随意改动
*/

/*
* sub:				请求业务类型
* domain:			领域
* language:			语言
* accent:			方言
* sample_rate:		音频采样率
* result_type:		识别结果格式
* result_encoding:	结果编码格式
*
//const char* session_begin_params = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = gb2312";
*/

enum {
	EVT_START = 0,
	EVT_STOP,
	EVT_QUIT,
	EVT_TOTAL
};

static int ERRORCODE = -1;

static HANDLE events[EVT_TOTAL] = { NULL,NULL,NULL };

static COORD begin_pos = { 0, 0 };
static COORD last_pos = { 0, 0 };


int __stdcall startupTask(char* login_params, char* session_begin_params, int(*startCallback)(int, char*), int(*errorCallback)(int, char*)) {

	int ret = MSP_SUCCESS;

	/* 用户登录 */
	ret = MSPLogin(NULL, NULL, login_params);
	if (MSP_SUCCESS != ret) {
		errorCallback(ret, "MSPLogin failed");
		goto exit;
	}


exit:
	MSPLogout();

	return ret;
}