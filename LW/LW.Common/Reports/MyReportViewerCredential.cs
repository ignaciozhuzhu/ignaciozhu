using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;

namespace LW.Common
{
    [Serializable]
    public class ReportViewerCredential : IReportServerCredentials
    {
        public ReportViewerCredential()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private string _username;
        private string _password;
        private string _domain;
        public Uri ReportServerUrl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        public ReportViewerCredential(string username, string password, string domain)
        {
            _username = username;
            _password = password;
            _domain = domain;
        }
        #region IReportServerCredentials Members
        /// <summary>
        /// 
        /// </summary>
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_username, _password, _domain);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authCookie"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public bool GetFormsCredentials(out Cookie authCookie,
            out string user, out string password, out string authority)
        {
            authCookie = null;
            user = _username;
            password = _password;
            authority = _domain;
            return false;
        }

        #endregion
    }
}