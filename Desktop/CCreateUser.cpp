// CCreateUser.cpp : implementation file
//

#include "pch.h"
#include "Travel.h"
#include "afxdialogex.h"
#include "CCreateUser.h"


// CCreateUser dialog

IMPLEMENT_DYNAMIC(CCreateUser, CDialog)

CCreateUser::CCreateUser(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_CCreateUser, pParent)
	, m_surname_name(_T(""))
	, m_name(_T(""))
	, m_patronymic(_T(""))
	, m_login(_T(""))
	, m_password(_T(""))
{

}

CCreateUser::~CCreateUser()
{
}

void CCreateUser::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT5, m_surname_name);
	DDX_Text(pDX, IDC_EDIT_NAME, m_name);
	DDX_Text(pDX, IDC_EDIT_PATRONYMIC, m_patronymic);
	DDX_Text(pDX, IDC_EDIT_LOGIN, m_login);
	DDX_Text(pDX, IDC_EDIT_PASSWORD, m_password);
	DDX_Control(pDX, IDC_BUTTON_SEND_REGISTER, m_send_btn);
}


BEGIN_MESSAGE_MAP(CCreateUser, CDialog)
	ON_BN_CLICKED(IDC_BUTTON_SEND_REGISTER, &CCreateUser::OnBnClickedButtonSendRegister)
END_MESSAGE_MAP()


// CCreateUser message handlers

void CCreateUser::OnBnClickedButtonSendRegister()
{
	//if (m_surname_name.GetLength() <= 4 || )
	// TODO: Add your control notification handler code here
}

