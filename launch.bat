@echo off
setlocal

set ClientBin=Client\Client\bin\Debug\Client.exe
set ServerBin=CUI_Sample\Client\Client\bin\Debug\netcoreapp3.1\Client.exe

pushd "%~dp0"

start %ClientBin%

wait 1000
start %ServerBin% ws://localhost:8000/ws/
start %ServerBin% ws://localhost:8001/ws/

popd
