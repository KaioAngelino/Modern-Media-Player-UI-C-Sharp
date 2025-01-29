@echo off
set Executavel="C:\Users\kaioa\Desktop\PlayerUI.exe"
set ILMerge="C:\Users\kaioa\source\repos\KaioAngelino\Modern-Media-Player-UI-C-Sharp\packages\ILMerge.3.0.41\tools\net452\ILMerge.exe"
set Saida="C:\Users\kaioa\Desktop\Quiz.exe"
%ILMerge% /target:winexe /out:%Saida% %Executavel% "C:\Users\kaioa\Downloads\CRUD_SQLite\packages\System.Data.SQLite.Core.1.0.103\build\net45\x64\SQLite.Interop.dll" "C:\Users\kaioa\Desktop\EntityFramework.dll"
@pause
