namespace Lubala.Core.Pushing.Encoding
{
    internal static class CrypographyConstant
    {
        public const int WXBizMsgCrypt_OK = 0;
        public const int WXBizMsgCrypt_ValidateSignature_Error = -40001;
        public const int WXBizMsgCrypt_ParseXml_Error = -40002;
        public const int WXBizMsgCrypt_ComputeSignature_Error = -40003;
        public const int WXBizMsgCrypt_IllegalAesKey = -40004;
        public const int WXBizMsgCrypt_ValidateAppid_Error = -40005;
        public const int WXBizMsgCrypt_EncryptAES_Error = -40006;
        public const int WXBizMsgCrypt_DecryptAES_Error = -40007;
        public const int WXBizMsgCrypt_IllegalBuffer = -40008;
        public const int WXBizMsgCrypt_EncodeBase64_Error = -40009;
        public const int WXBizMsgCrypt_DecodeBase64_Error = -40010;
    }
}