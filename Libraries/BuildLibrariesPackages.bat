@echo off

echo ====================== pack ViewFaceCore.runtime.win.x64 ======================
cd ViewFaceCore.runtime.win.x64
call pack.bat
cd ..

echo ====================== pack ViewFaceCore.runtime.win.x86 ======================
cd ViewFaceCore.runtime.win.x86
call pack.bat
cd ..