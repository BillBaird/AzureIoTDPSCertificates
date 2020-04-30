using System;
using System.Security.Cryptography.X509Certificates;

namespace RW.DPSCertificateTool
{
    public static class CertificateExtensions
    {
        public static X509Extension MakeAuthorityKey(this X509SubjectKeyIdentifierExtension subjectKeyIdentifierExtension)
        {
            // Make the AuthorityKeyIdentifierExtension. There is no built-in 
            // support, so it needs to be copied from the Subject Key 
            // Identifier of the signing certificate and massaged slightly.
            // AuthorityKeyIdentifier is "KeyID=<subject key identifier>"
            var issuerSubjectKey = subjectKeyIdentifierExtension.RawData;
            var segment = new ArraySegment<byte>(issuerSubjectKey, 2, issuerSubjectKey.Length - 2);
            var authorityKeyIdentifier = new byte[segment.Count + 4];
            // these bytes define the "KeyID" part of the AuthorityKeyIdentifier
            authorityKeyIdentifier[0] = 0x30;
            authorityKeyIdentifier[1] = 0x16;
            authorityKeyIdentifier[2] = 0x80;
            authorityKeyIdentifier[3] = 0x14;
            segment.CopyTo(authorityKeyIdentifier, 4);
            return new X509Extension("2.5.29.35", authorityKeyIdentifier, false);
        }

        public static X509SubjectKeyIdentifierExtension X509SubjectKeyIdentifierExtension(this X509ExtensionCollection extensions)
            => (X509SubjectKeyIdentifierExtension)extensions["2.5.29.14"];

        public static X509SubjectKeyIdentifierExtension X509SubjectKeyIdentifierExtension(this X509Certificate2 certificate)
            => certificate.Extensions.X509SubjectKeyIdentifierExtension();
    }
}