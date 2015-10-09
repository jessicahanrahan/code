using System;
using System.Web;

namespace code.web.aspnet
{
  public delegate IHttpHandler ICreatePageInstances(string path_to_template, Type page_type);
}