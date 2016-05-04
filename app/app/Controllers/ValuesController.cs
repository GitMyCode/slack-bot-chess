﻿using System;
using System.Web.Http;

namespace app.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        #region Methods

        public IHttpActionResult Get()
        {
            return this.Ok(new[] { "value1", "value2" });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        #endregion
    }
}