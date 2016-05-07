using System;
using System.Collections.Specialized;
using System.Net;
using System.Web.Http;

namespace app.Controllers
{
    public class BotController : ApiController
    {
        #region Fields

        private readonly string webhookurl = "https://hooks.slack.com/services/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";

        #endregion

        #region Methods

        public IHttpActionResult Get(string text)
        {
           
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["channel"] = "#chess-bot-test";
                data["test"] = "yo bro";

                var response = wb.UploadValues(this.webhookurl, "POST", data);
            }

            return this.Ok();
        }

        #endregion
    }
}