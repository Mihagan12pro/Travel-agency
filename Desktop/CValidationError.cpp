// CValidationError.cpp : implementation file
//

#include "pch.h"
#include "Travel.h"
#include "afxdialogex.h"
#include "CValidationError.h"


// CValidationError dialog

IMPLEMENT_DYNAMIC(CValidationError, CDialog)

CValidationError::CValidationError(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_CValidationError, pParent)
	, errors(_T(""))
{

}

CValidationError::~CValidationError()
{
}

void CValidationError::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT_ERRORS, errors);
}


BEGIN_MESSAGE_MAP(CValidationError, CDialog)
END_MESSAGE_MAP()


// CValidationError message handlers
