﻿using System.Collections.Generic;

public interface IHttpRequest
{
    Dictionary<string, string> FormData { get; }

    HttpHeaderCollection HeaderCollection { get; }

    string Path { get; }

    Dictionary<string, string> QueryParameters { get; }

    HttpRequestMethod RequestMethod { get; }

    string Url { get; }

    IHttpSession Session { get; set; }

    Dictionary<string, string> UrlParameters { get; }

    void AddUrlParameter(string key, string value);
}