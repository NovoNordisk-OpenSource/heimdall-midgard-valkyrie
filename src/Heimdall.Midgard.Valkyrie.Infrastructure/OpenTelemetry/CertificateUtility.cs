namespace Heimdall.Midgard.Valkyrie.Infrastructure.OpenTelemetry;

public static class CertificateUtility
{
    public static (X509Certificate2 Certificate, RSA PrivateKey) ExtractCert(string certObj)
    {
        X509Certificate2 certificate;
        RSA privateKey;

        var data = Convert.FromBase64String(certObj);
        
        try
        {
            (certificate, privateKey) = DecodePkcs12(data, "");
        }
        catch (Exception e)
        {
            throw new Exception("Failed to decode PKCS#12 certificate.", e);
        }

        return (certificate, privateKey);
    }

    private static (X509Certificate2, RSA) DecodePkcs12(byte[] pkcs, string password)
    {
        X509Certificate2 certificate;
        RSA? privateKey;

        try
        {
            certificate = new X509Certificate2(
                pkcs,
                password,
                X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet
            );

            privateKey = certificate.GetRSAPrivateKey();
        }
        catch (Exception e)
        {
            throw new Exception("Failed to decode PKCS#12 certificate.", e);
        }

        if (privateKey == null) 
            throw new Exception("PKCS#12 certificate must contain an RSA private key.");

        return (certificate, privateKey);
    }
}