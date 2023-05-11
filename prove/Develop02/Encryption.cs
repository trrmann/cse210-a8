using System.Security.Cryptography;
public class Encryption
{
    static private int _AES_BLOCK_SIZE = 128;
    static public int AESBlockSize
    {
        get
        {
            return _AES_BLOCK_SIZE;
        }
        protected set
        {
            _AES_BLOCK_SIZE = value;
        }
    }
    static private int _AES_FEEDBACK_SIZE = 8;
    static public int AESFeedbackSize
    {
        get
        {
            return _AES_FEEDBACK_SIZE;
        }
        protected set
        {
            _AES_FEEDBACK_SIZE = value;
        }
    }
    static private int _AES_KEY_SIZE = 256;
    static public int AESKeySize
    {
        get
        {
            return _AES_KEY_SIZE;
        }
        protected set
        {
            _AES_KEY_SIZE = value;
        }
    }
    static private CipherMode _AES_MODE = CipherMode.CBC;
    static public CipherMode AESCipherMode
    {
        get
        {
            return _AES_MODE;
        }
        protected set
        {
            _AES_MODE = value;
        }
    }
    static private PaddingMode _AES_PADDING = PaddingMode.PKCS7;
    static public PaddingMode AESPaddingMode
    {
        get
        {
            return _AES_PADDING;
        }
        protected set
        {
            _AES_PADDING = value;
        }
    }
    static private KeySizes _AES_LEGAL_BLOCK_SIZES = new KeySizes(128, 128, 0);
    static public KeySizes AESLegalBlockSizes
    {
        get
        {
            return _AES_LEGAL_BLOCK_SIZES;
        }
        protected set
        {
            _AES_LEGAL_BLOCK_SIZES = value;
        }
    }
    static private KeySizes _AES_LEGAL_KEY_SIZES = new KeySizes(128, 256, 64);
    static public KeySizes AESLegalKeySizes
    {
        get
        {
            return _AES_LEGAL_KEY_SIZES;
        }
        protected set
        {
            _AES_LEGAL_KEY_SIZES = value;
        }
    }
    static private int _RSA_CSP_BITS = 2048;
    static public int RSACSPBits
    {
        get
        {
            return _RSA_CSP_BITS;
        }
        protected set
        {
            _RSA_CSP_BITS = value;
        }
    }
    private Aes _aes;
    //CSP with a new 2048 bit rsa key pair
    private RSACryptoServiceProvider _csp;
    public Encryption(KeySizes legalBlockSizes=null, KeySizes legalKeySizes=null, Aes aes=null, RSACryptoServiceProvider csp=null)
    {
        if(legalBlockSizes is null)
        {
            AESLegalBlockSizes = AESLegalBlockSizes;
        }
        else
        {
            AESLegalBlockSizes = legalBlockSizes;
        }
        if(legalKeySizes is null)
        {
            AESLegalKeySizes = AESLegalKeySizes;
        }
        else
        {
            AESLegalKeySizes = legalKeySizes;
        }
        if(aes is null)
        {
            AES = Aes.Create();
        }
        else
        {
            AES = aes;
        }
        if(csp is null)
        {
            RSACryptoServiceProvider = new RSACryptoServiceProvider(RSACSPBits);
        }
        else
        {
            RSACryptoServiceProvider = csp;
        }
    }
    public Aes AES
    {
        get
        {
            return _aes;
        }
        set
        {
            _aes = value;
        }
    }
    public RSACryptoServiceProvider RSACryptoServiceProvider
    {
        get
        {
            return _csp;
        }
        set
        {
            _csp = value;
        }
    }
    public void SetAes(byte[] initializationVector,
        byte[] secretKey,
        int? blockSize = null,
        int? feedbackSize = null,
        int? keySize = null,
        KeySizes legalBlockSizes = null,
        KeySizes leagKeySizes = null,
        CipherMode? mode = null,
        PaddingMode? padding = null)
    {
        if(blockSize is null)
        {
            AES.BlockSize = AESBlockSize;
        }
        else
        {
            AES.BlockSize = (int)blockSize;
        }
        if (feedbackSize is null)
        {
            AES.FeedbackSize = AESFeedbackSize;
        }
        else
        {
            AES.FeedbackSize = (int)feedbackSize;
        }
        if (keySize is null)
        {
            AES.KeySize = AESKeySize;
        }
        else
        {
            AES.KeySize = (int)keySize;
        }
        if (legalBlockSizes is null)
        {
            AES.LegalBlockSizes[0] = AESLegalBlockSizes;
        }
        else
        {
            AES.LegalBlockSizes[0] = legalBlockSizes;
        }
        if (leagKeySizes is null)
        {
            AES.LegalKeySizes[0] = AESLegalKeySizes;
        }
        else
        {
            AES.LegalKeySizes[0] = leagKeySizes;
        }
        if (mode is null)
        {
            AES.Mode = AESCipherMode;
        }
        else
        {
            AES.Mode = (CipherMode)mode;
        }
        if(padding is null)
        {
            AES.Padding = AESPaddingMode;
        }
        else
        {
            AES.Padding = (PaddingMode)padding;
        }
        AES.IV = initializationVector;
        AES.Key = secretKey;
    }
    // modified from https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0
    // and https://social.msdn.microsoft.com/Forums/en-US/dfd2cbab-7598-4d9b-a051-5692302db7e1/converting-byte-array-to-string-and-back?forum=csharpgeneral
    public string EncryptStringAES(string plainText)
    {
        // Check arguments.
        if (plainText is null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (AES is null)
            throw new ArgumentNullException("Aes");
        if (AES.Key is null || AES.Key.Length <= 0)
            throw new ArgumentNullException("Aes.Key");
        if (AES.IV is null || AES.IV.Length <= 0)
            throw new ArgumentNullException("Aes.IV");
        byte[] encrypted;

        // Create an encryptor to perform the stream transform.
        ICryptoTransform encryptor = AES.CreateEncryptor(AES.Key, AES.IV);

        // Create the streams used for encryption.
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }
        }

        // Return the encrypted bytes from the memory stream.
        return Convert.ToBase64String(encrypted);
    }

    // modified from https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0
    // and https://social.msdn.microsoft.com/Forums/en-US/dfd2cbab-7598-4d9b-a051-5692302db7e1/converting-byte-array-to-string-and-back?forum=csharpgeneral
    public string DecryptStringAES(string ciphered)
    {
        byte[] cipherText = Convert.FromBase64String(ciphered);
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (AES is null)
            throw new ArgumentNullException("Aes");
        if (AES.Key is null || AES.Key.Length <= 0)
            throw new ArgumentNullException("Aes.Key");
        if (AES.IV is null || AES.IV.Length <= 0)
            throw new ArgumentNullException("Aes.IV");

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = AES.CreateDecryptor(AES.Key, AES.IV);

        // Create the streams used for decryption.
        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted bytes from the decrypting stream
                    // and place them in a string.
                    plaintext = srDecrypt.ReadToEnd();
                }
            }
        }
        return plaintext;
    }
    public void PromptForBaseFilename()
    {
        Console.WriteLine("Enter base filename for key:");
        Console.Write(">  ");
    }
    public string ReadResponse()
    {
        return Console.ReadLine();
    }
    public void DisplayPublicPrivateKeyPair()
    {
        PromptForBaseFilename();
        string baseFileName = ReadResponse();
        Tuple<string, string> pair = GetNewPublicPrivateKeyPair();
        Console.WriteLine($"Public Key File:  {baseFileName}.pub.xml");
        Console.WriteLine($"Private Key File:  {baseFileName}.pri.xml");
        File.WriteAllText($"{baseFileName}.pub.xml", pair.Item1);
        File.WriteAllText($"{baseFileName}.pri.xml", pair.Item2);
    }
    public Tuple<string, string> GetNewPublicPrivateKeyPair()
    {
        RSACryptoServiceProvider temp = new RSACryptoServiceProvider(2048);
        return new Tuple<string, string>(GetPublicKey(temp), GetPrivateKey(temp));
    }
    public string GetPublicKey(RSACryptoServiceProvider csp = null)
    {
        if (csp is null) { csp = _csp; };
        //get the public key ...
        RSAParameters pubKey = csp.ExportParameters(false);
        //converting the public key into a string representation
        return GetRSAKeyString(pubKey);
    }
    public string GetPrivateKey(RSACryptoServiceProvider csp = null)
    {
        if (csp is null) { csp = _csp; };
        //get the private key
        RSAParameters privKey = csp.ExportParameters(true);
        return GetRSAKeyString(privKey);
    }
    public RSAParameters GetRSAParameter(string key)
    {
        //get a stream from the string
        var sr = new System.IO.StringReader(key);
        //we need a deserializer
        var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
        //get the object back from the stream
        return (RSAParameters)xs.Deserialize(sr);
    }
    public string GetRSAKeyString(RSAParameters key)
    {
        //we need some buffer
        var sw = new System.IO.StringWriter();
        //we need a serializer
        var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
        //serialize the key into the stream
        xs.Serialize(sw, key);
        //get the string from the stream
        return sw.ToString();
    }
    public void SetRSAKey(string key)
    {
        _csp.ImportParameters(GetRSAParameter(key));
    }
    public string EncryptStringRSA(string plainText, string baseFileName)
    {
        //we have a public key ... let's get the csp and load that key
        SetRSAKey(File.ReadAllText($"{baseFileName}.pub.xml"));
        //for encryption, always handle bytes...

        byte[] bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainText);
        //apply pkcs#1.5 padding and encrypt our data 
        byte[] bytesCypherText = _csp.Encrypt(bytesPlainTextData, false);
        //we might want a string representation of our cypher text... base64 will do
        return Convert.ToBase64String(bytesCypherText);
    }
    public string DecryptStringRSA(string cypherText, string baseFileName)
    {
        //first, get our bytes back from the base64 string ...
        var bytesCypherText = Convert.FromBase64String(cypherText);
        //we have a private key ... let's get the csp and load that key
        SetRSAKey(File.ReadAllText($"{baseFileName}.pri.xml"));
        //decrypt and strip pkcs#1.5 padding
        var bytesPlainTextData = _csp.Decrypt(bytesCypherText, false);
        //get our original plainText back...
        return System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
    }
    public String[] EncryptLargeStringRSA(String plainText, string baseFileName)
    {
        String[] result = new String[0], lines;
        String resultString;
        Aes aes, tempAES;
        int maxRetries = 10, currentTry = 0;
        bool twoWay = false;
        while(!twoWay && currentTry < maxRetries)
        {
            result = new String[2];
            aes = AES;
            tempAES = Aes.Create();
            tempAES.GenerateIV();
            tempAES.GenerateKey();
            tempAES.Padding = PaddingMode.PKCS7;
            AES = tempAES;
            result[0] = EncryptStringRSA($"\"{System.Text.Encoding.Unicode.GetString(tempAES.IV)}\",\"{System.Text.Encoding.Unicode.GetString(tempAES.Key)}\"", baseFileName);
            result[1] = EncryptStringAES(plainText);
            twoWay = DecryptStringAES(result[1]).CompareTo(plainText) == 0;
            if(twoWay)
            {
                resultString = String.Join<String>('\n', result);
                try
                {
                    lines = resultString.Split('\n');
                    twoWay = (DecryptLargeStringRSA(lines, baseFileName).CompareTo(plainText) == 0);
                }
                catch (Exception e)
                {
                    if (e.Message.CompareTo("Padding is invalid and cannot be removed.") == 0) {
                        twoWay = false;
                    } else
                    {
                        throw;
                    }
                }
            }
            AES = aes;
            currentTry++;
        }
        if(!twoWay)
        {
            Console.WriteLine("Unable to encrypt!");
        }
        return result;
    }
    public String DecryptLargeStringRSA(String[] cypherText, string baseFileName)
    {
        Aes aes = AES;
        Aes tempAES = Aes.Create();
        String[] parts = DecryptStringRSA(cypherText[0], baseFileName).Split("\",\"");
        tempAES.IV = System.Text.Encoding.Unicode.GetBytes(parts[0].Substring(1));
        String p1 = parts[1];
        String p1g = parts[1].Substring(0, (parts[1].Length - 1));
        tempAES.Key = System.Text.Encoding.Unicode.GetBytes(parts[1].Substring(0, (parts[1].Length - 1)));
        tempAES.Padding = PaddingMode.PKCS7;
        AES = tempAES;
        String result = DecryptStringAES(cypherText[1]);
        AES = aes;
        return result;
    }
}