# Viewing a certificate in windows

```
certutil ^
   -p "mysecuredevicepassword" ^
   -v ^
   -dump C:\Users\Bill\Documents\ws\SB\AzureIoTDPSCertificates\src\DPSCertificateTool\bin\Debug\netcoreapp3.1\mydevicecert.pfx
```
