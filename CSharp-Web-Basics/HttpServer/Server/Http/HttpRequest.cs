﻿using HttpServer.Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;

public class HttpRequest : IHttpRequest
{
    public HttpRequest(string requestString)
    {
        this.HeaderCollection = new HttpHeaderCollection();
        this.UrlParameters = new Dictionary<string, string>();
        this.QueryParameters = new Dictionary<string, string>();
        this.FormData = new Dictionary<string, string>();

        this.ParseRequest(requestString);
    }

    public Dictionary<string, string> FormData { get; }

    public HttpHeaderCollection HeaderCollection { get; }

    public string Path { get; protected set; }

    public Dictionary<string, string> QueryParameters { get; }

    public HttpRequestMethod RequestMethod { get; protected set; }

    public string Url { get; protected set; }

    public IHttpSession Session { get; set; }

    public Dictionary<string, string> UrlParameters { get; }

    public void AddUrlParameter(string key, string value)
    {
        if (!this.UrlParameters.ContainsKey(key))
        {
            this.UrlParameters.Add(key, value);
        }
    }

    private void ParseRequest(string requestString)
    {
        string[] requestLines = requestString
            .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        string[] requestLine = requestLines[0].Trim()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
        {
            throw new BadRequestException("Invalid request line");
        }

        this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
        this.Url = requestLine[1];
        this.Path = this.Url
            .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

        this.ParseHeaders(requestLines);
        this.ParseParameters();

        if (this.RequestMethod == HttpRequestMethod.POST)
        {
            this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
        }
    }

    private HttpRequestMethod ParseRequestMethod(string toUpper)
    {
        var content = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), toUpper);

        return content;
    }

    private void ParseHeaders(string[] requestLines)
    {
        int endIndex = Array.IndexOf(requestLines, string.Empty);

        for (int i = 1; i < endIndex; i++)
        {
            string[] headerArgs = requestLines[i]
                .Split(new[] { ": " }, StringSplitOptions.None);

            string key = headerArgs[0];
            string value = headerArgs[1];

            HttpHeader header = new HttpHeader(key, value);

            this.HeaderCollection.Add(header);
        }

        if (!this.HeaderCollection.ContainsKey("Host"))
        {
            throw new BadRequestException("Invalid request line");
        }
    }

    private void ParseParameters()
    {
        if (!this.Url.Contains("?"))
        {
            return;
        }

        string query = this.Url.Split('?')[1];
        this.ParseQuery(query, this.QueryParameters);
    }

    private void ParseQuery(string query, Dictionary<string, string> queryParameters)
    {
        if (!query.Contains("="))
        {
            return;
        }

        string[] queryPairs = query.Split('&');

        foreach (var queryPair in queryPairs)
        {
            string[] queryArgs = queryPair.Split('=');

            if (queryArgs.Length != 2)
            {
                continue;
            }

            queryParameters.Add(
                WebUtility.UrlDecode(queryArgs[0]),
                WebUtility.UrlDecode(queryArgs[1]));
        }
    }
}