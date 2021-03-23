; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
AppName=Apskaita5 update
AppID=Apskaita5MD
AppVerName=Apskaita 5 v. 2021-03-23 update
AppPublisher=Marius Dagys
AppPublisherURL=https://github.com/Apskaita5/Apskaita5/wiki
AppSupportURL=http://www.tax.lt/temos/12748-nemokama-apskaitos-programa
AppUpdatesURL=https://github.com/Apskaita5/Apskaita5/wiki
DefaultDirName={pf}\Apskaita5
DisableDirPage=yes
DefaultGroupName=Apskaita5
DisableProgramGroupPage=yes
OutputDir=C:\D\My Documents\Inno Output
OutputBaseFilename=Apskaita5_setup
MinVersion=0,6.0
Compression=lzma
SolidCompression=yes
CreateUninstallRegKey=no
UpdateUninstallLogAppName=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Apskaita5.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\CSLA.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccDataAccessLayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccControlsWinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccDataBindingsWinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccPluginManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccIPlugin.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccDataProvider.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\DataProviders.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\RdlDesign.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\RdlViewer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\RdlEngine.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\RdlCri.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\ObjectListView.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\EPPlus.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\ListViewPrinter.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\ApskaitaObjects.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccCommon.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\InvoiceInfo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\sqlite3.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\AccMigration\bin\x86\Release\AccMigration.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Reports\*"; DestDir: "{app}\Reports"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\SqlDepositories\*"; DestDir: "{app}\SqlDepositories"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\DbStructure\*"; DestDir: "{app}\DbStructure"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\SaskaituPlanai.zip"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\WTClasses.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\LastUpdateA5.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MySQL_accsecurity.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\zalsva.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\FR0572(4).ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\FR0573(4).ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\SAM-v03.ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\SAM-v04.ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\SAM-v05.ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\SAM-v06.ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\13-SD-v05.ffdata"; DestDir: "{app}\FFData"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\FR0600(2).ffdata"; DestDir: "{app}\FFData"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\FR0471(5).ffdata"; DestDir: "{app}\FFData"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\GPM313.ffdata"; DestDir: "{app}\FFData"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\GPM312(1).ffdata"; DestDir: "{app}\FFData"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\SAM-v07.ffdata"; DestDir: "{app}\FFData"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0573(3).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0572(4).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0573(4).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAM-v03.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAM-v04.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAM-v05.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAM-v06.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0672(2).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0671(2).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\13-SD-v05.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0600(2).mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\GPM313.mxfd"; DestDir: "{app}\MXFD"; Flags: onlyifdoesntexist
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\isaf_1_2.xsd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAFT_2_01.xsd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\FR0471(5).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\GPM312(1).mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\SAM-v07.mxfd"; DestDir: "{app}\MXFD"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Apskaita5Help.chm"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\CommonSettings.xmls"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\RdlEngineConfig.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\UserReportExample.rdl"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\D\My Documents\My Projects\Apskaita5Plugins\A5P_ivesk_lt\bin\Release\A5Plugin.dll"; DestDir: "{app}\InvoiceAdapters\ivesk_lt"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Dirs]
Name: "{app}\UserReports"; Flags: uninsneveruninstall; Permissions: users-modify

[Run]
Filename: "{app}\Apskaita5.exe"; Description: "{cm:LaunchProgram,Apskaita5}"; Flags: nowait postinstall skipifsilent

[Code]
function IsUpgrade(): Boolean;
var
   sPrevPath: String;
begin
  sPrevPath := '';
  if not RegQueryStringValue(HKEY_CURRENT_USER, 'Software\Microsoft\Windows\CurrentVersion\Uninstall\Apskaita5MD_is1', 'UninstallString', sPrevpath) then
    RegQueryStringValue(HKEY_LOCAL_MACHINE, 'Software\Microsoft\Windows\CurrentVersion\Uninstall\Apskaita5MD_is1', 'UninstallString', sPrevpath);
  Result := (sPrevPath <> '');
end;

function InitializeSetup: Boolean;
begin
    if Not IsUpgrade() then begin
      MsgBox('The installation of Apskaita5 update requires Apskaita5 to be installed.' + #13#10 + 'Install Apskaita5 before installing this update.' + #13#10#13#10 + 'The setup of update will be terminated.', mbInformation, MB_OK);
      Result := False;
      end
    else begin
      Result := True;
      end
    end;
end.
