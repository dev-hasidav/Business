sc \\web stop BusinessSyncSrvAgent
ping -n 5 localhost > Nul
copy /Y G:\Rabota\Business\OutFiles\DebugSrvAgent \\WEB\AgentSync
del \\WEB\AgentSync\*.config
sc \\web start BusinessSyncSrvAgent