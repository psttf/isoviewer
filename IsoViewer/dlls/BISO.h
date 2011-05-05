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
	CString	GetOrigBuffer();					// возвр. орисг-ое содердимое записи в Win код.

protected:
	CFile				m_file;								// файл с которым работаем

	CString			m_isoBuffer;					// исходное содержимое тек. записи, нужно для отладки
	BOOL				m_bLoading;						// если TRUE то файл еще не загружен - нужно
																		//  считывать в m_dirArr
	CDWordArray	m_dirArr;							// массив из указателей на ISO записи в файле
	int					m_curRecord;					// текущая запись

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
// для использования в C# и т.п.
#ifdef __cplusplus
extern "C" {
#endif

//! Создает объект BISO
/**
	После использования необходимо удалить объект @see BISO_Close
	@param lpcsFileName - файл для открытия
	@return - возвращает указатель на объект isoObj, который потом необходимо использовать
*/
LPVOID	BVK_VDECL BISO_Create(const char *lpcsFileName);

//! Удалить объект из памяти
/**\n*/
void		BVK_VDECL BISO_Close(void *isoObj);

//! Возвращает код ошибки
/**\n*/
long		BVK_VDECL BISO_GetErrorCode(void *isoObj);

//! Возвращает текст ошибки
/**
	@return - код ошибки
	@return out - содержит ошибку
*/
long		BVK_VDECL BISO_GetErrorText(void *isoObj,BSTR *out);

//! Возвращает кол-во записей в isoObj
/**\n*/
long		BVK_VDECL BISO_GetRecordCount(void *isoObj);

//! Возвращает кол-во полей в текущей записи
/**\n*/
long		BVK_VDECL BISO_GetFieldCount(void *isoObj);

//! Возвращает номер текущей записи
/**\n*/
long		BVK_VDECL BISO_GetCurRecord(void *isoObj);

//! Встает на запись
/**\n*/
void		BVK_VDECL BISO_SetCurRecord(void *isoObj,long nRecord);

//! Получить название поля с номером nIndex
/**
	@param nIndex - номер поля
	@return out - название поля
*/
void		BVK_VDECL BISO_GetFieldName(void *isoObj,long nIndex, BSTR *out);

//! Получить содержимое поля с номером nIndex
/**
	@param nIndex - номер поля
	@return out - содержимое поля
*/
void		BVK_VDECL BISO_GetFieldText(void *isoObj,long nIndex, BSTR *out);

//! Построить ISO запись
/**\n*/
void		BVK_VDECL BISO_GetIsoBuffer(void *isoObj,BSTR *out);

//! удалить все поля из текущей записи
/**
	используется при создании новой записи
*/
void		BVK_VDECL BISO_RemoveFieldArray(void *isoObj);

//! добавить поле к текущей записи
/**
	используется при создании новой записи
*/
void		BVK_VDECL BISO_AddField(void *isoObj,const char *lpcsFldName, const char *lpcsFldText);

//! Получить оригинальный вид ISO записи
/**
	используется для отладки
*/
void		BVK_VDECL BISO_GetOrigIsoBuffer(void *isoObj,BSTR *out);

#ifdef __cplusplus
}
#endif

/*! @} */

#endif // !defined(AFX_BISO_H__6FEC9A1C_D768_4CD0_87A6_97C017D56CEB__INCLUDED_)
