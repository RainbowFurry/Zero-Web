using System.Web;

namespace Zero_Web.Content.csharp.Zero
{
    public class SessionManager
    {

        /// <summary>
        /// Get the Session Info
        /// </summary>
        public System.Web.SessionState.HttpSessionState Session = HttpContext.Current.Session;

        /// <summary>
        /// Create a Session Entry
        /// </summary>
        /// <param name="sessionName"></param>
        /// <param name="sessionContent"></param>
        public void CreateSession(string sessionName, string sessionContent)
        {
            Session[sessionName] = sessionContent;
        }

        /// <summary>
        /// Delete a Session Entry
        /// </summary>
        /// <param name="sessionName"></param>
        public void DeleteSession(string sessionName)
        {
            Session[sessionName] = null;
        }

        /// <summary>
        /// Get the Session Info
        /// </summary>
        /// <param name="sessionName"></param>
        public string getSession(string sessionName)
        {
            return (string)Session[sessionName];
        }

    }
}