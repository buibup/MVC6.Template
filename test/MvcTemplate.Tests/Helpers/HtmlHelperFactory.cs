﻿using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.ModelBinding.Metadata;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Routing;
using NSubstitute;
using System;

namespace MvcTemplate.Tests
{
    public static class HtmlHelperFactory
    {
        public static IHtmlHelper CreateHtmlHelper()
        {
            return CreateHtmlHelper<Object>(null);
        }
        public static IHtmlHelper<T> CreateHtmlHelper<T>(T model)
        {
            ICompositeMetadataDetailsProvider details = Substitute.For<ICompositeMetadataDetailsProvider>();
            IModelMetadataProvider provider = new DefaultModelMetadataProvider(details);
            IHtmlHelper<T> html = Substitute.For<IHtmlHelper<T>>();

            html.MetadataProvider.Returns(provider);
            html.ViewContext.Returns(new ViewContext());
            html.ViewContext.RouteData = new RouteData();
            html.ViewContext.HttpContext = Substitute.For<HttpContext>();
            html.ViewContext.ViewData.Model = model;

            return html;
        }
    }
}