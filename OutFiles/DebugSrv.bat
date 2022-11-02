sc \\web stop BusinessSyncSrv
ping -n 5 localhost > Nul
xcopy /Y /E G:\Rabota\Business\OutFiles\DebugSrv \\WEB\SyncServer
del \\WEB\SyncServer\*.config
sc \\web start BusinessSyncSrv