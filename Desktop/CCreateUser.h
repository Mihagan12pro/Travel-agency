#pragma once
#include "afxdialogex.h"


// CCreateUser dialog

class CCreateUser : public CDialog
{
	DECLARE_DYNAMIC(CCreateUser)

public:
	CCreateUser(CWnd* pParent = nullptr);   // standard constructor
	virtual ~CCreateUser();

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CCreateUser };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CString m_surname_name;
	afx_msg void OnBnClickedButtonSendRegister();
	CString m_name;
	CString m_patronymic;
	CString m_login;
	CString m_password;
	CButton m_send_btn;
};
