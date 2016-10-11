Originally take from https://www.youtube.com/watch?v=75XImxOOInU<br />
Open sourced dll file so you can modify as you wish. <br />
Unmanaged exports FTW<br />
Ensure to rename the compiled file to coreclr.dll<br />
I placed a working version in the root<br />
Compiled for x64<br />

1. coregen.exe /L lets us specify the path to coreclr.dll
2. coreclr.dll exports the function GetCLRRuntimeHost
3. create a .net class library that exports GetCLRRuntimeHost (using unmanaged exports)