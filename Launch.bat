echo off
svn log -v --xml>DealFile.xml
cd /d C:\Users\kingsoft\source\repos\SVNLog\SVNLog\bin\Debug
SVNLog.exe