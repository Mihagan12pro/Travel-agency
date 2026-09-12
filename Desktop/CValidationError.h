#pragma once
#include "afxdialogex.h"


// CValidationError dialog

class CValidationError : public CDialog
{
	DECLARE_DYNAMIC(CValidationError)

public:
	CValidationError(CWnd* pParent = nullptr);   // standard constructor
	virtual ~CValidationError();

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CValidationError };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CString errors;
};
