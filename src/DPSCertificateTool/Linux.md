# Running on Linux
1. cd SomeFolderWhereYouWillRun
2. git clone https://github.com/BillBaird/AzureIoTDPSCertificates
3. cd AzureIoTDPSCertificates/src/
4. dotnet publish -p:DefineConstants="NETSTANDARD2_0" -c Release -o ./Publish
5. cd Publish
6. \# Actually run it
 <br />
   ./RW.DPSCertificateTool createcertchain -s "SB Dev Certificate Authority" -p abc123 -i 1
7. ls   
8. openssl x509 -inform der -in SB\ Dev\ Certificate\ Authority.cer -noout -text
9. openssl x509 -inform p12 -in Intermediate\ 1.pfx -noout -text
<br />
   (Note that this will prompt for a "pass phrase", although it does not appear to work)
