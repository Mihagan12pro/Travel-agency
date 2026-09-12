// Ýòîò èñõîäíûé êîä ïðèìåðîâ MFC äåìîíñòðèðóåò ôóíêöèîíèðîâàíèå ïîëüçîâàòåëüñêîãî èíòåðôåéñà Fluent íà îñíîâå MFC â Microsoft Office
// ("Fluent UI") è ïðåäîñòàâëÿåòñÿ èñêëþ÷èòåëüíî êàê ñïðàâî÷íûé ìàòåðèàë â êà÷åñòâå äîïîëíåíèÿ ê
// ñïðàâî÷íèêó ïî ïàêåòó Microsoft Foundation Classes è ñâÿçàííîé ýëåêòðîííîé äîêóìåíòàöèè,
// âêëþ÷åííîé â ïðîãðàììíîå îáåñïå÷åíèå áèáëèîòåêè MFC C++.
// Óñëîâèÿ ëèöåíçèîííîãî ñîãëàøåíèÿ íà êîïèðîâàíèå, èñïîëüçîâàíèå èëè ðàñïðîñòðàíåíèå Fluent UI äîñòóïíû îòäåëüíî.
// Äëÿ ïîëó÷åíèÿ äîïîëíèòåëüíûõ ñâåäåíèé î íàøåé ïðîãðàììå ëèöåíçèðîâàíèÿ Fluent UI ïîñåòèòå âåá-ñàéò
// https://go.microsoft.com/fwlink/?LinkId=238214.
//
// (C) Êîðïîðàöèÿ Ìàéêðîñîôò (Microsoft Corp.)
// Âñå ïðàâà çàùèùåíû.

// MainFrm.cpp: ðåàëèçàöèÿ êëàññà CMainFrame
//

#include "pch.h"
#include "framework.h"
#include "Travel.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWndEx)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWndEx)
	ON_WM_CREATE()
	ON_COMMAND(ID_FILE_PRINT, &CMainFrame::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CMainFrame::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CMainFrame::OnFilePrintPreview)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, &CMainFrame::OnUpdateFilePrintPreview)
END_MESSAGE_MAP()

// Ñîçäàíèå èëè óíè÷òîæåíèå CMainFrame

CMainFrame::CMainFrame() noexcept
{
	// TODO: äîáàâüòå êîä èíèöèàëèçàöèè ÷ëåíà
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	BOOL bNameValid;

	m_wndRibbonBar.Create(this);
	m_wndRibbonBar.LoadFromResource(IDR_RIBBON);

	if (!m_wndStatusBar.Create(this))
	{
		TRACE0("Íå óäàëîñü ñîçäàòü ñòðîêó ñîñòîÿíèÿ\n");
		return -1;      // íå óäàëîñü ñîçäàòü
	}

	CString strTitlePane1;
	CString strTitlePane2;
	bNameValid = strTitlePane1.LoadString(IDS_STATUS_PANE1);
	ASSERT(bNameValid);
	bNameValid = strTitlePane2.LoadString(IDS_STATUS_PANE2);
	ASSERT(bNameValid);
	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE1, strTitlePane1, TRUE), strTitlePane1);
	m_wndStatusBar.AddExtendedElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE2, strTitlePane2, TRUE), strTitlePane2);

	// âêëþ÷èòü ðåæèì ðàáîòû çàêðåïëÿåìûõ îêîí ñòèëåé Visual Studio 2005
	CDockingManager::SetDockingMode(DT_SMART);
	// âêëþ÷èòü ðåæèì ðàáîòû àâòîìàòè÷åñêîãî ñêðûòèÿ çàêðåïëÿåìûõ îêîí ñòèëåé Visual Studio 2005
	EnableAutoHidePanes(CBRS_ALIGN_ANY);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWndEx::PreCreateWindow(cs) )
		return FALSE;
	// TODO: èçìåíèòü êëàññ Window èëè ñòèëè ïîñðåäñòâîì èçìåíåíèÿ
	//  CREATESTRUCT cs

	return TRUE;
}

// Äèàãíîñòèêà CMainFrame

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWndEx::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWndEx::Dump(dc);
}
#endif //_DEBUG


// Îáðàáîò÷èêè ñîîáùåíèé CMainFrame


void CMainFrame::OnFilePrint()
{
	if (IsPrintPreview())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_PRINT);
	}
}

void CMainFrame::OnFilePrintPreview()
{
	if (IsPrintPreview())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);  // ïðèíóäèòåëüíîå çàêðûòèå ðåæèìà \"Ïðåäâàðèòåëüíûé ïðîñìîòð\"
	}
}

void CMainFrame::OnUpdateFilePrintPreview(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(IsPrintPreview());
}
