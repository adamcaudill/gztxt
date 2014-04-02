; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "GZTXT"
#define MyAppVersion "0.1.0"
#define MyAppPublisher "Adam Caudill"
#define MyAppURL "https://github.com/adamcaudill/gztxt"
#define MyAppExeName "gztxt.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{5196EE2E-C4D9-443B-AB8A-FC9951BD733E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=.\LICENSE.txt
OutputBaseFilename=setup-gztxt-{#MyAppVersion}
Compression=lzma
SolidCompression=yes
UninstallDisplayIcon={app}\gztxt.exe

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: ".\gztxt\bin\Release\gztxt.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\gztxt\bin\Release\libgztxt.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\gztxt-cli\bin\Release\gztxt-cli.exe"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Run]
Filename: "{app}\gztxt.exe"; Parameters: "register"

[UninstallRun]
Filename: "{app}\gztxt.exe"; Parameters: "unregister"