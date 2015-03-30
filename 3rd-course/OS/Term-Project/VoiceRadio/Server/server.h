#define IDC_EDT_MSG			100
#define IDC_EDT_CHAT		101
#define IDC_BTN_START		102
#define IDC_BTN_STOP		103
#define IDC_USRLABEL		104
#define IDC_LST_USERS		105

#define IDM_MASK			150
#define IDM_PORT			151
#define IDM_PLAY			152
#define IDM_EXIT			153

#define IDI_FAVICON			180

typedef struct USRDATA
{
	in_addr addr;
} *LPUSRDATA;

int MainWndTop, MainWndLeft, MainWndWidth, MainWndHeight, EdtMsgHeight, LstUsersWidth, BtnHeight;