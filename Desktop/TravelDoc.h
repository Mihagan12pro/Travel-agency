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

// TravelDoc.h: èíòåðôåéñ êëàññà CTravelDoc 
//


#pragma once


class CTravelDoc : public CDocument
{
protected: // ñîçäàòü òîëüêî èç ñåðèàëèçàöèè
	CTravelDoc() noexcept;
	DECLARE_DYNCREATE(CTravelDoc)

// Àòðèáóòû
public:

// Îïåðàöèè
public:

// Ïåðåîïðåäåëåíèå
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
#ifdef SHARED_HANDLERS
	virtual void InitializeSearchContent();
	virtual void OnDrawThumbnail(CDC& dc, LPRECT lprcBounds);
#endif // SHARED_HANDLERS

// Ðåàëèçàöèÿ
public:
	virtual ~CTravelDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Ñîçäàííûå ôóíêöèè ñõåìû ñîîáùåíèé
protected:
	DECLARE_MESSAGE_MAP()

#ifdef SHARED_HANDLERS
	// Âñïîìîãàòåëüíàÿ ôóíêöèÿ, çàäàþùàÿ ñîäåðæèìîå ïîèñêà äëÿ îáðàáîò÷èêà ïîèñêà
	void SetSearchContent(const CString& value);
#endif // SHARED_HANDLERS
};
