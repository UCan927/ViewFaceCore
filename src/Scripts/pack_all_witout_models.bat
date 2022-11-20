@echo off

set configuration=Release
set runTimeVersion=6.0.8-alpha4
set extensionsVersion=0.4.0-alpha4
set mainVersion=0.4.0-alpha4
set output=%~dp0publish

cd ..

echo ��ʼ���ViewFaceCore...

echo ====================== pack ViewFaceCore ======================
cd .\ViewFaceCore
rd /s /q bin
call pack.bat %configuration% %mainVersion% %output%
cd ..
echo ��ʼ���Runtimes...


echo ====================== pack ViewFaceCore.runtime.win.x64 ======================
cd .\Runtimes\ViewFaceCore.runtime.win.x64
rd /s /q bin
call pack.bat %configuration% %runTimeVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.runtime.win.x86 ======================
cd .\Runtimes\ViewFaceCore.runtime.win.x86
rd /s /q bin
call pack.bat %configuration% %runTimeVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.runtime.ubuntu.20.04.x64 ======================
cd .\Runtimes\ViewFaceCore.runtime.ubuntu.20.04.x64
rd /s /q bin
call pack.bat %configuration% %runTimeVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.runtime.linux.arm ======================
cd .\Runtimes\ViewFaceCore.runtime.linux.arm
rd /s /q bin
call pack.bat %configuration% %runTimeVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.runtime.linux.arm64 ======================
cd .\Runtimes\ViewFaceCore.runtime.linux.arm64
rd /s /q bin
call pack.bat %configuration% %runTimeVersion% %output%
cd ..\..

echo ��ʼ���Extensions...

echo ====================== pack ViewFaceCore.Extension.DependencyInjection ======================
cd .\Extensions\ViewFaceCore.Extension.DependencyInjection
rd /s /q bin
call pack.bat %configuration% %extensionsVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.Extension.ImageSharp ======================
cd .\Extensions\ViewFaceCore.Extension.ImageSharp
rd /s /q bin
call pack.bat %configuration% %extensionsVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.Extension.SkiaSharp ======================
cd .\Extensions\ViewFaceCore.Extension.SkiaSharp
rd /s /q bin
call pack.bat %configuration% %extensionsVersion% %output%
cd ..\..

echo ====================== pack ViewFaceCore.Extension.SystemDrawing ======================
cd .\Extensions\ViewFaceCore.Extension.SystemDrawing
rd /s /q bin
call pack.bat %configuration% %extensionsVersion% %output%
cd ..\..

echo ������ɣ��밴������˳�...
pause > nul
exit 0