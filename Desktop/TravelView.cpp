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

// TravelView.cpp: ðåàëèçàöèÿ êëàññà CTravelView
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS ìîæíî îïðåäåëèòü â îáðàáîò÷èêàõ ôèëüòðîâ ïðîñìîòðà ðåàëèçàöèè ïðîåêòà ATL, ýñêèçîâ
// è ïîèñêà; ïîçâîëÿåò ñîâìåñòíî èñïîëüçîâàòü êîä äîêóìåíòà â äàííûì ïðîåêòå.
#ifndef SHARED_HANDLERS
#include "Travel.h"
#endif

#include "TravelDoc.h"
#include "TravelView.h"
#include "CCreateUser.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTravelView

IMPLEMENT_DYNCREATE(CTravelView, CView)

BEGIN_MESSAGE_MAP(CTravelView, CView)
	// Ñòàíäàðòíûå êîìàíäû ïå÷àòè
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CTravelView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
	ON_COMMAND(ID_BUTTON_CREATE_NEW_ACCOUNT, &CTravelView::OnButtonCreateNewAccount)
END_MESSAGE_MAP()

// Ñîçäàíèå èëè óíè÷òîæåíèå CTravelView

CTravelView::CTravelView() noexcept
{
	// TODO: äîáàâüòå êîä ñîçäàíèÿ

}

CTravelView::~CTravelView()
{
}

BOOL CTravelView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: èçìåíèòü êëàññ Window èëè ñòèëè ïîñðåäñòâîì èçìåíåíèÿ
	//  CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// Ðèñîâàíèå CTravelView

void CTravelView::OnDraw(CDC* /*pDC*/)
{
	CTravelDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: äîáàâüòå çäåñü êîä îòðèñîâêè äëÿ ñîáñòâåííûõ äàííûõ
}


// Ïå÷àòü CTravelView


void CTravelView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CTravelView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// ïîäãîòîâêà ïî óìîë÷àíèþ
	return DoPreparePrinting(pInfo);
}

void CTravelView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: äîáàâüòå äîïîëíèòåëüíóþ èíèöèàëèçàöèþ ïåðåä ïå÷àòüþ
}

void CTravelView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: äîáàâüòå î÷èñòêó ïîñëå ïå÷àòè
}

void CTravelView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CTravelView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// Äèàãíîñòèêà CTravelView

#ifdef _DEBUG
void CTravelView::AssertValid() const
{
	CView::AssertValid();
}

void CTravelView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CTravelDoc* CTravelView::GetDocument() const // âñòðîåíà íåîòëàæåííàÿ âåðñèÿ
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTravelDoc)));
	return (CTravelDoc*)m_pDocument;
}
#endif //_DEBUG


// Îáðàáîò÷èêè ñîîáùåíèé CTravelView

void CTravelView::OnButtonCreateNewAccount()
{
	CCreateUser dlg;
	dlg.DoModal();
	// TODO: Add your command handler code here
}
