﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lbl.Server.Controllers
{
    using Lbl.Model;
    using Lbl.RequestModel;
    using Lbl.ViewModel;

    [RoutePrefix("api/ContentQuery")]
    public class ContentQueryController : BaseQueryController<Content, ContentRequestModel, ContentViewModel>
    {
        public ContentQueryController() : base(new BusinessDbContext())
        {

        }
    }
}
