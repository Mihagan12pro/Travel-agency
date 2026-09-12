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

// TravelDoc.cpp: ðåàëèçàöèÿ êëàññà CTravelDoc 
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS ìîæíî îïðåäåëèòü â îáðàáîò÷èêàõ ôèëüòðîâ ïðîñìîòðà ðåàëèçàöèè ïðîåêòà ATL, ýñêèçîâ
// è ïîèñêà; ïîçâîëÿåò ñîâìåñòíî èñïîëüçîâàòü êîä äîêóìåíòà â äàííûì ïðîåêòå.
#ifndef SHARED_HANDLERS
#include "Travel.h"
#endif

#include "TravelDoc.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CTravelDoc

IMPLEMENT_DYNCREATE(CTravelDoc, CDocument)

BEGIN_MESSAGE_MAP(CTravelDoc, CDocument)
END_MESSAGE_MAP()


// Ñîçäàíèå èëè óíè÷òîæåíèå CTravelDoc

CTravelDoc::CTravelDoc() noexcept
{
	// TODO: äîáàâüòå êîä äëÿ îäíîðàçîâîãî âûçîâà êîíñòðóêòîðà

}

CTravelDoc::~CTravelDoc()
{
}

BOOL CTravelDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: äîáàâüòå êîä ïîâòîðíîé èíèöèàëèçàöèè
	// (Äîêóìåíòû SDI áóäóò ïîâòîðíî èñïîëüçîâàòü ýòîò äîêóìåíò)

	return TRUE;
}




// Ñåðèàëèçàöèÿ CTravelDoc

void CTravelDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: äîáàâüòå êîä ñîõðàíåíèÿ
	}
	else
	{
		// TODO: äîáàâüòå êîä çàãðóçêè
	}
}

#ifdef SHARED_HANDLERS

// Ïîääåðæêà äëÿ ýñêèçîâ
void CTravelDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
{
	// Èçìåíèòå ýòîò êîä äëÿ îòîáðàæåíèÿ äàííûõ äîêóìåíòà
	dc.FillSolidRect(lprcBounds, RGB(255, 255, 255));

	CString strText = _T("TODO: implement thumbnail drawing here");
	LOGFONT lf;

	CFont* pDefaultGUIFont = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	pDefaultGUIFont->GetLogFont(&lf);
	lf.lfHeight = 36;

	CFont fontDraw;
	fontDraw.CreateFontIndirect(&lf);

	CFont* pOldFont = dc.SelectObject(&fontDraw);
	dc.DrawText(strText, lprcBounds, DT_CENTER | DT_WORDBREAK);
	dc.SelectObject(pOldFont);
}

// Ïîääåðæêà îáðàáîò÷èêîâ ïîèñêà
void CTravelDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// Çàäàíèå ñîäåðæèìîãî ïîèñêà èç äàííûõ äîêóìåíòà.
	// ×àñòè ñîäåðæèìîãî äîëæíû ðàçäåëÿòüñÿ òî÷êîé ñ çàïÿòîé ";"

	// Íàïðèìåð:  strSearchContent = _T("òî÷êà;ïðÿìîóãîëüíèê;êðóã;îáúåêò ole;");
	SetSearchContent(strSearchContent);
}

void CTravelDoc::SetSearchContent(const CString& value)
{
	if (value.IsEmpty())
	{
		RemoveChunk(PKEY_Search_Contents.fmtid, PKEY_Search_Contents.pid);
	}
	else
	{
		CMFCFilterChunkValueImpl *pChunk = nullptr;
		ATLTRY(pChunk = new CMFCFilterChunkValueImpl);
		if (pChunk != nullptr)
		{
			pChunk->SetTextValue(PKEY_Search_Contents, value, CHUNK_TEXT);
			SetChunkValue(pChunk);
		}
	}
}

#endif // SHARED_HANDLERS

// Äèàãíîñòèêà CTravelDoc

#ifdef _DEBUG
void CTravelDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTravelDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// Êîìàíäû CTravelDoc
