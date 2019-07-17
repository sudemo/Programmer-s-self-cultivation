using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCCommunicationLibrary.Language;

namespace PLCCommunicationLibray.SocketBase
{
    class status
    {
        /// <summary>
        /// 指示本次访问是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 具体的错误描述
        /// </summary>
        public string Message { get; set; } = StringResources.LanguageSet.UnknownError;

        /// <summary>
        /// 具体的错误代码
        /// </summary>
        public int ErrorCode { get; set; } = 10000;

        /// <summary>
        /// 获取错误代号及文本描述
        /// </summary>
        /// <returns>包含错误码及错误消息</returns>
        public string ToMessageShowString()
        {
           return $"{StringResources.LanguageSet.ErrorCode}:{ErrorCode}{Environment.NewLine}{StringResources.LanguageSet.TextDescription}:{Message}";
        }
    }

    public static class StringResources
    {
        #region Constractor

        static StringResources()
        {
            if (System.Globalization.CultureInfo.CurrentCulture.ToString().StartsWith("zh"))
            {
                SetLanguageChinese();
            }
            else
            {
                SeteLanguageEnglish();
            }
        }

        #endregion


        /// <summary>
        /// 获取或设置系统的语言选项 ->
        /// Gets or sets the language options for the system
        /// </summary>
        public static DefaultLanguage LanguageSet = new DefaultLanguage();

        /// <summary>
        /// 将语言设置为中文 ->
        /// Set the language to Chinese
        /// </summary>
        public static void SetLanguageChinese()
        {
            LanguageSet = new DefaultLanguage();
        }

        /// <summary>
        /// 将语言设置为英文 ->
        /// Set the language to English
        /// </summary>
        public static void SeteLanguageEnglish()
        {
            LanguageSet = new English();
        }
    }
}
