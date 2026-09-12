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

#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN            // Èñêëþ÷èòå ðåäêî èñïîëüçóåìûå êîìïîíåíòû èç çàãîëîâêîâ Windows
#endif

#include "targetver.h"

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS      // íåêîòîðûå êîíñòðóêòîðû CString áóäóò ÿâíûìè

// îòêëþ÷àåò ôóíêöèþ ñêðûòèÿ íåêîòîðûõ îáùèõ è ÷àñòî ïðîïóñêàåìûõ ïðåäóïðåæäåíèé MFC
#define _AFX_ALL_WARNINGS

#include <afxwin.h>         // îñíîâíûå è ñòàíäàðòíûå êîìïîíåíòû MFC
#include <afxext.h>         // Ðàñøèðåíèÿ MFC


#include <afxdisp.h>        // êëàññû àâòîìàòèçàöèè MFC



#ifndef _AFX_NO_OLE_SUPPORT
#include <afxdtctl.h>           // ïîääåðæêà MFC äëÿ òèïîâûõ ýëåìåíòîâ óïðàâëåíèÿ Internet Explorer 4
#endif
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>             // ïîääåðæêà MFC äëÿ òèïîâûõ ýëåìåíòîâ óïðàâëåíèÿ Windows
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <afxcontrolbars.h>     // ïîääåðæêà MFC äëÿ ëåíò è ïàíåëåé óïðàâëåíèÿ









#ifdef _UNICODE
#if defined _M_IX86
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='x86' publicKeyToken='6595b64144ccf1df' language='*'\"")
#elif defined _M_X64
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='amd64' publicKeyToken='6595b64144ccf1df' language='*'\"")
#else
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='*' publicKeyToken='6595b64144ccf1df' language='*'\"")
#endif
#endif


