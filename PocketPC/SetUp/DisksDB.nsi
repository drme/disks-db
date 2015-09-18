;Version Information

  VIProductVersion "1.0.0.0"
  VIAddVersionKey "ProductName" "DisksDB"
  VIAddVersionKey "Comments" "Support for this application can be obtained via sarunas_p@sourceforge.net"
  VIAddVersionKey "CompanyName" "Sarunas"
  VIAddVersionKey "LegalTrademarks" ""
  VIAddVersionKey "LegalCopyright" "© Sarunas"
  VIAddVersionKey "FileDescription" "DVD Catalog for PocketPC"
  VIAddVersionKey "FileVersion" "1.0"

;--------------------------------

Caption "DisksDB"

;--------------------------------
; HM NIS Edit Wizard helper defines
;--------------------------------
!define PRODUCT_NAME "DisksDB"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "Software Company"
!define PRODUCT_WEB_SITE "http://disksdb.souceforge.net/"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

;--------------------------------
; MUI Settings
;--------------------------------
;Include Modern UI
!include "MUI.nsh"

!define MUI_ABORTWARNING
!define MUI_ICON "DisksDB.ico"
!define MUI_UNICON "DisksDB.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "topside.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP "leftside.bmp"
;--------------------------------
; MUI Pages
;--------------------------------
; Welcome page
!insertmacro MUI_PAGE_WELCOME

; License page
!define MUI_LICENSEPAGE_RADIOBUTTONS

!insertmacro MUI_PAGE_LICENSE "eula.txt"

; Components page
!insertmacro MUI_PAGE_COMPONENTS

; Instfiles page
!insertmacro MUI_PAGE_INSTFILES

; Finish page
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

;-------------------------------------
; MUI end
;-------------------------------------

;--------------------------------
;Configuration
;--------------------------------
Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "Setup-Pocket${PRODUCT_NAME}.${PRODUCT_VERSION}.exe"
InstallDir "$PROGRAMFILES\Microsoft ActiveSync\${PRODUCT_NAME}.${PRODUCT_VERSION}\"
ShowInstDetails show
ShowUnInstDetails show

;-------------------------------
; Call Pocket PC ActiveSync App
;-------------------------------
Section
 ;locate and launch the CEAPPMGR for the Pocket PC
 Call InitInstallCAB
SectionEnd

;--------------------------------
; Installer Sections
;--------------------------------

; The Multiple Installer Install
Section "DisksDB" SEC01 ; (default, requried section)
  SectionIn 1, RO
  SetOutPath "$INSTDIR"
  SetOverwrite on
  File eula.txt
  File DisksDB.ini
  File DisksDB.ARM.CAB
  File DisksDB.ARMV4.CAB
  StrCpy $0 "$INSTDIR\DisksDB.ini"
  Call InstallCAB
;  MessageBox MB_OK|MB_ICONEXCLAMATION \
;  "Please wait for The Multiple Installer Example install to finish on your device before continuing."
SectionEnd ; end of default section

; The Multiple Installer Install
Section "SQL 2005 Mobile" SEC02
  SectionIn 2
  SetOutPath "$INSTDIR"
  SetOverwrite on
  File SQLCE30.ini
  File sqlce30.ppc.wce4.armv4.CAB
  File sqlce30.ppc.wce5.armv4i.CAB
  File sqlce30.wce5.armv4i.CAB
;  File sqlce30.wce5.mipsii.CAB
;  File sqlce30.wce5.mipsii_fp.CAB
;  File sqlce30.wce5.mipsiv.CAB
;  File sqlce30.wce5.mipsiv_fp.CAB
;  File sqlce30.wce5.sh4.CAB
  StrCpy $0 "$INSTDIR\SQLCE30.ini"
  Call InstallCAB
;  MessageBox MB_OK|MB_ICONEXCLAMATION \
;  "Please wait for The Multiple Installer Example install to finish on your device before continuing."
SectionEnd ; end of default section

;--------------------------------
; Addtional Sections
;--------------------------------
Section -AdditionalIcons
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

;--------------------------------
; Section Descriptions
;--------------------------------
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC01} "DisksDB for Pocket PC devices"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC02} "Installs Microsoft SQL Server 2005 Mobile,"
!insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section
;--------------------------------

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\eula.txt"
  Delete "$INSTDIR\DisksDB.ARM.CAB"
  Delete "$INSTDIR\DisksDB.ARMV4.CAB"
  Delete "$INSTDIR\DisksDB.ini"
  Delete SQLCE30.ini
  Delete sqlce30.ppc.wce4.armv4.CAB
  Delete sqlce30.ppc.wce5.armv4i.CAB
  Delete sqlce30.wce5.armv4i.CAB
  RMDir "$INSTDIR"
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  SetAutoClose true
SectionEnd

;--------------------------------
; Pocket PC Install Section
;--------------------------------
; Installs a PocketPC cab-application
; It expects $0 to contain the absolute location of the ini file to be installed.
Function InstallCAB
  ExecWait '"$1" "$0"'
FunctionEnd

;--------------------------------
; OPEN CEAPPMGR FOR POCKET PC APPLICATION INSTALLING
;--------------------------------
Function InitInstallCAB
  ; one-time initialization needed for InstallCAB subroutine
  ReadRegStr $1 HKEY_LOCAL_MACHINE "software\Microsoft\Windows\CurrentVersion\App Paths\CEAppMgr.exe" ""
  IfErrors Error
  Goto End
  Error:
  MessageBox MB_OK|MB_ICONEXCLAMATION \
  "Unable to find Application Manager for PocketPC applications. \
  Please install ActiveSync and reinstall YourApp."
  End:
FunctionEnd
; eof
