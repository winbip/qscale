using System;
using System.Collections.Generic;
using System.Text;

namespace sCommonLib.Exceptions
{
    public class ExceptionWithoutControl: System.Exception
    {
        private string mTitleBarMessage;
        private string mHeadLineMessage;
        private string mErrorDescription;


        public string TitleBarMessage
        {
            get { return mTitleBarMessage; }
        }

        public string HeadLineMessage
        {
            get { return mHeadLineMessage; }
        }


        public string ErrorDescription
        {
            get { return mErrorDescription; }
        }

        public ExceptionWithoutControl(string TitleBarText, string HeadLineText, string ErrorMessage)
        {
            mTitleBarMessage = TitleBarText;
            mHeadLineMessage = HeadLineText;
            mErrorDescription = ErrorMessage;
        }
    }
}
