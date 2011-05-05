// BISO.h: interface for the BISO class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_BISO_H__6FEC9A1C_D768_4CD0_87A6_97C017D56CEB__INCLUDED_)
#define AFX_BISO_H__6FEC9A1C_D768_4CD0_87A6_97C017D56CEB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <afxtempl.h>


#ifdef BVK_VEXPORT
	#define BVK_VDECL	__declspec(dllexport)
#else
	#define BVK_VDECL	__declspec(dllimport)
#endif

/*! \addtogroup BISO_function
 @{ */

enum BIsoError
{
	err_isoNoError=0,
	err_isoOpenFile,
	err_isoRecordNotFound,
	err_isoDirOffsetNonDigit,
	err_isoFileSeekError,
	err_isoDirNotFound,
	err_isoReadRecordLess,
	err_isoReadBuffer,
	err_isoWrongSymbolNull,
	err_isoEOF,
	err_recHeaderBaseAdr,
	err_recWrongBaseAdr,
	err_recWrongFldSeparator,
	err_recHeaderLenField,
	err_recHeaderLenData,
	err_recWrongDataSize,
	err_recWrongDataFldDigit,
	err_fldWrongSize,
	err_fldWrongSymbol,
	err_fldBigFieldName,
};

class BVK_VDECL BISO  
{
public:
	void RemoveFldArray();
	CString GetIsoBuffer(char fldSep=0x1E,char recSep=0x1D);
	int GetRecordCount();
	int GetFieldCount();
	CString GetFieldText(LPCSTR lpName);
	CString GetFieldText(int nIndex);
	CString GetFieldName(int nIndex);
	void AddField(LPCSTR fldName,LPCSTR fldText);
	BOOL SetIsoBuffer(LPCSTR lpcBuffer, char fldSep=0x1E,char recSep=0x1D);
	int GetCurRecord();
	BISO();
	BISO(LPCSTR lpFileName);
	virtual ~BISO();

	BOOL		Open(LPCSTR lpFileName);
	BOOL		Close();
	BOOL		SetRecord(int nRecord);
	int			GetErrorCode();
	CString	GetErrorText();
	CString	GetOrigBuffer();					// �����. �����-�� ���������� ������ � Win ���.

protected:
	CFile				m_file;								// ���� � ������� ��������

	CString			m_isoBuffer;					// �������� ���������� ���. ������, ����� ��� �������
	BOOL				m_bLoading;						// ���� TRUE �� ���� ��� �� �������� - �����
																		//  ��������� � m_dirArr
	CDWordArray	m_dirArr;							// ������ �� ���������� �� ISO ������ � �����
	int					m_curRecord;					// ������� ������

	int					m_errorCode;
	CString			m_errorText;

	struct IsoFieldItem
	{
		CString fldName;
		CString fldText;
	};
	CArray<IsoFieldItem *,IsoFieldItem *> m_fldArr;

protected:
	CString ReadIsoBuffer();
	BOOL IsDigitString(LPCSTR str);
	long GetDirOffset(int nRecord);
	CString GetErrorMessage(CException *ex);
	void SetError(int errorCode,LPCSTR errorText=NULL);
	void RemoveAll();
};


/////////////////////////////////////////////////////////////////////////////////////////
// ��� ������������� � C# � �.�.
#ifdef __cplusplus
extern "C" {
#endif

//! ������� ������ BISO
/**
	����� ������������� ���������� ������� ������ @see BISO_Close
	@param lpcsFileName - ���� ��� ��������
	@return - ���������� ��������� �� ������ isoObj, ������� ����� ���������� ������������
*/
LPVOID	BVK_VDECL BISO_Create(const char *lpcsFileName);

//! ������� ������ �� ������
/**\n*/
void		BVK_VDECL BISO_Close(void *isoObj);

//! ���������� ��� ������
/**\n*/
long		BVK_VDECL BISO_GetErrorCode(void *isoObj);

//! ���������� ����� ������
/**
	@return - ��� ������
	@return out - �������� ������
*/
long		BVK_VDECL BISO_GetErrorText(void *isoObj,BSTR *out);

//! ���������� ���-�� ������� � isoObj
/**\n*/
long		BVK_VDECL BISO_GetRecordCount(void *isoObj);

//! ���������� ���-�� ����� � ������� ������
/**\n*/
long		BVK_VDECL BISO_GetFieldCount(void *isoObj);

//! ���������� ����� ������� ������
/**\n*/
long		BVK_VDECL BISO_GetCurRecord(void *isoObj);

//! ������ �� ������
/**\n*/
void		BVK_VDECL BISO_SetCurRecord(void *isoObj,long nRecord);

//! �������� �������� ���� � ������� nIndex
/**
	@param nIndex - ����� ����
	@return out - �������� ����
*/
void		BVK_VDECL BISO_GetFieldName(void *isoObj,long nIndex, BSTR *out);

//! �������� ���������� ���� � ������� nIndex
/**
	@param nIndex - ����� ����
	@return out - ���������� ����
*/
void		BVK_VDECL BISO_GetFieldText(void *isoObj,long nIndex, BSTR *out);

//! ��������� ISO ������
/**\n*/
void		BVK_VDECL BISO_GetIsoBuffer(void *isoObj,BSTR *out);

//! ������� ��� ���� �� ������� ������
/**
	������������ ��� �������� ����� ������
*/
void		BVK_VDECL BISO_RemoveFieldArray(void *isoObj);

//! �������� ���� � ������� ������
/**
	������������ ��� �������� ����� ������
*/
void		BVK_VDECL BISO_AddField(void *isoObj,const char *lpcsFldName, const char *lpcsFldText);

//! �������� ������������ ��� ISO ������
/**
	������������ ��� �������
*/
void		BVK_VDECL BISO_GetOrigIsoBuffer(void *isoObj,BSTR *out);

#ifdef __cplusplus
}
#endif

/*! @} */

#endif // !defined(AFX_BISO_H__6FEC9A1C_D768_4CD0_87A6_97C017D56CEB__INCLUDED_)
