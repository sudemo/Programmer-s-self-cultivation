using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCCommunicationKit.Language;

namespace PLCCommunicationKit
{
    public class ReturnStatus //返回操作结果状态，可以使用泛型实现该类
    {
        public ReturnStatus()
        { }
        /// <summary>
        /// 指示本次访问是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 具体的错误描述
        /// </summary>
        public string returnMessage { get; set; } = StringResources.LanguageSet.UnknownError;

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
            return $"{StringResources.LanguageSet.ErrorCode}:{ErrorCode}{Environment.NewLine}{StringResources.LanguageSet.TextDescription}:{returnMessage}";
        }

        public ReturnStatus(string msg)
        {
            this.returnMessage = msg;
        }

        public ReturnStatus(int i, string msg)
        {
            this.ErrorCode = i;
            this.returnMessage = msg;

        }

        public ReturnStatus(bool arg)
        {
            this.IsSuccess = arg;
        }



        public static ReturnStatus<T> CreatSuccessStatus<T>()
        {
            return new ReturnStatus<T>
            {
                IsSuccess = true,
                ErrorCode = 0,
                returnMessage = StringResources.LanguageSet.SuccessText,
            };
        }
        /// <summary>
        /// 创建一个返回成功的结果，其返回的类型为泛型，包括了数字，字符串等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ReturnStatus<T> CreatSuccessStatus<T>(T value) //一个返回值为状态类型的方法，接收一个泛型值
        {
            return new ReturnStatus<T>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                returnMessage = StringResources.LanguageSet.SuccessText,
                Content = value
            };
        }
        public static ReturnStatus<T1, T2> CreatSuccessStatus<T1, T2>(T1 value1, T2 value2) //一个返回值为状态类型的方法，接收一个泛型值
        {

            return new ReturnStatus<T1, T2>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                returnMessage = StringResources.LanguageSet.SuccessText,
                Content1 = value1,
                Content2 = value2,
            };
        }
    }
    #region 有一个参数的
    public class ReturnStatus<T> : ReturnStatus
    //public class OperateResult<T> : OperateResult
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认的结果对象
        /// </summary>
        public ReturnStatus() : base()
        {
        }

        /// <summary>
        /// 使用指定的消息实例化一个默认的结果对象
        /// </summary>
        /// <param name="msg">错误消息</param>
        public ReturnStatus(string msg) : base(msg)
        {

        }

        /// <summary>
        /// 使用错误代码，消息文本来实例化对象
        /// </summary>
        /// <param name="err">错误代码</param>
        /// <param name="msg">错误消息</param>
        public ReturnStatus(int err, string msg) : base(err, msg)
        {

        }

        #endregion

        /// <summary>
        /// 用户自定义的泛型数据
        /// </summary>
        public T Content { get; set; }

    }
    #endregion
    #region 两个参数
    public class ReturnStatus<T1, T2> : ReturnStatus
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认的结果对象
        /// </summary>
        public ReturnStatus() : base()
        {
        }

        /// <summary>
        /// 使用指定的消息实例化一个默认的结果对象
        /// </summary>
        /// <param name="msg">错误消息</param>
        public ReturnStatus(string msg) : base(msg)
        {

        }

        /// <summary>
        /// 使用错误代码，消息文本来实例化对象
        /// </summary>
        /// <param name="err">错误代码</param>
        /// <param name="msg">错误消息</param>
        public ReturnStatus(int err, string msg) : base(err, msg)
        {

        }

        #endregion

        /// <summary>
        /// 用户自定义的泛型数据1
        /// </summary>
        public T1 Content1 { get; set; }

        /// <summary>
        /// 用户自定义的泛型数据2
        /// </summary>
        public T2 Content2 { get; set; }
    }
    #endregion
    



    public static class StringResources //设置语言
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
