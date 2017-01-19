@REM Download latest NUR API libraries from GitHub.

@SET GETTER=wget.exe
@SET SDK_REPO=nur_sdk
@SET REMOTE_BASE=https://github.com/NordicID/%SDK_REPO%/raw/master
@SET LOCAL_IMPORTDIR=import

@REM ********************************************
@REM Windows CE / WEC .NET API
@REM ********************************************

@REM Target: dotnet\dotnet_cf_vs2005\NurApiDotNetWCE.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_cf_vs2005/NurApiDotNetWCE.dll -O %LOCAL_IMPORTDIR%\dotnet\dotnet_cf_vs2005\NurApiDotNetWCE.dll

@REM Target: dotnet\dotnet_cf_vs2005\NurApiDotNetWCE.XML
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_cf_vs2005/NurApiDotNetWCE.XML -O %LOCAL_IMPORTDIR%\dotnet\dotnet_cf_vs2005\NurApiDotNetWCE.XML

@REM Target: dotnet\dotnet_cf_vs2008\NurApiDotNetWCE.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_cf_vs2008/NurApiDotNetWCE.dll -O %LOCAL_IMPORTDIR%\dotnet\dotnet_cf_vs2008\NurApiDotNetWCE.dll

@REM Copy XML help from VS2005
@copy %LOCAL_IMPORTDIR%\dotnet\dotnet_cf_vs2005\NurApiDotNetWCE.XML %LOCAL_IMPORTDIR%\dotnet\dotnet_cf_vs2008\ /y

@REM ********************************************
@REM Windows .NET API
@REM ********************************************
@SET LOCAL_TARGET_BASE=%LOCAL_IMPORTDIR%\dotnet\dotnet_windows

@REM Target: %LOCAL_TARGET_BASE%\AnyCPU\NurApiDotNet.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_windows/AnyCPU/NurApiDotNet.dll -O %LOCAL_TARGET_BASE%\AnyCPU\NurApiDotNet.dll

@REM Target: %LOCAL_TARGET_BASE%\x64\NurApiDotNet.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_windows/x64/NurApiDotNet.dll -O %LOCAL_TARGET_BASE%\x64\NurApiDotNet.dll

@REM Target: %LOCAL_TARGET_BASE%\x86_ansi\NurApiDotNet.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_windows/x86_ansi/NurApiDotNet.dll -O %LOCAL_TARGET_BASE%\x86_ansi\NurApiDotNet.dll

@REM Target: %LOCAL_TARGET_BASE%\x86\NurApiDotNet.dll
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_windows/x86/NurApiDotNet.dll -O %LOCAL_TARGET_BASE%\x86\NurApiDotNet.dll

@REM Target: %LOCAL_TARGET_BASE%\x86\NurApiDotNet.XML
%GETTER% -q %REMOTE_BASE%/dotnet/dotnet_windows/x86/NurApiDotNet.XML -O %LOCAL_TARGET_BASE%\x86\NurApiDotNet.XML

@REM Copy XML help from x86
@copy %LOCAL_TARGET_BASE%\x86\NurApiDotNet.XML %LOCAL_TARGET_BASE%\AnyCPU\ /y
@copy %LOCAL_TARGET_BASE%\x86\NurApiDotNet.XML %LOCAL_TARGET_BASE%\x64\ /y
@copy %LOCAL_TARGET_BASE%\x86\NurApiDotNet.XML %LOCAL_TARGET_BASE%\x86_ansi\ /y

@REM *************
@REM Common native
@REM *************
@SET LOCAL_TARGET_BASE=%LOCAL_IMPORTDIR%\include
@SET REMOTE_DIR=%REMOTE_BASE%/include

%GETTER% -q %REMOTE_DIR%/NurAPI.h -O %LOCAL_TARGET_BASE%\NurAPI.h
%GETTER% -q %REMOTE_DIR%/NurAPIConstants.h -O %LOCAL_TARGET_BASE%\NurAPIConstants.h
%GETTER% -q %REMOTE_DIR%/NurAPIErrors.h -O %LOCAL_TARGET_BASE%\NurAPIErrors.h
%GETTER% -q %REMOTE_DIR%/NurAPIExport.h -O %LOCAL_TARGET_BASE%\NurAPIExport.h
%GETTER% -q %REMOTE_DIR%/NurOS.h -O %LOCAL_TARGET_BASE%\NurOS.h
%GETTER% -q %REMOTE_DIR%/NurOs_Linux.h -O %LOCAL_TARGET_BASE%\NurOs_Linux.h
%GETTER% -q %REMOTE_DIR%/NurOs_Win32.h -O %LOCAL_TARGET_BASE%\NurOs_Win32.h

@REM ******************
@REM Windows native API
@REM ******************
@SET LOCAL_TARGET_BASE=%LOCAL_IMPORTDIR%\win_native
@SET REMOTE_DIR=%REMOTE_BASE%/win_native

@REM Win32
%GETTER% -q %REMOTE_DIR%/win32/NURAPI.dll -O %LOCAL_TARGET_BASE%\win32\NURAPI.dll
%GETTER% -q %REMOTE_DIR%/win32/NURAPI.lib -O %LOCAL_TARGET_BASE%\win32\NURAPI.lib

@REM Win x86_64
%GETTER% -q %REMOTE_DIR%/win64/NURAPI.dll -O %LOCAL_TARGET_BASE%\win64\NURAPI.dll
%GETTER% -q %REMOTE_DIR%/win64/NURAPI.lib -O %LOCAL_TARGET_BASE%\win64\NURAPI.lib

@REM WCE/WEC
%GETTER% -q %REMOTE_DIR%/windowsce/NURAPI.dll -O %LOCAL_TARGET_BASE%\windowsce\NURAPI.dll
%GETTER% -q %REMOTE_DIR%/windowsce/NURAPI.lib -O %LOCAL_TARGET_BASE%\windowsce\NURAPI.lib


@SET GETTER=
@SET REMOTE_DIR=
@SET REMOTE_DIR=
@REM @PAUSE