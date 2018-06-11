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

enum {
	EVT_START = 0,
	EVT_STOP,
	EVT_QUIT,
	EVT_TOTAL
};
static HANDLE events[EVT_TOTAL] = { NULL,NULL,NULL };

static COORD begin_pos = { 0, 0 };
static COORD last_pos = { 0, 0 };


int __stdcall start(char* parm) {

	int			ret = MSP_SUCCESS;
	int			upload_on = 1; //是否上传用户词表
	const char* login_params = "appid = 5b0dfbb4, work_dir = ."; // 登录参数，appid与msc库绑定,请勿随意改动
	int aud_src = 0;

	/*
	* sub:				请求业务类型
	* domain:			领域
	* language:			语言
	* accent:			方言
	* sample_rate:		音频采样率
	* result_type:		识别结果格式
	* result_encoding:	结果编码格式
	*
	*/
	const char* session_begin_params = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = gb2312";

	/* 用户登录 */
	ret = MSPLogin(NULL, NULL, login_params); //第一个参数是用户名，第二个参数是密码，均传NULL即可，第三个参数是登录参数	
	if (MSP_SUCCESS != ret) {
		return ret;
	}
	return 1111;
}

