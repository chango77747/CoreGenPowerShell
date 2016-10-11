Originally take from https://www.youtube.com/watch?v=75XImxOOInU
Open sourced dll file so you can modify as you wish. 
Unmanaged exports FTW
Ensure to rename the compiled file to coreclr.dll
I placed a working version in the root
Compiled for x64

1. coregen.exe /L lets us specify the path to coreclr.dll
2. coreclr.dll exports the function GetCLRRuntimeHost
3. create a .net class library that exports GetCLRRuntimeHost (using unmanaged exports)